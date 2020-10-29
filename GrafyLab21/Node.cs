using System;
using System.Collections.Generic;
using System.Text;

namespace GrafyLab21 {
    class Node {

        public int id;
        public List<int> canGetToFrom;

        public Node(int id, List<int> canGetToFrom) {
            this.id = id;
            this.canGetToFrom = canGetToFrom;
        }
    }
}
