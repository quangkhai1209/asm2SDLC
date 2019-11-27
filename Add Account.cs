using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsForms_tune_source
{
    public partial class Add_Account : Form
    {
        string sqlconnect = " server=DESKTOP-LEGD62H\\SQLEXPRESS; database=TuneSource;uid=sa;pwd=1234567";
            SqlConnection con;
        public Add_Account()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Add_Account_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlconnect);
            con.Open();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //create command object
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "insert into Account values(@Cus_Name, @Cus_Address, @Cus_Phone,  @Cus_DOB, @Cus_Email, @Cus_UserName, @Cus_Password)";
                //create parameter and assign calue for each parameter
                cmd.Parameters.Add("@Cus_Name", SqlDbType.NChar, 100).Value = txtName.Text;
                cmd.Parameters.Add("@Cus_Address", SqlDbType.NChar, 100).Value = txtAddress.Text;
                cmd.Parameters.Add("@Cus_DOB", SqlDbType.Bit).Value = dtpDOB.Text;
                cmd.Parameters.Add("@Cus_Phone",SqlDbType.Text).Value = txtPhone.Text;
                cmd.Parameters.Add("@Cus_Email", SqlDbType.NChar, 100).Value = txtEmail.Text;
                cmd.Parameters.Add("@Cus_UserName", SqlDbType.NChar, 100).Value = txtUserName.Text;
                cmd.Parameters.Add("@Cus_Password", SqlDbType.NChar, 100).Value = txtPassword.Text;
                cmd.ExecuteNonQuery();


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
