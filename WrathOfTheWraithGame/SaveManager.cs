using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Diagnostics;

namespace WrathOfTheWraithGame
{
    public static class SaveManager
    {
        public static void Save(Stats playerStats)
        {
            string serialized = JsonSerializer.Serialize<Stats>(playerStats);  
            File.ReadAllText(serialized);
            Trace.WriteLine("{0} : \n", serialized);

           /* foreach(var item in playerStats)
            {

            }*/
        }


        public static void Load()
        {

        }

        public static void Delete()
        {

        }
    }
}
