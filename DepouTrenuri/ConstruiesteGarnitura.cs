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
    public partial class ConstruiesteGarnitura : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Depou.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlCommand cmd2;
        DataTable dt;
        SqlDataAdapter da;
        public ConstruiesteGarnitura()
        {
            InitializeComponent();
        }

        private void ConstruiesteGarnitura_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select Id from [Locomotive] where Garnitura is null", con);
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select Id from [Vagon_Marfa] where Garnitura is null", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                checkedListBox1.Items.Clear();
                foreach (DataRow r in dt.Rows)
                {
                    checkedListBox1.Items.Add(r[0]);
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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select Id from [Vagon_Pasageri] where Garnitura is null", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                checkedListBox1.Items.Clear();
                foreach (DataRow r in dt.Rows)
                {
                    checkedListBox1.Items.Add(r[0]);
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
            if (radioButton1.Checked)
            {
                try
                {
                    int sum = 0;
                    int s1 = 0;
                    con.Open();
                    foreach (var item in checkedListBox1.CheckedItems)
                    {
                        //item.ToString;
                       
                        cmd2 = new SqlCommand("select (Capacitate) from [Vagon_Marfa] where Id=@id", con);
                        cmd2.Parameters.AddWithValue("@id", item.ToString());
                        cmd2.Parameters.AddWithValue("@s", s1);
                        sum += (Int32)cmd2.ExecuteScalar();
                    }
                    //MessageBox.Show(sum.ToString());
                    cmd = new SqlCommand("insert into [Garnituri](Tip_Garnitura,Data_Alocare,Capacitate_totala,Locomotiva) values(@Tip, @Data, @Cap, @Loc)", con);
                    cmd.Parameters.AddWithValue("@Tip", "Marfa");
                    cmd.Parameters.AddWithValue("@Data", DateTime.Today);
                    cmd.Parameters.AddWithValue("@Cap", sum);
                    cmd.Parameters.AddWithValue("@Loc", comboBox1.Text);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("update [Locomotive] set Garnitura = (select max(Id) from [Garnituri]) where Id = @id", con);
                    cmd.Parameters.AddWithValue("@id", comboBox1.Text);
                    cmd.ExecuteNonQuery();
                    foreach (var item in checkedListBox1.CheckedItems)
                    {
                        //item.ToString;
                        cmd2 = new SqlCommand("update [Vagon_Marfa] set Garnitura = (select max(Id) from [Garnituri]) where Id=@id", con);
                        cmd2.Parameters.AddWithValue("@id", item.ToString());
                        cmd2.ExecuteNonQuery();
                    }
                    MessageBox.Show("Garnitura construita", "Inserat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBox1.Text = "";
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
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
            if (radioButton2.Checked)
            {
                try
                {
                    int sum = 0;
                    int s1 = 0;
                    con.Open();
                    foreach (var item in checkedListBox1.CheckedItems)
                    {
                        //item.ToString;
                        cmd2 = new SqlCommand("select (Capacitate) from [Vagon_Pasageri] where Id=@id", con);
                        cmd2.Parameters.AddWithValue("@id", item.ToString());
                        cmd2.Parameters.AddWithValue("@s", s1);
                        sum += (Int32)cmd2.ExecuteScalar();
                    }
                    cmd = new SqlCommand("insert into [Garnituri](Tip_Garnitura,Data_Alocare,Capacitate_totala,Locomotiva) values(@Tip, @Data, @Cap, @Loc)", con);
                    cmd.Parameters.AddWithValue("@Tip", "Pasageri");
                    cmd.Parameters.AddWithValue("@Data", DateTime.Today);
                    cmd.Parameters.AddWithValue("@Cap", sum);
                    cmd.Parameters.AddWithValue("@Loc", comboBox1.Text);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("update [Locomotive] set Garnitura = (select max(Id) from [Garnituri]) where Id = @id",con);
                    cmd.Parameters.AddWithValue("@id", comboBox1.Text);
                    cmd.ExecuteNonQuery();
                    foreach (var item in checkedListBox1.CheckedItems)
                    {
                        //item.ToString;
                        cmd2 = new SqlCommand("update [Vagon_Pasageri] set Garnitura = (select max(Id) from [Garnituri]) where Id=@id", con);
                        cmd2.Parameters.AddWithValue("@id", item.ToString());
                        cmd2.ExecuteNonQuery();
                    }
                    MessageBox.Show("Garnitura construita.", "Inserat", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            }
        }
    }
}
