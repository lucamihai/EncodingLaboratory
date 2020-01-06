using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Encoding.DI;
using Encoding.FileOperations;
using Encoding.ImagePrediction;
using Encoding.ImagePrediction.Interfaces;
using Encoding.ImagePrediction.Interfaces.Predictors;
using Encoding.ImagePrediction.Predictors;
using Buffer = Encoding.FileOperations.Buffer;

namespace Encoding.UserControls
{
    public partial class UserControlImagePrediction : UserControl
    {
        private readonly ImagePredictionEncoder imagePredictionEncoder;
        private readonly ImagePredictionDecoder imagePredictionDecoder;
        private string filePathOriginalImage;
        private string filePathPredictedImage;
        private string filePathDecodedImage;

        public UserControlImagePrediction()
        {
            InitializeComponent();

            var dependencyResolver = new DependencyResolver();
            imagePredictionEncoder = (ImagePredictionEncoder)dependencyResolver.GetObject<IImagePredictionEncoder>();
            imagePredictionDecoder = (ImagePredictionDecoder)dependencyResolver.GetObject<IImagePredictionDecoder>();

            UpdateButtonsEnabledProperty();
        }

        private void LoadImageClick(object sender, EventArgs e)
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
            UpdateButtonsEnabledProperty();
        }

        private void PredictClick(object sender, EventArgs e)
        {
            var imagePredictorToUse = DetermineImagePredictor();
            var filePathEncodedImage = $"{filePathOriginalImage}.pre";

            if (File.Exists(filePathEncodedImage))
            {
                File.Delete(filePathEncodedImage);
            }

            using (var fileReader = new FileReader(filePathOriginalImage, new Buffer()))
            {
                using (var fileWriter = new FileWriter($"{filePathOriginalImage}.pre", new Buffer()))
                {
                    imagePredictionEncoder.EncodeImage(fileReader, fileWriter, imagePredictorToUse);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void ShowErrorMatrixClick(object sender, EventArgs e)
        {
            var scale = numericUpDownErrorMatrixScale.Value;
            var bitmapErrorMatrix = new Bitmap(256, 256);

            for (int row = 0; row < 256; row++)
            {
                for (int column = 0; column < 256; column++)
                {
                    var code = Math.Abs(128 + imagePredictionEncoder.ErrorMatrix[row, column] * scale);
                    code = GetByteFromDecimal(code);
                    var codeByte = (byte) code;
                    bitmapErrorMatrix.SetPixel(row, column, Color.FromArgb(codeByte, codeByte, codeByte));
                }
            }

            pictureBoxErrorMatrix.Image = bitmapErrorMatrix;
        }

        private void LoadEncodedImageClick(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Browse Predicted files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "pre",
                Filter = "Predicted (*.pre)|*.pre",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePathPredictedImage = openFileDialog.FileName;
            }

            openFileDialog.Dispose();
            UpdateButtonsEnabledProperty();
        }

        private void DecodeClick(object sender, EventArgs e)
        {
            filePathDecodedImage = $"{filePathDecodedImage}.bmp";
            if (File.Exists(filePathDecodedImage))
            {
                File.Delete(filePathDecodedImage);
            }

            using (var fileReader = new FileReader(filePathPredictedImage, new Buffer()))
            {
                using (var fileWriter = new FileWriter(filePathDecodedImage, new Buffer()))
                {
                    imagePredictionDecoder.DecodeImage(fileReader, fileWriter);
                }
            }

            using (var fileStream = new FileStream(filePathDecodedImage, FileMode.Open))
            {
                var bmp = new Bitmap(fileStream);
                pictureBoxDecodedImage.Image = bmp;
            }
        }

        private void SaveDecodedClick(object sender, EventArgs e)
        {

        }

        private void buttonShowHistogram_Click(object sender, EventArgs e)
        {
            pictureBoxHistogram.Image = new Bitmap(256, 256);
            var histogramImage = pictureBoxHistogram.Image;

            using (var graphics = Graphics.FromImage(histogramImage))
            {
                var pen = new Pen(Color.Black, 1);
                var frequencies = GetFrequencies();

                for (int index = -256; index < 256; index++)
                {
                    if (frequencies[index] < 1)
                    {
                        continue;
                    }

                    if (frequencies[index] > 0)
                    {

                    }

                    var x = index + 256;
                    var p1 = new Point(x, histogramImage.Height - 1);
                    var p2 = new Point(x, histogramImage.Height - 1 - frequencies[index]);

                    graphics.DrawLine(pen, p1, p2);
                }
            }

            pictureBoxHistogram.Refresh();
            pictureBoxHistogram.Invalidate();
        }

        private void UpdateButtonsEnabledProperty()
        {

        }

        private IImagePredictor DetermineImagePredictor()
        {
            if (radioButtonImagePredictor0.Checked)
            {
                return new ImagePredictor0();
            }

            if (radioButtonImagePredictor1.Checked)
            {
                return new ImagePredictor1();
            }

            if (radioButtonImagePredictor2.Checked)
            {
                return new ImagePredictor2();
            }

            if (radioButtonImagePredictor3.Checked)
            {
                return new ImagePredictor3();
            }

            if (radioButtonImagePredictor4.Checked)
            {
                return new ImagePredictor4();
            }

            if (radioButtonImagePredictor5.Checked)
            {
                return new ImagePredictor5();
            }

            if (radioButtonImagePredictor6.Checked)
            {
                return new ImagePredictor6();
            }

            if (radioButtonImagePredictor7.Checked)
            {
                return new ImagePredictor7();
            }

            if (radioButtonImagePredictor8.Checked)
            {
                return new ImagePredictor8();
            }

            if (radioButtonImagePredictor9.Checked)
            {
                return new ImagePredictor9();
            }

            throw new InvalidOperationException();
        }

        private byte GetByteFromDecimal(decimal value)
        {
            if (value < 0)
            {
                return 0;
            }

            if (value > 255)
            {
                return 255;
            }

            return (byte)value;
        }

        private Dictionary<int, int> GetFrequencies()
        {
            var frequencies = new Dictionary<int, int>();

            for (int i = -256; i < 256; i++)
            {
                frequencies.Add(i, 0);
            }

            if (radioButtonHistogramOriginal.Checked)
            {
                var bitmap = (Bitmap) pictureBoxOriginalImage.Image;

                for (int row = 0; row < 256; row++)
                {
                    for (int column = 0; column < 256; column++)
                    {
                        var code = bitmap.GetPixel(row, column).R;
                        frequencies[code]++;
                    }
                }
            }

            if (radioButtonHistogramErrorMatrix.Checked)
            {
                for (int row = 0; row < 256; row++)
                {
                    for (int column = 0; column < 256; column++)
                    {
                        var code = imagePredictionEncoder.ErrorMatrix[row, column];
                        frequencies[code]++;
                    }
                }
            }

            if (radioButtonHistogramDecoded.Checked)
            {
                var bitmap = (Bitmap)pictureBoxDecodedImage.Image;

                for (int row = 0; row < 256; row++)
                {
                    for (int column = 0; column < 256; column++)
                    {
                        var code = bitmap.GetPixel(row, column).R;
                        frequencies[code]++;
                    }
                }
            }

            return frequencies;
        }
    }
}
