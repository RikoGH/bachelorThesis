using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using System.Threading;
using Newtonsoft.Json;


namespace BachelorProject
{
    public partial class Form1 : Form
    {
        Image backgroundImg;
        Image overlayImg;
        Point overlayPosition = new Point(100, 100); 
        string addedText = "";
        Point textPosition = new Point(50, 50); 
        float textFontSize = 24f; 
        private string selectedFontName = "Arial"; 
        private StringAlignment selectedTextHorizontalAlignment = StringAlignment.Center;
        private StringAlignment selectedTextVerticalAlignment = StringAlignment.Center;
        private Color selectedTextColor = Color.Red;
        private bool isBold = false;
        Color textBorderColor = Color.Black;
        private int blurAmount = 0;
        float overlayScale = 1.0f;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.KeyPreview = true;
            foreach (FontFamily font in FontFamily.Families)
            {
                comboBoxFont.Items.Add(font.Name);
            }
            comboBoxFont.SelectedItem = "Arial";
            comboBoxTextColor.Items.AddRange(new string[] { "White", "Green", "Blue", "Black", "Red", "Yellow", "Orange", "Purple" });
            comboBoxTextColor.SelectedIndex = 0;

        }

        // Upload/utility functions
        private async Task UploadConfigToS3Async()
        {
            float wrapWidth = checkBoxWrapText.Checked ? backgroundImg.Width / 2f : backgroundImg.Width;
            float wrapHeight = backgroundImg.Height;

            float x = 0;
            if (selectedTextHorizontalAlignment == StringAlignment.Center)
                x = (backgroundImg.Width - wrapWidth) / 2f;
            else if (selectedTextHorizontalAlignment == StringAlignment.Far)
                x = backgroundImg.Width - wrapWidth;
            else 
                x = 0;

            float y = textPosition.Y;

            RectangleF textRect = new RectangleF(x, y, wrapWidth, wrapHeight);

            StringFormat stringFormat = new StringFormat()
            {
                Alignment = selectedTextHorizontalAlignment,
                LineAlignment = StringAlignment.Center 
            };

            PointF actualTextPos = GetTextPosition(textRect, stringFormat);

            var config = new ThumbnailConfig
            {
                BackgroundImage = "background.jpg",
                OverlayImage = "overlay.png",
                BlurAmount = blurAmount,
                OverlayPosition = overlayPosition,
                OverlayScale = overlayScale,
                Text = addedText,
                TextFont = selectedFontName,
                TextFontSize = textFontSize + 23,
                TextColor = ColorTranslator.ToHtml(selectedTextColor),
                IsBold = isBold,
                TextPositionX = actualTextPos.X,
                TextPositionY = actualTextPos.Y,
                TextHorizontalAlignment = selectedTextHorizontalAlignment.ToString(),
                TextVerticalPosition = textPosition.Y,
                WrapText = checkBoxWrapText.Checked,
                WrapWidthRatio = checkBoxWrapText.Checked ? 0.5f : 1.0f
            };

            string jsonContent = JsonConvert.SerializeObject(config, Formatting.Indented);

            string tempFilePath = Path.Combine(Path.GetTempPath(), "config.json");
            File.WriteAllText(tempFilePath, jsonContent);

            await UploadFileToS3Async(tempFilePath, "config.json");

            File.Delete(tempFilePath);
        }

        private async Task UploadFileToS3Async(string filePath, string keyName)
        {
            var region = RegionEndpoint.EUNorth1; 
            var bucketName = "bach-uploaded-images-bucket";

            try
            {
                using (var client = new AmazonS3Client(region))
                {
                    var fileTransferUtility = new TransferUtility(client);

                    await fileTransferUtility.UploadAsync(filePath, bucketName, keyName);

                    MessageBox.Show($"Successfully uploaded {keyName} to S3.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error uploading file: {ex.Message}");
            }
        }

        private PointF GetTextPosition(RectangleF textRect, StringFormat format)
        {
            float x = textRect.Left;
            float y = textRect.Top;

            switch (format.Alignment)
            {
                case StringAlignment.Center:
                    x += textRect.Width / 2;
                    break;
                case StringAlignment.Far:
                    x += textRect.Width;
                    break;
                case StringAlignment.Near:
                default:
                    break;
            }

            switch (format.LineAlignment)
            {
                case StringAlignment.Center:
                    y += textRect.Height / 2;
                    break;
                case StringAlignment.Far:
                    y += textRect.Height;
                    break;
                case StringAlignment.Near:
                default:
                    break;
            }

            return new PointF(x, y);
        }

        private void ComposeImages()
        {
            if (backgroundImg == null) return;

            Bitmap composed = new Bitmap(backgroundImg.Width, backgroundImg.Height);

            using (Graphics g = Graphics.FromImage(composed))
            {
                
                Bitmap blurredBg = ApplyBlur(new Bitmap(backgroundImg), blurAmount);
                g.DrawImage(blurredBg, 0, 0);
                blurredBg.Dispose();

                if (overlayImg != null)
                {
                    int newWidth = (int)(overlayImg.Width * overlayScale);
                    int newHeight = (int)(overlayImg.Height * overlayScale);
                    Rectangle overlayRect = new Rectangle(overlayPosition.X, overlayPosition.Y, newWidth, newHeight);
                    g.DrawImage(overlayImg, overlayRect);
                }


                if (!string.IsNullOrEmpty(addedText))
                {

                    FontStyle fontStyle = isBold ? FontStyle.Bold : FontStyle.Regular;
                    using (Font font = new Font(selectedFontName, textFontSize, fontStyle))
                    {
                        StringFormat stringFormat = new StringFormat();
                        stringFormat.Alignment = StringAlignment.Center;
                        stringFormat.LineAlignment = StringAlignment.Center;

                        float wrapWidth = checkBoxWrapText.Checked ? backgroundImg.Width / 2f : backgroundImg.Width;
                        float wrapHeight = backgroundImg.Height;

                        if (checkBoxWrapText.Checked)
                        {
                            wrapWidth = backgroundImg.Width / 2f; 
                        }

                        float x = 0;
                        if (selectedTextHorizontalAlignment == StringAlignment.Center)
                            x = (backgroundImg.Width - wrapWidth) / 2f;
                        else if (selectedTextHorizontalAlignment == StringAlignment.Far)
                            x = backgroundImg.Width - wrapWidth;


                        float y = textPosition.Y;

                        RectangleF textRect = new RectangleF(x, y, wrapWidth, wrapHeight);

                        PointF actualTextPos = GetTextPosition(textRect, stringFormat);

                        using (Brush borderBrush = new SolidBrush(textBorderColor)) 
                        {
                            int borderSize = 2; 

                            for (int dx = -borderSize; dx <= borderSize; dx++)
                            {
                                for (int dy = -borderSize; dy <= borderSize; dy++)
                                {
                                    if (dx != 0 || dy != 0)
                                    {
                                        g.DrawString(addedText, font, borderBrush,
                                            new RectangleF(textRect.X + dx, textRect.Y + dy, textRect.Width, textRect.Height),
                                            stringFormat);
                                    }
                                }
                            }
                        }

                        using (Brush textBrush = new SolidBrush(selectedTextColor))
                        {
                            g.DrawString(addedText, font, textBrush, textRect, stringFormat);
                        }
                    }
                }
            }

            pictureBox1.Image = composed;
        }

        private async void buttonUpload_Click(object sender, EventArgs e)
        {
            if (backgroundImg == null)
            {
                MessageBox.Show("No background image loaded.");
                return;
            }

            // Show the progress bar and set it to 0 initially
            progressBarLoading.Visible = true;
            progressBarLoading.Value = 0;
            progressBarLoading.Maximum = 100;
            progressBarLoading.Step = 1;

            // Start a timer to simulate loading progress over 5 seconds
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 50; // Update every 50 ms for a smoother progress
            int progress = 0;

            timer.Tick += (s, args) =>
            {
                progress += 2; // Increment the progress
                progressBarLoading.Value = progress;

                if (progress >= 100)
                {
                    timer.Stop();
                }
            };
            timer.Start();

            string tempBgPath = Path.Combine(Path.GetTempPath(), "background.jpg");
            backgroundImg.Save(tempBgPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            await UploadFileToS3Async(tempBgPath, "background.jpg");
            File.Delete(tempBgPath);

            if (overlayImg != null)
            {
                string tempOverlayPath = Path.Combine(Path.GetTempPath(), "overlay.png");
                overlayImg.Save(tempOverlayPath, System.Drawing.Imaging.ImageFormat.Png);
                await UploadFileToS3Async(tempOverlayPath, "overlay.png");
                File.Delete(tempOverlayPath);
            }

            progressBarLoading.Visible = false;

            await UploadConfigToS3Async();
        }

        private async void buttonDownload_Click(object sender, EventArgs e)
        {
            var region = RegionEndpoint.EUNorth1;
            var bucketName = "bach-output-image-bucket";
            var keyName = "output-image.png";

            try
            {
                using (var client = new AmazonS3Client(region))
                {
                    var saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "JPEG Image|*.jpg";
                    saveFileDialog.Title = "Save Final Image As";
                    saveFileDialog.FileName = "final_image.jpg";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string localFilePath = saveFileDialog.FileName;

                        var request = new Amazon.S3.Model.GetObjectRequest
                        {
                            BucketName = bucketName,
                            Key = keyName
                        };

                        using (var response = await client.GetObjectAsync(request))
                        {
                            await response.WriteResponseStreamToFileAsync(localFilePath, false, CancellationToken.None);
                        }

                        MessageBox.Show("Final image downloaded successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading final image: {ex.Message}");
            }
        }


        // Background
        private void buttonAddBackground_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    backgroundImg = Image.FromFile(filePath);

                    ComposeImages();
                }
            }
        }

        private void trackBarBlur_Scroll(object sender, EventArgs e)
        {
            blurAmount = ((TrackBar)sender).Value;
            ComposeImages();
        }

        private Bitmap ApplyBlur(Bitmap image, int blurSize)
        {
            if (blurSize == 0) return new Bitmap(image);

            Bitmap blurred = new Bitmap(image.Width, image.Height);

            using (Graphics graphics = Graphics.FromImage(blurred))
            {
                int scaleFactor = Math.Max(1, blurSize);
                Bitmap smallBmp = new Bitmap(image, new Size(image.Width / scaleFactor, image.Height / scaleFactor));
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                graphics.DrawImage(smallBmp, new Rectangle(0, 0, image.Width, image.Height));
            }

            return blurred;
        }

        // Overlay
        private void buttonAddOverlay_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image files (*.png)|*.png";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    overlayImg = Image.FromFile(filePath);

                    ComposeImages();
                }
                if (overlayImg != null)
                {
                    MessageBox.Show("Overlay image loaded properly.");
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int moveAmount = 10;

            if (overlayImg != null)
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        overlayPosition.Y -= moveAmount;
                        break;
                    case Keys.S:
                        overlayPosition.Y += moveAmount;
                        break;
                    case Keys.A:
                        overlayPosition.X -= moveAmount;
                        break;
                    case Keys.D:
                        overlayPosition.X += moveAmount;
                        break;
                }

                ComposeImages();
            }
        }

        private void buttonIncreaseOverlaySize_Click(object sender, EventArgs e)
        {
            overlayScale += 0.1f;
            ComposeImages();
        }

        private void buttonDecreaseOverlaySize_Click(object sender, EventArgs e)
        {
            if (overlayScale > 0.1f)
                overlayScale -= 0.1f;
            ComposeImages();
        }

        private void buttonFlipOverlay_Click(object sender, EventArgs e)
        {
            if (overlayImg != null)
            {
                overlayImg.RotateFlip(RotateFlipType.RotateNoneFlipX);
                ComposeImages();
            }
        }

        // Text
        private void buttonAddText_Click(object sender, EventArgs e)
        {
            using (TextInputForm inputForm = new TextInputForm())
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    addedText = inputForm.EnteredText;
                    ComposeImages();
                }
            }
        }

        private void buttonFontSizePlus_Click(object sender, EventArgs e)
        {
            textFontSize += 2f;
            ComposeImages();
        }

        private void buttonFontSizeMinus_Click(object sender, EventArgs e)
        {
            if (textFontSize > 2f) 
                textFontSize -= 2f;

            ComposeImages();
        }

        private void radioButtonVertical_CheckedChanged(object sender, EventArgs e)
        {
            if (backgroundImg == null) return;

            if (radioButtonTop.Checked)
            {
                textPosition.Y = -(backgroundImg.Height / 2 - backgroundImg.Height / 10);
            }
            else if (radioButtonMiddle.Checked)
            {
                textPosition.Y = 0;
            }
            else if (radioButtonBottom.Checked)
            {
                textPosition.Y = backgroundImg.Height / 2 - backgroundImg.Height / 10;
            }

            ComposeImages();
        }

        private void radioButtonHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLeft.Checked)
            {
                selectedTextHorizontalAlignment = StringAlignment.Near;

            }
            else if (radioButtonCenter.Checked)
            {
                selectedTextHorizontalAlignment = StringAlignment.Center;
            }
            else if (radioButtonRight.Checked)
            {
                selectedTextHorizontalAlignment = StringAlignment.Far;
            }

            ComposeImages();
        }

        private void comboBoxTextColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxTextColor.SelectedItem.ToString())
            {
                case "Red":
                    selectedTextColor = Color.Red;
                    break;
                case "Green":
                    selectedTextColor = Color.Green;
                    break;
                case "Blue":
                    selectedTextColor = Color.Blue;
                    break;
                case "Black":
                    selectedTextColor = Color.Black;
                    break;
                case "White":
                    selectedTextColor = Color.White;
                    break;
                case "Yellow":
                    selectedTextColor = Color.Yellow;
                    break;
                case "Orange":
                    selectedTextColor = Color.Orange;
                    break;
                case "Purple":
                    selectedTextColor = Color.Purple;
                    break;
            }

            ComposeImages();
        }

        private void checkBoxBold_CheckedChanged(object sender, EventArgs e)
        {
            isBold = ((CheckBox)sender).Checked;
            ComposeImages();
        }

        private void checkBoxWrapText_CheckedChanged(object sender, EventArgs e)
        {
            ComposeImages();
        }

        private void comboBoxFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFont.SelectedItem != null)
            {
                selectedFontName = comboBoxFont.SelectedItem.ToString();
                ComposeImages();
            }
        }
    }
}