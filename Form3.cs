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

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
