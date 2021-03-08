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
    public partial class Form2 : Form
    {
        List<Alquiler> pre = new List<Alquiler>();
        List<Cliente> per = new List<Cliente>();
        List<Automovil> au = new List<Automovil>();
        Boolean h = false;
        int c = 0;
        public Form2()
        {
            InitializeComponent();
        }

        void leernit()
        {
            OpenFileDialog op = new OpenFileDialog();
            string filename = "clientes.txt";
            FileStream st = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(st);
            while (reader.Peek() > -1)
            {
                Cliente a = new Cliente();
                a.Nit = reader.ReadLine();
                a.Nombre = reader.ReadLine();
                a.Direccion = reader.ReadLine();
                per.Add(a);


            }
            reader.Close();

            comboBox1.DisplayMember = "NIT";
            comboBox1.ValueMember = "Nombre";

            comboBox1.DataSource = null;
            comboBox1.DataSource = per;
            comboBox1.Refresh();
        }

        void leerpla()
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
                au.Add(a);

            }
            reader.Close();

            comboBox2.DisplayMember = "Placa";
            comboBox2.ValueMember = "Modelo";

            comboBox2.DataSource = null;
            comboBox2.DataSource = au;
            comboBox2.Refresh();
        }

        void agregar()
        {
            Alquiler c = new Alquiler();
            c.Nit = comboBox1.SelectedValue.ToString();
            c.Placa = comboBox2.SelectedValue.ToString();
            c.Fecha_al = dateTimePicker1.Value.ToString();
            c.Fecha_de = dateTimePicker2.Value.ToString();
            c.Kilrecorridos = Convert.ToDouble(textBox1.Text);
        }

        void escribira()
        {
            FileStream stream = new FileStream("alquiler.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter write = new StreamWriter(stream);
            foreach (var d in pre)
            {
                write.WriteLine(d.Nit);
                write.WriteLine(d.Placa);
                write.WriteLine(d.Fecha_al);
                write.WriteLine(d.Fecha_de);
                write.WriteLine(d.Kilrecorridos);
            }
            write.Close();
        }

        void leera()
        {
            OpenFileDialog op = new OpenFileDialog();
            string filename = "alquiler.txt";
            FileStream st = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(st);
            while (reader.Peek() > -1)
            {
                Alquiler a = new Alquiler();
                a.Nit = reader.ReadLine();
                a.Placa = reader.ReadLine();
                a.Fecha_al = reader.ReadLine();
                a.Fecha_de = reader.ReadLine();
                a.Kilrecorridos = Convert.ToDouble(reader.ReadLine());
                pre.Add(a);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = pre;
                dataGridView1.Refresh();
            }
            reader.Close();
        }

        void repetidos()
        {
            while (h == false && c < pre.Count)
            {
                if (pre[c].Placa.CompareTo(comboBox1.SelectedValue.ToString()) == 0)
                {
                    h = true;
                }
                else
                {
                    c++;
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            leernit();
            leerpla();
            leera();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                agregar();
                repetidos();
                Alquiler f = new Alquiler();

                f.Nit = comboBox1.SelectedValue.ToString();
                f.Placa = comboBox2.SelectedValue.ToString();
                f.Fecha_al = dateTimePicker1.Value.ToString();
                f.Fecha_de = dateTimePicker2.Value.ToString();
                f.Kilrecorridos = Convert.ToDouble(textBox1.Text);
                pre.Add(f);
                MessageBox.Show("Se ha agregado a la base de datos");
                textBox1.Clear();
                escribira();
            }
            else
            {
                MessageBox.Show("Debe de llenar todos los campos");
            }
        }
    }
}

