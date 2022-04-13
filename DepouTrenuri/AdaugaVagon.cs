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
    public partial class AdaugaVagon : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Depou.mdf;Integrated Security=True");
        SqlCommand cmd;
        public AdaugaVagon()
        {
            InitializeComponent();
        }

        private void AdaugaVagon_Load(object sender, EventArgs e)
        {

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
                cmd = new SqlCommand("insert into [Vagon_Pasageri](Tip,Capacitate) values(@Tip, @Capacitate)", con);
                cmd.Parameters.AddWithValue("@Tip", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Capacitate", textBox2.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Vagon inserat", "Inserat", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                cmd = new SqlCommand("insert into [Vagon_Marfa](Tip_Marfa,Capacitate) values(@Tip_Marfa, @Capacitate)", con);
                cmd.Parameters.AddWithValue("@Tip_Marfa", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Capacitate", textBox3.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Vagon inserat", "Inserat", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
