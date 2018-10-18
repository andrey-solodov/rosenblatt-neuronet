using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace RosenblattNeuroNet.Image
{
    class ImageSurfaceForProcession3 : System.ICloneable //для того, чтобы клонировать объект и выполнять с ним все манипуляции, не затрагивая реальный объект
    {
        public System.Windows.Media.Transform _LayoutTransform;
        public double _ActualWidth;
        public double _ActualHeight;
        public UIElementCollection _UIChildren;

        public object Clone()
        {
            return new ImageSurfaceForProcession3
            {
                _LayoutTransform = this._LayoutTransform,
                _ActualWidth = this._ActualWidth,
                _ActualHeight = this._ActualHeight,
                _UIChildren = this._UIChildren
            };
        }
    }
}


/* использование 
 * 
 * class Program
{
    static void Main(string[] args)
    {
        ImageSurfaceForProcession p1 = new ImageSurfaceForProcession { CanvasSource=some_canvas };
        ImageSurfaceForProcession p2 = (ImageSurfaceForProcession)p1.Clone();
        p2.CanvasSource = ....;
        ....
    }
}
 
     */
