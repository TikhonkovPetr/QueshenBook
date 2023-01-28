using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace QueshensBook
{
    public partial class FormAdd : Form
    {
        public FormAdd()
        {
            InitializeComponent();
        }
        public Qusen qusen = new Qusen();
        private void FormAdd_Load(object sender, EventArgs e)
        {
            BackColor = Color.White;
            button1.BackColor = Color.Coral;
            button2.BackColor = Color.Coral;
            label1.BackColor = Color.MediumTurquoise;
            label2.BackColor = Color.MediumTurquoise;
            label3.BackColor = Color.MediumTurquoise;
            label4.BackColor = Color.MediumTurquoise;
            dateTimePicker1.CalendarForeColor = Color.White;
            dateTimePicker1.CalendarTrailingForeColor = Color.Gray;
            qusen.Zag = null;
            qusen.Opis = null;
            qusen.Sloth = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 =new Form1();
            form1.Show();
            Close();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            qusen.Zag = textBox1.Text;
            if(textBox2.Text!="")
            qusen.Opis = textBox2.Text;
            qusen.data = dateTimePicker1.Value.Date;
            if (qusen.Zag != null && qusen.Opis != null && qusen.Sloth != 0)
            {
                InnerQusen.qusens.Add(qusen);
                using (FileStream Fill=new FileStream("SaveQue.json", FileMode.OpenOrCreate))
                {
                    await JsonSerializer.SerializeAsync<List<Qusen>>(Fill, InnerQusen.qusens);
                }
                Form1 form1 = new Form1();
                form1.Show();
                Close();
            }
            else
            {
                MessageBox.Show(
                    "Все поля должны быть заполнены",
                    "Не все поля заполнены",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
            }
        }

        private void button_Sloth3_Click(object sender, EventArgs e)
        {

        }

        private void button_Sloth1_Click(object sender, EventArgs e)
        {
            button_Sloth1.BackColor=Color.Green;
            button_Sloth2.BackColor = Color.White;
            button_Sloth3.BackColor = Color.White;
            button_Sloth4.BackColor = Color.White;
            button_Sloth5.BackColor = Color.White;
            qusen.Sloth = 1;
        }

        private void button_Sloth2_Click(object sender, EventArgs e)
        {
            button_Sloth1.BackColor = Color.DarkGreen;
            button_Sloth2.BackColor = Color.DarkGreen;
            button_Sloth3.BackColor = Color.White;
            button_Sloth4.BackColor = Color.White;
            button_Sloth5.BackColor = Color.White;
            qusen.Sloth = 2;
        }

        private void button_Sloth3_Click_1(object sender, EventArgs e)
        {
            button_Sloth1.BackColor = Color.Yellow;
            button_Sloth2.BackColor = Color.Yellow;
            button_Sloth3.BackColor = Color.Yellow;
            button_Sloth4.BackColor = Color.White;
            button_Sloth5.BackColor = Color.White;
            qusen.Sloth = 3;
        }

        private void button_Sloth4_Click(object sender, EventArgs e)
        {
            button_Sloth1.BackColor = Color.Orange;
            button_Sloth2.BackColor = Color.Orange;
            button_Sloth3.BackColor = Color.Orange;
            button_Sloth4.BackColor = Color.Orange;
            button_Sloth5.BackColor = Color.White;
            qusen.Sloth = 4;
        }

        private void button_Sloth5_Click(object sender, EventArgs e)
        {
            button_Sloth1.BackColor = Color.Red;
            button_Sloth2.BackColor = Color.Red;
            button_Sloth3.BackColor = Color.Red;
            button_Sloth4.BackColor = Color.Red;
            button_Sloth5.BackColor = Color.Red;
            qusen.Sloth = 5;
        }
    }
    [Serializable]
    public class Qusen
    {
        public string Zag { get; set; }
        public string Opis { get; set; }
        public DateTime data { get; set; }
        public int Sloth{get;set;}
    }
}
