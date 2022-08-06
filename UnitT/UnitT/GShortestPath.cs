using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class GShortestPath
    {
        [Theory]
        [ClassData(typeof(GShortestPath.Data))]
        public void Test(Dictionary<string, List<string>> graph, string source, string destination, int? pathLen)
        {
            Assert.Equal(pathLen, Calculate(graph, source, destination));
        }
        private int? Calculate(Dictionary<string, List<string>> graph, string source, string destination)
        {
           // var x = DepthTraversal(graph, source, destination, new(), 0);
            var x = BreadthTraversal(graph, source, destination, new());
            return x;
        }

        private int? BreadthTraversal(Dictionary<string, List<string>> graph, string source, string destination, HashSet<string> visited)
        {
            if (destination == source)
                return 0;
            Queue<(string val, int len)> queue = new ();
            queue.Enqueue((source,0));
            while (queue.Count > 0 && (_= queue.Dequeue()) is (string,int) curr && !string.IsNullOrEmpty(curr.val) )
            {
                if (visited.Contains(curr.val))
                    continue;
                if (curr.val == destination)
                    return curr.len;
                foreach(var item in graph[curr.val])
                {
                    queue.Enqueue((item,curr.len+1));
                }
            }
            return null;
        }

        //this is bad depth is not suited for the shortest path question 
        private int? DepthTraversal(Dictionary<string, List<string>> graph, string source, string destination, HashSet<string> visited, int? len)
        {
            if (source == destination)
                return len;
            if (visited.Contains(source))
                return null;
            len++;
            visited.Add(source);

            foreach (var neighbor in graph[source])
            {
                int? r = DepthTraversal(graph, neighbor, destination, visited, len);
                if (r.HasValue)
                {
                    return r.Value;
                }

            }
            return null;
        }

        private class Data : IEnumerable<object[]>
        {
            private Dictionary<string, List<string>> GetGraph(HashSet<(string p1, string? p2)> edges)
            {
                var graph = new Dictionary<string, List<string>>();
                foreach (var edge in edges)
                {
                    if (!graph.ContainsKey(edge.p1))
                        graph.Add(edge.p1, new());
                    if (edge.p2 != null && !graph.ContainsKey(edge.p2))
                        graph.Add(edge.p2, new());
                    if (edge.p2 != null)
                    {
                        graph[edge.p1].Add(edge.p2);
                        if (graph.ContainsKey(edge.p2))
                            graph[edge.p2].Add(edge.p1);
                    }
                }
                return graph;
            }
            HashSet<(string p1, string? p2)> edges = new(10);

            public IEnumerator<object[]> GetEnumerator()
            {
                var graph = GetGraph(new HashSet<(string p1, string? p2)> { ("a", "b"), ("c", "d"), ("d", "x"), ("a", "c"), ("n", "z"), ("n", "y"), ("y", "z"), ("x", "b") });
                yield return new object[] { graph, "x", "a", 2 };
                // yield return new object[] { graph, "y", "a", null };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        }
    }
}
