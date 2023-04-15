using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace LinqPerformance_Net6_7_8
{
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net70)]
    [SimpleJob(RuntimeMoniker.Net80)]
    [MemoryDiagnoser(false)]
    public class Benchmarks
    {
        [Params(100)]
        public int Size { get; set; }
        private IEnumerable<int> _items { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            _items = Enumerable.Range(0, 100).ToArray();
        }

        [Benchmark]
        public int Min() => _items.Min();

        [Benchmark]
        public int Max() => _items.Max();

        [Benchmark]
        public int Sum() => _items.Sum();

        [Benchmark]
        public double Average() => _items.Average();

    }
}
