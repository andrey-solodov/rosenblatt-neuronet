using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RosenblattNeuroNet.Image
{
    class ImageProcessor
    {
        private Canvas _ImageSourceForProcession;
        public Canvas ImageSourceForProcession
        {
            set { this._ImageSourceForProcession = value; }
        }

        public void CanvasToBitMap(FrameworkElement visual, string fileName) //сохраняет в локальную папку /*убрал мараметр Uri path*/
        {
            var bitmapEncoder = new BmpBitmapEncoder();
            SaveUsingEncoder(visual, fileName, bitmapEncoder);
        }

        public void ImageGreyFilter(string fname)
        {
            List<System.Drawing.Color> PixelsAray=new List<System.Drawing.Color>(); 
          

            Bitmap input = new Bitmap(@fname,true);
            // создаём Bitmap для черно-белого изображения
            Bitmap output = new Bitmap(input.Width, input.Height);
            // перебираем в циклах все пиксели исходного изображения
            for (int j = 0; j < input.Height; j++)
                for (int i = 0; i < input.Width; i++)
                {
                    // получаем (i, j) пиксель
                    UInt32 pixel = (UInt32)(input.GetPixel(i, j).ToArgb());
                    // получаем компоненты цветов пикселя
                    float R = (float)((pixel & 0x00FF0000) >> 16); // красный
                    float G = (float)((pixel & 0x0000FF00) >> 10); // зеленый
                    float B = (float)(pixel & 0x000000FF); // синий
                                                           // делаем цвет черно-белым (оттенки серого) - находим среднее арифметическое
                    R = G = B = (R + G + B) / 3.0f;
                    // собираем новый пиксель по частям (по каналам)
                    UInt32 newPixel = 0xFF000000 | ((UInt32)R << 16) | ((UInt32)G << 8) | ((UInt32)B);
                    // добавляем его в Bitmap нового изображения
                    output.SetPixel(i, j, System.Drawing.Color.FromArgb((int)newPixel));


                    PixelsAray.Add(System.Drawing.Color.FromArgb((int)newPixel));


                }

            SaveFromBitmapToFile(output, fname);
            var tmp = PixelsClassificationList(PixelsAray);

            /*string result = string.Empty;
            int Rinput = 1564546;
            result = Rinput.ToString("X");
            MessageBox.Show(result);*/


            //вызываем тестовую функцию по сортировке пикселей
            Arrays.ArrayFunctions.SortArray(ref tmp);
            string str_msg = "";
            for (int i = 0; i < tmp.Count; i++)
            {
                str_msg = str_msg + tmp[i]+"; ";
            }
            MessageBox.Show(str_msg);
        }
        private static void SaveUsingEncoder(FrameworkElement visual, string fileName, BitmapEncoder encoder)
        {

            // Save current canvas transform
            Transform transform = visual.LayoutTransform;
            visual.LayoutTransform = null;

            // fix margin offset as well
            Thickness margin = visual.Margin;
            visual.Margin = new Thickness(0, 0, margin.Right - margin.Left, margin.Bottom - margin.Top);
            System.Windows.Size size = new System.Windows.Size(visual.ActualWidth, visual.ActualHeight);

            // force control to Update
            visual.Measure(size);
            visual.Arrange(new Rect(size));


            RenderTargetBitmap rtb = new RenderTargetBitmap((int)size.Width, (int)size.Height, 90, 90, PixelFormats.Pbgra32); //System.Windows.Media.PixelFormats.Default
            rtb.Render(visual);

            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(rtb));

            // return values as they were before
            visual.LayoutTransform = transform;
            visual.Margin = margin;

            using (var fs = System.IO.File.OpenWrite(fileName))
            {
                pngEncoder.Save(fs);
            }
        }

        private static void SaveFromBitmapToFile(Bitmap bmp, string filedistination)
        {

            if (File.Exists(@filedistination))
            {
                try
                {
                    using (FileStream fs = new FileStream(@filedistination, FileMode.Open, FileAccess.Write))
                    {
                        fs.Dispose();
                        bmp.Save(filedistination);

                    }
                }
                catch (Exception)
                {
                    bmp.Save(Path.GetFileNameWithoutExtension(filedistination) + "_grey_filter.bmp");
                }
            }
            else
            {
                bmp.Save(filedistination);
            }




        }


        private static List<string> PixelsClassificationList(List<System.Drawing.Color> pixels_to_unique_list)
        {

            List<string> UniqPixels = new List<string>();
            bool isdublicated = false;

            UniqPixels.Add(pixels_to_unique_list[0].Name);
                        

            for (int i = 1; i < pixels_to_unique_list.Count; i++)
            {
                foreach (string item in UniqPixels)
                {
                    if (item== pixels_to_unique_list[i].Name)
                    {
                        isdublicated = true;
                    }
                }

                if (!isdublicated)
                {
                    UniqPixels.Add(pixels_to_unique_list[i].Name);
                }
                else
                {
                    isdublicated = false;
                }
            }


            //System.Drawing.Color[] p_ord = new System.Drawing.Color[1];



            return UniqPixels;
        }
}
}
