using SignalSimulatorWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SignalSimulator
{
    /// <summary>
    /// controller for the simulator
    /// </summary>
    class BusinessLogics
    {
        static Library _Lib = new Library();
        private static System.Timers.Timer _RequestTimer = new System.Timers.Timer();

        public static List<float> maxPressure = new List<float>();
        public static List<float> maxFlow = new List<float>();
        public static List<int> maxTemp = new List<int>();
        public static List<float> avgPressure = new List<float>();
        public static List<float> avgFlow = new List<float>();
        public static List<float> avgTemp = new List<float>();
        public static List<float> minPressure = new List<float>();
        public static List<float> minFlow = new List<float>();
        public static List<int> minTemp = new List<int>();
        public static List<string> minute = new List<string>();
        public static void Initialize()
        {
            //add settings here
        }

        /**
         *request signal 
         * 
         */
        public static void ServiceStart()
        {
            _RequestTimer = new System.Timers.Timer(1000);
            _RequestTimer.Elapsed += RequestSignal;
            _RequestTimer.Start();
        }
        public static void RequestSignal(Object myObject,
                                    EventArgs myEventArgs)
        {

            DataAccess.DataCollect();
        }

        public static void ServiceStop()
        {
            if (_RequestTimer != null)
            {
                _RequestTimer.Stop();
            }
        }

        public static void SimulatorStop()
        {
            DataAccess.Halt();
        }

        public static void SimulatorStart()
        {
            DataAccess.Start();
        }


        public static void Delete(int poolnum)
        {
            //DataCentre._Pool.Remove(_Map[poolnum]);
            //_Map.Remove(poolnum);
        }

        public static List<float> SearchPressure(DateTime from, DateTime to)
        {
            return DataCentre.ToPressureList(DataCentre.GetDateRange(from, to));
        }
        public static List<string> SearchTime(DateTime from, DateTime to)
        {
            return DataCentre.ToDateStringList(DataCentre.GetDateRange(from, to));
        }
        public static List<List<Signal>> SearchTimeLists(DateTime from, DateTime to)
        {
            return DataCentre.GetMinuteLists((DataCentre.GetDateRange(from, to)));
        }
        public static List<float> SearchFlow(DateTime from, DateTime to)
        {
            return DataCentre.ToFlowList(DataCentre.GetDateRange(from, to));
        }
        public static List<int> SearchTemp(DateTime from, DateTime to)
        {
            return DataCentre.ToTempList(DataCentre.GetDateRange(from, to));
        }
        public static Signal SearchIndex(int i)
        {
            return DataCentre._Pool[i];
        }
        public static int SearchCount()
        {
            return DataCentre._Pool.Count;
        }

        public static void GetLists(DateTime from, DateTime to)
        {


            if (DateTime.Compare(from, to) < 0)
            {

                maxPressure = new List<float>();
                maxFlow = new List<float>();
                maxTemp = new List<int>();
                avgPressure = new List<float>();
                avgFlow = new List<float>();
                avgTemp = new List<float>();
                minPressure = new List<float>();
                minFlow = new List<float>();
                minTemp = new List<int>();
                minute = new List<string>();
                for (int i = 0; i < BusinessLogics.SearchTimeLists(from, to).Count; i++)
                {
                    var x = BusinessLogics.SearchTimeLists(from, to)[i].Count;
                    if (x != 0)
                    {
                        minute.Add(BusinessLogics.SearchTimeLists(from, to)[i][0].GetDateInstance().ToLongTimeString());
                    }
                }
                for (int i = 0; i < BusinessLogics.SearchTimeLists(from, to).Count; i++)
                {
                    var x = BusinessLogics.SearchTimeLists(from, to)[i].Count;
                    if (x != 0)
                    {
                        maxPressure.Add(_Lib.GetMaxPressure(BusinessLogics.SearchTimeLists(from, to)[i]));
                    }
                }
                for (int i = 0; i < BusinessLogics.SearchTimeLists(from, to).Count; i++)
                {
                    var x = BusinessLogics.SearchTimeLists(from, to)[i].Count;
                    if (x != 0)
                    {
                        maxFlow.Add(_Lib.GetMaxFlow(BusinessLogics.SearchTimeLists(from, to)[i]));
                    }
                }
                for (int i = 0; i < BusinessLogics.SearchTimeLists(from, to).Count; i++)
                {
                    var x = BusinessLogics.SearchTimeLists(from, to)[i].Count;
                    if (x != 0)
                    {
                        maxTemp.Add(_Lib.GetMaxTemp(BusinessLogics.SearchTimeLists(from, to)[i]));
                    }
                }

                for (int i = 0; i < BusinessLogics.SearchTimeLists(from, to).Count; i++)
                {
                    var x = BusinessLogics.SearchTimeLists(from, to)[i].Count;
                    if (x != 0)
                    {
                        avgPressure.Add(_Lib.GetAvgPressure(BusinessLogics.SearchTimeLists(from, to)[i]));
                    }
                }
                for (int i = 0; i < BusinessLogics.SearchTimeLists(from, to).Count; i++)
                {
                    var x = BusinessLogics.SearchTimeLists(from, to)[i].Count;
                    if (x != 0)
                    {
                        avgFlow.Add(_Lib.GetAvgFlow(BusinessLogics.SearchTimeLists(from, to)[i]));
                    }
                }
                for (int i = 0; i < BusinessLogics.SearchTimeLists(from, to).Count; i++)
                {
                    var x = BusinessLogics.SearchTimeLists(from, to)[i].Count;
                    if (x != 0)
                    {
                        avgTemp.Add(_Lib.GetAvgTemp(BusinessLogics.SearchTimeLists(from, to)[i]));
                    }
                }

                for (int i = 0; i < BusinessLogics.SearchTimeLists(from, to).Count; i++)
                {
                    var x = BusinessLogics.SearchTimeLists(from, to)[i].Count;
                    if (x != 0)
                    {
                        minPressure.Add(_Lib.GetMinPressure(BusinessLogics.SearchTimeLists(from, to)[i]));
                    }
                }
                for (int i = 0; i < BusinessLogics.SearchTimeLists(from, to).Count; i++)
                {
                    var x = BusinessLogics.SearchTimeLists(from, to)[i].Count;
                    if (x != 0)
                    {
                        minFlow.Add(_Lib.GetMinFlow(BusinessLogics.SearchTimeLists(from, to)[i]));
                    }
                }
                for (int i = 0; i < BusinessLogics.SearchTimeLists(from, to).Count; i++)
                {
                    var x = BusinessLogics.SearchTimeLists(from, to)[i].Count;
                    if (x != 0)
                    {
                        minTemp.Add(_Lib.GetMinTemp(BusinessLogics.SearchTimeLists(from, to)[i]));
                    }
                }
            }
        }

    }
}
