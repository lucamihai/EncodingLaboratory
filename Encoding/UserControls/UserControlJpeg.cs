using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encoding.DI;
using Encoding.FileOperations;
using Encoding.Jpeg;
using Encoding.Jpeg.Enums;
using Encoding.Jpeg.Interfaces;
using Encoding.Jpeg.Utilities;
using Buffer = Encoding.FileOperations.Buffer;

namespace Encoding.UserControls
{
    public partial class UserControlJpeg : UserControl
    {
        private string filePathOriginalImage;
        private JpegEncoder jpegEncoder;

        public UserControlJpeg()
        {
            InitializeComponent();

            var dependencyResolver = new DependencyResolver();
            jpegEncoder = (JpegEncoder) dependencyResolver.GetObject<IJpegEncoder>();
        }

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Browse Bitmap files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "bmp",
                Filter = "Bitmap (*.bmp)|*.bmp",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePathOriginalImage = openFileDialog.FileName;

                using (var fileStream = new FileStream(filePathOriginalImage, FileMode.Open))
                {
                    var bmp = new Bitmap(fileStream);
                    pictureBoxOriginalImage.Image = bmp;
                }
            }

            openFileDialog.Dispose();
        }

        private void buttonPredict_Click(object sender, EventArgs e)
        {
            using (var fileReader = new FileReader(filePathOriginalImage, new Buffer()))
            {
                jpegEncoder.EncodeImage(fileReader, new DownSampler411());
            }
        }

        private void buttonLast4Steps_Click(object sender, EventArgs e)
        {
            QuantizeMethod quantizeMethod = QuantizeMethod.Method2;
            int quantizeParameter = 0;

            if (radioButtonMethod2.Checked)
            {
                quantizeMethod = QuantizeMethod.Method2;
                quantizeParameter = (int)numericUpDownR.Value;
            }

            if (radioButtonJpegQ.Checked)
            {
                quantizeMethod = QuantizeMethod.JpegQuality;
                quantizeParameter = (int)numericUpDownJpeg.Value;
            }

            jpegEncoder.DecodeImage(new DownSampler411(), quantizeMethod, quantizeParameter);
            pictureBoxDecodedImage.Image = jpegEncoder.ReconstructedImage;
        }
    }
}
