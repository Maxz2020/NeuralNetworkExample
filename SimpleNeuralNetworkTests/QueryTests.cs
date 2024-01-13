using SimpleNeuralNetwork;

namespace NeuralNetworkTests
{
    public class QueryTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void QueryTest(TestData data)
        {
            var nn = new NeuralNetwork(3, 3, 3);
            nn.Init(data.Wih!, data.Who!);

            _ = nn.Query(data.InputList!);

            Assert.Equal(data.HiddenInputs!.GetLength(0), nn.HiddenInputs!.GetLength(0));
            for (var i = 0; i < data.HiddenInputs.GetLength(0); i++)
            {
                Assert.True(Math.Abs(data.HiddenInputs[i, 0] - nn.HiddenInputs[i, 0]) < 0.001);
            }

            Assert.Equal(data.HiddenOutputs!.Length, nn.HiddenOutputs!.Length);
            for (var i = 0; i < data.HiddenOutputs.Length; i++)
            {
                Assert.True(Math.Abs(data.HiddenOutputs[i] - nn.HiddenOutputs[i]) < 0.001);
            }

            Assert.Equal(data.FinalInputs!.GetLength(0), nn.FinalInputs!.GetLength(0));
            for (var i = 0; i < data.FinalInputs.GetLength(0); i++)
            {
                Assert.True(Math.Abs(data.FinalInputs[i, 0] - nn.FinalInputs[i, 0]) < 0.001);
            }

            Assert.Equal(data.FinalOutputs!.Length, nn.FinalOutputs!.Length);
            for (var i = 0; i < data.FinalOutputs.Length; i++)
            {
                Assert.True(Math.Abs(data.FinalOutputs[i] - nn.FinalOutputs[i]) < 0.001);
            }
        }

        public class TestData
        {
            public double[]? InputList { get; set; }
            public double[,]? Wih { get; set; }
            public double[,]? Who { get; set; }
            public double[,]? HiddenInputs { get; set; }
            public double[]? HiddenOutputs { get; set; }
            public double[,]? FinalInputs { get; set; }
            public double[]? FinalOutputs { get; set; }
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[]
                {
                    new TestData()
                    {
                        InputList = [0.9, 0.1, 0.8],
                        Wih = new double[3, 3] { { 0.9, 0.3, 0.4 }, { 0.2, 0.8, 0.2 }, { 0.1, 0.5, 0.6 } },
                        Who = new double[3, 3] { { 0.3, 0.7, 0.5 }, { 0.6, 0.5, 0.2 }, { 0.8, 0.1, 0.9 } },
                        HiddenInputs = new double[3, 1] { { 1.16 }, { 0.42 }, { 0.62 } },
                        HiddenOutputs = [0.761, 0.603, 0.65],
                        FinalInputs = new double[3, 1] { { 0.975 }, { 0.888 }, { 1.254 } },
                        FinalOutputs = [0.726, 0.708, 0.778]
                    }
                },
            };
    }
}
