using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{

    //count the numer of graphs islands 
    public class GCountGraphs
    {
        [Theory]
        [ClassData(typeof(GCountGraphs.Data))]
        public void Test(Dictionary<string, List<string>> graph, int expected)
        {

            Assert.Equal(expected, Calculate(graph));
        }
        private int Calculate(Dictionary<string, List<string>> graph)
        {
            var x = 0;
            HashSet<string> visited = new HashSet<string>(graph.Count);
            foreach (var item in graph)
            {
                if (visited.Contains(item.Key))
                    continue;
                if (TravelBreadth(graph, visited, item.Key))//could use TravelDepth as well 
                    x++;
            }
            return x;
        }
        private bool TravelDepth(Dictionary<string, List<string>> graph, HashSet<string> visited, string curr)
        {
            if (visited.Contains(curr))
                return false;
            visited.Add(curr);
            foreach (var str in graph[curr])
            {
                TravelDepth(graph, visited, str);
            }
            return true;
        }

        private bool TravelBreadth(Dictionary<string, List<string>> graph, HashSet<string> visited, string curr)
        {
            Queue<string> queue = new();
            if (visited.Contains(curr))
                return false;
            queue.Enqueue(curr);
            visited.Add(curr);
            string str;
            while (queue.Count > 0 && (str = queue.Dequeue()) is not null)
                foreach (var item in graph[str])
                {
                    if (visited.Contains(item))
                        continue;
                    queue.Enqueue(item);
                    visited.Add(item);
                }
            return true;

        }
        private class Data : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                //var graph = new Dictionary<string, List<string>>(10);
                //graph.Add("c", new() {"a", "d" });
                //graph.Add("d", new() { "c","x" });
                //graph.Add("x", new() { "d"});
                //graph.Add("y", new() {"n", "z" });
                //graph.Add("z", new() {"y", "n" });
                //graph.Add("n", new() {"z", "y" });
                //graph.Add("o", new());
                //graph.Add("a", new() { "b", "c" });
                //graph.Add("b", new() { "a"});

                var graph = GetUndirectedGraph(new() { ("a", "c"), ("a", "b"), ("c", "d"), ("d", "x"), ("y", "n"), ("y", "z"), ("z", "n") ,("o",null)});
                yield return new object[] { graph, 3 };
            }


            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

            private Dictionary<string, List<string>> GetUndirectedGraph(HashSet<(string p1, string? p2)> directed)
            {
                var graph = new Dictionary<string, List<string>>(10);
                foreach (var item in directed)
                {
                    //if (!graph.ContainsKey(item.p1) && item.p2 ==null)
                    //    graph.Add
                    if (!graph.ContainsKey(item.p1))
                    {
                        if (item.p2 == null)
                            graph[item.p1] = new List<string>();
                        else
                            graph.Add(item.p1, new() { item.p2 });
                    }
                    else if (!graph[item.p1].Contains(item.p2))
                        graph[item.p1].Add(item.p2);
                    if (item.p2 == null)
                        continue;
                    if (!graph.ContainsKey(item.p2))
                        graph.Add(item.p2, new() { item.p1 });
                    else if (!graph[item.p2].Contains(item.p1))
                        graph[item.p2].Add(item.p1);

                }
                return graph;
            }
        }
    }
}
