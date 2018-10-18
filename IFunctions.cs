using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace RosenblattNeuroNet.InterfaceFunctions
{
    class IDrawOnCanvas
    {
       
        public static void StartFigure(Point start, ref Canvas cnv, ref PathFigure currentFigure)
        {
           
            SolidColorBrush nBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE3F0E2"));
            currentFigure = new PathFigure() { StartPoint = start };
            var currentPath =
                new Path()
                {
                    Stroke = nBrush, //Brushes.Red,
                    StrokeThickness = 3,
                    Data = new PathGeometry() { Figures = { currentFigure } }
                };
            cnv.Children.Add(currentPath);



        }

        public static void AddFigurePoint(Point point, ref PathFigure currentFigure)
        {
            if (currentFigure!=null)
            currentFigure.Segments.Add(new LineSegment(point, isStroked: true));
        }

        public static void EndFigure(ref PathFigure currentFigure)
        {
            currentFigure = null;
        }

        public static void CanvasClean(ref Canvas cnv)
        {
            cnv.Children.Clear();

        }
    }
}
