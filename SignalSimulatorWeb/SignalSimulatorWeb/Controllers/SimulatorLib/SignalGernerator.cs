using SignalSimulatorWeb.Models;
using System;
using System.Threading.Tasks;
using System.Timers;


namespace SignalSimulator
{
    /**
     *Generating the Signal by two method 
     * with periodic mode or requesting mode
     */
    class SignalGenerator
    {
        int key = 0;
        SignalFactory SF = new SimulatiingSignalFactory();
        public int _CycleNum = -1;
        public SignalGenerator()
        {
            this._CycleNum = 0;
        }
       
        /**
         * for Request Mode                                                                                                                                                                               
         * 
         */
        public Signal StartDiscreteMode(int num)
        {
            return SF.CreateSignal(num);
        }

    }
}
