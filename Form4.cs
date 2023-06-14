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

            int dataRowCount = dataGridViewData.GetLength(0); // Get the number of rows from the data

            // Set the border style and fixed size for each panel
            tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel.Padding = new Padding(4);

            // Define an array of colors to be used for each panel
            Color[] panelColors = new Color[] { Color.LightBlue, Color.LightGreen, Color.LightYellow, Color.LightPink, Color.LightCoral, Color.LightSalmon, Color.LightSkyBlue, Color.LightGray };

            // Create panel instances for each cell
            Panel[] panels = new Panel[8];

            // Create labels for each panel
            Label[] label1s = new Label[8];
            Label[] label2s = new Label[8];

            for (int i = 0; i < dataRowCount; i++)
            {
                string value1 = dataGridViewData[i, 0];
                string value2 = dataGridViewData[i, 1];
                string value3 = dataGridViewData[i, 2];

                for (int j = 0; j < 8; j++)
                {
                    // Create panel and label instances
                    panels[j] = new Panel();
                    label1s[j] = new Label();
                    label2s[j] = new Label();

                    // Set common properties for the panels
                    panels[j].Dock = DockStyle.Fill;
                    panels[j].Margin = new Padding(0);

                    // Set the background color from the array
                    panels[j].BackColor = panelColors[i % panelColors.Length];

                    // Set common properties for the labels
                    label1s[j].AutoSize = false;
                    label1s[j].AutoEllipsis = true;
                    label2s[j].AutoSize = true;

                    // Set the text for the labels
                    label1s[j].Text = value1;
                    label2s[j].Text = value2;

                    // Set the position of labels within the panels
                    label1s[j].Location = new Point(4, 4);
                    label2s[j].Location = new Point(4, 30);

                    // Add the labels to the panels
                    panels[j].Controls.Add(label1s[j]);
                    panels[j].Controls.Add(label2s[j]);
                }

                // Add the panels to the TableLayoutPanel based on the condition
                if (value3 == "월1수2")
                {
                    tableLayoutPanel.Controls.Add(panels[0], 0, 1);
                    tableLayoutPanel.Controls.Add(panels[1], 1, 1);

                }
                else if (value3 == "월2수1")
                {
                    tableLayoutPanel.Controls.Add(panels[1], 0, 2);
                    tableLayoutPanel.Controls.Add(panels[2], 2, 1);
                }
                else
                {
                    tableLayoutPanel.Controls.Add(panels[1], 0, 6);
                }
            }


        }


    }


}


