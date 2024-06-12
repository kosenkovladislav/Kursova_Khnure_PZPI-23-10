using System;
using System.Collections.Generic;
using System.IO; 
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Delete : Form
    {
        private List<MilitaryPersonnel> personnelList; 

        public Delete(List<MilitaryPersonnel> personnelList)
        {
            InitializeComponent();
            this.personnelList = personnelList; 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string nameToDelete = textBox1.Text; 

            
            MilitaryPersonnel personnelToDelete = personnelList.FirstOrDefault(person => person.Name == nameToDelete);

            if (personnelToDelete != null)
            {
               
                personnelList.Remove(personnelToDelete);

                
                Form2 mainForm = (Form2)Application.OpenForms["Form2"];
                mainForm.DisplayData();

               
                UpdateDataFile();

               
                MessageBox.Show("Військовослужбовця успішно видалено.");
            }
            else
            {
                MessageBox.Show("Військовослужбовця з таким іменем не знайдено.");
            }
        }

      
        private void UpdateDataFile()
        {
           
            List<string> lines = new List<string>();

           
            foreach (var personnel in personnelList)
            {
                string line = $"{personnel.Name},{personnel.Age},{personnel.Gender},{personnel.Address},{personnel.Profession},{personnel.Education},{personnel.Rank},{personnel.RankDate},{personnel.Unit},{personnel.ServiceType},{personnel.ServicePeriod},{personnel.PersonalityTraits}";
                lines.Add(line);
            }

            
            File.WriteAllLines("data.txt", lines);
        }

       
    }
}