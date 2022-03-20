namespace ConsoleTicTacToe;
class NeuralNetwork
{
    private List<Neuron[]> Layers = new List<Neuron[]>();
    public int FirstIndex, SecondIndex;
    private Neuron[] InputNeurons = new Neuron[9];
    private Neuron[] HiddenNeurons = new Neuron[9];
    private Neuron[] OuputNeurons = new Neuron[9];
     
    int LayerIndex = 0;
    double LearningRate;
    public NeuralNetwork(double LearningRate)
    {
        this.LearningRate = LearningRate;

        int index = 0;

        for (int In = 0; In < InputNeurons.Length; In++)
        {
            InputNeurons[In] = new();
        }
        //Layers[index] = InputNeurons;
        Layers.Add(InputNeurons);
        index++;


        for (int Hn = 0; Hn < HiddenNeurons.Length; Hn++)
        {
            HiddenNeurons[Hn] = new Neuron();
        }
        //Layers[index] = HiddenNeurons;
        Layers.Add(HiddenNeurons);
        index++;

        for (int On = 0; On < OuputNeurons.Length; On++)
        {
            OuputNeurons[On] = new();
        }
        Layers.Add(OuputNeurons);
        //Layers[index] = OuputNeurons;
    }
    public void FeedForward()
    {
        var inputs = new double[9];
        for (int i = 0; i < Layers.Count; i++)
        {
            if (i == 0) inputs = Matrix.Normalization();
            else
            {
                for (int h = 0; h < Layers[LayerIndex].Length; h++)
                {
                    inputs[h] = Layers[i - 1][h].Output;
                }
            }

            foreach (var neuron in Layers[i])
            {
                neuron.FeedForward(inputs);
            }
        }

        //output Init
        double max = 0.0;
        int index = 0;
        for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < 3; column++)
            {
                if (Layers.Last()[index].Output > max)
                {
                    max = Layers.Last()[index].Output;
                    FirstIndex = row;
                    SecondIndex = column;
                }
                index++;
            }
        }
    }
    public void Backpropogation(double response)
    {
        double error = 0.0;
        for (int j = Layers.Count - 1; j > 0; j--)
        {
            if (j == Layers.Count - 1)
            {
                error = response;
            }
            else
            {
                var previousLayer = Layers[j + 1];

                for (int i = 0; i < Layers[j].Length; i++)
                {
                    for (int k = 0; k < previousLayer.Length; k++)
                    {
                        var previousNeuron = previousLayer[k];
                        error = previousNeuron.Weights[i] * previousNeuron.Delta;
                        Layers[j][i].Learn(error, LearningRate);
                    }
                }
            }

            foreach (var neuron in Layers[j])
            {
                neuron.Learn(error, LearningRate);
            }
        }
    }
}