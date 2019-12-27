namespace Encoding.UserControls
{
    partial class UserControlRsa
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
            this.numericUpDownN = new System.Windows.Forms.NumericUpDown();
            this.textBoxKeysDecrypt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelEncoding = new System.Windows.Forms.Panel();
            this.labelN = new System.Windows.Forms.Label();
            this.buttonEncrypt = new System.Windows.Forms.Button();
            this.labelE = new System.Windows.Forms.Label();
            this.numericUpDownE = new System.Windows.Forms.NumericUpDown();
            this.checkBoxShowKeysEncrypting = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.textBoxFilePathSource = new System.Windows.Forms.TextBox();
            this.checkBoxShowKeysDecoding = new System.Windows.Forms.CheckBox();
            this.textBoxFilePathEnryptedFile = new System.Windows.Forms.TextBox();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSelectEncryptedFile = new System.Windows.Forms.Button();
            this.panelDecoding = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownD = new System.Windows.Forms.NumericUpDown();
            this.textBoxKeysEncrypt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownN)).BeginInit();
            this.panelEncoding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownE)).BeginInit();
            this.panelDecoding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownD)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownN
            // 
            this.numericUpDownN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownN.Location = new System.Drawing.Point(193, 126);
            this.numericUpDownN.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDownN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownN.Name = "numericUpDownN";
            this.numericUpDownN.Size = new System.Drawing.Size(66, 20);
            this.numericUpDownN.TabIndex = 22;
            this.numericUpDownN.Value = new decimal(new int[] {
            143,
            0,
            0,
            0});
            // 
            // textBoxKeysDecrypt
            // 
            this.textBoxKeysDecrypt.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxKeysDecrypt.Location = new System.Drawing.Point(47, 223);
            this.textBoxKeysDecrypt.Multiline = true;
            this.textBoxKeysDecrypt.Name = "textBoxKeysDecrypt";
            this.textBoxKeysDecrypt.ReadOnly = true;
            this.textBoxKeysDecrypt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxKeysDecrypt.Size = new System.Drawing.Size(323, 272);
            this.textBoxKeysDecrypt.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(167, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "Keys";
            // 
            // panelEncoding
            // 
            this.panelEncoding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEncoding.Controls.Add(this.textBoxKeysEncrypt);
            this.panelEncoding.Controls.Add(this.label5);
            this.panelEncoding.Controls.Add(this.labelN);
            this.panelEncoding.Controls.Add(this.numericUpDownN);
            this.panelEncoding.Controls.Add(this.buttonEncrypt);
            this.panelEncoding.Controls.Add(this.labelE);
            this.panelEncoding.Controls.Add(this.numericUpDownE);
            this.panelEncoding.Controls.Add(this.checkBoxShowKeysEncrypting);
            this.panelEncoding.Controls.Add(this.label1);
            this.panelEncoding.Controls.Add(this.buttonSelectFile);
            this.panelEncoding.Controls.Add(this.textBoxFilePathSource);
            this.panelEncoding.Location = new System.Drawing.Point(0, 0);
            this.panelEncoding.Name = "panelEncoding";
            this.panelEncoding.Size = new System.Drawing.Size(380, 500);
            this.panelEncoding.TabIndex = 16;
            // 
            // labelN
            // 
            this.labelN.AutoSize = true;
            this.labelN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelN.Location = new System.Drawing.Point(190, 108);
            this.labelN.Name = "labelN";
            this.labelN.Size = new System.Drawing.Size(15, 13);
            this.labelN.TabIndex = 23;
            this.labelN.Text = "N";
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.Location = new System.Drawing.Point(130, 49);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(75, 23);
            this.buttonEncrypt.TabIndex = 21;
            this.buttonEncrypt.Text = "Encrypt";
            this.buttonEncrypt.UseVisualStyleBackColor = true;
            this.buttonEncrypt.Click += new System.EventHandler(this.EncryptClick);
            // 
            // labelE
            // 
            this.labelE.AutoSize = true;
            this.labelE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelE.Location = new System.Drawing.Point(41, 110);
            this.labelE.Name = "labelE";
            this.labelE.Size = new System.Drawing.Size(14, 13);
            this.labelE.TabIndex = 16;
            this.labelE.Text = "E";
            // 
            // numericUpDownE
            // 
            this.numericUpDownE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownE.Location = new System.Drawing.Point(42, 126);
            this.numericUpDownE.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDownE.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownE.Name = "numericUpDownE";
            this.numericUpDownE.Size = new System.Drawing.Size(66, 20);
            this.numericUpDownE.TabIndex = 15;
            this.numericUpDownE.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // checkBoxShowKeysEncrypting
            // 
            this.checkBoxShowKeysEncrypting.AutoSize = true;
            this.checkBoxShowKeysEncrypting.Location = new System.Drawing.Point(265, 49);
            this.checkBoxShowKeysEncrypting.Name = "checkBoxShowKeysEncrypting";
            this.checkBoxShowKeysEncrypting.Size = new System.Drawing.Size(78, 17);
            this.checkBoxShowKeysEncrypting.TabIndex = 7;
            this.checkBoxShowKeysEncrypting.Text = "Show keys";
            this.checkBoxShowKeysEncrypting.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(147, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Encryption";
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.Location = new System.Drawing.Point(33, 49);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectFile.TabIndex = 3;
            this.buttonSelectFile.Text = "Select file";
            this.buttonSelectFile.UseVisualStyleBackColor = true;
            this.buttonSelectFile.Click += new System.EventHandler(this.SelectFileClick);
            // 
            // textBoxFilePathSource
            // 
            this.textBoxFilePathSource.Location = new System.Drawing.Point(33, 78);
            this.textBoxFilePathSource.Name = "textBoxFilePathSource";
            this.textBoxFilePathSource.ReadOnly = true;
            this.textBoxFilePathSource.Size = new System.Drawing.Size(310, 20);
            this.textBoxFilePathSource.TabIndex = 2;
            // 
            // checkBoxShowKeysDecoding
            // 
            this.checkBoxShowKeysDecoding.AutoSize = true;
            this.checkBoxShowKeysDecoding.Location = new System.Drawing.Point(238, 53);
            this.checkBoxShowKeysDecoding.Name = "checkBoxShowKeysDecoding";
            this.checkBoxShowKeysDecoding.Size = new System.Drawing.Size(78, 17);
            this.checkBoxShowKeysDecoding.TabIndex = 25;
            this.checkBoxShowKeysDecoding.Text = "Show keys";
            this.checkBoxShowKeysDecoding.UseVisualStyleBackColor = true;
            // 
            // textBoxFilePathEnryptedFile
            // 
            this.textBoxFilePathEnryptedFile.Location = new System.Drawing.Point(14, 78);
            this.textBoxFilePathEnryptedFile.Name = "textBoxFilePathEnryptedFile";
            this.textBoxFilePathEnryptedFile.ReadOnly = true;
            this.textBoxFilePathEnryptedFile.Size = new System.Drawing.Size(310, 20);
            this.textBoxFilePathEnryptedFile.TabIndex = 7;
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.Location = new System.Drawing.Point(157, 49);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(75, 23);
            this.buttonDecrypt.TabIndex = 8;
            this.buttonDecrypt.Text = "Decrypt";
            this.buttonDecrypt.UseVisualStyleBackColor = true;
            this.buttonDecrypt.Click += new System.EventHandler(this.DecryptClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(151, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Decryption";
            // 
            // buttonSelectEncryptedFile
            // 
            this.buttonSelectEncryptedFile.Location = new System.Drawing.Point(14, 49);
            this.buttonSelectEncryptedFile.Name = "buttonSelectEncryptedFile";
            this.buttonSelectEncryptedFile.Size = new System.Drawing.Size(123, 23);
            this.buttonSelectEncryptedFile.TabIndex = 7;
            this.buttonSelectEncryptedFile.Text = "Select encrypted file";
            this.buttonSelectEncryptedFile.UseVisualStyleBackColor = true;
            this.buttonSelectEncryptedFile.Click += new System.EventHandler(this.SelectEncryptedFileClick);
            // 
            // panelDecoding
            // 
            this.panelDecoding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDecoding.Controls.Add(this.textBoxKeysDecrypt);
            this.panelDecoding.Controls.Add(this.label3);
            this.panelDecoding.Controls.Add(this.label4);
            this.panelDecoding.Controls.Add(this.checkBoxShowKeysDecoding);
            this.panelDecoding.Controls.Add(this.numericUpDownD);
            this.panelDecoding.Controls.Add(this.textBoxFilePathEnryptedFile);
            this.panelDecoding.Controls.Add(this.buttonDecrypt);
            this.panelDecoding.Controls.Add(this.label2);
            this.panelDecoding.Controls.Add(this.buttonSelectEncryptedFile);
            this.panelDecoding.Location = new System.Drawing.Point(380, 0);
            this.panelDecoding.Name = "panelDecoding";
            this.panelDecoding.Size = new System.Drawing.Size(420, 500);
            this.panelDecoding.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "D";
            // 
            // numericUpDownD
            // 
            this.numericUpDownD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownD.Location = new System.Drawing.Point(14, 126);
            this.numericUpDownD.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDownD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownD.Name = "numericUpDownD";
            this.numericUpDownD.Size = new System.Drawing.Size(66, 20);
            this.numericUpDownD.TabIndex = 24;
            this.numericUpDownD.Value = new decimal(new int[] {
            103,
            0,
            0,
            0});
            // 
            // textBoxKeysEncrypt
            // 
            this.textBoxKeysEncrypt.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxKeysEncrypt.Location = new System.Drawing.Point(33, 223);
            this.textBoxKeysEncrypt.Multiline = true;
            this.textBoxKeysEncrypt.Name = "textBoxKeysEncrypt";
            this.textBoxKeysEncrypt.ReadOnly = true;
            this.textBoxKeysEncrypt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxKeysEncrypt.Size = new System.Drawing.Size(323, 272);
            this.textBoxKeysEncrypt.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(153, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 19);
            this.label5.TabIndex = 27;
            this.label5.Text = "Keys";
            // 
            // UserControlRsa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.panelEncoding);
            this.Controls.Add(this.panelDecoding);
            this.Name = "UserControlRsa";
            this.Size = new System.Drawing.Size(800, 500);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownN)).EndInit();
            this.panelEncoding.ResumeLayout(false);
            this.panelEncoding.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownE)).EndInit();
            this.panelDecoding.ResumeLayout(false);
            this.panelDecoding.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericUpDownN;
        private System.Windows.Forms.TextBox textBoxKeysDecrypt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelEncoding;
        private System.Windows.Forms.Label labelN;
        private System.Windows.Forms.Button buttonEncrypt;
        private System.Windows.Forms.Label labelE;
        private System.Windows.Forms.NumericUpDown numericUpDownE;
        private System.Windows.Forms.CheckBox checkBoxShowKeysEncrypting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.TextBox textBoxFilePathSource;
        private System.Windows.Forms.CheckBox checkBoxShowKeysDecoding;
        private System.Windows.Forms.TextBox textBoxFilePathEnryptedFile;
        private System.Windows.Forms.Button buttonDecrypt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSelectEncryptedFile;
        private System.Windows.Forms.Panel panelDecoding;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownD;
        private System.Windows.Forms.TextBox textBoxKeysEncrypt;
        private System.Windows.Forms.Label label5;
    }
}
