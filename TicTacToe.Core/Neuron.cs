namespace TicTacToe.Core;
public class Neuron
{

    public double Value = 0.0;
    public double Delta = 0.0;
    public double[] Inputs = new double[9];
    public double Output = 0.0;


    public double[] Weights = new double[9];

    private void RandomizeWeights()
    {
        Random random = new();
        for (var w = 0; w < Weights.Length; w++)
        {
            Weights[w] = random.NextDouble();
        }
    }
    public Neuron() => RandomizeWeights();
    public static double Sigmoid(double x) => 1.0 / (1.0 + Math.Exp(-x));
    public static double SigmoidDx(double x) => Sigmoid(x) * (1.0 - Sigmoid(x));

    public void Learn(double error, double LearningRate)
    {
        Delta = error * SigmoidDx(Output);

        for (int i = 0; i < Weights.Length; i++)
        {
            var newWeight = Weights[i] - Inputs[i] * Delta * LearningRate;

            if (newWeight > 1 || newWeight < 0)
            {
                newWeight = newWeight - Math.Floor(newWeight);
            }

            Weights[i] = newWeight;
        }
    }
    public void FeedForward(double[] inputs)
    {
        Inputs = inputs;

        var sum = 0.0;
        for (int i = 0; i < inputs.Length; i++)
        {
            sum += inputs[i] * Weights[i];
        }
        Output = Sigmoid(sum);
    }
}