using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        List<Automovil> auto = new List<Automovil>();
        Boolean h = false;
        int c=0;
        public Form1()
        {
            InitializeComponent();
        }

        void agregar()
        {
            Automovil a = new Automovil();
            a.Placa = textBox1.Text;
            a.Marca = textBox2.Text;
            a.Modelo = textBox3.Text;
            a.Color = textBox4.Text;
            a.Preciok = Convert.ToDouble(textBox5.Text);
        }

        void escribirv()
        {
            FileStream stream = new FileStream("automovil.txt",FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter write = new StreamWriter(stream);
            foreach (var d in auto)
            {
                write.WriteLine(d.Placa);
                write.WriteLine(d.Marca);
                write.WriteLine(d.Modelo);
                write.WriteLine(d.Color);
                write.WriteLine(d.Preciok);
            }
            write.Close();
        }

        void leerv()
        {
            OpenFileDialog op = new OpenFileDialog();
            string filename = "automovil.txt";
            FileStream st = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(st);
            while (reader.Peek() > -1)
            {
                Automovil a = new Automovil();
                a.Placa = reader.ReadLine();
                a.Marca = reader.ReadLine();
                a.Modelo = reader.ReadLine();
                a.Color = reader.ReadLine();
                a.Preciok = Convert.ToDouble(reader.ReadLine());
                auto.Add(a);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = auto;
                dataGridView1.Refresh();
            }
            reader.Close();
        }

        void repetidos()
        {
            while (h == false && c < auto.Count)
            {
                if (auto[c].Placa.CompareTo(textBox1.Text) == 0)
                {
                    h = true;
                }
                else
                {
                    c++;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrEmpty(textBox5.Text))
            {
                agregar();
                repetidos();
                Automovil f = new Automovil();
                if (h)
                {
                    MessageBox.Show("La placa ya esta en uso");
                    textBox1.Clear();
                }
                else
                {
                    f.Placa = textBox1.Text;
                    f.Marca = textBox2.Text;
                    f.Modelo = textBox3.Text;
                    f.Color = textBox4.Text;
                    f.Preciok = Convert.ToInt32(textBox5.Text);
                    auto.Add(f);
                    MessageBox.Show("Se ha agregado correctamente en la base de datos");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    escribirv();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = auto;
                    dataGridView1.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Debe de llenar todos los campos");
            }
            h = false;
            c = 0;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            leerv();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}
