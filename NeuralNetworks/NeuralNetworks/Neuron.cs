﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworks
{
    class Neuron
     {
        public List<double> Weights { get; }
        public NeuronType NeuronType { get; }
        public double Output { get; private set; }
        public Neuron(int inputCount,NeuronType type)
        {
            NeuronType = type;
            Weights = new List<double>();
            for (int i = 0; i < inputCount; i++)
            {
                Weights.Add(1);

            }        
        }
        public double FeedForward(List<double>inputsSignals) /// we need to create cheak of matching input signals and weights
        {
            var sum = 0.0;
            for (int i = 0; i < inputsSignals.Count; i++)
            {
                sum += inputsSignals[i] * Weights[i];
            }
            Output = Sigmoid(sum);
            return Output;
        }
        private double Sigmoid(double x) 
        { var result = 1.0 / (1.0 + Math.Pow(Math.E, -x));
            return result;       
        
        }
    }
}