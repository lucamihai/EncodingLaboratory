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

        private void radioButtonFileReadingAndWriting_CheckedChanged(object sender, System.EventArgs e)
        {
            UpdatePanelBasedOnChoice();
        }

        private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
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
                UpdatePanelUserControl();
            }

            if (selectedRadioButton == radioButtonHuffman)
            {
                activeUserControl = new UserControlHuffman();
                UpdatePanelUserControl();
            }
        }

        private void UpdatePanelUserControl()
        {
            panelActiveUserControl.Controls.Clear();
            panelActiveUserControl.Controls.Add(activeUserControl);
        }
    }
}
