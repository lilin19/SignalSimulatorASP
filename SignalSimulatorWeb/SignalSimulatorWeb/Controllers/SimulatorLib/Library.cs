using SignalSimulatorWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalSimulator
{
    /**
     *Class for get max, min and average of signal 
     * 
     */
    class Library
    {
        
        public float GetMaxPressure(List<Signal> input)
        {
            float max=0;
            for(int i=0; i < input.Count; i++)
            {
                if (input[i].GetPressureInstance() > max)
                {
                    max = input[i].GetPressureInstance();
                }
            }
            return max;
        }

        public float GetAvgPressure(List<Signal> input)
        {
            float avg = 0;
            for (int i = 0; i < input.Count; i++)
            {
                avg += input[i].GetPressureInstance();
            }
            avg = avg / input.Count;
            return avg;
        }

        public float GetAvgFlow(List<Signal> input)
        {
            float avg = 0;
            for (int i = 0; i < input.Count; i++)
            {
                avg += input[i].GetFlowInstance();
            }
            avg = avg / input.Count;
            return avg;
        }

        public float GetAvgTemp(List<Signal> input)
        {
            float avg = 0;
            for (int i = 0; i < input.Count; i++)
            {
                avg += input[i].GetTempInstance();
            }
            avg = avg / input.Count;
            return avg;
        }


        public int GetMaxTemp(List<Signal> input)
        {
            int max = 0;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i].GetTempInstance() > max)
                {
                    max = input[i].GetTempInstance();
                }
            }
            return max;
        }

        public float GetMaxFlow(List<Signal> input)
        {
            float max = 0;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i].GetFlowInstance() > max)
                {
                    max = input[i].GetFlowInstance();
                }
            }
            return max;
        }




        public int GetMinTemp(List<Signal> input)
        {
            int min = 150;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i].GetTempInstance() < min)
                {
                    min = input[i].GetTempInstance();
                }
            }
            return min;
        }

        public float GetMinFlow(List<Signal> input)
        {
            float min = 150;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i].GetFlowInstance() < min)
                {
                    min = input[i].GetFlowInstance();
                }
            }
            return min;
        }

        public float GetMinPressure(List<Signal> input)
        {
            float min = 55;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i].GetPressureInstance() < min)
                {
                    min = input[i].GetPressureInstance();
                }
            }
            return min;
        }
    }
}
