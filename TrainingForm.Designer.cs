namespace FaceRecogniser
{
    partial class TrainingForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrainingForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TraningGroupBox = new System.Windows.Forms.GroupBox();
            this.AmountCounter = new System.Windows.Forms.Label();
            this.AmountCounterLabel = new System.Windows.Forms.Label();
            this.CancelTrainingButton = new System.Windows.Forms.Button();
            this.StartTrainingButton = new System.Windows.Forms.Button();
            this.IntructionTextBox = new System.Windows.Forms.TextBox();
            this.imageBoxFrameGrabber = new Emgu.CV.UI.ImageBox();
            this.LeftArrowPicture = new System.Windows.Forms.PictureBox();
            this.TopArrowPicture = new System.Windows.Forms.PictureBox();
            this.RightArrowPicture = new System.Windows.Forms.PictureBox();
            this.BottomArrowPicture = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.TraningGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftArrowPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopArrowPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightArrowPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomArrowPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.941861F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.05814F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 214F));
            this.tableLayoutPanel1.Controls.Add(this.TraningGroupBox, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.imageBoxFrameGrabber, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.LeftArrowPicture, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TopArrowPicture, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.RightArrowPicture, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.BottomArrowPicture, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.609284F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.39072F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(924, 546);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TraningGroupBox
            // 
            this.TraningGroupBox.Controls.Add(this.AmountCounter);
            this.TraningGroupBox.Controls.Add(this.AmountCounterLabel);
            this.TraningGroupBox.Controls.Add(this.CancelTrainingButton);
            this.TraningGroupBox.Controls.Add(this.StartTrainingButton);
            this.TraningGroupBox.Controls.Add(this.IntructionTextBox);
            this.TraningGroupBox.Location = new System.Drawing.Point(712, 31);
            this.TraningGroupBox.Name = "TraningGroupBox";
            this.TraningGroupBox.Size = new System.Drawing.Size(209, 479);
            this.TraningGroupBox.TabIndex = 1;
            this.TraningGroupBox.TabStop = false;
            this.TraningGroupBox.Text = "Add new user";
            // 
            // AmountCounter
            // 
            this.AmountCounter.AutoSize = true;
            this.AmountCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AmountCounter.ForeColor = System.Drawing.Color.Red;
            this.AmountCounter.Location = new System.Drawing.Point(147, 323);
            this.AmountCounter.Name = "AmountCounter";
            this.AmountCounter.Size = new System.Drawing.Size(15, 15);
            this.AmountCounter.TabIndex = 12;
            this.AmountCounter.Text = "0";
            // 
            // AmountCounterLabel
            // 
            this.AmountCounterLabel.AutoSize = true;
            this.AmountCounterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AmountCounterLabel.Location = new System.Drawing.Point(6, 323);
            this.AmountCounterLabel.Name = "AmountCounterLabel";
            this.AmountCounterLabel.Size = new System.Drawing.Size(135, 15);
            this.AmountCounterLabel.TabIndex = 11;
            this.AmountCounterLabel.Text = "Faces on the scene:";
            // 
            // CancelTrainingButton
            // 
            this.CancelTrainingButton.Location = new System.Drawing.Point(107, 275);
            this.CancelTrainingButton.Name = "CancelTrainingButton";
            this.CancelTrainingButton.Size = new System.Drawing.Size(96, 29);
            this.CancelTrainingButton.TabIndex = 10;
            this.CancelTrainingButton.Text = "Cancel";
            this.CancelTrainingButton.UseVisualStyleBackColor = true;
            // 
            // StartTrainingButton
            // 
            this.StartTrainingButton.Location = new System.Drawing.Point(6, 275);
            this.StartTrainingButton.Name = "StartTrainingButton";
            this.StartTrainingButton.Size = new System.Drawing.Size(96, 29);
            this.StartTrainingButton.TabIndex = 9;
            this.StartTrainingButton.Text = "Start";
            this.StartTrainingButton.UseVisualStyleBackColor = true;
            // 
            // IntructionTextBox
            // 
            this.IntructionTextBox.Location = new System.Drawing.Point(6, 19);
            this.IntructionTextBox.Multiline = true;
            this.IntructionTextBox.Name = "IntructionTextBox";
            this.IntructionTextBox.ReadOnly = true;
            this.IntructionTextBox.Size = new System.Drawing.Size(197, 250);
            this.IntructionTextBox.TabIndex = 8;
            this.IntructionTextBox.Text = resources.GetString("IntructionTextBox.Text");
            // 
            // imageBoxFrameGrabber
            // 
            this.imageBoxFrameGrabber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.imageBoxFrameGrabber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxFrameGrabber.Location = new System.Drawing.Point(36, 31);
            this.imageBoxFrameGrabber.MaximumSize = new System.Drawing.Size(640, 480);
            this.imageBoxFrameGrabber.MinimumSize = new System.Drawing.Size(640, 480);
            this.imageBoxFrameGrabber.Name = "imageBoxFrameGrabber";
            this.imageBoxFrameGrabber.Size = new System.Drawing.Size(640, 480);
            this.imageBoxFrameGrabber.TabIndex = 4;
            this.imageBoxFrameGrabber.TabStop = false;
            // 
            // LeftArrowPicture
            // 
            this.LeftArrowPicture.Location = new System.Drawing.Point(3, 31);
            this.LeftArrowPicture.Name = "LeftArrowPicture";
            this.LeftArrowPicture.Size = new System.Drawing.Size(26, 479);
            this.LeftArrowPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.LeftArrowPicture.TabIndex = 0;
            this.LeftArrowPicture.TabStop = false;
            // 
            // TopArrowPicture
            // 
            this.TopArrowPicture.Location = new System.Drawing.Point(36, 3);
            this.TopArrowPicture.Name = "TopArrowPicture";
            this.TopArrowPicture.Size = new System.Drawing.Size(637, 22);
            this.TopArrowPicture.TabIndex = 5;
            this.TopArrowPicture.TabStop = false;
            // 
            // RightArrowPicture
            // 
            this.RightArrowPicture.Location = new System.Drawing.Point(679, 31);
            this.RightArrowPicture.Name = "RightArrowPicture";
            this.RightArrowPicture.Size = new System.Drawing.Size(27, 479);
            this.RightArrowPicture.TabIndex = 6;
            this.RightArrowPicture.TabStop = false;
            // 
            // BottomArrowPicture
            // 
            this.BottomArrowPicture.Location = new System.Drawing.Point(36, 516);
            this.BottomArrowPicture.Name = "BottomArrowPicture";
            this.BottomArrowPicture.Size = new System.Drawing.Size(637, 27);
            this.BottomArrowPicture.TabIndex = 7;
            this.BottomArrowPicture.TabStop = false;
            // 
            // TrainingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 587);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TrainingForm";
            this.Text = "TrainingForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.TraningGroupBox.ResumeLayout(false);
            this.TraningGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftArrowPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopArrowPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightArrowPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomArrowPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox LeftArrowPicture;
        private Emgu.CV.UI.ImageBox imageBoxFrameGrabber;
        private System.Windows.Forms.PictureBox TopArrowPicture;
        private System.Windows.Forms.PictureBox RightArrowPicture;
        private System.Windows.Forms.PictureBox BottomArrowPicture;
        private System.Windows.Forms.TextBox IntructionTextBox;
        private System.Windows.Forms.GroupBox TraningGroupBox;
        private System.Windows.Forms.Button CancelTrainingButton;
        private System.Windows.Forms.Button StartTrainingButton;
        private System.Windows.Forms.Label AmountCounter;
        private System.Windows.Forms.Label AmountCounterLabel;
    }
}