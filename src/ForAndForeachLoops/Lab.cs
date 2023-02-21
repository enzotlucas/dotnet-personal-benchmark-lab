using BenchmarkDotNet.Attributes;

namespace ForAndForeachLoops
{
    [MemoryDiagnoser]
    public class Lab
    {
        [Params(10, 100, 100000)]
        public int Number;

        private List<int> _numberList;
        private int[] _numberArray;

        [GlobalSetup]
        public void Setup()
        {
            _numberList = Enumerable.Range(1, Number).ToList();
            _numberArray = Enumerable.Range(1, Number).ToArray();
        }

        [Benchmark]
        public void ForeachLoopWithList()
        {
            foreach (var number in _numberList)
            {
                var test = number * number;
                test -= number;
                test.ToString();
            }
        }

        [Benchmark]
        public void ForeachLoopWithArray()
        {
            foreach (var number in _numberArray)
            {
                var test = number * number;
                test -= number;
                test.ToString();
            }
        }

        [Benchmark]
        public void ForLoopWithList()
        {
            for (int i = 0; i < _numberList.Count; i++)
            {
                var number = _numberList[i];
                var test = number * number;
                test -= number;
                test.ToString();
            }
        }

        [Benchmark]
        public void ForLoopWithArray()
        {
            for (int i = 0; i < _numberArray.Length; i++)
            {
                var number = _numberArray[i];
                var test = number * number;
                test -= number;
                test.ToString();
            }
        }

        [Benchmark]
        public void ParallelForeachLoopWithList()
        {
            Parallel.ForEach(_numberList, number =>
            {
                var test = number * number;
                test -= number;
                test.ToString();
            });
        }

        [Benchmark]
        public void ParallelForeachLoopWithArray()
        {
            Parallel.ForEach(_numberArray, number =>
            {
                var test = number * number;
                test -= number;
                test.ToString();
            });
        }

        [Benchmark]
        public void ParallelForLoopWithList()
        {
            Parallel.For(0, _numberList.Count, i =>
            {
                var number = _numberList[i];
                var test = number * number;
                test -= number;
                test.ToString();
            });
        }

        [Benchmark]
        public void ParallelForLoopWithArray()
        {
            Parallel.For(0, _numberArray.Length, i =>
            {
                var number = _numberArray[i];
                var test = number * number;
                test -= number;
                test.ToString();
            });
        }
    }
}
