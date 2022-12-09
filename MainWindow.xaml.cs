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
                
                
                if (y <= canvas_Bewegung.ActualHeight - uwu.ActualHeight - 10 && !Collision.Up(uwu, Wand))
                {
                    y += 10;
                    Canvas.SetBottom(uwu, y);
                }
                
                
                
            }
            else if(e.Key == Key.Down)
            {
                if (y >= 10 && !Collision.Down(uwu, Wand))
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
                if (x <= canvas_Bewegung.ActualWidth - uwu.ActualWidth - 10 && !Collision.Right(uwu,Wand))
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
            // Diese Methode erkennt, ob das Objekt moving mit dem
            //Objekt fest kollidiert, wenn moving sich nach links bewegt.
            // Eckpunkt des bewegten Objekts:
            double x0 = Canvas.GetLeft(moving)-5;
            double y0 = Canvas.GetBottom(moving);
            double x1 = x0 + moving.ActualWidth;
            double y1 = y0 + moving.ActualHeight;

            //Eckpunkt des festen Objekts:
            double xf0 = Canvas.GetLeft(fest);
            double yf0 = Canvas.GetBottom(fest);
            double xf1 = xf0 + fest.ActualWidth;
            double yf1 = yf0 + fest.ActualHeight;

            if(xf0 <= x1 && x0 <= xf1 && yf0 <= y1 && y0 <= yf1)
            {
                return true;
            }
            else {return false;}

            // Wenn beide Figuren kollidieren (aufeinander treffen)
            // wird true zurückgegeben, sonst false.
            
        }


        public static bool Right(Shape moving, Shape fest)
        {
            // Diese Methode erkennt, ob das Objekt moving mit dem
            //Objekt fest kollidiert, wenn moving sich nach links bewegt.
            // Eckpunkt des bewegten Objekts:
            double x0 = Canvas.GetLeft(moving) + 5;
            double y0 = Canvas.GetBottom(moving);
            double x1 = x0 + moving.ActualWidth;
            double y1 = y0 + moving.ActualHeight;

            //Eckpunkt des festen Objekts:
            double xf0 = Canvas.GetLeft(fest);
            double yf0 = Canvas.GetBottom(fest);
            double xf1 = xf0 + fest.ActualWidth;
            double yf1 = yf0 + fest.ActualHeight;

            if (xf0 <= x1 && x0 <= xf1 && yf0 <= y1 && y0 <= yf1)
            {
                return true;
            }
            else { return false; }

            // Wenn beide Figuren kollidieren (aufeinander treffen)
            // wird true zurückgegeben, sonst false.

        }

        public static bool Up(Shape moving, Shape fest)
        {
            // Diese Methode erkennt, ob das Objekt moving mit dem
            //Objekt fest kollidiert, wenn moving sich nach links bewegt.
            // Eckpunkt des bewegten Objekts:
            double x0 = Canvas.GetLeft(moving);
            double y0 = Canvas.GetBottom(moving) + 5;
            double x1 = x0 + moving.ActualWidth;
            double y1 = y0 + moving.ActualHeight;

            //Eckpunkt des festen Objekts:
            double xf0 = Canvas.GetLeft(fest);
            double yf0 = Canvas.GetBottom(fest);
            double xf1 = xf0 + fest.ActualWidth;
            double yf1 = yf0 + fest.ActualHeight;

            if (xf0 <= x1 && x0 <= xf1 && yf0 <= y1 && y0 <= yf1)
            {
                return true;
            }
            else { return false; }

            // Wenn beide Figuren kollidieren (aufeinander treffen)
            // wird true zurückgegeben, sonst false.

        }

        public static bool Down(Shape moving, Shape fest)
        {
            // Diese Methode erkennt, ob das Objekt moving mit dem
            //Objekt fest kollidiert, wenn moving sich nach links bewegt.
            // Eckpunkt des bewegten Objekts:
            double x0 = Canvas.GetLeft(moving);
            double y0 = Canvas.GetBottom(moving) - 5;
            double x1 = x0 + moving.ActualWidth;
            double y1 = y0 + moving.ActualHeight;

            //Eckpunkt des festen Objekts:
            double xf0 = Canvas.GetLeft(fest);
            double yf0 = Canvas.GetBottom(fest);
            double xf1 = xf0 + fest.ActualWidth;
            double yf1 = yf0 + fest.ActualHeight;

            if (xf0 <= x1 && x0 <= xf1 && yf0 <= y1 && y0 <= yf1)
            {
                return true;
            }
            else { return false; }

            // Wenn beide Figuren kollidieren (aufeinander treffen)
            // wird true zurückgegeben, sonst false.

        }
    }
}
