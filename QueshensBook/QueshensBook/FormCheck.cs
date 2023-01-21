using Microsoft.VisualBasic.ApplicationServices;
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
namespace QueshensBook
{
    public partial class FormCheck : Form
    {
        public FormCheck()
        {
            InitializeComponent();
        }
        List<Qusen> zapas = new List<Qusen>();
        List<Sort> sorting = new List<Sort> { new Sort("По дате",0), new Sort("По возрастанию сложности", 1), new Sort("По убыванию сложности", 2) };
        private async void FormCheck_Load(object sender, EventArgs e)
        {
            listBox1.DisplayMember = nameof(Qusen.Zag);
            listBox2.DisplayMember = nameof(Qusen.Zag);
            comboBox1.DisplayMember = nameof(Sort.NameSort);
            listBox2.ForeColor = Color.Red;
            BackColor = Color.White;
            button1.BackColor = Color.Coral;
            button2.BackColor = Color.Coral;
            label1.BackColor = Color.MediumTurquoise;
            label2.BackColor = Color.Coral;
            label3.BackColor = Color.MediumTurquoise;
            label4.BackColor = Color.MediumTurquoise;
            label9.BackColor = Color.White;
            label10.BackColor = Color.MediumTurquoise;
            monthCalendar1.TrailingForeColor = Color.Gray;
            foreach (Sort s in sorting)
            {
                comboBox1.Items.Add(s);
            }
            foreach (Qusen qusen in InnerQusen.qusens)
            {
                listBox1.Items.Add(qusen);
                if (qusen.data == monthCalendar1.TodayDate)
                {
                    zapas.Add(qusen);
                    listBox2.Items.Add(qusen);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Qusen qusen = listBox1.SelectedItem as Qusen;
            int prov = 0;
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                if (qusen == listBox2.Items[i])
                {
                    listBox2.SelectedItem = qusen;
                    break;
                }
            }
            label2.Text = qusen.Opis;
            monthCalendar1.SelectionStart = qusen.data;
            monthCalendar1.SelectionEnd = qusen.data;
            label6.Text = "2";
            label7.Text = "3";
            label8.Text = "4";
            label9.Text = "5";
            switch (qusen.Sloth)
            {
                case 1:
                    label5.BackColor = Color.Green;
                    label6.BackColor = Color.LightGray;
                    label7.BackColor = Color.LightGray;
                    label8.BackColor = Color.LightGray;
                    label9.BackColor = Color.LightGray;
                    label6.Text = "";
                    label7.Text = "";
                    label8.Text = "";
                    label9.Text = "";
                    break;
                case 2:
                    label5.BackColor = Color.DarkGreen;
                    label6.BackColor = Color.DarkGreen;
                    label7.BackColor = Color.LightGray;
                    label8.BackColor = Color.LightGray;
                    label9.BackColor = Color.LightGray;
                    label7.Text = "";
                    label8.Text = "";
                    label9.Text = "";
                    break;
                case 3:
                    label5.BackColor = Color.Yellow;
                    label6.BackColor = Color.Yellow;
                    label7.BackColor = Color.Yellow;
                    label8.BackColor = Color.LightGray;
                    label9.BackColor = Color.LightGray;
                    label8.Text = "";
                    label9.Text = "";
                    break;
                case 4:
                    label5.BackColor = Color.Orange;
                    label6.BackColor = Color.Orange;
                    label7.BackColor = Color.Orange;
                    label8.BackColor = Color.Orange;
                    label9.BackColor = Color.LightGray;
                    label9.Text = "";
                    break;
                case 5:
                    label5.BackColor = Color.Red;
                    label6.BackColor = Color.Red;
                    label7.BackColor = Color.Red;
                    label8.BackColor = Color.Red;
                    label9.BackColor = Color.Red;
                    break;
            }
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.SelectedItem = listBox2.SelectedItem as Qusen;
            Qusen qusen = listBox2.SelectedItem as Qusen;
            label2.Text = qusen.Opis;
            monthCalendar1.SelectionStart = qusen.data;
            monthCalendar1.SelectionEnd = qusen.data;
            switch (qusen.Sloth)
            {
                case 1:
                    label5.BackColor = Color.Green;
                    label6.BackColor = Color.White;
                    label7.BackColor = Color.White;
                    label8.BackColor = Color.White;
                    label9.BackColor = Color.White;
                    break;
                case 2:
                    label5.BackColor = Color.DarkGreen;
                    label6.BackColor = Color.DarkGreen;
                    label7.BackColor = Color.White;
                    label8.BackColor = Color.White;
                    label9.BackColor = Color.White;
                    break;
                case 3:
                    label5.BackColor = Color.Yellow;
                    label6.BackColor = Color.Yellow;
                    label7.BackColor = Color.Yellow;
                    label8.BackColor = Color.White;
                    label9.BackColor = Color.White;
                    break;
                case 4:
                    label5.BackColor = Color.Orange;
                    label6.BackColor = Color.Orange;
                    label7.BackColor = Color.Orange;
                    label8.BackColor = Color.Orange;
                    label9.BackColor = Color.White;
                    break;
                case 5:
                    label5.BackColor = Color.Red;
                    label6.BackColor = Color.Red;
                    label7.BackColor = Color.Red;
                    label8.BackColor = Color.Red;
                    label9.BackColor = Color.Red;
                    break;
            }
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            Qusen qusen1 = listBox1.SelectedItem as Qusen;
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            zapas.Remove(qusen1);
            foreach (Qusen qusen in zapas)
            {
                listBox2.Items.Add(qusen);
            }
            InnerQusen.qusens.Remove(qusen1);
            foreach (Qusen qusen in InnerQusen.qusens)
            {
                listBox1.Items.Add(qusen);
            }
            File.Delete("C:\\Users\\StudentApple\\Desktop\\QueshensBook\\SaveQue.json");
            using (FileStream Fill = new FileStream("C:\\Users\\StudentApple\\Desktop\\QueshensBook\\SaveQue.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<List<Qusen>>(Fill, InnerQusen.qusens);
            }
            label2.Text = "Ваше описание задачи";
            monthCalendar1.SelectionStart = monthCalendar1.TodayDate;
            monthCalendar1.SelectionEnd = monthCalendar1.TodayDate;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        public class Sort
        {
            public string NameSort { get; set; }
            public int Number { get; set; }
            public Sort(string str,int num)
            {
                this.NameSort = str;
                this.Number = num;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = comboBox1.SelectedIndex;
            switch (a)
            {
                case 0:
                    List<Qusen> qq1 = new List<Qusen>();
                    foreach(Qusen q in listBox1.Items)
                    {
                        qq1.Add(q);
                    }
                    listBox1.Items.Clear();
                    qq1.Sort(new Comparison<Qusen>((x,y)=>DateTime.Compare(x.data,y.data)));
                    foreach (Qusen q in qq1)
                    {
                        listBox1.Items.Add(q);
                    }
                    break;
                case 1:
                    List<Qusen> qq2 = new List<Qusen>();
                    foreach (Qusen q in listBox1.Items)
                    {
                        qq2.Add(q);
                    }
                    listBox1.Items.Clear();
                    List<Qusen> Q = qq2.OrderBy(q => q.Sloth).ToList();
                    foreach (Qusen q in Q)
                    {
                        listBox1.Items.Add(q);
                    }
                    break;
                case 2:
                    List<Qusen> qq3 = new List<Qusen>();
                    foreach (Qusen q in listBox1.Items)
                    {
                        qq3.Add(q);
                    }
                    listBox1.Items.Clear();
                    List<Qusen> QQ = qq3.OrderByDescending(q => q.Sloth).ToList();
                    foreach (Qusen q in QQ)
                    {
                        listBox1.Items.Add(q);
                    }
                    break;

            }
        }
    }
}
