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
using GUI.Controls;
using SemanticAnalyzer.SyntaxTree;
using SemanticAnalyzer.SyntaxTree.Node;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ASTNode tree;

        public MainWindow()
        {
            InitializeComponent();
            GenTestTree();
            DrawSomething();
        }

        public void DrawSomething()
        {

        }

        private void GenerateDrawingTree()
        {
             
        }

        public void GenTestTree()
        {
            Operator root = new Operator("x");
            root.LeftChild = new Number("4");
            root.RightChild = new Number("1");

            tree = root;
        }

        public IEnumerable<ASTNode> PreOrderTraversal(ASTNode node)
        {
            Stack<ASTNode> parent = new Stack<ASTNode>();
    
            while (parent.Count != 0 || node != null)
            {
                if (node != null)
                {
                    yield return node;
                    parent.Push(node.RightChild);
                    node = node.LeftChild;
                }
                else
                {
                    node = parent.Pop();
                }
            }
        }

        private DrawingNode GenDrawingTree(ASTNode node)
        {
               
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();

            VisualNode node = new VisualNode();
            node.Text = "*";
            Canvas.SetLeft(node, this.canvas.ActualWidth / 2);

            VisualNode node2 = new VisualNode();
            node2.Text = "3";
            Canvas.SetLeft(node2, (this.canvas.ActualWidth / 2) - 50);
            Canvas.SetTop(node2, 75);

            VisualNode node3 = new VisualNode();
            node3.Text = "4";
            Canvas.SetLeft(node3, (this.canvas.ActualWidth / 2) + 50);
            Canvas.SetTop(node3, 75);

            canvas.Children.Add(node);
            canvas.Children.Add(node2);
            canvas.Children.Add(node3);
        }
    }
}
