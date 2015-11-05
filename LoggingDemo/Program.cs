using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.GetData("APP_CONFIG_FILE").ToString()));
            GlobalContext.Properties["Hostname"] = Environment.MachineName;
            var log = LogManager.GetLogger(typeof(Program));

            string key = null;
            while (key != "x")
            {
                log.Info("Starting");
                for (int x = 0; x < 10; x++)
                {
                    log.Error("Some error: " + x);
                }
                log.Debug("Ended");
                Console.ReadLine();
            }
        }
    }
}
