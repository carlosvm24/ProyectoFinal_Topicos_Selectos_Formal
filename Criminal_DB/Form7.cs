using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace Criminal_DB
{
    public partial class Form7 : Form
    {
        OracleConnection conn;
        string name = "";
        public Form7(OracleConnection Conn, string uname)
        {
            InitializeComponent();
            conn = Conn;
            name = uname;
            label4.Text = name;
            //Edit_pwd("root", "root1", "David");
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '*';
                Console.Write("Entra");
            }
            else
            {
                textBox2.PasswordChar = '\0';
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox3.PasswordChar = '*';
                Console.Write("Entra");
            }
            else
            {
                textBox3.PasswordChar = '\0';
            }
        }

        private void Add_button_Click(object sender, EventArgs e)
        {
            Console.Write(textBox2.Text+" "+textBox3.Text);
            Edit_pwd(textBox2.Text,textBox3.Text, label4.Text);
            this.Close();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
        private void Edit_pwd(string officer_pwd, string new_officer_pwd, string officer_name)
        {
            string oradb = "Data Source=TJPD;User Id=TJPD;Password=Criminal2511;";
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "EDIT_PWD";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.BindByName = true;


            cmd.Parameters.Add("OFFICER_NAME", OracleDbType.Varchar2, officer_name, ParameterDirection.Input);
            cmd.Parameters.Add("OFFICER_PWD", OracleDbType.Varchar2, officer_pwd, ParameterDirection.Input);
            cmd.Parameters.Add("OFFICER_NEWPWD", OracleDbType.Varchar2, new_officer_pwd, ParameterDirection.Input);
            cmd.ExecuteNonQuery();

            conn.Close();

        }
    }
}
