using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalSimulatorWeb.Models
{
    public class Request
    {
        public string Tail { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        
    }

    public class SearchRequest
    {
        public string Tail { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

    }

    public class EditRequest
    {
        public string Tail { get; set; }
        public int info { get; set; }

    }

    public class Message
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Time { get; set; }
    }

    /**
 *The model class 
 * Author：Guhao Huang
 * 5.6.2018
 */
    public interface Signal
    {
        String GetString();
        int GetNum();
        string GetPressure();
        string GetTemp();
        string GetFlow();
        string GetDate();
        DateTime GetDateInstance();
        int GetNumInstance();
        float GetPressureInstance();
        int GetTempInstance();
        float GetFlowInstance();
    }

    /**
     *Signal type of the simulator 
     *
     */
    public class SimulatedSignal : Signal
    {
        public int _Num; //it shall be >=0
        public float _MudPressure; //from 45 to 55
        public int _Temp; //from 50 to 150
        public float _FlowRate; // 50 - 150
        public DateTime _Time;

        /**
         *Signal generating
         *from editing
         */
        public SimulatedSignal(int num, float press, int temp, float flow, DateTime date)
        {
            this._Num = num;
            this._MudPressure = press;
            this._Temp = temp;
            this._FlowRate = flow;
            this._Time = date;
        }

        /**
         *Get Number
         */
        public void SetCycleNum(int num)
        {
            this._Num = num;
        }

        //for test
        public string GetString()
        {
            string output = this._Num + "        " + _Time + "        Temp: " + _Temp + "        FlowRate: " + _FlowRate + "        Pressure: " + _MudPressure + "\n";
            return output;
        }

        //access the attributions
        public int GetNum()
        {
            return this._Num;
        }

        public string GetPressure()
        {
            return this._MudPressure.ToString();
        }

        public string GetTemp()
        {
            return this._Temp.ToString();
        }

        public string GetFlow()
        {
            return this._FlowRate.ToString();
        }

        public string GetDate()
        {
            return this._Time.ToString();
        }

        public DateTime GetDateInstance()
        {
            return this._Time;
        }

        public int GetNumInstance()
        {
            return this._Num;
        }

        public float GetPressureInstance()
        {
            return this._MudPressure;
        }

        public int GetTempInstance()
        {
            return this._Temp;
        }

        public float GetFlowInstance()
        {
            return this._FlowRate;
        }
    }
}