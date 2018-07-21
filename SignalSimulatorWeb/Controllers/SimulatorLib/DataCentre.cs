using SignalSimulatorWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalSimulator
{
    /// <summary>
    /// The static containers for the signals
    /// </summary>
    public class DataCentre
    {
        public static Dictionary<string, string> _ElementMap = new Dictionary<string, string>();
        public static List<Signal> _Pool = new List<Signal>();

        //editing interface
        public static void AddSignal(Signal s)
        {
            _Pool.Add(s);
            
        }
        public static void DeleteSignal(int i)
        {
            _Pool.RemoveAt(i);
        }

        /**
         * Generate a Pressure list splited from signals
         */ 
        public static List<float> ToPressureList(List<Signal> input)
        {
            List<float> l = new List<float>(input.Count);
            for(int i=0; i < input.Count; i++)
            {
                l.Add(input[i].GetPressureInstance());
            }
            return l;
        }

        /**
         * Generate a temperature list splited from signals
         */
        public static List<int> ToTempList(List<Signal> input)
        {
            List<int> l = new List<int>(input.Count);
            for (int i = 0; i < input.Count; i++)
            {                l.Add((int)input[i].GetTempInstance());
            }
            return l;
        }

        /**
         * Generate a flow list splited from signals
         */
        public static List<float> ToFlowList(List<Signal> input)
        {
            List<float> l = new List<float>(input.Count);
            for (int i = 0; i < input.Count; i++)
            {
                l.Add(input[i].GetFlowInstance());
            }
            return l;
        }

        /**
         * Generate a date list splited from signals
         */
        public static List<string> ToDateStringList(List<Signal> input)
        {
            List<string> l = new List<string>(input.Count);
            for (int i = 0; i < input.Count; i++)
            {
                l.Add(input[i].GetDateInstance().ToLongTimeString());
            }
            return l;
        }

        //for thest
        public static string GetString()
        {
            string output = "";
            if (_Pool[0] != null)
            {
               for (int i=_Pool.Count-1; i>0; i--)
               {

                output += _Pool[i].GetString();
               }
            }
            return output;
        }

        /**
         * Select the time span for the signal set
         */
        public static List<Signal> GetDateRange(DateTime from, DateTime to)
        {
            List<Signal> l = new List<Signal>();
            if (DateTime.Compare(from, to) <= 0)
            {
                for (int i = 0; i < _Pool.Count; i++)
                {
                    if ((DateTime.Compare(_Pool[i].GetDateInstance(), from) >= 0) && (DateTime.Compare(_Pool[i].GetDateInstance(), to) <= 0))
                    {
                        l.Add(_Pool[i]);
                    }
                }
                
                return l;
            }
            else
            {
                return null;
            }
        }

        /**
         * Find the max Cycle number
         */
        public static int GetNumMax(List<Signal> input)
        {
            int max=0;
            for(int i=0; i<input.Count; i++)
            {
                if (input[i].GetNumInstance() > max)
                {
                    max = input[i].GetNumInstance();
                }
            }
            return max;
        }

        /**
         * Find the List of List divided by Cycle numbers.
         */
        public static List<List <Signal>> GetMinuteLists(List<Signal> input)
        {
            List<List<Signal>> ll = new List<List<Signal>>();
            for (int i=0; i<=GetNumMax(input); i++)
            {
                List<Signal> l = new List<Signal>();
                for(int q=0; q<input.Count; q++)
                {
                    if(input[q].GetNumInstance() == i)
                    {
                        l.Add(input[q]);
                    }
                }
                ll.Add(l);

            }
            return ll;
        }


    }
}
