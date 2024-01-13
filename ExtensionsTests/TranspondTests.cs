using Extensions;

namespace NeuralNetworkTests
{
    public class TranspondTests
    {
        [Theory]
        [MemberData(nameof(TestData1))]
        public void TranspondTest1(double[] a, double[,] expected)
        {
            var result = a.ToTranspondMatrix();

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(TestData2))]
        public void TranspondTest2(double[,] a, double[,] expected)
        {
            var result = a.Transpond();

            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData1 =>
            new List<object[]>
            {
                new object[]
                {
                    new double[3] { 1, 2, -3 },
                    new double[1,3] { { 1, 2, -3 } },
                },
            };

        public static IEnumerable<object[]> TestData2 =>
            new List<object[]>
            {
                new object[]
                {
                    new double[3,3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } },
                    new double[3,3] { { 1, 4, 7 }, { 2, 5, 8 }, { 3, 6, 9 } },
                },
                new object[]
                {
                    new double[2,3] { { 1, 2, 3 }, { 4, 5, 6 } },
                    new double[3,2] { { 1, 4 }, { 2, 5 }, { 3, 6 } },
                },
                new object[]
                {
                    new double[3,2] { { 1, 4 }, { 2, 5 }, { 3, 6 } },
                    new double[2,3] { { 1, 2, 3 }, { 4, 5, 6 } },
                },
            };
    }
}
