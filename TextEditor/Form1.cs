using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        //code where the user opens a txt file to load into the textbox
        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                //if file is a .txt file, read the text into the textbox
                if (Path.GetExtension(openFileDialog1.FileName) == ".txt") {
                    String line = null;
                    StreamReader streamReader = new StreamReader(openFileDialog1.FileName);
                    line = streamReader.ReadToEnd();
                    textBox1.Text = line;
                    streamReader.Close();
                } else {
                    //if file is not a .txt file, tell the user
                    MessageBox.Show("This is not a .txt file. Please select a .txt file.", "Error when choosing .txt file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
