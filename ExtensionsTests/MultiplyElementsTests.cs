using Extensions;

namespace NeuralNetworkTests
{
    public class MultiplyElementsTests
    {
        [Theory]
        [MemberData(nameof(TestData1))]
        public void MultiplyElementsTest1(double[] a, double[] b, double[] expected)
        {
            var result = a.MultiplyElements(b);

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(TestData2))]
        public void MultiplyElementsTest2(double[,] a, double b, double[,] expected)
        {
            var result = a.MultiplyElements(b);

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(TestData3))]
        public void MultiplyElementsTest3(double[,] a, double[,] b, double[,] expected)
        {
            var result = a.MultiplyElements(b);

            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData1 =>
            new List<object[]>
            {
                new object[]
                {
                    new double[3] { 1, 2, -3 },
                    new double[3] { 3, 0, 2 },
                    new double[3] { 3, 0, -6 },
                },
            };

        public static IEnumerable<object[]> TestData2 =>
            new List<object[]>
            {
                new object[]
                {
                    new double[3,3] { { 1, 2, 3 }, { -4, -1, 0 }, { 100, 1, 1 } },
                    2,
                    new double[3,3] { { 2, 4, 6 }, { -8, -2, 0 }, { 200, 2, 2 } },
                },
            };

        public static IEnumerable<object[]> TestData3 =>
            new List<object[]>
            {
                new object[]
                {
                    new double[3,3] { { 1, 2, 3 }, { -4, -10, 0 }, { 10, 1, 2 } },
                    new double[3,3] { { 1, 2, 3 }, { -4, 2, 0 }, { 10, 2, 1 } },
                    new double[3,3] { { 1, 4, 9 }, { 16, -20, 0 }, { 100, 2, 2 } },
                },
            };
    }
}
