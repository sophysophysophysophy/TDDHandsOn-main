using System;
using System.Linq;

namespace Variance
{
    class Program
    {
        // 도메인 지식 전달이 없을 때 프로그래머가 어떤 버그를 양산시킬 수 있는지. 도메인 지식 바탕 코딩의 중요성
        static void Main(string[] args) => Console.WriteLine(args.Length switch
        {
            0 => "입력된 데이터가 없습니다.",
            1 => "데이터가 부족해 분산을 계산할 수 없습니다. 2개 이상의 데이터를 입력해 주세요.",
            _ => GetCalculationOutput(args),
        });

        private static string GetCalculationOutput(string[] args)
        {
            double[] source = ParseArguments(args);
            double variance = CalculateVariance(source);
            return $"분산: {variance}";
        }

        private static double[] ParseArguments(string[] args)
            => args.Select(double.Parse).ToArray();

        private static double CalculateVariance(double[] source)
        {
            double sumOfSquares = CalculateSumOfSquares(source);
            int degreesOfFreedom = source.Length - 1;
            return sumOfSquares / degreesOfFreedom;
        }

        private static double CalculateSumOfSquares(double[] source)
        {
            double mean = source.Average();
            return source.Select(x => mean - x)
                         .Select(d => d * d)
                         .Sum();
        }
    }
}