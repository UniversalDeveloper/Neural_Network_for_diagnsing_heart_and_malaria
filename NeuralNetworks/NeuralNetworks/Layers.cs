using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworks
{
  public  class Layers
    {        public List<Neuron> Neurons { get; }
        public int Count => Neurons?.Count ?? 0;

        public Layers(List<Neuron> neurons, NeuronType type = NeuronType.Normal) =>
            // TODO: cheack input data correct
            Neurons = neurons;

    }
}
