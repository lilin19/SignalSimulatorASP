using SignalSimulator;
using SignalSimulatorWeb.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public ActionResult Save(SaveRequest sr)
        {
            float.Parse(sr.Pressure);
            int.Parse(sr.Temp);
            float.Parse(sr.Flow);
            DateTime.Parse(sr.Time);
            Signal s = new SimulatedSignal(sr.Num, float.Parse(sr.Pressure), int.Parse(sr.Temp), float.Parse(sr.Flow), DateTime.Parse(sr.Time));

            DataCentre._Pool[sr.index] = s;
            return Json("success", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(DeleteRequest sr)
        {
            DataCentre._Pool.Remove(BusinessLogics.SearchIndex(sr.index)) ;
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
            List<Signal> l = new List<Signal>();
            for (int i = BusinessLogics.SearchCount() - 1; i > 0; i--)
            {
                if ((DateTime.Compare(BusinessLogics.SearchIndex(i).GetDateInstance(), sr.From) >= 0) && (DateTime.Compare(BusinessLogics.SearchIndex(i).GetDateInstance(), sr.To) <= 0))
                {
                    l.Add(BusinessLogics.SearchIndex(i));
                }
            }
            return Json(l, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchChart(SearchRequest sr)
        {

            ChartAxis ca = new ChartAxis();
            ca.flow = BusinessLogics.SearchFlow(sr.From, sr.To);
            ca.press = BusinessLogics.SearchPressure(sr.From, sr.To);
            ca.time = BusinessLogics.SearchTime(sr.From, sr.To);
            ca.temp = BusinessLogics.SearchTemp(sr.From, sr.To);
            return Json(ca, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchStats(SearchRequest sr)
        {

            StatisDatas cd = new StatisDatas();
            BusinessLogics.GetLists(sr.From,sr.To);
            cd.avgFlow = BusinessLogics.avgFlow;
            cd.avgPressure = BusinessLogics.maxPressure;
            cd.avgTemp = BusinessLogics.avgTemp;
            cd.maxFlow = BusinessLogics.maxFlow;
            cd.maxPressure = BusinessLogics.maxPressure;
            cd.maxTemp = BusinessLogics.maxTemp;
            cd.minPressure = BusinessLogics.minPressure;
            cd.minTemp = BusinessLogics.minTemp;
            cd.minFlow = BusinessLogics.minFlow;
            cd.minute = BusinessLogics.minute;

            //cd.avgFlow = new List<float>();
            //cd.avgPressure = new List<float>();
            //cd.avgTemp = new List<float>();
            //cd.maxFlow = new List<float>();
            //cd.maxPressure = new List<float>();
            //cd.maxTemp = new List<int>();
            //cd.minPressure = new List<float>();
            //cd.minTemp = new List<int>();
            //cd.minFlow = new List<float>();
            //cd.minute = new List<string>();
            return Json(cd, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Simulator()
        {
            
            return View();
        }
        public ActionResult Management()
        {
            return View();
        }

        public ActionResult Stats()
        {
            return View();
        }

        public ActionResult Curves()
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