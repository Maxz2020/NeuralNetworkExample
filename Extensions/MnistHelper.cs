namespace Extensions
{
    // MNIST in CSV - the train set and test set. https://pjreddie.com/projects/mnist-in-csv/
    public class MnistHelper
    {
        private readonly string _mnistDatasetPath = Path.Combine([Environment.CurrentDirectory, "mnist_dataset"]);

        /// <summary>
        /// Загрузка и подготовка данных из CSV файлов с рукописными цифрами
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public List<double[][]> LoadData(string filename)
        {
            List<double[][]> result = [];

            foreach (string line in File.ReadLines(Path.Combine([_mnistDatasetPath, filename])))
            {
                var array = line.Split(',');

                var target = ConvertToTargetArray(array[0]);

                var example = NormalizeStringArray(array[1..]);

                result.Add([target, example]);
            }

            return result;
        }

        private static double[] ConvertToTargetArray(string value)
        {
            var result = new double[10];

            result[int.Parse(value)] = 0.99;

            return result;
        }

        private static double[] NormalizeStringArray(string[] array)
        {
            return array.Select(double.Parse).ToArray().Normalize(0, 255);
        }
    }
}
