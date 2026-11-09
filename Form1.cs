using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CreateFoldersByNames
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string _Location = "";
        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {
                btnCreate.Enabled = true;
                this._Location = folderBrowserDialog1.SelectedPath + "\\FolderCreator";
                label1.Visible = true;
                lblLocation.Text = this._Location;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("You cannot use it when textbox is empty!","Type the folders name!");
                return;
            }
            Directory.CreateDirectory(_Location);
            string[] FoldersName;

            if (rbRow.Checked)
               FoldersName= textBox1.Text.Split('\n');
            else
               FoldersName = textBox1.Text.Split(' ', '\n');


            foreach (var item in FoldersName)
            {
                string path = _Location + "\\" + item;
                Directory.CreateDirectory(path);
            }
            MessageBox.Show("Created successfully!");
            textBox1.Text = "";
        }

        private void rbArabic_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.RightToLeft=RightToLeft.Yes;
            SetLanguagePlaceHolder();
        }

        private void rbEnglish_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.RightToLeft = RightToLeft.No;
            SetLanguagePlaceHolder();
        }
        void SetLanguagePlaceHolder()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || textBox1.ForeColor==Color.Gray)
            {
                if (rbArabic.Checked)
                {
                    textBox1.Text = "...اكتب اسم الملفات";
                }
                else
                {
                    textBox1.Text = "Write File Names...";
                    textBox1.ForeColor = Color.Gray;
                }

            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.ForeColor == Color.Gray && !char.IsControl(e.KeyChar))
            {
                textBox1.Clear();
                textBox1.ForeColor = Color.Black;
            }
            else
                SetLanguagePlaceHolder();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            SetLanguagePlaceHolder();
            textBox1.ForeColor = Color.Gray;
            textBox1.SelectionLength = 0;
            textBox1.SelectionStart = 0;
        }
    }
}
