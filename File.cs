using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

/**
 * Programmer: Miao Sun
 * Date: 5/16/20
 * Program: Project #6
 * Files: File.cs
 */

namespace Grade_Calculator
{
    class File
    {
        private string rawdata = "";

        //read data from file
        public void readFile(string path)
        {
            
            try
            {
                StreamReader sr = new StreamReader(path);
                rawdata = sr.ReadLine();
                sr.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show("wrong path or file");
                return;
            }
        }

        //proces data
        public void procesData(Student st)
        {
                //split by ,
                string[] data = rawdata.Split(',');
               //add elements to student object
                st.setName(data[0]);
                st.setClass(data[1]);
                st.setSemester(data[2]);
                st.setIndex(data[3]);

                

                int[] sc = new int[8];
                
                for(int i=0;i<8;i++)
                {
                    sc[i] = int.Parse(data[4 + i]);
                    
                }

                st.setScores(sc);


          



        }




    }
}
