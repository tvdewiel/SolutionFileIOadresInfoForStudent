using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ReadAdresInfoLib
{
    //opmerking : json settings : always copy !
    public class AdresInfoReader
    {
        private Dictionary<string,SortedSet<Data>> adressen = new Dictionary<string, SortedSet<Data>>();
        private string source;

        public AdresInfoReader()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"adresfile.json", false, true);
            var config = builder.Build();
            source = config["source"];
        }

        public void readData()
        {
            using (StreamReader sr = new StreamReader(source))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] x = line.Trim().Split(',');
                    if (adressen.ContainsKey(x[1]))
                    {
                        adressen[x[1]].Add(new Data(x[0], x[1], x[2]));
                    }
                    else
                    {
                        adressen.Add(x[1], new SortedSet<Data>() { new Data(x[0], x[1], x[2]) });
                    }
                }
            }
        }
        public void printData(string gemeente)
        {
            if (adressen.ContainsKey(gemeente))
            {
                foreach (var x in adressen[gemeente])
                {
                    Console.WriteLine(x);
                }
            }
            else
            {
                Console.WriteLine($"gemeente {gemeente} not found");
            }
        }
    }
}
