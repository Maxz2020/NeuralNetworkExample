using Extensions;

namespace NeuralNetworkTests
{
    public class GetDifTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void GetDifTest(double[] a, double[] b, double[] expected)
        {
            var result = a.GetDif(b);

            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[]
                {
                    new double[3] { 1, 2, 3 },
                    new double[3] { 3, 2, 1 },
                    new double[3] { -2, 0, 2 },
                },
            };
    }
}
