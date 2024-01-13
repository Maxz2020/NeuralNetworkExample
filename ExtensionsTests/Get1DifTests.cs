using Extensions;

namespace NeuralNetworkTests
{
    public class Get1DifTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void Get1DifTest(double[] a, double[] expected)
        {
            var result = a.Get1Dif();

            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[]
                {
                    new double[3] { 1, 2, -3 },
                    new double[3] { 0, -1, 4 },
                },
            };
    }
}
