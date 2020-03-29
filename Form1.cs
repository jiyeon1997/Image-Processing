using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment
{
    public partial class Form1 : Form
    {
        Bitmap firstBitmap;
        Bitmap bitmap;

        Bitmap histoBitmap;

        Image image;

        int newWidth, newHeight;
        int HISTO_WIDTH = 256, HISTO_HEIGHT = 240;

        int[,] grayArray;
        

        public Form1()
        {
            InitializeComponent();

            setFixedForm();
        }

        private void setFixedForm()
        {
            // Define the border style of the form to a dialog box.
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;

            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;

            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // interpolation
        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            base.OnPaint(pe);
        }


        // open button.
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Load Image...";
            ofd.Filter = "All Files(*.*) |*.*| Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
            ofd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

            

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = ofd.FileName;
                image = Image.FromFile(filename);

                firstBitmap = new Bitmap(image);
                Bitmap grayBitmap = new Bitmap(image);
                
                // picturebox initialize - important!!
                pictureBox1.Image = null;

                label1.Text = image.Width + " X " + image.Height + " px";

                textBox1.Text = "" + image.Width;
                textBox2.Text = "" + image.Height;

                // convert color to gray.
                bitmap = copy2darray(grayBitmap);

                // first image = convert color to gray.
                firstBitmap = copy2darray(firstBitmap);

                // display image.
                displayImage(bitmap);

                // trackbar initialize
                trackBar1.Value = 0;
                trackBar1.Invalidate();

                label3.Text = "0";

            }
        }

        // convert gray image.
        private Bitmap copy2darray(Bitmap bitmap)
        {
            int x, y, brightness;
            Color color;
            grayArray = new int[bitmap.Height, bitmap.Width];

            for (y = 0; y < bitmap.Height; y++)
            {
                for (x = 0; x < bitmap.Width; x++)
                {
                    color = bitmap.GetPixel(x, y);
                    brightness = (int)(0.299 * color.R + 0.587 * color.G + 0.114 * color.B);
                    grayArray[y, x] = brightness;
                }
            }

            for (y = 0; y < bitmap.Height; y++)
            {
                for (x = 0; x < bitmap.Width; x++)
                {
                    color = Color.FromArgb(grayArray[y, x], grayArray[y, x], grayArray[y, x]);
                    bitmap.SetPixel(x, y, color);
                }
            }

            return bitmap;
        }

        private void displayImage(Bitmap bitmap)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.Image = bitmap;
        }

        // save button.
        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save dialog";
            sfd.OverwritePrompt = true;
            //기존의 파일이 있으면 업데이트 하겠다라는 의미
            sfd.Filter = "Png File(*.png) |*.png| Bitmap File(*.bmp) | *.bmp |Jpeg File(*.jpg) | *.jpg ";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string strFilename = sfd.FileName;
                string strLowerFilename = strFilename.ToLower();
                Bitmap bm = new Bitmap(pictureBox1.Image);
                bm.Save(strLowerFilename);
            }
        }

        // histo equalization.
        private void button5_Click(object sender, EventArgs e)
        {
            int x, y, sum;
            double scale;

            int[] histogram = new int[256];
            int[] LUT = new int[256];

            int numberOfPixels;

            grayArray = new int[bitmap.Height, bitmap.Width];
            bitmap = copy2darray(new Bitmap(pictureBox1.Image));

            histogram.Initialize();
            for (y=0; y<bitmap.Height; y++)
            {
                for (x=0; x<bitmap.Width; x++)
                {
                    histogram[grayArray[y, x]]++;
                }
            }

            numberOfPixels = bitmap.Width * bitmap.Height;

            sum = 0;

            scale = 255.0 / numberOfPixels;

            for (x=0; x<256; x++)
            {
                sum += histogram[x];
                LUT[x] = (int)(sum * scale + 0.5);
            }

            /* transfer new image */
            for (y = 0; y<bitmap.Height; y++)
            {
                for (x=0; x<bitmap.Width; x++)
                {
                    grayArray[y, x] = LUT[grayArray[y, x]];
                }
            }

            Color color;

            for (y = 0; y < bitmap.Height; y++)
            {
                for (x = 0; x < bitmap.Width; x++)
                {
                    color = Color.FromArgb(grayArray[y, x], grayArray[y, x], grayArray[y, x]);
                    bitmap.SetPixel(x, y, color);
                }
            }

            pictureBox1.Image = bitmap;
        }

        // fuzzy stretching.
        private void button6_Click(object sender, EventArgs e)
        {
            int Xmean, Xmin = 255, Xmax = 0, Dmin, Dmax, Imax, Imin, Imid, a, x, y, r = 0, g = 0, b = 0;
            double I_value, r_value, percent = 0.05;
            Color color;

            grayArray = new int[bitmap.Height, bitmap.Width];
            copy2darray(bitmap);

            for (x = 0; x < bitmap.Width; x++)
            {
                for (y = 0; y < bitmap.Height; y++)
                {
                    color = bitmap.GetPixel(x, y);

                    r += color.R;
                    g += color.G;
                    b += color.B;

                    if (Xmin > (color.R + color.G + color.B) / 3)
                    {
                        Xmin = ((color.R + color.G + color.B) / 3);
                    }
                    if (Xmax < (color.R + color.G + color.B) / 3)
                    {
                        Xmax = (color.R + color.G + color.B) / 3;
                    }
                }
            }
            r = r / (bitmap.Height * bitmap.Width);
            g = g / (bitmap.Height * bitmap.Width);
            b = b / (bitmap.Height * bitmap.Width);

            Xmean = (r + g + b) / 3;
            Dmax = Xmax - Xmean;
            Dmin = Xmean - Xmin;

            if (Xmean > 128)
            {
                a = 255 - Xmean;
            }
            else if (Xmean <= Dmin) a = Dmin;
            else if (Xmean >= Dmax) a = Dmax;
            else
            {
                a = Xmean;
            }
            Imax = Xmean + a;
            Imin = Xmean - a;
            Imid = (Imax + Imin) / 2;


            if (Imin != 0) percent = (double)Imin / (double)Imax;
            I_value = (Imid - Imin) * percent + Imin;
            r_value = -(Imax - Imid) * percent + Imax;

            int alpha = (int)I_value;
            int beta = (int)r_value;

            int[] histogram = new int[256];
            int[] LUT = new int[256];

            histogram.Initialize();

            for (y = 0; y < bitmap.Height; y++)
            {
                for (x = 0; x < bitmap.Width; x++)
                {
                    histogram[grayArray[y, x]]++;
                }
            }

            for (x = 0; x < alpha; x++) LUT[x] = 0;
            for (x = 255; x > beta; x--) LUT[x] = 255;
            for (x = alpha; x <= beta; x++)
            {
                LUT[x] = (int)((x - alpha) * 255.0 / (beta - alpha));
            }

            for (y = 0; y < bitmap.Height; y++)
            {
                for (x = 0; x < bitmap.Width; x++)
                {
                    grayArray[y, x] = LUT[grayArray[y, x]];
                }
            }

            for (y = 0; y < bitmap.Height; y++)
            {
                for (x = 0; x < bitmap.Width; x++)
                {
                    color = Color.FromArgb(grayArray[y, x], grayArray[y, x], grayArray[y, x]);
                    bitmap.SetPixel(x, y, color);
                }
            }
            
            pictureBox1.Image = bitmap;
        }

        // original image.
        private void button7_Click(object sender, EventArgs e)
        {
            // grayArray initialize.
            grayArray = new int[image.Height, image.Width];

            // bitmap initialize.
            bitmap = new Bitmap(image);
            bitmap = copy2darray(bitmap);
            
            // textBox initialize.
            textBox1.Text = "" + image.Width;
            textBox2.Text = "" + image.Height;

            // pictureBox initialize
            pictureBox1.Image = bitmap;

            // trackbar initialize
            trackBar1.Value = 0;
            trackBar1.Invalidate();

            label3.Text = "0";
        }

        // view histogram
        private void button4_Click(object sender, EventArgs e)
        {
            if (image == null) return;
            int x, y;
            Color color;
            histoBitmap = new Bitmap(HISTO_WIDTH, HISTO_HEIGHT);
            int[] histogram = new int[256];

            bitmap = new Bitmap(pictureBox1.Image);
            copy2darray(bitmap);

            // histogram 배열에 밝기의 개수를 저장한다.
            for (y = 0; y < bitmap.Height; y++)
            {
                for (x = 0; x < bitmap.Width; x++)
                {
                    histogram[grayArray[y, x]]++;
                }
            }
            int max_cnt = 0; // 가장 많은 픽셀의 수.

            // 히스토그램의 x축은 0부터 255까지이므로.
            for (x = 0; x < HISTO_WIDTH; x++)
            {
                if (histogram[x] > max_cnt) max_cnt = histogram[x];

            }

            // 아래 for문은 histogram의 배경을 그리는 부분이다.
            for (x = 0; x < HISTO_WIDTH; x++)
            {
                for (y = 0; y < HISTO_HEIGHT; y++)
                {
                    color = Color.FromArgb(125, 125, 125);
                    histoBitmap.SetPixel(x, y, color);
                }

            }

            // 아래 for문은 histogram의 y축을 그리는 부분이다.

            // y축 = 히스토그램 개수 * 히스토그램 높이 / 최대개수.
            for (x = 0; x < HISTO_WIDTH; x++)
            {
                double dHeight = (double)histogram[x] * (HISTO_HEIGHT - 1) / (double)max_cnt;
                for (y = 0; y < (int)dHeight; y++)
                {
                    color = Color.FromArgb(0, 0, 0);
                    histoBitmap.SetPixel(x, (HISTO_HEIGHT - 1) - y, color);
                }
            }

            
            Form2 popup = new Form2();
            popup.setHistoBitmap(histoBitmap);
            
            popup.Show();
            popup.drawHistogram();

        }
    

        // resize image
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                newWidth = Int32.Parse(textBox1.Text);
                if (newWidth == 0)
                {
                    MessageBox.Show("가로길이는 0이상이어야 합니다.", "Warning");
                }
                else
                {
                    pictureBox1.Size = new Size(512, 512);

                    newHeight = (image.Height * newWidth) / image.Width;
                    textBox2.Text = "" + newHeight;

                    Size size = new Size(newWidth, newHeight);

                    bitmap = new Bitmap(pictureBox1.Image, size);
                    copy2darray(bitmap);

                    label1.Text = newWidth + " X " + newHeight + " px";
                    pictureBox1.Image = bitmap;
                }
            }
        }

        // 보간법 적용하기. interpolation - highqualitybicubic.
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label3.Text = trackBar1.Value.ToString();

            
            Bitmap bm = contrast(bitmap, trackBar1.Value);
            
            pictureBox1.Image = bm;
        }

        // contrast
        public Bitmap contrast(Bitmap sourceBitmap, int threshold)
        {
            double contrastLevel = Math.Pow((100.0 + threshold) / 100.0, 2);
            int brightness;
            double temp;

            Color color;

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    temp = ((((grayArray[y,x] / 255.0) - 0.5) * contrastLevel) + 0.5) * 255.0;

                    if (temp > 255) temp = 255;
                    if (temp < 0) temp = 0;

                    brightness = (int)temp;
                    color = Color.FromArgb(brightness, brightness, brightness);
                    bitmap.SetPixel(x, y, color);
                }
            }
            
            return bitmap;
        }


    }
}
