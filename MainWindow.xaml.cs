using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using RosenblattNeuroNet.Image;
using RosenblattNeuroNet.InterfaceFunctions;

namespace RosenblattNeuroNet
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isDrawing = false;
        PathFigure currentFigure;

        public MainWindow()
        {
            InitializeComponent();
            CanvasUserDrawing.ClipToBounds = true;
        }

        private void CanvasUserDrawing_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(CanvasUserDrawing);
            isDrawing = true;
            IDrawOnCanvas.StartFigure(e.GetPosition(CanvasUserDrawing), ref CanvasUserDrawing, ref currentFigure);
        }

        private void CanvasUserDrawing_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            IDrawOnCanvas.AddFigurePoint(e.GetPosition(CanvasUserDrawing), ref currentFigure);
            IDrawOnCanvas.EndFigure(ref currentFigure);
            isDrawing = false;
            Mouse.Capture(null);
        }

        private void CanvasUserDrawing_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing)
                return;
            IDrawOnCanvas.AddFigurePoint(e.GetPosition(CanvasUserDrawing), ref currentFigure);
        }

        private void BtCleanUpCnv_Click(object sender, RoutedEventArgs e)
        {
            IDrawOnCanvas.CanvasClean(ref CanvasUserDrawing);
        }

       
        private void BtRecognize_Click(object sender, RoutedEventArgs e)
        {
            ImageRecognition.RunRecognition(this.CanvasUserDrawing);
        }
    }
}
