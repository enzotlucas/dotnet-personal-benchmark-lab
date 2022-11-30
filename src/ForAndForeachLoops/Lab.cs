using BenchmarkDotNet.Attributes;

namespace ForAndForeachLoops
{
    [MemoryDiagnoser]
    public class Lab
    {
        [Params(10, 100, 100000)]
        public int Number;

        private List<int> NumberList;
        private int[] NumberArray;

        [GlobalSetup]
        public void Setup()
        {
            NumberList = Enumerable.Range(1, Number).ToList();
            NumberArray = Enumerable.Range(1, Number).ToArray();
        }

        [Benchmark]
        public void ForeachLoopWithList()
        {
            foreach (var number in NumberList)
            {
                var test = number * number;
                test -= number;
                test.ToString();
            }
        }

        [Benchmark]
        public void ForeachLoopWithArray()
        {
            foreach (var number in NumberArray)
            {
                var test = number * number;
                test -= number;
                test.ToString();
            }
        }

        [Benchmark]
        public void ForLoopWithList()
        {
            for (int i = 0; i < NumberList.Count; i++)
            {
                var number = NumberList[i];
                var test = number * number;
                test -= number;
                test.ToString();
            }
        }

        [Benchmark]
        public void ForLoopWithArray()
        {
            for (int i = 0; i < NumberArray.Length; i++)
            {
                var number = NumberArray[i];
                var test = number * number;
                test -= number;
                test.ToString();
            }
        }

        [Benchmark]
        public void ParallelForeachLoopWithList()
        {
            Parallel.ForEach(NumberList, number =>
            {
                var test = number * number;
                test -= number;
                test.ToString();
            });
        }

        [Benchmark]
        public void ParallelForeachLoopWithArray()
        {
            Parallel.ForEach(NumberArray, number =>
            {
                var test = number * number;
                test -= number;
                test.ToString();
            });
        }

        [Benchmark]
        public void ParallelForLoopWithList()
        {
            Parallel.For(0, NumberList.Count, i =>
            {
                var number = NumberList[i];
                var test = number * number;
                test -= number;
                test.ToString();
            });
        }

        [Benchmark]
        public void ParallelForLoopWithArray()
        {
            Parallel.For(0, NumberArray.Length, i =>
            {
                var number = NumberArray[i];
                var test = number * number;
                test -= number;
                test.ToString();
            });
        }
    }
}
