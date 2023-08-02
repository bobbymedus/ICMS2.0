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
using static DesktopApp2.FormICMSMain;

namespace ICMS
{
    public partial class Shipping : Form
    {

        public int custID;

        public bool firstCustPO;

        public string branch;

        public FormICMSMain f1;
        
        public Shipping()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;

            this.ActiveControl = textBoxShipReleaseNum;
            
        }

        public Boolean IsNumber(String s)
        {
            Boolean value = true;
            foreach (Char c in s.ToCharArray())
            {
                value = value && Char.IsDigit(c);
            }

            return value;
        }

        public void LoadItems()
        {


            int cntr = 0;

            //f1 is set to "this" in calling form.  shipping.f1 = this;
            foreach (ListViewItem fr in f1.GetShipCoilItems())
            {
                dataGridViewShip.Rows.Add();
                dataGridViewShip.Rows[cntr].Cells[dgvShipTagID.Index].Value = fr.SubItems[0].Text;

                TagParser tp = new TagParser();
                tp.TagToBeParsed = fr.SubItems[0].Text;

                tp.ParseTag();


                dataGridViewShip.Rows[cntr].Cells[dgvShipOriginID.Index].Value = tp.TagID;
                dataGridViewShip.Rows[cntr].Cells[dgvShipCoilTagSuffix.Index].Value = tp.CoilTagSuffix;
                dataGridViewShip.Rows[cntr].Cells[dgvShipType.Index].Value = "Coil";
                dataGridViewShip.Rows[cntr].Cells[dgvShipType.Index].Tag = 0;
                dataGridViewShip.Rows[cntr].Cells[dgvShipAlloy.Index].Value = fr.SubItems[2].Text;
                dataGridViewShip.Rows[cntr].Cells[dgvShipThickness.Index].Value = fr.SubItems[3].Text;
                dataGridViewShip.Rows[cntr].Cells[dgvShipWidth.Index].Value = fr.SubItems[4].Text;
                dataGridViewShip.Rows[cntr].Cells[dgvShipLength.Index].Value = fr.SubItems[5].Text;
                dataGridViewShip.Rows[cntr].Cells[dgvShipWeight.Index].Value = fr.SubItems[6].Text;
                cntr++;
            }
            
            foreach (ListViewItem fr in f1.GetShipSkidItems())
            {
                dataGridViewShip.Rows.Add();
                dataGridViewShip.Rows[cntr].Cells[dgvShipTagID.Index].Value = fr.SubItems[0].Text;


                TagParser tp = new TagParser();

                tp.TagToBeParsed = fr.SubItems[0].Text;

                tp.ParseTag();


                dataGridViewShip.Rows[cntr].Cells[dgvShipOriginID.Index].Value = tp.TagID;
                dataGridViewShip.Rows[cntr].Cells[dgvShipSkidLetter.Index].Value = tp.SkidLetter;
                dataGridViewShip.Rows[cntr].Cells[dgvShipCoilTagSuffix.Index].Value = tp.CoilTagSuffix;

                dataGridViewShip.Rows[cntr].Cells[dgvShipType.Index].Value = "Skid";
                dataGridViewShip.Rows[cntr].Cells[dgvShipType.Index].Tag = 1;
                dataGridViewShip.Rows[cntr].Cells[dgvShipAlloy.Index].Value = fr.SubItems[3].Text;
                dataGridViewShip.Rows[cntr].Cells[dgvShipThickness.Index].Value = fr.SubItems[4].Text;
                dataGridViewShip.Rows[cntr].Cells[dgvShipWidth.Index].Value = fr.SubItems[5].Text;
                dataGridViewShip.Rows[cntr].Cells[dgvShipLength.Index].Value = fr.SubItems[6].Text;
                dataGridViewShip.Rows[cntr].Cells[dgvShipWeight.Index].Value = fr.SubItems[7].Text;
                cntr++;
            }

        }
        private void ButtonShipCreateBOL_Click(object sender, EventArgs e)
        {
            if (CheckField( textBoxShipReleaseNum, "Release Number"))
            {
                return;
            }
            if (CheckField(textBoxShipCarrier, "Carrier"))
            {
                return;
            }
            if (CheckField(textBoxShipDestination, "Destination"))
            {
                return;
            }
            if (CheckField(textBoxShipCity, "City"))
            {
                return;
            }
            if (CheckField(textBoxShipState, "State"))
            {
                return;
            }
            if (CheckField(textBoxShipDeliveryCarrier, "Delivery Carrier"))
            {
                return;
            }
            if (CheckField(textBoxShipConsTo, "Consigned To"))
            {
                return;
            }
            if (CheckField(textBoxConsZip, "Zip"))
            {
                return;
            }
            if (CheckField(textBoxShipPer, "Ship Per"))
            {
                return;
            }

            for (int i = 0;i< dataGridViewShip.Rows.Count; i++)
            {
                if (dataGridViewShip.Rows[i].Cells[dgvShipPO.Index].Value == null ||
                    dataGridViewShip.Rows[i].Cells[dgvShipPO.Index].Value.Equals(""))
                {
                    MessageBox.Show("Customer PO cannot be blank.");
                    dataGridViewShip.CurrentCell = dataGridViewShip.Rows[i].Cells[dgvShipPO.Index];
                    dataGridViewShip.BeginEdit(true);
                    return;
                }
                if (dataGridViewShip.Rows[i].Cells[dgvShipWeight.Index].Value == null ||
                    dataGridViewShip.Rows[i].Cells[dgvShipWeight.Index].Value.Equals("")||
                    Convert.ToInt32(dataGridViewShip.Rows[i].Cells[dgvShipWeight.Index].Value)<=0)
                {
                    MessageBox.Show("Weight is invalid.  Please correct.");
                    dataGridViewShip.CurrentCell = dataGridViewShip.Rows[i].Cells[dgvShipWeight.Index];
                    dataGridViewShip.BeginEdit(true);
                    return;
                }
            }

            bool modify = false;
            if (buttonShipCreateBOL.Text.Equals("Modify BOL"))
            {
                modify = true;

            }

            DBUtils db = new DBUtils();
            DBUtils.ShipHdrInfo sh = new DBUtils.ShipHdrInfo();
            DBUtils.ShipDtlInfo sd = new DBUtils.ShipDtlInfo();

            db.OpenSQLConn();
            SqlTransaction tran = db.StartTrans();
            try
            {




                sh.CustomerID = custID;
                sh.ReleaseNum = textBoxShipReleaseNum.Text.Trim();
                sh.ReleaseDate = dateTimePickerShipDate.Value;
                sh.Carrier = textBoxShipCarrier.Text.Trim();
                sh.Destination = textBoxShipDestination.Text.Trim();
                sh.City = textBoxShipCity.Text.Trim();
                sh.State = textBoxShipState.Text.Trim();
                sh.Route = textBoxShipRoute.Text.Trim();
                sh.DeliveryCarrier = textBoxShipDeliveryCarrier.Text.Trim();
                sh.ShipAgent = textBoxShipShipper.Text.Trim();
                sh.ShipAddress = textBoxShipShipperAddr.Text.Trim();
                sh.ConsignedTo = textBoxShipConsTo.Text.Trim();
                sh.Street = textBoxShipConsStreet.Text.Trim();
                sh.County = textBoxShipConsCounty.Text.Trim();
                sh.Zip = textBoxConsZip.Text.Trim();
                sh.DeliveryAddress = textBoxShipDelvAddr.Text.Trim();
                sh.TractorNum = textBoxShipTractor.Text.Trim();
                sh.TrailerNum = textBoxShipTrailer.Text.Trim();
                sh.ShipPerson = textBoxShipPer.Text.Trim();
                if (radioButtonShipPrepaid.Checked)
                {
                    sh.PrepaidCollect = 0;
                }
                else
                {
                    sh.PrepaidCollect = 1;
                }
                sh.Status = 1;
                sh.Branch = branch;

                int shipID = 0;
                if (modify)
                {
                    //update shiphdr
                    sh.ShipID = Convert.ToInt32(buttonShipCreateBOL.Tag);
                    db.UpdateShipHdr(sh, tran);

                    //updateskidstatus/coilstatus so they are not showing as shipped.
                    //have to do this before deleting the shipdtl info.
                    db.UndoCoilSkidStatus(sh.ShipID, tran);
                    sd.ShipID = sh.ShipID;
                    int delRows = db.DeleteShipDtl(sd.ShipID, tran);

                    shipID = sd.ShipID;
                }
                else
                {
                    //insert ship header
                    shipID = db.InsertShipHdr(sh, tran);
                }

                

                for (int i = 0; i < dataGridViewShip.Rows.Count; i++)
                {
                    sd.CustomerPO = dataGridViewShip.Rows[i].Cells[dgvShipPO.Index].Value.ToString().Trim();
                    sd.ShipID = shipID;
                    sd.Id = Convert.ToInt32(dataGridViewShip.Rows[i].Cells[dgvShipOriginID.Index].Value);
                    sd.CoilTagSuffix = dataGridViewShip.Rows[i].Cells[dgvShipCoilTagSuffix.Index].Value.ToString().Trim();
                    if (dataGridViewShip.Rows[i].Cells[dgvShipSkidLetter.Index].Value == null)
                    {
                        dataGridViewShip.Rows[i].Cells[dgvShipSkidLetter.Index].Value = "";
                    }
                    sd.Letter = dataGridViewShip.Rows[i].Cells[dgvShipSkidLetter.Index].Value.ToString().Trim();
                    sd.Type = Convert.ToInt32(dataGridViewShip.Rows[i].Cells[dgvShipType.Index].Tag);
                    sd.Status = 1;
                    sd.Weight = Convert.ToInt32(dataGridViewShip.Rows[i].Cells[dgvShipWeight.Index].Value);
                    sd.DateModified = DateTime.Now;

                   
                    //insert shipdtl

                    int retID = db.InsertShipDtl(sd, tran);

                    if (sd.Type == 1)
                    {
                        int cnt = db.UpdateSkidStatus(sd.Id, sd.CoilTagSuffix, sd.Letter, 2, tran);
                    }
                    else
                    {
                        int cnt = db.UpdateCoilStatus(sd.Id, sd.CoilTagSuffix, 2, tran);
                    }
                    

                }

                if (modify)
                {
                    MessageBox.Show("BOL# " + shipID.ToString() + " modified!");
                }
                else
                {
                    MessageBox.Show("BOL# " + shipID.ToString() + " created!");
                }
                

                tran.Commit();
                db.CloseSQLConn();

                ReportGeneration rg = new ReportGeneration();

                rg.setReportDrive(MachineDefaults.ReportDrive);

                rg.Shipping(shipID);


                if (!modify)
                {
                    f1.ShipComboBranch().Text = "All";

                    foreach (ListViewItem fr in f1.GetShipCoilItems())
                    {
                        int index = fr.Index;

                        fr.ForeColor = Color.Blue;
                        fr.Checked = false;
                    }
                    foreach (ListViewItem fr in f1.GetShipSkidItems())
                    {
                        fr.ForeColor = Color.Blue;
                        fr.Checked = false;
                    }
                    f1.SyncShipColor();
                }
                else
                {
                    f1.LoadRemoteShipData();
                }
                
            }
            catch (Exception se)
            {
                if (tran != null)
                {
                    tran.Rollback();
                }
                
                db.CloseSQLConn();
                MessageBox.Show(se.ToString());

            }

            
            



            this.Close();
        }

        private bool CheckField(TextBox tx, string messageinfo)
        {
            if (tx.Text == null || tx.Text.Equals(""))
            {
                MessageBox.Show(messageinfo + " is a required field!");
                tx.Focus();
                return true;
            }

            return false;
        }


        private void DataGridViewShip_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (firstCustPO && dataGridViewShip.Rows.Count > 1)
            {
                if (dataGridViewShip.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    return;
                }
                if (MessageBox.Show(this, "Use the same PO for all items?", "Verify PO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string po = dataGridViewShip.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    for(int i = 0;i < dataGridViewShip.Rows.Count; i++)
                    {
                        dataGridViewShip.Rows[i].Cells[0].Value = po;
                    }
                }
                if (textBoxShipReleaseNum.Text == null || textBoxShipReleaseNum.Text == "")
                {
                    textBoxShipReleaseNum.Focus();
                }
                else
                {
                    buttonShipCreateBOL.Focus();
                }
            
                firstCustPO = false;
            }

            

        }
        private void ColumnDigitNoDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
        private void ColumnDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void DataGridViewShip_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnDigit_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnDigitNoDecimal_KeyPress);

            if (e.Control is System.Windows.Forms.TextBox)

                ((System.Windows.Forms.TextBox)e.Control).CharacterCasing = CharacterCasing.Upper;
            if (dataGridViewShip.CurrentCell.ColumnIndex == dgvShipWeight.Index) //Desired Column
            {
                if (e.Control is System.Windows.Forms.TextBox tb)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColumnDigitNoDecimal_KeyPress);
                }
            }

        }

        
        private void ButtonDeleteRow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridViewShip.SelectedRows)
            {
                dataGridViewShip.Rows.RemoveAt(item.Index);
            }
            if (dataGridViewShip.Rows.Count <= 0)
            {
                this.Close();
            }
        }
        public bool ModifyBOL(int bolNumber)
        {
            bool goodtogo = false;

            
            foreach (ListViewItem lv in f1.GetAllShipCoilItems())
            {

                //make a copy and add it to the list.
                ListViewItem l1 = (ListViewItem) lv.Clone();
                listViewModShipCoil.Items.Add(l1);

            }
            foreach (ListViewItem lv in f1.GetAllShipSkidItems())
            {
                //make a copy and add it to the list.
                ListViewItem l1 = (ListViewItem)lv.Clone();
                listViewModShipSkid.Items.Add(l1);

            }

            //load up stuff from database.
            DBUtils db = new DBUtils();
            db.OpenSQLConn();
            int cntr = 0;
            //get coils
            using (DbDataReader reader = db.GetShipCoilDtls(bolNumber,false, true))
            {
                
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (!goodtogo)//first record
                        {
                            //get header info
                            textBoxShipReleaseNum.Text = reader.GetString(reader.GetOrdinal("releaseNum")).Trim();
                            textBoxShipCarrier.Text = reader.GetString(reader.GetOrdinal("carrierName")).Trim();
                            textBoxShipDestination.Text = reader.GetString(reader.GetOrdinal("destination")).Trim();
                            textBoxShipCity.Text = reader.GetString(reader.GetOrdinal("city")).Trim();
                            textBoxShipState.Text = reader.GetString(reader.GetOrdinal("state")).Trim();
                            textBoxShipRoute.Text = reader.GetString(reader.GetOrdinal("route")).Trim();
                            textBoxShipDeliveryCarrier.Text = reader.GetString(reader.GetOrdinal("deliveryCarrier")).Trim();
                            textBoxShipShipper.Text = reader.GetString(reader.GetOrdinal("shipAgent")).Trim();
                            textBoxShipShipperAddr.Text = reader.GetString(reader.GetOrdinal("shipAddress")).Trim();
                            textBoxShipConsTo.Text = reader.GetString(reader.GetOrdinal("consignedTo")).Trim();
                            textBoxShipConsStreet.Text = reader.GetString(reader.GetOrdinal("street")).Trim();
                            textBoxShipConsCounty.Text = reader.GetString(reader.GetOrdinal("county")).Trim();
                            textBoxConsZip.Text = reader.GetString(reader.GetOrdinal("zip")).Trim();
                            textBoxShipDelvAddr.Text = reader.GetString(reader.GetOrdinal("deliveryAddress")).Trim();
                            textBoxShipTractor.Text = reader.GetString(reader.GetOrdinal("tractorNum")).Trim();
                            textBoxShipTrailer.Text = reader.GetString(reader.GetOrdinal("trailerNum")).Trim();
                            textBoxShipPer.Text = reader.GetString(reader.GetOrdinal("shipPerson")).Trim();
                            dateTimePickerShipDate.Value = reader.GetDateTime(reader.GetOrdinal("releaseDate"));
                        }
                        dataGridViewShip.Rows.Add();
                        dataGridViewShip.Rows[cntr].Cells[0].Value = reader.GetString(reader.GetOrdinal("custPO")).Trim();
                        int tagID = reader.GetInt32(reader.GetOrdinal("id"));
                        string coiltagSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();

                        dataGridViewShip.Rows[cntr].Cells[dgvShipTagID.Index].Value = tagID.ToString().Trim() + coiltagSuffix.Trim();
                        dataGridViewShip.Rows[cntr].Cells[dgvShipOriginID.Index].Value = tagID;
                        dataGridViewShip.Rows[cntr].Cells[dgvShipCoilTagSuffix.Index].Value = coiltagSuffix.Trim();
                        dataGridViewShip.Rows[cntr].Cells[dgvShipType.Index].Value = "Coil";
                        dataGridViewShip.Rows[cntr].Cells[dgvShipType.Index].Tag = 0;

                        string alloy = reader.GetString(reader.GetOrdinal("alloyDesc")).Trim();
                        string finish = reader.GetString(reader.GetOrdinal("FinishDesc")).Trim();

                        dataGridViewShip.Rows[cntr].Cells[dgvShipAlloy.Index].Value = alloy.Trim() + " " + finish.Trim();

                        dataGridViewShip.Rows[cntr].Cells[dgvShipThickness.Index].Value = reader.GetDecimal(reader.GetOrdinal("thickness"));
                        dataGridViewShip.Rows[cntr].Cells[dgvShipWidth.Index].Value = reader.GetDecimal(reader.GetOrdinal("width"));

                        dataGridViewShip.Rows[cntr].Cells[dgvShipLength.Index].Value = reader.GetDecimal(reader.GetOrdinal("length"));

                        dataGridViewShip.Rows[cntr].Cells[dgvShipWeight.Index].Value = reader.GetInt32(reader.GetOrdinal("weight"));


                        string taginfo = tagID.ToString().Trim() + coiltagSuffix;
                        for (int i= 0;i< listViewModShipCoil.Items.Count;i++)
                        {
                            ListViewItem lv = listViewModShipCoil.Items[i];
                            
                            if (lv.SubItems[0].Text.Equals(taginfo))
                            {
                                lv.Checked = true;
                                lv.SubItems[6].Tag = dataGridViewShip.Rows[cntr].Cells[0].Value;

                                //exit when you find a match
                                i = listViewModShipCoil.Items.Count;
                            }
                        }




                        cntr++;



                        goodtogo = true;
                    }




                    


                }
            }

            using (DbDataReader reader = db.GetShipSkidlDtls(bolNumber,false,true))
            {
                
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (!goodtogo)//first record
                        {
                            //get header info
                            textBoxShipReleaseNum.Text = reader.GetString(reader.GetOrdinal("releaseNum")).Trim();
                            textBoxShipCarrier.Text = reader.GetString(reader.GetOrdinal("carrierName")).Trim();
                            textBoxShipDestination.Text = reader.GetString(reader.GetOrdinal("destination")).Trim();
                            textBoxShipCity.Text = reader.GetString(reader.GetOrdinal("city")).Trim();
                            textBoxShipState.Text = reader.GetString(reader.GetOrdinal("state")).Trim();
                            textBoxShipRoute.Text = reader.GetString(reader.GetOrdinal("route")).Trim();
                            textBoxShipDeliveryCarrier.Text = reader.GetString(reader.GetOrdinal("deliveryCarrier")).Trim();
                            textBoxShipShipper.Text = reader.GetString(reader.GetOrdinal("shipAgent")).Trim();
                            textBoxShipShipperAddr.Text = reader.GetString(reader.GetOrdinal("shipAddress")).Trim();
                            textBoxShipConsTo.Text = reader.GetString(reader.GetOrdinal("consignedTo")).Trim();
                            textBoxShipConsStreet.Text = reader.GetString(reader.GetOrdinal("street")).Trim();
                            textBoxShipConsCounty.Text = reader.GetString(reader.GetOrdinal("county")).Trim();
                            textBoxConsZip.Text = reader.GetString(reader.GetOrdinal("zip")).Trim();
                            textBoxShipDelvAddr.Text = reader.GetString(reader.GetOrdinal("deliveryAddress")).Trim();
                            textBoxShipTractor.Text = reader.GetString(reader.GetOrdinal("tractorNum")).Trim();
                            textBoxShipTrailer.Text = reader.GetString(reader.GetOrdinal("trailerNum")).Trim();
                            textBoxShipPer.Text = reader.GetString(reader.GetOrdinal("shipPerson")).Trim();
                            dateTimePickerShipDate.Value = reader.GetDateTime(reader.GetOrdinal("releaseDate"));
                        }
                        dataGridViewShip.Rows.Add();
                        dataGridViewShip.Rows[cntr].Cells[0].Value = reader.GetString(reader.GetOrdinal("custPO")).Trim();
                        int tagID = reader.GetInt32(reader.GetOrdinal("id"));
                        string coiltagSuffix = reader.GetString(reader.GetOrdinal("coilTagSuffix")).Trim();
                        string letter = reader.GetString(reader.GetOrdinal("letter")).Trim();

                        dataGridViewShip.Rows[cntr].Cells[dgvShipTagID.Index].Value = tagID.ToString().Trim() + coiltagSuffix.Trim() + "." + letter.Trim() ;
                        dataGridViewShip.Rows[cntr].Cells[dgvShipOriginID.Index].Value = tagID;
                        dataGridViewShip.Rows[cntr].Cells[dgvShipCoilTagSuffix.Index].Value = coiltagSuffix.Trim();
                        dataGridViewShip.Rows[cntr].Cells[dgvShipSkidLetter.Index].Value = letter;
                        dataGridViewShip.Rows[cntr].Cells[dgvShipType.Index].Value = "Skid";
                        dataGridViewShip.Rows[cntr].Cells[dgvShipType.Index].Tag = 1;

                        string alloy = reader.GetString(reader.GetOrdinal("alloyDesc"));
                        string finish = reader.GetString(reader.GetOrdinal("FinishDesc"));

                        dataGridViewShip.Rows[cntr].Cells[dgvShipAlloy.Index].Value = alloy.Trim() + " " + finish.Trim();






                        dataGridViewShip.Rows[cntr].Cells[dgvShipThickness.Index].Value = reader.GetDecimal(reader.GetOrdinal("mic1"));
                        dataGridViewShip.Rows[cntr].Cells[dgvShipWidth.Index].Value = reader.GetDecimal(reader.GetOrdinal("width"));



                        dataGridViewShip.Rows[cntr].Cells[dgvShipLength.Index].Value = reader.GetDecimal(reader.GetOrdinal("length"));
                        decimal weight = reader.GetInt32(reader.GetOrdinal("weight"));

                        dataGridViewShip.Rows[cntr].Cells[dgvShipWeight.Index].Value = weight;
                        string taginfo = tagID.ToString().Trim() + coiltagSuffix + "." + letter;
                        for (int i = 0; i < listViewModShipSkid.Items.Count; i++)
                        {
                            ListViewItem lv = listViewModShipSkid.Items[i];
                            
                            if (lv.SubItems[0].Text.Equals(taginfo))
                            {
                                lv.Checked = true;
                                lv.SubItems[6].Tag = dataGridViewShip.Rows[cntr].Cells[0].Value;

                                //exit when you find a match
                                i = listViewModShipSkid.Items.Count;
                            }
                        }



                        cntr++;




                        goodtogo = true;
                    }







                }
            }

            db.CloseSQLConn();
            //get skids
            buttonShipCreateBOL.Text = "Modify BOL";
            buttonShipCreateBOL.Tag = bolNumber;
            buttonShipModDelete.Visible = true;
            buttonBOLShowModList.Visible = true;
            
            return goodtogo;
        }


        private void ButtonBOLShowModList_Click(object sender, EventArgs e)
        {
            panelShipModLists.Visible = true;
            panelShipModLists.BringToFront ();
        }

        private void ButtonModSelectionFinished_Click(object sender, EventArgs e)
        {
            //go through each list and move to datagridview
            if (listViewModShipCoil.CheckedItems.Count ==0 && listViewModShipSkid.CheckedItems.Count == 0)
            {
                MessageBox.Show("You must select at least one item.");
                return;
            }
            dataGridViewShip.Rows.Clear();
            int cntr = 0;
            foreach (ListViewItem fr in listViewModShipCoil.CheckedItems)
            {
                dataGridViewShip.Rows.Add();
                dataGridViewShip.Rows[cntr].Cells[dgvShipTagID.Index].Value = fr.SubItems[0].Text;

                TagParser tp = new TagParser();

                tp.TagToBeParsed = fr.SubItems[0].Text;

                tp.ParseTag();


                dataGridViewShip.Rows[cntr].Cells[dgvShipOriginID.Index].Value = tp.TagID;
                dataGridViewShip.Rows[cntr].Cells[dgvShipCoilTagSuffix.Index].Value = tp.CoilTagSuffix;
                dataGridViewShip.Rows[cntr].Cells[dgvShipType.Index].Value = "Coil";
                dataGridViewShip.Rows[cntr].Cells[dgvShipType.Index].Tag = 0;
                dataGridViewShip.Rows[cntr].Cells[dgvShipAlloy.Index].Value = fr.SubItems[2].Text;
                dataGridViewShip.Rows[cntr].Cells[dgvShipThickness.Index].Value = fr.SubItems[3].Text;
                dataGridViewShip.Rows[cntr].Cells[dgvShipWidth.Index].Value = fr.SubItems[4].Text;
                dataGridViewShip.Rows[cntr].Cells[dgvShipLength.Index].Value = fr.SubItems[5].Text;
                dataGridViewShip.Rows[cntr].Cells[dgvShipWeight.Index].Value = fr.SubItems[6].Text;
                if (fr.SubItems[6].Tag != null)
                { 
                    dataGridViewShip.Rows[cntr].Cells[dgvShipPO.Index].Value = fr.SubItems[6].Tag.ToString();
                }
                
                cntr++;
            }

            foreach (ListViewItem fr in listViewModShipSkid.CheckedItems)
            {
                dataGridViewShip.Rows.Add();
                dataGridViewShip.Rows[cntr].Cells[dgvShipTagID.Index].Value = fr.SubItems[0].Text;

                TagParser tp = new TagParser();
                tp.TagToBeParsed = fr.SubItems[0].Text;
                tp.ParseTag();

                dataGridViewShip.Rows[cntr].Cells[dgvShipOriginID.Index].Value = tp.TagID;
                dataGridViewShip.Rows[cntr].Cells[dgvShipSkidLetter.Index].Value = tp.SkidLetter;
                dataGridViewShip.Rows[cntr].Cells[dgvShipCoilTagSuffix.Index].Value = tp.CoilTagSuffix;

                dataGridViewShip.Rows[cntr].Cells[dgvShipType.Index].Value = "Skid";
                dataGridViewShip.Rows[cntr].Cells[dgvShipType.Index].Tag = 1;
                dataGridViewShip.Rows[cntr].Cells[dgvShipAlloy.Index].Value = fr.SubItems[3].Text;
                dataGridViewShip.Rows[cntr].Cells[dgvShipThickness.Index].Value = fr.SubItems[4].Text;
                dataGridViewShip.Rows[cntr].Cells[dgvShipWidth.Index].Value = fr.SubItems[5].Text;
                dataGridViewShip.Rows[cntr].Cells[dgvShipLength.Index].Value = fr.SubItems[6].Text;
                dataGridViewShip.Rows[cntr].Cells[dgvShipWeight.Index].Value = fr.SubItems[7].Text;
                if (fr.SubItems[6].Tag != null)
                {
                    dataGridViewShip.Rows[cntr].Cells[dgvShipPO.Index].Value = fr.SubItems[6].Tag.ToString();
                }
                cntr++;
            }

            firstCustPO = true;
            panelShipModLists.Visible = false;
            panelShipModLists.SendToBack();
        }

        private void ButtonShipCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonShipModCancel_Click(object sender, EventArgs e)
        {
            panelShipModLists.Visible = false;
            panelShipModLists.SendToBack();
        }

        private void ButtonShipModDelete_Click(object sender, EventArgs e)
        {

            int shipID = Convert.ToInt32(buttonShipCreateBOL.Tag);

            if (MessageBox.Show(this, "Permanantely Delete BOL# "+shipID +"?", "Verify Delete", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            DBUtils db = new DBUtils();
            db.OpenSQLConn();
            SqlTransaction tran = db.StartTrans();

            try
            {
                
                db.UpdateShipHdrStatus(shipID, -99, tran);
                db.UndoCoilSkidStatus(shipID, tran);
                db.DeleteShipDtl(shipID, tran);


                tran.Commit();
                MessageBox.Show("BOL# " + shipID + " permanantly deleted!");
                Close();
            }catch(Exception se)
            {
                tran.Rollback();
                MessageBox.Show(se.Message);

            }
        

            
        }

        private void textBoxShipReleaseNum_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
