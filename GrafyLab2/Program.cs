using System;

namespace GrafyLab2 {
    class Program {
        static void Main(string[] args) {

            Dzban[] dzbans = { new Dzban(14, true), new Dzban(10, false), new Dzban(8, false), new Dzban(3, true) };
            /* v1 xD
            Random rnd = new Random();
            int counter = 0;
            while(dzbans[1].waterNow != 5 && dzbans[2].waterNow != 5) {
                int x = rnd.Next(4);
                int y = rnd.Next(4);
                while (x == y) y = rnd.Next(4);
                dzbans[x].yeet(dzbans[y]);
                counter++;
            }

            
            Console.WriteLine("Udało się w " + counter + " ruchach!");
            */

            //Dozwolone operacje: +3, -3, +8, -8, +10, -10, +14, -14

            
        }
    }
}
