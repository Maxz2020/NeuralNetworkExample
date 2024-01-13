using SimpleNeuralNetwork;

namespace NeuralNetworkTests
{
    public class TrainTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void TrainTest(TestData data)
        {
            var nn = new NeuralNetwork(data.Inputnodes, data.Hiddennodes, data.Outputnodes, data.LearningRate);
            nn.Init(data.Wih!, data.Who!);

            nn.Train(data.InputList!, data.TargetList!);

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

            Assert.Equal(data.OutputErrors!.Length, nn.OutputErrors!.Length);
            for (var i = 0; i < data.OutputErrors.Length; i++)
            {
                Assert.True(Math.Abs(data.OutputErrors[i] - nn.OutputErrors[i]) < 0.001);
            }

            Assert.Equal(data.HiddenErrors!.GetLength(0), nn.HiddenErrors!.GetLength(0));
            for (var i = 0; i < data.HiddenErrors.GetLength(0); i++)
            {
                Assert.True(Math.Abs(data.HiddenErrors[i, 0] - nn.HiddenErrors[i, 0]) < 0.001);
            }

            Assert.Equal(data.TranedWho!.GetLength(0), nn.Who!.GetLength(0));
            Assert.Equal(data.TranedWho!.GetLength(1), nn.Who!.GetLength(1));
            for (var i = 0; i < data.TranedWho.GetLength(0); i++)
            {
                for (int j = 0; j < data.TranedWho!.GetLength(1); j++)
                {
                    Assert.True(Math.Abs(data.TranedWho![i, j] - nn.Who![i, j]) < 0.001);
                }
            }

            Assert.Equal(data.TranedWih!.GetLength(0), nn.Wih!.GetLength(0));
            Assert.Equal(data.TranedWih!.GetLength(1), nn.Wih!.GetLength(1));
            for (var i = 0; i < data.TranedWih.GetLength(0); i++)
            {
                for (int j = 0; j < data.TranedWih!.GetLength(1); j++)
                {
                    Assert.True(Math.Abs(data.TranedWih![i, j] - nn.Wih![i, j]) < 0.001);
                }
            }
        }
        public class TestData
        {
            public int Inputnodes { get; set; }
            public int Hiddennodes { get; set; }
            public int Outputnodes { get; set; }
            public double LearningRate { get; set; }
            public double[]? InputList { get; set; }
            public double[]? TargetList { get; set; }
            public double[,]? Wih { get; set; }
            public double[,]? Who { get; set; }
            public double[,]? HiddenInputs { get; set; }
            public double[]? HiddenOutputs { get; set; }
            public double[,]? FinalInputs { get; set; }
            public double[]? FinalOutputs { get; set; }
            public double[]? OutputErrors { get; set; }
            public double[,]? HiddenErrors { get; set; }
            public double[,]? TranedWho { get; set; }
            public double[,]? TranedWih { get; set; }
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[]
                {
                    new TestData()
                    {
                        Inputnodes = 3,
                        Hiddennodes = 3,
                        Outputnodes = 3,
                        LearningRate = 0.3,
                        InputList = [1.0, 0.5, -1.5],
                        TargetList = [0.5, 0.6, 0.7],
                        Wih = new double[3, 3] { { 0.1, 0.2 , 0.3}, { 0.4, 0.5, 0.6 }, { 0.7, 0.8, 0.9 } },
                        Who = new double[3, 3] { { -0.1, -0.2 , -0.3}, { -0.4, -0.5, -0.6 }, { -0.7, -0.8, -0.9 } },
                        HiddenInputs = new double[3, 1] { { -0.25 }, { -0.25 }, { -0.25 } },
                        HiddenOutputs = [0.4378235, 0.4378235, 0.4378235],
                        FinalInputs = new double[3, 1] { { -0.2626941 }, { -0.65673525 }, { -1.0507764 } },
                        FinalOutputs = [0.43470155, 0.34147337, 0.25907604],
                        OutputErrors = [0.06529845, 0.25852663, 0.44092396],
                        HiddenErrors = new double[3, 1] { { -0.41858727 }, { -0.49506217 }, { -0.57153707 } },
                        TranedWho = new double[3, 3] { { -0.09789238, -0.19789238, -0.29789238 }, { -0.39236418, -0.49236418, -0.59236418 }, { -0.68888307, -0.78888307, -0.88888307 } },
                        TranedWih = new double[3, 3] { { 0.06909142, 0.18454571, 0.34636287 }, { 0.3634445, 0.48172225, 0.65483325 }, { 0.65779757, 0.77889879, 0.96330364 } },
                    },
                },
                new object[]
                {
                    new TestData()
                    {
                        Inputnodes = 3,
                        Hiddennodes = 4,
                        Outputnodes = 2,
                        LearningRate = 0.2,
                        InputList = [0.01, 1, 0.5 ],
                        TargetList = [0.5, 1],
                        Wih = new double[4, 3] { { 0.1, 0.2 , 0.3}, { 0.4, 0.5, 0.6 }, { 0.7, 0.8, 0.9 }, { -0.7, -0.8, -0.9 } },
                        Who = new double[2, 4] { { -0.1, -0.2 , -0.3, 0.4}, { -0.4, -0.5, -0.6, 0.7 } },
                        HiddenInputs = new double[4, 1] { { 0.351 }, { 0.804 }, { 1.257 }, { -1.257 } },
                        HiddenOutputs = [0.58686006, 0.69082947, 0.77850924, 0.22149076],
                        FinalInputs = new double[2, 1] { { -0.34180837 }, { -0.89222077 } },
                        FinalOutputs = [0.41537027, 0.29065175],
                        OutputErrors = [0.08462973, 0.70934825],
                        HiddenErrors = new double[4, 1] { { -0.29220227 }, { -0.37160007 }, { -0.45099787 }, { 0.53039567 } },
                        TranedWho = new double[2, 4] { { -0.09758785, -0.19716051, -0.29680012, 0.40091038 }, { -0.3828345, -0.47979342, -0.57722881, 0.70647855 } },
                        TranedWih = new double[4, 3] { { 0.09985831, 0.1858308, 0.2929154 }, { 0.39984126, 0.48412643, 0.59206321 }, { 0.69984447, 0.78444665, 0.89222333 }, { -0.69981708, -0.7817085, -0.89085425 } },
                    },
                },
            };
    }
}
