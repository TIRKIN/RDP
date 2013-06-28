using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI.Controls
{
    /// <summary>
    /// Interaction logic for VisualNode.xaml
    /// </summary>
    public partial class VisualNode : UserControl
    {
        private int _breadth;
        private int _depth;

        public VisualNode()
        {
            InitializeComponent();
        }

        public String Text
        {
            get { return this.TextBlock.Text; }
            set { this.TextBlock.Text = value; }
        }

        public int Breadth
        {
            get { return _breadth; }
            set { _breadth = value; }
        }

        public int Depth
        {
            get { return _depth; }
            set { _depth = value; }
        }
    }
}
