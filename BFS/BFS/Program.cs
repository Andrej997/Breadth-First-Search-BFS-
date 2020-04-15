using System;
using System.Collections.Generic;

using BFS.Primer1.Controller;
using BFS.Primer1.Model;

using BFS.Primer2.Model;
using BFS.Primer2.Controller;

using BFS.Primer3.Model;
using BFS.Primer3.Controller;

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
            Console.WriteLine("------END PRIMER2------\n");
            Console.ReadKey();
            #endregion

            #region PRIMER3
            ///https://www.koderdojo.com/blog/breadth-first-search-and-shortest-path-in-csharp-and-net-core

            /// Undirected Graph Modeled as Adjacency List
            Console.WriteLine("\n------START PRIMER3------");

            var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var edges = new[]{Tuple.Create(1,2), Tuple.Create(1,3),
                Tuple.Create(2,4), Tuple.Create(3,5), Tuple.Create(3,6),
                Tuple.Create(4,7), Tuple.Create(5,7), Tuple.Create(5,8),
                Tuple.Create(5,6), Tuple.Create(8,9), Tuple.Create(9,10)};

            var graph = new Graph<int>(vertices, edges);
            var algorithms = new Algorithms();

            #region Prva metoda
            Console.WriteLine(string.Join(", ", algorithms.BFS(graph, 1)));
            #endregion

            #region Druga metoda
            var path = new List<int>();
            Console.WriteLine(string.Join(", ", algorithms.BFS(graph, 1, v => path.Add(v))));
            Console.WriteLine(string.Join(", ", path));
            #endregion

            #region Treca metoda
            var startVertex = 1;
            var shortestPath = algorithms.ShortestPathFunction(graph, startVertex);
            foreach (var vertex in vertices)
                Console.WriteLine("shortest path to {0,2}: {1}",
                        vertex, string.Join(", ", shortestPath(vertex)));
            #endregion

            Console.WriteLine("------END PRIMER3------\n");
            Console.ReadKey();
            #endregion
        }
    }
}
