using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kektura
{
    public class Trail
    {
        public string StartPlace { get; set; }
        public string FinishPlace { get; set; }
        public double Distance { get; set; }
        public int Increase { get; set; }
        public int Decrease { get; set; }
        public bool isStamp { get; set; }

        public int FinishHeight { get; set; }

        public Trail(string row, int startHeight)
        {
            //Sumeg, vasutallomas;Sumeg, buszpalyaudvar;1,208;16;6;n
            var splittedData = row.Split(';');
            StartPlace = splittedData[0];
            FinishPlace = splittedData[1];
            Distance = double.Parse(splittedData[2]);
            Increase = int.Parse(splittedData[3]);
            Decrease = int.Parse(splittedData[4]);
            isStamp = splittedData[5] == "i";

            FinishHeight = startHeight + Increase - Decrease;
        }

        public bool HianyosNev => isStamp && !FinishPlace.Contains("pecsetelohely");

    }
}
