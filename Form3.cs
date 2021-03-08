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
    public partial class Form3 : Form
    {
        List<Cliente> persona = new List<Cliente>();
        Boolean h = false;
        int c = 0;

        public Form3()
        {
            InitializeComponent();
        }

        void agregar()
        {
            Cliente a = new Cliente();
            a.Nit = textBox1.Text;
            a.Nombre = textBox2.Text;
            a.Direccion = textBox3.Text;
        }
        
        void escribirc()
        {
            FileStream stream = new FileStream("clientes.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter write = new StreamWriter(stream);
            foreach (var d in persona)
            {
                write.WriteLine(d.Nit);
                write.WriteLine(d.Nombre);
                write.WriteLine(d.Direccion);
            }
            write.Close();
        }

        void leerc()
        {
            OpenFileDialog op = new OpenFileDialog();
            string filename = "clientes.txt";
            FileStream st = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(st);
            while (reader.Peek()>-1)
            {
                Cliente a = new Cliente();
                a.Nit = reader.ReadLine();
                a.Nombre = reader.ReadLine();
                a.Direccion = reader.ReadLine();
                persona.Add(a);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = persona;
                dataGridView1.Refresh();
            }
            reader.Close();
        }

        void repetidos()
        {
            while (h == false && c < persona.Count)
            {
                if (persona[c].Nit.CompareTo(textBox1.Text)==0)
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
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                agregar();
                repetidos();
                Cliente f = new Cliente();
                if(h)
                {
                    MessageBox.Show("El nit ya esta en uso");
                    textBox1.Clear();
                }
                else
                {
                    f.Nit = textBox1.Text;
                    f.Nombre = textBox2.Text;
                    f.Direccion = textBox3.Text;
                    persona.Add(f);
                    MessageBox.Show("Seha agregado correctamente en la base de datos");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    escribirc();
                }
            }
            else
            {
                MessageBox.Show("Debe de llenar todos los campos");
            }
            h = false;
            c = 0;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            leerc();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            Form3 f3 = new Form3();
            f3.Hide();
                f1.Show();
        }
    }
}
