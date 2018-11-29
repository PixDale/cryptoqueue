using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaM1Lista
{
    class Node
    {
        private String info;
        private Node next;
        private Node back;

        public String Info
        {
            get { return info; }
            set { info = value; }
        }

        public Node Next
        {
            get { return next; }
            set { next = value; }
        }

        public Node Back
        {
            get { return back; }
            set { back = value; }
        }

    }
}
