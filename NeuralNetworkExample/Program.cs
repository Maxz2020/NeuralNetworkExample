using Extensions;
using SimpleNeuralNetwork;

namespace NeuralNetworkExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mnistHelper = new MnistHelper();
            var loadedData = mnistHelper.LoadData("mnist_train_100.csv");

            var neuralNetwork = new NeuralNetwork(784, 100, 10);
            neuralNetwork.Init();
            Console.WriteLine($"Примеров всего: {loadedData.Count}");

            var epoh = 5; // Количество эпох - повторных циклов обучения на одних и тех же данных
            for (int i = 0; i < epoh; i++)
            {
                Console.WriteLine($"Эпоха: {i + 1} из {epoh}");
                var cnt = 0;
                foreach (var data in loadedData)
                {
                    cnt++;
                    if (cnt % 100 == 0)
                    {
                        Console.Write(cnt);
                        Console.CursorLeft = 0;
                    }


                    neuralNetwork.Train(data[1], data[0]);
                }
            }

            loadedData = mnistHelper.LoadData("mnist_test_10.csv");

            var errors = 0;
            foreach (var data in loadedData)
            {
                var result = neuralNetwork.Query(data[1]);

                errors += CompareResults(result, data[0]);
            }

            Console.WriteLine($"Всего ошибок: {errors} из {loadedData.Count} ({(errors / (double)loadedData.Count) * 100}% ошибок)");
        }

        static int CompareResults(double[] actual, double[] expected)
        {
            var actualIndex = Array.IndexOf(actual, actual.Max());

            var expectedlIndex = Array.IndexOf(expected, expected.Max());

            if (expectedlIndex == actualIndex)
            {
                Console.WriteLine($"Успрех! {actualIndex} - уверенность для {actualIndex}: {Math.Round(actual[actualIndex], 3)}");
                return 0;
            }
            else
            {
                Console.WriteLine($"Ошибка! - Ожидание:{expectedlIndex} Результат:{actualIndex} (Уверенность для {actualIndex}:{actual[actualIndex]}) уверенность для {expectedlIndex}: {Math.Round(actual[expectedlIndex], 3)}");
                return 1;
            }
        }
    }
}
