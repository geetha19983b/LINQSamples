using System;
using System.Collections.Generic;
using System.Globalization;
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
                    case 4:
                        findAlbumDuration();
                        break;
                    case 5:
                        ExpandRange();
                        break;
                    case 6:
                        GetOldest();
                        break;
                    case 7:
                        FindIfAllItems_InFirstList_IsPresentInSecondList();
                        break;
                    default:
                        Console.WriteLine("byee");
                        break;
                }
            }
        }
        static void FindIfAllItems_InFirstList_IsPresentInSecondList()
        {
            //SampleClass[] List1 = { new SampleClass("1"), new SampleClass("a")};
            //SampleClass[] List2 = { new SampleClass("1"), new SampleClass("a"), new SampleClass("c"), new SampleClass("1") };
            List<string> List1 = new List<string>(){ "1", "a","1","rt" };
            List<string> List2 = new List<string>() { "a", "1", "b", "c" };
            //Except to remove from the first list all values that exist in the second list, and then check if all values have been removed:
            var allOfList1IsInList2 = List1.Except(List2).Any();
            //allOfList1IsInList2.ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine(allOfList1IsInList2);
        }
        //get the olderst person in the list
        static void GetOldest()
        {
            var res = "Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988"
        .Split(';')
        .Select(n => n.Split(','))
        .Select(n => new { Name = n[0].Trim(), DateOfBirth = DateTime.ParseExact(n[1].Trim(), "d/M/yyyy", CultureInfo.InvariantCulture) })
        .OrderByDescending(n => n.DateOfBirth);
       // .Select(n => new { Name = n.Name, Age = GetAge(n.DateOfBirth) });

            foreach (var i in res)
            {
              
                Console.WriteLine(i.Name + " " + i.DateOfBirth);
            }
    
        }
        //expand range eg 2,5,7,8,9,10 etc for input as 2,5,7-10
        static void ExpandRange()
        {
            var res = "2,5,7-10,11,17-18"
                 .Split(',')
                 .Select(x => x.Split('-'))
                 .Select(p => new { First = int.Parse(p[0]), Last = int.Parse(p.Last()) })
                .SelectMany(r => Enumerable.Range(r.First, r.Last - r.First + 1));

            foreach(var i in res)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            var res2 = "6,1-3,2-4"
                .Split(',')
                .Select(x => x.Split('-'))
                .Select(p => new { First = int.Parse(p[0]), Last = int.Parse(p.Last()) })
                .SelectMany(r => Enumerable.Range(r.First, r.Last - r.First + 1))
                .OrderBy(r => r)
                .Distinct();
            foreach (var i in res2)
            {
                Console.WriteLine(i);
            }
           
        }
        //find strings in list which are not subset for given input should not display "ab" and "ef" cause they are already subset of "abc" and "DEf"
        static void NonSunbsetStrings()
        {
            var list = new List<string> { "abc", "def", "ghi", "ab", "cd", "ef" };
            var res = list.Where(x => !list.Any(y => x != y && y.Contains(x)));
            foreach (var s in res)
            {
                Console.WriteLine(s);
            }
        }
        //use double up extension method to display the contents in sequence twice
        static void DoubleUpEx()
        {
            var numbers = new[] { 1, 5, 3 };
            var str = new[] { "orange", "pears" };
            numbers.DoubleUp().ToList().ForEach(x => Console.WriteLine(x));
            str.DoubleUp().ToList().ForEach(x => Console.WriteLine(x));
        }
        //eliminate lowest thress scores in list and sum the rest
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
        //find the album total duration
        static void findAlbumDuration()
        {
            var toaldur = "2:54,3:48,4:51,3:32,6:15,4:08,5:17,3:13,4:16,3:55,4:53,5:35,4:24"
                 .Split(',')
                 .Select(t => TimeSpan.Parse("0:" + t))
                 .Aggregate((t1, t2) => t1 + t2);

            Console.WriteLine("Album total duration is : " + toaldur);
        }

    }
}
