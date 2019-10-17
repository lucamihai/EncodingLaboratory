using System.Diagnostics.CodeAnalysis;

namespace Encoding.Entities
{
    [ExcludeFromCodeCoverage]
    public class Node
    {
        public NodeInfo NodeInfo { get; set; }

        public Node Parent { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }

        public bool IsParent => LeftChild != null || RightChild != null;
    }
}
