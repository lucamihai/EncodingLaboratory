using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Encoding.DI;
using Encoding.FileOperations;
using Encoding.LzW;
using Encoding.LzW.Interfaces;
using Encoding.LzW.Options;

namespace Encoding.UserControls
{
    [ExcludeFromCodeCoverage]
    public partial class UserControlLzW : UserControl
    {
        private readonly LzWEncoder lzWEncoder;
        private readonly LzWDecoder lzWDecoder;

        public UserControlLzW()
        {
            InitializeComponent();

            var dependencyResolver = new DependencyResolver();
            lzWEncoder = (LzWEncoder)dependencyResolver.GetObject<ILzWEncoder>();
            lzWDecoder = (LzWDecoder)dependencyResolver.GetObject<ILzWDecoder>();

            UpdateButtonsEnabledProperty();
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
                Title = "Browse LzW encoded files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "lzw",
                Filter = "LzW encoded files (*.lzw)|*.lzw",
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

        private void buttonEncode_Click(object sender, EventArgs e)
        {
            var onFullDictionaryOption = radioButtonFreeze.Checked ? OnFullDictionaryOption.Freeze : OnFullDictionaryOption.Empty;
            var onFullDictionaryOptionChar = onFullDictionaryOption == OnFullDictionaryOption.Freeze ? 'f' : 'e';

            var bits = (int)numericUpDownIndexBits.Value;

            var destinationFilePath = $"{textBoxFilePathSource.Text}.[{onFullDictionaryOptionChar}][{bits}].lzw";

            using (var fileReader = new FileReader(textBoxFilePathSource.Text, new FileOperations.Buffer()))
            {
                using (var fileWriter = new FileWriter(destinationFilePath, new FileOperations.Buffer()))
                {
                    lzWEncoder.EncodeFile(fileReader, fileWriter, onFullDictionaryOption, bits);
                }
            }

            if (checkBoxShowIndexes.Checked)
            {
                DisplayIndexes();
            }
        }

        private void buttonDecode_Click(object sender, EventArgs e)
        {
            var fileInfoEncodedFile = new FileInfo(textBoxFilePathEncodedFile.Text);

            if (!fileInfoEncodedFile.Exists)
            {
                throw new InvalidOperationException($"LzW decoding error: file '{fileInfoEncodedFile.FullName}' does not exist");
            }

            var encodedFileExtension = GetExtensionOfEncodedFile(fileInfoEncodedFile);
            var decodedFileDestinationPath = $"{fileInfoEncodedFile.FullName}.{encodedFileExtension}";

            using (var fileReader = new FileReader(textBoxFilePathEncodedFile.Text, new FileOperations.Buffer()))
            {
                using (var fileWriter = new FileWriter(decodedFileDestinationPath, new FileOperations.Buffer()))
                {
                    lzWDecoder.DecodeFile(fileReader, fileWriter);
                }
            }
        }

        private void UpdateButtonsEnabledProperty()
        {
            buttonEncode.Enabled = !string.IsNullOrWhiteSpace(textBoxFilePathSource.Text);
            buttonDecode.Enabled = !string.IsNullOrWhiteSpace(textBoxFilePathEncodedFile.Text);
        }

        private void DisplayIndexes()
        {
            var stringBuilder = new StringBuilder();

            for (int currentIndex = 0; currentIndex < lzWEncoder.IndexesFromLastRun.Count; currentIndex++)
            {
                stringBuilder.Append(currentIndex + 1);
                stringBuilder.Append(". ");
                stringBuilder.Append(lzWEncoder.IndexesFromLastRun[currentIndex]);
                stringBuilder.Append(Environment.NewLine);
            }

            textBoxIndexes.Text = stringBuilder.ToString();
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
