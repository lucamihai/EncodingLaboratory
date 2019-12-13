using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Encoding.DI;
using Encoding.FileOperations;
using Encoding.Huffman;
using Encoding.Huffman.Entities;
using Encoding.Huffman.Interfaces;
using Buffer = Encoding.FileOperations.Buffer;

namespace Encoding.UserControls
{
    [ExcludeFromCodeCoverage]
    public partial class UserControlHuffman : UserControl
    {
        private readonly HuffmanEncoder huffmanEncoder;
        private readonly HuffmanDecoder huffmanDecoder;

        public UserControlHuffman()
        {
            InitializeComponent();

            var dependencyResolver = new DependencyResolver();
            huffmanEncoder = (HuffmanEncoder)dependencyResolver.GetObject<IHuffmanEncoder>();
            huffmanDecoder = (HuffmanDecoder)dependencyResolver.GetObject<IHuffmanDecoder>();

            textBoxCodes.Font = new Font(FontFamily.GenericMonospace, textBoxCodes.Font.Size);

            UpdateButtonsEnabledProperty();
        }

        private void ClickEncode(object sender, EventArgs e)
        {
            string sourceFilePath;
            string destinationFilePath;

            if (radioButtonEncodeContentsFromFile.Checked)
            {
                sourceFilePath = textBoxFilePathSource.Text;
                destinationFilePath = $"{sourceFilePath}.hs";
            }
            else
            {
                if (radioButtonEncodeContentsFromTextBox.Checked)
                {
                    sourceFilePath = $"{Environment.CurrentDirectory}\\textFormTextBox.txt";
                    destinationFilePath = $"{sourceFilePath}.hs";

                    File.WriteAllText(sourceFilePath, textBoxContents.Text);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }

            using (var fileReader = new FileReader(sourceFilePath, new Buffer()))
            {
                using (var fileWriter = new FileWriter(destinationFilePath, new Buffer()))
                {
                    huffmanEncoder.EncodeFile(fileReader, fileWriter);
                    fileWriter.Buffer.Flush();
                }
            }

            if (checkBoxShowCodesFromEncoding.Checked)
            {
                DisplayEncodedBytes(huffmanEncoder.EncodedBytesFromPreviousRun);
            }
        }

        private void ClickDecode(object sender, EventArgs e)
        {
            var fileInfoEncodedFile = new FileInfo(textBoxFilePathEncodedFile.Text);

            if (!fileInfoEncodedFile.Exists)
            {
                throw new InvalidOperationException($"Huffman decoding error: file '{fileInfoEncodedFile.FullName}' does not exist");
            }

            var encodedFileExtension = GetExtensionOfEncodedFile(fileInfoEncodedFile);
            var decodedFileDestinationPath = $"{fileInfoEncodedFile.FullName}.{DateTime.Now:dd-MM-yyyy-hh-mm}.{encodedFileExtension}";

            using (var fileReader = new FileReader(textBoxFilePathEncodedFile.Text, new Buffer()))
            {
                using (var fileWriter = new FileWriter(decodedFileDestinationPath, new Buffer()))
                {
                    huffmanDecoder.DecodeFile(fileReader, fileWriter);
                }
            }

            if (checkBoxShowCodesFromDecoding.Checked)
            {
                DisplayEncodedBytes(huffmanDecoder.EncodedBytesFromPreviousRun);
            }
        }

        private string GetExtensionOfEncodedFile(FileInfo fileInfoEncodedFile)
        {
            var indexOfLastDot = fileInfoEncodedFile.Name.LastIndexOf('.');
            var nameWithoutHuffmanEncodedFileExtension = fileInfoEncodedFile.Name.Substring(0, indexOfLastDot);

            return nameWithoutHuffmanEncodedFileExtension
                .Substring(nameWithoutHuffmanEncodedFileExtension.LastIndexOf('.') + 1);
        }

        private void SelectFileClick(object sender, EventArgs e)
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

        private void ClickSelectEncodedFile(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Browse Huffman encoded files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "hs",
                Filter = "Huffman encoded files (*.hs)|*.hs",
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

        private void CheckedChangedEncodeContentsFromFile(object sender, EventArgs e)
        {
            UpdateButtonsEnabledProperty();
        }

        private void CheckedChangedEncodeContentsFromTextBox(object sender, EventArgs e)
        {
            UpdateButtonsEnabledProperty();
        }

        private void UpdateButtonsEnabledProperty()
        {
            //buttonEncode.Enabled = (radioButtonEncodeContentsFromFile.Checked && !string.IsNullOrWhiteSpace(textBoxFilePathSource.Text))
            //    || (radioButtonEncodeContentsFromTextBox.Checked && !string.IsNullOrWhiteSpace(textBoxContents.Text));

            buttonEncode.Enabled = true;

            buttonDecode.Enabled = !string.IsNullOrWhiteSpace(textBoxFilePathEncodedFile.Text);
        }

        private void DisplayEncodedBytes(List<EncodedByte> encodedBytes)
        {
            var stringBuilder = new StringBuilder();

            foreach (var encodedByte in encodedBytes.OrderBy(x => x.Byte))
            {
                stringBuilder.Append(encodedByte);
                stringBuilder.Append(Environment.NewLine);
            }

            textBoxCodes.Text = stringBuilder.ToString();
        }
    }
}
