using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += new EventHandler(Form1_Load);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String StringConnection = "server=10.158.56.53;uid=csci473g08;pwd=wordpass08;database=csci473g08;";
            using (MySqlConnection MyConnection = new MySqlConnection(StringConnection))
            {
                MyConnection.Open();                    // To open Database Connection
                
                MySqlCommand command = new MySqlCommand(
                    "DROP TABLE IF EXISTS RoomTable, OfficeTable, ClassTable;", MyConnection);      // To drop Tables if already exists
                command.ExecuteNonQuery();

                command = new MySqlCommand(
                    "CREATE TABLE RoomTable(Room integer,Capacity integer,Smart char(1));", MyConnection);      // To Create RoomTable with given parameters
                command.ExecuteNonQuery();

                command = new MySqlCommand(
                    "CREATE TABLE OfficeTable(Teacher char(20),Office integer);", MyConnection);            // To create OfficeTable with given Parameters
                command.ExecuteNonQuery();

                command = new MySqlCommand(
                    "CREATE TABLE ClassTable(Course integer,Section integer,Teacher char(20),Room integer,Time char(5),Days char(5),Enrollment integer);", MyConnection);        //To Create ClassTable with given Parameters
                command.ExecuteNonQuery();

                string fileName1 = "Room.txt";                                        // file name given to a string variable to initialize values for RoomTable
                string textLine1 = "";

                if (System.IO.File.Exists(fileName1) == true)
                {
                    System.IO.StreamReader objReader;
                    objReader = new System.IO.StreamReader(fileName1);                 // reads the the content in the file and stores the data in 3 different variables
                    while ((textLine1 = objReader.ReadLine()) != null)
                    {
                        string[] values = textLine1.Split(',');
                        int col1 = Convert.ToInt32(values[0]);
                        int col2 = Convert.ToInt32(values[1]);
                        char flag = values[2][0];

                        String myCommand = "INSERT into RoomTable values (" + col1 + ", " + col2 + ", '" + flag + "');";        // To Insert the data stored in the variables into RoomTable
                        command = new MySqlCommand(myCommand, MyConnection);
                        command.ExecuteNonQuery();
                    }
                    objReader.Close();          // To close object Reader
                }
                else
                {
                    Console.WriteLine("No File: " + fileName1);
                }

                fileName1 = "Office.txt";                                        // file name given to a string variable
                textLine1 = "";

                if (System.IO.File.Exists(fileName1) == true)
                {
                    System.IO.StreamReader objReader;
                    objReader = new System.IO.StreamReader(fileName1);                 // reads the the content in the file and storing the data in 2 different variables
                    while ((textLine1 = objReader.ReadLine()) != null)
                    {
                        string[] values = textLine1.Split(',');
                        String col1 = values[0];
                        int col2 = Convert.ToInt32(values[1]);

                        String myCommand = "INSERT into OfficeTable values ('" + col1 + "', " + col2 + ");";            // To Insert the data stored in the variables into OfficeTable
                        command = new MySqlCommand(myCommand, MyConnection);
                        command.ExecuteNonQuery();
                    }
                    objReader.Close();
                }
                else
                {
                    Console.WriteLine("No File: " + fileName1);
                }

                fileName1 = "Class.txt";                                        // file name given to a string variable
                textLine1 = "";

                if (System.IO.File.Exists(fileName1) == true)
                {
                    System.IO.StreamReader objReader;
                    objReader = new System.IO.StreamReader(fileName1);                 // reads the the content in the file and storing the data in 7 different variables
                    while ((textLine1 = objReader.ReadLine()).Length > 0)
                    {
                        string[] values = textLine1.Split(',');
                        int col1 = Convert.ToInt32(values[0]);
                        int col2 = Convert.ToInt32(values[1]);
                        String col3 = values[2];
                        int col4;
                        if (values[3] == "null")
                            col4 = 0;
                        else
                            col4 = Convert.ToInt32(values[3]);
                        String col5 = values[4];
                        String col6 = values[5];
                        int col7 = Convert.ToInt32(values[6]);

                        String myCommand = "INSERT into ClassTable values (" + col1 + ", " + col2 + ",'" + col3 + "'," + col4 + ",'" + col5 + "','" + col6 + "'," + col7 + ");";          // To Insert the data stored in the variables into ClassTable
                        command = new MySqlCommand(myCommand, MyConnection);
                        command.ExecuteNonQuery();
                    }
                    objReader.Close();
                }
                else
                {
                    Console.WriteLine("No File: " + fileName1);
                }

                DataTable table = MyConnection.GetSchema("Tables");     // To Get the DB Schema and Display the Table Names in listbox
                foreach (DataRow row in table.Rows)
                {
                    if (row[2].ToString().Substring(0, 2) != "pg" && row[2].ToString().Substring(0, 3) != "sql")
                        listbox1.Items.Add(row[2].ToString());          // To add Schema to listbox
                }

            }
        }
    

    private void button1_Click(object sender, EventArgs e)
    {
        listbox1.Items.Add(" ");
        string query = textBox1.Text;
        string strconnection = "server=10.158.56.53;uid=csci473g08;pwd=wordpass08;database=csci473g08;";
            
            using (MySqlConnection Connection = new MySqlConnection(strconnection))
        {
            Connection.Open();
                MySqlCommand command = new MySqlCommand(query, Connection);
            try
            {
                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    int count = dataReader.FieldCount;
                    String item = "";
                    var table = dataReader.GetSchemaTable();
                    String s = "";
                    foreach (DataRow row in table.Rows)
                    {
                        String t = row.Field<string>("ColumnName");
                        for (int i = t.Length; i < 20; i++)
                        {
                            t += " ";
                        }
                        s += t + "\t";
                    }
                    listbox1.Items.Add(s);
                    while (dataReader.Read())
                    {
                        for (int i = 0; i < count; i++)
                        {
                            String t = dataReader[i].ToString();

                            for (int j = t.Length; j < 20; j++)
                            {
                                t += " ";
                            }

                            item += t + "\t";
                        }
                        listbox1.Items.Add(item);         //to add elements to the listbox for displaying
                        item = "";
                    }

                }

            }
            catch (MySqlException)
            {
                MessageBox.Show("Enter a valid query!");
            }
        }
    }

    private void button3_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        textBox1.Text = "";
        listbox1.Items.Clear();
    }
  }
}

