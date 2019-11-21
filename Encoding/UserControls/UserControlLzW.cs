using System;
using System.Windows.Forms;
using Encoding.FileOperations;
using Encoding.LzW;
using Encoding.LzW.Options;

namespace Encoding.UserControls
{
    public partial class UserControlLzW : UserControl
    {
        private readonly LzWEncoder lzWEncoder;

        public UserControlLzW()
        {
            InitializeComponent();

            lzWEncoder = new LzWEncoder();

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
        }

        private void buttonDecode_Click(object sender, EventArgs e)
        {

        }

        private void UpdateButtonsEnabledProperty()
        {
            buttonEncode.Enabled = !string.IsNullOrWhiteSpace(textBoxFilePathSource.Text);
            buttonDecode.Enabled = !string.IsNullOrWhiteSpace(textBoxFilePathEncodedFile.Text);
        }
    }
}
