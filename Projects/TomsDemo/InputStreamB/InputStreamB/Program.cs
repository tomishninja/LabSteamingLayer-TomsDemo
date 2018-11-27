using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LSL;

namespace InputStreamB
{
    class Program
    {
        static void Main(string[] args)
        {
            // create stream info and outlet
            liblsl.StreamInfo inf = new liblsl.StreamInfo("Test1", "Markers", 1, 0, liblsl.channel_format_t.cf_string, "bgiu4569");
            liblsl.StreamOutlet outl = new liblsl.StreamOutlet(inf);

            Random rnd = new Random();
            string[] strings = new string[] { "Test", "ABC", "123" };
            string[] sample = new string[1];
            for (int k = 0; ; k++)
            {
                // send a marker and wait for a random interval
                sample[0] = "B" + strings[k % 3];
                outl.push_sample(sample);
                System.Threading.Thread.Sleep(rnd.Next(1000));
            }
        }
    }
}
