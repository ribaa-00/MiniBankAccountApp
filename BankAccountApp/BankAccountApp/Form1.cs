using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankAccountApp
{
    public partial class Form1 : Form
    {
        List<BankAccount> AllAccount = new List<BankAccount>();
    
        public Form1()
        {
            InitializeComponent();          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
                return;

            BankAccount bankaccount1 = new BankAccount(textBox1.Text);

            AllAccount.Add(bankaccount1);
            RefreshGuid();
            MessageBox.Show("AccountCreateSuccessfully");


        }
        public void RefreshGuid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = AllAccount;
            textBox1.Text = "";
        }



        private void button2_Click(object sender, EventArgs e)
        {
            0BankAccount SelectAccount = dat1aGridView1.SelectedRows[0].DataBoundItem as BankAccount;
            SelectAccount.Balance += numericUpDown1.Value;
            RefreshGuid();
            numericUpDown1.Value = 0;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            BankAccount SelectAccount = dataGridView1.SelectedRows[0].DataBoundItem as BankAccount;
            decimal withdrawAmount = numericUpDown1.Value;
          

            if (SelectAccount.Balance < withdrawAmount)
            {
                MessageBox.Show("insufficient balance");
                return;
            }

            SelectAccount.Balance -= numericUpDown1.Value;
            RefreshGuid();
            numericUpDown1.Value = 0;

        }

    }
}
