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
            this.radioButtonLzW = new System.Windows.Forms.RadioButton();
            this.radioButtonLz77 = new System.Windows.Forms.RadioButton();
            this.radioButtonHuffman = new System.Windows.Forms.RadioButton();
            this.radioButtonFileReadingAndWriting = new System.Windows.Forms.RadioButton();
            this.radioButtonRsa = new System.Windows.Forms.RadioButton();
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
            this.panelRadioButtons.Controls.Add(this.radioButtonRsa);
            this.panelRadioButtons.Controls.Add(this.radioButtonLzW);
            this.panelRadioButtons.Controls.Add(this.radioButtonLz77);
            this.panelRadioButtons.Controls.Add(this.radioButtonHuffman);
            this.panelRadioButtons.Controls.Add(this.radioButtonFileReadingAndWriting);
            this.panelRadioButtons.Location = new System.Drawing.Point(12, 29);
            this.panelRadioButtons.Name = "panelRadioButtons";
            this.panelRadioButtons.Size = new System.Drawing.Size(150, 500);
            this.panelRadioButtons.TabIndex = 1;
            // 
            // radioButtonLzW
            // 
            this.radioButtonLzW.AutoSize = true;
            this.radioButtonLzW.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonLzW.Location = new System.Drawing.Point(22, 124);
            this.radioButtonLzW.Name = "radioButtonLzW";
            this.radioButtonLzW.Size = new System.Drawing.Size(57, 23);
            this.radioButtonLzW.TabIndex = 3;
            this.radioButtonLzW.TabStop = true;
            this.radioButtonLzW.Text = "LzW";
            this.radioButtonLzW.UseVisualStyleBackColor = true;
            this.radioButtonLzW.CheckedChanged += new System.EventHandler(this.radioButtonLzW_CheckedChanged);
            // 
            // radioButtonLz77
            // 
            this.radioButtonLz77.AutoSize = true;
            this.radioButtonLz77.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonLz77.Location = new System.Drawing.Point(22, 95);
            this.radioButtonLz77.Name = "radioButtonLz77";
            this.radioButtonLz77.Size = new System.Drawing.Size(58, 23);
            this.radioButtonLz77.TabIndex = 2;
            this.radioButtonLz77.TabStop = true;
            this.radioButtonLz77.Text = "Lz77";
            this.radioButtonLz77.UseVisualStyleBackColor = true;
            this.radioButtonLz77.CheckedChanged += new System.EventHandler(this.radioButtonLz77_CheckedChanged);
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
            this.radioButtonHuffman.CheckedChanged += new System.EventHandler(this.CheckedChangedHuffman);
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
            this.radioButtonFileReadingAndWriting.CheckedChanged += new System.EventHandler(this.CheckedChangedFileReadingAndWriting);
            // 
            // radioButtonRsa
            // 
            this.radioButtonRsa.AutoSize = true;
            this.radioButtonRsa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonRsa.Location = new System.Drawing.Point(23, 153);
            this.radioButtonRsa.Name = "radioButtonRsa";
            this.radioButtonRsa.Size = new System.Drawing.Size(50, 23);
            this.radioButtonRsa.TabIndex = 4;
            this.radioButtonRsa.TabStop = true;
            this.radioButtonRsa.Text = "Rsa";
            this.radioButtonRsa.UseVisualStyleBackColor = true;
            this.radioButtonRsa.CheckedChanged += new System.EventHandler(this.radioButtonRsa_CheckedChanged);
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
        private System.Windows.Forms.RadioButton radioButtonLzW;
        private System.Windows.Forms.RadioButton radioButtonLz77;
        private System.Windows.Forms.RadioButton radioButtonRsa;
    }
}

