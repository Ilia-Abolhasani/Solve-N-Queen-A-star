using System;
using System.Drawing;
using System.Windows.Forms;

namespace NqueenSolver
{
    public partial class Board : Form
    {
        PictureBox[,] Cells;        
        public Board(Node node)
        {            
            InitializeComponent();                                   
            CellCreate();            
            for (int i = 0; i < Data.ChessSize; i++)
                Cells[i, node.Position[i] - 1].Image = global::NqueenSolver.Properties.Resources.Qeen;
        }
        public void CellCreate()
        {
            Cells = new PictureBox[Data.ChessSize, Data.ChessSize];
            for (int j = 0; j < Data.ChessSize; j++)
                for (int i = 0; i < Data.ChessSize; i++)            
                {
                    Cells[i, j] = new PictureBox();
                    Cells[i, j].BorderStyle = BorderStyle.FixedSingle;
                    this.panel3.Controls.Add(Cells[i,j]);
                    Cells[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                    if ((i%2==0&&j%2==1)||(i%2==1&&j%2==0))
                        Cells[i,j].BackColor= Data.ColorWhite;
                    else
                        Cells[i, j].BackColor = Data.ColorBlack;
                }
            FixSize();
        }
        public void FixSize()
        {
            int Width = this.panel3.Size.Width / Data.ChessSize;
            int Height = this.panel3.Size.Height / Data.ChessSize;
            for (int j = 0; j < Data.ChessSize; j++)
                for (int i = 0; i < Data.ChessSize; i++)
                {
                    Cells[i, j].Size = new Size(Width, Height);
                    Cells[i, j].Location = new Point(Width * i, Height * j);
                }
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            FixSize();
        }        
        private int Abstract(int Input)
        {
            return (Input < 0) ? Input * -1 : Input;
        }
    }
}
