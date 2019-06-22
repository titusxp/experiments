using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Topshelf;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x => 
            {
                x.Service<HeartBeat>(s =>
                {
                    s.ConstructUsing(heartbeat => new HeartBeat());
                    s.WhenStarted(h => h.Start());
                    s.WhenStopped(h => h.Stop());
                });
                x.RunAsLocalSystem();
                x.SetServiceName("HeartbeatService");
                x.SetDisplayName("Heartbeat Service");
                x.SetDescription("This is the sample heatbeat service used in a youtube demo");
                //x.StartAutomaticallyDelayed();
            });

            var exitCodeValue = (int) Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
            
        }
    }
}
