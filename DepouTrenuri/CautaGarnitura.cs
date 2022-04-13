using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DepouTrenuri
{
    public partial class CautaGarnitura : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Depou.mdf;Integrated Security=True");
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter da;
        public CautaGarnitura(Form1 parent)
        {
            InitializeComponent();
        }
        public CautaGarnitura()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from [Garnituri] where Capacitate_totala between @c1 and @c2", con);
                cmd.Parameters.AddWithValue("@c1", textBox2.Text);
                cmd.Parameters.AddWithValue("@c2", textBox1.Text);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                cmd.ExecuteNonQuery();
                ((Form1)Owner).dataGridView4.DataSource = dt;
                MessageBox.Show("Cautare efectuata!", "Cauta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from [Garnituri] where Data_alocare between @d1 and @d2", con);
                cmd.Parameters.AddWithValue("@d1", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@d2", dateTimePicker2.Value);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                cmd.ExecuteNonQuery();
                ((Form1)Owner).dataGridView4.DataSource = dt;
                MessageBox.Show("Cautare efectuata!", "Cauta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from [Garnituri] where Tip_Garnitura=@t", con);
                cmd.Parameters.AddWithValue("@t", radioButton1.Text);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                cmd.ExecuteNonQuery();
                ((Form1)Owner).dataGridView4.DataSource = dt;
                MessageBox.Show("Cautare efectuata!", "Cauta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from [Garnituri] where Tip_Garnitura=@t", con);
                cmd.Parameters.AddWithValue("@t", radioButton2.Text);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                cmd.ExecuteNonQuery();
                ((Form1)Owner).dataGridView4.DataSource = dt;
                MessageBox.Show("Cautare efectuata!", "Cauta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
