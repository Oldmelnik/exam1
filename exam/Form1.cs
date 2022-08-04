using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace exam
{
    public partial class Form1 : Form
    {
        private Object Locker = new Object();
        public Product[] mas = { new Product("Яблоки", 120, 20, "США"), new Product("Груши", 350, 57, "Япония"), new Product("Сливы", 70, 80, "Россия") };

        public List<Product> list;
        public Dictionary<string, Product> dict;

        public Form1()
        {
            InitializeComponent();
            list = mas.Cast<Product>().ToList<Product>();
            update();
        }

        private void updateList()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = this.list;
        }

        private void updatedict()
        {
            dict = mas.Select((s) => new { Key = s.Name, Value = s }).ToDictionary(v => v.Key, v => v.Value);
        }

        private void updateCombo()
        {
            this.comboBox1.DataSource = list.Select(x => x.Name).ToList<string>();
            this.comboBox2.DataSource = dict.Keys.ToList<string>();
        }

        private void update()
        {
            updatedict();
            updateList();
            updateCombo();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            count();
        }

        private void button3_Click(object sender, EventArgs e)
        {
			try {
				if (Convert.ToInt32(this.textBox3.Text) < 1)
				{
					throw new Exception("Неправильный срок хранения");
				}
				var v = new Product(
					this.textBox1.Text,
					Convert.ToDouble(this.textBox2.Text),
					Convert.ToInt32(this.textBox3.Text),
					this.textBox4.Text);
				list.Add(v);
				update();
			}
			catch(Exception){
				MessageBox.Show("Ошибка");
			}
			
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Product v = list.Find(x => x.Name == this.comboBox1.Text);
            list.Remove(v);
            update();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product v;
            dict.TryGetValue(this.comboBox2.SelectedItem.ToString(), out v);
            this.textBox8.Text = v.Name;
            this.textBox7.Text = v.Cost.ToString();
            this.textBox6.Text = v.Srok.ToString(); ;
            this.textBox9.Text = v.Sort;
            this.textBox5.Text = v.Country;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int sum = 0;
            lock (Locker){
                
                foreach (var elem in list)
                {
                    sum += elem.Srok;
                }
            }
            MessageBox.Show(sum.ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Regex.IsMatch(this.textBox10.Text,  @"^\d{1,5} р\. \d{2} к\.").ToString());
        }

        private void count()
        {
            double sum = 0.0;
            foreach (var elem in list)
            {
                sum += elem.Cost;
            }
            MessageBox.Show(sum.ToString());
        }

        private async void t1Async()
        {
            await Task.Run(count);
            MessageBox.Show("асинхронно");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            t1Async();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            list.Select(x => x.Srok > 56).OrderBy(x => x);
        }
    }
}
