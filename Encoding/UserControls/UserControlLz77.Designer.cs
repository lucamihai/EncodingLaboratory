namespace Encoding.UserControls
{
    partial class UserControlLz77
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownOffsetBits = new System.Windows.Forms.NumericUpDown();
            this.checkBoxShowTokensEncoding = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.textBoxFilePathSource = new System.Windows.Forms.TextBox();
            this.textBoxFilePathEncodedFile = new System.Windows.Forms.TextBox();
            this.buttonDecode = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSelectEncodedFile = new System.Windows.Forms.Button();
            this.panelDecoding = new System.Windows.Forms.Panel();
            this.checkBoxShowTokensDecrypting = new System.Windows.Forms.CheckBox();
            this.textBoxTokens = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelCodes = new System.Windows.Forms.Panel();
            this.panelEncoding = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownLengthBits = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetBits)).BeginInit();
            this.panelDecoding.SuspendLayout();
            this.panelCodes.SuspendLayout();
            this.panelEncoding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLengthBits)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonEncode
            // 
            this.buttonEncode.Location = new System.Drawing.Point(35, 253);
            this.buttonEncode.Name = "buttonEncode";
            this.buttonEncode.Size = new System.Drawing.Size(75, 23);
            this.buttonEncode.TabIndex = 21;
            this.buttonEncode.Text = "Encode";
            this.buttonEncode.UseVisualStyleBackColor = true;
            this.buttonEncode.Click += new System.EventHandler(this.buttonEncode_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(101, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "bits\r\n";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(29, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Encode offset on";
            // 
            // numericUpDownOffsetBits
            // 
            this.numericUpDownOffsetBits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownOffsetBits.Location = new System.Drawing.Point(33, 152);
            this.numericUpDownOffsetBits.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownOffsetBits.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownOffsetBits.Name = "numericUpDownOffsetBits";
            this.numericUpDownOffsetBits.Size = new System.Drawing.Size(66, 20);
            this.numericUpDownOffsetBits.TabIndex = 15;
            this.numericUpDownOffsetBits.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // checkBoxShowTokensEncoding
            // 
            this.checkBoxShowTokensEncoding.AutoSize = true;
            this.checkBoxShowTokensEncoding.Location = new System.Drawing.Point(35, 230);
            this.checkBoxShowTokensEncoding.Name = "checkBoxShowTokensEncoding";
            this.checkBoxShowTokensEncoding.Size = new System.Drawing.Size(92, 17);
            this.checkBoxShowTokensEncoding.TabIndex = 7;
            this.checkBoxShowTokensEncoding.Text = "Show indexes";
            this.checkBoxShowTokensEncoding.UseVisualStyleBackColor = true;
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
            // buttonSelectFile
            // 
            this.buttonSelectFile.Location = new System.Drawing.Point(33, 49);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectFile.TabIndex = 3;
            this.buttonSelectFile.Text = "Select file";
            this.buttonSelectFile.UseVisualStyleBackColor = true;
            this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // textBoxFilePathSource
            // 
            this.textBoxFilePathSource.Location = new System.Drawing.Point(33, 78);
            this.textBoxFilePathSource.Name = "textBoxFilePathSource";
            this.textBoxFilePathSource.ReadOnly = true;
            this.textBoxFilePathSource.Size = new System.Drawing.Size(310, 20);
            this.textBoxFilePathSource.TabIndex = 2;
            // 
            // textBoxFilePathEncodedFile
            // 
            this.textBoxFilePathEncodedFile.Location = new System.Drawing.Point(14, 78);
            this.textBoxFilePathEncodedFile.Name = "textBoxFilePathEncodedFile";
            this.textBoxFilePathEncodedFile.ReadOnly = true;
            this.textBoxFilePathEncodedFile.Size = new System.Drawing.Size(310, 20);
            this.textBoxFilePathEncodedFile.TabIndex = 7;
            // 
            // buttonDecode
            // 
            this.buttonDecode.Location = new System.Drawing.Point(157, 49);
            this.buttonDecode.Name = "buttonDecode";
            this.buttonDecode.Size = new System.Drawing.Size(75, 23);
            this.buttonDecode.TabIndex = 8;
            this.buttonDecode.Text = "Decode";
            this.buttonDecode.UseVisualStyleBackColor = true;
            this.buttonDecode.Click += new System.EventHandler(this.buttonDecode_Click);
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
            // buttonSelectEncodedFile
            // 
            this.buttonSelectEncodedFile.Location = new System.Drawing.Point(14, 49);
            this.buttonSelectEncodedFile.Name = "buttonSelectEncodedFile";
            this.buttonSelectEncodedFile.Size = new System.Drawing.Size(123, 23);
            this.buttonSelectEncodedFile.TabIndex = 7;
            this.buttonSelectEncodedFile.Text = "Select encoded file";
            this.buttonSelectEncodedFile.UseVisualStyleBackColor = true;
            this.buttonSelectEncodedFile.Click += new System.EventHandler(this.buttonSelectEncodedFile_Click);
            // 
            // panelDecoding
            // 
            this.panelDecoding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDecoding.Controls.Add(this.checkBoxShowTokensDecrypting);
            this.panelDecoding.Controls.Add(this.textBoxFilePathEncodedFile);
            this.panelDecoding.Controls.Add(this.buttonDecode);
            this.panelDecoding.Controls.Add(this.label2);
            this.panelDecoding.Controls.Add(this.buttonSelectEncodedFile);
            this.panelDecoding.Location = new System.Drawing.Point(380, 0);
            this.panelDecoding.Name = "panelDecoding";
            this.panelDecoding.Size = new System.Drawing.Size(420, 128);
            this.panelDecoding.TabIndex = 14;
            // 
            // checkBoxShowTokensDecrypting
            // 
            this.checkBoxShowTokensDecrypting.AutoSize = true;
            this.checkBoxShowTokensDecrypting.Location = new System.Drawing.Point(238, 53);
            this.checkBoxShowTokensDecrypting.Name = "checkBoxShowTokensDecrypting";
            this.checkBoxShowTokensDecrypting.Size = new System.Drawing.Size(92, 17);
            this.checkBoxShowTokensDecrypting.TabIndex = 25;
            this.checkBoxShowTokensDecrypting.Text = "Show indexes";
            this.checkBoxShowTokensDecrypting.UseVisualStyleBackColor = true;
            // 
            // textBoxTokens
            // 
            this.textBoxTokens.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTokens.Location = new System.Drawing.Point(47, 41);
            this.textBoxTokens.Multiline = true;
            this.textBoxTokens.Name = "textBoxTokens";
            this.textBoxTokens.ReadOnly = true;
            this.textBoxTokens.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxTokens.Size = new System.Drawing.Size(323, 326);
            this.textBoxTokens.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(161, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tokens";
            // 
            // panelCodes
            // 
            this.panelCodes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCodes.Controls.Add(this.textBoxTokens);
            this.panelCodes.Controls.Add(this.label3);
            this.panelCodes.Location = new System.Drawing.Point(380, 128);
            this.panelCodes.Name = "panelCodes";
            this.panelCodes.Size = new System.Drawing.Size(420, 372);
            this.panelCodes.TabIndex = 15;
            // 
            // panelEncoding
            // 
            this.panelEncoding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEncoding.Controls.Add(this.label7);
            this.panelEncoding.Controls.Add(this.label8);
            this.panelEncoding.Controls.Add(this.numericUpDownLengthBits);
            this.panelEncoding.Controls.Add(this.buttonEncode);
            this.panelEncoding.Controls.Add(this.label5);
            this.panelEncoding.Controls.Add(this.label6);
            this.panelEncoding.Controls.Add(this.numericUpDownOffsetBits);
            this.panelEncoding.Controls.Add(this.checkBoxShowTokensEncoding);
            this.panelEncoding.Controls.Add(this.label1);
            this.panelEncoding.Controls.Add(this.buttonSelectFile);
            this.panelEncoding.Controls.Add(this.textBoxFilePathSource);
            this.panelEncoding.Location = new System.Drawing.Point(0, 0);
            this.panelEncoding.Name = "panelEncoding";
            this.panelEncoding.Size = new System.Drawing.Size(380, 500);
            this.panelEncoding.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(252, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "bits\r\n";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(180, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Encode length on";
            // 
            // numericUpDownLengthBits
            // 
            this.numericUpDownLengthBits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownLengthBits.Location = new System.Drawing.Point(184, 152);
            this.numericUpDownLengthBits.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericUpDownLengthBits.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownLengthBits.Name = "numericUpDownLengthBits";
            this.numericUpDownLengthBits.Size = new System.Drawing.Size(66, 20);
            this.numericUpDownLengthBits.TabIndex = 22;
            this.numericUpDownLengthBits.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // UserControlLz77
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.panelDecoding);
            this.Controls.Add(this.panelCodes);
            this.Controls.Add(this.panelEncoding);
            this.Name = "UserControlLz77";
            this.Size = new System.Drawing.Size(800, 500);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetBits)).EndInit();
            this.panelDecoding.ResumeLayout(false);
            this.panelDecoding.PerformLayout();
            this.panelCodes.ResumeLayout(false);
            this.panelCodes.PerformLayout();
            this.panelEncoding.ResumeLayout(false);
            this.panelEncoding.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLengthBits)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonEncode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownOffsetBits;
        private System.Windows.Forms.CheckBox checkBoxShowTokensEncoding;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.TextBox textBoxFilePathSource;
        private System.Windows.Forms.TextBox textBoxFilePathEncodedFile;
        private System.Windows.Forms.Button buttonDecode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSelectEncodedFile;
        private System.Windows.Forms.Panel panelDecoding;
        private System.Windows.Forms.TextBox textBoxTokens;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelCodes;
        private System.Windows.Forms.Panel panelEncoding;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownLengthBits;
        private System.Windows.Forms.CheckBox checkBoxShowTokensDecrypting;
    }
}
