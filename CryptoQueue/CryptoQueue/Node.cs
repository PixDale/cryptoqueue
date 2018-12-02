using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoQueue
{
    class Node
    {
        private Char info;
        private Node next;
        private Node back;

        public Char Info
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
