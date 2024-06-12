using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string login = textBox1.Text;
            string password = textBox2.Text;

            
            if (login == "123" && password == "123")
            {
               
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide(); 
            }
            else
            {
                
                MessageBox.Show("Неправильний логін або пароль");
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
