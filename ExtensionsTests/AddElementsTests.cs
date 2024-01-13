using Extensions;

namespace NeuralNetworkTests
{
    public class AddElementsTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void AddElementsTest(double[,] a, double[,] b, double[,] expected)
        {
            var result = a.AddElements(b);

            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[]
                {
                    new double[3,3] { { 1, 2, 3 }, { -4, -1, 0 }, { 100, -1, 1 } },
                    new double[3,3] { { 2, 4, 6 }, { -8, -2, 0 }, { 200, 2, 2 } },
                    new double[3,3] { { 3, 6, 9 }, { -12, -3, 0 }, { 300, 1, 3 } },
                },
            };
    }
}
