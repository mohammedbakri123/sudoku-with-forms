using System;
using System.Drawing;
using System.Windows.Forms;

namespace sudoku_with_forms
{



    public partial class Form1 : Form
    {
        private SudokuGame sudokuGame;

        public Form1()
        {
            InitializeComponent();
            sudokuGame = new SudokuGame();
            PopulateTableLayoutPanel();
            MapLabelsToGrid();
        }

        private void PopulateTableLayoutPanel()
        {
            tableLayoutPanel1.Controls.Clear();

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    // Create a local copy of row and col
                    int currentRow = row;
                    int currentCol = col;

                    Label lbl = new Label
                    {
                        Text = "",
                        TextAlign = ContentAlignment.MiddleCenter,
                        BorderStyle = BorderStyle.FixedSingle,
                        Dock = DockStyle.Fill,
                        Font = new Font("Arial", 16)
                    };

                    lbl.Click += (s, e) => Label_Click(s, e, currentRow, currentCol);
                    tableLayoutPanel1.Controls.Add(lbl, col, row);
                }
            }
        }

        private void MapLabelsToGrid()
        {
            for (int row = 0; row < tableLayoutPanel1.RowCount; row++)
            {
                for (int col = 0; col < tableLayoutPanel1.ColumnCount; col++)
                {
                    var control = tableLayoutPanel1.GetControlFromPosition(col, row);
                    if (control is Label lbl)
                    {
                        lbl.Text = sudokuGame.Matrix[row, col] == 0 ? "" : sudokuGame.Matrix[row, col].ToString();
                        lbl.ForeColor = sudokuGame.Matrix[row, col] == 0 ? Color.Black : Color.Blue;
                    }
                }
            }
        }

        private void Label_Click(object sender, EventArgs e, int row, int col)
        {
            Label clickedLabel = sender as Label;

            if (!string.IsNullOrEmpty(clickedLabel.Text))
            {
                MessageBox.Show("Cell already filled!", "Invalid Move", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (frmSelectNumber selectNumberForm = new frmSelectNumber())
            {
                if (selectNumberForm.ShowDialog() == DialogResult.OK)
                {
                    int selectedNumber = selectNumberForm.SelectedNumber;

                    if (sudokuGame.IsValid(row, col, selectedNumber))
                    {
                        sudokuGame.Matrix[row, col] = selectedNumber;
                        clickedLabel.Text = selectedNumber.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Invalid move. Try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            sudokuGame.Reset();
            MapLabelsToGrid();
        }
    }



}
