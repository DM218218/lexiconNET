using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace IncrementedItinerary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? firstLine = Console.ReadLine();
            IncrementedItinerary incrementedItinerary = new IncrementedItinerary();

            if (string.IsNullOrEmpty(firstLine))
            {
                Console.WriteLine("Please provide number of intersections and number of streets.");
                return;
            }

            int numberOfNodes = int.Parse(firstLine.Split(" ")[0]);
            int numberOfEdges = int.Parse(firstLine.Split(" ")[1]);
            List<Node> graph = new();

            for (int i = 0; i < numberOfNodes; i++)
            {
                graph.Add(new Node(i));
            }

            for (int i = 0; i < numberOfEdges; i++)
            {
                string edgeInput = Console.ReadLine();
                (int, int) edge;

                edge.Item1 = int.Parse(edgeInput.Split(" ")[0]) - 1;
                edge.Item2 = int.Parse(edgeInput.Split(" ")[1]) - 1;

                //add bidirectional edge between nodes
                graph[edge.Item1].neighbors.Add(graph[edge.Item2]);
                graph[edge.Item2].neighbors.Add(graph[edge.Item1]);
            }

            if(incrementedItinerary.isNewRoutePossible(graph))
            {
                Console.WriteLine("possible");
            }
            else
            {
                Console.WriteLine("impossible");
            }
        }
    }

    class Node
    {
        public int Id;
        public List<Node> neighbors = new();

        public Node(int id)
        {
            Id = id;
        }
    }

    class IncrementedItinerary
    {
        public IncrementedItinerary() 
        {
        }

        internal bool isNewRoutePossible(List<Node> graph)
        {
            bool result = false;

            Dictionary<Node, int> shortestPaths = new();
            List<Node> shortestPathRoute = new();

            //start node 0
            shortestPaths.Add(graph[0], 0);

            for (int i = 1; i < graph.Count; i++)
            {
                shortestPaths.Add(graph[i], int.MaxValue);
            }
                
            //shortestPaths = FindShortestToGoal(shortestPaths, graph[graph.Count - 1]);
            shortestPathRoute = FindShortestPathToGoal(shortestPaths, graph[graph.Count - 1]);

            result = YenIt(shortestPathRoute, graph, shortestPaths[graph[graph.Count - 1]]);

            //foreach (var kvp in shortestPaths)
            //{
            //    Console.WriteLine($"{kvp.Key.Id} - {kvp.Value}");
            //}
            //foreach (var node in shortestPathRoute)
            //{
            //    Console.Write($"{node.Id} - ");
            //}

            //Console.WriteLine("Done");

            return result;
        }

        private bool YenIt(List<Node> shortestPathRoute, List<Node> graph, int oldWeight)
        {
            bool result = false;
            int weight = 0;
            (Node, Node) restoreEdge = (null,  null);

            for (int i = 0; i < shortestPathRoute.Count - 1; i++)
            {
                //if current branch point only have 1 neighbor branching is irrelevant
                //if current branch point has only 2 neighboors and is not the start branching is irrelevant
                //since we arrived from one and is going to the other, no alternate route
                if ((shortestPathRoute[i].neighbors.Count == 1 && i == 0) 
                    || (shortestPathRoute[i].neighbors.Count == 2 && i != 0))
                {
                    continue;
                }

                Dictionary<Node, int> newShortestPath = new();
                restoreEdge = (shortestPathRoute[i], shortestPathRoute[i + 1]);
                RemoveEdge(restoreEdge);

                //start node 0
                newShortestPath.Add(graph[0], 0);

                for (int j = 1; j < graph.Count; j++)
                {
                    newShortestPath.Add(graph[j], int.MaxValue);
                }

                FindShortestPathToGoal(newShortestPath, graph[graph.Count - 1]);
                RestoreEdge(restoreEdge);

                weight = newShortestPath[graph[graph.Count - 1]];
                if(weight == oldWeight + 1)
                {
                    return true;
                }
            }

            return result;
        }

        private void RestoreEdge((Node, Node) restoreEdge)
        {
            restoreEdge.Item1.neighbors.Add(restoreEdge.Item2);
            restoreEdge.Item2.neighbors.Add(restoreEdge.Item1);
        }

        private void RemoveEdge((Node, Node) restoreEdge)
        {
            restoreEdge.Item1.neighbors.Remove(restoreEdge.Item2);
            restoreEdge.Item2.neighbors.Remove(restoreEdge.Item1);
        }

        Dictionary<Node, int> FindShortest(Dictionary<Node, int> shortestPaths)
        {
            List<Node> visited = new();

            while (visited.Count < shortestPaths.Count)
            {
                //find next node
                Node activeNode = FindShortestUnvisited(shortestPaths, visited);

                for (int i = 0; i < activeNode.neighbors.Count; i++)
                {
                    //update distance to neighbors
                    if (!visited.Contains(activeNode.neighbors[i]))
                    {
                        if(shortestPaths[activeNode.neighbors[i]] > shortestPaths[activeNode] + 1)
                        {
                            shortestPaths[activeNode.neighbors[i]] = shortestPaths[activeNode] + 1;
                        }
                    }
                }

                //mark current as visited
                visited.Add(activeNode);
            }

            return shortestPaths;
        }

        Dictionary<Node, int> FindShortestToGoal(Dictionary<Node, int> shortestPaths, Node goal)
        {
            List<Node> visited = new();

            while (visited.Count < shortestPaths.Count)
            {
                //find next node
                Node activeNode = FindShortestUnvisited(shortestPaths, visited);

                for (int i = 0; i < activeNode.neighbors.Count; i++)
                {
                    //update distance to neighbors
                    if (!visited.Contains(activeNode.neighbors[i]))
                    {
                        if (shortestPaths[activeNode.neighbors[i]] > shortestPaths[activeNode] + 1)
                        {
                            shortestPaths[activeNode.neighbors[i]] = shortestPaths[activeNode] + 1;
                        }
                    }
                }

                //mark current as visited
                visited.Add(activeNode);
                //are we done?
                if(activeNode == goal)
                {
                    break;
                }
            }

            return shortestPaths;
        }

        List<Node> FindShortestPathToGoal(Dictionary<Node, int> shortestPaths, Node goal)
        {
            List<Node> visited = new();
            Dictionary<Node, Node> predecessors = new();

            foreach (var pair in shortestPaths)
            {
                predecessors.Add(pair.Key, null);
            }

            while (visited.Count < shortestPaths.Count)
            {
                //find next node
                Node activeNode = FindShortestUnvisited(shortestPaths, visited);

                for (int i = 0; i < activeNode.neighbors.Count; i++)
                {
                    //update distance to neighbors
                    if (!visited.Contains(activeNode.neighbors[i]))
                    {
                        if (shortestPaths[activeNode.neighbors[i]] > shortestPaths[activeNode] + 1)
                        {
                            shortestPaths[activeNode.neighbors[i]] = shortestPaths[activeNode] + 1;
                            //and update predessesor
                            predecessors[activeNode.neighbors[i]] = activeNode;
                        }
                    }
                }

                //mark current as visited
                visited.Add(activeNode);
            }

            //reconstruct the path
            List<Node> nodePath = new();
            Node currentNode = goal;

            while (predecessors[currentNode] != null)
            {
                nodePath.Add(currentNode);
                currentNode = predecessors[currentNode];
            }

            //add start node to path
            nodePath.Add(currentNode);

            nodePath.Reverse();
            return nodePath;
        }

        private Node FindShortestUnvisited(Dictionary<Node, int> shortestPaths, List<Node> visited)
        {
            Node lowest = null;
            int path = int.MaxValue;

            foreach(var pair in shortestPaths)
            {
                if(path >= pair.Value && !visited.Contains(pair.Key))
                {
                    path = pair.Value;
                    lowest = pair.Key;
                }
            }

            return lowest;
        }
    }
}
