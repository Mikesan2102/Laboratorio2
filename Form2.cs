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

        private void Form2_Load(object sender, EventArgs e)
        {
            leernit();
            leerpla();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
