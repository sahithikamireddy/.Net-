


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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /* The method Form1_load is used to load the data of a file named file.txt to list named "list"*/

        private void Form1_Load(object sender, EventArgs e)
        {
            // var logFile;
            // var loglist = null;// StreamReader sr = new StreamReader("C:\\Users\\dell\\source\\repos\\WindowsFormsApp1\\bin\\Debug\\data1.txt");
            List<string> list = new List<string>();/*creating list of strings*/
            list = LoadList();/* loads all the strings into list*/
            radioButton1.AutoCheck = true;/*makes all the radiobuttons unchecked when form is loaded*/
            radioButton2.AutoCheck = true;
            radioButton3.AutoCheck = true;
            radioButton4.AutoCheck = true;
            radioButton5.AutoCheck = true;
            radioButton6.AutoCheck = true;
            radioButton7.AutoCheck = true;
            radioButton8.AutoCheck = true;
            //  radioButton1.Checked = false;




        }

        /*the method loadlist is used to load the logfile to log list and it returns loglist */
        public List<string> LoadList()
        {
            var logFile = File.ReadAllLines("C:\\Users\\dell\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\bin\\Debug\\data1.txt");/*path of the given text file*/
            var logList = new List<string>(logFile);/*Creating loglist*/
            return logList;
        }

        /* this method refers to display the list of all names, officenumbers and 
         * telephone numbers 
         */

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Visible = false;/*here all the visibility of buttos made false as there is no need of buttons here*/
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            if (radioButton1.Checked)
            {
                List<string> list = new List<string>();
                list = LoadList();
                // var logList = new List<string>(logFile);
                for (int i = 0; i < list.Count; i++)
                    listBox1.Items.Add(list[i]);/*adding elements of list into listbox*/

               
                
                
               
                
                    }
        }

        /* The method is to add an entry that is a name, officenum and telephone 
         * number in the list. 
         */

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();/*clearing all the elements before printing elements into listbox*/
            if (radioButton2.Checked)
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                button1.Visible = true;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;


            }

        }
        /* The method search for the name and prints the deatils wrt the office number */
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Visible = true;
            textBox3.Visible = false;
            label2.Visible = true;
            label3.Visible = false;


            textBox1.Visible = false;
            label1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = true;
            //List<string> addlist = new List<string>();
            //addlist = LoadList();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        /* This method refers to the button "GO" display the list of all names, officenumbers and 
         * telephone numbers and add an entry to the listbox
         */
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if ((textBox1.Text == null || string.IsNullOrWhiteSpace(textBox1.Text)) || (textBox2.Text == null || string.IsNullOrWhiteSpace(textBox2.Text)) || (textBox3.Text == null || string.IsNullOrWhiteSpace(textBox3.Text)))

            { listBox1.Items.Add("Error: Give any text in the textbox!!"); }/*if the textbox is empty or consists of any whitespaces then error message is displayed in the listbox*/
            else
            {
                List<string> addlist = new List<string>();
                addlist = LoadList();
                //giving names for all textboxes*/
                string Name = textBox1.Text;
                string off_no = textBox2.Text;
                string telephn = textBox3.Text;
                /*adding name,officenumber,telephone number*/

                addlist.Add(Name);
                addlist.Add(off_no);
                addlist.Add(telephn);

                for (int i = 0; i < addlist.Count; i++)
                {
                    listBox1.Items.Add(addlist[i]);/*adding addlist elements into listbox*/
                }
                //addlist.Clear();

                string file_name3 = "C:\\Users\\dell\\source\\repos\\assignment_2\\assignment_2\\bin\\Debug\\data1.txt";
                //  File.WriteAllLines(file_name3, addlist);
                using (StreamWriter writer = new StreamWriter(file_name3))
                {
                    for (int i = 0; i < addlist.Count; i++)
                    {
                        writer.Write(addlist[i]);
                    }

                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                addlist.Clear();
            }

        }

        /* The method search for the name and prints the deatils wrt the name*/

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                textBox2.Visible = false;
                textBox3.Visible = false;
                label2.Visible = false;
                label3.Visible = false;

                textBox1.Visible = true;
                label1.Visible = true;
                button1.Visible = false;
                button5.Visible = false;
                button3.Visible = false;
                button2.Visible = true;
                button4.Visible = false;
                //   List<string> addlist = new List<string>();
                //   addlist = LoadList();


                //if (addlist.Contains(Name))

                //{      
                //       int index = addlist.IndexOf(Name);
                //       listBox1.Items.Add(addlist[index]);
                //       listBox1.Items.Add(addlist[index++]);
                //       listBox1.Items.Add(addlist[index++]);
                //}






            }

        }
        /* The method refers to the button search for the name and prints the deatils wrt the name */
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string line;
            string Name = textBox1.Text;
            List<string> addlist = new List<string>();
            addlist = LoadList();
            



            //if(addlist.Contains(Name))
            //{
            //    int index = addlist.IndexOf(Name);
            //    //listBox1.Items.Add(index);
            //    //listBox1.Items.Add(++index);
            //    //listBox1.Items.Add(++index);
            //    listBox1.Items.Add(addlist[index]);
            //    // listBox1.Items.Add(index);
            //    listBox1.Items.Add(addlist[++index]);
            //    // listBox1.Items.Add(index++);
            //    listBox1.Items.Add(addlist[++index]);
            //    // listBox1.Items.Add(index++);
            //    index = 0;
            //}
            /*searching the name given in textbox*/

            foreach (var a in addlist)
            {
                
                addlist = LoadList();
                
                 if (a == Name)/*if condition to search the given name*/
                {

                    int index = addlist.IndexOf(Name);
                    listBox1.Items.Add(addlist[index]);/*preincrementing the searched element to obtain office no telephone no along with the name*/
                    listBox1.Items.Add(addlist[++index]);
                    listBox1.Items.Add(addlist[++index]);
                    // index = 0;
                    
                }

            }
            

        }
        /* The method refers to the button search for the name and prints the deatils wrt the office number*/

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (textBox2.Text == null || string.IsNullOrWhiteSpace(textBox2.Text))
            { listBox1.Items.Add("Error: Give any text in the textbox!!"); }
            else
            {


                string off_no = textBox2.Text;
                //List<string> ofce = new List<string>();
                //list 
                List<string> addlist = new List<string>();
                addlist = LoadList();
                int m = 0;
                foreach (var a in addlist)
                {
                    int index;// = addlist.IndexOf(a);/*conditions for searching office no's*/
                    if (a == off_no)
                    {
                        index = m;
                        listBox1.Items.Add("successful");
                        listBox1.Items.Add(addlist[index - 1]);
                        listBox1.Items.Add(addlist[index]);
                        listBox1.Items.Add(addlist[index + 1]);
                        //index = 0;
                    }
                    m = m + 1;
                }
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = true;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = true;
        }
       
        /* The method refers to the button search for the name and prints the deatils wrt the telephone number */

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (textBox3.Text == null || string.IsNullOrWhiteSpace(textBox3.Text))
            { listBox1.Items.Add("Error: Give any text in the textbox!!");
            }
            else
            {
                string tel_no = textBox3.Text;
            List<string> addlist = new List<string>();
            addlist = LoadList();
                foreach (var a in addlist)
                {
                    if (a == tel_no)/*if condition for searching telephone number*/
                    {
                        //   listBox1.Items.Add("successful");

                        int index = addlist.IndexOf(tel_no);
                        listBox1.Items.Add(addlist[index - 2]);
                        listBox1.Items.Add(addlist[index - 1]);
                        listBox1.Items.Add(addlist[index]);
                        textBox3.Clear();
                        //  listBox1.Items.Add(addlist[index + 1]);
                        // index = 0;
                    }
                }

            }
        }
        /* the method is to change the office number */
        
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = true;

        }

        /* the method refers to button that change the office numvber "change" */
        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string name = textBox1.Text;
            string off_no = textBox2.Text;
            List<string> addlist = new List<string>();
            addlist = LoadList();
             string file_name2 = "C:\\Users\\dell\\source\\repos\\assignment_2\\assignment_2\\bin\\Debug\\data1.txt";
            foreach (var c in addlist.ToList())
            {
                if (c == name)
                {
                    //   listBox1.Items.Add("successful");

                    int index = addlist.IndexOf(name);
                    addlist[index + 1] = off_no;


                }

                //  listBox1.Items.Add(addlist[index + 1]);
                // index = 0;
            }

            //foreach (var b in addlist)
            //{
            //    listBox1.Items.Add(b);
            //    }
            
            //using (StreamWriter w = File.AppendText(file_name2))
            //{
                //for (int i = 0; i < addlist.Count; i++)
                //{
                File.WriteAllLines(file_name2, addlist);
            foreach (var b in addlist)
            {
                listBox1.Items.Add(b);
            }
        
        //w.WriteLine(textBox1.Text);
        //w.WriteLine(textBox2.Text);
        //    //w.WriteLine(textBox3.Text);
        //    w.Close();
        //}

    }

        //private void radioButton7_CheckedChanged(object sender, EventArgs e)
        //{
        //               listBox1.Items.Clear();
        //    List<string> addlist = new List<string>();
        //    addlist = LoadList();
        //    addlist.Sort();
        //    for(int i=0;i<addlist.Count ;i++)
        //    {
        //            listBox1.Items.Add(addlist[i]);
        //    }
        //}

            //this method is used to sort the list with respect to name*/
        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            button5.Visible = false;
            listBox1.Items.Clear();
            List<string> addlist = new List<string>();
            List<string> sort1 = new List<string>();
            addlist = LoadList();
            
            string s;
            int i = 0; int m = 0;
            while (i < addlist.Count)
            {
               s= addlist[i]+" " + addlist[i+1] +" "+ addlist[i+2];
               
                i += 3;
                
                sort1.Add(s);
            }
            sort1.Sort();/*sorting all the strings present in the list*/

            for (i = 0; i < sort1.Count; i++)
            {
                listBox1.Items.Add(sort1[i]);/*adding the sorted elements into listbox*/

            }





        }
        /* this method is usd to quit the application */

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            Application.Exit();/* to exit from the whole application*/

        }

      
    }
}
