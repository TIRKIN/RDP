using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI
{
    class DrawingNode
    {
        public string Value { get; set; }

        public Point Location { get; set; }

        public int Identifier { get; set; }

        public List<int> Childeren { get; set; } 
    }
}
