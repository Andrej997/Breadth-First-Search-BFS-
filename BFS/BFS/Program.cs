using System;

using BFS.Primer1.Controller;
using BFS.Primer1.Model;

using BFS.Primer2.Model;
using BFS.Primer2.Controller;

namespace BFS
{
    class Program
    {
        static void Main(string[] args)
        {
            #region PRIMER1
            /// https://www.csharpstar.com/csharp-breadth-first-search/
            Console.WriteLine("------START PRIMER1------");

            BreadthFirstAlgorithm b = new BreadthFirstAlgorithm();
            Employee root = b.BuildEmployeeGraph();
            Console.WriteLine("Traverse Graph\n------");
            b.Traverse(root);

            Console.WriteLine("\nSearch in Graph\n------");
            Employee e = b.Search(root, "Eva");
            Console.WriteLine(e == null ? "Employee not found" : e.name);
            e = b.Search(root, "Brian");
            Console.WriteLine(e == null ? "Employee not found" : e.name);
            e = b.Search(root, "Soni");
            Console.WriteLine(e == null ? "Employee not found" : e.name);

            Console.WriteLine("------END PRIMER1------\n");
            Console.ReadKey();
            #endregion

            #region PRIMER2
            /// https://www.dotnetlovers.com/article/167/breadth-first-searchbfs-and-graphs

            Console.WriteLine("\n------START PRIMER2------");
            BreadthFirstSearch demo = new BreadthFirstSearch(5);
            demo.AddV(1, 3);
            demo.AddV(2, 4);
            demo.AddV(2, 1);
            demo.AddV(0, 3);
            demo.AddV(3, 1);
            demo.AddV(4, 0);
            demo.AddV(3, 2);

            demo.PrintPath(0, 1);
            Console.WriteLine("------END PRIMER1------");
            Console.ReadKey();
            #endregion
        }
    }
}
