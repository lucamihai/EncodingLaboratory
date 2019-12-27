using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Encoding.DI;
using Encoding.FileOperations;
using Encoding.Rsa;
using Encoding.Rsa.Interfaces;
using Buffer = Encoding.FileOperations.Buffer;

namespace Encoding.UserControls
{
    [ExcludeFromCodeCoverage]
    public partial class UserControlRsa : UserControl
    {
        private readonly RsaEncrypter rsaEncrypter;
        private readonly RsaDecrypter rsaDecrypter;

        public UserControlRsa()
        {
            InitializeComponent();

            var dependencyResolver = new DependencyResolver();
            rsaEncrypter = (RsaEncrypter)dependencyResolver.GetObject<IRsaEncrypter>();
            rsaDecrypter = (RsaDecrypter)dependencyResolver.GetObject<IRsaDecrypter>();
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

        private void SelectEncryptedFileClick(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Browse RSA encoded files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "rsa",
                Filter = "RSA encoded files (*.rsa)|*.rsa",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFilePathEnryptedFile.Text = openFileDialog.FileName;
            }

            openFileDialog.Dispose();
            UpdateButtonsEnabledProperty();
        }

        private void UpdateButtonsEnabledProperty()
        {
            buttonEncrypt.Enabled = !string.IsNullOrWhiteSpace(textBoxFilePathSource.Text);
            buttonDecrypt.Enabled = !string.IsNullOrWhiteSpace(textBoxFilePathEnryptedFile.Text);
        }

        private void EncryptClick(object sender, EventArgs e)
        {
            var N = (uint)numericUpDownN.Value;
            var E = (uint)numericUpDownE.Value;
            var destinationFilePath = $"{textBoxFilePathSource.Text}.rsa";

            using (var fileReader = new FileReader(textBoxFilePathSource.Text, new Buffer()))
            {
                using (var fileWriter = new FileWriter(destinationFilePath, new Buffer()))
                {
                    rsaEncrypter.EncryptFile(fileReader, fileWriter, N, E);
                }
            }

            if (checkBoxShowKeysEncrypting.Checked)
            {
                DisplayKeys(rsaEncrypter.KeysFromLastRun, textBoxKeysEncrypt);
            }
        }

        private void DecryptClick(object sender, EventArgs e)
        {
            var D = (uint)numericUpDownD.Value;
            var fileInfoEncryptedFile = new FileInfo(textBoxFilePathEnryptedFile.Text);

            if (!fileInfoEncryptedFile.Exists)
            {
                throw new InvalidOperationException($"Lz77 decoding error: file '{fileInfoEncryptedFile.FullName}' does not exist");
            }

            var encryptedFileExtension = GetExtensionOfEncryptedFile(fileInfoEncryptedFile);
            var decryptedFileDestinationPath = $"{fileInfoEncryptedFile.FullName}.{encryptedFileExtension}";

            using (var fileReader = new FileReader(textBoxFilePathEnryptedFile.Text, new Buffer()))
            {
                using (var fileWriter = new FileWriter(decryptedFileDestinationPath, new Buffer()))
                {
                    rsaDecrypter.DecryptFile(fileReader, fileWriter, D);
                }
            }

            if (checkBoxShowKeysDecoding.Checked)
            {
                DisplayKeys(rsaDecrypter.KeysFromLastRun, textBoxKeysDecrypt);
            }
        }

        private void DisplayKeys(List<byte> keys, TextBox textBox)
        {
            var stringBuilder = new StringBuilder();

            for (int currentIndex = 0; currentIndex < keys.Count; currentIndex++)
            {
                stringBuilder.Append(currentIndex + 1);
                stringBuilder.Append(". ");
                stringBuilder.Append(keys[currentIndex]);
                stringBuilder.Append(Environment.NewLine);
            }

            textBox.Text = stringBuilder.ToString();
        }

        private string GetExtensionOfEncryptedFile(FileInfo fileInfoEncodedFile)
        {
            var splitName = fileInfoEncodedFile.Name.Split('.');
            var nameWithoutRsaEncryptedFileExtension = splitName[splitName.Length - 2];

            return nameWithoutRsaEncryptedFileExtension
                .Substring(nameWithoutRsaEncryptedFileExtension.LastIndexOf('.') + 1);
        }
    }
}
