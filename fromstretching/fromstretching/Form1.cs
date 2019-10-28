using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fromstretching
{
    public partial class Form1 : Form
    {
        Image image;

        Bitmap colorBitmap;
        Bitmap grayBitmap;
        Bitmap histoBitmap;

        Graphics gr;

        const int HISTO_WIDTH = 256;
        const int HISTO_HEIGHT = 240;

        int[,] grayArray;

        int[] histogram = new int[256];
        int[] stretchHistogram = new int[256];

        private Bitmap buffer; // 전체 bitmap.

        public Form1()
        {
            InitializeComponent();
            setShadowBitmap();
        }

        private void setShadowBitmap()
        {
            // buffer 변수는 전체 bitmap을 저장하는 변수.
            buffer = new Bitmap(ClientSize.Width, ClientSize.Height);
            gr = Graphics.FromImage(buffer);
            gr.Clear(BackColor);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filter = "All Files(*.*) |*.*| Bitmap File(*.bmp) |*.bmp| Jpeg File(*.*) |*.jpg";

            openFileDialog1.Title = "영상 파일 열기";
            openFileDialog1.Filter = filter;

            gr = CreateGraphics();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                image = Image.FromFile(filename);

                // 컬러 영상을 colorBitmap 객체에 저장.
                colorBitmap = new Bitmap(image);

                // 그레이 영상을 grayBitmap 객체에 저장.
                grayBitmap = new Bitmap(image);
                this.ClientSize = new Size(image.Width + 30 + HISTO_WIDTH, (image.Height > HISTO_HEIGHT) ? 2 * image.Height + 10 + menuStrip1.Height : 2 * HISTO_HEIGHT + 10 + menuStrip1.Height);
                setShadowBitmap();

                // 컬러 영상 그리기
                //gr.DrawImage(image, 10, 0, image.Width, 10 + image.Height);

                copy2darray();
            }
            Refresh();
        }

        private void copy2darray()
        {
            int x, y, brightness;
            Color color;
            grayArray = new int[image.Width, image.Height];

            for (y = 0; y < image.Height; y++)
            {
                for (x = 0; x < image.Width; x++)
                {
                    color = colorBitmap.GetPixel(x, y);
                    brightness = (int)(0.299 * color.R + 0.587 * color.G + 0.114 * color.B);
                    grayArray[y, x] = brightness;
                }
            }

            displayArray();
        }

        private void displayArray()
        {
            int x, y;
            Color color;

            for (y = 0; y < image.Height; y++)
            {
                for (x = 0; x < image.Width; x++)
                {
                    color = Color.FromArgb(grayArray[y, x], grayArray[y, x], grayArray[y, x]);
                    grayBitmap.SetPixel(x, y, color);
                }
            }
            gr.DrawImage(grayBitmap, 10, 10, image.Width, image.Height);
            viewHistogram(image.Width + 20, 10);
        }

        private void displayArray(int leftTopX, int leftTopY)
        {
            int x, y;
            Color color;

            for (y = 0; y < image.Height; y++)
            {
                for (x = 0; x < image.Width; x++)
                {
                    color = Color.FromArgb(grayArray[y, x], grayArray[y, x], grayArray[y, x]);
                    grayBitmap.SetPixel(x, y, color);
                }
            }

            gr.DrawImage(grayBitmap, leftTopX, leftTopY, grayBitmap.Width, grayBitmap.Height);
        }

        private void viewHistogram(int leftTopX, int leftTopY)
        {
            int x, y;
            Color color;
            Bitmap histoBitmap = new Bitmap(HISTO_WIDTH, HISTO_HEIGHT);
            int[] histogram = new int[256];

            for (y = 0; y < image.Height; y++)
            {
                for (x = 0; x < image.Width; x++)
                {
                    histogram[grayArray[y, x]]++;
                }
            }
            int max_cnt = 0;
            for (x = 0; x < HISTO_WIDTH; x++)
            {
                if (histogram[x] > max_cnt) max_cnt = histogram[x];

            }

            for (x = 0; x < HISTO_WIDTH; x++)
            {
                for (y = 0; y < HISTO_HEIGHT; y++)
                {
                    color = Color.FromArgb(125, 125, 125);
                    histoBitmap.SetPixel(x, y, color);
                }

            }

            for (x = 0; x < HISTO_WIDTH; x++)
            {
                double dHeight = (double)histogram[x] * (HISTO_HEIGHT - 1) / (double)max_cnt;
                for (y = 0; y < (int)dHeight; y++)
                {
                    color = Color.FromArgb(0, 0, 0);
                    histoBitmap.SetPixel(x, (HISTO_HEIGHT - 1) - y, color);
                }
            }

            gr.DrawImage(histoBitmap, leftTopX, leftTopY);

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void stretchingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x, y;
            int alpha = 0, beta = 255;
            int[] histogram = new int[256];
            int[] LUT = new int[256];

            histogram.Initialize();
            for (y = 0; y < image.Height; y++)
            {
                for (x = 0; x < image.Width; x++)
                {
                    histogram[grayArray[y, x]]++;
                }
            }

            for (x = 0; x < 256; x++)
            {
                if (histogram[x] != 0)
                {
                    alpha = x;
                    break;
                }
            }

            for (x = 255; x >= 0; x--)
            {
                if (histogram[x] != 0)
                {
                    beta = x;
                    break;
                }
            }

            for (x = 0; x < alpha; x++) LUT[x] = 0;
            for (x = 255; x > beta; x--) LUT[x] = 255;

            for (x = alpha; x <= beta; x++)
            {
                LUT[x] = (int)((x - alpha) * 255.0 / (beta - alpha));

            }

            for (y = 0; y < image.Height; y++)
            {
                for (x = 0; x < image.Width; x++)
                {
                    grayArray[y, x] = LUT[grayArray[y, x]];
                }
            }

            displayArray(10, image.Height + 20);
            viewHistogram(image.Width + 20, image.Height + 20);
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            gr.DrawImage(buffer, 0, menuStrip1.Height);
        }

        private void opToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x, y;
            const int Value = 35;
            int[] LUT = new int[256];

            for (int index = 0; index < 256; index++)
            {
                int newValue = index + Value;
                if (newValue > 255) newValue = 255;
                LUT[index] = newValue;
            }

            for (y = 0; y < grayBitmap.Height; y++)
            {
                for (x = 0; x < grayBitmap.Width; x++)
                {
                    grayArray[y, x] = LUT[grayArray[y, x]];
                }
            }
            displayArray();
            Refresh();
        }

        private void opToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int x, y;
            const double Value = 1.5;
            int[] LUT = new int[256];

            for (int index = 0; index < 256; index++)
            {
                int newValue = (int)(index * Value);
                if (newValue > 255) newValue = 255;
                LUT[index] = newValue;
            }

            for (y = 0; y < grayBitmap.Height; y++)
            {
                for (x = 0; x < grayBitmap.Width; x++)
                {
                    grayArray[y, x] = LUT[grayArray[y, x]];
                }
            }
            displayArray();
            Refresh();
        }

        private void opToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int x, y;
            const int Value = 35;
            int[] LUT = new int[256];

            for (int index = 0; index < 256; index++)
            {
                int newValue = index - Value;
                if (newValue < 0) newValue = 0;
                LUT[index] = newValue;
            }

            for (y = 0; y < grayBitmap.Height; y++)
            {
                for (x = 0; x < grayBitmap.Width; x++)
                {
                    grayArray[y, x] = LUT[grayArray[y, x]];
                }
            }
            displayArray();
            Refresh();
        }

        private void opToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            int x, y;
            const double Value = 1.5;
            int[] LUT = new int[256];

            for (int index = 0; index < 256; index++)
            {
                int newValue = (int)(index / Value);
                if (newValue < 0) newValue = 0;
                LUT[index] = newValue;
            }

            for (y = 0; y < grayBitmap.Height; y++)
            {
                for (x = 0; x < grayBitmap.Width; x++)
                {
                    grayArray[y, x] = LUT[grayArray[y, x]];
                }
            }
            displayArray();
            Refresh();
        }

        private void gamma1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x, y;
            int[] LUT = new int[256];
            const double GAMMA = 2.5;
            for (int index = 0; index < 256; index++)
            {
                LUT[index] = (int)(255.0 * Math.Pow((double)index / 255.0, 1.0 / GAMMA));
            }

            for (y = 0; y < grayBitmap.Height; y++)
            {
                for (x = 0; x < grayBitmap.Width; x++)
                {
                    grayArray[y, x] = LUT[grayArray[y, x]];
                }
            }

            displayArray();
            Refresh();
        }

        private void gamma2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x, y;
            int[] LUT = new int[256];
            const double GAMMA = 0.5;
            for (int index = 0; index < 256; index++)
            {
                LUT[index] = (int)(255.0 * Math.Pow((double)index / 255.0, 1.0 / GAMMA));
            }

            for (y = 0; y < grayBitmap.Height; y++)
            {
                for (x = 0; x < grayBitmap.Width; x++)
                {
                    grayArray[y, x] = LUT[grayArray[y, x]];
                }
            }

            displayArray();
            Refresh();
        }
    }
}
