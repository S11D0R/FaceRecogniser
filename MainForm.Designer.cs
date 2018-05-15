namespace FaceRecogniser
{
    partial class MainForm
    {
        /// <summary>
        /// Design container 
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Free resources
        /// </summary>
        /// <param name="disposing">Disposing flag. True if disposing, False else.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Automatically generated main frame contents
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.AddFaceButton = new System.Windows.Forms.Button();
            this.AddNameTextBox = new System.Windows.Forms.TextBox();
            this.AddGroupBox = new System.Windows.Forms.GroupBox();
            this.AddNameLabel = new System.Windows.Forms.Label();
            this.AddFaceImgBox = new Emgu.CV.UI.ImageBox();
            this.ResultsGroupBox = new System.Windows.Forms.GroupBox();
            this.RecognisedLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AmountCounter = new System.Windows.Forms.Label();
            this.AmountLabel = new System.Windows.Forms.Label();
            this.RunButton = new System.Windows.Forms.Button();
            this.imageBoxFrameGrabber = new Emgu.CV.UI.ImageBox();
            this.StopButton = new System.Windows.Forms.Button();
            this.AddGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddFaceImgBox)).BeginInit();
            this.ResultsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).BeginInit();
            this.SuspendLayout();
            // 
            // AddFaceButton
            // 
            this.AddFaceButton.AutoSize = true;
            this.AddFaceButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddFaceButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AddFaceButton.Location = new System.Drawing.Point(11, 201);
            this.AddFaceButton.Name = "AddFaceButton";
            this.AddFaceButton.Size = new System.Drawing.Size(163, 31);
            this.AddFaceButton.TabIndex = 3;
            this.AddFaceButton.Text = "Add face";
            this.AddFaceButton.UseVisualStyleBackColor = true;
            this.AddFaceButton.Click += new System.EventHandler(this.AddFaceButton_Click);
            // 
            // AddNameTextBox
            // 
            this.AddNameTextBox.Location = new System.Drawing.Point(67, 170);
            this.AddNameTextBox.Name = "AddNameTextBox";
            this.AddNameTextBox.Size = new System.Drawing.Size(107, 20);
            this.AddNameTextBox.TabIndex = 7;
            this.AddNameTextBox.Text = "DefaultName";
            // 
            // AddGroupBox
            // 
            this.AddGroupBox.Controls.Add(this.AddNameLabel);
            this.AddGroupBox.Controls.Add(this.AddNameTextBox);
            this.AddGroupBox.Controls.Add(this.AddFaceImgBox);
            this.AddGroupBox.Controls.Add(this.AddFaceButton);
            this.AddGroupBox.Location = new System.Drawing.Point(658, 12);
            this.AddGroupBox.Name = "AddGroupBox";
            this.AddGroupBox.Size = new System.Drawing.Size(188, 480);
            this.AddGroupBox.TabIndex = 8;
            this.AddGroupBox.TabStop = false;
            this.AddGroupBox.Text = "Add new person";
            // 
            // AddNameLabel
            // 
            this.AddNameLabel.AutoSize = true;
            this.AddNameLabel.Location = new System.Drawing.Point(11, 173);
            this.AddNameLabel.Name = "AddNameLabel";
            this.AddNameLabel.Size = new System.Drawing.Size(41, 13);
            this.AddNameLabel.TabIndex = 8;
            this.AddNameLabel.Text = "Name: ";
            // 
            // AddFaceImgBox
            // 
            this.AddFaceImgBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AddFaceImgBox.Location = new System.Drawing.Point(11, 18);
            this.AddFaceImgBox.Name = "AddFaceImgBox";
            this.AddFaceImgBox.Size = new System.Drawing.Size(163, 134);
            this.AddFaceImgBox.TabIndex = 5;
            this.AddFaceImgBox.TabStop = false;
            // 
            // ResultsGroupBox
            // 
            this.ResultsGroupBox.Controls.Add(this.StopButton);
            this.ResultsGroupBox.Controls.Add(this.RecognisedLabel);
            this.ResultsGroupBox.Controls.Add(this.label4);
            this.ResultsGroupBox.Controls.Add(this.RunButton);
            this.ResultsGroupBox.Controls.Add(this.AmountCounter);
            this.ResultsGroupBox.Controls.Add(this.AmountLabel);
            this.ResultsGroupBox.Location = new System.Drawing.Point(12, 498);
            this.ResultsGroupBox.Name = "ResultsGroupBox";
            this.ResultsGroupBox.Size = new System.Drawing.Size(834, 93);
            this.ResultsGroupBox.TabIndex = 9;
            this.ResultsGroupBox.TabStop = false;
            this.ResultsGroupBox.Text = "Results: ";
            // 
            // RecognisedLabel
            // 
            this.RecognisedLabel.AutoSize = true;
            this.RecognisedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecognisedLabel.ForeColor = System.Drawing.Color.Black;
            this.RecognisedLabel.Location = new System.Drawing.Point(10, 38);
            this.RecognisedLabel.Name = "RecognisedLabel";
            this.RecognisedLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RecognisedLabel.Size = new System.Drawing.Size(125, 15);
            this.RecognisedLabel.TabIndex = 17;
            this.RecognisedLabel.Text = "Recognised faces:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(9, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 19);
            this.label4.TabIndex = 16;
            // 
            // AmountCounter
            // 
            this.AmountCounter.AutoSize = true;
            this.AmountCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmountCounter.ForeColor = System.Drawing.Color.Red;
            this.AmountCounter.Location = new System.Drawing.Point(151, 18);
            this.AmountCounter.Name = "AmountCounter";
            this.AmountCounter.Size = new System.Drawing.Size(16, 16);
            this.AmountCounter.TabIndex = 15;
            this.AmountCounter.Text = "0";
            // 
            // AmountLabel
            // 
            this.AmountLabel.AutoSize = true;
            this.AmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmountLabel.Location = new System.Drawing.Point(10, 19);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(135, 15);
            this.AmountLabel.TabIndex = 14;
            this.AmountLabel.Text = "Faces on the scene:";
            // 
            // RunButton
            // 
            this.RunButton.BackColor = System.Drawing.SystemColors.Control;
            this.RunButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RunButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RunButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.RunButton.Location = new System.Drawing.Point(451, 22);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(163, 50);
            this.RunButton.TabIndex = 2;
            this.RunButton.Text = "Run recogniser";
            this.RunButton.UseVisualStyleBackColor = false;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // imageBoxFrameGrabber
            // 
            this.imageBoxFrameGrabber.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imageBoxFrameGrabber.BackgroundImage")));
            this.imageBoxFrameGrabber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.imageBoxFrameGrabber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxFrameGrabber.Location = new System.Drawing.Point(12, 12);
            this.imageBoxFrameGrabber.Name = "imageBoxFrameGrabber";
            this.imageBoxFrameGrabber.Size = new System.Drawing.Size(640, 480);
            this.imageBoxFrameGrabber.TabIndex = 4;
            this.imageBoxFrameGrabber.TabStop = false;
            // 
            // StopButton
            // 
            this.StopButton.Enabled = false;
            this.StopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StopButton.Location = new System.Drawing.Point(631, 22);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(163, 50);
            this.StopButton.TabIndex = 18;
            this.StopButton.Text = "Stop recogniser";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 601);
            this.Controls.Add(this.ResultsGroupBox);
            this.Controls.Add(this.AddGroupBox);
            this.Controls.Add(this.imageBoxFrameGrabber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Face recogniser";
            this.AddGroupBox.ResumeLayout(false);
            this.AddGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddFaceImgBox)).EndInit();
            this.ResultsGroupBox.ResumeLayout(false);
            this.ResultsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddFaceButton;
        private Emgu.CV.UI.ImageBox imageBoxFrameGrabber;
        private Emgu.CV.UI.ImageBox AddFaceImgBox;
        private System.Windows.Forms.TextBox AddNameTextBox;
        private System.Windows.Forms.GroupBox AddGroupBox;
        private System.Windows.Forms.Label AddNameLabel;
        private System.Windows.Forms.GroupBox ResultsGroupBox;
        private System.Windows.Forms.Label RecognisedLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label AmountCounter;
        private System.Windows.Forms.Label AmountLabel;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Button StopButton;
    }
}

