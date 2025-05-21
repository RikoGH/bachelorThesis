using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BachelorProject
{
    public partial class TextInputForm : Form
    {
        public string EnteredText { get; private set; }
        public TextInputForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            EnteredText = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
