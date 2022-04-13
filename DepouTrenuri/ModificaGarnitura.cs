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
    public partial class ModificaGarnitura : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Depou.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlCommand cmd2;
        DataTable dt;
        SqlDataAdapter da;
        public ModificaGarnitura()
        {
            InitializeComponent();
        }
        private void ModificaGarnitura_Load(object sender, EventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select Locomotiva from [Garnituri] where Id=@id", con);
                cmd.Parameters.AddWithValue("@id", comboBox1.Text);
                object result2 = cmd.ExecuteScalar();
                comboBox2.Text = result2.ToString();
                cmd = new SqlCommand("select Id from [Locomotive] where Garnitura is null", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                comboBox2.Items.Clear();
                foreach (DataRow r in dt.Rows)
                {
                    comboBox2.Items.Add(r[0]);
                }
                cmd = new SqlCommand("select Tip_Garnitura from [Garnituri] where Id=@id", con);
                cmd.Parameters.AddWithValue("@id", comboBox1.Text);
                object result = cmd.ExecuteScalar().ToString();
                if(string.Equals(result,"Marfa"))
                {
                    con.Close();
                    radioButton1.Checked = true;   
                }
                if (string.Equals(result, "Pasageri"))
                {
                    con.Close();
                    radioButton2.Checked = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if(con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select Id from [Vagon_Marfa]", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                checkedListBox1.Items.Clear();
                foreach (DataRow r in dt.Rows)
                {
                    checkedListBox1.Items.Add(r[0]);
                }
                cmd.ExecuteNonQuery();
                for (int i = 0; i < checkedListBox1.Items.Count; ++i)
                {
                    checkedListBox1.SetSelected(i, true);
                    cmd2 = new SqlCommand("select Garnitura from Vagon_Marfa where Id=@id", con);
                    cmd2.Parameters.AddWithValue("@id", checkedListBox1.SelectedItem.ToString());
                    object result = cmd2.ExecuteScalar().ToString();
                    if (string.Equals(result, comboBox1.Text))
                    {
                        checkedListBox1.SetItemChecked(i, true);
                    }
                    cmd2.ExecuteNonQuery();
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
                cmd = new SqlCommand("select Id from [Vagon_Pasageri]", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                checkedListBox1.Items.Clear();
                foreach (DataRow r in dt.Rows)
                {
                    checkedListBox1.Items.Add(r[0]);
                }
                cmd.ExecuteNonQuery();
                /*foreach (var item in checkedListBox1.Items)
                {
                    //item.ToString;
                    cmd2 = new SqlCommand("select Garnitura from Vagon_Pasageri where Id=@id", con);
                    cmd2.Parameters.AddWithValue("@id", item.ToString());
                    object result = cmd2.ExecuteScalar().ToString();
                    if (string.Equals(result, comboBox1.Text))
                    {
                        checkedListBox1.SetItemChecked(,true);
                    }
                    cmd2.ExecuteNonQuery();
                }*/
                for(int i=0;i<checkedListBox1.Items.Count;++i)
                {
                    checkedListBox1.SetSelected(i, true);
                    cmd2 = new SqlCommand("select Garnitura from Vagon_Pasageri where Id=@id", con);
                    cmd2.Parameters.AddWithValue("@id", checkedListBox1.SelectedItem.ToString());
                    object result = cmd2.ExecuteScalar().ToString();
                    if (string.Equals(result, comboBox1.Text))
                    {
                        checkedListBox1.SetItemChecked(i, true);
                    }
                    cmd2.ExecuteNonQuery();
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
                cmd = new SqlCommand("update [Locomotive] set Garnitura=null where Garnitura=@id", con);
                cmd.Parameters.AddWithValue("@id", comboBox1.Text);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("update [Vagon_Marfa] set Garnitura=null where Garnitura=@id", con);
                cmd.Parameters.AddWithValue("@id", comboBox1.Text);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("update [Vagon_Pasageri] set Garnitura=null where Garnitura=@id", con);
                cmd.Parameters.AddWithValue("@id", comboBox1.Text);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("update [Garnituri] set Locomotiva=@n where Id=@id", con);
                cmd.Parameters.AddWithValue("@n", -1);
                cmd.Parameters.AddWithValue("@id", comboBox1.Text);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("update [Locomotive] set Garnitura=@n where Id=@id", con);
                cmd.Parameters.AddWithValue("@n", comboBox1.Text);
                cmd.Parameters.AddWithValue("@id", comboBox2.Text);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("update [Garnituri] set Locomotiva=@n where Id=@id", con);
                cmd.Parameters.AddWithValue("@n", comboBox2.Text);
                cmd.Parameters.AddWithValue("@id", comboBox1.Text);
                cmd.ExecuteNonQuery();
                if (radioButton1.Checked)
                {
                    /*foreach (var item in checkedListBox1.Items)
                    {
                        //item.ToString;
                        cmd = new SqlCommand("update [Vagon_Marfa] set Garnitura=@id", con);
                        cmd.Parameters.AddWithValue("@id", comboBox1.Text);
                        cmd.ExecuteNonQuery();
                    }*/
                    for (int i = 0; i < checkedListBox1.Items.Count; ++i)
                    {
                        if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                        {
                            checkedListBox1.SetSelected(i, true);
                            cmd2 = new SqlCommand("update [Vagon_Marfa] set Garnitura=@n where Id=@id", con);
                            cmd2.Parameters.AddWithValue("@n", comboBox1.Text);
                            cmd2.Parameters.AddWithValue("@id", checkedListBox1.SelectedItem.ToString());
                            cmd2.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    /*foreach (var item in checkedListBox1.Items)
                    {
                        //item.ToString;
                        cmd = new SqlCommand("update [Vagon_Pasageri] set Garnitura=@id", con);
                        cmd.Parameters.AddWithValue("@id", comboBox1.Text);
                        cmd.ExecuteNonQuery();
                    }*/
                    for (int i = 0; i < checkedListBox1.Items.Count; ++i)
                    {
                        if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                        {
                            checkedListBox1.SetSelected(i, true);
                            cmd2 = new SqlCommand("update [Vagon_Pasageri] set Garnitura=@n where Id=@id", con);
                            cmd2.Parameters.AddWithValue("@n", comboBox1.Text);
                            cmd2.Parameters.AddWithValue("@id", checkedListBox1.SelectedItem.ToString());
                            cmd2.ExecuteNonQuery();
                        }
                    }
                }
                MessageBox.Show("Garnitura modificata!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
