namespace Encoding.UserControls
{
    partial class UserControlFileReadingAndWriting
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
            this.textBoxSourceFilePath = new System.Windows.Forms.TextBox();
            this.textBoxDestinationFilePath = new System.Windows.Forms.TextBox();
            this.buttonSelectDestination = new System.Windows.Forms.Button();
            this.textBoxSourceContents = new System.Windows.Forms.TextBox();
            this.buttonReadSource = new System.Windows.Forms.Button();
            this.buttonSelectSource = new System.Windows.Forms.Button();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxSourceFilePath
            // 
            this.textBoxSourceFilePath.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSourceFilePath.Location = new System.Drawing.Point(123, 9);
            this.textBoxSourceFilePath.Name = "textBoxSourceFilePath";
            this.textBoxSourceFilePath.ReadOnly = true;
            this.textBoxSourceFilePath.Size = new System.Drawing.Size(668, 26);
            this.textBoxSourceFilePath.TabIndex = 0;
            // 
            // textBoxDestinationFilePath
            // 
            this.textBoxDestinationFilePath.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDestinationFilePath.Location = new System.Drawing.Point(123, 53);
            this.textBoxDestinationFilePath.Name = "textBoxDestinationFilePath";
            this.textBoxDestinationFilePath.ReadOnly = true;
            this.textBoxDestinationFilePath.Size = new System.Drawing.Size(668, 26);
            this.textBoxDestinationFilePath.TabIndex = 2;
            // 
            // buttonSelectDestination
            // 
            this.buttonSelectDestination.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectDestination.Location = new System.Drawing.Point(7, 52);
            this.buttonSelectDestination.Name = "buttonSelectDestination";
            this.buttonSelectDestination.Size = new System.Drawing.Size(110, 27);
            this.buttonSelectDestination.TabIndex = 3;
            this.buttonSelectDestination.Text = "Select destination";
            this.buttonSelectDestination.UseVisualStyleBackColor = true;
            this.buttonSelectDestination.Click += new System.EventHandler(this.ClickSelectDestination);
            // 
            // textBoxSourceContents
            // 
            this.textBoxSourceContents.Location = new System.Drawing.Point(7, 128);
            this.textBoxSourceContents.Multiline = true;
            this.textBoxSourceContents.Name = "textBoxSourceContents";
            this.textBoxSourceContents.ReadOnly = true;
            this.textBoxSourceContents.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSourceContents.Size = new System.Drawing.Size(784, 358);
            this.textBoxSourceContents.TabIndex = 4;
            // 
            // buttonReadSource
            // 
            this.buttonReadSource.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReadSource.Location = new System.Drawing.Point(366, 95);
            this.buttonReadSource.Name = "buttonReadSource";
            this.buttonReadSource.Size = new System.Drawing.Size(110, 27);
            this.buttonReadSource.TabIndex = 5;
            this.buttonReadSource.Text = "Read source";
            this.buttonReadSource.UseVisualStyleBackColor = true;
            this.buttonReadSource.Click += new System.EventHandler(this.ClickReadSource);
            // 
            // buttonSelectSource
            // 
            this.buttonSelectSource.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectSource.Location = new System.Drawing.Point(7, 9);
            this.buttonSelectSource.Name = "buttonSelectSource";
            this.buttonSelectSource.Size = new System.Drawing.Size(110, 27);
            this.buttonSelectSource.TabIndex = 6;
            this.buttonSelectSource.Text = "Select source";
            this.buttonSelectSource.UseVisualStyleBackColor = true;
            this.buttonSelectSource.Click += new System.EventHandler(this.ClickSelectSource);
            // 
            // buttonCopy
            // 
            this.buttonCopy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCopy.Location = new System.Drawing.Point(250, 95);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(110, 27);
            this.buttonCopy.TabIndex = 7;
            this.buttonCopy.Text = "Copy";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.ClickCopy);
            // 
            // UserControlFileReadingAndWriting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.buttonSelectSource);
            this.Controls.Add(this.buttonReadSource);
            this.Controls.Add(this.textBoxSourceContents);
            this.Controls.Add(this.buttonSelectDestination);
            this.Controls.Add(this.textBoxDestinationFilePath);
            this.Controls.Add(this.textBoxSourceFilePath);
            this.Name = "UserControlFileReadingAndWriting";
            this.Size = new System.Drawing.Size(800, 500);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSourceFilePath;
        private System.Windows.Forms.TextBox textBoxDestinationFilePath;
        private System.Windows.Forms.Button buttonSelectDestination;
        private System.Windows.Forms.TextBox textBoxSourceContents;
        private System.Windows.Forms.Button buttonReadSource;
        private System.Windows.Forms.Button buttonSelectSource;
        private System.Windows.Forms.Button buttonCopy;
    }
}
