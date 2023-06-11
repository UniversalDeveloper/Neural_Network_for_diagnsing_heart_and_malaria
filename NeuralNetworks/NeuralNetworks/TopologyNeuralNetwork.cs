using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworks
{
  public  class TopologyNeuralNetwork
    {
        public int InputCount { get; }
        public int OutputCount { get; }
        public List<int> HiddenLayers { get; }
        public TopologyNeuralNetwork(int inputCount,int outputCount, params int[]layers) 
        {
            InputCount = inputCount;
            OutputCount = outputCount;
            HiddenLayers = new List<int>();
            HiddenLayers.AddRange(layers);
        
        
        
        }
    }
}
