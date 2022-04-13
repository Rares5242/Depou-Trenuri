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
    public partial class DesfiinteazaGarnitura : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Depou.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlCommand cmd2;
        DataTable dt;
        SqlDataAdapter da;
        public DesfiinteazaGarnitura()
        {
            InitializeComponent();
        }

        private void DesfiinteazaGarnitura_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select Id from [Garnituri]", con);
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("update [Locomotive] set Garnitura=null where Garnitura=@id", con);
                cmd.Parameters.AddWithValue("@id", comboBox1.Text);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("update [Vagon_Marfa] set Garnitura=null where Garnitura=@id", con);
                cmd.Parameters.AddWithValue("@id", comboBox1.Text);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("update [Vagon_Pasageri] set Garnitura=null where Garnitura=@id", con);
                cmd.Parameters.AddWithValue("@id", comboBox1.Text);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("delete from [Garnituri] where Id=@id", con);
                cmd.Parameters.AddWithValue("@id", comboBox1.Text);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("select Id from [Garnituri]", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                comboBox1.Items.Clear();
                foreach (DataRow r in dt.Rows)
                {
                    comboBox1.Items.Add(r[0]);
                }
                comboBox1.Text = "";
                MessageBox.Show("Garnitura desfiintata!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
