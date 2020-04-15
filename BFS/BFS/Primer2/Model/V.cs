using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS.Primer2.Model
{
    /// <summary>
    /// Vertex Structure
    /// </summary>
    public class V
    {
        public int Vertex { get; set; }     //vertex number
        public V Next { get; set; }         //reachable vertex
        public V(int val)
        {
            Vertex = val;
            Distance = Int32.MaxValue;
            Color = 'W';
        }

        public int Distance { get; set; }   //distance from source
        public char Color { get; set; }     //initial color
        public V Parent { get; set; }       //parent node for keep tracking direction
    }
}
