using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        private List<Unit> units = new List<Unit>();

        public Form4()
        {
            InitializeComponent();

            
            dataGridView1.Columns.Add("NameColumn", "Назва");
            dataGridView1.Columns.Add("LocationColumn", "Локація");
            dataGridView1.Columns.Add("NumberOfPersonnelColumn", "Кількість людей");
            dataGridView1.Columns.Add("MissionColumn", "Mісія");
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            
            dataGridView1.Columns["NumberOfPersonnelColumn"].ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;

            
            LoadDataFromFile("unit.txt");
            LoadPersonnelData("data.txt");
        }

        private void LoadDataFromFile(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        Unit unit = new Unit
                        {
                            Name = parts[0].Trim(),
                            Location = parts[1].Trim(),
                            Mission = parts[3].Trim()
                        };
                        units.Add(unit);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        private void LoadPersonnelData(string filePath)
        {
            Dictionary<string, int> unitPersonnelCount = new Dictionary<string, int>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 12)
                    {
                        string unitName = parts[8].Trim();
                        if (unitPersonnelCount.ContainsKey(unitName))
                        {
                            unitPersonnelCount[unitName]++;
                        }
                        else
                        {
                            unitPersonnelCount[unitName] = 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading personnel data: " + ex.Message);
            }

            dataGridView1.Rows.Clear();

            foreach (var kvp in unitPersonnelCount)
            {
                var unit = units.Find(u => u.Name == kvp.Key);
                dataGridView1.Rows.Add(kvp.Key, unit?.Location ?? "", kvp.Value, unit?.Mission ?? "");
            }
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string unitName = dataGridView1.Rows[e.RowIndex].Cells["NameColumn"].Value?.ToString();
                string location = dataGridView1.Rows[e.RowIndex].Cells["LocationColumn"].Value?.ToString();
                string mission = dataGridView1.Rows[e.RowIndex].Cells["MissionColumn"].Value?.ToString();

                var unit = units.FirstOrDefault(u => u.Name == unitName);
                if (unit != null)
                {
                    unit.Location = location;
                    unit.Mission = mission;
                }
                else
                {
                    units.Add(new Unit { Name = unitName, Location = location, Mission = mission });
                }
            }
        }

        private void SaveDataToFile(string filePath)
        {
            try
            {
                var lines = new List<string>();
                foreach (var unit in units)
                {
                    lines.Add($"{unit.Name},{unit.Location},{unit.NumberOfPersonnel},{unit.Mission}");
                }
                File.WriteAllLines(filePath, lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveDataToFile("unit.txt");
            MessageBox.Show("Data saved successfully.");
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}