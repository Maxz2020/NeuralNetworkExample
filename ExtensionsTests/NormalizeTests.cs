using Extensions;

namespace NeuralNetworkTests
{
    public class NormalizeTests
    {
        [Theory]
        [MemberData(nameof(TestData1))]
        public void MultiplyMatrixTest1(double input, double min, double max, double expected)
        {
            var result = input.Normalize(min, max);

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(TestData2))]
        public void MultiplyMatrixTest2(double[] input, double min, double max, double[] expected)
        {
            var result = input.Normalize(min, max);

            for (var i = 0; i < expected.Length; i++)
            {
                Assert.True(Math.Abs(expected[i] - result[i]) < 0.001);
            }
        }

        public static IEnumerable<object[]> TestData1 =>
            new List<object[]>
            {
                new object[]
                {
                    1,
                    0,
                    1,
                    0.99
                },
                new object[]
                {
                    0,
                    0,
                    1,
                    0.01
                },
                new object[]
                {
                    100,
                    -100,
                    100,
                    0.99
                },
                new object[]
                {
                    0,
                    -127,
                    127,
                    0.495
                },
                new object[]
                {
                    755,
                    0,
                    1000,
                    0.74745
                },
                new object[]
                {
                    -500,
                    -1000,
                    1000,
                    0.2475
                },
            };

        public static IEnumerable<object[]> TestData2 =>
            new List<object[]>
            {
                new object[]
                {
                    new double[] { 0, 50, 100, 127, 255 },
                    0,
                    255,
                    new double[] { 0.01, 0.194, 0.388, 0.493, 0.99 },
                },
            };
    }
}
