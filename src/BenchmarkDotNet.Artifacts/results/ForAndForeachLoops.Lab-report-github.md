``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19042.804/20H2/October2020Update)
AMD Ryzen 5 5600X, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.400
  [Host]     : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2


```
|                       Method | Number |            Mean |         Error |        StdDev |          Median |     Gen0 |   Gen1 | Allocated |
|----------------------------- |------- |----------------:|--------------:|--------------:|----------------:|---------:|-------:|----------:|
|          **ForeachLoopWithList** |     **10** |        **55.08 ns** |      **1.097 ns** |      **1.501 ns** |        **54.85 ns** |   **0.0134** |      **-** |     **224 B** |
|         ForeachLoopWithArray |     10 |        49.08 ns |      0.988 ns |      1.651 ns |        48.65 ns |   0.0134 |      - |     224 B |
|              ForLoopWithList |     10 |        54.44 ns |      1.107 ns |      2.407 ns |        54.94 ns |   0.0134 |      - |     224 B |
|             ForLoopWithArray |     10 |        55.19 ns |      1.086 ns |      2.539 ns |        54.04 ns |   0.0134 |      - |     224 B |
|  ParallelForeachLoopWithList |     10 |     1,611.51 ns |     15.622 ns |     14.613 ns |     1,608.45 ns |   0.1488 |      - |    2507 B |
| ParallelForeachLoopWithArray |     10 |     1,590.27 ns |     10.897 ns |     10.193 ns |     1,589.10 ns |   0.1488 |      - |    2498 B |
|      ParallelForLoopWithList |     10 |     1,557.10 ns |     16.940 ns |     15.845 ns |     1,551.37 ns |   0.1450 |      - |    2426 B |
|     ParallelForLoopWithArray |     10 |     1,530.01 ns |     28.658 ns |     26.807 ns |     1,520.96 ns |   0.1431 |      - |    2411 B |
|          **ForeachLoopWithList** |    **100** |       **793.78 ns** |     **15.551 ns** |     **14.547 ns** |       **789.12 ns** |   **0.1850** |      **-** |    **3104 B** |
|         ForeachLoopWithArray |    100 |       738.93 ns |     12.067 ns |     11.287 ns |       736.84 ns |   0.1850 |      - |    3104 B |
|              ForLoopWithList |    100 |       805.15 ns |     11.497 ns |     10.754 ns |       802.35 ns |   0.1850 |      - |    3104 B |
|             ForLoopWithArray |    100 |       763.65 ns |     10.198 ns |      8.516 ns |       762.50 ns |   0.1850 |      - |    3104 B |
|  ParallelForeachLoopWithList |    100 |     3,760.25 ns |     10.785 ns |     10.088 ns |     3,758.50 ns |   0.3624 |      - |    6075 B |
| ParallelForeachLoopWithArray |    100 |     3,617.91 ns |      6.885 ns |      6.103 ns |     3,618.59 ns |   0.3624 |      - |    6032 B |
|      ParallelForLoopWithList |    100 |     3,552.78 ns |     21.668 ns |     20.268 ns |     3,555.11 ns |   0.3548 |      - |    5956 B |
|     ParallelForLoopWithArray |    100 |     3,469.37 ns |     14.074 ns |     11.752 ns |     3,470.41 ns |   0.3548 |      - |    5921 B |
|          **ForeachLoopWithList** | **100000** | **1,563,759.19 ns** | **12,018.092 ns** | **10,653.726 ns** | **1,561,306.93 ns** | **263.6719** |      **-** | **4434105 B** |
|         ForeachLoopWithArray | 100000 | 1,468,138.24 ns | 17,224.117 ns | 16,111.449 ns | 1,469,290.43 ns | 263.6719 |      - | 4434105 B |
|              ForLoopWithList | 100000 | 1,527,281.86 ns | 20,350.108 ns | 19,035.503 ns | 1,521,067.58 ns | 263.6719 |      - | 4434105 B |
|             ForLoopWithArray | 100000 | 1,540,175.92 ns | 13,211.132 ns | 11,711.324 ns | 1,537,300.10 ns | 263.6719 |      - | 4434105 B |
|  ParallelForeachLoopWithList | 100000 |   400,935.15 ns |  1,214.297 ns |  1,076.443 ns |   400,808.25 ns | 265.6250 | 3.4180 | 4438125 B |
| ParallelForeachLoopWithArray | 100000 |   382,086.13 ns |  1,060.724 ns |    828.144 ns |   382,253.52 ns | 265.6250 | 3.4180 | 4438066 B |
|      ParallelForLoopWithList | 100000 |   377,887.93 ns |  3,127.494 ns |  2,925.460 ns |   376,257.71 ns | 265.6250 | 3.4180 | 4438083 B |
|     ParallelForLoopWithArray | 100000 |   377,448.78 ns |  1,022.791 ns |    798.528 ns |   377,395.19 ns | 265.6250 | 3.4180 | 4438085 B |
