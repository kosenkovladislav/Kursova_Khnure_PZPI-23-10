using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private List<MilitaryPersonnel> personnelList;
        private Dictionary<string, object> filters;

        public Form2()
        {
            InitializeComponent();
            InitializeComboBoxes();
            InitializeData();
            InitializeFilters();
            DisplayData();

           
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
        }

        private void InitializeFilters()
        {
            filters = new Dictionary<string, object>
            {
                { "Age", null },
                { "Gender", null },
                { "Profession", null },
                { "Education", null },
                { "Rank", null },
                { "ServiceType", null },
                { "Unit", null }
            };
        }

        public void InitializeData()
        {
            personnelList = new List<MilitaryPersonnel>();

            string[] lines = File.ReadAllLines("data.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length == 12)
                {
                    string name = parts[0].Trim();
                    int age = int.Parse(parts[1].Trim());
                    string gender = parts[2].Trim();
                    string address = parts[3].Trim();
                    string profession = parts[4].Trim();
                    string education = parts[5].Trim();
                    string rank = parts[6].Trim();
                    string rankDate = parts[7].Trim();
                    string unit = parts[8].Trim();
                    string serviceType = parts[9].Trim();
                    string servicePeriod = parts[10].Trim();
                    string personalityTraits = parts[11].Trim();

                    personnelList.Add(new MilitaryPersonnel(name, age, gender, address, profession, education,
                                                             rank, rankDate, unit, serviceType, servicePeriod,
                                                             personalityTraits));
                }
                else
                {
                    Console.WriteLine("Некоректний формат в data.txt: " + line);
                }
            }
        }

        public void DisplayData()
        {
            List<MilitaryPersonnel> filteredList = ApplyFilters(personnelList);

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("Ім'я", "Ім'я");
            dataGridView1.Columns.Add("Вік", "Вік");
            dataGridView1.Columns.Add("Стать", "Стать");
            dataGridView1.Columns.Add("Адреса", "Адреса");
            dataGridView1.Columns.Add("Професія", "Професія");
            dataGridView1.Columns.Add("Освіта", "Освіта");
            dataGridView1.Columns.Add("Звання", "Звання");
            dataGridView1.Columns.Add("Дата звання", "Дата звання");
            dataGridView1.Columns.Add("Підрозділ", "Підрозділ");
            dataGridView1.Columns.Add("Тип служби", "Тип служби");
            dataGridView1.Columns.Add("Період служби", "Період служби");
            dataGridView1.Columns.Add("Особисті якості", "Особисті якості");

           
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.ReadOnly = false;
            }

            UpdateDataGridView(filteredList);
        }

        private List<MilitaryPersonnel> ApplyFilters(List<MilitaryPersonnel> list)
        {
            IEnumerable<MilitaryPersonnel> filteredList = list;

            if (filters["Age"] != null)
            {
                int age = (int)filters["Age"];
                filteredList = filteredList.Where(person => person.Age == age);
            }

            if (filters["Gender"] != null)
            {
                string gender = (string)filters["Gender"];
                filteredList = filteredList.Where(person => person.Gender == gender);
            }

            if (filters["Profession"] != null)
            {
                string profession = (string)filters["Profession"];
                filteredList = filteredList.Where(person => person.Profession == profession);
            }

            if (filters["Education"] != null)
            {
                string education = (string)filters["Education"];
                filteredList = filteredList.Where(person => person.Education == education);
            }

            if (filters["Rank"] != null)
            {
                string rank = (string)filters["Rank"];
                filteredList = filteredList.Where(person => person.Rank == rank);
            }

            if (filters["ServiceType"] != null)
            {
                string serviceType = (string)filters["ServiceType"];
                filteredList = filteredList.Where(person => person.ServiceType == serviceType);
            }

            if (filters["Unit"] != null)
            {
                string unit = (string)filters["Unit"];
                filteredList = filteredList.Where(person => person.Unit == unit);
            }

            return filteredList.ToList();
        }

        private void UpdateDataGridView(List<MilitaryPersonnel> filteredData)
        {
            dataGridView1.Rows.Clear();
            foreach (var person in filteredData)
            {
                dataGridView1.Rows.Add(
                    person.Name,
                    person.Age,
                    person.Gender,
                    person.Address,
                    person.Profession,
                    person.Education,
                    person.Rank,
                    person.RankDate,
                    person.Unit,
                    person.ServiceType,
                    person.ServicePeriod,
                    person.PersonalityTraits
                );
            }
        }

        private void InitializeComboBoxes()
        {
            comboBox1.Items.Add("");
            for (int i = 18; i <= 60; i++)
            {
                comboBox1.Items.Add(i);
            }

            comboBox2.Items.Add("");
            comboBox2.Items.Add("Чоловік");
            comboBox2.Items.Add("Жінка");
            comboBox3.Items.Add("");
            comboBox3.Items.Add("Водій");
            comboBox3.Items.Add("Штурмовик");
            comboBox3.Items.Add("Артилерист");
            comboBox3.Items.Add("Зв'язківець");
            comboBox3.Items.Add("Інженер");
            comboBox3.Items.Add("Снайпер");
            comboBox3.Items.Add("Танкіст");
            comboBox3.Items.Add("Пілот");
            comboBox3.Items.Add("Медик");

            comboBox4.Items.Add("");
            comboBox4.Items.Add("Середня");
            comboBox4.Items.Add("Вища");

            comboBox5.Items.Add("");
            comboBox5.Items.Add("Солдат");
            comboBox5.Items.Add("Молодший сержант");
            comboBox5.Items.Add("Сержант");
            comboBox5.Items.Add("Старший сержант");
            comboBox5.Items.Add("Прапорщик");
            comboBox5.Items.Add("Молодший лейтенант");
            comboBox5.Items.Add("Лейтенант");
            comboBox5.Items.Add("Старший лейтенант");

            comboBox6.Items.Add("");
            comboBox6.Items.Add("Звичайний");
            comboBox6.Items.Add("Контрактний");

            comboBox7.Items.Add("");
            comboBox7.Items.Add("1");
            comboBox7.Items.Add("2");
            comboBox7.Items.Add("3");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox1.SelectedItem.ToString() == "")
            {
                filters["Age"] = null;
            }
            else
            {
                filters["Age"] = Convert.ToInt32(comboBox1.SelectedItem);
            }
            DisplayData();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null || comboBox2.SelectedItem.ToString() == "")
            {
                filters["Gender"] = null;
            }
            else
            {
                filters["Gender"] = comboBox2.SelectedItem.ToString();
            }
            DisplayData();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem == null || comboBox3.SelectedItem.ToString() == "")
            {
                filters["Profession"] = null;
            }
            else
            {
                filters["Profession"] = comboBox3.SelectedItem.ToString();
            }
            DisplayData();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem == null || comboBox4.SelectedItem.ToString() == "")
            {
                filters["Education"] = null;
            }
            else
            {
                filters["Education"] = comboBox4.SelectedItem.ToString();
            }
            DisplayData();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedItem == null || comboBox5.SelectedItem.ToString() == "")
            {
                filters["Rank"] = null;
            }
            else
            {
                filters["Rank"] = comboBox5.SelectedItem.ToString();
            }
            DisplayData();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.SelectedItem == null || comboBox6.SelectedItem.ToString() == "")
            {
                filters["ServiceType"] = null;
            }
            else
            {
                filters["ServiceType"] = comboBox6.SelectedItem.ToString();
            }
            DisplayData();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.SelectedItem == null || comboBox7.SelectedItem.ToString() == "")
            {
                filters["Unit"] = null;
            }
            else
            {
                filters["Unit"] = comboBox7.SelectedItem.ToString();
            }
            DisplayData();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string personName = dataGridView1.Rows[e.RowIndex].Cells["Ім'я"].Value.ToString();
                var person = personnelList.Find(p => p.Name == personName);
                if (person != null)
                {
                    person.Age = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Вік"].Value.ToString());
                    person.Gender = dataGridView1.Rows[e.RowIndex].Cells["Стать"].Value.ToString();
                    person.Address = dataGridView1.Rows[e.RowIndex].Cells["Адреса"].Value.ToString();
                    person.Profession = dataGridView1.Rows[e.RowIndex].Cells["Професія"].Value.ToString();
                    person.Education = dataGridView1.Rows[e.RowIndex].Cells["Освіта"].Value.ToString();
                    person.Rank = dataGridView1.Rows[e.RowIndex].Cells["Звання"].Value.ToString();
                    person.RankDate = dataGridView1.Rows[e.RowIndex].Cells["Дата звання"].Value.ToString();
                    person.Unit = dataGridView1.Rows[e.RowIndex].Cells["Підрозділ"].Value.ToString();
                    person.ServiceType = dataGridView1.Rows[e.RowIndex].Cells["Тип служби"].Value.ToString();
                    person.ServicePeriod = dataGridView1.Rows[e.RowIndex].Cells["Період служби"].Value.ToString();
                    person.PersonalityTraits = dataGridView1.Rows[e.RowIndex].Cells["Особисті якості"].Value.ToString();
                }
            }
        }

        private void SaveDataToFile(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var person in personnelList)
                    {
                        writer.WriteLine($"{person.Name},{person.Age},{person.Gender},{person.Address},{person.Profession},{person.Education},{person.Rank},{person.RankDate},{person.Unit},{person.ServiceType},{person.ServicePeriod},{person.PersonalityTraits}");
                    }
                }
                MessageBox.Show("Дані успішно збережені!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при збереженні даних: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveDataToFile("data.txt");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Delete deleteForm = new Delete(personnelList);
            deleteForm.Show();
        }
    }

    
    
}