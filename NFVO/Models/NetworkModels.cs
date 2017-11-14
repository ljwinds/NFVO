using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Collections;

namespace NFVO.Models
{
    public class NetworkModels
    {
        public String ID { get; set; }
        public String Name { get; set; }
        public String ProviderNetworkType { get; set; }
        public String ProviderPhysicalNetwork { get; set; }
        public String ProjectID { get; set; }
        public String RouterExternal { get; set; }
        public String Shared { get; set; }

        public List<String> Subnets { get; set; }
    }

    public class SubnetModels
    {
        public String ID { get; set; }
        public String Name { get; set; }
        public String ProjectID { get; set; }
        public String NetworkID { get; set; }
        public String GatewayIP { get; set; }
        public String CIDR { get; set; }

        public List<AllocationPoolModels> AllocationPools { get; set; }
    }

    public class RouterModels
    {
        public String ID { get; set; }
        public String ProjectID { get; set; }
        public String Name { get; set; }

        public GatewayInfoModels ExternalGatewayInfo { get; set; }
    }

    public class PortModels
    {
        public String DeviceID { get; set; }
        public String ProjectID { get; set; }
        public String NetworkID { get; set; }
        public String MacAddress { get; set; }

        public List<FixedIPModels> FixedIPs { get; set; }
    }

    public class NetworkRouterPortsModels
    {
        public List<NetworkModels> Networks { get; set; }

        // Hashtable<NetworkModels, List<SubnetModels>>
        public Hashtable NetworkSubnets { get; set; }

        // Hashtable<RouterModels, List<PortModels>>
        public Hashtable RouterPorts { get; set; }
    }

    public class GatewayInfoModels
    {
        public String NetworkID { get; set; }
        public String EnableSNAT { get; set; }

        public List<FixedIPModels> ExternalFixedIPs { get; set; }
    }

    public class FixedIPModels
    {
        public String SubnetID { get; set; }
        public String IPAddress { get; set; }
    }

    public class AllocationPoolModels
    {
        public String Start { get; set; }
        public String End { get; set; }
    }

    public class NetworkDBContext : DbContext
    {
        public DbSet<NetworkModels> Networks { get; set; }
    }
}