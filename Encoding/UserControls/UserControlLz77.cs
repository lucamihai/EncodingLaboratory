using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Encoding.DI;
using Encoding.FileOperations;
using Encoding.Lz77;
using Encoding.Lz77.Entities;
using Encoding.Lz77.Interfaces;
using Buffer = Encoding.FileOperations.Buffer;

namespace Encoding.UserControls
{
    [ExcludeFromCodeCoverage]
    public partial class UserControlLz77 : UserControl
    {
        private readonly Lz77Encoder lz77Encoder;
        private readonly Lz77Decoder lz77Decoder;

        public UserControlLz77()
        {
            InitializeComponent();

            var dependencyResolver = new DependencyResolver();
            lz77Encoder = (Lz77Encoder)dependencyResolver.GetObject<ILz77Encoder>();
            lz77Decoder = (Lz77Decoder)dependencyResolver.GetObject<ILz77Decoder>();
        }

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Browse files",

                CheckFileExists = true,
                CheckPathExists = true,

                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFilePathSource.Text = openFileDialog.FileName;
            }

            openFileDialog.Dispose();
            UpdateButtonsEnabledProperty();
        }

        private void buttonSelectEncodedFile_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Browse Lz77 encoded files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "lz77",
                Filter = "Lz77 encoded files (*.lz77)|*.lz77",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFilePathEncodedFile.Text = openFileDialog.FileName;
            }

            openFileDialog.Dispose();
            UpdateButtonsEnabledProperty();
        }

        private void UpdateButtonsEnabledProperty()
        {
            buttonEncode.Enabled = !string.IsNullOrWhiteSpace(textBoxFilePathSource.Text);
            buttonDecode.Enabled = !string.IsNullOrWhiteSpace(textBoxFilePathEncodedFile.Text);
        }

        private void buttonEncode_Click(object sender, EventArgs e)
        {
            var bitsForOffset = (int)numericUpDownOffsetBits.Value;
            var bitsForLength = (int)numericUpDownLengthBits.Value;
            var destinationFilePath = $"{textBoxFilePathSource.Text}.o[{bitsForOffset}]l[{bitsForLength}].lz77";

            using (var fileReader = new FileReader(textBoxFilePathSource.Text, new Buffer()))
            {
                using (var fileWriter = new FileWriter(destinationFilePath, new Buffer()))
                {
                    lz77Encoder.EncodeFile(fileReader, fileWriter, bitsForOffset, bitsForLength);
                }
            }

            if (checkBoxShowTokensEncoding.Checked)
            {
                DisplayTokens(lz77Encoder.TokensFromPreviousRun);
            }
        }

        private void buttonDecode_Click(object sender, EventArgs e)
        {
            var fileInfoEncodedFile = new FileInfo(textBoxFilePathEncodedFile.Text);

            if (!fileInfoEncodedFile.Exists)
            {
                throw new InvalidOperationException($"Lz77 decoding error: file '{fileInfoEncodedFile.FullName}' does not exist");
            }

            var encodedFileExtension = GetExtensionOfEncodedFile(fileInfoEncodedFile);
            var decodedFileDestinationPath = $"{fileInfoEncodedFile.FullName}.{encodedFileExtension}";

            using (var fileReader = new FileReader(textBoxFilePathEncodedFile.Text, new Buffer()))
            {
                using (var fileWriter = new FileWriter(decodedFileDestinationPath, new Buffer()))
                {
                    lz77Decoder.DecodeFile(fileReader, fileWriter);
                }
            }

            if (checkBoxShowTokensDecoding.Checked)
            {
                DisplayTokens(lz77Decoder.TokensFromPreviousRun);
            }
        }

        private void DisplayTokens(List<Lz77Token> tokens)
        {
            var stringBuilder = new StringBuilder();

            for (int currentIndex = 0; currentIndex < tokens.Count; currentIndex++)
            {
                stringBuilder.Append(currentIndex + 1);
                stringBuilder.Append(". ");
                stringBuilder.Append(tokens[currentIndex]);
                stringBuilder.Append(Environment.NewLine);
            }

            textBoxTokens.Text = stringBuilder.ToString();
        }

        private string GetExtensionOfEncodedFile(FileInfo fileInfoEncodedFile)
        {
            var splitName = fileInfoEncodedFile.Name.Split('.');
            var nameWithoutLzWEncodedFileExtension = splitName[splitName.Length - 3];

            return nameWithoutLzWEncodedFileExtension
                .Substring(nameWithoutLzWEncodedFileExtension.LastIndexOf('.') + 1);
        }
    }
}
