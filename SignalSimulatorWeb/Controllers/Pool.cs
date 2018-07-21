using SignalSimulatorWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalSimulatorWeb.Controllers
{
    public class Pool
    {
        public static List<Message> pool = new List<Message>(100);
    }
}