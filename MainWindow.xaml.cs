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

namespace Bewegung_mit_den_Pfeiltasten
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            x = Canvas.GetLeft(uwu);
            y = Canvas.GetBottom(uwu);
            x1 = Canvas.GetLeft(Wand);
            y1 = Canvas.GetBottom(Wand);
        }
        private double x = 10;
        private double y = 10;
        private double x1;
        private double y1;

        private void Canvas_Bewegung_KeyDown(object sender, KeyEventArgs e)
        {
            //switch (e.Key)
            //{
            //    case Key.Up:
            //        break;
            //}
            //int rest = MainWindow.ActualWidthProperty % 10;
            //MainWindow.ActualWidthProperty = MainWindow.ActualWidthProperty - rest;

            if (e.Key == Key.Up)
            {
                //dieser Code wird ausgeführt, wenn Pfeiltaste hoch gedrückt wird
                
                
                if (y <= canvas_Bewegung.ActualHeight - uwu.ActualHeight - 10 && !Collision.Left(uwu, Wand))
                {
                    y += 10;
                    Canvas.SetBottom(uwu, y);
                }
                
                
                
            }
            else if(e.Key == Key.Down)
            {
                if (y >= 10 && !Collision.Left(uwu, Wand))
                {
                    y -= 10;
                    Canvas.SetBottom(uwu, y);
                }
                
            }
            else if (e.Key == Key.Left)
            {
                if (x >= 10 && !Collision.Left(uwu, Wand))
                {
                    x -= 10;
                    Canvas.SetLeft(uwu, x);
                }
                
            }
            else if (e.Key== Key.Right)
            {
                if (x <= canvas_Bewegung.ActualWidth - uwu.ActualWidth - 10 && !Collision.Left(uwu,Wand))
                {
                    x += 10;
                    Canvas.SetLeft(uwu, x);
                }
                
            }
            else if (e.Key == Key.Back)
            {
                x = 10;
                y = 10;
                Canvas.SetLeft(uwu, x);
                Canvas.SetBottom(uwu, y);
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

    }
    class Collision
    {
        public static bool Left(Shape moving, Shape fest)
        {
            // Diese Methode erkennt, ob das Objekt moving
            // von der linken Seite mit fest kollidiert.
            // Eckpunkt des bewegten Objekts:
            double x = Canvas.GetLeft(moving)+5;
            double y = Canvas.GetBottom(moving);
            double xw = x + moving.ActualWidth;
            double yh = y + moving.ActualHeight;

            //Eckpunkt des festen Objekts:
            double xfest = Canvas.GetLeft(fest);
            double yfest = Canvas.GetBottom(fest);
            double xwfest = xfest + fest.ActualWidth;
            double yhfest = yfest + fest.ActualHeight;

            if(xw > xfest && yh > yfest && y < yhfest && x < xwfest)
            {
                return true;
            }
            else {return false;}

            // Wenn beide Figuren kollidieren (aufeinander treffen)
            // wird true zurückgegeben, sonst false.
            
        }
    }
}
