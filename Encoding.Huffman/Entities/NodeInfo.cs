using System;

namespace Encoding.Huffman.Entities
{
    public class NodeInfo : IComparable
    {
        public byte? Code { get; set; }
        public uint NumericValue { get; set; }

        public int CompareTo(object obj)
        {
            if (!(obj is NodeInfo otherNodeInfo))
            {
                return 1;
            }

            var numericValueComparison = this.NumericValue.CompareTo(otherNodeInfo.NumericValue);

            if (numericValueComparison == 0)
            {
                if (this.Code.HasValue && otherNodeInfo.Code.HasValue)
                {
                    return this.Code.Value.CompareTo(otherNodeInfo.Code.Value);
                }
            }

            return numericValueComparison;
        }
    }
}
