using System;
using System.Collections.Generic;

namespace siszarp
{
    class Node<T>
    {
        T value;

        int number;

        static int total = 0;

        public Node()
        {
            number = total;
            total++;
        }

        List<Edge<T>> edges = new List<Edge<T>();

        public void addEdge(Edge<T> edge)
        {
            edges.Add(edge);
        }

        public void removeEdge(Edge<T> edge)
        {
            edges.Remove(edge);
        }

        public List<Edge<T>> GetEdges()
        {
            return edges;
        }

    }

    class Edge<T>
    {
        Node<T> node1;

        Node<T> node2;

        double value;

        public Edge(Node<T> node1, Node<T> node2, double value)
        {
            this.node1 = node1;
            this.node2 = node2;
            node1.addEdge(this);
            node2.addEdge(this);
            this.value = value;

        }

        public void removeNode()
        {
            node1 = null;

            node2 = null;
        }

        public Node<T>[] getNode()
        {
            return Node<T> { node1, node2 }; 
        }
    }

    class Graph<T>
    {
        List<Node<T>> nodes = new List<Node<T>>();

        public void addNode(Node<T> node)
        {
            nodes.Add(node);
        }

        public void removeNode(Node<T> node)
        {
            List<Edge<T>> edges = node.GetEdges();
            foreach (Edge<T> edge in edges)
            {
                removeEdge(edge);
            }

        }

        public void removeEdge(Edge<T> edge)
        {
            Node<T>[] nodes = edge.getNodes();
            edge.removeNode();
            nodes[0].removeEdge(edge);
            nodes[1].removeEdge(edge);
        }

        public int size()
        {
            return nodes.Count();
        }

        public string printNeighbour(Node<T> node)
        {

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
           


        }
    }
}
