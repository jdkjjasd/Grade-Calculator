using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/**
 * Programmer: Miao Sun
 * Date: 5/16/20
 * Program: Project #6
 * Files: Form1.cs
 */

namespace Grade_Calculator
{
    public partial class Form1 : Form
    {
        private Student student = new Student();
        public Form1()
        {
            InitializeComponent();
            this.ControlBox = false;
            openFileDialog1.InitialDirectory = Application.StartupPath;
            reset();//reset when start
        }

        //reset form elements
        public void reset()
        {
            nameLab.Text = "";
            classLab.Text = "";
            semesterLab.Text = "";
            gradeLab.Text="";
            scoresLB.Items.Clear();
            photoPB.Image = null;
        }

        // add scores to listbox
        public void addListbox(int[] i)
        {
            try
            {
                scoresLB.Items.Add("Project1\t\t"+i[0]);
                scoresLB.Items.Add("Project2\t\t" + i[1]);
                scoresLB.Items.Add("Project3\t\t" + i[2]);
                scoresLB.Items.Add("Project4\t\t" + i[3]);
                scoresLB.Items.Add("Project5\t\t" + i[4]);
                scoresLB.Items.Add("Project6\t\t" + i[5]);
                scoresLB.Items.Add("Miderm\t\t\t" + i[6]);
                scoresLB.Items.Add("Final\t\t\t" + i[7]);

            }
            catch(Exception ec)
            {
                MessageBox.Show("wrong score");
            }

        }

        //change label color depents on grade
        public void colorChange(int i)
        {
            switch (i)
            {
                case 1:
                    gradeLab.ForeColor = Color.Black;
                    break;
                case 2:
                    gradeLab.ForeColor = Color.Orange;
                    break;
                case 3:
                    gradeLab.ForeColor = Color.Red;
                    break;
            }

        }

        //exit 
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        //open
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //reset at start
            reset();
            student.reset();

            string path = "";

            //show dialog
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
            }
            else
            {
                reset();
                return;
            }

            
            File rfile = new File();

            //open file and proces
            try
            {
                rfile.readFile(path);
                rfile.procesData(student);
            }
            catch(Exception ec)
            {
                MessageBox.Show("wrong file");
                return;
            }

            //add score to listbox
            addListbox(student.getScore());
            //change label text
            nameLab.Text = student.getName();
            classLab.Text = student.getClass();
            semesterLab.Text = student.getSemester();

            //set image
            try
            {
                photoPB.Image = Image.FromFile(Application.StartupPath + "\\" + student.getIndex());
            }
            catch(Exception ec)
            {
                MessageBox.Show("image not found");
            }

        }

        //get grade
        private void calBt_Click(object sender, EventArgs e)
        {
            

            if (photoPB.Image==null)
            {
                gradeLab.Text = "";
                return;
            }
            else
            {
                gradeLab.Text = student.getGrade();
                colorChange(student.getColor());
            }

        }
    }
}
