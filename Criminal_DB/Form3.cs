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
    public partial class Form3 : Form
    {
        OracleConnection conn;
        public Form3(OracleConnection con)
        {
            InitializeComponent();
            conn = con;
        }

        private void Create_new_user(string name, string rank, string pwd, string station_name)

        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "TJPD.LVL1.ADD_USER";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.BindByName = true;

            cmd.Parameters.Add("ORANK", OracleDbType.Varchar2, rank, ParameterDirection.Input);

            cmd.Parameters.Add("ONAME", OracleDbType.Varchar2, name, ParameterDirection.Input);

            cmd.Parameters.Add("OPWD", OracleDbType.Varchar2, pwd, ParameterDirection.Input);

            cmd.Parameters.Add("SNAME", OracleDbType.Varchar2, station_name, ParameterDirection.Input);

            cmd.ExecuteNonQuery();
        }

        private void Add_button_Click(object sender, EventArgs e)
        {
            Create_new_user(textBox1.Text, comboBox1.SelectedItem.ToString(), "root", textBox2.Text);
            this.Close();
        }
    }
}
