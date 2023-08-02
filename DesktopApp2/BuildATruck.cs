using DesktopApp2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICMS
{
    public partial class BuildATruck : Form
    {

        public FormICMSMain f1;
        public int customerID;
        public BuildATruck()
        {

            InitializeComponent();

            

        }

        private void BuildATruck_Load(object sender, EventArgs e)
        {
            ComboBox bb = f1.ShipComboBranch();

            for (int i = 0; i < bb.Items.Count; i++)
            {
                comboBoxBTBranch.Items.Add(bb.Items[i]);

            }
            comboBoxBTBranch.Text = "All";
            LoadBOLs();

        }

        private void LoadBOLs()
        {

            DBUtils db = new DBUtils();

            db.OpenSQLConn();

            using (DbDataReader reader = db.GetShipHdrByCustomer(customerID,false))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //load up listview.
                        ListViewItem lv = new ListViewItem();
                        lv.SubItems[colBTShipID.Index].Text = reader.GetInt32(reader.GetOrdinal("shipID")).ToString().Trim();

                        lv.SubItems.Add("");
                        lv.SubItems[colBTRelNum.Index].Text = reader.GetString(reader.GetOrdinal("releaseNum")).Trim();

                        lv.SubItems.Add("");
                        lv.SubItems[colBTRelDate.Index].Text = reader.GetDateTime(reader.GetOrdinal("releaseDate")).ToString().Trim();

                        lv.SubItems.Add("");
                        lv.SubItems[colBTBranch.Index].Text = reader.GetString(reader.GetOrdinal("branch")).Trim();

                        listViewBTBOLs.Items.Add(lv);

                    }
                }
            }
        }

        private void ButtonBTCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonBTBuildTruck_Click(object sender, EventArgs e)
        {
            if (listViewBTBOLs.CheckedItems.Count < 2)
            {
                MessageBox.Show("You have to have at least 2 items checked!");
                return;
            }
            DBUtils db = new DBUtils();
            db.OpenSQLConn();
            SqlTransaction tran =  db.StartTrans();

            try
            {
                int loadid = 0;
                foreach(ListViewItem lv in listViewBTBOLs.CheckedItems)
                {
                    int shipid = Convert.ToInt32(lv.SubItems[0].Text);
                    DateTime dt = DateTime.Now;
                    loadid = db.InsertTruckLoad(loadid, shipid, dt, 1,tran);

                }
                tran.Commit();
                MessageBox.Show("Load# " + loadid + " created!");

            }catch (Exception se)
            {
                MessageBox.Show("error in Build Truck - " + se.Message);

                tran.Rollback();
            }
        }
    }
}
