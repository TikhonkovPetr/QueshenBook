using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace QueshensBook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            BackColor = Color.White;
            button1.BackColor = Color.Coral;
            button2.BackColor = Color.Coral;
            button3.BackColor = Color.Coral;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAdd formadd = new FormAdd();
            formadd.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormCheck formCheck = new FormCheck();
            formCheck.Show();
            this.Hide();
        }
    }
    [Serializable]
    static class InnerQusen
    {
        static public List<Qusen>? qusens = new List<Qusen>();
    }
}