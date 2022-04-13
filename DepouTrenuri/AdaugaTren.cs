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
    public partial class AdaugaTren : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Depou.mdf;Integrated Security=True");
        SqlCommand cmd;
        public AdaugaTren()
        {
            InitializeComponent();
        }

        private void AdaugaTren_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("insert into [Locomotive](Nume,Putere,Stare) values(@Nume, @Putere, @stare)", con);
                cmd.Parameters.AddWithValue("@Nume", textBox1.Text);
                cmd.Parameters.AddWithValue("@Putere", textBox2.Text);
                cmd.Parameters.AddWithValue("@stare", textBox3.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Locomotiva inserata", "Inserat", MessageBoxButtons.OK, MessageBoxIcon.Information);
             
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                this.Close();
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
    }
}
