using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace footgolf
{
    public class Competitor
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Team { get; set; }
        public int[] Points { get; set; }

        public Competitor(string row)
        {
            //Albert Laszlo;Felnott ferfi;HOLE HUNTERS;0;0;10;10;0;0;0;10
            var splittedData = row.Split(';');
            Name = splittedData[0];
            Category = splittedData[1];
            Team = splittedData[2];
            Points = new int[8];
            for (int i = 0; i < 8; i++)
                Points[i] = int.Parse(splittedData[i + 3]);
        }

        public int SumOfPoints
        {
            get
            {
                var orderedPoints = Points.OrderBy(p => p).ToList();
                return orderedPoints.Skip(2).Sum()
                       + (orderedPoints[0] == 0 ? 0 : 10)
                       + (orderedPoints[1] == 0 ? 0 : 10);
            }
        }
    }
}
