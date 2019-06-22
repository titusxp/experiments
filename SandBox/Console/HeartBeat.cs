using System;
using System.Globalization;
using System.IO;
using System.Timers;

namespace Console
{
    public class HeartBeat
    {
        private readonly Timer _timer;

        public HeartBeat()
        {
            _timer = new Timer(1000) {AutoReset = true};
            _timer.Elapsed += Timer_Elapsed;
        }

        private string path => "log.txt";

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var lines = new[] {DateTime.Now.ToString(CultureInfo.InvariantCulture)};

            File.AppendAllLines(path, lines);
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}