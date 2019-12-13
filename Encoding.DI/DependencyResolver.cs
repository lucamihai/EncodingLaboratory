using System.Diagnostics.CodeAnalysis;
using Autofac;
using Encoding.Huffman;
using Encoding.Huffman.Interfaces;
using Encoding.Huffman.Interfaces.Utilities;
using Encoding.Huffman.Utilities;
using Encoding.Lz77;
using Encoding.Lz77.Interfaces;
using Encoding.Lz77.Interfaces.Utilities;
using Encoding.Lz77.Utilities;
using Encoding.LzW;
using Encoding.LzW.Interfaces;

namespace Encoding.DI
{
    [ExcludeFromCodeCoverage]
    public class DependencyResolver
    {
        private readonly IContainer container;

        public DependencyResolver()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<StatisticsGenerator>().As<IStatisticsGenerator>();
            containerBuilder.RegisterType<HuffmanHeaderWriter>().As<IHuffmanHeaderWriter>();
            containerBuilder.RegisterType<HuffmanHeaderReader>().As<IHuffmanHeaderReader>();
            containerBuilder.RegisterType<HuffmanEncodedBytesManager>().As<IHuffmanEncodedBytesManager>();
            containerBuilder.RegisterType<HuffmanNodesManager>().As<IHuffmanNodesManager>();
            containerBuilder.RegisterType<HuffmanEncoder>().As<IHuffmanEncoder>().PropertiesAutowired();
            containerBuilder.RegisterType<HuffmanDecoder>().As<IHuffmanDecoder>().PropertiesAutowired();

            containerBuilder.RegisterType<LzWEncoder>().As<ILzWEncoder>().PropertiesAutowired();
            containerBuilder.RegisterType<LzWDecoder>().As<ILzWDecoder>().PropertiesAutowired();

            containerBuilder.RegisterType<Lz77BufferManager>().As<ILz77BufferManager>();
            containerBuilder.RegisterType<Lz77TokenExtractor>().As<ILz77TokenExtractor>();
            containerBuilder.RegisterType<Lz77TokenWriter>().As<ILz77TokenWriter>();
            containerBuilder.RegisterType<Lz77Encoder>().As<ILz77Encoder>().PropertiesAutowired();
            containerBuilder.RegisterType<Lz77Decoder>().As<ILz77Decoder>().PropertiesAutowired();

            container = containerBuilder.Build();
        }

        public T GetObject<T>()
        {
            return container.Resolve<T>();
        }
    }
}
