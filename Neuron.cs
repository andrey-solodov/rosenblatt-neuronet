using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RosenblattNeuroNet.NeuroNetwork
{
    class Neuron
    {

        private const double THRESHOLD_STANDARD_VALUE = 0.5;

        private int _ID; //массив входных значений
        public int ID
        {
            get { return _ID; }
        }

        private double[] _XInput; //массив входных значений
        public double[] XInput
        {
            get { return _XInput; }
            set { this._XInput = XInput; }
        }

        private double[] _WeightInput; //массив весовых коэффициентов
        public double[] WeightInput
        {
            get { return _WeightInput; }
            set { this._WeightInput = WeightInput; }
        }

        private double _YInput; // выходной сигнал
        public double YInput
        {
            get { return _YInput >= 0 ? _YInput : 0; }
        }

        private double _Threshold; // порог активации
        public double Threshold
        {
            get { return _Threshold >= 0 ? _Threshold : 0; }
        }

        public Neuron(int NeuronID) // значения по умолчанию: один вход+стандартный порог
        {
            _ID = NeuronID;
            _Threshold = THRESHOLD_STANDARD_VALUE;
            _XInput = new double[1]; _XInput[0] = 1;
            _WeightInput = new double[1]; _WeightInput[0] = 1;
        }

       
        public Neuron(int NeuronID, double[] NewXinputs, double[] NewWeights, double NewThreshold= THRESHOLD_STANDARD_VALUE)
        {
            _ID = NeuronID;
            _Threshold = NewThreshold;
            _XInput = NewXinputs;
            _WeightInput = NewWeights;
        }

        public void Activate()
        {
            double WSum = 0; // взвешенная сумма
            if (_XInput.Length > 0)
            {
                for (int i = 0; i < _XInput.Length; i++)
                {
                    WSum += _XInput[i] * _WeightInput[i];
                }
                _YInput = WSum - _Threshold;
            }
            else
            { _YInput = 0; }
            
        }
    }


}
