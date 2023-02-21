using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImposibleBruhNoter
{
    internal class CringeConverter
    {
        public static void Serialize<T>(T allNotez)
        {
            string json = JsonConvert.SerializeObject(allNotez);
            File.WriteAllText("C:\\JsonSaves\\Saves.json", json);
        } 
        public static T Deserialize<T>() 
        {
            string text = File.ReadAllText("C:\\JsonSaves\\Saves.json");
            T allNotez = JsonConvert.DeserializeObject<T>(text);
            return allNotez;
        }
    }
}
