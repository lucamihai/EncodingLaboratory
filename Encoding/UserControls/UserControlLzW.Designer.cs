namespace Encoding.UserControls
{
    partial class UserControlLzW
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
            this.panelCodes = new System.Windows.Forms.Panel();
            this.textBoxIndexes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelDecoding = new System.Windows.Forms.Panel();
            this.textBoxFilePathEncodedFile = new System.Windows.Forms.TextBox();
            this.buttonDecode = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSelectEncodedFile = new System.Windows.Forms.Button();
            this.panelEncoding = new System.Windows.Forms.Panel();
            this.checkBoxShowIndexes = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.textBoxFilePathSource = new System.Windows.Forms.TextBox();
            this.radioButtonEmpty = new System.Windows.Forms.RadioButton();
            this.radioButtonFreeze = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownIndexBits = new System.Windows.Forms.NumericUpDown();
            this.buttonEncode = new System.Windows.Forms.Button();
            this.panelCodes.SuspendLayout();
            this.panelDecoding.SuspendLayout();
            this.panelEncoding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIndexBits)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCodes
            // 
            this.panelCodes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCodes.Controls.Add(this.textBoxIndexes);
            this.panelCodes.Controls.Add(this.label3);
            this.panelCodes.Location = new System.Drawing.Point(380, 128);
            this.panelCodes.Name = "panelCodes";
            this.panelCodes.Size = new System.Drawing.Size(420, 372);
            this.panelCodes.TabIndex = 12;
            // 
            // textBoxIndexes
            // 
            this.textBoxIndexes.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIndexes.Location = new System.Drawing.Point(47, 41);
            this.textBoxIndexes.Multiline = true;
            this.textBoxIndexes.Name = "textBoxIndexes";
            this.textBoxIndexes.ReadOnly = true;
            this.textBoxIndexes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxIndexes.Size = new System.Drawing.Size(323, 326);
            this.textBoxIndexes.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(161, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "Indexes";
            // 
            // panelDecoding
            // 
            this.panelDecoding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDecoding.Controls.Add(this.textBoxFilePathEncodedFile);
            this.panelDecoding.Controls.Add(this.buttonDecode);
            this.panelDecoding.Controls.Add(this.label2);
            this.panelDecoding.Controls.Add(this.buttonSelectEncodedFile);
            this.panelDecoding.Location = new System.Drawing.Point(380, 0);
            this.panelDecoding.Name = "panelDecoding";
            this.panelDecoding.Size = new System.Drawing.Size(420, 128);
            this.panelDecoding.TabIndex = 11;
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
            // panelEncoding
            // 
            this.panelEncoding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEncoding.Controls.Add(this.buttonEncode);
            this.panelEncoding.Controls.Add(this.radioButtonEmpty);
            this.panelEncoding.Controls.Add(this.radioButtonFreeze);
            this.panelEncoding.Controls.Add(this.label4);
            this.panelEncoding.Controls.Add(this.label5);
            this.panelEncoding.Controls.Add(this.label6);
            this.panelEncoding.Controls.Add(this.numericUpDownIndexBits);
            this.panelEncoding.Controls.Add(this.checkBoxShowIndexes);
            this.panelEncoding.Controls.Add(this.label1);
            this.panelEncoding.Controls.Add(this.buttonSelectFile);
            this.panelEncoding.Controls.Add(this.textBoxFilePathSource);
            this.panelEncoding.Location = new System.Drawing.Point(0, 0);
            this.panelEncoding.Name = "panelEncoding";
            this.panelEncoding.Size = new System.Drawing.Size(380, 500);
            this.panelEncoding.TabIndex = 10;
            // 
            // checkBoxShowIndexes
            // 
            this.checkBoxShowIndexes.AutoSize = true;
            this.checkBoxShowIndexes.Location = new System.Drawing.Point(39, 310);
            this.checkBoxShowIndexes.Name = "checkBoxShowIndexes";
            this.checkBoxShowIndexes.Size = new System.Drawing.Size(92, 17);
            this.checkBoxShowIndexes.TabIndex = 7;
            this.checkBoxShowIndexes.Text = "Show indexes";
            this.checkBoxShowIndexes.UseVisualStyleBackColor = true;
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
            // radioButtonEmpty
            // 
            this.radioButtonEmpty.AutoSize = true;
            this.radioButtonEmpty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonEmpty.Location = new System.Drawing.Point(64, 243);
            this.radioButtonEmpty.Name = "radioButtonEmpty";
            this.radioButtonEmpty.Size = new System.Drawing.Size(54, 17);
            this.radioButtonEmpty.TabIndex = 20;
            this.radioButtonEmpty.Text = "Empty";
            this.radioButtonEmpty.UseVisualStyleBackColor = true;
            // 
            // radioButtonFreeze
            // 
            this.radioButtonFreeze.AutoSize = true;
            this.radioButtonFreeze.Checked = true;
            this.radioButtonFreeze.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonFreeze.Location = new System.Drawing.Point(64, 214);
            this.radioButtonFreeze.Name = "radioButtonFreeze";
            this.radioButtonFreeze.Size = new System.Drawing.Size(57, 17);
            this.radioButtonFreeze.TabIndex = 19;
            this.radioButtonFreeze.TabStop = true;
            this.radioButtonFreeze.Text = "Freeze";
            this.radioButtonFreeze.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "When full, dictionary will";
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
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Encode index on";
            // 
            // numericUpDownIndexBits
            // 
            this.numericUpDownIndexBits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownIndexBits.Location = new System.Drawing.Point(33, 152);
            this.numericUpDownIndexBits.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownIndexBits.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDownIndexBits.Name = "numericUpDownIndexBits";
            this.numericUpDownIndexBits.Size = new System.Drawing.Size(66, 20);
            this.numericUpDownIndexBits.TabIndex = 15;
            this.numericUpDownIndexBits.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // buttonEncode
            // 
            this.buttonEncode.Location = new System.Drawing.Point(39, 333);
            this.buttonEncode.Name = "buttonEncode";
            this.buttonEncode.Size = new System.Drawing.Size(75, 23);
            this.buttonEncode.TabIndex = 21;
            this.buttonEncode.Text = "Encode";
            this.buttonEncode.UseVisualStyleBackColor = true;
            this.buttonEncode.Click += new System.EventHandler(this.buttonEncode_Click);
            // 
            // UserControlLzW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.panelCodes);
            this.Controls.Add(this.panelDecoding);
            this.Controls.Add(this.panelEncoding);
            this.Name = "UserControlLzW";
            this.Size = new System.Drawing.Size(800, 500);
            this.panelCodes.ResumeLayout(false);
            this.panelCodes.PerformLayout();
            this.panelDecoding.ResumeLayout(false);
            this.panelDecoding.PerformLayout();
            this.panelEncoding.ResumeLayout(false);
            this.panelEncoding.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIndexBits)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCodes;
        private System.Windows.Forms.TextBox textBoxIndexes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelDecoding;
        private System.Windows.Forms.TextBox textBoxFilePathEncodedFile;
        private System.Windows.Forms.Button buttonDecode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSelectEncodedFile;
        private System.Windows.Forms.Panel panelEncoding;
        private System.Windows.Forms.RadioButton radioButtonEmpty;
        private System.Windows.Forms.RadioButton radioButtonFreeze;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownIndexBits;
        private System.Windows.Forms.CheckBox checkBoxShowIndexes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.TextBox textBoxFilePathSource;
        private System.Windows.Forms.Button buttonEncode;
    }
}
