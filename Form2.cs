using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment
{
    public partial class Form2 : Form
    {
        public Graphics gr;

        Bitmap bitmap;
        Bitmap buffer;
        
        public Form2()
        {
            InitializeComponent();

            // Define the border style of the form to a dialog box.
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;

            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;

            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;

            gr = CreateGraphics();

            setShadowBitmap();
        }

        public void setHistoBitmap(Bitmap bitmap)
        {
            this.bitmap = bitmap;
        }

        public void drawHistogram()
        {
            gr.DrawImage(this.bitmap, 10, 10);
            Refresh();
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            gr.DrawImage(buffer, 0, 0);
        }

        private void setShadowBitmap()
        {
            // buffer 변수는 전체 bitmap을 저장하는 변수.
            buffer = new Bitmap(ClientSize.Width, ClientSize.Height);
            gr = Graphics.FromImage(buffer);
            gr.Clear(BackColor);
        }
    }
}
