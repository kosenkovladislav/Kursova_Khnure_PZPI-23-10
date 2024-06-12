using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {

        private List<MilitaryPersonnel> personnelList = new List<MilitaryPersonnel>();
        public Form3()
        {
            this.Load += new System.EventHandler(this.Form_Load);
            InitializeComponent();
        }

        
        private void Form_Load(object sender, EventArgs e)
        {
            
            comboBox1.Items.Add("Чоловік");
            comboBox1.Items.Add("Жінка");
            comboBox2.Items.Add("Вища");
            comboBox2.Items.Add("Середня");
            comboBox3.Items.Add("1");
            comboBox3.Items.Add("2");
            comboBox3.Items.Add("3");
            comboBox4.Items.Add("Звичайний");
            comboBox4.Items.Add("Контрактний");
            comboBox5.Items.Add("Солдат");
            comboBox5.Items.Add("Молодший сержант");
            comboBox5.Items.Add("Сержант");
            comboBox5.Items.Add("Старший сержант");
            comboBox5.Items.Add("Прапорщик");
            comboBox5.Items.Add("Молодший лейтенант");
            comboBox5.Items.Add("Лейтенант");
            comboBox5.Items.Add("Старший лейтенант");
            comboBox6.Items.Add("Водій");
            comboBox6.Items.Add("Штурмовик");
            comboBox6.Items.Add("Артилерист");
            comboBox6.Items.Add("Зв'язківець");
            comboBox6.Items.Add("Інженер");
            comboBox6.Items.Add("Снайпер");
            comboBox6.Items.Add("Танкіст");
            comboBox6.Items.Add("Пілот");
            comboBox6.Items.Add("Медик");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string name = textBox1.Text;
          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int age))
            {
                
            }
            else
            {
                MessageBox.Show("Будь ласка, введіть ціле число для віку.");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string selectedGender = comboBox1.SelectedItem.ToString();
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
          
            string address = textBox3.Text;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string profession = comboBox6.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           string education = comboBox2.SelectedItem.ToString();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string rank = comboBox5.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
          string RankDate = textBox6.Text;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           string unit = comboBox3.SelectedItem.ToString();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
           
          string serviceType = comboBox4.SelectedItem.ToString();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
          
           string servicePeriod = textBox7.Text;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
          
           string personalityTraits = textBox8.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            Form2 form2 = Application.OpenForms.OfType<Form2>().FirstOrDefault();
            if (form2 != null)
            {
              
                string name = textBox1.Text;
                int age = int.Parse(textBox2.Text); 
                string gender = comboBox1.SelectedItem.ToString();
                string address = textBox3.Text;
                string profession = comboBox6.Text;
                string education = comboBox2.SelectedItem.ToString();
                string rank = comboBox5.Text;
                string rankDate = textBox6.Text;
                string unit = comboBox3.SelectedItem.ToString();
                string serviceType = comboBox4.SelectedItem.ToString();
                string servicePeriod = textBox7.Text;
                string personalityTraits = textBox8.Text;

                string dataLine = $"{name},{age},{gender},{address},{profession},{education},{rank},{rankDate},{unit},{serviceType},{servicePeriod},{personalityTraits}";

              
                string filePath = "data.txt";

                try
                {
                   
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine(dataLine);
                    }

                    MessageBox.Show("Дані успішно збережено у файл data.txt");

                    
                    form2.InitializeData();
                    form2.DisplayData();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Сталася помилка при збереженні даних: {ex.Message}");
                }
            }
            
        }

        
    }
   
}
