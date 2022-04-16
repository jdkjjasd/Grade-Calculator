using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

/**
 * Programmer: Miao Sun
 * Date: 5/16/20
 * Program: Project #6
 * Files: Student.cs
 */

namespace Grade_Calculator
{
    class Student
    {
        //set variable
        private String studentName = "";
        private string studentClass = "";
        private string studentSemester = "";
        private string index = "";
        private string grade = "";
        private int color = 0; //color 1=black;2=orange;3=red


        private double average = 0.0;
        private int[] scores = new int[8];

        //reset all variable as needed
        public void reset()
        {
            studentName = "";
            studentClass = "";
            studentSemester = "";
            index = "";
            grade = "";
            color = 0;
            average = 0.0;
            Array.Clear(scores, 0, scores.Length);

        }

        public void setName(string name)
        {
            studentName = name;
        }

        public void setClass(string c)
        {
            studentClass = c;
        }

        public void setSemester(string s)
        {
            studentSemester = s;
        }

        public void setScores(int[] s)
        {
            scores = s;
        }

        public void setIndex(string i)
        {
            index = i;
        }

        public string getName()
        {
            return studentName;
        }

        public string getClass()
        {
            return studentClass;
        }


        public string getSemester()
        {
            return studentSemester;
        }

        public string getIndex()
        {
            return index;
        }

        public int[] getScore()
        {
            return scores;
        }

        public string getGrade()
        {
            calAverage();
            return grade;
        }

        public int getColor()
        {
            return color;
        }
        

        //get average score then set grade and color
        private void calAverage()
        {
            average = 0.0;

            foreach(int i in scores)
            {
                average += i;
            }

            average /= 8;
            
            //ABC black,D orange,F red.
            if(average>89)
            {
                grade = "A";
                color = 1;
            }
            else if(average>79)
            {
                grade = "B";
                color = 1;
            }
            else if(average >69)
            {
                grade = "C";
                color = 1;
            }
            else if(average > 59)
            {
                grade = "D";
                color = 2;
            }
            else
            {
                grade = "F";
                color = 3;
            }

        }




    }
    
}

