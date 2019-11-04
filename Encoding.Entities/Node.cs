using System.Collections.Generic;

namespace Encoding.Entities
{
    public class Node
    {
        public NodeInfo NodeInfo { get; set; }

        public Node Parent { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }

        public bool IsParent => LeftChild != null || RightChild != null;

        public List<Node> NodesInPreOrder
        {
            get
            {
                var nodes = new List<Node>();
                AddNodesToListInPreOrder(this, nodes);

                return nodes;
            }
        }

        private void AddNodesToListInPreOrder(Node currentNode, List<Node> nodesList)
        {
            nodesList.Add(currentNode);

            if (currentNode.LeftChild != null)
            {
                AddNodesToListInPreOrder(currentNode.LeftChild, nodesList);
            }

            if (currentNode.RightChild != null)
            {
                AddNodesToListInPreOrder(currentNode.RightChild, nodesList);
            }
        }
    }
}
