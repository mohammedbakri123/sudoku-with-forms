using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sudoku_with_forms
{
    public partial class frmSelectNumber : Form
    {

        public int SelectedNumber { get; private set; }

        public frmSelectNumber()
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                SelectedNumber = int.Parse(button.Text);
                DialogResult = DialogResult.OK;
            }
        }

       
    }
}
