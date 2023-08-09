using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuralNetworks
{
    public class NeuralNetwork
    {   public TopologyNeuralNetwork Topology{get;}
        public List<Layers> Layers { get; }

        public NeuralNetwork(TopologyNeuralNetwork topology)
        {
            Topology = topology;
            Layers = new List<Layers>();

           CreateInputLayer();
           CreateHiddenLayers();
            CreatedOutputLayers();

        }

        private void SendSignalsToInputNeurons(List<double> inputSignals)
        {
            // TODO: cheack input signals mast be equal input neurons of network  
            for (int i = 0; i < inputSignals.Count; i++)
            {
                var signal = new List<double> { inputSignals[i] };
                var neuron = Layers[0].Neurons[i];
            }


        }
        public Neuron FeedForward(List<double> inputSignals)
        {
            SendSignalsToInputNeurons(inputSignals);
            FeedForwardsAllLayersAfterInput();
            if (Topology.OutputCount==1)
            {
                return Layers.Last().Neurons[0];
            }
            else
            {
                return Layers.Last().Neurons.OrderByDescending(n => n.Output).First();
            }

        }
        private void FeedForwardsAllLayersAfterInput() {
            for (int i = 1; i < Layers.Count; i++)
            {
                var layer = Layers[i];
                var priviousLayerCountSignals = Layers[i - 1].GetOutputSignals();
                foreach (var neuron in layer.Neurons)
                {
                    neuron.FeedForward(priviousLayerCountSignals);
                }
            }
        }
        private void CreateHiddenLayers()
        {
            for (int j = 0; j < Topology.HiddenLayers.Count; j++)
            {
                var hiddenNeurons = new List<Neuron>();
                var lastLayer = Layers.Last();
                for (int i = 0; i < Topology.HiddenLayers[j]; i++)
                {
                    var neuron = new Neuron(lastLayer.Count);
                    hiddenNeurons.Add(neuron);
                }
                var hiddenLayer = new Layers(hiddenNeurons);
                Layers.Add(hiddenLayer);
            }
        }

        private void CreatedOutputLayers()
        {
            var outputNeurons = new List<Neuron>();
            var lastLayer = Layers.Last();
            for (int i = 0; i < Topology.OutputCount; i++)
            {
                var neuron = new Neuron(lastLayer.Count, NeuronType.Output);
                outputNeurons.Add(neuron);
            }
            var outputLayer = new Layers(outputNeurons, NeuronType.Input);
            Layers.Add(outputLayer);
        }

        private void CreateInputLayer()
        {//0 enter topologeInput
            var inputNeurons = new List<Neuron>();//2 create collection of input neurons
            for (int i = 0; i < Topology.InputCount; i++)
            {
                var neuron = new Neuron(1, NeuronType.Input);//1 create new neuron
                inputNeurons.Add(neuron);//2 add newurons in collection
            }
            var inputLayer = new Layers(inputNeurons,NeuronType.Input);//3 create input layer which hollds firs input of collectionNeurons
            Layers.Add(inputLayer);//4 create first layer from topologe input
        }
    }
}
