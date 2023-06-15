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
        // Field to store the data received from Form2
        private string[,] dataGridViewData; 

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

            int l = 0;

            for (int i = 0; i < dataRowCount; i++)
            {
                string value1 = dataGridViewData[i, 0];
                string value2 = dataGridViewData[i, 1];
                string value3 = dataGridViewData[i, 2];
                l = 0;

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
                if (value3.Contains("월0"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 0, 0); l++;
                }
                if (value3.Contains("월1"))
                {
                    if (!value3.Contains("월10") && !value3.Contains("월11") && !value3.Contains("월12"))
                        tableLayoutPanel.Controls.Add(panels[l], 0, 1); l++;
                }
                if (value3.Contains("월2"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 0, 2); l++;
                }
                if (value3.Contains("월3"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 0, 3); l++;
                }
                if (value3.Contains("월4"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 0, 4); l++;
                }
                if (value3.Contains("월5"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 0, 5); l++;
                }
                if (value3.Contains("월6"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 0, 6); l++;
                }
                if (value3.Contains("월7"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 0, 7); l++;
                }
                if (value3.Contains("월8"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 0, 8); l++;
                }
                if (value3.Contains("월9"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 0, 9); l++;
                }
                if (value3.Contains("월10"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 0, 10); l++;
                }
                if (value3.Contains("월11"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 0, 11); l++;
                }
                if (value3.Contains("월12"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 0, 12); l++;
                }
                if (value3.Contains("화0"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 1, 0); l++;
                }
                if (value3.Contains("화1"))
                {
                    if (!value3.Contains("화10") && !value3.Contains("화11") && !value3.Contains("화12"))
                        tableLayoutPanel.Controls.Add(panels[l], 1, 1); l++;
                }
                if (value3.Contains("화2"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 1, 2); l++;
                }
                if (value3.Contains("화3"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 1, 3); l++;
                }
                if (value3.Contains("화4"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 1, 4); l++;
                }
                if (value3.Contains("화5"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 1, 5); l++;
                }
                if (value3.Contains("화6"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 1, 6); l++;
                }
                if (value3.Contains("화7"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 1, 7); l++;
                }
                if (value3.Contains("화8"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 1, 8); l++;
                }
                if (value3.Contains("화9"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 1, 9); l++;
                }
                if (value3.Contains("화10"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 1, 10); l++;
                }
                if (value3.Contains("화11"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 1, 11); l++;
                }
                if (value3.Contains("화12"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 1, 12); l++;
                }
                if (value3.Contains("수0"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 2, 0); l++;
                }
                if (value3.Contains("수1"))
                {
                    if (!value3.Contains("수10") && !value3.Contains("수11") && !value3.Contains("수12"))
                    tableLayoutPanel.Controls.Add(panels[l], 2, 1); l++;
                }
                if (value3.Contains("수2"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 2, 2); l++;
                }
                if (value3.Contains("수3"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 2, 3); l++;
                }
                if (value3.Contains("수4"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 2, 4); l++;
                }
                if (value3.Contains("수5"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 2, 5); l++;
                }
                if (value3.Contains("수6"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 2, 6); l++;
                }
                if (value3.Contains("수7"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 2, 7); l++;
                }
                if (value3.Contains("수8"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 2, 8); l++;
                }
                if (value3.Contains("수9"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 2, 9); l++;
                }
                if (value3.Contains("수10"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 2, 10); l++;
                }
                if (value3.Contains("수11"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 2, 11); l++;
                }
                if (value3.Contains("수12"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 2, 12); l++;
                }
                if (value3.Contains("목0"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 3, 0); l++;
                }
                if (value3.Contains("목1"))
                {
                    if (!value3.Contains("목10") && !value3.Contains("목11") && !value3.Contains("목12"))
                        tableLayoutPanel.Controls.Add(panels[l], 3, 1); l++;
                }
                if (value3.Contains("목2"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 3, 2); l++;
                }
                if (value3.Contains("목3"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 3, 3); l++;
                }
                if (value3.Contains("목4"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 3, 4); l++;
                }
                if (value3.Contains("목5"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 3, 5); l++;
                }
                if (value3.Contains("목6"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 3, 6); l++;
                }
                if (value3.Contains("목7"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 3, 7); l++;
                }
                if (value3.Contains("목8"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 3, 8); l++;
                }
                if (value3.Contains("목9"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 3, 9); l++;
                }
                if (value3.Contains("목10"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 3, 10); l++;
                }
                if (value3.Contains("목11"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 3, 11); l++;
                }
                if (value3.Contains("목12"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 3, 12); l++;
                }
                if (value3.Contains("금0"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 4, 0); l++;
                }
                if (value3.Contains("금1"))
                {
                    if (!value3.Contains("금10") && !value3.Contains("금11") && !value3.Contains("금12"))
                        tableLayoutPanel.Controls.Add(panels[l], 4, 1); l++;
                }
                if (value3.Contains("금2"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 4, 2); l++;
                }
                if (value3.Contains("금3"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 4, 3); l++;
                }
                if (value3.Contains("금4"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 4, 4); l++;
                }
                if (value3.Contains("금5"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 4, 5); l++;
                }
                if (value3.Contains("금6"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 4, 6); l++;
                }
                if (value3.Contains("금7"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 4, 7); l++;
                }
                if (value3.Contains("금8"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 4, 8); l++;
                }
                if (value3.Contains("금9"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 4, 9); l++;
                }
                if (value3.Contains("금10"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 4, 10); l++;
                }
                if (value3.Contains("금11"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 4, 11); l++;
                }
                if (value3.Contains("금12"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 4, 12); l++;
                }
                if (value3.Contains("토0"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 5, 0); l++;
                }
                if (value3.Contains("토1"))
                {
                    if (!value3.Contains("토10") && !value3.Contains("토11") && !value3.Contains("토12"))
                        tableLayoutPanel.Controls.Add(panels[l], 5, 1); l++;
                }
                if (value3.Contains("토2"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 5, 2); l++;
                }
                if (value3.Contains("토3"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 5, 3); l++;
                }
                if (value3.Contains("토4"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 5, 4); l++;
                }
                if (value3.Contains("토5"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 5, 5); l++;
                }
                if (value3.Contains("토6"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 5, 6); l++;
                }
                if (value3.Contains("토7"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 5, 7); l++;
                }
                if (value3.Contains("토8"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 5, 8); l++;
                }
                if (value3.Contains("토9"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 5, 9); l++;
                }
                if (value3.Contains("토10"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 5, 10); l++;
                }
                if (value3.Contains("토11"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 5, 11); l++;
                }
                if (value3.Contains("토12"))
                {
                    tableLayoutPanel.Controls.Add(panels[l], 5, 12); l++;
                }
            }


        }


    }


}


