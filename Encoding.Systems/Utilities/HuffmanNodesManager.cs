using System;
using System.Collections.Generic;
using System.Linq;
using Encoding.Entities;
using Encoding.Systems.Interfaces.Utilities;

namespace Encoding.Systems.Utilities
{
    public class HuffmanNodesManager : IHuffmanNodesManager
    {
        public Node GetNodeFromCharacterStatistics(List<CharacterStatistics> characterStatistics)
        {
            if (characterStatistics == null)
            {
                throw new ArgumentNullException();
            }

            var nodes = GenerateNodeListFromCharacterStatisticsList(characterStatistics);

            while (nodes.Count > 1)
            {
                var firstMinimum = nodes.Min(x => x.NodeInfo);
                var firstNode = nodes.First(x => x.NodeInfo == firstMinimum);
                nodes.Remove(firstNode);

                var secondMinimum = nodes.Min(x => x.NodeInfo);
                var secondNode = nodes.First(x => x.NodeInfo == secondMinimum);
                nodes.Remove(secondNode);

                var newNode = new Node
                {
                    LeftChild = firstNode,
                    RightChild = secondNode,
                    NodeInfo = new NodeInfo
                    {
                        NumericValue = firstNode.NodeInfo.NumericValue + secondNode.NodeInfo.NumericValue
                    }
                };
                nodes.Add(newNode);

                firstNode.Parent = newNode;
                secondNode.Parent = newNode;
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

        private List<Node> GenerateNodeListFromCharacterStatisticsList(List<CharacterStatistics> characterStatisticsList)
        {
            var nodes = new List<Node>();

            foreach (var characterStatistics in characterStatisticsList)
            {
                var node = new Node
                {
                    NodeInfo = new NodeInfo { NumericValue = characterStatistics.Apparitions, Code = (byte)characterStatistics.Character }
                };

                nodes.Add(node);
            }

            return nodes;
        }
    }
}
