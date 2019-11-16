using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Windows.Forms;
using Encoding.FileOperations;
using Buffer = Encoding.FileOperations.Buffer;

namespace Encoding.UserControls
{
    [ExcludeFromCodeCoverage]
    public partial class UserControlFileReadingAndWriting : UserControl
    {
        public UserControlFileReadingAndWriting()
        {
            InitializeComponent();

            buttonReadSource.Enabled = false;
            buttonCopy.Enabled = false;
        }

        private void ClickSelectSource(object sender, EventArgs e)
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
                textBoxSourceFilePath.Text = openFileDialog.FileName;
            }

            openFileDialog.Dispose();
            UpdateButtonsEnabledProperty();
        }

        private void ClickSelectDestination(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Title = "Save an Image File"
            };

            saveFileDialog.ShowDialog();

            if (!string.IsNullOrWhiteSpace(saveFileDialog.FileName))
            {
                textBoxDestinationFilePath.Text = saveFileDialog.FileName;
            }

            saveFileDialog.Dispose();
            UpdateButtonsEnabledProperty();
        }

        private void ClickReadSource(object sender, EventArgs e)
        {
            var stopWatch = new Stopwatch();
            var stringBuilder = new StringBuilder();

            using (var fileReader = new FileReader(textBoxSourceFilePath.Text, new FileOperations.Buffer()))
            {
                stopWatch.Start();

                while (!fileReader.ReachedEndOfFile)
                {
                    var character = (char)fileReader.ReadBits(8);
                    stringBuilder.Append(character);
                }

                stopWatch.Stop();
            }

            textBoxSourceContents.Text = stringBuilder.ToString();
        }

        private void ClickCopy(object sender, EventArgs e)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            using (var fileReader = new FileReader(textBoxSourceFilePath.Text, new Buffer()))
            {
                using (var fileWriter = new FileWriter(textBoxDestinationFilePath.Text, new Buffer()))
                {
                    while (!fileReader.ReachedEndOfFile)
                    {
                        var readStuff = fileReader.ReadBits(8);
                        fileWriter.WriteValueOnBits(readStuff, 8);
                    }

                    stopWatch.Stop();
                }
            }
        }

        private void UpdateButtonsEnabledProperty()
        {
            buttonReadSource.Enabled = !string.IsNullOrWhiteSpace(textBoxSourceFilePath.Text);
            buttonCopy.Enabled = !string.IsNullOrWhiteSpace(textBoxSourceFilePath.Text)
                && !string.IsNullOrWhiteSpace(textBoxDestinationFilePath.Text);
        }
    }
}
