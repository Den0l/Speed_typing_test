using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Speed_typing_test
{
    internal class Records
    {
        static public List<Player> ReadJson(string json, List<Player> player)
        {
            player = JsonConvert.DeserializeObject<List<Player>>(json);
            return player;
        }
        static public void SaveJson(List<Player> player)
        {
            string json = JsonConvert.SerializeObject(player);
            File.WriteAllText(@"C:\Users\denol\Desktop\Record.json", json);
        }

    }
}
