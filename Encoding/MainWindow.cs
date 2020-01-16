using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Forms;
using Encoding.UserControls;

namespace Encoding
{
    [ExcludeFromCodeCoverage]
    public partial class MainWindow : Form
    {
        private UserControl activeUserControl;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckedChangedFileReadingAndWriting(object sender, System.EventArgs e)
        {
            UpdatePanelBasedOnChoice();
        }

        private void CheckedChangedHuffman(object sender, System.EventArgs e)
        {
            UpdatePanelBasedOnChoice();
        }

        private void radioButtonLz77_CheckedChanged(object sender, System.EventArgs e)
        {
            UpdatePanelBasedOnChoice();
        }

        private void radioButtonLzW_CheckedChanged(object sender, System.EventArgs e)
        {
            UpdatePanelBasedOnChoice();
        }
        private void radioButtonRsa_CheckedChanged(object sender, System.EventArgs e)
        {
            UpdatePanelBasedOnChoice();
        }

        private void radioButtonImagePrediction_CheckedChanged(object sender, System.EventArgs e)
        {
            UpdatePanelBasedOnChoice();
        }

        private void radioButtonJpeg_CheckedChanged(object sender, System.EventArgs e)
        {
            UpdatePanelBasedOnChoice();
        }

        private void UpdatePanelBasedOnChoice()
        {
            var selectedRadioButton = panelRadioButtons
                .Controls
                .OfType<RadioButton>()
                .First(x => x.Checked);

            if (selectedRadioButton == radioButtonFileReadingAndWriting)
            {
                activeUserControl = new UserControlFileReadingAndWriting();
            }

            if (selectedRadioButton == radioButtonHuffman)
            {
                activeUserControl = new UserControlHuffman();
            }

            if (selectedRadioButton == radioButtonLz77)
            {
                activeUserControl = new UserControlLz77();
            }

            if (selectedRadioButton == radioButtonLzW)
            {
                activeUserControl = new UserControlLzW();
            }

            if (selectedRadioButton == radioButtonRsa)
            {
                activeUserControl = new UserControlRsa();
            }

            if (selectedRadioButton == radioButtonImagePrediction)
            {
                activeUserControl = new UserControlImagePrediction();
            }

            if (selectedRadioButton == radioButtonJpeg)
            {
                activeUserControl = new UserControlJpeg();
            }

            UpdatePanelUserControl();
        }

        private void UpdatePanelUserControl()
        {
            panelActiveUserControl.Controls.Clear();
            panelActiveUserControl.Controls.Add(activeUserControl);
        }
    }
}
