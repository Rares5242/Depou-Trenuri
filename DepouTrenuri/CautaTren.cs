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
    public partial class CautaTren : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Depou.mdf;Integrated Security=True");
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter da;
        public CautaTren(Form1 parent)
        {
            InitializeComponent();
        }
        
        public CautaTren()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from [Locomotive] where Nume = @nume", con);
                cmd.Parameters.AddWithValue("@nume", textBox1.Text);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                cmd.ExecuteNonQuery();
                ((Form1)Owner).dataGridView1.DataSource = dt;
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
                cmd = new SqlCommand("select * from [Locomotive] where Putere between @p1 and @p2", con);
                cmd.Parameters.AddWithValue("@p1", textBox2.Text);
                cmd.Parameters.AddWithValue("@p2", textBox4.Text);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                cmd.ExecuteNonQuery();
                ((Form1)Owner).dataGridView1.DataSource = dt;
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
                cmd = new SqlCommand("select * from [Locomotive] where Stare = @stare", con);
                cmd.Parameters.AddWithValue("@stare", textBox3.Text);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                cmd.ExecuteNonQuery();
                ((Form1)Owner).dataGridView1.DataSource = dt;
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

        private void CautaTren_Load(object sender, EventArgs e)
        {

        }
    }
}
