using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Encoding.Entities;

namespace Encoding.Systems.UnitTests
{
    [ExcludeFromCodeCoverage]
    internal static class Constants
    {
        public const string Text1 = "Ana has apples";
        public static List<CharacterStatistics> TextCharacterStatistics1 => new List<CharacterStatistics>
        {
            new CharacterStatistics
            {
                Character = ' ',
                Apparitions = 2
            },
            new CharacterStatistics
            {
                Character = 'A',
                Apparitions = 1
            },
            new CharacterStatistics
            {
                Character = 'a',
                Apparitions = 3
            },
            new CharacterStatistics
            {
                Character = 'e',
                Apparitions = 1
            },
            new CharacterStatistics
            {
                Character = 'h',
                Apparitions = 1
            },
            new CharacterStatistics
            {
                Character = 'l',
                Apparitions = 1
            },
            new CharacterStatistics
            {
                Character = 'n',
                Apparitions = 1
            },
            new CharacterStatistics
            {
                Character = 'p',
                Apparitions = 2
            },
            new CharacterStatistics
            {
                Character = 's',
                Apparitions = 2
            }
        };

        public static Node ExpectedNodeForText1 => new Node
        {
            NodeInfo = new NodeInfo {NumericValue = 14},
            LeftChild = new Node
            {
                NodeInfo = new NodeInfo {NumericValue = 6},
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
                NodeInfo = new NodeInfo {NumericValue = 8},
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
                        NodeInfo = new NodeInfo { NumericValue = 2},
                        LeftChild = new Node
                        {
                            NodeInfo = new NodeInfo { NumericValue = 1, Code = (byte)'A'}
                        },
                        RightChild = new Node
                        {
                            NodeInfo = new NodeInfo { NumericValue = 1, Code = (byte)'e' }
                        }
                    },
                    RightChild = new Node
                    {
                        NodeInfo = new NodeInfo { NumericValue = 2},
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
    }
}
