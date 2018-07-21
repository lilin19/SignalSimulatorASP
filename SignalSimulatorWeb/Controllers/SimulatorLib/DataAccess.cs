using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
namespace SignalSimulator
{
    class DataAccess
    {
        private static System.Timers.Timer _MyTimer = new System.Timers.Timer();
        static int _CycleNum = 0;
        //timer for adding the cycle number
        static SignalGenerator _Sg = new SignalGenerator();

        /**
         *Controlling cycle number interface
         */
        public static void Start()
        {
            _MyTimer = new System.Timers.Timer(6000);
            _MyTimer.Elapsed += TimerEventProcessor;
            _MyTimer.Start();
        }
        public static void Halt()
        {
            _MyTimer.Stop();
        }

        /**
         *bind the event for adding the cycle number
         */
        private static void TimerEventProcessor(Object myObject,
                                    EventArgs myEventArgs)
        {
            _CycleNum++;
        }

        public static void DataCollect()
        {
            DataCentre.AddSignal(_Sg.StartDiscreteMode(_CycleNum));
        }

    }
} 
