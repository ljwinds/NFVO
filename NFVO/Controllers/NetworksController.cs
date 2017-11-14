using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NFVO.Models;
using NFVO.ServiceInterface;
using System.Collections;
using System.IO;

namespace NFVO.Controllers
{
    public class NetworksController : Controller
    {
        private NetworkDBContext db = new NetworkDBContext();

        // GET: Networks
        public ActionResult Index()
        {
            NeutronAPI n = new NeutronAPI();
            NetworkRouterPortsModels nrp = new NetworkRouterPortsModels();

            nrp.Networks = n.ListNetworks();

            // 生成网络和所包含的子网的哈希表
            nrp.NetworkSubnets = new Hashtable();
            foreach (NetworkModels network in nrp.Networks)
            {
                List<SubnetModels> subnets = new List<SubnetModels>();
                foreach (String subnet_id in network.Subnets)
                {
                    SubnetModels subnet = n.GetSubnet(subnet_id);
                    subnets.Add(subnet);
                }
                nrp.NetworkSubnets.Add(network, subnets);
            }

            // 生成路由器和所配置的接口的哈希表
            nrp.RouterPorts = new Hashtable();
            List<RouterModels> routers = n.ListRouters();
            foreach (RouterModels router in routers)
            {
                List<PortModels> router_port_list = n.ListRouterPorts(router.ID);
                nrp.RouterPorts.Add(router, router_port_list);
            }

            return View(nrp);
        }

        [HttpPost]
        public ActionResult CreateNetwork()
        {
            StreamReader sr = new StreamReader(Request.InputStream);
            String json_str = sr.ReadToEnd();
            return Json(json_str);
        }

        // GET: Networks/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NetworkModels network = db.Networks.Find(id);
            if (network == null)
            {
                return HttpNotFound();
            }
            return View(network);
        }

        // GET: Networks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Networks/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,name,provider_network_type,subnets,router_external,shared")] NetworkModels network)
        {
            if (ModelState.IsValid)
            {
                db.Networks.Add(network);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(network);
        }

        // GET: Networks/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NetworkModels network = db.Networks.Find(id);
            if (network == null)
            {
                return HttpNotFound();
            }
            return View(network);
        }

        // POST: Networks/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name,provider_network_type,subnets,router_external,shared")] NetworkModels network)
        {
            if (ModelState.IsValid)
            {
                db.Entry(network).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(network);
        }

        // GET: Networks/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NetworkModels network = db.Networks.Find(id);
            if (network == null)
            {
                return HttpNotFound();
            }
            return View(network);
        }

        // POST: Networks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NetworkModels network = db.Networks.Find(id);
            db.Networks.Remove(network);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
