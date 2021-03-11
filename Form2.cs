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
        List<total> tot = new List<total>();
        Boolean h = false;
        Boolean h2 = false;
        int c = 0;
        int c2 = 0;
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
            comboBox1.ValueMember = "NIT";

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
            comboBox2.ValueMember = "Placa";

            comboBox2.DataSource = null;
            comboBox2.DataSource = au;
            comboBox2.Refresh();
        }

        void agregar()
        {
            Alquiler c = new Alquiler();
            Automovil s = new Automovil();

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

       

        void buscarp()
        {
            Automovil t = new Automovil();
            while (h2 == false && c2 < au.Count)
            {
                if (au[c2].Placa.CompareTo(comboBox1.SelectedValue.ToString())==0)
                {
                    h2 = true;
                }
                else
                {
                    c2++;
                }
            }
        }

        void repetidos()
        {
            while (h == false && c < pre.Count)
            {
                if (pre[c].Placa.CompareTo(comboBox1.SelectedValue.ToString())==0)
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

            if (pre.Count > 0)
            {
                ordenar();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                Alquiler f = new Alquiler();
                Automovil s = new Automovil();
                agregar();
                
                    f.Nit = comboBox1.SelectedValue.ToString();
                    f.Placa = comboBox2.SelectedValue.ToString();
                    f.Fecha_al = dateTimePicker1.Value.ToString();
                    f.Fecha_de = dateTimePicker2.Value.ToString();
                    f.Kilrecorridos = Convert.ToDouble(textBox1.Text);
                    
                    pre.Add(f);
                    MessageBox.Show("Se ha agregado a la base de datos");
                    textBox1.Clear();
                    escribira();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = pre;
                dataGridView1.Refresh();
            }
            else
            {
                MessageBox.Show("Debe de llenar todos los campos");
            }

            if (pre.Count > 0)
            {
                ordenar();
            }
        }

        void ordenar()
        {
            label8.Text = " ";
            pre = pre.OrderByDescending(a => a.Kilrecorridos).ToList();
            label8.Text = Convert.ToString(pre[0].Kilrecorridos);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
                Automovil v = new Automovil();
                v.Placa = comboBox1.SelectedValue.ToString();
                buscarp();
                if (h2)
                {
                    repetidos();
                    if (h)
                    {
                        MessageBox.Show("El vehiculo introducido ya esta en renta");
                       h = true;
                        c = 0;
                    }
                    else
                    {
                        h2 = false;
                        c2 = 0;
                        c = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Vehiculo no encontrado");
                    c = 0;
                }
            }
    }
}

