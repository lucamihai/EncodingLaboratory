namespace Encoding.UserControls
{
    partial class UserControlImagePrediction
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
            this.pictureBoxOriginalImage = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonLoadImage = new System.Windows.Forms.Button();
            this.buttonPredict = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.numericUpDownErrorMatrixScale = new System.Windows.Forms.NumericUpDown();
            this.buttonShowErrorMatrix = new System.Windows.Forms.Button();
            this.buttonSaveDecoded = new System.Windows.Forms.Button();
            this.buttonDecode = new System.Windows.Forms.Button();
            this.buttonEncodedImage = new System.Windows.Forms.Button();
            this.panelImagePredictorSelection = new System.Windows.Forms.Panel();
            this.radioButtonImagePredictor0 = new System.Windows.Forms.RadioButton();
            this.radioButtonImagePredictor1 = new System.Windows.Forms.RadioButton();
            this.radioButtonImagePredictor2 = new System.Windows.Forms.RadioButton();
            this.radioButtonImagePredictor3 = new System.Windows.Forms.RadioButton();
            this.radioButtonImagePredictor4 = new System.Windows.Forms.RadioButton();
            this.radioButtonImagePredictor5 = new System.Windows.Forms.RadioButton();
            this.radioButtonImagePredictor6 = new System.Windows.Forms.RadioButton();
            this.radioButtonImagePredictor7 = new System.Windows.Forms.RadioButton();
            this.radioButtonImagePredictor8 = new System.Windows.Forms.RadioButton();
            this.panelHistogramSelection = new System.Windows.Forms.Panel();
            this.radioButtonHistogramOriginal = new System.Windows.Forms.RadioButton();
            this.radioButtonHistogramErrorMatrix = new System.Windows.Forms.RadioButton();
            this.radioButtonHistogramDecoded = new System.Windows.Forms.RadioButton();
            this.numericUpDownHistogram = new System.Windows.Forms.NumericUpDown();
            this.buttonShowHistogram = new System.Windows.Forms.Button();
            this.pictureBoxHistogram = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownErrorMatrixScale)).BeginInit();
            this.panelImagePredictorSelection.SuspendLayout();
            this.panelHistogramSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHistogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogram)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxOriginalImage
            // 
            this.pictureBoxOriginalImage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBoxOriginalImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxOriginalImage.Location = new System.Drawing.Point(3, 19);
            this.pictureBoxOriginalImage.Name = "pictureBoxOriginalImage";
            this.pictureBoxOriginalImage.Size = new System.Drawing.Size(256, 256);
            this.pictureBoxOriginalImage.TabIndex = 0;
            this.pictureBoxOriginalImage.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(272, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(541, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(256, 256);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Original image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(342, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Error matrix";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(612, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Decoded image";
            // 
            // buttonLoadImage
            // 
            this.buttonLoadImage.Location = new System.Drawing.Point(4, 276);
            this.buttonLoadImage.Name = "buttonLoadImage";
            this.buttonLoadImage.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadImage.TabIndex = 6;
            this.buttonLoadImage.Text = "Load image";
            this.buttonLoadImage.UseVisualStyleBackColor = true;
            // 
            // buttonPredict
            // 
            this.buttonPredict.Location = new System.Drawing.Point(94, 276);
            this.buttonPredict.Name = "buttonPredict";
            this.buttonPredict.Size = new System.Drawing.Size(75, 23);
            this.buttonPredict.TabIndex = 7;
            this.buttonPredict.Text = "Predict";
            this.buttonPredict.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(184, 276);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Store";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // numericUpDownErrorMatrixScale
            // 
            this.numericUpDownErrorMatrixScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownErrorMatrixScale.Location = new System.Drawing.Point(291, 278);
            this.numericUpDownErrorMatrixScale.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownErrorMatrixScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownErrorMatrixScale.Name = "numericUpDownErrorMatrixScale";
            this.numericUpDownErrorMatrixScale.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownErrorMatrixScale.TabIndex = 9;
            this.numericUpDownErrorMatrixScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonShowErrorMatrix
            // 
            this.buttonShowErrorMatrix.Location = new System.Drawing.Point(387, 276);
            this.buttonShowErrorMatrix.Name = "buttonShowErrorMatrix";
            this.buttonShowErrorMatrix.Size = new System.Drawing.Size(103, 23);
            this.buttonShowErrorMatrix.TabIndex = 10;
            this.buttonShowErrorMatrix.Text = "Show error matrix";
            this.buttonShowErrorMatrix.UseVisualStyleBackColor = true;
            // 
            // buttonSaveDecoded
            // 
            this.buttonSaveDecoded.Location = new System.Drawing.Point(708, 275);
            this.buttonSaveDecoded.Name = "buttonSaveDecoded";
            this.buttonSaveDecoded.Size = new System.Drawing.Size(88, 23);
            this.buttonSaveDecoded.TabIndex = 13;
            this.buttonSaveDecoded.Text = "Save decoded";
            this.buttonSaveDecoded.UseVisualStyleBackColor = true;
            // 
            // buttonDecode
            // 
            this.buttonDecode.Location = new System.Drawing.Point(631, 275);
            this.buttonDecode.Name = "buttonDecode";
            this.buttonDecode.Size = new System.Drawing.Size(71, 23);
            this.buttonDecode.TabIndex = 12;
            this.buttonDecode.Text = "Decode";
            this.buttonDecode.UseVisualStyleBackColor = true;
            // 
            // buttonEncodedImage
            // 
            this.buttonEncodedImage.Location = new System.Drawing.Point(541, 275);
            this.buttonEncodedImage.Name = "buttonEncodedImage";
            this.buttonEncodedImage.Size = new System.Drawing.Size(84, 23);
            this.buttonEncodedImage.TabIndex = 11;
            this.buttonEncodedImage.Text = "Load encoded";
            this.buttonEncodedImage.UseVisualStyleBackColor = true;
            // 
            // panelImagePredictorSelection
            // 
            this.panelImagePredictorSelection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelImagePredictorSelection.Controls.Add(this.radioButtonImagePredictor8);
            this.panelImagePredictorSelection.Controls.Add(this.radioButtonImagePredictor7);
            this.panelImagePredictorSelection.Controls.Add(this.radioButtonImagePredictor6);
            this.panelImagePredictorSelection.Controls.Add(this.radioButtonImagePredictor5);
            this.panelImagePredictorSelection.Controls.Add(this.radioButtonImagePredictor4);
            this.panelImagePredictorSelection.Controls.Add(this.radioButtonImagePredictor3);
            this.panelImagePredictorSelection.Controls.Add(this.radioButtonImagePredictor2);
            this.panelImagePredictorSelection.Controls.Add(this.radioButtonImagePredictor1);
            this.panelImagePredictorSelection.Controls.Add(this.radioButtonImagePredictor0);
            this.panelImagePredictorSelection.Location = new System.Drawing.Point(4, 306);
            this.panelImagePredictorSelection.Name = "panelImagePredictorSelection";
            this.panelImagePredictorSelection.Size = new System.Drawing.Size(165, 191);
            this.panelImagePredictorSelection.TabIndex = 14;
            // 
            // radioButtonImagePredictor0
            // 
            this.radioButtonImagePredictor0.AutoSize = true;
            this.radioButtonImagePredictor0.Location = new System.Drawing.Point(4, 4);
            this.radioButtonImagePredictor0.Name = "radioButtonImagePredictor0";
            this.radioButtonImagePredictor0.Size = new System.Drawing.Size(43, 17);
            this.radioButtonImagePredictor0.TabIndex = 0;
            this.radioButtonImagePredictor0.TabStop = true;
            this.radioButtonImagePredictor0.Text = "128";
            this.radioButtonImagePredictor0.UseVisualStyleBackColor = true;
            // 
            // radioButtonImagePredictor1
            // 
            this.radioButtonImagePredictor1.AutoSize = true;
            this.radioButtonImagePredictor1.Location = new System.Drawing.Point(3, 27);
            this.radioButtonImagePredictor1.Name = "radioButtonImagePredictor1";
            this.radioButtonImagePredictor1.Size = new System.Drawing.Size(32, 17);
            this.radioButtonImagePredictor1.TabIndex = 1;
            this.radioButtonImagePredictor1.TabStop = true;
            this.radioButtonImagePredictor1.Text = "A";
            this.radioButtonImagePredictor1.UseVisualStyleBackColor = true;
            // 
            // radioButtonImagePredictor2
            // 
            this.radioButtonImagePredictor2.AutoSize = true;
            this.radioButtonImagePredictor2.Location = new System.Drawing.Point(4, 50);
            this.radioButtonImagePredictor2.Name = "radioButtonImagePredictor2";
            this.radioButtonImagePredictor2.Size = new System.Drawing.Size(32, 17);
            this.radioButtonImagePredictor2.TabIndex = 2;
            this.radioButtonImagePredictor2.TabStop = true;
            this.radioButtonImagePredictor2.Text = "B";
            this.radioButtonImagePredictor2.UseVisualStyleBackColor = true;
            // 
            // radioButtonImagePredictor3
            // 
            this.radioButtonImagePredictor3.AutoSize = true;
            this.radioButtonImagePredictor3.Location = new System.Drawing.Point(4, 73);
            this.radioButtonImagePredictor3.Name = "radioButtonImagePredictor3";
            this.radioButtonImagePredictor3.Size = new System.Drawing.Size(32, 17);
            this.radioButtonImagePredictor3.TabIndex = 3;
            this.radioButtonImagePredictor3.TabStop = true;
            this.radioButtonImagePredictor3.Text = "C";
            this.radioButtonImagePredictor3.UseVisualStyleBackColor = true;
            // 
            // radioButtonImagePredictor4
            // 
            this.radioButtonImagePredictor4.AutoSize = true;
            this.radioButtonImagePredictor4.Location = new System.Drawing.Point(4, 96);
            this.radioButtonImagePredictor4.Name = "radioButtonImagePredictor4";
            this.radioButtonImagePredictor4.Size = new System.Drawing.Size(67, 17);
            this.radioButtonImagePredictor4.TabIndex = 4;
            this.radioButtonImagePredictor4.TabStop = true;
            this.radioButtonImagePredictor4.Text = "A + B - C";
            this.radioButtonImagePredictor4.UseVisualStyleBackColor = true;
            // 
            // radioButtonImagePredictor5
            // 
            this.radioButtonImagePredictor5.AutoSize = true;
            this.radioButtonImagePredictor5.Location = new System.Drawing.Point(4, 119);
            this.radioButtonImagePredictor5.Name = "radioButtonImagePredictor5";
            this.radioButtonImagePredictor5.Size = new System.Drawing.Size(90, 17);
            this.radioButtonImagePredictor5.TabIndex = 15;
            this.radioButtonImagePredictor5.TabStop = true;
            this.radioButtonImagePredictor5.Text = "A + (B - C) / 2";
            this.radioButtonImagePredictor5.UseVisualStyleBackColor = true;
            // 
            // radioButtonImagePredictor6
            // 
            this.radioButtonImagePredictor6.AutoSize = true;
            this.radioButtonImagePredictor6.Location = new System.Drawing.Point(4, 142);
            this.radioButtonImagePredictor6.Name = "radioButtonImagePredictor6";
            this.radioButtonImagePredictor6.Size = new System.Drawing.Size(90, 17);
            this.radioButtonImagePredictor6.TabIndex = 16;
            this.radioButtonImagePredictor6.TabStop = true;
            this.radioButtonImagePredictor6.Text = "B + (A - C) / 2";
            this.radioButtonImagePredictor6.UseVisualStyleBackColor = true;
            // 
            // radioButtonImagePredictor7
            // 
            this.radioButtonImagePredictor7.AutoSize = true;
            this.radioButtonImagePredictor7.Location = new System.Drawing.Point(4, 165);
            this.radioButtonImagePredictor7.Name = "radioButtonImagePredictor7";
            this.radioButtonImagePredictor7.Size = new System.Drawing.Size(74, 17);
            this.radioButtonImagePredictor7.TabIndex = 17;
            this.radioButtonImagePredictor7.TabStop = true;
            this.radioButtonImagePredictor7.Text = "(A + B) / 2";
            this.radioButtonImagePredictor7.UseVisualStyleBackColor = true;
            // 
            // radioButtonImagePredictor8
            // 
            this.radioButtonImagePredictor8.AutoSize = true;
            this.radioButtonImagePredictor8.Location = new System.Drawing.Point(100, 3);
            this.radioButtonImagePredictor8.Name = "radioButtonImagePredictor8";
            this.radioButtonImagePredictor8.Size = new System.Drawing.Size(58, 17);
            this.radioButtonImagePredictor8.TabIndex = 18;
            this.radioButtonImagePredictor8.TabStop = true;
            this.radioButtonImagePredictor8.Text = "jpegLS";
            this.radioButtonImagePredictor8.UseVisualStyleBackColor = true;
            // 
            // panelHistogramSelection
            // 
            this.panelHistogramSelection.Controls.Add(this.radioButtonHistogramDecoded);
            this.panelHistogramSelection.Controls.Add(this.radioButtonHistogramErrorMatrix);
            this.panelHistogramSelection.Controls.Add(this.radioButtonHistogramOriginal);
            this.panelHistogramSelection.Location = new System.Drawing.Point(184, 306);
            this.panelHistogramSelection.Name = "panelHistogramSelection";
            this.panelHistogramSelection.Size = new System.Drawing.Size(103, 76);
            this.panelHistogramSelection.TabIndex = 15;
            // 
            // radioButtonHistogramOriginal
            // 
            this.radioButtonHistogramOriginal.AutoSize = true;
            this.radioButtonHistogramOriginal.Location = new System.Drawing.Point(3, 5);
            this.radioButtonHistogramOriginal.Name = "radioButtonHistogramOriginal";
            this.radioButtonHistogramOriginal.Size = new System.Drawing.Size(60, 17);
            this.radioButtonHistogramOriginal.TabIndex = 19;
            this.radioButtonHistogramOriginal.TabStop = true;
            this.radioButtonHistogramOriginal.Text = "Original";
            this.radioButtonHistogramOriginal.UseVisualStyleBackColor = true;
            // 
            // radioButtonHistogramErrorMatrix
            // 
            this.radioButtonHistogramErrorMatrix.AutoSize = true;
            this.radioButtonHistogramErrorMatrix.Location = new System.Drawing.Point(3, 28);
            this.radioButtonHistogramErrorMatrix.Name = "radioButtonHistogramErrorMatrix";
            this.radioButtonHistogramErrorMatrix.Size = new System.Drawing.Size(96, 17);
            this.radioButtonHistogramErrorMatrix.TabIndex = 20;
            this.radioButtonHistogramErrorMatrix.TabStop = true;
            this.radioButtonHistogramErrorMatrix.Text = "Error prediction";
            this.radioButtonHistogramErrorMatrix.UseVisualStyleBackColor = true;
            // 
            // radioButtonHistogramDecoded
            // 
            this.radioButtonHistogramDecoded.AutoSize = true;
            this.radioButtonHistogramDecoded.Location = new System.Drawing.Point(3, 51);
            this.radioButtonHistogramDecoded.Name = "radioButtonHistogramDecoded";
            this.radioButtonHistogramDecoded.Size = new System.Drawing.Size(69, 17);
            this.radioButtonHistogramDecoded.TabIndex = 21;
            this.radioButtonHistogramDecoded.TabStop = true;
            this.radioButtonHistogramDecoded.Text = "Decoded";
            this.radioButtonHistogramDecoded.UseVisualStyleBackColor = true;
            // 
            // numericUpDownHistogram
            // 
            this.numericUpDownHistogram.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownHistogram.Location = new System.Drawing.Point(184, 400);
            this.numericUpDownHistogram.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownHistogram.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownHistogram.Name = "numericUpDownHistogram";
            this.numericUpDownHistogram.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownHistogram.TabIndex = 16;
            this.numericUpDownHistogram.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonShowHistogram
            // 
            this.buttonShowHistogram.Location = new System.Drawing.Point(184, 443);
            this.buttonShowHistogram.Name = "buttonShowHistogram";
            this.buttonShowHistogram.Size = new System.Drawing.Size(103, 23);
            this.buttonShowHistogram.TabIndex = 17;
            this.buttonShowHistogram.Text = "Show histogram";
            this.buttonShowHistogram.UseVisualStyleBackColor = true;
            // 
            // pictureBoxHistogram
            // 
            this.pictureBoxHistogram.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBoxHistogram.Location = new System.Drawing.Point(296, 306);
            this.pictureBoxHistogram.Name = "pictureBoxHistogram";
            this.pictureBoxHistogram.Size = new System.Drawing.Size(500, 180);
            this.pictureBoxHistogram.TabIndex = 18;
            this.pictureBoxHistogram.TabStop = false;
            // 
            // UserControlImagePrediction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.pictureBoxHistogram);
            this.Controls.Add(this.buttonShowHistogram);
            this.Controls.Add(this.numericUpDownHistogram);
            this.Controls.Add(this.panelHistogramSelection);
            this.Controls.Add(this.panelImagePredictorSelection);
            this.Controls.Add(this.buttonSaveDecoded);
            this.Controls.Add(this.buttonDecode);
            this.Controls.Add(this.buttonEncodedImage);
            this.Controls.Add(this.buttonShowErrorMatrix);
            this.Controls.Add(this.numericUpDownErrorMatrixScale);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonPredict);
            this.Controls.Add(this.buttonLoadImage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBoxOriginalImage);
            this.Name = "UserControlImagePrediction";
            this.Size = new System.Drawing.Size(800, 500);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownErrorMatrixScale)).EndInit();
            this.panelImagePredictorSelection.ResumeLayout(false);
            this.panelImagePredictorSelection.PerformLayout();
            this.panelHistogramSelection.ResumeLayout(false);
            this.panelHistogramSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHistogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogram)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxOriginalImage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonLoadImage;
        private System.Windows.Forms.Button buttonPredict;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown numericUpDownErrorMatrixScale;
        private System.Windows.Forms.Button buttonShowErrorMatrix;
        private System.Windows.Forms.Button buttonSaveDecoded;
        private System.Windows.Forms.Button buttonDecode;
        private System.Windows.Forms.Button buttonEncodedImage;
        private System.Windows.Forms.Panel panelImagePredictorSelection;
        private System.Windows.Forms.RadioButton radioButtonImagePredictor7;
        private System.Windows.Forms.RadioButton radioButtonImagePredictor6;
        private System.Windows.Forms.RadioButton radioButtonImagePredictor5;
        private System.Windows.Forms.RadioButton radioButtonImagePredictor4;
        private System.Windows.Forms.RadioButton radioButtonImagePredictor3;
        private System.Windows.Forms.RadioButton radioButtonImagePredictor2;
        private System.Windows.Forms.RadioButton radioButtonImagePredictor1;
        private System.Windows.Forms.RadioButton radioButtonImagePredictor0;
        private System.Windows.Forms.RadioButton radioButtonImagePredictor8;
        private System.Windows.Forms.Panel panelHistogramSelection;
        private System.Windows.Forms.RadioButton radioButtonHistogramDecoded;
        private System.Windows.Forms.RadioButton radioButtonHistogramErrorMatrix;
        private System.Windows.Forms.RadioButton radioButtonHistogramOriginal;
        private System.Windows.Forms.NumericUpDown numericUpDownHistogram;
        private System.Windows.Forms.Button buttonShowHistogram;
        private System.Windows.Forms.PictureBox pictureBoxHistogram;
    }
}
