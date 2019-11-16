using System;
using System.Collections.Generic;
using System.Linq;
using Encoding.Entities;
using Encoding.Systems.Interfaces.Utilities;

namespace Encoding.Systems.Utilities
{
    public class HuffmanNodesManager : IHuffmanNodesManager
    {
        public Node GetNodeFromByteStatistics(List<ByteStatistics> byteStatistics)
        {
            if (byteStatistics == null)
            {
                throw new ArgumentNullException();
            }

            var nodes = GenerateNodeListFromByteStatisticsList(byteStatistics);

            while (nodes.Count > 1)
            {
                nodes = nodes
                    .OrderBy(x => x.NodeInfo)
                    .ToList();

                var firstNode = nodes[0];
                var secondNode = nodes[1];

                var newNode = new Node
                {
                    LeftChild = firstNode,
                    RightChild = secondNode,
                    NodeInfo = new NodeInfo
                    {
                        NumericValue = firstNode.NodeInfo.NumericValue + secondNode.NodeInfo.NumericValue
                    }
                };
                
                firstNode.Parent = newNode;
                secondNode.Parent = newNode;

                nodes.Add(newNode);
                nodes.Remove(secondNode);
                nodes.Remove(firstNode);
            }

            return nodes.Count == 1
                ? nodes[0]
                : new Node();
        }

        public void SetPathFromNodeToParent(List<bool> path, Node node, Node parent, int maxNodesToClimb)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (path.Count != 0)
            {
                throw new ArgumentException($"{nameof(path)} should be empty");
            }

            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            if (parent == null)
            {
                throw new ArgumentNullException(nameof(parent));
            }

            if (node == parent)
            {
                throw new ArgumentException($"{nameof(node)} can't be {nameof(parent)}");
            }

            if (maxNodesToClimb < 1)
            {
                throw new ArgumentException($"{nameof(maxNodesToClimb)} must be at least 1");
            }

            var currentNode = node;
            var nodesClimbed = 0;
            while (true)
            {
                if (nodesClimbed == maxNodesToClimb)
                {
                    path.Clear();
                    throw new InvalidOperationException($"Path couldn't be found in {maxNodesToClimb} steps");
                }

                path.Add(currentNode.Parent.RightChild == currentNode);

                currentNode = currentNode.Parent;
                nodesClimbed++;

                if (currentNode == parent)
                {
                    break;
                }
            }

            path.Reverse();
        }

        private List<Node> GenerateNodeListFromByteStatisticsList(List<ByteStatistics> byteStatisticsList)
        {
            var nodes = new List<Node>();

            foreach (var characterStatistics in byteStatisticsList)
            {
                var node = new Node
                {
                    NodeInfo = new NodeInfo { NumericValue = characterStatistics.Apparitions, Code = characterStatistics.Byte }
                };

                nodes.Add(node);
            }

            return nodes;
        }
    }
}
