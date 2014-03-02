using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Program
    {
        //TODO make a choice in command line program. Add scanner.
        static void Main(string[] args)
        {
            ProblemPrinter(15);
            int PROBLEMS = 15;
            //for (int i = 1; i <= PROBLEMS;i++ )
                //ProblemPrinter(i);
        }

        static void ProblemPrinter(int problemNumber)
        {
            var probleName = "Problem"+problemNumber;
            ProblemSolver s = new ProblemSolver();
            Type t = s.GetType();
            Stopwatch timer = new Stopwatch();
            try
            {
                var pb = t.GetMethod(probleName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
                Debug.Write("Problem " + problemNumber + " : ");
                timer.Start();
                Debug.WriteLine(pb.Invoke(s, null));
                Debug.WriteLine("elapsed time :" + timer.ElapsedMilliseconds + "ms------------------------------------\n");
                timer.Stop();
            } catch(Exception) {
                Debug.WriteLine("ERROR");
                timer.Stop();
            }
        }
    }
}
