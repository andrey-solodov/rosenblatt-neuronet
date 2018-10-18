using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RosenblattNeuroNet.NeuroNetwork
{
    class DefaultNeuroNet
    {
        private int[,] _AdjacencyMatrix;
        public DefaultNeuroNet(int NumOfNeurons, int NumOfLayers = 1, bool DefaultAdjacencyMatrixResolution = true)
        {
            _AdjacencyMatrix = new int[NumOfNeurons,NumOfNeurons];
            for (int i = 0; i < NumOfNeurons; i++)
            {
                for (int j = 0; j < NumOfNeurons; j++)
                {
                    if (i < j) // делаем треугольную матрицу все входы на все нейроны первого и единственного слоя
                    {
                        _AdjacencyMatrix[i, j] = 1;
                    }
                }

            }
        }
    }
}
