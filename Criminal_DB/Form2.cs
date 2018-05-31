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
    public partial class Form2 : Form
    {
        OracleConnection conn;
        string mode;
        int fid = 0;
        int uid = 0;
        int sid = 0;
        public Form2(OracleConnection con, string action, int user_id, int station_id)
        {
            InitializeComponent();
            conn = con;
            mode = action;
            uid = user_id;
            sid = station_id;
        }

        public Form2(OracleConnection con, string action, int fir_id, int user_id, int station_id)
        {
            InitializeComponent();
            conn = con;
            mode = action;
            fid = fir_id;
            uid = user_id;
            sid = station_id;
            button2.Text = action;
            Search_Fir(fir_id,"","","","", "01 - JAN - 0001", "","");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (e.Start.ToShortDateString().Equals(e.End.ToShortDateString()))
            {
                this.textBox14.Text = e.Start.ToShortDateString();
                monthCalendar1.Visible = false;
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (e.Start.ToShortDateString().Equals(e.End.ToShortDateString()))
            {
                this.textBox14.Text = e.Start.ToShortDateString();
                monthCalendar1.Visible = false;
            }
        }
        private void Add_Fir(int of_id, int st_id, string i_date, string i_time, string i_place, string v_name, string v_addr, string v_gender, int v_age, string a_name, string a_addr, string a_gender, int a_age, string p_name, string p_addr)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "TJPD.LVL2.ADD_FIR";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.BindByName = true;

            var dates = i_date.Split('/');
            switch (Convert.ToInt32(dates[0]))
            {
                case 1:
                    dates[0] = "JAN";
                    break;
                case 2:
                    dates[0] = "FEB";
                    break;
                case 3:
                    dates[0] = "MAR";
                    break;
                case 4:
                    dates[0] = "APR";
                    break;
                case 5:
                    dates[0] = "MAY";
                    break;
                case 6:
                    dates[0] = "JUN";
                    break;
                case 7:
                    dates[0] = "JUL";
                    break;
                case 8:
                    dates[0] = "AUG";
                    break;
                case 9:
                    dates[0] = "SEP";
                    break;
                case 10:
                    dates[0] = "OCT";
                    break;
                case 11:
                    dates[0] = "NOV";
                    break;
                case 12:
                    dates[0] = "DEC";
                    break;
            }
            i_date = dates[1] + "-" + dates[0] + "-" + dates[2];
            //OracleDataReader dr = cmd.ExecuteReader();
            //dr.GetDataTypeName(2);
            cmd.Parameters.Add("OFID", OracleDbType.Decimal, of_id, ParameterDirection.Input);
            cmd.Parameters.Add("STID", OracleDbType.Decimal, st_id, ParameterDirection.Input);
            cmd.Parameters.Add("IDATE", OracleDbType.Date, i_date, ParameterDirection.Input);
            cmd.Parameters.Add("ITIME", OracleDbType.Varchar2, i_time, ParameterDirection.Input);
            cmd.Parameters.Add("IPLACE", OracleDbType.Varchar2, i_place, ParameterDirection.Input);
            cmd.Parameters.Add("VNAME", OracleDbType.Varchar2, v_name, ParameterDirection.Input);
            cmd.Parameters.Add("VADR", OracleDbType.Varchar2, v_addr, ParameterDirection.Input);
            cmd.Parameters.Add("VGENDER", OracleDbType.Varchar2, v_gender, ParameterDirection.Input);
            cmd.Parameters.Add("VAGE", OracleDbType.Int32, v_age, ParameterDirection.Input);
            cmd.Parameters.Add("ANAME", OracleDbType.Varchar2, a_name, ParameterDirection.Input);
            cmd.Parameters.Add("AADR", OracleDbType.Varchar2, a_addr, ParameterDirection.Input);
            cmd.Parameters.Add("AGENDER", OracleDbType.Varchar2, a_gender, ParameterDirection.Input);
            cmd.Parameters.Add("AAGE", OracleDbType.Int32, a_age, ParameterDirection.Input);
            cmd.Parameters.Add("PNAME", OracleDbType.Varchar2, p_name, ParameterDirection.Input);
            cmd.Parameters.Add("PADR", OracleDbType.Varchar2, p_addr, ParameterDirection.Input);

            cmd.ExecuteNonQuery();
        }

        private void Update_Fir(int fir_id, int of_id, int st_id, string i_date, string i_time, string i_place, string v_name, string v_addr, string v_gender, int v_age, string a_name, string a_addr, string a_gender, int a_age, string p_name, string p_addr)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "TJPD.LVL2.UPDATE_FIR";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.BindByName = true;

            var dates = i_date.Split('/');
            switch(Convert.ToInt32(dates[0]))
            {
                case 1:
                    dates[0] = "JAN";
                    break;
                case 2:
                    dates[0] = "FEB";
                    break;
                case 3:
                    dates[0] = "MAR";
                    break;
                case 4:
                    dates[0] = "APR";
                    break;
                case 5:
                    dates[0] = "MAY";
                    break;
                case 6:
                    dates[0] = "JUN";
                    break;
                case 7:
                    dates[0] = "JUL";
                    break;
                case 8:
                    dates[0] = "AUG";
                    break;
                case 9:
                    dates[0] = "SEP";
                    break;
                case 10:
                    dates[0] = "OCT";
                    break;
                case 11:
                    dates[0] = "NOV";
                    break;
                case 12:
                    dates[0] = "DEC";
                    break;
            }
            i_date = dates[1] + "-" + dates[0] + "-" + dates[2];
            //OracleDataReader dr = cmd.ExecuteReader();
            //dr.GetDataTypeName(2);
            cmd.Parameters.Add("FIRID", OracleDbType.Decimal, fir_id, ParameterDirection.Input);
            cmd.Parameters.Add("OFID", OracleDbType.Decimal, of_id, ParameterDirection.Input);
            cmd.Parameters.Add("STID", OracleDbType.Decimal, st_id, ParameterDirection.Input);
            cmd.Parameters.Add("IDATE", OracleDbType.Date, i_date, ParameterDirection.Input);
            cmd.Parameters.Add("ITIME", OracleDbType.Varchar2, i_time, ParameterDirection.Input);
            cmd.Parameters.Add("IPLACE", OracleDbType.Varchar2, i_place, ParameterDirection.Input);
            cmd.Parameters.Add("VNAME", OracleDbType.Varchar2, v_name, ParameterDirection.Input);
            cmd.Parameters.Add("VADR", OracleDbType.Varchar2, v_addr, ParameterDirection.Input);
            cmd.Parameters.Add("VGENDER", OracleDbType.Varchar2, v_gender, ParameterDirection.Input);
            cmd.Parameters.Add("VAGE", OracleDbType.Int32, v_age, ParameterDirection.Input);
            cmd.Parameters.Add("ANAME", OracleDbType.Varchar2, a_name, ParameterDirection.Input);
            cmd.Parameters.Add("AADR", OracleDbType.Varchar2, a_addr, ParameterDirection.Input);
            cmd.Parameters.Add("AGENDER", OracleDbType.Varchar2, a_gender, ParameterDirection.Input);
            cmd.Parameters.Add("AAGE", OracleDbType.Int32, a_age, ParameterDirection.Input);
            cmd.Parameters.Add("PNAME", OracleDbType.Varchar2, p_name, ParameterDirection.Input);
            cmd.Parameters.Add("PADR", OracleDbType.Varchar2, p_addr, ParameterDirection.Input);

            cmd.ExecuteNonQuery();
        }

        private void Search_Fir(int fir_id, string off_name, string off_rank, string sta_name, string sta_zone, string fir_date, string fir_time, string fir_place)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "TJPD.SEARCH_FIR";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter id = new OracleParameter();
            id.OracleDbType = OracleDbType.Decimal;
            id.Direction = ParameterDirection.Input;
            id.Value = fir_id;
            cmd.Parameters.Add(id);

            OracleParameter name = new OracleParameter();
            name.OracleDbType = OracleDbType.Varchar2;
            name.Direction = ParameterDirection.Input;
            name.Value = off_name + "%";
            cmd.Parameters.Add(name);

            OracleParameter rank = new OracleParameter();
            rank.OracleDbType = OracleDbType.Varchar2;
            rank.Direction = ParameterDirection.Input;
            rank.Value = off_rank + "%";
            cmd.Parameters.Add(rank);

            OracleParameter station = new OracleParameter();
            station.OracleDbType = OracleDbType.Varchar2;
            station.Direction = ParameterDirection.Input;
            station.Value = sta_name + "%";
            cmd.Parameters.Add(station);

            OracleParameter zone = new OracleParameter();
            zone.OracleDbType = OracleDbType.Varchar2;
            zone.Direction = ParameterDirection.Input;
            zone.Value = sta_zone + "%";
            cmd.Parameters.Add(zone);

            OracleParameter date = new OracleParameter();
            date.OracleDbType = OracleDbType.Date;
            date.Direction = ParameterDirection.Input;
            date.Value = fir_date;
            cmd.Parameters.Add(date);

            OracleParameter time = new OracleParameter();
            time.OracleDbType = OracleDbType.Varchar2;
            time.Direction = ParameterDirection.Input;
            time.Value = fir_time + "%";
            cmd.Parameters.Add(time);

            OracleParameter place = new OracleParameter();
            place.OracleDbType = OracleDbType.Varchar2;
            place.Direction = ParameterDirection.Input;
            place.Value = fir_place + "%";
            cmd.Parameters.Add(place);

            OracleParameter dnt_cur = new OracleParameter();
            dnt_cur.OracleDbType = OracleDbType.RefCursor;
            dnt_cur.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(dnt_cur);

            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();
            textBox1.Text = Convert.ToString(dr.GetString(17));
            textBox2.Text = Convert.ToString(dr.GetString(18));
            textBox8.Text = Convert.ToString(dr.GetString(21));
            textBox7.Text = Convert.ToString(dr.GetString(24));
            textBox3.Text = Convert.ToString(dr.GetDecimal(22));
            comboBox1.SelectedItem = Convert.ToString(dr.GetString(23));
            textBox5.Text = Convert.ToString(dr.GetString(29));
            textBox4.Text = Convert.ToString(dr.GetString(30));
            textBox6.Text = Convert.ToString(dr.GetDecimal(31));
            comboBox2.SelectedItem = Convert.ToString(dr.GetString(32));
            textBox14.Text = dr.GetDateTime(3).ToShortDateString();
            textBox13.Text = Convert.ToString(dr.GetString(4));
            textBox9.Text = Convert.ToString(dr.GetString(5));
        }

        private void button2_Click(object sender, EventArgs e)
        {   try
            {
                if (mode.Equals("update"))
                {
                    Update_Fir(fid, uid, sid, textBox14.Text, textBox13.Text, textBox9.Text, textBox8.Text, textBox7.Text, comboBox1.SelectedItem.ToString(), Convert.ToInt32(textBox3.Text), textBox5.Text, textBox4.Text, comboBox2.SelectedItem.ToString(), Convert.ToInt32(textBox6.Text), textBox1.Text, textBox2.Text);
                }
                else if (mode.Equals("add"))
                {
                    Add_Fir(uid, sid, textBox14.Text, textBox13.Text, textBox9.Text, textBox8.Text, textBox7.Text, comboBox1.SelectedItem.ToString(), Convert.ToInt32(textBox3.Text), textBox5.Text, textBox4.Text, comboBox2.SelectedItem.ToString(), Convert.ToInt32(textBox6.Text), textBox1.Text, textBox2.Text);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            this.Close();
        }

    }
}
