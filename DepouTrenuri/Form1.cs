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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Depou.mdf;Integrated Security=True");
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter da;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            update_grid();
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(button9, "In curand!");
            toolTip1.SetToolTip(button10, "In curand!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            new AdaugaTren().ShowDialog();
            this.Show();
        }
        void update_grid()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from [Locomotive]", con);
                da = new SqlDataAdapter(cmd);     
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                cmd = new SqlCommand("select * from [Vagon_Pasageri]", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                cmd = new SqlCommand("select * from [Vagon_Marfa]", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView3.DataSource = dt;
                cmd = new SqlCommand("select * from [Garnituri]", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView4.DataSource = dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Sigur doriti sa inchideti?", "Sigur sigur", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            new EditeazaTren().ShowDialog();
            this.Show();
        }

        private void tabControl1_Enter(object sender, EventArgs e)
        {
            update_grid();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            update_grid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            new StergereTren().ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Hide();
            //new CautaTren().ShowDialog();
            //this.Show();
            //Form2 form = new Form2();
            //new CautaTren().ShowDialog();
            //this.Show();
            CautaTren form = new CautaTren();
            form.Show(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            new AdaugaVagon().ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Hide();
            new EditeazaVagon().ShowDialog();
            this.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Hide();
            new StergereVagon().ShowDialog();
            this.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CautaVagon form = new CautaVagon();
            form.Show(this);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Hide();
            new ConstruiesteGarnitura().ShowDialog();
            this.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Hide();
            new ModificaGarnitura().ShowDialog();
            this.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Hide();
            new DesfiinteazaGarnitura().ShowDialog();
            this.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            CautaGarnitura form = new CautaGarnitura();
            form.Show(this);
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                //This line of code will help you to change the apperance like size,name,style.
                Font f;
                //For background color
                Brush backBrush;
                //For forground color
                Brush foreBrush;

                //This construct will hell you to deside which tab page have current focus
                //to change the style.
                if (e.Index == this.tabControl1.SelectedIndex)
                {
                    //This line of code will help you to change the apperance like size,name,style.
                    f = new Font(e.Font, FontStyle.Bold | FontStyle.Bold);
                    f = new Font(e.Font, FontStyle.Bold);

                    backBrush = new System.Drawing.SolidBrush(Color.DimGray);
                    foreBrush = Brushes.White;
                    Graphics g = e.Graphics;
                    Pen p = new Pen(Color.DimGray, 7);
                    g.DrawRectangle(p, this.tabPage1.Bounds);
                }
                else
                {
                    f = e.Font;
                    backBrush = new SolidBrush(e.BackColor);
                    foreBrush = new SolidBrush(e.ForeColor);
                }

                //To set the alignment of the caption.
                string tabName = this.tabControl1.TabPages[e.Index].Text;
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;

                //Thsi will help you to fill the interior portion of
                //selected tabpage.
                e.Graphics.FillRectangle(backBrush, e.Bounds);
                Rectangle r = e.Bounds;
                r = new Rectangle(r.X, r.Y + 3, r.Width, r.Height - 3);
                e.Graphics.DrawString(tabName, f, foreBrush, r, sf);

                sf.Dispose();
                if (e.Index == this.tabControl1.SelectedIndex)
                {
                    f.Dispose();
                    backBrush.Dispose();
                }
                else
                {
                    backBrush.Dispose();
                    foreBrush.Dispose();
                }
                //set color for Background
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
