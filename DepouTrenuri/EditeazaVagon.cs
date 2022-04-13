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
    public partial class EditeazaVagon : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Depou.mdf;Integrated Security=True");
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter da;
        public EditeazaVagon()
        {
            InitializeComponent();
        }

        private void EditeazaVagon_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select Id from [Vagon_Pasageri]", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                comboBox3.Items.Clear();
                foreach (DataRow r in dt.Rows)
                {
                    comboBox3.Items.Add(r[0]);
                }
                cmd = new SqlCommand("select Id from [Vagon_Marfa]", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                comboBox4.Items.Clear();
                foreach (DataRow r in dt.Rows)
                {
                    comboBox4.Items.Add(r[0]);
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

        private void comboBox3_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select Tip from [Vagon_Pasageri] where Id=@id", con);
                cmd.Parameters.AddWithValue("@id", comboBox3.Text);
                object result = cmd.ExecuteScalar();
                comboBox1.Text = result.ToString();
                cmd = new SqlCommand("select Capacitate from [Vagon_Pasageri] where Id=@id", con);
                cmd.Parameters.AddWithValue("@id", comboBox3.Text);
                object result2 = cmd.ExecuteScalar();
                textBox2.Text = result2.ToString();
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select Tip from [Vagon_Pasageri] where Id=@id", con);
                cmd.Parameters.AddWithValue("@id", comboBox3.Text);
                object result = cmd.ExecuteScalar();
                comboBox1.Text = result.ToString();
                cmd = new SqlCommand("select Capacitate from [Vagon_Pasageri] where Id=@id", con);
                cmd.Parameters.AddWithValue("@id", comboBox3.Text);
                object result2 = cmd.ExecuteScalar();
                textBox2.Text = result2.ToString();
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
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("update [Vagon_Pasageri] set Tip = @tip, Capacitate = @capacitate where Id = @id", con);
                cmd.Parameters.AddWithValue("@id", comboBox3.Text);
                cmd.Parameters.AddWithValue("@tip", comboBox1.Text);
                cmd.Parameters.AddWithValue("@capacitate", textBox2.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Informati actualizate", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox3.Text = "";
                comboBox1.Text = "";
                textBox2.Clear();
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("update [Vagon_Marfa] set Tip_Marfa = @tip_m, Capacitate = @capacitate where Id = @id", con);
                cmd.Parameters.AddWithValue("@id", comboBox4.Text);
                cmd.Parameters.AddWithValue("@tip_m", comboBox2.Text);
                cmd.Parameters.AddWithValue("@capacitate", textBox3.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Informati actualizate", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox4.Text = "";
                comboBox2.Text = "";
                textBox3.Clear();
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

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select Tip_Marfa from [Vagon_Marfa] where Id=@id", con);
                cmd.Parameters.AddWithValue("@id", comboBox4.Text);
                object result = cmd.ExecuteScalar();
                comboBox2.Text = result.ToString();
                cmd = new SqlCommand("select Capacitate from [Vagon_Marfa] where Id=@id", con);
                cmd.Parameters.AddWithValue("@id", comboBox4.Text);
                object result2 = cmd.ExecuteScalar();
                textBox3.Text = result2.ToString();
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
