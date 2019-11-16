namespace Encoding
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelActiveUserControl = new System.Windows.Forms.Panel();
            this.panelRadioButtons = new System.Windows.Forms.Panel();
            this.radioButtonHuffman = new System.Windows.Forms.RadioButton();
            this.radioButtonFileReadingAndWriting = new System.Windows.Forms.RadioButton();
            this.panelRadioButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelActiveUserControl
            // 
            this.panelActiveUserControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelActiveUserControl.Location = new System.Drawing.Point(168, 29);
            this.panelActiveUserControl.Name = "panelActiveUserControl";
            this.panelActiveUserControl.Size = new System.Drawing.Size(800, 500);
            this.panelActiveUserControl.TabIndex = 0;
            // 
            // panelRadioButtons
            // 
            this.panelRadioButtons.Controls.Add(this.radioButtonHuffman);
            this.panelRadioButtons.Controls.Add(this.radioButtonFileReadingAndWriting);
            this.panelRadioButtons.Location = new System.Drawing.Point(12, 29);
            this.panelRadioButtons.Name = "panelRadioButtons";
            this.panelRadioButtons.Size = new System.Drawing.Size(150, 500);
            this.panelRadioButtons.TabIndex = 1;
            // 
            // radioButtonHuffman
            // 
            this.radioButtonHuffman.AutoSize = true;
            this.radioButtonHuffman.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonHuffman.Location = new System.Drawing.Point(22, 66);
            this.radioButtonHuffman.Name = "radioButtonHuffman";
            this.radioButtonHuffman.Size = new System.Drawing.Size(78, 23);
            this.radioButtonHuffman.TabIndex = 1;
            this.radioButtonHuffman.TabStop = true;
            this.radioButtonHuffman.Text = "Huffman";
            this.radioButtonHuffman.UseVisualStyleBackColor = true;
            this.radioButtonHuffman.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButtonFileReadingAndWriting
            // 
            this.radioButtonFileReadingAndWriting.AutoSize = true;
            this.radioButtonFileReadingAndWriting.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonFileReadingAndWriting.Location = new System.Drawing.Point(22, 37);
            this.radioButtonFileReadingAndWriting.Name = "radioButtonFileReadingAndWriting";
            this.radioButtonFileReadingAndWriting.Size = new System.Drawing.Size(101, 23);
            this.radioButtonFileReadingAndWriting.TabIndex = 0;
            this.radioButtonFileReadingAndWriting.TabStop = true;
            this.radioButtonFileReadingAndWriting.Text = "Read / write";
            this.radioButtonFileReadingAndWriting.UseVisualStyleBackColor = true;
            this.radioButtonFileReadingAndWriting.CheckedChanged += new System.EventHandler(this.radioButtonFileReadingAndWriting_CheckedChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1004, 541);
            this.Controls.Add(this.panelRadioButtons);
            this.Controls.Add(this.panelActiveUserControl);
            this.Name = "MainWindow";
            this.Text = "Encoding";
            this.panelRadioButtons.ResumeLayout(false);
            this.panelRadioButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelActiveUserControl;
        private System.Windows.Forms.Panel panelRadioButtons;
        private System.Windows.Forms.RadioButton radioButtonHuffman;
        private System.Windows.Forms.RadioButton radioButtonFileReadingAndWriting;
    }
}

