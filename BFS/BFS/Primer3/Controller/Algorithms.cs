using System;
using System.Collections.Generic;
using System.Linq;
using BFS.Primer3.Model;

namespace BFS.Primer3.Controller
{
    public class Algorithms
    {
        /// <summary>
        /// To make sure the breadth-first search algorithm doesn't re-visit vertices, 
        /// the visited HashSet keeps track of vertices already visited. A Queue, called queue, 
        /// keeps track of vertices found but not yet visited. Initially queue contains the starting vertex. 
        /// The next vertex is dequeued from queue. If it has already been visited, 
        /// it is discarded and the next vertex is dequeued from queue. If it has not been visited, 
        /// it is added to the set of visited vertices and its unvisited neighbors are added to queue. 
        /// This continues until there are no more vertices in queue, and the set of vertices visited is returned. 
        /// The set of vertices returned is all the vertices that can be reached from the starting vertex.
        /// </summary>
        public HashSet<T> BFS<T>(Graph<T> graph, T start)
        {
            var visited = new HashSet<T>();

            if (!graph.AdjacencyList
.ContainsKey(start))
                return visited;

            var queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);

                foreach (var neighbor in graph.AdjacencyList[vertex])
                    if (!visited.Contains(neighbor))
                        queue.Enqueue(neighbor);
            }

            return visited;
        }

        /// <summary>
        /// If you want a list of the vertices as they are visited by breadth-first search, 
        ///  just add each vertex one-by-one to a list. 
        /// Here is breadth-first search with an extra parameter, preVisit, 
        /// which allows one to pass a function that gets called each time a vertex is visited.
        /// </summary>
        public HashSet<T> BFS<T>(Graph<T> graph, T start, Action<T> preVisit = null)
        {
            var visited = new HashSet<T>();

            if (!graph.AdjacencyList.ContainsKey(start))
                return visited;

            var queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                if (visited.Contains(vertex))
                    continue;

                if (preVisit != null)
                    preVisit(vertex);

                visited.Add(vertex);

                foreach (var neighbor in graph.AdjacencyList[vertex])
                    if (!visited.Contains(neighbor))
                        queue.Enqueue(neighbor);
            }

            return visited;
        }

        /// <summary>
        /// Breadth-first search is unique with respect to depth-first search in that you can 
        /// use breadth-first search to find the shortest path between 2 vertices. 
        /// This assumes an unweighted graph. The shortest path in this case is defined as 
        /// the path with the minimum number of edges between the two vertices.
        /// In these cases it might be useful to calculate the shortest path to all vertices 
        /// in the graph from the starting vertex, and provide a function that allows the client 
        /// application to query for the shortest path to any other vertex.
        /// I've created a ShortestPathFunction in C# that does just this. 
        /// It caculates the shortest path to all vertices from a starting vertex and then returns a 
        /// function that allows one to query for the shortest path to any vertex from the original starting vertex.
        /// Breadth-first search is being used to traverse the graph from the starting 
        /// vertex and storing how it got to each node(the previous node ) into a C# Dictionary, called previous. 
        /// To find the shortest path to a node, the code looks up the previous node of the destination 
        /// node and continues looking at all previous nodes until it arrives at the starting node. 
        /// Since this will be the path in reverse, the code simply reverses the list and returns it.
        /// </summary>
        public Func<T, IEnumerable<T>> ShortestPathFunction<T>(Graph<T> graph, T start)
        {
            var previous = new Dictionary<T, T>();

            var queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                foreach (var neighbor in graph.AdjacencyList[vertex])
                {
                    if (previous.ContainsKey(neighbor))
                        continue;

                    previous[neighbor] = vertex;
                    queue.Enqueue(neighbor);
                }
            }

            Func<T, IEnumerable<T>> shortestPath = v => {
                var path = new List<T> { };

                var current = v;
                while (!current.Equals(start))
                {
                    path.Add(current);
                    current = previous[current];
                };

                path.Add(start);
                path.Reverse();

                return path;
            };

            return shortestPath;
        }
    }
}
