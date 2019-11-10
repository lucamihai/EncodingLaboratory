﻿using System.Collections.Generic;
using Encoding.Entities;

namespace Encoding.Tests.Common
{
    public static class ConstantsEncodingSystems
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

        public static Node ExpectedNodeForText1()
        {
            var root = new Node
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

            SetParentPropertiesForNodesUnderThisNode(root);

            return root;
        }

        public const int NumberOfLeafs1 = 9;

        private static void SetParentPropertiesForNodesUnderThisNode(Node node)
        {
            if (node.LeftChild != null)
            {
                node.LeftChild.Parent = node;
                SetParentPropertiesForNodesUnderThisNode(node.LeftChild);
            }

            if (node.RightChild != null)
            {
                node.RightChild.Parent = node;
                SetParentPropertiesForNodesUnderThisNode(node.RightChild);
            }
        }

        public static List<EncodedByte> EncodedBytes1()
        {
            var encodedBytes = new List<EncodedByte>();

            encodedBytes.Add(new EncodedByte { Byte = (byte)'a' });
            encodedBytes[0].EncodingBits.Add(false);
            encodedBytes[0].EncodingBits.Add(false);

            encodedBytes.Add(new EncodedByte { Byte = (byte)'n' });
            encodedBytes[1].EncodingBits.Add(false);
            encodedBytes[1].EncodingBits.Add(true);
            encodedBytes[1].EncodingBits.Add(false);

            encodedBytes.Add(new EncodedByte { Byte = (byte)' ' });
            encodedBytes[2].EncodingBits.Add(false);
            encodedBytes[2].EncodingBits.Add(true);
            encodedBytes[2].EncodingBits.Add(true);

            encodedBytes.Add(new EncodedByte { Byte = (byte)'p' });
            encodedBytes[3].EncodingBits.Add(true);
            encodedBytes[3].EncodingBits.Add(false);
            encodedBytes[3].EncodingBits.Add(false);

            encodedBytes.Add(new EncodedByte { Byte = (byte)'s' });
            encodedBytes[4].EncodingBits.Add(true);
            encodedBytes[4].EncodingBits.Add(false);
            encodedBytes[4].EncodingBits.Add(true);

            encodedBytes.Add(new EncodedByte { Byte = (byte)'A' });
            encodedBytes[5].EncodingBits.Add(true);
            encodedBytes[5].EncodingBits.Add(true);
            encodedBytes[5].EncodingBits.Add(false);
            encodedBytes[5].EncodingBits.Add(false);

            encodedBytes.Add(new EncodedByte { Byte = (byte)'e' });
            encodedBytes[6].EncodingBits.Add(true);
            encodedBytes[6].EncodingBits.Add(true);
            encodedBytes[6].EncodingBits.Add(false);
            encodedBytes[6].EncodingBits.Add(true);

            encodedBytes.Add(new EncodedByte { Byte = (byte)'h' });
            encodedBytes[7].EncodingBits.Add(true);
            encodedBytes[7].EncodingBits.Add(true);
            encodedBytes[7].EncodingBits.Add(true);
            encodedBytes[7].EncodingBits.Add(false);

            encodedBytes.Add(new EncodedByte { Byte = (byte)'l' });
            encodedBytes[8].EncodingBits.Add(true);
            encodedBytes[8].EncodingBits.Add(true);
            encodedBytes[8].EncodingBits.Add(true);
            encodedBytes[8].EncodingBits.Add(true);

            return encodedBytes;
        }
    }
}