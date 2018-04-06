using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyJobaid.CodeGenerate;

namespace MyJobaid
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnToolStripMenuItemClick(object sender, EventArgs e)
        {
            string strTag = ((ToolStripMenuItem)sender).Tag.ToString().Trim();
            switch (strTag)
            {
                case "CodeGenerate":
                    CodeGenerateForm codeGenerateForm = new CodeGenerateForm();
                    codeGenerateForm.MdiParent = this;
                    codeGenerateForm.Show();
                    break;
                default:
                    break;
            }
        }
    }
}
