﻿using ActividadCuatro.Bss;
using ActividadCuatro.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActividadCuatro.Vistas.ClientesVistas
{
    public partial class ClientesListarVistas : Form
    {
        public ClientesListarVistas()
        {
            InitializeComponent();
        }
        ClienteBss clientebss = new ClienteBss();
        private void ClientesListarVistas_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clientebss.ListarClienteBss();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientesInsertarVistas fr = new ClientesInsertarVistas();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = clientebss.ListarClienteBss();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int IdClienteSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            ClientesEditarVistas fr = new ClientesEditarVistas(IdClienteSeleccionado);
            if (fr.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = clientebss.ListarClienteBss();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int IdClienteSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            DialogResult result = MessageBox.Show("¿Seguro que desea elimiar a este cliente?", "Este cliente sera eliminado......", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                clientebss.EliminarClienteBss(IdClienteSeleccionado);
                dataGridView1.DataSource = clientebss.ListarClienteBss();
            }
        }
    }
}
