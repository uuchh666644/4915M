﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace afterservice
{
    public partial class record1 : Form
    {
        GuestClass record = new GuestClass();
        public record1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void record_Load(object sender, EventArgs e)
            {
                showTable();
            }
        public void showTable()
            {
                dataGridView1.DataSource = record.getRecordlist();

            }
        

        private void button1_Click(object sender, EventArgs e)
        {
            string searchw = textBox_search.Text;
            string selectedColumn = comboBox1.Text;

            DataTable results = record.getRecordkeylist(selectedColumn, searchw);
            dataGridView1.DataSource = results;
        }
    }
}
