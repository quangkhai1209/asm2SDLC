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

namespace WindowsForms_tune_source
{
    public partial class Form2 : Form
    {
        string sqlconnect = " server=DESKTOP-LEGD62H\\SQLEXPRESS; database=TuneSource;uid=sa;pwd=1234567";
        SqlConnection con;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select song in list", sqlconnect);
                DataSet ds = new DataSet();
                da.Fill(ds, "Song");
                dataGridView1.DataSource = ds.Tables["Song"];
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Display Song",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //create command object
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "insert into Account values(@Song_Name, @Song_Category, @Song_Singr,  @Song_Cót, @Song_Linkdowload)";
                MessageBox.Show("Insert success!", "Insert");

                Login login = new Login();


                login.Show();


                this.Hide();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
