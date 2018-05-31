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
    public partial class Form4 : Form
    {
        OracleConnection conn;
        public Form4(OracleConnection con)
        {
            InitializeComponent();
            conn = con;
        }

        private void Create_new_station(string name, string adr, string zone)

        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "TJPD.LVL1.ADD_STATION";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.BindByName = true;

            cmd.Parameters.Add("STNAME", OracleDbType.Varchar2, name, ParameterDirection.Input);

            cmd.Parameters.Add("STADDR", OracleDbType.Varchar2, adr, ParameterDirection.Input);

            cmd.Parameters.Add("STZONE", OracleDbType.Varchar2, zone, ParameterDirection.Input);

            cmd.ExecuteNonQuery();
        }

        private void Add_button_Click(object sender, EventArgs e)
        {
            Create_new_station(textBox1.Text, textBox2.Text, comboBox5.SelectedItem.ToString());
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
