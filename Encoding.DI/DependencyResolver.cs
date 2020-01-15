using System.Diagnostics.CodeAnalysis;
using Autofac;
using Encoding.Huffman;
using Encoding.Huffman.Interfaces;
using Encoding.Huffman.Interfaces.Utilities;
using Encoding.Huffman.Utilities;
using Encoding.ImagePrediction;
using Encoding.ImagePrediction.Interfaces;
using Encoding.ImagePrediction.Interfaces.Utilities;
using Encoding.ImagePrediction.Utilities;
using Encoding.Jpeg;
using Encoding.Jpeg.Interfaces;
using Encoding.Jpeg.Interfaces.Mappers;
using Encoding.Jpeg.Interfaces.Utilities;
using Encoding.Jpeg.Mappers;
using Encoding.Jpeg.Utilities;
using Encoding.Lz77;
using Encoding.Lz77.Interfaces;
using Encoding.Lz77.Interfaces.Utilities;
using Encoding.Lz77.Utilities;
using Encoding.LzW;
using Encoding.LzW.Interfaces;
using Encoding.Rsa;
using Encoding.Rsa.Interfaces;

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
            containerBuilder.RegisterType<HuffmanEncoder>().As<IHuffmanEncoder>();
            containerBuilder.RegisterType<HuffmanDecoder>().As<IHuffmanDecoder>();

            containerBuilder.RegisterType<LzWEncoder>().As<ILzWEncoder>();
            containerBuilder.RegisterType<LzWDecoder>().As<ILzWDecoder>();

            containerBuilder.RegisterType<Lz77BufferManager>().As<ILz77BufferManager>();
            containerBuilder.RegisterType<Lz77TokenExtractor>().As<ILz77TokenExtractor>();
            containerBuilder.RegisterType<Lz77TokenWriter>().As<ILz77TokenWriter>();
            containerBuilder.RegisterType<Lz77Encoder>().As<ILz77Encoder>();
            containerBuilder.RegisterType<Lz77Decoder>().As<ILz77Decoder>();

            containerBuilder.RegisterType<RsaEncrypter>().As<IRsaEncrypter>();
            containerBuilder.RegisterType<RsaDecrypter>().As<IRsaDecrypter>();

            containerBuilder.RegisterType<ErrorMatrixWriter>().As<IErrorMatrixWriter>();
            containerBuilder.RegisterType<ErrorMatrixReader>().As<IErrorMatrixReader>();
            containerBuilder.RegisterType<ImagePredictionEncoder>().As<IImagePredictionEncoder>();
            containerBuilder.RegisterType<ImagePredictionDecoder>().As<IImagePredictionDecoder>();

            containerBuilder.RegisterType<DownSampler411>().As<IDownSampler>();
            containerBuilder.RegisterType<PixelMapper>().As<IPixelMapper>();
            containerBuilder.RegisterType<JpegEncoder>().As<IJpegEncoder>();

            container = containerBuilder.Build();
        }

        public T GetObject<T>()
        {
            return container.Resolve<T>();
        }
    }
}
