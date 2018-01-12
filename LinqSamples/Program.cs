using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter option to run enter 0 to quit");

            int opt = 1;
            while (opt > 0)
            {
                opt = Convert.ToInt32(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        NonSunbsetStrings();
                        break;
                    case 2:
                        DoubleUpEx();
                        break;
                    case 3:
                        SumScoresElimatingLowestthreescores();
                        break;
                    default:
                        Console.WriteLine("byee");
                        break;
                }
            }
        }
        //find strings in list which are not subset
        static void NonSunbsetStrings()
        {
            var list = new List<string> { "abc", "def", "ghi", "ab", "cd", "ef" };
            var res = list.Where(x => !list.Any(y => x != y && y.Contains(x)));
            foreach(var s in res)
            {
                Console.WriteLine(s);
            }
        }
        static void DoubleUpEx()
        {
            var numbers = new[] { 1, 5, 3 };
            var str = new[] { "orange", "pears" };
            numbers.DoubleUp().ToList().ForEach(x => Console.WriteLine(x));
            str.DoubleUp().ToList().ForEach(x => Console.WriteLine(x));
        }
        static void SumScoresElimatingLowestthreescores()
        {
            //var scores = "10,5,0,8,10,1,4,0,10,1";
            //var scores_wthutleast = scores.Split(',').Select(int.Parse)
            //    .OrderBy(n => n).Skip(3).Sum();
            var res = "10,5,0,8,10,1,4,0,10,1"
     .Split(',')
     .Select(int.Parse)
     .OrderBy(n => n)
     .Skip(3)
     .Sum();
            Console.WriteLine("sum without lease three scores" + res);
        }
            
    }
}
