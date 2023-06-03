using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworks
{
    class Neuron
     {
        public List<double> Weight { get; }
        public NeuronType Type { get; }
        public double Output { get; private set; }
    }
}
