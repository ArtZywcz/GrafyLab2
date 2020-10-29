using System;
using System.Collections.Generic;
using System.Text;

namespace GrafyLab2 {
    class Dzban {

        public int maxCap;
        public int waterNow;


        public void yeet(Dzban next) {

            while(!(this.waterNow == 0 || next.maxCap == next.waterNow)) {
                this.waterNow--;
                next.waterNow++;
            }
        }

        public Dzban(int max, bool isFull) {
            maxCap = max;
            if (isFull) waterNow = maxCap;
            else waterNow = 0;
        }
    }
}
