using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /**********************************************************************************
           function   : button1_Click
           Use        : button which is used to add the user given input to the chart

           Parameters :  sender, e

          **********************************************************************************/
        private void button1_Click(object sender, EventArgs e)
        {

            if (chart1.Enabled == true)
            {
                double text = Convert.ToDouble(textBox1.Text);


                this.chart1.Series["series1"].Points.AddY(text);
            }
            else
            {

                double text = Convert.ToDouble(textBox1.Text);
                this.chart2.Series["series2"].Points.AddY(text);
            }
        }
        /**********************************************************************************
         function   : button6_Click
         Use        : button which is used to add the input from file to the chart

         Parameters :  sender, e

        **********************************************************************************/
        private void button2_Click(object sender, EventArgs e)
        {
            //List<double> list = new List<double>();

            //this.chart1.Series["series1"].Points.AddY(list);
            List<double> list = new List<double>();
            string line;
            using (StreamReader reader = new StreamReader("Numbers.txt"))
            {

                while ((line = reader.ReadLine()) != null)
                {
                    list.Add(Double.Parse(line));
                    //Console.WriteLine(list);
                }

            }
            foreach (double value in list)
            {
                if (chart1.Enabled == true)
                {

                    this.chart1.Series["series1"].Points.AddY(value);
                }
                else
                {


                    this.chart2.Series["series2"].Points.AddY(value);
                }

            }
        }
        /**********************************************************************************
         function   : button3_Click
         Use        : button which is used to generate random points in a range 0 to 10
                      and add to the chart
         Parameters :  sender, e

        **********************************************************************************/
        private void button3_Click(object sender, EventArgs e)
        {

            Random random = new Random();
            double dbl = random.NextDouble() * (10.0 - 0.0) + 0.0;
            if (chart1.Enabled == true)
                this.chart1.Series["series1"].Points.AddY(dbl);
            else
                this.chart2.Series["series2"].Points.AddY(dbl);

        }

        /**********************************************************************************
         function   : button4_Click
         Use        : button which is used to clear the textbox1

         Parameters :  sender, e

        **********************************************************************************/
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
        /**********************************************************************************
         function   : button5_Click
         Use        : button which is used to exit the application

         Parameters :  sender, e

        **********************************************************************************/
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /**********************************************************************************
         function   : button6_Click
         Use        : button which is used to clear the data points of chart completely

         Parameters :  sender, e

        **********************************************************************************/
        private void button6_Click(object sender, EventArgs e)
        {
            this.chart1.Series["series1"].Points.Clear();
            this.chart2.Series["series2"].Points.Clear();
        }
        /**********************************************************************************
              function   : button7_Click
              Use        : button which is used to switch the charts

              Parameters :  sender, e

             **********************************************************************************/
        private void button7_Click(object sender, EventArgs e)
        {
            if(chart1.Enabled == true)
            {
                chart1.Enabled = false;
                chart2.Enabled = true;
            }

            else
            {
                chart1.Enabled = true;
                chart2.Enabled = false;
            }
        }
        /**********************************************************************************
         function   : textBox1_TextChanged
         Use        : button which is used to pop out a message box for wrong input

         Parameters :  sender, e

        **********************************************************************************/
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            double parsedValue;
            if (!double.TryParse(textBox1.Text, out parsedValue))
            {
                MessageBox.Show("Give a double");
                return;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        /**********************************************************************************
              function      : radiobutton1_checkedchanged
              Use        : radio button which is used to change the charttype to column

              Parameters :  sender, e

        **********************************************************************************/

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (chart1.Enabled == true)
            {
                this.chart1.Series["series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            }
            else
            {
                this.chart2.Series["series2"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            }
        }

        /**********************************************************************************
      function      : radiobutton2_checkedchanged
      Use        : radio button which is used to change the charttype to pie

      Parameters :  sender, e

     **********************************************************************************/
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (chart1.Enabled == true)
            {
                this.chart1.Series["series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

            }
            else
            {
                this.chart2.Series["series2"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            }
        }
        /**********************************************************************************
              function      : radiobutton3_checkedchanged
              Use        : radio button which is used to change the charttype to bar

              Parameters :  sender, e

        **********************************************************************************/
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (chart1.Enabled == true)
            {
                this.chart1.Series["series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;

            }
            else
            {
                this.chart2.Series["series2"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            }
        }

        /**********************************************************************************
      function      : radiobutton4_checkedchanged
      Use        : radio button which is used to change the charttype to doughnut

      Parameters :  sender, e

     **********************************************************************************/
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (chart1.Enabled == true)
            {
                this.chart1.Series["series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;

            }
            else
            {
                this.chart2.Series["series2"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }




        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
