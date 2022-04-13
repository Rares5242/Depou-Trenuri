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
    public partial class EditeazaTren : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Depou.mdf;Integrated Security=True");
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter da;
        public EditeazaTren()
        {
            InitializeComponent();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("select Nume from [Locomotive] where Id=@id", con);
                    cmd.Parameters.AddWithValue("@id", comboBox1.Text);
                    object result = cmd.ExecuteScalar();
                    textBox1.Text = result.ToString();
                    cmd = new SqlCommand("select Putere from [Locomotive] where Id=@id", con);
                    cmd.Parameters.AddWithValue("@id", comboBox1.Text);
                    object result2 = cmd.ExecuteScalar();
                    textBox2.Text = result2.ToString();
                    cmd = new SqlCommand("select stare from [Locomotive] where Id=@id", con);
                    cmd.Parameters.AddWithValue("@id", comboBox1.Text);
                    object result3 = cmd.ExecuteScalar();
                    textBox3.Text = result3.ToString();
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
        private void EditeazaTren_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select Id from [Locomotive]", con);
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("update [Locomotive] set Nume = @nume, Putere = @putere, Stare = @stare where Id = @id", con);
                cmd.Parameters.AddWithValue("@id",comboBox1.Text);
                cmd.Parameters.AddWithValue("@nume", textBox1.Text);
                cmd.Parameters.AddWithValue("@putere", textBox2.Text);
                cmd.Parameters.AddWithValue("@stare", textBox3.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Informati actualizate", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox1.Text = "";
                textBox1.Clear();
                textBox2.Clear();
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
    }
}
