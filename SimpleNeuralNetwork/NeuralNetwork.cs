using Extensions;

namespace SimpleNeuralNetwork
{
    public class NeuralNetwork(int inputnodes, int hiddennodes, int outputnodes, double learningRate = 0.3)
    {
        /// <summary>
        /// Кол-во входных узлов
        /// </summary>
        public int Inputnodes { get; private set; } = inputnodes;

        /// <summary>
        /// Кол-во узлов скрытого слоя
        /// </summary>
        public int Hiddennodes { get; private set; } = hiddennodes;

        /// <summary>
        /// Кол-во выходных узлов
        /// </summary>
        public int Outputnodes { get; private set; } = outputnodes;

        /// <summary>
        /// Коэфф. обучения
        /// </summary>
        public double LearningRate { get; private set; } = learningRate;

        // Входные параметры нейросети
        public double[]? InputList { get; private set; }

        /// <summary>
        /// Матрица весовых коэффициентов связей между входным и скрытым слоями Hiddennodes х Inputnodes. Весовые коэффициенты связей между узлом i и узлом j следующего слоя обозначены как w_i_j: w11 w21 w12 w22 и т.д.
        /// </summary>
        public double[,]? Wih { get; private set; }

        /// <summary>
        /// Матрица весовых коэффициентов связей между скрытым и выходным слоями Outputnodes х Hiddennodes
        /// </summary>
        public double[,]? Who { get; private set; }

        /// <summary>
        /// Входящие сигналы для скрытого слоя
        /// </summary>
        public double[,]? HiddenInputs { get; private set; }

        /// <summary>
        /// Исходящие сигналы для скрытого слоя
        /// </summary>
        public double[]? HiddenOutputs { get; private set; }

        /// <summary>
        /// Входящие сигналы для выходного слоя
        /// </summary>
        public double[,]? FinalInputs { get; private set; }

        /// <summary>
        /// Исходящие сигналы для выходного слоя
        /// </summary>
        public double[]? FinalOutputs { get; private set; }

        /// <summary>
        /// Ошибка нейросети: желаемые значения минус ответ нейросети
        /// </summary>
        public double[]? OutputErrors { get; private set; }

        /// <summary>
        /// ошибки скрытого слоя - это ошибки распределенные пропорционально весовым коэффициентам связей и рекомбинированные на скрытых узлах   
        /// </summary>
        public double[,]? HiddenErrors { get; private set; }

        /// <summary>
        /// Заполнение весовых коэффициентов случайными начальными значениями
        /// </summary>
        public void Init()
        {
            Wih = MathExtensions.GenereteRandomMatrix(Hiddennodes, Inputnodes);
            Who = MathExtensions.GenereteRandomMatrix(Outputnodes, Hiddennodes);
        }

        /// <summary>
        /// Заполнение весовых коэффициентов фикcированными начальными значениями
        /// </summary>
        public void Init(double[,] wih, double[,] who)
        {
            Wih = wih;
            Who = who;
        }

        // Опрос нейронной сети
        public double[] Query(double[] inputList)
        {
            if (inputList.Length != Inputnodes)
            {
                throw new ArgumentException("Кол-во входящих параметров должно быть равно кол-ву входных узлов.");
            }

            InputList = inputList;

            // рассчитать входящие сигналы для скрытого слоя
            HiddenInputs = Wih!.MultiplyMatrix(InputList.ToMatrix());

            // рассчитать исходящие сигналы для скрытого слоя
            HiddenOutputs = HiddenInputs.Sigmoid();

            // рассчитать входящие сигналы для выходного слоя
            FinalInputs = Who!.MultiplyMatrix(HiddenOutputs.ToMatrix());

            // рассчитать исходящие сигналы для выходного слоя
            FinalOutputs = FinalInputs.Sigmoid();

            return FinalOutputs;
        }

        public void Train(double[] inputList, double[] targetList)
        {
            if (targetList.Length != Outputnodes)
            {
                throw new ArgumentException("Кол-во исходящих параметров должно быть равно кол-ву выходных узлов.");
            }

            Query(inputList);

            // Ошибка нейросети: желаемые значения минус ответ нейросети
            OutputErrors = targetList.GetDif(FinalOutputs!);

            // ошибки скрытого слоя - это ошибки распределенные пропорционально весовым коэффициентам связей и рекомбинированные на скрытых узлах     
            HiddenErrors = Who!.Transpond().MultiplyMatrix(OutputErrors.ToMatrix());

            //Поэлементное произведение Ошибка сети * ответ нейросети
            var x1 = OutputErrors.MultiplyElements(FinalOutputs!);

            // 1 минус ответ нейросети
            var x2 = FinalOutputs!.Get1Dif();

            // Поэлементное произведение (ошибка сети * ответ сети * (1 - ответсети)
            var x3 = x1.MultiplyElements(x2);

            // Транспонированные данные выхода скрытого слоя
            var x4 = HiddenOutputs!.ToTranspondMatrix();

            // Произведение подготовленных матриц
            var x5 = x3.ToMatrix().MultiplyMatrix(x4);

            // Поэлементное умножение полученной матрицы на коэффициент обучения
            var x6 = x5.MultiplyElements(LearningRate);

            // Добавляем к весовым коэффициентам рассчитанные поправки 
            Who = Who!.AddElements(x6);


            // Те же самые действия для весов Wih ...
            var x11 = HiddenErrors.MultiplyElements(HiddenOutputs!.ToMatrix());
            x2 = HiddenOutputs!.Get1Dif();
            var x33 = x11.MultiplyElements(x2.ToMatrix());
            x4 = InputList!.ToTranspondMatrix();
            x5 = x33.MultiplyMatrix(x4);
            x6 = x5.MultiplyElements(LearningRate);
            Wih = Wih!.AddElements(x6);
        }
    }
}
