using System;
using System.CodeDom;
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
                    //uses streamreader function to read the text from the .txt file 
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

        //create a new file
        //the current file will be over written, so ask the user if they would like to beforehand
        //future feature: automatically open a new file if the current work is saved
        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            if(textBox1.Text != "") {
                var newFile = MessageBox.Show("Do you want to create a new file? This will delete any unsaved work.", "Create a new file?", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (newFile == DialogResult.OK) {
                    textBox1.Text = null;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        //asks the user where to save the current text
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                StreamWriter saveFile = new StreamWriter(saveFileDialog1.FileName);
                saveFile.Write(textBox1.Text);
                saveFile.Close();
            }
        }

        //close the program
        //the user is asked if they want to continue if there is text
        //future feature: close automatically if detected work is saved already
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            if (textBox1.Text != "") {
                var closeFile = MessageBox.Show("Do you want to exit? You will lose unsaved data.", "Close without saving?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (closeFile == DialogResult.Yes) {
                    this.Close();
                }
            } else {
                this.Close();
            }
        }
    }
}
