namespace Encoding.UserControls
{
    partial class UserControlHuffman
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonEncode = new System.Windows.Forms.Button();
            this.radioButtonEncodeContentsFromFile = new System.Windows.Forms.RadioButton();
            this.textBoxFilePathSource = new System.Windows.Forms.TextBox();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.radioButtonEncodeContentsFromTextBox = new System.Windows.Forms.RadioButton();
            this.textBoxContents = new System.Windows.Forms.TextBox();
            this.panelEncoding = new System.Windows.Forms.Panel();
            this.checkBoxShowCodesFromEncoding = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSelectEncodedFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panelDecoding = new System.Windows.Forms.Panel();
            this.checkBoxShowCodesFromDecoding = new System.Windows.Forms.CheckBox();
            this.textBoxFilePathEncodedFile = new System.Windows.Forms.TextBox();
            this.buttonDecode = new System.Windows.Forms.Button();
            this.panelCodes = new System.Windows.Forms.Panel();
            this.textBoxCodes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelEncoding.SuspendLayout();
            this.panelDecoding.SuspendLayout();
            this.panelCodes.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonEncode
            // 
            this.buttonEncode.Location = new System.Drawing.Point(3, 39);
            this.buttonEncode.Name = "buttonEncode";
            this.buttonEncode.Size = new System.Drawing.Size(127, 23);
            this.buttonEncode.TabIndex = 0;
            this.buttonEncode.Text = "Encode contents from";
            this.buttonEncode.UseVisualStyleBackColor = true;
            this.buttonEncode.Click += new System.EventHandler(this.buttonEncode_Click);
            // 
            // radioButtonEncodeContentsFromFile
            // 
            this.radioButtonEncodeContentsFromFile.AutoSize = true;
            this.radioButtonEncodeContentsFromFile.Checked = true;
            this.radioButtonEncodeContentsFromFile.Location = new System.Drawing.Point(23, 68);
            this.radioButtonEncodeContentsFromFile.Name = "radioButtonEncodeContentsFromFile";
            this.radioButtonEncodeContentsFromFile.Size = new System.Drawing.Size(41, 17);
            this.radioButtonEncodeContentsFromFile.TabIndex = 1;
            this.radioButtonEncodeContentsFromFile.TabStop = true;
            this.radioButtonEncodeContentsFromFile.Text = "File";
            this.radioButtonEncodeContentsFromFile.UseVisualStyleBackColor = true;
            this.radioButtonEncodeContentsFromFile.CheckedChanged += new System.EventHandler(this.radioButtonEncodeContentsFromFile_CheckedChanged);
            // 
            // textBoxFilePathSource
            // 
            this.textBoxFilePathSource.Location = new System.Drawing.Point(55, 91);
            this.textBoxFilePathSource.Name = "textBoxFilePathSource";
            this.textBoxFilePathSource.ReadOnly = true;
            this.textBoxFilePathSource.Size = new System.Drawing.Size(310, 20);
            this.textBoxFilePathSource.TabIndex = 2;
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.Location = new System.Drawing.Point(55, 117);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectFile.TabIndex = 3;
            this.buttonSelectFile.Text = "Select file";
            this.buttonSelectFile.UseVisualStyleBackColor = true;
            this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // radioButtonEncodeContentsFromTextBox
            // 
            this.radioButtonEncodeContentsFromTextBox.AutoSize = true;
            this.radioButtonEncodeContentsFromTextBox.Location = new System.Drawing.Point(23, 146);
            this.radioButtonEncodeContentsFromTextBox.Name = "radioButtonEncodeContentsFromTextBox";
            this.radioButtonEncodeContentsFromTextBox.Size = new System.Drawing.Size(64, 17);
            this.radioButtonEncodeContentsFromTextBox.TabIndex = 4;
            this.radioButtonEncodeContentsFromTextBox.Text = "TextBox";
            this.radioButtonEncodeContentsFromTextBox.UseVisualStyleBackColor = true;
            this.radioButtonEncodeContentsFromTextBox.CheckedChanged += new System.EventHandler(this.radioButtonEncodeContentsFromTextBox_CheckedChanged);
            // 
            // textBoxContents
            // 
            this.textBoxContents.Location = new System.Drawing.Point(55, 169);
            this.textBoxContents.Multiline = true;
            this.textBoxContents.Name = "textBoxContents";
            this.textBoxContents.ReadOnly = true;
            this.textBoxContents.Size = new System.Drawing.Size(293, 326);
            this.textBoxContents.TabIndex = 5;
            // 
            // panelEncoding
            // 
            this.panelEncoding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEncoding.Controls.Add(this.checkBoxShowCodesFromEncoding);
            this.panelEncoding.Controls.Add(this.label1);
            this.panelEncoding.Controls.Add(this.textBoxContents);
            this.panelEncoding.Controls.Add(this.buttonEncode);
            this.panelEncoding.Controls.Add(this.radioButtonEncodeContentsFromTextBox);
            this.panelEncoding.Controls.Add(this.radioButtonEncodeContentsFromFile);
            this.panelEncoding.Controls.Add(this.buttonSelectFile);
            this.panelEncoding.Controls.Add(this.textBoxFilePathSource);
            this.panelEncoding.Location = new System.Drawing.Point(0, 0);
            this.panelEncoding.Name = "panelEncoding";
            this.panelEncoding.Size = new System.Drawing.Size(380, 500);
            this.panelEncoding.TabIndex = 6;
            // 
            // checkBoxShowCodesFromEncoding
            // 
            this.checkBoxShowCodesFromEncoding.AutoSize = true;
            this.checkBoxShowCodesFromEncoding.Location = new System.Drawing.Point(136, 43);
            this.checkBoxShowCodesFromEncoding.Name = "checkBoxShowCodesFromEncoding";
            this.checkBoxShowCodesFromEncoding.Size = new System.Drawing.Size(85, 17);
            this.checkBoxShowCodesFromEncoding.TabIndex = 7;
            this.checkBoxShowCodesFromEncoding.Text = "Show codes";
            this.checkBoxShowCodesFromEncoding.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(147, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Encoding";
            // 
            // buttonSelectEncodedFile
            // 
            this.buttonSelectEncodedFile.Location = new System.Drawing.Point(12, 62);
            this.buttonSelectEncodedFile.Name = "buttonSelectEncodedFile";
            this.buttonSelectEncodedFile.Size = new System.Drawing.Size(123, 23);
            this.buttonSelectEncodedFile.TabIndex = 7;
            this.buttonSelectEncodedFile.Text = "Select encoded file";
            this.buttonSelectEncodedFile.UseVisualStyleBackColor = true;
            this.buttonSelectEncodedFile.Click += new System.EventHandler(this.buttonSelectEncodedFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(151, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Decoding";
            // 
            // panelDecoding
            // 
            this.panelDecoding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDecoding.Controls.Add(this.checkBoxShowCodesFromDecoding);
            this.panelDecoding.Controls.Add(this.textBoxFilePathEncodedFile);
            this.panelDecoding.Controls.Add(this.buttonDecode);
            this.panelDecoding.Controls.Add(this.label2);
            this.panelDecoding.Controls.Add(this.buttonSelectEncodedFile);
            this.panelDecoding.Location = new System.Drawing.Point(380, 0);
            this.panelDecoding.Name = "panelDecoding";
            this.panelDecoding.Size = new System.Drawing.Size(420, 128);
            this.panelDecoding.TabIndex = 8;
            // 
            // checkBoxShowCodesFromDecoding
            // 
            this.checkBoxShowCodesFromDecoding.AutoSize = true;
            this.checkBoxShowCodesFromDecoding.Location = new System.Drawing.Point(237, 66);
            this.checkBoxShowCodesFromDecoding.Name = "checkBoxShowCodesFromDecoding";
            this.checkBoxShowCodesFromDecoding.Size = new System.Drawing.Size(85, 17);
            this.checkBoxShowCodesFromDecoding.TabIndex = 8;
            this.checkBoxShowCodesFromDecoding.Text = "Show codes";
            this.checkBoxShowCodesFromDecoding.UseVisualStyleBackColor = true;
            // 
            // textBoxFilePathEncodedFile
            // 
            this.textBoxFilePathEncodedFile.Location = new System.Drawing.Point(12, 91);
            this.textBoxFilePathEncodedFile.Name = "textBoxFilePathEncodedFile";
            this.textBoxFilePathEncodedFile.ReadOnly = true;
            this.textBoxFilePathEncodedFile.Size = new System.Drawing.Size(310, 20);
            this.textBoxFilePathEncodedFile.TabIndex = 7;
            // 
            // buttonDecode
            // 
            this.buttonDecode.Location = new System.Drawing.Point(155, 62);
            this.buttonDecode.Name = "buttonDecode";
            this.buttonDecode.Size = new System.Drawing.Size(75, 23);
            this.buttonDecode.TabIndex = 8;
            this.buttonDecode.Text = "Decode";
            this.buttonDecode.UseVisualStyleBackColor = true;
            this.buttonDecode.Click += new System.EventHandler(this.buttonDecode_Click);
            // 
            // panelCodes
            // 
            this.panelCodes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCodes.Controls.Add(this.textBoxCodes);
            this.panelCodes.Controls.Add(this.label3);
            this.panelCodes.Location = new System.Drawing.Point(380, 128);
            this.panelCodes.Name = "panelCodes";
            this.panelCodes.Size = new System.Drawing.Size(420, 372);
            this.panelCodes.TabIndex = 9;
            // 
            // textBoxCodes
            // 
            this.textBoxCodes.Location = new System.Drawing.Point(47, 41);
            this.textBoxCodes.Multiline = true;
            this.textBoxCodes.Name = "textBoxCodes";
            this.textBoxCodes.ReadOnly = true;
            this.textBoxCodes.Size = new System.Drawing.Size(323, 326);
            this.textBoxCodes.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(161, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "Codes";
            // 
            // UserControlHuffman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.panelCodes);
            this.Controls.Add(this.panelDecoding);
            this.Controls.Add(this.panelEncoding);
            this.Name = "UserControlHuffman";
            this.Size = new System.Drawing.Size(800, 500);
            this.panelEncoding.ResumeLayout(false);
            this.panelEncoding.PerformLayout();
            this.panelDecoding.ResumeLayout(false);
            this.panelDecoding.PerformLayout();
            this.panelCodes.ResumeLayout(false);
            this.panelCodes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonEncode;
        private System.Windows.Forms.RadioButton radioButtonEncodeContentsFromFile;
        private System.Windows.Forms.TextBox textBoxFilePathSource;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.RadioButton radioButtonEncodeContentsFromTextBox;
        private System.Windows.Forms.TextBox textBoxContents;
        private System.Windows.Forms.Panel panelEncoding;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSelectEncodedFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelDecoding;
        private System.Windows.Forms.TextBox textBoxFilePathEncodedFile;
        private System.Windows.Forms.Button buttonDecode;
        private System.Windows.Forms.Panel panelCodes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCodes;
        private System.Windows.Forms.CheckBox checkBoxShowCodesFromEncoding;
        private System.Windows.Forms.CheckBox checkBoxShowCodesFromDecoding;
    }
}
