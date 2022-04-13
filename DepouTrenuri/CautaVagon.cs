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
    public partial class CautaVagon : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Depou.mdf;Integrated Security=True");
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter da;
        public CautaVagon(Form1 parent)
        {
            InitializeComponent();
        }
        public CautaVagon()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from [Vagon_Pasageri] where Tip = @tip", con);
                cmd.Parameters.AddWithValue("@tip", comboBox1.Text);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                cmd.ExecuteNonQuery();
                ((Form1)Owner).dataGridView2.DataSource = dt;
                MessageBox.Show("Cautare efectuata!", "Cauta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                cmd = new SqlCommand("select * from [Vagon_Pasageri] where Capacitate between @c1 and @c2", con);
                cmd.Parameters.AddWithValue("@c1", textBox3.Text);
                cmd.Parameters.AddWithValue("@c2", textBox4.Text);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                cmd.ExecuteNonQuery();
                ((Form1)Owner).dataGridView2.DataSource = dt;
                MessageBox.Show("Cautare efectuata!", "Cauta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from [Vagon_Marfa] where Tip_Marfa = @tip_m", con);
                cmd.Parameters.AddWithValue("@tip_m", comboBox2.Text);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                cmd.ExecuteNonQuery();
                ((Form1)Owner).dataGridView3.DataSource = dt;
                MessageBox.Show("Cautare efectuata!", "Cauta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from [Vagon_Marfa] where Capacitate between @c1 and @c2", con);
                cmd.Parameters.AddWithValue("@c1", textBox6.Text);
                cmd.Parameters.AddWithValue("@c2", textBox5.Text);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                cmd.ExecuteNonQuery();
                ((Form1)Owner).dataGridView3.DataSource = dt;
                MessageBox.Show("Cautare efectuata!", "Cauta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
