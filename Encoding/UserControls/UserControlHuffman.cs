using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Windows.Forms;
using Encoding.FileOperations;
using Encoding.Systems.Decoders;
using Encoding.Systems.Encoders;
using Encoding.Systems.Utilities;
using Buffer = Encoding.FileOperations.Buffer;

namespace Encoding.UserControls
{
    [ExcludeFromCodeCoverage]
    public partial class UserControlHuffman : UserControl
    {
        private readonly HuffmanEncoder huffmanEncoder;
        private HuffmanDecoder huffmanDecoder;

        public UserControlHuffman()
        {
            InitializeComponent();

            // TODO: Find a more 'pleasant' way of initiating objects (maybe consider using AutoFac)
            huffmanEncoder = new HuffmanEncoder(new TextAnalyzer(), new HuffmanEncodedBytesManager(new HuffmanNodesManager()), new HuffmanHeaderWriter());
            huffmanDecoder = new HuffmanDecoder(new HuffmanHeaderReader(), new HuffmanEncodedBytesManager(new HuffmanNodesManager()));

            UpdateButtonsEnabledProperty();
        }

        private void buttonEncode_Click(object sender, EventArgs e)
        {
            string destinationFilePath;
            string textToEncode;

            if (radioButtonEncodeContentsFromFile.Checked)
            {
                var sourceFilePath = textBoxFilePathSource.Text;
                textToEncode = File.ReadAllText(sourceFilePath);
                destinationFilePath = $"{sourceFilePath}.hs";
            }
            else
            {
                if (radioButtonEncodeContentsFromTextBox.Checked)
                {
                    textToEncode = textBoxContents.Text;
                    destinationFilePath = "";
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }

            using (var fileWriter = new FileWriter(destinationFilePath, new Buffer()))
            {
                huffmanEncoder.EncodeTextToFile(textToEncode, fileWriter);
            }
            
        }

        private void buttonDecode_Click(object sender, EventArgs e)
        {
            var fileInfoEncodedFile = new FileInfo(textBoxFilePathEncodedFile.Text);

            if (!fileInfoEncodedFile.Exists)
            {
                throw new InvalidOperationException($"Huffman decoding error: file '{fileInfoEncodedFile.FullName}' does not exist");
            }

            string decodedText;
            using (var fileReader = new FileReader(fileInfoEncodedFile.FullName, new Buffer()))
            {
                decodedText = huffmanDecoder.GetDecodedText(fileReader);
            }

            var encodedFileExtension = GetExtensionOfEncodedFile(fileInfoEncodedFile);
            var decodedFileDestinationPath = $"{fileInfoEncodedFile.FullName}.{DateTime.Now:dd-MM-yyyy-hh-mm}.{encodedFileExtension}";

            File.WriteAllText(decodedFileDestinationPath, decodedText);
        }

        private string GetExtensionOfEncodedFile(FileInfo fileInfoEncodedFile)
        {
            var indexOfLastDot = fileInfoEncodedFile.Name.LastIndexOf('.');
            var nameWithoutHuffmanEncodedFileExtension = fileInfoEncodedFile.Name.Substring(0, indexOfLastDot);

            return nameWithoutHuffmanEncodedFileExtension
                .Substring(nameWithoutHuffmanEncodedFileExtension.LastIndexOf('.') + 1);
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
                Title = "Browse Json files",

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

        private void radioButtonEncodeContentsFromFile_CheckedChanged(object sender, EventArgs e)
        {
            UpdateButtonsEnabledProperty();
        }

        private void radioButtonEncodeContentsFromTextBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateButtonsEnabledProperty();
        }

        private void UpdateButtonsEnabledProperty()
        {
            buttonEncode.Enabled = (radioButtonEncodeContentsFromFile.Checked && !string.IsNullOrWhiteSpace(textBoxFilePathSource.Text))
                || (radioButtonEncodeContentsFromTextBox.Checked && !string.IsNullOrWhiteSpace(textBoxContents.Text));

            buttonDecode.Enabled = !string.IsNullOrWhiteSpace(textBoxFilePathEncodedFile.Text);
        }
    }
}
