using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;


namespace RosenblattNeuroNet.Image
{
    static class ImageRecognition
    {
        public static void RunRecognition(Canvas ImageSource)
        {
            // создаем картинку из canvas во временный  локальный файл tmp_bitmap.bmp
            CreateImage(ImageSource);
            //преобразуем картинку в матрицу пикселей
            // работает System.Drawing.Color[,] color = GetPixelsMatrixFromBMP("tmp_bitmap.bmp");

            //применяем серый фильтр
            ImageProcessor IP = new ImageProcessor();
            IP.ImageGreyFilter("tmp_bitmap.bmp");
        }

        private static void CreateImage(Canvas ImageSource)
        {
            ImageProcessor IP = new ImageProcessor();
            IP.ImageSourceForProcession = ImageSource;
            IP.CanvasToBitMap(ImageSource, "tmp_bitmap.bmp");
        }

        private static System.Drawing.Color[,] GetPixelsMatrixFromBMP(string FileName)
        {
            Bitmap bmp = new Bitmap(FileName);
            System.Drawing.Color[,] color = new System.Drawing.Color[bmp.Width, bmp.Height];

            for (int y = 0; y < bmp.Height; y++)
                for (int x = 0; x < bmp.Width; x++)
                {
                    color[x, y] = bmp.GetPixel(x, y);
                }

            return color;
        }                           
    }
}
