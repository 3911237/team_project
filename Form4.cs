using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kwangwoon_Sugang_Practice_Project
{
    public partial class Form4 : Form
    {

        private string[,] dataGridViewData; // Field to store the data received from Form1

        public string[,] DataGridViewData
        {
            get { return dataGridViewData; }
            set { dataGridViewData = value; PopulateTableLayoutPanel(); }
        }

        public Form4()
        {
            InitializeComponent();
            
        }

        private void PopulateTableLayoutPanel()
        {
            // Clear any existing controls in the TableLayoutPanel
            tableLayoutPanel.Controls.Clear();
            tableLayoutPanel.RowStyles.Clear();
            tableLayoutPanel.RowCount = 0;

            int rowCount = dataGridViewData.GetLength(0); // Get the number of rows from the array

            // Iterate over the data received from Form1 and create panels to display the values
            for (int i = 0; i < rowCount; i++)
            {
                Panel panel = new Panel();
                panel.Dock = DockStyle.Fill;
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.AutoSize = true;

                TableLayoutPanel innerTableLayoutPanel = new TableLayoutPanel();
                innerTableLayoutPanel.Dock = DockStyle.Fill;
                innerTableLayoutPanel.AutoSize = true;

                innerTableLayoutPanel.ColumnCount = 3;

                string value1 = dataGridViewData[i, 0];
                string value2 = dataGridViewData[i, 1];
                string value3 = dataGridViewData[i, 2];

                Label label1 = new Label();
                label1.Text = value1;
                label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;

                Label label2 = new Label();
                label2.Text = value2;
                label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;

                Label label3 = new Label();
                label3.Text = value3;
                label3.Anchor = AnchorStyles.Left | AnchorStyles.Right;

                innerTableLayoutPanel.Controls.Add(label1, 0, 0);
                innerTableLayoutPanel.Controls.Add(label2, 1, 0);
                innerTableLayoutPanel.Controls.Add(label3, 2, 0);

                panel.Controls.Add(innerTableLayoutPanel);

                // Add the panel to the TableLayoutPanel
                tableLayoutPanel.RowCount++;
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tableLayoutPanel.Controls.Add(panel, 0, i);
            }
        }




        /*
        public void ShowDataFromDataGridView(string[,] dataGridValues)
        {
            // Clear the existing label text
            lblDisplayValues.Text = string.Empty;

            // Loop through the DataGridView values and append them to the label text
            for (int row = 0; row < dataGridValues.GetLength(0); row++)
            {
                for (int col = 0; col < dataGridValues.GetLength(1); col++)
                {
                    string value = dataGridValues[row, col];
                    lblDisplayValues.Text += value + " ";
                }
                lblDisplayValues.Text += Environment.NewLine;
            }
        }
        */
        /*
        public void ShowDataFromDataGridView(string[,] dataGridValues)
        {
            // Clear the existing labels
            panelLabels.Controls.Clear();

            // Loop through the DataGridView values and create labels for each item
            for (int row = 0; row < dataGridValues.GetLength(0); row++)
            {
                for (int col = 0; col < dataGridValues.GetLength(1); col++)
                {
                    string value = dataGridValues[row, col];

                    // Create a new label
                    Label label = new Label();
                    label.Text = value;
                    label.AutoSize = true;

                    // Position the label based on its row and column index
                    label.Location = new Point(col * 100, row * 30);

                    // Add the label to the panel
                    panelLabels.Controls.Add(label);
                }
            }
        }*/


    }


}


