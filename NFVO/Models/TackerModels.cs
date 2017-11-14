using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NFVO.Models
{
    public class TackerModels
    {

    }

    public class VnfdModels
    {
        public String TenantId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public List<VnfdServiceTypeModels> ServiceTypes { get; set; }
        public VnfdAttributeModels Attributes { get; set; }
        public String CreatedAt { get; set; }
        public String UpdatedAt { get; set; }
        public String Id { get; set; }
        public String TemplateSource { get; set; }
    }

    public class VnfdServiceTypeModels
    {
        public String ServiceType { get; set; }
        public String Id { get; set; }
    }

    public class VnfdAttributeModels
    {
        public VnfdAttributeVnfdModels Vnfd { get; set; }
    }

    public class VnfdAttributeVnfdModels
    {
        public String ToscaDefinitionsVersion { get; set; }
        public String Description { get; set; }
        public MetaDataModels MetaData { get; set; }
        public TopologyTemplateModels TopologyTemplate { get; set; }
    }

    public class MetaDataModels
    {
        public String TemplateName { get; set; }
    }

    public class TopologyTemplateModels
    {
        public NodeTemplateModels NodeTemplates { get; set; }
    }
    
    public class NodeTemplateModels
    {
        public VduModels Vdu { get; set; }
    }

    public class VduModels
    {
        public String Type { get; set; }
        public CapabilitiesModels Capabilities { get; set; }
        public VduPropertyModels Properties { get; set; }
    }

    public class CapabilitiesModels
    {
        public NfvComputeModels NfvCompute { get; set; }
    }

    public class NfvComputeModels
    {
        public NfvComputePropertyModels Properties { get; set; }
    }

    public class NfvComputePropertyModels
    {
        public String NumCpus { get; set; }
        public String MemSize { get; set; }
        public String DiskSize { get; set; }
    }

    public class VduPropertyModels
    {
        public String Image { get; set; }
    }

    public class CpModels
    {
        public String Type { get; set; }
        public CpPropertyModels Properties { get; set; }
        public List<RequirementModels> Requirements { get; set; }
    }

    public class CpPropertyModels
    {
        public String Order { get; set; }
        public String Management { get; set; }
        public String AntiSpoofingProtection { get; set; }
    }

    public class RequirementModels
    {
        public VirtualLinkModels VirtualLink { get; set; }
        public VirtualBindingModels VirtualBinding { get; set; }
    }

    public class VirtualLinkModels
    {
        public String Node { get; set; }
    }

    public class VirtualBindingModels
    {
        public String Node { get; set; }
    }

    public class VlModels
    {
        public String Type { get; set; }
        public VlPropertyModels Properties { get; set; }
    }

    public class VlPropertyModels
    {
        public String Vendor { get; set; }
        public String NetworkName { get; set; }
    }

    public class VnfModels
    {
        public String TenantId { get; set; }
        public String VnfdId { get; set; }
        public String VimId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Status { get; set; }
        public VnfAttributeModels Attributes { get; set; }
        public VnfPlacementAttrModels PlacementAttr { get; set; }
        public String CreatedAt { get; set; }
        public String UpdatedAt { get; set; }
        public String InstanceId { get; set; }
        public String MgmtUrl { get; set; }
        public String ErrorReason { get; set; }
        public String Id { get; set; }
    }

    public class VnfAttributeModels
    {
        public VnfAttributeConfigModels Config { get; set; }
        public VnfAttributeParamValueModels ParamValues { get; set; }
        public String HeatTemplate { get; set; }
        public String MonitoringPolicy { get; set; }
    }

    public class VnfAttributeConfigModels
    {
        public VnfAttributeConfigVduModels Vdus { get; set; }
    }

    public class VnfAttributeConfigVduModels
    {
        public VnfAttributeConfigVduVduModels Vdu { get; set; }
    }

    public class VnfAttributeConfigVduVduModels
    {
        public VnfAttributeConfigVduVduConfigModels Config { get; set; }
    }

    public class VnfAttributeConfigVduVduConfigModels
    {
        public String Firewall { get; set; }
    }

    public class VnfAttributeParamValueModels
    {
        public VnfAttributeParamValueVduModels Vdus { get; set; }
    }

    public class VnfAttributeParamValueVduModels
    {
        public VnfAttributeParamValueVduVduModels Vdu { get; set; }
    }

    public class VnfAttributeParamValueVduVduModels
    {
        public VnfAttributeParamValueVduVduParamModels Config { get; set; }
    }

    public class VnfAttributeParamValueVduVduParamModels
    {
        public String VduName { get; set; }
    }

    public class VnfPlacementAttrModels
    {
        public String RegionName { get; set; }
        public String VimName { get; set; }
    }

    public class VnfResourceModels
    {
        public String Type { get; set; }
        public String Name { get; set; }
        public String Id { get; set; }
    }

    public class VimModels
    {
        public String TenantId { get; set; }
        public String Type { get; set; }
        public String AuthUrl { get; set; }
        public VimAuthCredModels AuthCred { get; set; }
        public VimProjectModels VimProject { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String IsDefault { get; set; }
        public String Status { get; set; }
        public String CreatedAt { get; set; }
        public String UpdatedAt { get; set; }
        public String Id { get; set; }
    }

    public class VimAuthCredModels
    {
        public String UserName { get; set; }
        public String UserDomainName { get; set; }
        public String Password { get; set; }
        public String ProjectName { get; set; }
        public String AuthUrl { get; set; }
        public String ProjectId { get; set; }
        public String ProjectDomainName { get; set; }
    }

    public class VimProjectModels
    {
        public String Name { get; set; }
        public String ProjectDomainName { get; set; }
    }

    public class EventModels
    {
        public String EventType { get; set; }
        public String ResourceId { get; set; }
        public String Timestamp { get; set; }
        public String EventDetails { get; set; }
        public String ResourceState { get; set; }
        public String Id { get; set; }
        public String ResourceType { get; set; }
    }

    public class VnffgdModels
    {
        public String TenantId { get; set; }
        public String Name { get; set; }
        public VnffgdTemplateModels template { get; set; }
        public String Description { get; set; }
    }

    public class VnffgdTemplateModels
    {
        public VnffgdTemplateVnffgdModels Vnffgd { get; set; }
    }

    public class VnffgdTemplateVnffgdModels
    {
        public String ToscaDefinitionsVersion { get; set; }
        public String Description { get; set; }
        public VnffgdTopologyTemplateModels TopologyTemplate { get; set; }
    }

    public class VnffgdTopologyTemplateModels
    {

    }

    public class NsdModels
    {
        public String TenantId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
    }
}