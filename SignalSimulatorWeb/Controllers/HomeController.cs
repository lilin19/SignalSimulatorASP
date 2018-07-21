using SignalSimulator;
using SignalSimulatorWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web.Mvc;

namespace SignalSimulatorWeb.Controllers
{

    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Start()
        {
            BusinessLogics.SimulatorStart();
            BusinessLogics.ServiceStart();
            return Json("success", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(EditRequest er)
        {
            var y = BusinessLogics._Map;
            Signal s = BusinessLogics._Map[er.info];
                     //查到了该学生的详细
             if (s != null)
                             {
                                 //找到该学生的信息，则在Details视图中显示，将该学生的信息对象传过去。
                 return View("Edit", s);
                             }
                         else
            {
                                //没有查到学生信息明细，则返回学生列表
                 return RedirectToAction("StudentList");
                             }
          
        }

        public ActionResult Save()
        {
            return Json("success", JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Stop()
        {
            BusinessLogics.SimulatorStop();
            BusinessLogics.ServiceStop();
            return Json("success", JsonRequestBehavior.AllowGet);

        }
        public ActionResult Search(SearchRequest sr)
        {
            BusinessLogics._Map.Clear();
            List<Signal> l = new List<Signal>();
            for (int i = BusinessLogics.SearchCount() - 1; i > 0; i--)
            {
                if ((DateTime.Compare(BusinessLogics.SearchIndex(i).GetDateInstance(), sr.From) >= 0) && (DateTime.Compare(BusinessLogics.SearchIndex(i).GetDateInstance(), sr.To) <= 0))
                {
                    l.Add(BusinessLogics.SearchIndex(i));
                    var x = BusinessLogics.SearchIndex(i);
                    var y = BusinessLogics._Map;
                    BusinessLogics._Map.Add(l.Count-1, BusinessLogics.SearchIndex(i));
                }
            }
            return Json(l, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Simulator()
        {
            
            return View();
        }
        public ActionResult Management()
        {
            return View();
        }

        public ActionResult RequestData()
        {
      
            List<Signal> latest = new List<Signal>();
            for (int i = DataCentre._Pool.Count() - 1; i > 0; i--)
            {
                Signal sig = BusinessLogics.SearchIndex(i);
                latest.Add(sig);
                if (i == (BusinessLogics.SearchCount() - 30))
                {
                    i = 0;
                }
            }
            return Json(latest, JsonRequestBehavior.AllowGet);
        }
    }


    public class AjaxTestController : Controller
    {
        //
        // GET: /AjaxTest/



        public ActionResult FirstAjax()
        {

            return Json(Pool.pool.Count, JsonRequestBehavior.AllowGet);
        }
        public ActionResult writerequest(Request r)
        {
            Message msg = new Message();
            msg.Name = r.Name;
            msg.Time = DateTime.Now.ToString();
            msg.Text = r.Text;
            Pool.pool.Add(msg);
            return Json(Pool.pool, JsonRequestBehavior.AllowGet);
        }

    }
}