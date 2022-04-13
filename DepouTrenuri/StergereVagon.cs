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
    public partial class StergereVagon : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Depou.mdf;Integrated Security=True");
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter da;
        public StergereVagon()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("delete from [Vagon_Marfa] where Id = @id", con);
                cmd.Parameters.AddWithValue("@id", comboBox2.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Vagon sters", "Sters", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox2.Text = "";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
            try
            {
                con.Open();
                cmd = new SqlCommand("select Id from [Vagon_Marfa]", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                comboBox2.Items.Clear();
                foreach (DataRow r in dt.Rows)
                {
                    comboBox2.Items.Add(r[0]);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
            comboBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("delete from [Vagon_Pasageri] where Id = @id", con);
                cmd.Parameters.AddWithValue("@id", comboBox1.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Vagon sters", "Sters", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox1.Text = "";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
            try
            {
                con.Open();
                cmd = new SqlCommand("select Id from [Vagon_Pasageri]", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                comboBox1.Items.Clear();
                foreach (DataRow r in dt.Rows)
                {
                    comboBox1.Items.Add(r[0]);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
            comboBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StergereVagon_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select Id from [Vagon_Pasageri] where Garnitura is null", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                comboBox1.Items.Clear();
                foreach (DataRow r in dt.Rows)
                {
                    comboBox1.Items.Add(r[0]);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
            try
            {
                con.Open();
                cmd = new SqlCommand("select Id from [Vagon_Marfa] where Garnitura is null", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                comboBox2.Items.Clear();
                foreach (DataRow r in dt.Rows)
                {
                    comboBox2.Items.Add(r[0]);
                }
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
