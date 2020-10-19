using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NqueenSolver
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch Time = new Stopwatch();
            Time.Start();
            Node node = new AstartTree().Run();
            Time.Stop();
            MessageBox.Show("Runnig time : "+ Time.Elapsed);
            new Board(node).ShowDialog();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Data.ChessSize = (int)numericUpDown1.Value;
        }
    }
}
