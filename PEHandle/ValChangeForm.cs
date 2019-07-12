using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PEHandle
{
    public partial class ValChangeForm : Form
    {
        public string Value { get; set; }

        public int Type { get; set; }

        public int MaxLength { get; set; }

        public ValChangeForm()
        {
            InitializeComponent();
        }

        public ValChangeForm(string val)
        {
            InitializeComponent();
            Value = val;
        }

        private void ValChangeForm_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = Value;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {

            //Check Value
            if (textBox1.Text == "error")
            {
                this.DialogResult = System.Windows.Forms.DialogResult.None;

            }
            else
            {
                Value = textBox1.Text;
            }
            return;

        }



    }
}
