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

namespace PaintApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private enum Shapes
        {
            Line, Ellipse, Rectangle
        }

        private Shapes currentShape = Shapes.Line;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LineBTN_Click(object sender, RoutedEventArgs e)
        {
            currentShape = Shapes.Line;
        }

        private void EllipseBTN_Click(object sender, RoutedEventArgs e)
        {
            currentShape = Shapes.Ellipse;
        }

        private void SquareBTN_Click(object sender, RoutedEventArgs e)
        {
            currentShape = Shapes.Rectangle;
        }

        //współrzędne początek i koniec
        Point start;
        Point end;

        private void canvasMy_MouseDown(object sender, MouseButtonEventArgs e)
        {
            start = e.GetPosition(this);
        }

        private void canvasMy_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                end = e.GetPosition(this);
            }
        }

        private void canvasMy_MouseUp(object sender, MouseButtonEventArgs e)
        {
            switch (currentShape)
            {
                case Shapes.Line:
                    DrawLine();
                    break;
                case Shapes.Ellipse:
                    DrawEllipse();
                    break;
                case Shapes.Rectangle:
                    DrawSquare();
                    break;
                default:
                    return;
            }
        }

        private void DrawLine()
        {
            Line line = new Line() {
                Stroke = Brushes.Red,
                X1=start.X,
                Y1=start.Y-50,
                X2=end.X,
                Y2=end.Y-50,
                StrokeThickness=7
            };
            canvasMy.Children.Add(line);
        }

        private void DrawEllipse() {
            Ellipse nEli = new Ellipse() {
                Stroke = Brushes.Crimson,
                Fill = Brushes.DeepSkyBlue,
                StrokeThickness = 4,
                Height=25,
                Width=25
            };
            //od lewej do prawej
            if (start.X <= end.X)
            {
                nEli.SetValue(Canvas.LeftProperty, start.X);
                nEli.Width = end.X - start.X;
            }
            //od prawej do lewej
            else
            {
                nEli.SetValue(Canvas.LeftProperty, end.X);
                nEli.Width = start.X - end.X;
            }
            //od góry do dołu
            if (start.Y <= end.Y)
            {
                nEli.SetValue(Canvas.TopProperty, start.Y-50);
                nEli.Height = end.Y - start.Y;
            }
            //od dołu do góry
            else
            {
                nEli.SetValue(Canvas.TopProperty, end.Y-50);
                nEli.Height = start.Y - end.Y;
            }

            canvasMy.Children.Add(nEli);
        }

        private void DrawSquare()
        {
            Rectangle square = new Rectangle()
            {
                Stroke = Brushes.DeepSkyBlue,
                Fill = Brushes.Crimson,
                StrokeThickness = 4,
                Height = 20,
                Width = 20
            };

            if (start.X <= end.X)
            {
                square.SetValue(Canvas.LeftProperty, start.X);
                square.Width = end.X - start.X;
            }
            else
            {
                square.SetValue(Canvas.LeftProperty, end.X);
                square.Width = start.X - end.X;
            }

            if (start.Y <= end.Y)
            {
                square.SetValue(Canvas.TopProperty, start.Y - 50);
                square.Height = end.Y - start.Y;
            }
            else
            {
                square.SetValue(Canvas.TopProperty, end.Y - 50);
                square.Height = start.Y - end.Y;
            }

            canvasMy.Children.Add(square);
        }

        
    }
}
