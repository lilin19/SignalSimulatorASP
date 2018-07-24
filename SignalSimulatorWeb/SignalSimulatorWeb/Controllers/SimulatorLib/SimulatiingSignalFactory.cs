using SignalSimulatorWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalSimulator
{

    //method to create signal
    public abstract class SignalFactory
    {
        
        public abstract Signal CreateSignal(int num);
    }

    //for the random simulator
    class SimulatiingSignalFactory : SignalFactory
    {
        int key = 0;
        int temp = 50;
        public override Signal CreateSignal(int num)
        {
            Random r = new Random();
            float _MudPressure = (float)r.NextDouble() * 10 + 45;
            temp += r.Next(2, 5);
            if (temp >= 150)
            {
                temp = 50;
            }
            r = new Random();
            float _FlowRate = (float)r.NextDouble() * 100 + 50;
            DateTime _Time = DateTime.Now;
            SimulatedSignal s = new SimulatedSignal(num, _MudPressure, temp, _FlowRate, _Time);
            s._Key = key;
            key++;
            return s;
        }
    }
}
