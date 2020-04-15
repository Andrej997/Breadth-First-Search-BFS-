using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BFS.Primer2.Model;

namespace BFS.Primer2.Controller
{
    public class BreadthFirstSearch
    {
        public int v;
        public V[] adjList;
        public BreadthFirstSearch(int totalVertix)
        {
            v = totalVertix;
            adjList = new V[totalVertix];
            for (int i = 0; i < adjList.Length; i++)
                adjList[i] = new V(i);

        }

        /// <summary>
        /// Adds a vertex to adjacency list
        /// </summary>
        /// <param name="u">vertex where v has to be linked</param>
        /// <param name="v">vertex which has to be linked</param>
        public void AddV(int u, int v)
        {
            V tempU = adjList[u];
            //finding if there is already same vertex v is connected 
            while (tempU.Next != null)
            {
                if (tempU.Vertex != v) //reaching last
                    tempU = tempU.Next;
                else             //v is already defined
                    return;
            }
            tempU.Next = new V(v);   // connecting new vertex v to u

            //for undirected graph we have to connect vertex v also to u
            V tempV = adjList[v];
            while (tempV.Next != null)
                tempV = tempV.Next;

            tempV.Next = new V(u);  //connecting v to u
        }

        /// <summary>
        /// Breadth First Search Algorithm
        /// </summary>
        /// <param name="source">where to start</param>
        private void BFS(int source)
        {
            Queue<V> queue = new Queue<V>(); //initializing vertex Queue
            V src = adjList[source]; //finding source
            src.Color = 'G'; //giving color grey to source
            src.Distance = 0; //0 distance to source
            src.Parent = null;  // np parent for source

            //marking all other vertices color to white distance is max and parent is null
            for (int i = 0; i < adjList.Length; i++)
            {
                V u = adjList[i];
                if (u.Vertex != source)
                {
                    u.Color = 'W';
                    u.Distance = Int32.MaxValue;
                    u.Parent = null;
                }
            }

            queue.Enqueue(src); //enquing source
            while (queue.Count > 0)
            {
                V u = queue.Dequeue();
                V v = u.Next; //finding linked vertex
                while (v != null)
                {
                    V mainV = adjList[v.Vertex];  // getting actual vertex
                    if (mainV.Color == 'W')  //process only if white
                    {
                        mainV.Color = 'G'; //grey for currently processing
                        mainV.Distance = u.Distance + 1; // distance 1+ from parent
                        mainV.Parent = u; //assigning parent
                        queue.Enqueue(mainV); //enqueue for finding connected nodes to this
                    }

                    v = v.Next; //another node connected to u
                }

                u.Color = 'B'; //once completed mark color as black
            }
        }

        /// <summary>
        /// Recursive method prints minimum path
        /// </summary>
        /// <param name="u">source</param>
        /// <param name="v">destination</param>
        private void RecPrint(V u, V v)
        {
            if (u == v)
                Console.WriteLine(u.Vertex);
            else if (v.Parent == null)
                Console.WriteLine("No way from u to v");
            else
            {
                RecPrint(u, v.Parent);
                Console.WriteLine(v.Vertex + " ");
            }
        }

        public void PrintPath(int u, int v)
        {
            BFS(u);
            RecPrint(adjList[u], adjList[v]);
        }
    }
}
