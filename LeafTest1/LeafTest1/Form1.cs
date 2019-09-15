using System.Windows.Forms;

namespace LeafTest1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            LeafDrawer.Paint(e.Graphics);
        }
    }
}
