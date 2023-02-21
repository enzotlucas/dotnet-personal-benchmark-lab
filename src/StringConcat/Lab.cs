using BenchmarkDotNet.Attributes;
using System.Text;

namespace StringConcat
{
    [MemoryDiagnoser]
    public class Lab
    {
        [Params(10, 100)]
        public int Number;

        private string[] _words;
        private readonly string _phrase = "Lorem ipsum dolor sit amet.";
        private readonly string _concatPhrase = "Sed recusandae maiores aut ipsa quidem aut illum";
        private readonly string _concatWord = "Lorem";

        [GlobalSetup]
        public void Setup()
        {
            _words = new string[Number]; 
            Array.Fill(_words, _concatWord);
        }



        //Operator
        [Benchmark]
        public void ConcatUsingOperator()
        {
            var result = _phrase + " " + _concatPhrase;

            Console.WriteLine(result);
        }

        [Benchmark]
        public void ConcatCollectionUsingOperatorAndForeach()
        {
            var result = _phrase;

            foreach (var word in _words)
            {
                result = result + " " + word;
            }

            Console.WriteLine(result);
        }

        [Benchmark]
        public void ConcatCollectionUsingOperatorAndFor()
        {
            var result = _phrase;

            for (int i = 0; i < Number; i++)
            {
                var word = _words[i];

                result = result + " " + word;
            }

            Console.WriteLine(result);
        }



        //Interpolation
        [Benchmark]
        public void ConcatUsingInterpolation()
        {
            var result = $"{_phrase} {_concatPhrase}";

            Console.WriteLine(result);
        }

        [Benchmark]
        public void ConcatCollectionUsingInterpolationAndForeach()
        {
            var result = _phrase;

            foreach (var word in _words)
            {
                result = $"{result} {word}";
            }

            Console.WriteLine(result);
        }

        [Benchmark]
        public void ConcatCollectionUsingInterpolationAndFor()
        {
            var result = _phrase;

            for (int i = 0; i < Number; i++)
            {
                var word = _words[i];

                result = $"{result} {word}";
            }

            Console.WriteLine(result);
        }



        //StringFormat
        [Benchmark]
        public void ConcatUsingStringFormat()
        {
            var result = string.Format("{0} {1}", _phrase, _concatPhrase);

            Console.WriteLine(result);
        }

        [Benchmark]
        public void ConcatCollectionUsingStringFormatAndForeach()
        {
            var result = _phrase;

            foreach (var word in _words)
            {
                result = string.Format("{0} {1}", result, word);
            }

            Console.WriteLine(result);
        }

        [Benchmark]
        public void ConcatCollectionUsingStringFormatAndFor()
        {
            var result = _phrase;

            for (int i = 0; i < Number; i++)
            {
                var word = _words[i];

                result = string.Format("{0} {1}", result, word);
            }

            Console.WriteLine(result);
        }



        //StringBuilder
        [Benchmark]
        public void ConcatUsingStringBuilder()
        {
            var builder = new StringBuilder();

            builder.Append(_phrase);
            builder.Append(' ');
            builder.Append(_concatPhrase);

            var result = builder.ToString();

            Console.WriteLine(result);
        }

        [Benchmark]
        public void ConcatCollectionUsingStringBuilderAndForeach()
        {
            var builder = new StringBuilder();

            builder.Append(_phrase);

            foreach (var word in _words)
            {
                builder.Append(' ');

                builder.Append(word);
            }

            var result = builder.ToString();

            Console.WriteLine(result);
        }

        [Benchmark]
        public void ConcatCollectionUsingStringBuilderAndFor()
        {
            var builder = new StringBuilder();

            builder.Append(_phrase);

            for (int i = 0; i < Number; i++)
            {
                var word = _words[i];

                builder.Append(' ');

                builder.Append(word);
            }

            var result = builder.ToString();

            Console.WriteLine(result);
        }



        //StringConcat
        [Benchmark]
        public void ConcatCollectionUsingStringConcat()
        {
            var result = _phrase;

            result += string.Concat(" ", _words);

            Console.WriteLine(result);
        }



        //StringJoin
        [Benchmark]
        public void ConcatCollectionUsingStringJoin()
        {
            var result = _phrase;

            result += string.Join(" ", _words);

            Console.WriteLine(result);
        }



        //LINQ
        [Benchmark]
        public void ConcatCollectionUsingLinqAggregate()
        {
            var result = _phrase;

            result = _words.Aggregate((partialPhrase, word) => $"{partialPhrase} {word}");

            Console.WriteLine(result);
        }
    }
}
