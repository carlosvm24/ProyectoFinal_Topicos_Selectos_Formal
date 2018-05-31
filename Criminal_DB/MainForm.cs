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
    public partial class MainForm : Form
    {
        OracleConnection conn;
        List<object> list;
        int level = 0;
        int id = 0;
        string uname = "";
        string rank = "";
        string station = "";
        Form7 newpwd;
        public MainForm(OracleConnection connect, List<object> l)
        //public MainForm()
        {
            InitializeComponent();
            conn = connect;
            list = l;
            id = Convert.ToInt32(list[0]);
            uname = Convert.ToString(list[1]);
            rank = Convert.ToString(list[2]);
            level = Convert.ToInt32(list[3]);
            station = Convert.ToString(list[4]);
            label1.Text = uname;
            label2.Text = rank;
            label3.Text = station;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            UserControl1 init = new UserControl1(conn, level, id, station);
            //UserControl1 init = new UserControl1();
            splitContainer1.Panel2.Controls.Add(init);
            init.Visible = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            newpwd = new Form7(conn, uname);
            newpwd.MdiParent = this.MdiParent;
            newpwd.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
