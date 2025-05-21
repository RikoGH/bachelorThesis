namespace BachelorProject
{
    partial class Form1
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
            this.buttonAddBackground = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonAddOverlay = new System.Windows.Forms.Button();
            this.buttonAddText = new System.Windows.Forms.Button();
            this.buttonFontSizePlus = new System.Windows.Forms.Button();
            this.buttonFontSizeMinus = new System.Windows.Forms.Button();
            this.comboBoxFont = new System.Windows.Forms.ComboBox();
            this.radioButtonLeft = new System.Windows.Forms.RadioButton();
            this.radioButtonCenter = new System.Windows.Forms.RadioButton();
            this.radioButtonRight = new System.Windows.Forms.RadioButton();
            this.radioButtonTop = new System.Windows.Forms.RadioButton();
            this.radioButtonMiddle = new System.Windows.Forms.RadioButton();
            this.radioButtonBottom = new System.Windows.Forms.RadioButton();
            this.comboBoxTextColor = new System.Windows.Forms.ComboBox();
            this.checkBoxBold = new System.Windows.Forms.CheckBox();
            this.trackBarBlur = new System.Windows.Forms.TrackBar();
            this.buttonIncreaseOverlaySize = new System.Windows.Forms.Button();
            this.buttonDecreaseOverlaySize = new System.Windows.Forms.Button();
            this.checkBoxWrapText = new System.Windows.Forms.CheckBox();
            this.buttonFlipOverlay = new System.Windows.Forms.Button();
            this.buttonUpload = new System.Windows.Forms.Button();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.progressBarLoading = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAddBackground
            // 
            this.buttonAddBackground.Location = new System.Drawing.Point(1085, 39);
            this.buttonAddBackground.Name = "buttonAddBackground";
            this.buttonAddBackground.Size = new System.Drawing.Size(104, 23);
            this.buttonAddBackground.TabIndex = 0;
            this.buttonAddBackground.Text = "Add background";
            this.buttonAddBackground.UseVisualStyleBackColor = true;
            this.buttonAddBackground.Click += new System.EventHandler(this.buttonAddBackground_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonAddOverlay
            // 
            this.buttonAddOverlay.Location = new System.Drawing.Point(1085, 125);
            this.buttonAddOverlay.Name = "buttonAddOverlay";
            this.buttonAddOverlay.Size = new System.Drawing.Size(104, 23);
            this.buttonAddOverlay.TabIndex = 3;
            this.buttonAddOverlay.Text = "Add overlay";
            this.buttonAddOverlay.UseVisualStyleBackColor = true;
            this.buttonAddOverlay.Click += new System.EventHandler(this.buttonAddOverlay_Click);
            // 
            // buttonAddText
            // 
            this.buttonAddText.Location = new System.Drawing.Point(1085, 236);
            this.buttonAddText.Name = "buttonAddText";
            this.buttonAddText.Size = new System.Drawing.Size(104, 23);
            this.buttonAddText.TabIndex = 4;
            this.buttonAddText.Text = "Add text";
            this.buttonAddText.UseVisualStyleBackColor = true;
            this.buttonAddText.Click += new System.EventHandler(this.buttonAddText_Click);
            // 
            // buttonFontSizePlus
            // 
            this.buttonFontSizePlus.Location = new System.Drawing.Point(1085, 265);
            this.buttonFontSizePlus.Name = "buttonFontSizePlus";
            this.buttonFontSizePlus.Size = new System.Drawing.Size(44, 23);
            this.buttonFontSizePlus.TabIndex = 5;
            this.buttonFontSizePlus.Text = "+ text";
            this.buttonFontSizePlus.UseVisualStyleBackColor = true;
            this.buttonFontSizePlus.Click += new System.EventHandler(this.buttonFontSizePlus_Click);
            // 
            // buttonFontSizeMinus
            // 
            this.buttonFontSizeMinus.Location = new System.Drawing.Point(1145, 265);
            this.buttonFontSizeMinus.Name = "buttonFontSizeMinus";
            this.buttonFontSizeMinus.Size = new System.Drawing.Size(44, 23);
            this.buttonFontSizeMinus.TabIndex = 6;
            this.buttonFontSizeMinus.Text = "- text";
            this.buttonFontSizeMinus.UseVisualStyleBackColor = true;
            this.buttonFontSizeMinus.Click += new System.EventHandler(this.buttonFontSizeMinus_Click);
            // 
            // comboBoxFont
            // 
            this.comboBoxFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFont.FormattingEnabled = true;
            this.comboBoxFont.Location = new System.Drawing.Point(1085, 294);
            this.comboBoxFont.Name = "comboBoxFont";
            this.comboBoxFont.Size = new System.Drawing.Size(104, 21);
            this.comboBoxFont.TabIndex = 7;
            this.comboBoxFont.SelectedIndexChanged += new System.EventHandler(this.comboBoxFont_SelectedIndexChanged);
            // 
            // radioButtonLeft
            // 
            this.radioButtonLeft.AutoSize = true;
            this.radioButtonLeft.Location = new System.Drawing.Point(1060, 323);
            this.radioButtonLeft.Name = "radioButtonLeft";
            this.radioButtonLeft.Size = new System.Drawing.Size(67, 17);
            this.radioButtonLeft.TabIndex = 8;
            this.radioButtonLeft.TabStop = true;
            this.radioButtonLeft.Text = "Text Left";
            this.radioButtonLeft.UseVisualStyleBackColor = true;
            this.radioButtonLeft.CheckedChanged += new System.EventHandler(this.radioButtonHorizontal_CheckedChanged);
            // 
            // radioButtonCenter
            // 
            this.radioButtonCenter.AutoSize = true;
            this.radioButtonCenter.Location = new System.Drawing.Point(1060, 346);
            this.radioButtonCenter.Name = "radioButtonCenter";
            this.radioButtonCenter.Size = new System.Drawing.Size(80, 17);
            this.radioButtonCenter.TabIndex = 9;
            this.radioButtonCenter.TabStop = true;
            this.radioButtonCenter.Text = "Text Center";
            this.radioButtonCenter.UseVisualStyleBackColor = true;
            this.radioButtonCenter.CheckedChanged += new System.EventHandler(this.radioButtonHorizontal_CheckedChanged);
            // 
            // radioButtonRight
            // 
            this.radioButtonRight.AutoSize = true;
            this.radioButtonRight.Location = new System.Drawing.Point(1060, 369);
            this.radioButtonRight.Name = "radioButtonRight";
            this.radioButtonRight.Size = new System.Drawing.Size(74, 17);
            this.radioButtonRight.TabIndex = 10;
            this.radioButtonRight.TabStop = true;
            this.radioButtonRight.Text = "Text Right";
            this.radioButtonRight.UseVisualStyleBackColor = true;
            this.radioButtonRight.CheckedChanged += new System.EventHandler(this.radioButtonHorizontal_CheckedChanged);
            // 
            // radioButtonTop
            // 
            this.radioButtonTop.AutoSize = true;
            this.radioButtonTop.Location = new System.Drawing.Point(1060, 411);
            this.radioButtonTop.Name = "radioButtonTop";
            this.radioButtonTop.Size = new System.Drawing.Size(68, 17);
            this.radioButtonTop.TabIndex = 11;
            this.radioButtonTop.TabStop = true;
            this.radioButtonTop.Text = "Text Top";
            this.radioButtonTop.UseVisualStyleBackColor = true;
            this.radioButtonTop.CheckedChanged += new System.EventHandler(this.radioButtonVertical_CheckedChanged);
            // 
            // radioButtonMiddle
            // 
            this.radioButtonMiddle.AutoSize = true;
            this.radioButtonMiddle.Location = new System.Drawing.Point(1060, 435);
            this.radioButtonMiddle.Name = "radioButtonMiddle";
            this.radioButtonMiddle.Size = new System.Drawing.Size(80, 17);
            this.radioButtonMiddle.TabIndex = 12;
            this.radioButtonMiddle.TabStop = true;
            this.radioButtonMiddle.Text = "Text Middle";
            this.radioButtonMiddle.UseVisualStyleBackColor = true;
            this.radioButtonMiddle.CheckedChanged += new System.EventHandler(this.radioButtonVertical_CheckedChanged);
            // 
            // radioButtonBottom
            // 
            this.radioButtonBottom.AutoSize = true;
            this.radioButtonBottom.Location = new System.Drawing.Point(1060, 458);
            this.radioButtonBottom.Name = "radioButtonBottom";
            this.radioButtonBottom.Size = new System.Drawing.Size(82, 17);
            this.radioButtonBottom.TabIndex = 13;
            this.radioButtonBottom.TabStop = true;
            this.radioButtonBottom.Text = "Text Bottom";
            this.radioButtonBottom.UseVisualStyleBackColor = true;
            this.radioButtonBottom.CheckedChanged += new System.EventHandler(this.radioButtonVertical_CheckedChanged);
            // 
            // comboBoxTextColor
            // 
            this.comboBoxTextColor.FormattingEnabled = true;
            this.comboBoxTextColor.Location = new System.Drawing.Point(1085, 481);
            this.comboBoxTextColor.Name = "comboBoxTextColor";
            this.comboBoxTextColor.Size = new System.Drawing.Size(104, 21);
            this.comboBoxTextColor.TabIndex = 14;
            this.comboBoxTextColor.SelectedIndexChanged += new System.EventHandler(this.comboBoxTextColor_SelectedIndexChanged);
            // 
            // checkBoxBold
            // 
            this.checkBoxBold.AutoSize = true;
            this.checkBoxBold.Location = new System.Drawing.Point(1140, 358);
            this.checkBoxBold.Name = "checkBoxBold";
            this.checkBoxBold.Size = new System.Drawing.Size(67, 17);
            this.checkBoxBold.TabIndex = 15;
            this.checkBoxBold.Text = "Bold text";
            this.checkBoxBold.UseVisualStyleBackColor = true;
            this.checkBoxBold.CheckedChanged += new System.EventHandler(this.checkBoxBold_CheckedChanged);
            // 
            // trackBarBlur
            // 
            this.trackBarBlur.Location = new System.Drawing.Point(1060, 68);
            this.trackBarBlur.Maximum = 11;
            this.trackBarBlur.Minimum = 1;
            this.trackBarBlur.Name = "trackBarBlur";
            this.trackBarBlur.Size = new System.Drawing.Size(151, 45);
            this.trackBarBlur.TabIndex = 16;
            this.trackBarBlur.Value = 1;
            this.trackBarBlur.Scroll += new System.EventHandler(this.trackBarBlur_Scroll);
            // 
            // buttonIncreaseOverlaySize
            // 
            this.buttonIncreaseOverlaySize.Location = new System.Drawing.Point(1060, 154);
            this.buttonIncreaseOverlaySize.Name = "buttonIncreaseOverlaySize";
            this.buttonIncreaseOverlaySize.Size = new System.Drawing.Size(73, 23);
            this.buttonIncreaseOverlaySize.TabIndex = 17;
            this.buttonIncreaseOverlaySize.Text = "+ overlay";
            this.buttonIncreaseOverlaySize.UseVisualStyleBackColor = true;
            this.buttonIncreaseOverlaySize.Click += new System.EventHandler(this.buttonIncreaseOverlaySize_Click);
            // 
            // buttonDecreaseOverlaySize
            // 
            this.buttonDecreaseOverlaySize.Location = new System.Drawing.Point(1138, 154);
            this.buttonDecreaseOverlaySize.Name = "buttonDecreaseOverlaySize";
            this.buttonDecreaseOverlaySize.Size = new System.Drawing.Size(73, 23);
            this.buttonDecreaseOverlaySize.TabIndex = 18;
            this.buttonDecreaseOverlaySize.Text = "- overlay";
            this.buttonDecreaseOverlaySize.UseVisualStyleBackColor = true;
            this.buttonDecreaseOverlaySize.Click += new System.EventHandler(this.buttonDecreaseOverlaySize_Click);
            // 
            // checkBoxWrapText
            // 
            this.checkBoxWrapText.AutoSize = true;
            this.checkBoxWrapText.Location = new System.Drawing.Point(1140, 335);
            this.checkBoxWrapText.Name = "checkBoxWrapText";
            this.checkBoxWrapText.Size = new System.Drawing.Size(72, 17);
            this.checkBoxWrapText.TabIndex = 19;
            this.checkBoxWrapText.Text = "Wrap text";
            this.checkBoxWrapText.UseVisualStyleBackColor = true;
            this.checkBoxWrapText.CheckedChanged += new System.EventHandler(this.checkBoxWrapText_CheckedChanged);
            // 
            // buttonFlipOverlay
            // 
            this.buttonFlipOverlay.Location = new System.Drawing.Point(1085, 183);
            this.buttonFlipOverlay.Name = "buttonFlipOverlay";
            this.buttonFlipOverlay.Size = new System.Drawing.Size(104, 23);
            this.buttonFlipOverlay.TabIndex = 20;
            this.buttonFlipOverlay.Text = "Flip Overlay";
            this.buttonFlipOverlay.UseVisualStyleBackColor = true;
            this.buttonFlipOverlay.Click += new System.EventHandler(this.buttonFlipOverlay_Click);
            // 
            // buttonUpload
            // 
            this.buttonUpload.Location = new System.Drawing.Point(1085, 533);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(104, 23);
            this.buttonUpload.TabIndex = 21;
            this.buttonUpload.Text = "Upload";
            this.buttonUpload.UseVisualStyleBackColor = true;
            this.buttonUpload.Click += new System.EventHandler(this.buttonUpload_Click);
            // 
            // buttonDownload
            // 
            this.buttonDownload.Location = new System.Drawing.Point(1085, 591);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(104, 23);
            this.buttonDownload.TabIndex = 22;
            this.buttonDownload.Text = "Download";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // progressBarLoading
            // 
            this.progressBarLoading.Location = new System.Drawing.Point(1085, 562);
            this.progressBarLoading.Name = "progressBarLoading";
            this.progressBarLoading.Size = new System.Drawing.Size(100, 23);
            this.progressBarLoading.TabIndex = 23;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BachelorProject.Properties.Resources.preview;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1034, 623);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1224, 655);
            this.Controls.Add(this.progressBarLoading);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.buttonUpload);
            this.Controls.Add(this.buttonFlipOverlay);
            this.Controls.Add(this.checkBoxWrapText);
            this.Controls.Add(this.buttonDecreaseOverlaySize);
            this.Controls.Add(this.buttonIncreaseOverlaySize);
            this.Controls.Add(this.trackBarBlur);
            this.Controls.Add(this.checkBoxBold);
            this.Controls.Add(this.comboBoxTextColor);
            this.Controls.Add(this.radioButtonBottom);
            this.Controls.Add(this.radioButtonMiddle);
            this.Controls.Add(this.radioButtonTop);
            this.Controls.Add(this.radioButtonRight);
            this.Controls.Add(this.radioButtonCenter);
            this.Controls.Add(this.radioButtonLeft);
            this.Controls.Add(this.comboBoxFont);
            this.Controls.Add(this.buttonFontSizeMinus);
            this.Controls.Add(this.buttonFontSizePlus);
            this.Controls.Add(this.buttonAddText);
            this.Controls.Add(this.buttonAddOverlay);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonAddBackground);
            this.Name = "Form1";
            this.Text = "Thumbnail Maker";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddBackground;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonAddOverlay;
        private System.Windows.Forms.Button buttonAddText;
        private System.Windows.Forms.Button buttonFontSizePlus;
        private System.Windows.Forms.Button buttonFontSizeMinus;
        private System.Windows.Forms.ComboBox comboBoxFont;
        private System.Windows.Forms.RadioButton radioButtonLeft;
        private System.Windows.Forms.RadioButton radioButtonCenter;
        private System.Windows.Forms.RadioButton radioButtonRight;
        private System.Windows.Forms.RadioButton radioButtonTop;
        private System.Windows.Forms.RadioButton radioButtonMiddle;
        private System.Windows.Forms.RadioButton radioButtonBottom;
        private System.Windows.Forms.ComboBox comboBoxTextColor;
        private System.Windows.Forms.CheckBox checkBoxBold;
        private System.Windows.Forms.TrackBar trackBarBlur;
        private System.Windows.Forms.Button buttonIncreaseOverlaySize;
        private System.Windows.Forms.Button buttonDecreaseOverlaySize;
        private System.Windows.Forms.CheckBox checkBoxWrapText;
        private System.Windows.Forms.Button buttonFlipOverlay;
        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.ProgressBar progressBarLoading;
    }
}

