﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GUI.Controls;
using GUI.Viewmodel;
using Microsoft.Win32;
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

            this.DataContext = new MainViewmodel();
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
            return null;
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

            // Draw a line between the nodes
            Point centerNode1 = new Point(this.canvas.ActualWidth / 2, node.Height / 2);
            Point centerNode2 = new Point((this.canvas.ActualWidth / 2) - 50, 75);


            VisualNode node3 = new VisualNode();
            node3.Text = "4";
            Canvas.SetLeft(node3, (this.canvas.ActualWidth / 2) + 50);
            Canvas.SetTop(node3, 75);

            canvas.Children.Add(node);
            canvas.Children.Add(node2);
            canvas.Children.Add(node3);
            Line lijn = new Line();
            lijn.X1 = this.canvas.ActualWidth/2 + 25;
            lijn.X2 = (this.canvas.ActualWidth/2) - 25;
            lijn.Y1 = 25;
            lijn.Y2 = 100;

            lijn.Stroke = Brushes.Black;
            
            Canvas.SetZIndex(lijn, -1000);
            canvas.Children.Add(lijn);
        }

        private void btnLoadImage_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.ShowDialog();
            
            BitmapImage image = new BitmapImage(new Uri(dialog.FileName));

            ((MainViewmodel) this.DataContext).Image = image;
        }
    }
}
