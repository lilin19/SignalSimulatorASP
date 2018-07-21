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
        public static Dictionary<int, Signal> _Map = new Dictionary<int, Signal>();
        private static System.Timers.Timer _RequestTimer = new System.Timers.Timer();
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

        public static void Edit(int poolnum, int num, float press, int temp, float flow, DateTime da)
        {
            Signal r = new SimulatedSignal(num,press,temp,flow,da);
            DataCentre._Pool[poolnum] = r;
            _Map[poolnum] = r;
        }

        public static void Delete(int poolnum)
        {
            DataCentre._Pool.Remove(_Map[poolnum]);
            _Map.Remove(poolnum);
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

    }
}
