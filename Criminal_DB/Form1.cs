using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;

namespace Criminal_DB
{
    public partial class Login : Form
    {
        string oradb = "Data Source=TJPD;User Id=TJPD;Password=Criminal2511;";
        OracleConnection conn;
        public Login()
        {
            InitializeComponent();
            conn = new OracleConnection(oradb);
            conn.Open();
            this.FormClosing += CloseApp;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(textBox1.Text +" "+ textBox2.Text);
            List<object> list = Check_Login(textBox1.Text, textBox2.Text);
            if (list.Count > 0)
            {
                MainForm main_form = new MainForm(conn, list);
                main_form.Show();
                this.Hide();
                main_form.FormClosing += OnClose;
            }
            else
            {
                MessageBox.Show("Usuario no encontrado.", "Base de datos criminalistica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private List<object> Check_Login(string username, string password)
        {
            try
            {
                List<object> data = new List<object>();
                OracleCommand cmd1 = conn.CreateCommand();
                cmd1.CommandText = "CHECK_LOGIN";
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.BindByName = true;

                cmd1.Parameters.Add("ONAME", OracleDbType.Varchar2, username, ParameterDirection.Input);
                cmd1.Parameters.Add("OPWD", OracleDbType.Varchar2, password, ParameterDirection.Input);
                cmd1.Parameters.Add("DATAUSER", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd1.ExecuteNonQuery();

                OracleDataReader dr1 = cmd1.ExecuteReader();
                dr1.Read();
                data.Add(dr1.GetDecimal(0));
                data.Add(dr1.GetString(1));
                data.Add(dr1.GetString(2));
                data.Add(dr1.GetDecimal(4));
                data.Add(dr1.GetString(9));
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return new List<object>();
            }
        }

        private void OnClose(object sender, EventArgs e)
        {
            this.Show();
            textBox1.Text = "";
            textBox2.Text = "";
            checkBox1.Checked = true;
        }

        private void CloseApp(object sender, EventArgs e)
        {
            conn.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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
    }
}
