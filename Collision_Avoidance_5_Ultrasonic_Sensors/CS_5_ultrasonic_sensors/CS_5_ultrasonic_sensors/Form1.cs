// File: Form1.cs
// Description: Intelligent Mobile Robot - Collision Avoidance
// Environment: Visual Studio 2015, C#
//
// MIT License
// Copyright (c) 2018 Valentyn N Sichkar
// github.com/sichkar-valentyn
// Reference to:
// Valentyn N Sichkar. Intelligent Navigation System of Mobile Robot // GitHub platform. DOI: 10.5281/zenodo.1317907

//Namespaces
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace CS_5_ultrasonic_sensors
{
    public partial class Form1 : Form
    {
        //Public variables
        public int i = 0;
        public string send = "";

        //public variable for calculating the exact time of the execution of the part of the code
        Stopwatch stopWatch = new Stopwatch();

        //Public variables for represanting results in different threads
        public Dictionary<string, string> D = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();

            //Setting the SerialPort
            serialPort1.PortName = "COM3";
            serialPort1.BaudRate = 9600;

            D.Add("label1", "0");
            D.Add("label2", "0");
            D.Add("label3", "0");
            D.Add("label4", "0");
            D.Add("label5", "0");
            D.Add("sensor1", "0");
            D.Add("sensor2", "0");
            D.Add("sensor3", "0");
            D.Add("sensor4", "0");
            D.Add("sensor5", "0");

            timer1.Stop();

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Time";
            column2.Name = "time";
            column2.Width = 60;
            column2.ReadOnly = true;
            column2.Frozen = true;
            column2.CellTemplate = new DataGridViewTextBoxCell();

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Sensor #1";
            column3.Name = "sensor_1";
            column3.Width = 65;
            column3.ReadOnly = true;
            column3.Frozen = true;
            column3.CellTemplate = new DataGridViewTextBoxCell();

            var column4 = new DataGridViewColumn();
            column4.HeaderText = "Sensor #2";
            column4.Name = "sensor_2";
            column4.Width = 65;
            column4.ReadOnly = true;
            column4.Frozen = true;
            column4.CellTemplate = new DataGridViewTextBoxCell();

            var column5 = new DataGridViewColumn();
            column5.HeaderText = "Sensor #3";
            column5.Name = "sensor_3";
            column5.Width = 65;
            column5.ReadOnly = true;
            column5.Frozen = true;
            column5.CellTemplate = new DataGridViewTextBoxCell();

            var column6 = new DataGridViewColumn();
            column6.HeaderText = "Sensor #4";
            column6.Name = "sensor_4";
            column6.Width = 65;
            column6.ReadOnly = true;
            column6.Frozen = true;
            column6.CellTemplate = new DataGridViewTextBoxCell();

            var column7 = new DataGridViewColumn();
            column7.HeaderText = "Sensor #5";
            column7.Name = "sensor_5";
            column7.Width = 65;
            column7.ReadOnly = true;
            column7.Frozen = true;
            column7.CellTemplate = new DataGridViewTextBoxCell();

            dataGridView1.Columns.Add(column2);
            dataGridView1.Columns.Add(column3);
            dataGridView1.Columns.Add(column4);
            dataGridView1.Columns.Add(column5);
            dataGridView1.Columns.Add(column6);
            dataGridView1.Columns.Add(column7);

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DeepSkyBlue;

            dataGridView1.Rows.Add(DateTime.Now.ToLongTimeString());

            pictureBox3.Visible = true;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;

            pictureBox6.Visible = true;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;

            pictureBox9.Visible = true;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;

            pictureBox12.Visible = true;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;

            pictureBox15.Visible = true;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;

            pictureBox18.Visible = true;
            pictureBox19.Visible = false;
            pictureBox20.Visible = false;

            pictureBox21.Visible = true;
            pictureBox22.Visible = false;
            pictureBox23.Visible = false;

            pictureBox24.Visible = true;
            pictureBox25.Visible = false;
            pictureBox26.Visible = false;

            pictureBox27.Visible = true;
            pictureBox28.Visible = false;
            pictureBox29.Visible = false;

            pictureBox30.Visible = true;
            pictureBox31.Visible = false;
            pictureBox32.Visible = false;

            pictureBox33.Visible = false;
            pictureBox34.Visible = false;

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;

            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;

            label1.Text = "0";
            label2.Text = "0";
            label3.Text = "0";
            label4.Text = "0";
            label5.Text = "0";
            label6.Text = "0";

            label10.Text = "0";
            label11.Text = "0";
            label12.Text = "0";
            label13.Text = "0";
            label14.Text = "0";

            label18.Text = "";

            button1.Enabled = true;
            button1.BackColor = Color.Lime;
            button2.Enabled = false;
            button2.BackColor = Color.Gray;
            button3.Enabled = true;
            button3.BackColor = Color.DeepSkyBlue;
        }

        public void neural_network_results()
        {
            //Creating an Input vector
            double[] inputs = new double[6];
            inputs[0] = Convert.ToDouble(D["label1"]);
            inputs[1] = Convert.ToDouble(D["label2"]);
            inputs[2] = Convert.ToDouble(D["label3"]);
            inputs[3] = Convert.ToDouble(D["label4"]);
            inputs[4] = Convert.ToDouble(D["label5"]);
            inputs[5] = 1;

            //Creating a matrix of weights for the Layer #1
            double[,] Weights_First_Layer_Separate = new double[6,20];
            Weights_First_Layer_Separate[0, 0] = 0.11;
            Weights_First_Layer_Separate[0, 1] = -0.05;
            Weights_First_Layer_Separate[0, 2] = 0;
            Weights_First_Layer_Separate[0, 3] = 0;
            Weights_First_Layer_Separate[0, 4] = 0;
            Weights_First_Layer_Separate[0, 5] = 0;
            Weights_First_Layer_Separate[0, 6] = 0;
            Weights_First_Layer_Separate[0, 7] = 0;
            Weights_First_Layer_Separate[0, 8] = 0;
            Weights_First_Layer_Separate[0, 9] = 0;
            Weights_First_Layer_Separate[0, 10] = 0.5;
            Weights_First_Layer_Separate[0, 11] = -0.11;
            Weights_First_Layer_Separate[0, 12] = 0;
            Weights_First_Layer_Separate[0, 13] = 0;
            Weights_First_Layer_Separate[0, 14] = 0;
            Weights_First_Layer_Separate[0, 15] = 0;
            Weights_First_Layer_Separate[0, 16] = 0;
            Weights_First_Layer_Separate[0, 17] = 0;
            Weights_First_Layer_Separate[0, 18] = 0;
            Weights_First_Layer_Separate[0, 19] = 0;
            Weights_First_Layer_Separate[1, 0] = 0;
            Weights_First_Layer_Separate[1, 1] = 0;
            Weights_First_Layer_Separate[1, 2] = 0.11;
            Weights_First_Layer_Separate[1, 3] = -0.05;
            Weights_First_Layer_Separate[1, 4] = 0;
            Weights_First_Layer_Separate[1, 5] = 0;
            Weights_First_Layer_Separate[1, 6] = 0;
            Weights_First_Layer_Separate[1, 7] = 0;
            Weights_First_Layer_Separate[1, 8] = 0;
            Weights_First_Layer_Separate[1, 9] = 0;
            Weights_First_Layer_Separate[1, 10] = 0;
            Weights_First_Layer_Separate[1, 11] = 0;
            Weights_First_Layer_Separate[1, 12] = 0.5;
            Weights_First_Layer_Separate[1, 13] = -0.11;
            Weights_First_Layer_Separate[1, 14] = 0;
            Weights_First_Layer_Separate[1, 15] = 0;
            Weights_First_Layer_Separate[1, 16] = 0;
            Weights_First_Layer_Separate[1, 17] = 0;
            Weights_First_Layer_Separate[1, 18] = 0;
            Weights_First_Layer_Separate[1, 19] = 0;
            Weights_First_Layer_Separate[2, 0] = 0;
            Weights_First_Layer_Separate[2, 1] = 0;
            Weights_First_Layer_Separate[2, 2] = 0;
            Weights_First_Layer_Separate[2, 3] = 0;
            Weights_First_Layer_Separate[2, 4] = 0.11;
            Weights_First_Layer_Separate[2, 5] = -0.05;
            Weights_First_Layer_Separate[2, 6] = 0;
            Weights_First_Layer_Separate[2, 7] = 0;
            Weights_First_Layer_Separate[2, 8] = 0;
            Weights_First_Layer_Separate[2, 9] = 0;
            Weights_First_Layer_Separate[2, 10] = 0;
            Weights_First_Layer_Separate[2, 11] = 0;
            Weights_First_Layer_Separate[2, 12] = 0;
            Weights_First_Layer_Separate[2, 13] = 0;
            Weights_First_Layer_Separate[2, 14] = 0.5;
            Weights_First_Layer_Separate[2, 15] = -0.11;
            Weights_First_Layer_Separate[2, 16] = 0;
            Weights_First_Layer_Separate[2, 17] = 0;
            Weights_First_Layer_Separate[2, 18] = 0;
            Weights_First_Layer_Separate[2, 19] = 0;
            Weights_First_Layer_Separate[3, 0] = 0;
            Weights_First_Layer_Separate[3, 1] = 0;
            Weights_First_Layer_Separate[3, 2] = 0;
            Weights_First_Layer_Separate[3, 3] = 0;
            Weights_First_Layer_Separate[3, 4] = 0;
            Weights_First_Layer_Separate[3, 5] = 0;
            Weights_First_Layer_Separate[3, 6] = 0.11;
            Weights_First_Layer_Separate[3, 7] = -0.05;
            Weights_First_Layer_Separate[3, 8] = 0;
            Weights_First_Layer_Separate[3, 9] = 0;
            Weights_First_Layer_Separate[3, 10] = 0;
            Weights_First_Layer_Separate[3, 11] = 0;
            Weights_First_Layer_Separate[3, 12] = 0;
            Weights_First_Layer_Separate[3, 13] = 0;
            Weights_First_Layer_Separate[3, 14] = 0;
            Weights_First_Layer_Separate[3, 15] = 0;
            Weights_First_Layer_Separate[3, 16] = 0.5;
            Weights_First_Layer_Separate[3, 17] = -0.11;
            Weights_First_Layer_Separate[3, 18] = 0;
            Weights_First_Layer_Separate[3, 19] = 0;
            Weights_First_Layer_Separate[4, 0] = 0;
            Weights_First_Layer_Separate[4, 1] = 0;
            Weights_First_Layer_Separate[4, 2] = 0;
            Weights_First_Layer_Separate[4, 3] = 0;
            Weights_First_Layer_Separate[4, 4] = 0;
            Weights_First_Layer_Separate[4, 5] = 0;
            Weights_First_Layer_Separate[4, 6] = 0;
            Weights_First_Layer_Separate[4, 7] = 0;
            Weights_First_Layer_Separate[4, 8] = 0.11;
            Weights_First_Layer_Separate[4, 9] = -0.05;
            Weights_First_Layer_Separate[4, 10] = 0;
            Weights_First_Layer_Separate[4, 11] = 0;
            Weights_First_Layer_Separate[4, 12] = 0;
            Weights_First_Layer_Separate[4, 13] = 0;
            Weights_First_Layer_Separate[4, 14] = 0;
            Weights_First_Layer_Separate[4, 15] = 0;
            Weights_First_Layer_Separate[4, 16] = 0;
            Weights_First_Layer_Separate[4, 17] = 0;
            Weights_First_Layer_Separate[4, 18] = 0.5;
            Weights_First_Layer_Separate[4, 19] = -0.11;
            Weights_First_Layer_Separate[5, 0] = -1;
            Weights_First_Layer_Separate[5, 1] = 1.05;
            Weights_First_Layer_Separate[5, 2] = -1;
            Weights_First_Layer_Separate[5, 3] = 1.05;
            Weights_First_Layer_Separate[5, 4] = -1;
            Weights_First_Layer_Separate[5, 5] = 1.05;
            Weights_First_Layer_Separate[5, 6] = -1;
            Weights_First_Layer_Separate[5, 7] = 1.05;
            Weights_First_Layer_Separate[5, 8] = -1;
            Weights_First_Layer_Separate[5, 9] = 1.05;
            Weights_First_Layer_Separate[5, 10] = -1;
            Weights_First_Layer_Separate[5, 11] = 1.05;
            Weights_First_Layer_Separate[5, 12] = -1;
            Weights_First_Layer_Separate[5, 13] = 1.05;
            Weights_First_Layer_Separate[5, 14] = -1;
            Weights_First_Layer_Separate[5, 15] = 1.05;
            Weights_First_Layer_Separate[5, 16] = -1;
            Weights_First_Layer_Separate[5, 17] = 1.05;
            Weights_First_Layer_Separate[5, 18] = -1;
            Weights_First_Layer_Separate[5, 19] = 1.05;

            //Getting the outputs of the Layer #1
            double[] A_Separate = new double[21];
            for (int j = 0; j < 20; j++) { A_Separate[j] = 0; }

            for (int m = 0; m < 20; m++)
                for (int j = 0; j < 6; j++)
                    {
                        A_Separate[m] += inputs[j] * Weights_First_Layer_Separate[j, m];
                    }

            //Adding to the outputs of the Layer #1 the second bias
            A_Separate[20] = 1;

            //Activating the neurons in the Layer #1
            for (int j = 0; j < 20; j++)
            {
                if (A_Separate[j] < 0) A_Separate[j] = 0;
                if (A_Separate[j] > 0) A_Separate[j] = 1;
            }
            
            //Creating a matrix of weights for the inputs of the Hidden Layer
            double[,] Weights_Hidden_Layer_Separate = new double[21, 10];
            Weights_Hidden_Layer_Separate[0, 0] = 1;
            Weights_Hidden_Layer_Separate[0, 1] = 0;
            Weights_Hidden_Layer_Separate[0, 2] = 0;
            Weights_Hidden_Layer_Separate[0, 3] = 0;
            Weights_Hidden_Layer_Separate[0, 4] = 0;
            Weights_Hidden_Layer_Separate[0, 5] = 0;
            Weights_Hidden_Layer_Separate[0, 6] = 0;
            Weights_Hidden_Layer_Separate[0, 7] = 0;
            Weights_Hidden_Layer_Separate[0, 8] = 0;
            Weights_Hidden_Layer_Separate[0, 9] = 0;
            Weights_Hidden_Layer_Separate[1, 0] = 1;
            Weights_Hidden_Layer_Separate[1, 1] = 0;
            Weights_Hidden_Layer_Separate[1, 2] = 0;
            Weights_Hidden_Layer_Separate[1, 3] = 0;
            Weights_Hidden_Layer_Separate[1, 4] = 0;
            Weights_Hidden_Layer_Separate[1, 5] = 0;
            Weights_Hidden_Layer_Separate[1, 6] = 0;
            Weights_Hidden_Layer_Separate[1, 7] = 0;
            Weights_Hidden_Layer_Separate[1, 8] = 0;
            Weights_Hidden_Layer_Separate[1, 9] = 0;
            Weights_Hidden_Layer_Separate[2, 0] = 0;
            Weights_Hidden_Layer_Separate[2, 1] = 1;
            Weights_Hidden_Layer_Separate[2, 2] = 0;
            Weights_Hidden_Layer_Separate[2, 3] = 0;
            Weights_Hidden_Layer_Separate[2, 4] = 0;
            Weights_Hidden_Layer_Separate[2, 5] = 0;
            Weights_Hidden_Layer_Separate[2, 6] = 0;
            Weights_Hidden_Layer_Separate[2, 7] = 0;
            Weights_Hidden_Layer_Separate[2, 8] = 0;
            Weights_Hidden_Layer_Separate[2, 9] = 0;
            Weights_Hidden_Layer_Separate[3, 0] = 0;
            Weights_Hidden_Layer_Separate[3, 1] = 1;
            Weights_Hidden_Layer_Separate[3, 2] = 0;
            Weights_Hidden_Layer_Separate[3, 3] = 0;
            Weights_Hidden_Layer_Separate[3, 4] = 0;
            Weights_Hidden_Layer_Separate[3, 5] = 0;
            Weights_Hidden_Layer_Separate[3, 6] = 0;
            Weights_Hidden_Layer_Separate[3, 7] = 0;
            Weights_Hidden_Layer_Separate[3, 8] = 0;
            Weights_Hidden_Layer_Separate[3, 9] = 0;
            Weights_Hidden_Layer_Separate[4, 0] = 0;
            Weights_Hidden_Layer_Separate[4, 1] = 0;
            Weights_Hidden_Layer_Separate[4, 2] = 1;
            Weights_Hidden_Layer_Separate[4, 3] = 0;
            Weights_Hidden_Layer_Separate[4, 4] = 0;
            Weights_Hidden_Layer_Separate[4, 5] = 0;
            Weights_Hidden_Layer_Separate[4, 6] = 0;
            Weights_Hidden_Layer_Separate[4, 7] = 0;
            Weights_Hidden_Layer_Separate[4, 8] = 0;
            Weights_Hidden_Layer_Separate[4, 9] = 0;
            Weights_Hidden_Layer_Separate[5, 0] = 0;
            Weights_Hidden_Layer_Separate[5, 1] = 0;
            Weights_Hidden_Layer_Separate[5, 2] = 1;
            Weights_Hidden_Layer_Separate[5, 3] = 0;
            Weights_Hidden_Layer_Separate[5, 4] = 0;
            Weights_Hidden_Layer_Separate[5, 5] = 0;
            Weights_Hidden_Layer_Separate[5, 6] = 0;
            Weights_Hidden_Layer_Separate[5, 7] = 0;
            Weights_Hidden_Layer_Separate[5, 8] = 0;
            Weights_Hidden_Layer_Separate[5, 9] = 0;
            Weights_Hidden_Layer_Separate[6, 0] = 0;
            Weights_Hidden_Layer_Separate[6, 1] = 0;
            Weights_Hidden_Layer_Separate[6, 2] = 0;
            Weights_Hidden_Layer_Separate[6, 3] = 1;
            Weights_Hidden_Layer_Separate[6, 4] = 0;
            Weights_Hidden_Layer_Separate[6, 5] = 0;
            Weights_Hidden_Layer_Separate[6, 6] = 0;
            Weights_Hidden_Layer_Separate[6, 7] = 0;
            Weights_Hidden_Layer_Separate[6, 8] = 0;
            Weights_Hidden_Layer_Separate[6, 9] = 0;
            Weights_Hidden_Layer_Separate[7, 0] = 0;
            Weights_Hidden_Layer_Separate[7, 1] = 0;
            Weights_Hidden_Layer_Separate[7, 2] = 0;
            Weights_Hidden_Layer_Separate[7, 3] = 1;
            Weights_Hidden_Layer_Separate[7, 4] = 0;
            Weights_Hidden_Layer_Separate[7, 5] = 0;
            Weights_Hidden_Layer_Separate[7, 6] = 0;
            Weights_Hidden_Layer_Separate[7, 7] = 0;
            Weights_Hidden_Layer_Separate[7, 8] = 0;
            Weights_Hidden_Layer_Separate[7, 9] = 0;
            Weights_Hidden_Layer_Separate[8, 0] = 0;
            Weights_Hidden_Layer_Separate[8, 1] = 0;
            Weights_Hidden_Layer_Separate[8, 2] = 0;
            Weights_Hidden_Layer_Separate[8, 3] = 0;
            Weights_Hidden_Layer_Separate[8, 4] = 1;
            Weights_Hidden_Layer_Separate[8, 5] = 0;
            Weights_Hidden_Layer_Separate[8, 6] = 0;
            Weights_Hidden_Layer_Separate[8, 7] = 0;
            Weights_Hidden_Layer_Separate[8, 8] = 0;
            Weights_Hidden_Layer_Separate[8, 9] = 0;
            Weights_Hidden_Layer_Separate[9, 0] = 0;
            Weights_Hidden_Layer_Separate[9, 1] = 0;
            Weights_Hidden_Layer_Separate[9, 2] = 0;
            Weights_Hidden_Layer_Separate[9, 3] = 0;
            Weights_Hidden_Layer_Separate[9, 4] = 1;
            Weights_Hidden_Layer_Separate[9, 5] = 0;
            Weights_Hidden_Layer_Separate[9, 6] = 0;
            Weights_Hidden_Layer_Separate[9, 7] = 0;
            Weights_Hidden_Layer_Separate[9, 8] = 0;
            Weights_Hidden_Layer_Separate[9, 9] = 0;
            Weights_Hidden_Layer_Separate[10, 0] = 0;
            Weights_Hidden_Layer_Separate[10, 1] = 0;
            Weights_Hidden_Layer_Separate[10, 2] = 0;
            Weights_Hidden_Layer_Separate[10, 3] = 0;
            Weights_Hidden_Layer_Separate[10, 4] = 0;
            Weights_Hidden_Layer_Separate[10, 5] = 1;
            Weights_Hidden_Layer_Separate[10, 6] = 0;
            Weights_Hidden_Layer_Separate[10, 7] = 0;
            Weights_Hidden_Layer_Separate[10, 8] = 0;
            Weights_Hidden_Layer_Separate[10, 9] = 0;
            Weights_Hidden_Layer_Separate[11, 0] = 0;
            Weights_Hidden_Layer_Separate[11, 1] = 0;
            Weights_Hidden_Layer_Separate[11, 2] = 0;
            Weights_Hidden_Layer_Separate[11, 3] = 0;
            Weights_Hidden_Layer_Separate[11, 4] = 0;
            Weights_Hidden_Layer_Separate[11, 5] = 1;
            Weights_Hidden_Layer_Separate[11, 6] = 0;
            Weights_Hidden_Layer_Separate[11, 7] = 0;
            Weights_Hidden_Layer_Separate[11, 8] = 0;
            Weights_Hidden_Layer_Separate[11, 9] = 0;
            Weights_Hidden_Layer_Separate[12, 0] = 0;
            Weights_Hidden_Layer_Separate[12, 1] = 0;
            Weights_Hidden_Layer_Separate[12, 2] = 0;
            Weights_Hidden_Layer_Separate[12, 3] = 0;
            Weights_Hidden_Layer_Separate[12, 4] = 0;
            Weights_Hidden_Layer_Separate[12, 5] = 0;
            Weights_Hidden_Layer_Separate[12, 6] = 1;
            Weights_Hidden_Layer_Separate[12, 7] = 0;
            Weights_Hidden_Layer_Separate[12, 8] = 0;
            Weights_Hidden_Layer_Separate[12, 9] = 0;
            Weights_Hidden_Layer_Separate[13, 0] = 0;
            Weights_Hidden_Layer_Separate[13, 1] = 0;
            Weights_Hidden_Layer_Separate[13, 2] = 0;
            Weights_Hidden_Layer_Separate[13, 3] = 0;
            Weights_Hidden_Layer_Separate[13, 4] = 0;
            Weights_Hidden_Layer_Separate[13, 5] = 0;
            Weights_Hidden_Layer_Separate[13, 6] = 1;
            Weights_Hidden_Layer_Separate[13, 7] = 0;
            Weights_Hidden_Layer_Separate[13, 8] = 0;
            Weights_Hidden_Layer_Separate[13, 9] = 0;
            Weights_Hidden_Layer_Separate[14, 0] = 0;
            Weights_Hidden_Layer_Separate[14, 1] = 0;
            Weights_Hidden_Layer_Separate[14, 2] = 0;
            Weights_Hidden_Layer_Separate[14, 3] = 0;
            Weights_Hidden_Layer_Separate[14, 4] = 0;
            Weights_Hidden_Layer_Separate[14, 5] = 0;
            Weights_Hidden_Layer_Separate[14, 6] = 0;
            Weights_Hidden_Layer_Separate[14, 7] = 1;
            Weights_Hidden_Layer_Separate[14, 8] = 0;
            Weights_Hidden_Layer_Separate[14, 9] = 0;
            Weights_Hidden_Layer_Separate[15, 0] = 0;
            Weights_Hidden_Layer_Separate[15, 1] = 0;
            Weights_Hidden_Layer_Separate[15, 2] = 0;
            Weights_Hidden_Layer_Separate[15, 3] = 0;
            Weights_Hidden_Layer_Separate[15, 4] = 0;
            Weights_Hidden_Layer_Separate[15, 5] = 0;
            Weights_Hidden_Layer_Separate[15, 6] = 0;
            Weights_Hidden_Layer_Separate[15, 7] = 1;
            Weights_Hidden_Layer_Separate[15, 8] = 0;
            Weights_Hidden_Layer_Separate[15, 9] = 0;
            Weights_Hidden_Layer_Separate[16, 0] = 0;
            Weights_Hidden_Layer_Separate[16, 1] = 0;
            Weights_Hidden_Layer_Separate[16, 2] = 0;
            Weights_Hidden_Layer_Separate[16, 3] = 0;
            Weights_Hidden_Layer_Separate[16, 4] = 0;
            Weights_Hidden_Layer_Separate[16, 5] = 0;
            Weights_Hidden_Layer_Separate[16, 6] = 0;
            Weights_Hidden_Layer_Separate[16, 7] = 0;
            Weights_Hidden_Layer_Separate[16, 8] = 1;
            Weights_Hidden_Layer_Separate[16, 9] = 0;
            Weights_Hidden_Layer_Separate[17, 0] = 0;
            Weights_Hidden_Layer_Separate[17, 1] = 0;
            Weights_Hidden_Layer_Separate[17, 2] = 0;
            Weights_Hidden_Layer_Separate[17, 3] = 0;
            Weights_Hidden_Layer_Separate[17, 4] = 0;
            Weights_Hidden_Layer_Separate[17, 5] = 0;
            Weights_Hidden_Layer_Separate[17, 6] = 0;
            Weights_Hidden_Layer_Separate[17, 7] = 0;
            Weights_Hidden_Layer_Separate[17, 8] = 1;
            Weights_Hidden_Layer_Separate[17, 9] = 0;
            Weights_Hidden_Layer_Separate[18, 0] = 0;
            Weights_Hidden_Layer_Separate[18, 1] = 0;
            Weights_Hidden_Layer_Separate[18, 2] = 0;
            Weights_Hidden_Layer_Separate[18, 3] = 0;
            Weights_Hidden_Layer_Separate[18, 4] = 0;
            Weights_Hidden_Layer_Separate[18, 5] = 0;
            Weights_Hidden_Layer_Separate[18, 6] = 0;
            Weights_Hidden_Layer_Separate[18, 7] = 0;
            Weights_Hidden_Layer_Separate[18, 8] = 0;
            Weights_Hidden_Layer_Separate[18, 9] = 1;
            Weights_Hidden_Layer_Separate[19, 0] = 0;
            Weights_Hidden_Layer_Separate[19, 1] = 0;
            Weights_Hidden_Layer_Separate[19, 2] = 0;
            Weights_Hidden_Layer_Separate[19, 3] = 0;
            Weights_Hidden_Layer_Separate[19, 4] = 0;
            Weights_Hidden_Layer_Separate[19, 5] = 0;
            Weights_Hidden_Layer_Separate[19, 6] = 0;
            Weights_Hidden_Layer_Separate[19, 7] = 0;
            Weights_Hidden_Layer_Separate[19, 8] = 0;
            Weights_Hidden_Layer_Separate[19, 9] = 1;
            Weights_Hidden_Layer_Separate[20, 0] = -1.5;
            Weights_Hidden_Layer_Separate[20, 1] = -1.5;
            Weights_Hidden_Layer_Separate[20, 2] = -1.5;
            Weights_Hidden_Layer_Separate[20, 3] = -1.5;
            Weights_Hidden_Layer_Separate[20, 4] = -1.5;
            Weights_Hidden_Layer_Separate[20, 5] = -1.5;
            Weights_Hidden_Layer_Separate[20, 6] = -1.5;
            Weights_Hidden_Layer_Separate[20, 7] = -1.5;
            Weights_Hidden_Layer_Separate[20, 8] = -1.5;
            Weights_Hidden_Layer_Separate[20, 9] = -1.5;

            //Getting the outputs of the Hidden Layer
            double[] Results = new double[10];
            for (int j = 0; j < 9; j++) { Results[j] = 0; }

            for (int m  = 0; m < 10; m++)
                for (int j = 0; j < 21; j++)
                {
                    Results[m] += A_Separate[j] * Weights_Hidden_Layer_Separate[j, m];
                }

            //Activating the neurons in the Hidden Layer
            for (int j = 0; j < 10; j++)
            {
                if (Results[j] < 0) Results[j] = 0;
                if (Results[j] > 0) Results[j] = 1;
            }

            if (Results[0] == 1) D["sensor1"] = "Warning";
            if (Results[5] == 1) D["sensor1"] = "Alarm";
            if (Results[0] == 0 & Results[5] ==0) D["sensor1"] = "Empty";

            if (Results[1] == 1) D["sensor2"] = "Warning";
            if (Results[6] == 1) D["sensor2"] = "Alarm";
            if (Results[1] == 0 & Results[6] == 0) D["sensor2"] = "Empty";

            if (Results[2] == 1) D["sensor3"] = "Warning";
            if (Results[7] == 1) D["sensor3"] = "Alarm";
            if (Results[2] == 0 & Results[7] == 0) D["sensor3"] = "Empty";

            if (Results[3] == 1) D["sensor4"] = "Warning";
            if (Results[8] == 1) D["sensor4"] = "Alarm";
            if (Results[3] == 0 & Results[8] == 0) D["sensor4"] = "Empty";

            if (Results[4] == 1) D["sensor5"] = "Warning";
            if (Results[9] == 1) D["sensor5"] = "Alarm";
            if (Results[4] == 0 & Results[9] == 0) D["sensor5"] = "Empty";


        }

        //Button - Opening the port
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();

            Task task_1 = Task.Factory.StartNew(read_line);

            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;

            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;

            button1.Enabled = false;
            button1.BackColor = Color.Gray;
            button2.Enabled = true;
            button2.BackColor = Color.Fuchsia;
        }

        //Metod for the thread_1
        private void read_line()
        {
            if (serialPort1.IsOpen == false) serialPort1.Open();

            while (serialPort1.IsOpen == true)
            {
                try
                {
                    string line = "";
                    line = serialPort1.ReadLine();

                    string[] result = line.Split('_');

                    D["label1"] = result[3];
                    D["label2"] = result[2];
                    D["label3"] = result[1];
                    D["label4"] = result[0];
                    D["label5"] = result[4];

                    //Calculating the quantity of data exchange
                    i++;
                }
                catch { break; }
            }
        }

        //Button - Closing the port
        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            timer1.Stop();

            button1.Enabled = true;
            button1.BackColor = Color.Lime;
            button2.Enabled = false;
            button2.BackColor = Color.Gray;
        }

        //Button - close application
        private void button3_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            Application.Exit();
        }
        
        //Creating a timer for updating all data from main thread by the data from first thread
        private void timer1_Tick(object sender, EventArgs e)
        {
            send = "";

            //Checking for the necessary to add something into the journey
            bool check = false;

            //Checking for 3 and mor Alarms
            int check_alarm = 0;

            //Getting the results from Neural Network
            stopWatch.Start();
            neural_network_results();
            stopWatch.Stop();
            label18.Text = Convert.ToString(stopWatch.Elapsed); //Checking the execution time
            stopWatch.Reset();

            string time = "", sensor_1 = "", sensor_2 = "", sensor_3 = "", sensor_4 = "", sensor_5 = "";

            //Represanting results for Separate Parameters
            label1.Text = D["label1"];
            label10.Text = D["label1"];
            string neural_result_1 = D["sensor1"];
            if (neural_result_1 == "Alarm") { check_alarm++; pictureBox20.Visible = true; pictureBox18.Visible = false; pictureBox19.Visible = false; check = true; sensor_1 = "Alarm"; pictureBox5.Visible = true; pictureBox3.Visible = false; pictureBox4.Visible = false; }
            if (neural_result_1 == "Warning") { pictureBox19.Visible = true; pictureBox18.Visible = false; pictureBox20.Visible = false; check = true; sensor_1 = "Warning"; pictureBox4.Visible = true; pictureBox3.Visible = false; pictureBox5.Visible = false; }
            if (neural_result_1 == "Empty") { pictureBox18.Visible = true; pictureBox19.Visible = false; pictureBox20.Visible = false; pictureBox3.Visible = true; pictureBox4.Visible = false; pictureBox5.Visible = false; }
            
            label2.Text = D["label2"];
            label11.Text = D["label2"];
            string neural_result_2 = D["sensor2"];
            if (neural_result_2 == "Alarm") { check_alarm++; pictureBox23.Visible = true; pictureBox21.Visible = false; pictureBox22.Visible = false; check = true; sensor_2 = "Alarm"; pictureBox8.Visible = true; pictureBox7.Visible = false; pictureBox6.Visible = false; }
            if (neural_result_2 == "Warning") { pictureBox22.Visible = true; pictureBox21.Visible = false; pictureBox23.Visible = false; check = true; sensor_2 = "Warning"; pictureBox7.Visible = true; pictureBox6.Visible = false; pictureBox8.Visible = false; }
            if (neural_result_2 == "Empty") { pictureBox21.Visible = true; pictureBox22.Visible = false; pictureBox23.Visible = false; pictureBox6.Visible = true; pictureBox7.Visible = false; pictureBox8.Visible = false; }
            
            label3.Text = D["label3"];
            label12.Text = D["label3"];
            string neural_result_3 = D["sensor3"];
            if (neural_result_3 == "Alarm") { check_alarm++; pictureBox26.Visible = true; pictureBox25.Visible = false; pictureBox24.Visible = false; check = true; sensor_3 = "Alarm"; pictureBox11.Visible = true; pictureBox9.Visible = false; pictureBox10.Visible = false; }
            if (neural_result_3 == "Warning") { pictureBox25.Visible = true; pictureBox24.Visible = false; pictureBox26.Visible = false; check = true; sensor_3 = "Warning"; pictureBox10.Visible = true; pictureBox9.Visible = false; pictureBox11.Visible = false; }
            if (neural_result_3 == "Empty") { pictureBox24.Visible = true; pictureBox25.Visible = false; pictureBox26.Visible = false; pictureBox9.Visible = true; pictureBox10.Visible = false; pictureBox11.Visible = false; }
            
            label4.Text = D["label4"];
            label13.Text = D["label4"];
            string neural_result_4 = D["sensor4"];
            if (neural_result_4 == "Alarm") { check_alarm++; pictureBox29.Visible = true; pictureBox27.Visible = false; pictureBox28.Visible = false; check = true; sensor_4 = "Alarm"; pictureBox14.Visible = true; pictureBox13.Visible = false; pictureBox12.Visible = false; }
            if (neural_result_4 == "Warning") { pictureBox28.Visible = true; pictureBox27.Visible = false; pictureBox29.Visible = false; check = true; sensor_4 = "Warning"; pictureBox13.Visible = true; pictureBox12.Visible = false; pictureBox14.Visible = false; }
            if (neural_result_4 == "Empty") { pictureBox27.Visible = true; pictureBox28.Visible = false; pictureBox29.Visible = false; pictureBox12.Visible = true; pictureBox13.Visible = false; pictureBox14.Visible = false; }
            
            label5.Text = D["label5"];
            label14.Text = D["label5"];
            string neural_result_5 = D["sensor5"];
            if (neural_result_5 == "Alarm") { check_alarm++; pictureBox32.Visible = true; pictureBox30.Visible = false; pictureBox31.Visible = false; check = true; sensor_5 = "Alarm"; pictureBox17.Visible = true; pictureBox15.Visible = false; pictureBox16.Visible = false; }
            if (neural_result_5 == "Warning") { pictureBox31.Visible = true; pictureBox30.Visible = false; pictureBox32.Visible = false; check = true; sensor_5 = "Warning"; pictureBox16.Visible = true; pictureBox15.Visible = false; pictureBox17.Visible = false; }
            if (neural_result_5 == "Empty") { pictureBox30.Visible = true; pictureBox31.Visible = false; pictureBox32.Visible = false; pictureBox15.Visible = true; pictureBox16.Visible = false; pictureBox17.Visible = false; }

            //Light the "Stop"
            if (check_alarm >= 3) pictureBox33.Visible = true;
            else pictureBox33.Visible = false;

            //Light the "Go"
            if (check_alarm == 0) pictureBox34.Visible = true;
            else pictureBox34.Visible = false;

            //Showing always the latest line in the GridView
            dataGridView1.CurrentCell = dataGridView1["time", dataGridView1.Rows.Count - 1];

            //Showing the value for data exchange
            label6.Text = Convert.ToString(i);

            //setting the current time
            time = DateTime.Now.ToLongTimeString();

            //Adding the line in the journal with current values
            if (check == true)
            {
                dataGridView1.Rows.Add(time, sensor_1, sensor_2, sensor_3, sensor_4, sensor_5);
                if (sensor_1 == "Alarm") dataGridView1["sensor_1", dataGridView1.Rows.Count - 1].Style.BackColor = Color.Red;
                if (sensor_1 == "Warning") dataGridView1["sensor_1", dataGridView1.Rows.Count - 1].Style.BackColor = Color.Yellow;
                if (sensor_2 == "Alarm") dataGridView1["sensor_2", dataGridView1.Rows.Count - 1].Style.BackColor = Color.Red;
                if (sensor_2 == "Warning") dataGridView1["sensor_2", dataGridView1.Rows.Count - 1].Style.BackColor = Color.Yellow;
                if (sensor_3 == "Alarm") dataGridView1["sensor_3", dataGridView1.Rows.Count - 1].Style.BackColor = Color.Red;
                if (sensor_3 == "Warning") dataGridView1["sensor_3", dataGridView1.Rows.Count - 1].Style.BackColor = Color.Yellow;
                if (sensor_4 == "Alarm") dataGridView1["sensor_4", dataGridView1.Rows.Count - 1].Style.BackColor = Color.Red;
                if (sensor_4 == "Warning") dataGridView1["sensor_4", dataGridView1.Rows.Count - 1].Style.BackColor = Color.Yellow;
                if (sensor_5 == "Alarm") dataGridView1["sensor_5", dataGridView1.Rows.Count - 1].Style.BackColor = Color.Red;
                if (sensor_5 == "Warning") dataGridView1["sensor_5", dataGridView1.Rows.Count - 1].Style.BackColor = Color.Yellow;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            send = "1";
            if (serialPort1.IsOpen == true) serialPort1.Write(send);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            send = "2";
            if (serialPort1.IsOpen == true) serialPort1.Write(send);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            send = "0";
            if (serialPort1.IsOpen == true) serialPort1.Write(send);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            send = "3";
            if (serialPort1.IsOpen == true) serialPort1.Write(send);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            send = "4";
            if (serialPort1.IsOpen == true) serialPort1.Write(send);
        }
    }
}
