namespace Extensions
{
    public static class MathExtensions
    {
        /// <summary>
        /// Создание и инициализация массива начальных весов заданной размерности
        /// Случайные числа от -0.5 до 0.5
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static double[,] GenereteRandomMatrix(int x, int y)
        {
            Random rnd = new();

            var result = new double[x, y];

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    result[i, j] = rnd.NextDouble() - 0.5;
                }
            }

            return result;
        }

        /// <summary>
        /// Скалярное произведение 2х двумерных массивов / матриц : a*b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static double[,] MultiplyMatrix(this double[,] a, double[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0))
            {
                // Чтобы можно было умножить две матрицы, количество столбцов первой матрицы должно быть равно количеству строк второй матрицы.
                throw new ArgumentException("Умножаемые матрицы должны быть совместимыми");
            }

            var result = new double[a.GetLength(0), b.GetLength(1)];

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < a.GetLength(1); k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Конвертация double[] в double[,]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double[,] ToMatrix(this double[] input)
        {
            var result = new double[input.Length, 1];
            for (int i = 0; i < input.Length; i++)
            {
                result[i, 0] = input[i];
            }
            return result;
        }

        /// <summary>
        /// Конвертация double[] в double[,] c транспонированием
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double[,] ToTranspondMatrix(this double[] input)
        {
            var result = new double[1, input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                result[0, i] = input[i];
            }
            return result;
        }

        /// <summary>
        /// Транспонирование
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double[,] Transpond(this double[,] input)
        {
            var result = new double[input.GetLength(1), input.GetLength(0)];

            for (int i = 0; i < input.GetLength(1); i++)
            {
                for (int j = 0; j < input.GetLength(0); j++)
                {
                    result[i, j] = input[j, i];
                }

            }
            return result;
        }

        /// <summary>
        /// Функция активации - в данном случае сигма - функция
        /// 1/(1+e^-x) = e^x/(e^x+1)
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Sigmoid(double x)
        {
            return Math.Exp(x) / (1 + Math.Exp(x));
        }

        /// <summary>
        /// Функция активации для входных параметров
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double[] Sigmoid(this double[,] x)
        {
            var result = new double[x.GetLength(0)];
            for (int i = 0; i < x.GetLength(0); i++)
            {
                result[i] = Sigmoid(x[i, 0]);
            }

            return result;
        }

        /// <summary>
        /// Поэлементная разница между массивами - вычисление ошибки нейросети
        /// </summary>
        /// <param name="target"></param>
        /// <param name="actual"></param>
        /// <returns></returns>
        public static double[] GetDif(this double[] target, double[] actual)
        {
            if (target.Length != actual.Length)
            {
                throw new ArgumentException("Размеры массивов должны совпадать.");
            }

            var result = new double[target.Length];

            for (int i = 0; i < target.Length; i++)
            {
                result[i] = target[i] - actual[i];
            }

            return result;
        }

        /// <summary>
        /// Поэлементная разность единицы и массива / 1-array
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static double[] Get1Dif(this double[] a)
        {
            var result = new double[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                result[i] = 1 - a[i];
            }

            return result;
        }

        /// <summary>
        /// Поэлементное умножение массивов
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static double[] MultiplyElements(this double[] a, double[] b)
        {
            if (a.Length != b.Length)
            {
                throw new ArgumentException("Размеры массивов должны совпадать.");
            }

            var result = new double[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                result[i] = a[i] * b[i];
            }

            return result;
        }

        /// <summary>
        /// Поэлементное умножение массива на константу
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double[,] MultiplyElements(this double[,] a, double b)
        {
            var result = new double[a.GetLength(0), a.GetLength(1)];

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    result[i, j] = a[i, j] * b;
                }
            }

            return result;
        }

        /// <summary>
        /// Поэлементное умножение массивов
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double[,] MultiplyElements(this double[,] a, double[,] b)
        {
            if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
            {
                throw new ArgumentException("Размеры массивов должны совпадать.");
            }

            var result = new double[a.GetLength(0), a.GetLength(1)];

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)

                    result[i, j] = a[i, j] * b[i, j];
            }

            return result;
        }

        /// <summary>
        /// Поэлементное сложение массивов
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double[,] AddElements(this double[,] a, double[,] b)
        {
            if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
            {
                throw new ArgumentException("Размеры массивов должны совпадать.");
            }

            var result = new double[a.GetLength(0), a.GetLength(1)];

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)

                    result[i, j] = a[i, j] + b[i, j];
            }

            return result;
        }

        /// <summary>
        /// Нормализация числа в диапапзон от 0.01 до 0.99
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static double Normalize(this double value, double min, double max)
        {
            if (max - min <= 0)
            {
                throw new ArgumentException("Минимальное и максимальное возможные значения должны быть корректно указаны.");
            }

            value += (0 - min);
            value /= (max - min);
            value *= 0.99;

            if (value == 0)
            {
                value = 0.01;
            }

            return value;
        }

        /// <summary>
        /// Нормализация массива в диапапзон от 0.01 до 1
        /// </summary>
        /// <param name="array"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static double[] Normalize(this double[] array, double min, double max)
        {
            var result = new double[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                result[i] = array[i].Normalize(min, max);
            }

            return result;
        }
    }
}
