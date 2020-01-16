namespace Encoding.UserControls
{
    partial class UserControlJpeg
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
            this.pictureBoxHistogram = new System.Windows.Forms.PictureBox();
            this.radioButtonJpegQ = new System.Windows.Forms.RadioButton();
            this.radioButtonMethod2 = new System.Windows.Forms.RadioButton();
            this.radioButtonZigZag = new System.Windows.Forms.RadioButton();
            this.panelHistogramSelection = new System.Windows.Forms.Panel();
            this.buttonSaveDecoded = new System.Windows.Forms.Button();
            this.buttonLast4Steps = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxDecodedImage = new System.Windows.Forms.PictureBox();
            this.pictureBoxErrorMatrix = new System.Windows.Forms.PictureBox();
            this.pictureBoxOriginalImage = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonFirstThreeSteps = new System.Windows.Forms.Button();
            this.buttonLoadImage = new System.Windows.Forms.Button();
            this.numericUpDownN = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownR = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownJpeg = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogram)).BeginInit();
            this.panelHistogramSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDecodedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxErrorMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownJpeg)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxHistogram
            // 
            this.pictureBoxHistogram.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBoxHistogram.Location = new System.Drawing.Point(284, 304);
            this.pictureBoxHistogram.Name = "pictureBoxHistogram";
            this.pictureBoxHistogram.Size = new System.Drawing.Size(512, 180);
            this.pictureBoxHistogram.TabIndex = 37;
            this.pictureBoxHistogram.TabStop = false;
            // 
            // radioButtonJpegQ
            // 
            this.radioButtonJpegQ.AutoSize = true;
            this.radioButtonJpegQ.Location = new System.Drawing.Point(3, 51);
            this.radioButtonJpegQ.Name = "radioButtonJpegQ";
            this.radioButtonJpegQ.Size = new System.Drawing.Size(59, 17);
            this.radioButtonJpegQ.TabIndex = 21;
            this.radioButtonJpegQ.Text = "Jpeg Q";
            this.radioButtonJpegQ.UseVisualStyleBackColor = true;
            // 
            // radioButtonMethod2
            // 
            this.radioButtonMethod2.AutoSize = true;
            this.radioButtonMethod2.Location = new System.Drawing.Point(3, 28);
            this.radioButtonMethod2.Name = "radioButtonMethod2";
            this.radioButtonMethod2.Size = new System.Drawing.Size(70, 17);
            this.radioButtonMethod2.TabIndex = 20;
            this.radioButtonMethod2.Text = "Method 2";
            this.radioButtonMethod2.UseVisualStyleBackColor = true;
            // 
            // radioButtonZigZag
            // 
            this.radioButtonZigZag.AutoSize = true;
            this.radioButtonZigZag.Checked = true;
            this.radioButtonZigZag.Location = new System.Drawing.Point(3, 5);
            this.radioButtonZigZag.Name = "radioButtonZigZag";
            this.radioButtonZigZag.Size = new System.Drawing.Size(62, 17);
            this.radioButtonZigZag.TabIndex = 19;
            this.radioButtonZigZag.TabStop = true;
            this.radioButtonZigZag.Text = "Zig Zag";
            this.radioButtonZigZag.UseVisualStyleBackColor = true;
            // 
            // panelHistogramSelection
            // 
            this.panelHistogramSelection.Controls.Add(this.numericUpDownJpeg);
            this.panelHistogramSelection.Controls.Add(this.numericUpDownR);
            this.panelHistogramSelection.Controls.Add(this.numericUpDownN);
            this.panelHistogramSelection.Controls.Add(this.radioButtonJpegQ);
            this.panelHistogramSelection.Controls.Add(this.radioButtonMethod2);
            this.panelHistogramSelection.Controls.Add(this.radioButtonZigZag);
            this.panelHistogramSelection.Location = new System.Drawing.Point(16, 392);
            this.panelHistogramSelection.Name = "panelHistogramSelection";
            this.panelHistogramSelection.Size = new System.Drawing.Size(243, 76);
            this.panelHistogramSelection.TabIndex = 34;
            // 
            // buttonSaveDecoded
            // 
            this.buttonSaveDecoded.Location = new System.Drawing.Point(708, 275);
            this.buttonSaveDecoded.Name = "buttonSaveDecoded";
            this.buttonSaveDecoded.Size = new System.Drawing.Size(88, 23);
            this.buttonSaveDecoded.TabIndex = 32;
            this.buttonSaveDecoded.Text = "Save decoded";
            this.buttonSaveDecoded.UseVisualStyleBackColor = true;
            // 
            // buttonLast4Steps
            // 
            this.buttonLast4Steps.Location = new System.Drawing.Point(4, 334);
            this.buttonLast4Steps.Name = "buttonLast4Steps";
            this.buttonLast4Steps.Size = new System.Drawing.Size(71, 23);
            this.buttonLast4Steps.TabIndex = 31;
            this.buttonLast4Steps.Text = "Steps 4 - 1";
            this.buttonLast4Steps.UseVisualStyleBackColor = true;
            this.buttonLast4Steps.Click += new System.EventHandler(this.buttonLast4Steps_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "Original image";
            // 
            // pictureBoxDecodedImage
            // 
            this.pictureBoxDecodedImage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBoxDecodedImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxDecodedImage.Location = new System.Drawing.Point(541, 19);
            this.pictureBoxDecodedImage.Name = "pictureBoxDecodedImage";
            this.pictureBoxDecodedImage.Size = new System.Drawing.Size(256, 256);
            this.pictureBoxDecodedImage.TabIndex = 21;
            this.pictureBoxDecodedImage.TabStop = false;
            // 
            // pictureBoxErrorMatrix
            // 
            this.pictureBoxErrorMatrix.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBoxErrorMatrix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxErrorMatrix.Location = new System.Drawing.Point(272, 19);
            this.pictureBoxErrorMatrix.Name = "pictureBoxErrorMatrix";
            this.pictureBoxErrorMatrix.Size = new System.Drawing.Size(256, 256);
            this.pictureBoxErrorMatrix.TabIndex = 20;
            this.pictureBoxErrorMatrix.TabStop = false;
            // 
            // pictureBoxOriginalImage
            // 
            this.pictureBoxOriginalImage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBoxOriginalImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxOriginalImage.Location = new System.Drawing.Point(3, 19);
            this.pictureBoxOriginalImage.Name = "pictureBoxOriginalImage";
            this.pictureBoxOriginalImage.Size = new System.Drawing.Size(256, 256);
            this.pictureBoxOriginalImage.TabIndex = 19;
            this.pictureBoxOriginalImage.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(612, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "Decoded image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(342, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 23;
            this.label2.Text = "Error matrix";
            // 
            // buttonFirstThreeSteps
            // 
            this.buttonFirstThreeSteps.Location = new System.Drawing.Point(4, 305);
            this.buttonFirstThreeSteps.Name = "buttonFirstThreeSteps";
            this.buttonFirstThreeSteps.Size = new System.Drawing.Size(75, 23);
            this.buttonFirstThreeSteps.TabIndex = 26;
            this.buttonFirstThreeSteps.Text = "Steps 1 - 3";
            this.buttonFirstThreeSteps.UseVisualStyleBackColor = true;
            this.buttonFirstThreeSteps.Click += new System.EventHandler(this.buttonPredict_Click);
            // 
            // buttonLoadImage
            // 
            this.buttonLoadImage.Location = new System.Drawing.Point(4, 276);
            this.buttonLoadImage.Name = "buttonLoadImage";
            this.buttonLoadImage.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadImage.TabIndex = 25;
            this.buttonLoadImage.Text = "Load image";
            this.buttonLoadImage.UseVisualStyleBackColor = true;
            this.buttonLoadImage.Click += new System.EventHandler(this.buttonLoadImage_Click);
            // 
            // numericUpDownN
            // 
            this.numericUpDownN.Location = new System.Drawing.Point(108, 5);
            this.numericUpDownN.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numericUpDownN.Name = "numericUpDownN";
            this.numericUpDownN.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownN.TabIndex = 22;
            // 
            // numericUpDownR
            // 
            this.numericUpDownR.Location = new System.Drawing.Point(108, 28);
            this.numericUpDownR.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numericUpDownR.Name = "numericUpDownR";
            this.numericUpDownR.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownR.TabIndex = 23;
            // 
            // numericUpDownJpeg
            // 
            this.numericUpDownJpeg.Location = new System.Drawing.Point(108, 48);
            this.numericUpDownJpeg.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numericUpDownJpeg.Name = "numericUpDownJpeg";
            this.numericUpDownJpeg.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownJpeg.TabIndex = 24;
            // 
            // UserControlJpeg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.pictureBoxHistogram);
            this.Controls.Add(this.panelHistogramSelection);
            this.Controls.Add(this.buttonSaveDecoded);
            this.Controls.Add(this.buttonLast4Steps);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxDecodedImage);
            this.Controls.Add(this.pictureBoxErrorMatrix);
            this.Controls.Add(this.pictureBoxOriginalImage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonFirstThreeSteps);
            this.Controls.Add(this.buttonLoadImage);
            this.Name = "UserControlJpeg";
            this.Size = new System.Drawing.Size(800, 500);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogram)).EndInit();
            this.panelHistogramSelection.ResumeLayout(false);
            this.panelHistogramSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDecodedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxErrorMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownJpeg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxHistogram;
        private System.Windows.Forms.RadioButton radioButtonJpegQ;
        private System.Windows.Forms.RadioButton radioButtonMethod2;
        private System.Windows.Forms.RadioButton radioButtonZigZag;
        private System.Windows.Forms.Panel panelHistogramSelection;
        private System.Windows.Forms.Button buttonSaveDecoded;
        private System.Windows.Forms.Button buttonLast4Steps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxDecodedImage;
        private System.Windows.Forms.PictureBox pictureBoxErrorMatrix;
        private System.Windows.Forms.PictureBox pictureBoxOriginalImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonFirstThreeSteps;
        private System.Windows.Forms.Button buttonLoadImage;
        private System.Windows.Forms.NumericUpDown numericUpDownJpeg;
        private System.Windows.Forms.NumericUpDown numericUpDownR;
        private System.Windows.Forms.NumericUpDown numericUpDownN;
    }
}
