using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace Criminal_DB
{
    public partial class UserControl1 : UserControl
    {
        int rootid = 0;
        string rootstation;
        int user_id = 0;
        int station_id = 0;
        int fir_id = 0;
        int case_id = 0;
        int cr_id = 0;
        int level = 0;
        Form2 newfir;
        Form3 newu;
        Form4 news;
        OracleConnection conn;
        public UserControl1(OracleConnection connect, int lvl, int userid, string station)
        {
            InitializeComponent();
            conn = connect;
            level = lvl;
            rootid = userid;
            rootstation = station;
            initScreen(lvl);
            Console.WriteLine("Imprime");
        }

        private void initScreen(int nivel)
        {
            Check_Users(0, "", "", "", "");
            Check_Stations(0, "", "", "");
            Search_Fir(0,"","","","","1/1/0001","","");
            switch(nivel)
            {
                case 1:
                    FIRlist.Enabled = false;
                    Dsearch.Enabled = false;
                    Dadd.Enabled = false;
                    Dedit.Enabled = false;
                    Caselist.Enabled = false;
                    Csearch.Enabled = false;
                    Cadd.Enabled = false;
                    Cedit.Enabled = false;
                    CRlist.Enabled = false;
                    Rsearch.Enabled = false;
                    Radd.Enabled = false;
                    Redit.Enabled = false;
                    break;
                case 2:
                    AddUser.Enabled = false;
                    User_Edit.Enabled = false;
                    Station_edit.Enabled = false;
                    AddSt.Enabled = false;
                    Caselist.Enabled = false;
                    Csearch.Enabled = false;
                    Cadd.Enabled = false;
                    Cedit.Enabled = false;
                    break;
                case 3:
                    AddUser.Enabled = false;
                    User_Edit.Enabled = false;
                    Station_edit.Enabled = false;
                    AddSt.Enabled = false;
                    Dadd.Enabled = false;
                    Dedit.Enabled = false;
                    Dview.Enabled = true;
                    Cadd.Enabled = false;
                    Cedit.Enabled = false;
                    Cview.Enabled = true;
                    Radd.Enabled = false;
                    Redit.Enabled = false;
                    Rview.Enabled = true;
                    break;
                case 4:
                    AddUser.Enabled = false;
                    User_Edit.Enabled = false;
                    Station_edit.Enabled = false;
                    AddSt.Enabled = false;
                    Dadd.Enabled = false;
                    Dedit.Enabled = false;
                    Dview.Enabled = true;
                    Radd.Enabled = false;
                    Redit.Enabled = false;
                    Rview.Enabled = true;
                    break;
                case 5:
                    AddUser.Enabled = false;
                    User_Edit.Enabled = false;
                    Station_edit.Enabled = false;
                    AddSt.Enabled = false;
                    Dadd.Enabled = false;
                    Dedit.Enabled = false;
                    Dview.Enabled = true;
                    break;
                case 6:
                    break;
            }
        }

        private void Userlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Userlist.SelectedItems.Count > 0)
            {
                user_id = Convert.ToInt32(Userlist.SelectedItems[0].SubItems[0].Text);
                New_username.Text = Userlist.SelectedItems[0].SubItems[1].Text;
                New_rank.SelectedItem = Userlist.SelectedItems[0].SubItems[2].Text;
                New_station.Text = Userlist.SelectedItems[0].SubItems[3].Text;
            }
        }

        public void Check_Users(int userid, string username, string user_rank, string station_name, string stationzone)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "TJPD.SEARCH_USER";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter id = new OracleParameter();
            id.OracleDbType = OracleDbType.Decimal;
            id.Direction = ParameterDirection.Input;
            id.Value = userid;
            cmd.Parameters.Add(id);

            OracleParameter name = new OracleParameter();
            name.OracleDbType = OracleDbType.Varchar2;
            name.Direction = ParameterDirection.Input;
            name.Value = username+"%";
            cmd.Parameters.Add(name);

            OracleParameter rank = new OracleParameter();
            rank.OracleDbType = OracleDbType.Varchar2;
            rank.Direction = ParameterDirection.Input;
            rank.Value = user_rank+"%";
            cmd.Parameters.Add(rank);

            OracleParameter station = new OracleParameter();
            station.OracleDbType = OracleDbType.Varchar2;
            station.Direction = ParameterDirection.Input;
            station.Value = station_name+"%";
            cmd.Parameters.Add(station);

            OracleParameter zone = new OracleParameter();
            zone.OracleDbType = OracleDbType.Varchar2;
            zone.Direction = ParameterDirection.Input;
            zone.Value = stationzone+"%";
            cmd.Parameters.Add(zone);

            OracleParameter dnt_cur = new OracleParameter();
            dnt_cur.OracleDbType = OracleDbType.RefCursor;
            dnt_cur.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(dnt_cur);

            OracleDataReader dr = cmd.ExecuteReader();
            Userlist.Items.Clear();
            while (dr.Read())
            {
                Console.WriteLine(dr.GetDecimal(0) + " " + dr.GetString(1) + " " + dr.GetString(2) + " " + dr.GetString(3) + " " + dr.GetString(4));
                ListViewItem lvi = new ListViewItem(Convert.ToString(dr.GetDecimal(0)));
                lvi.SubItems.Add(dr.GetString(1));
                lvi.SubItems.Add(dr.GetString(2));
                lvi.SubItems.Add(dr.GetString(3));
                lvi.SubItems.Add(dr.GetString(4));

                Userlist.Items.Add(lvi);
            }
        }

        private void Delete_user(int id)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "TJPD.LVL1.DELETE_USER";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("OFID", OracleDbType.Decimal, id, ParameterDirection.Input);

            cmd.ExecuteNonQuery();
        }

        private void Edit_user(int id, string name, string officer_rank, string station_name)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "TJPD.LVL1.EDIT_USER";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.BindByName = true;

            cmd.Parameters.Add("OFID", OracleDbType.Decimal, id, ParameterDirection.Input);

            cmd.Parameters.Add("ONAME", OracleDbType.Varchar2, name, ParameterDirection.Input);

            cmd.Parameters.Add("ORANK", OracleDbType.Varchar2, officer_rank, ParameterDirection.Input);

            cmd.Parameters.Add("SNAME", OracleDbType.Varchar2, station_name, ParameterDirection.Input);

            cmd.ExecuteNonQuery();
        }

        private void User_Edit_CheckedChanged(object sender, EventArgs e)
        {
            New_username.Enabled = !New_username.Enabled;
            New_rank.Enabled = !New_rank.Enabled;
            New_station.Enabled = !New_station.Enabled;
            UpdateUser.Enabled = !UpdateUser.Enabled;
            DeleteUser.Enabled = !DeleteUser.Enabled;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                Check_Users(Convert.ToInt32(User_ID.Text), User_Name.Text, User_Rank.SelectedItem.ToString(), User_Station.Text, User_Zone.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Los campos estan mal ingresados.", "Base de datos criminalistica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void UpdateUser_Click(object sender, EventArgs e)
        {
            Edit_user(user_id, New_username.Text, New_rank.SelectedItem.ToString(), New_station.Text);
            Check_Users(0, "", "", "", "");
        }

        private void DeleteUser_Click(object sender, EventArgs e)
        {
            Delete_user(user_id);
            Check_Users(0, "", "", "", "");
        }

        private void AddUser_Click(object sender, EventArgs e)
        {
            newu = new Form3(conn);
            newu.Show();
            this.Enabled = false;
            newu.FormClosing += adduclose;
        }

        private void adduclose(object sender, EventArgs e)
        {
            this.Enabled = true;
            Check_Users(0, "", "", "", "");
        }

        public void Check_Stations(int userid, string station_name, string station_adr, string stationzone)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "TJPD.SEARCH_STATION";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter id = new OracleParameter();
            id.OracleDbType = OracleDbType.Decimal;
            id.Direction = ParameterDirection.Input;
            id.Value = userid;
            cmd.Parameters.Add(id);

            OracleParameter name = new OracleParameter();
            name.OracleDbType = OracleDbType.Varchar2;
            name.Direction = ParameterDirection.Input;
            name.Value = station_name + "%";
            cmd.Parameters.Add(name);

            OracleParameter addr = new OracleParameter();
            addr.OracleDbType = OracleDbType.Varchar2;
            addr.Direction = ParameterDirection.Input;
            addr.Value = station_adr + "%";
            cmd.Parameters.Add(addr);

            OracleParameter zone = new OracleParameter();
            zone.OracleDbType = OracleDbType.Varchar2;
            zone.Direction = ParameterDirection.Input;
            zone.Value = stationzone + "%";
            cmd.Parameters.Add(zone);

            OracleParameter dnt_cur = new OracleParameter();
            dnt_cur.OracleDbType = OracleDbType.RefCursor;
            dnt_cur.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(dnt_cur);

            OracleDataReader dr = cmd.ExecuteReader();
            Stationlist.Items.Clear();
            while (dr.Read())
            {
                Console.WriteLine(dr.GetDecimal(0) + " " + dr.GetString(1) + " " + dr.GetString(2) + " " + dr.GetString(3));
                ListViewItem lvi = new ListViewItem(Convert.ToString(dr.GetDecimal(0)));
                lvi.SubItems.Add(dr.GetString(1));
                lvi.SubItems.Add(dr.GetString(2));
                lvi.SubItems.Add(dr.GetString(3));

                Stationlist.Items.Add(lvi);
            }
        }

        private void Delete_station(int id)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "TJPD.LVL1.DELETE_STATION";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("STID", OracleDbType.Decimal, id, ParameterDirection.Input);

            cmd.ExecuteNonQuery();
        }

        private void Edit_station(int id, string name, string adr, string zone)
        {
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "TJPD.LVL1.EDIT_STATION";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.BindByName = true;

            cmd.Parameters.Add("STID", OracleDbType.Decimal, id, ParameterDirection.Input);

            cmd.Parameters.Add("STNAME", OracleDbType.Varchar2, name, ParameterDirection.Input);

            cmd.Parameters.Add("STADDR", OracleDbType.Varchar2, adr, ParameterDirection.Input);

            cmd.Parameters.Add("STZONE", OracleDbType.Varchar2, zone, ParameterDirection.Input);

            cmd.ExecuteNonQuery();
        }

        private void Search_Fir(int fir_id, string off_name, string off_rank, string sta_name, string sta_zone, string fir_date, string fir_time, string fir_place)
        {
            var dates = fir_date.Split('/');
            Console.WriteLine(dates[0]);
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
            fir_date = dates[1] + "-" + dates[0] + "-" + dates[2];

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
            FIRlist.Items.Clear();
            while (dr.Read())
            {
                ListViewItem lvi = new ListViewItem(Convert.ToString(dr.GetDecimal(0)));
                lvi.SubItems.Add(Convert.ToString(dr.GetString(7)));
                lvi.SubItems.Add(Convert.ToString(dr.GetString(8)));
                lvi.SubItems.Add(Convert.ToString(dr.GetString(12)));
                lvi.SubItems.Add(Convert.ToString(dr.GetString(14)));
                lvi.SubItems.Add(dr.GetDateTime(3).ToShortDateString());
                lvi.SubItems.Add(Convert.ToString(dr.GetString(4)));
                lvi.SubItems.Add(Convert.ToString(dr.GetString(5)));

                FIRlist.Items.Add(lvi);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Check_Stations(Convert.ToInt32(StID.Text), StName.Text, StAdr.Text, StZone.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Los campos estan mal ingresados.", "Base de datos criminalistica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            NewStation.Enabled = !NewStation.Enabled;
            NewAdr.Enabled = !NewAdr.Enabled;
            NewZone.Enabled = !NewZone.Enabled;
            UpdateSt.Enabled = !UpdateSt.Enabled;
            DelSt.Enabled = !DelSt.Enabled;
        }

        private void Stationlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Stationlist.SelectedItems.Count > 0)
            {
                station_id = Convert.ToInt32(Stationlist.SelectedItems[0].SubItems[0].Text);
                NewStation.Text = Stationlist.SelectedItems[0].SubItems[1].Text;
                NewAdr.Text = Stationlist.SelectedItems[0].SubItems[2].Text;
                NewZone.SelectedItem = Stationlist.SelectedItems[0].SubItems[3].Text;
            }
        }

        private void UpdateSt_Click(object sender, EventArgs e)
        {
            Edit_station(station_id, NewStation.Text, NewAdr.Text, NewZone.SelectedItem.ToString());
            Check_Stations(0, "", "", "");
        }

        private void DelSt_Click(object sender, EventArgs e)
        {
            Delete_station(station_id);
            Check_Stations(0, "", "", "");
        }

        private void AddSt_Click(object sender, EventArgs e)
        {
            news = new Form4(conn);
            news.Show();
            this.Enabled = false;
            news.FormClosing += addsclose;
        }

        private void addsclose(object sender, EventArgs e)
        {
            this.Enabled = true;
            Check_Stations(0, "", "", "");
        }

        private void Dedit_CheckedChanged(object sender, EventArgs e)
        {
            DFIRID.Enabled = !DFIRID.Enabled;
            Dupdate.Enabled = !Dupdate.Enabled;
            Dview.Enabled = !Dview.Enabled;
        }

        private void Cedit_CheckedChanged(object sender, EventArgs e)
        {
            CASEID.Enabled = !CASEID.Enabled;
            Cupdate.Enabled = !Cupdate.Enabled;
            Cview.Enabled = !Cview.Enabled;
        }

        private void Redit_CheckedChanged(object sender, EventArgs e)
        {
            REGID.Enabled = !REGID.Enabled;
            Rupdate.Enabled = !Rupdate.Enabled;
            Rview.Enabled = !Rview.Enabled;
        }

        private void FIRlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FIRlist.SelectedItems.Count > 0)
            {
                fir_id = Convert.ToInt32(FIRlist.SelectedItems[0].SubItems[0].Text);
                DFIRID.Text = fir_id.ToString();
            }
        }

        private void Caselist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Caselist.SelectedItems.Count > 0)
            {
                case_id = Convert.ToInt32(Caselist.SelectedItems[0].SubItems[0].Text);
                CASEID.Text = case_id.ToString();
            }
        }

        private void CRlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CRlist.SelectedItems.Count > 0)
            {
                cr_id = Convert.ToInt32(CRlist.SelectedItems[0].SubItems[0].Text);
                REGID.Text = cr_id.ToString();
            }
        }

        private void CriminalR_Click(object sender, EventArgs e)
        {

        }

        private void Radd_Click(object sender, EventArgs e)
        {

        }

        private void Dadd_Click(object sender, EventArgs e)
        {
            newfir = new Form2(conn, "add", rootid, find_station(rootstation));
            Console.WriteLine(find_station("CDMXPD"));
            newfir.Show();
            this.Enabled = false;
            newfir.FormClosing += addsclose;
        }

        private void Dupdate_Click(object sender, EventArgs e)
        {
            newfir = new Form2(conn, "update", fir_id, rootid, find_station(rootstation));
            newfir.Show();
            this.Enabled = false;
            newfir.FormClosing += addsclose;
        }

        private int find_station(string station_name)
        {
            int station_id = 0;
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "TJPD.LVL1.FIND_STATION";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.BindByName = true;

            cmd.Parameters.Add("SNAME", OracleDbType.Varchar2, station_name, ParameterDirection.Input);

            var return_param = cmd.Parameters.Add("STID", OracleDbType.Decimal, ParameterDirection.ReturnValue);

            cmd.ExecuteNonQuery();

            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();
            station_id = Convert.ToInt32(return_param.Value.ToString());
            return station_id;
        }

        private void Denuncias_Click(object sender, EventArgs e)
        {

        }

        private void Rsearch_Click(object sender, EventArgs e)
        {

        }

        private void Dsearch_Click(object sender, EventArgs e)
        {
            try
            {
                Search_Fir(Convert.ToInt32(DID.Text), Dname.Text, Drank.SelectedItem.ToString(), Dstation.Text, Dzone.SelectedItem.ToString(), Ddate.Text, Dtime.Text, Dplace.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Los campos estan mal ingresados.", "Base de datos criminalistica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
                this.Ddate.Text = e.Start.ToShortDateString();
                monthCalendar1.Visible = false;
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (e.Start.ToShortDateString().Equals(e.End.ToShortDateString()))
            {
                this.Ddate.Text = e.Start.ToShortDateString();
                monthCalendar1.Visible = false;
            }
        }
    }
}
