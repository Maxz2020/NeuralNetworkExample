using Extensions;

namespace NeuralNetworkTests
{
    public class SigmaTests
    {
        [Theory]
        [MemberData(nameof(TestData1))]
        public void SigmaTest1(double x, double expected)
        {
            var result = MathExtensions.Sigmoid(x);

            Assert.True(Math.Abs(expected - result) < 0.00000001);
        }

        [Theory]
        [MemberData(nameof(TestData2))]
        public void SigmaTest2(double[,] x, double[] expected)
        {
            var result = x.Sigmoid();

            for (var i = 0; i < expected.GetLength(0); i++)
            {
                Assert.True(Math.Abs(expected[i] - result[i]) < 0.00000001);
            }
        }

        public static IEnumerable<object[]> TestData1 =>
            new List<object[]>
            {
                new object[]
                {
                    2.5,
                    0.9241418199787566
                },
            };

        public static IEnumerable<object[]> TestData2 =>
            new List<object[]>
            {
                new object[]
                {
                    new double[3, 1] { { -1.5 }, { 0 }, { 1.5 } },
                    new double[3] { 0.18242552, 0.5, 0.81757448 },
                },
            };
    }
}
