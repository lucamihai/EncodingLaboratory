using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Encoding.Entities.UnitTests
{
    [ExcludeFromCodeCoverage]
    internal static class Constants
    {
        public static Node Node1 => new Node
        {
            NodeInfo = new NodeInfo { NumericValue = 14 },
            LeftChild = new Node
            {
                NodeInfo = new NodeInfo { NumericValue = 6 },
                LeftChild = new Node
                {
                    NodeInfo = new NodeInfo { NumericValue = 3, Code = (byte)'a' }
                },
                RightChild = new Node
                {
                    NodeInfo = new NodeInfo { NumericValue = 3 },
                    LeftChild = new Node
                    {
                        NodeInfo = new NodeInfo { NumericValue = 1, Code = (byte)'n' }
                    },
                    RightChild = new Node
                    {
                        NodeInfo = new NodeInfo { NumericValue = 2, Code = (byte)' ' }
                    }
                },


            },
            RightChild = new Node
            {
                NodeInfo = new NodeInfo { NumericValue = 8 },
                LeftChild = new Node
                {
                    NodeInfo = new NodeInfo { NumericValue = 4 },
                    LeftChild = new Node
                    {
                        NodeInfo = new NodeInfo { NumericValue = 2, Code = (byte)'p' }
                    },
                    RightChild = new Node
                    {
                        NodeInfo = new NodeInfo { NumericValue = 2, Code = (byte)'s' }
                    }
                },
                RightChild = new Node
                {
                    NodeInfo = new NodeInfo { NumericValue = 4 },
                    LeftChild = new Node
                    {
                        NodeInfo = new NodeInfo { NumericValue = 2 },
                        LeftChild = new Node
                        {
                            NodeInfo = new NodeInfo { NumericValue = 1, Code = (byte)'A' }
                        },
                        RightChild = new Node
                        {
                            NodeInfo = new NodeInfo { NumericValue = 1, Code = (byte)'e' }
                        }
                    },
                    RightChild = new Node
                    {
                        NodeInfo = new NodeInfo { NumericValue = 2 },
                        LeftChild = new Node
                        {
                            NodeInfo = new NodeInfo { NumericValue = 1, Code = (byte)'h' }
                        },
                        RightChild = new Node
                        {
                            NodeInfo = new NodeInfo { NumericValue = 1, Code = (byte)'l' }
                        }
                    }
                },
            }
        };

        public static List<Node> NodesInPreOrder1 => new List<Node>
        {
            Node1,

            Node1.LeftChild,
            Node1.LeftChild.LeftChild,
            Node1.LeftChild.RightChild,
            Node1.LeftChild.RightChild.LeftChild,
            Node1.LeftChild.RightChild.RightChild,

            Node1.RightChild,
            Node1.RightChild.LeftChild,
            Node1.RightChild.LeftChild.LeftChild,
            Node1.RightChild.LeftChild.RightChild,
            Node1.RightChild.RightChild,
            Node1.RightChild.RightChild.LeftChild,
            Node1.RightChild.RightChild.LeftChild.LeftChild,
            Node1.RightChild.RightChild.LeftChild.RightChild,
            Node1.RightChild.RightChild.RightChild,
            Node1.RightChild.RightChild.RightChild.LeftChild,
            Node1.RightChild.RightChild.RightChild.RightChild,
        };
    }
}
