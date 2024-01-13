namespace Extensions
{
    public static class DispalyExtensions
    {
        /// <summary>
        /// Вывод на консоль
        /// </summary>
        /// <param name="array"></param>
        /// <param name="header"></param>
        public static void PrintMatrix(this double[,]? array, string? header = null)
        {
            Console.WriteLine(header);
            for (int i = 0; i < array?.GetLongLength(0); i++)
            {
                for (int j = 0; j < array.GetLongLength(1); j++)
                {
                    Console.Write(array[i, j].ToString());
                    Console.Write("\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Вывод на консоль
        /// </summary>
        /// <param name="array"></param>
        /// <param name="header"></param>
        public static void PrintMatrix(this double[]? array, string? header = null)
        {
            Console.WriteLine(header);
            for (int i = 0; i < array?.GetLongLength(0); i++)
            {
                Console.Write(array[i].ToString());
                Console.Write("\t");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
