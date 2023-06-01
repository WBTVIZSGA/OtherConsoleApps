using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ultrabalaton
{
    /*Versenyzo;Rajtszam;Kategoria;Versenyido;TavSzazalek
    Acsadi Lajos;1;Ferfi;30:28:42;100*/

    public class Competitor
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Category { get; set; }
        public string Time { get; set; }
        public int TimeInSeconds { get; set; }
        public int Percent { get; set; }

        public Competitor(string row)
        {
            var splittedData = row.Split(';');
            Name = splittedData[0]; 
            Number = splittedData[1];
            Category = splittedData[2];
            Time = splittedData[3];
            Percent = int.Parse(splittedData[4]);

            var splittedTime = splittedData[3].Split(':');
            TimeInSeconds = int.Parse(splittedTime[0]) * 3600 +
                            int.Parse(splittedTime[1]) * 60 +
                            int.Parse(splittedTime[2]);
        }

        public double IdőÓrában => TimeInSeconds / 3600.0;
    }
}
