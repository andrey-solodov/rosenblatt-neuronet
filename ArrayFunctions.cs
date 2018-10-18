using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RosenblattNeuroNet.Arrays
{
    static class ArrayFunctions
    {
        /// <summary>
        /// изменяет размерность массива
        /// </summary>
        /// <param name="arr">исходный массив</param>
        /// <param name="delta">насколько увеличить</param>
        public static void IncreaseLengthArray(ref System.Drawing.Color[] arr, int delta)
        {
            System.Drawing.Color[] tmp = new System.Drawing.Color[arr.Length + delta];
            Array.Copy(arr, 0, tmp, 0, arr.Length);
            arr = tmp;
        }

        public static void SortArray(ref List<string> arr)
        {
            string tmp_element ="";
            string min_element ="";

            long value1,value2 = 0;
            int index_of_min_element = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                min_element = arr[i];
                index_of_min_element = i;

                for (int j = i; j < arr.Count; j++)
                {
                    value1 = long.Parse(min_element, System.Globalization.NumberStyles.HexNumber);
                    value2 = long.Parse(arr[j], System.Globalization.NumberStyles.HexNumber);
                    if (value1 > value2)
                    {
                        min_element = arr[j];
                        index_of_min_element = j;
                    }
                }

                tmp_element = arr[i];
                arr[i] = arr[index_of_min_element];
                arr[index_of_min_element] = tmp_element;

            }
        }
    }
}
