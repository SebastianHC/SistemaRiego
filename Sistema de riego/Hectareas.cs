﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_riego
{
    public partial class Hectareas : Form
    {
        consultasSql cli = new consultasSql();
        conexion cn = new conexion();

        public Hectareas()
        {
            InitializeComponent();
        }

        private void Hectareas_Load(object sender, EventArgs e)
        {
            dgvHectareas.DataSource = cli.MostrarHectareas();
            dgvHectareas.Columns["Num_Hect"].Visible = false;
            int a = dgvHectareas.Rows.Count;
        }

        private void dgvHectareas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                numhect_txt.Text = dgvHectareas.CurrentRow.Cells[0].Value.ToString();
                tipocult_txt.Text = dgvHectareas.CurrentRow.Cells[1].Value.ToString();
                cantarbo_txt.Text = dgvHectareas.CurrentRow.Cells[2].Value.ToString();
                cantcos_txt.Text = dgvHectareas.CurrentRow.Cells[3].Value.ToString();
                numhect_txt.Enabled = false;
            }
            catch
            {

            }
  

        }

        private void update_btn_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("UPDATE HECTAREAS SET Tipo_Cultivo = @tipocultivo, Cant_Arboles = @cantarboles, cant_Cosecha = @cantcosecha WHERE Num_Hect = @numhect", cn.LeerCadena());
            cmd.Parameters.AddWithValue("@tipocultivo", tipocult_txt.Text);
            cmd.Parameters.AddWithValue("@cantarboles", cantarbo_txt.Text);
            cmd.Parameters.AddWithValue("@cantcosecha", cantcos_txt.Text);
            cmd.Parameters.AddWithValue("@numhect", numhect_txt.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            dgvHectareas.DataSource = cli.MostrarHectareas();
            MessageBox.Show("Registro actualizado");
        }

        //Este metodo no le muevan esta en PROCESO
        private void buscar_txt_KeyUp(object sender, KeyEventArgs e)
        {
            /*
            SqlCommand cmd = cn.LeerCadena().CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Hectareas WHERE Hectareas LIKE ('" + buscar_txt.Text + "%')";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            dgvHectareas.DataSource = dt;
            SqlCommand cmd = new SqlCommand("SELECT * FROM Hectareas WHERE Hectareas LIKE ('" + buscar_txt.Text + "%')", cn.LeerCadena());
            SqlDataReader dr = cmd.ExecuteReader();
            dgvHectareas.DataSource = cli.MostrarHectareas();*/
        }
    }
}