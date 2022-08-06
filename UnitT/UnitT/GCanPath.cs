using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitT
{
    public class GCanPath
    {
        [Theory]
        [ClassData(typeof(GCanPath.Data))]
        public void Test(Dictionary<string, List<string>> graph, string source, string destination, bool expected)
        {
            Assert.Equal(expected, CalculateDepth(graph, source, destination));
            Assert.Equal(expected, CalculateBreadth(graph, source, destination));
        }

        private bool CalculateDepth(Dictionary<string, List<string>> graph, string source, string destination)
        {
            if (source == destination)
                return true;

            foreach (var neighbor in graph[source])
            {
                if (CalculateDepth(graph, neighbor, destination))
                    return true;
            }
            return false;
        }

        private bool CalculateBreadth(Dictionary<string, List<string>> graph, string source, string destination)
        {
            
            var queue = new Queue<string>();
            queue.Enqueue(source);
            
            string curr;
            while (queue.Any() && (curr = queue.Dequeue()) is not null)
            {
                
                if (curr == destination)
                    return true ;
                foreach (var neighbor in graph[curr])
                    queue.Enqueue(neighbor);
            }
            return false ;

        }

        private class Data : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                var graph = new Dictionary<string, List<string>>(10);
                graph.Add("a", new() { "b", "c" });
                graph.Add("b", new());
                graph.Add("c", new() { "d" });
                graph.Add("d", new() { "x" });
                graph.Add("x", new());
                graph.Add("y", new() { "b", "x" });

                yield return new object[] { graph, "a", "x", true };
                yield return new object[] { graph, "a", "y", false };
                yield return new object[] { graph, "a", "o", false };

            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
