using Extensions;

namespace NeuralNetworkTests
{
    public class MultiplyMatrixTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void MultiplyMatrixTest(double[,] a, double[,] b, double[,] expected)
        {
            var c = a.MultiplyMatrix(b);

            Assert.Equal(expected, c);
        }

        public static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[]
                {
                    // [строки, столбцы]
                    new double[2, 2] { { 1, 2 }, { 3, 4 } },
                    new double[2, 2] { { 5, 6 }, { 7, 8 } },
                    new double[2, 2] { { 19, 22 }, { 43, 50 } },
                },
                new object[]
                {
                    new double[2, 3] { { 1, 2 , 2 }, { 3, 1, 1 } },
                    new double[3, 2] { { 4, 2 }, { 3, 1 }, { 1, 5 } },
                    new double[2, 2] { { 12, 14 }, { 16, 12 } },
                },
                new object[]
                {
                    new double[3, 2] { { 4, 2 }, { 3, 1 }, { 1, 5 } },
                    new double[2, 3] { { 1, 2 , 2 }, { 3, 1, 1 } },
                    new double[3, 3] { { 10, 10, 10 }, { 6, 7, 7 }, { 16, 7, 7 } },
                },
                new object[]
                {
                    new double[3, 3] { { 1, 2, 1 }, { 0, 4, -4 }, { 3, 1, 2} },
                    new double[3, 1] { { 1 }, { 3 }, { 2 } },
                    new double[3, 1] {  { 9 }, { 4 }, { 10 } },
                },
                new object[]
                {
                    new double[3, 1] { { 1 }, { 3 } , { 2 } },
                    new double[1, 3] { { 9, 4, 10 } },
                    new double[3, 3] { { 9, 4, 10 }, { 27, 12, 30 }, { 18, 8, 20} },
                },
            };
    }
}