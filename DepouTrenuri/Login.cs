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
using System.Threading;

namespace DepouTrenuri
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Depou.mdf;Integrated Security=True");
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter da;
        Thread th;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from [Utilizator] where Nume=@n and Parola=@p", con);
                cmd.Parameters.AddWithValue("@n", textBox1.Text);
                cmd.Parameters.AddWithValue("@p", textBox6.Text);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count==1)
                {
                    string n = textBox1.Text;
                    MessageBox.Show("Logarea a fost realizata cu succes. Bine ati revenit, " + n + "!");
                    this.Close();
                    th = new Thread(opennewform);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }
                else
                {
                    MessageBox.Show("Datele introduse nu corespund unui cont existent. Va rugam sa incercati din nou sau sa creati un cont.");
                    textBox1.Clear();
                    textBox6.Clear();
                }

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
        private void opennewform(object obj)
        {
            Application.Run(new Form1());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("select * from [Utilizator] where Nume=@n", con);
                cmd.Parameters.AddWithValue("@n", textBox4.Text);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    if (string.Equals(textBox3.Text, textBox5.Text))
                    {
                        con.Open();
                        cmd = new SqlCommand("insert into [Utilizator](Nume,Parola) values(@n, @p)", con);
                        cmd.Parameters.AddWithValue("@n", textBox4.Text);
                        cmd.Parameters.AddWithValue("@p", textBox3.Text);
                        cmd.ExecuteNonQuery();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        MessageBox.Show("Contul a fost creat cu succes!");
                    }
                    else
                    {
                        textBox3.Clear();
                        textBox5.Clear();
                        MessageBox.Show("Parolele nu coincid. Va rugam sa incercati din nou.");
                    }
                }
                else
                {
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    MessageBox.Show("Numele de utilizator introdus apartine unui cont existent. Va rugam sa incercati alt nume.");
                }
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

        private void Login_Load(object sender, EventArgs e)
        {
            textBox1.Text = "admin";
            textBox6.Text = "admin";
        }
    }
}
