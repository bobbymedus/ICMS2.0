using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using static DesktopApp2.FormICMSMain;
using static ICMS.CompleteOrders;
using Microsoft.Office.Interop.Excel;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Net.NetworkInformation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Org.BouncyCastle.Asn1.X509;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Web.UI.WebControls;
using Org.BouncyCastle.Asn1.Cmp;
using DesktopApp2;

namespace ICMS
{
    class DBUtils
    {

        public class MachineInfo
        {
            public int processID{ get; set; }
            public string machineName{ get; set; }
            public decimal minThickness{ get; set; }
            public decimal maxThickness{ get; set; }
            public decimal minWidth{ get; set; }
            public decimal maxWidth{ get; set; }
            public decimal minWeight{ get; set; }
            public decimal maxWeight{ get; set; }
            public int maxLength{ get; set; }
            public int minLength{ get; set; }
            public string machineDesc{ get; set; }
            public int leadTime{ get; set; }
            public int finishID{ get; set; }
            public int HoldDown{ get; set; }

        }

        public class CustomerInfo
        {
            public int custID { get; set; }
            public string ShortName { get; set; }
            public string LongName { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string City { get; set; }
            public string StateCode { get; set; }
            public string Zip { get; set; }
            public string Country { get; set; }
            public string Phone { get; set; }
            public string Fax { get; set; }
            public string ContactName { get; set; }
            public string Email { get; set; }
            public string Packaging { get; set; }
            public int MaxSkidWeight { get; set; }
            public int PriceTier { get; set; }
            public int WeightFormula { get; set; }
            public int isActive { get; set; }
            public string QuickBookName { get; set; }
            public int leadTime { get; set; }


        }
        public class ShipDtlInfo
        {
            public int ShipID { get; set; }
            public int Id { get; set; }
            public string CoilTagSuffix { get; set; }
            public string Letter { get; set; }
            public int Type { get; set; }//0=coil;1=skid;
            public int Status { get; set; }
            public int Weight { get; set; }
            public DateTime DateModified { get; set; }
            public string CustomerPO { get; set; }

        }
        public class ShipHdrInfo
        {
            public int ShipID { get; set; }
            public int CustomerID { get; set; }
            public string ReleaseNum { get; set; }
            public DateTime ReleaseDate { get; set; }
            public string Carrier { get; set; }
            public string Destination { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Route { get; set; }
            public string DeliveryCarrier { get; set; }
            public string ShipAgent { get; set; }
            public string ShipAddress { get; set; }
            public string ConsignedTo { get; set; }
            public string Street { get; set; }
            public string County { get; set; }
            public string Zip { get; set; }
            public string DeliveryAddress { get; set; }
            public string TractorNum { get; set; }
            public string TrailerNum { get; set; }
            public string ShipPerson { get; set; }
            public int PrepaidCollect { get; set; }
            public int Status { get; set; }
            public string Branch { get; set; }

        }

        
        

        static class SQLConn
        {
            public static SqlConnection conn = FormICMSMain.SQLConn.conn;
        }

        static class SQLConn1
        {
            public static SqlConnection conn = FormICMSMain.SQLConn1.conn;
        }

        public static SqlConnection GetDBMasterConnection(string u, string p)
        {
            string datasource = @"tsaprocessingchicago.database.windows.net";

            string database = "tsaprocessingdatabase";
            if (PlantLocation.runDebugMode)
            {
                database = "tsaprocessingdatabase_2024-01-05T20-10Z";
            }
            
            

            return DBSQLServerUtils.GetDBConnection(datasource, database, u, p);

        }

        public static SqlConnection GetDBConnection(string u, string p)
        {
            string datasource = @"tsaprocessingchicago.database.windows.net";

            string database = "tsaprocessingdatabase";
            if (PlantLocation.runDebugMode)
            {
                database = "tsaprocessingdatabase_2024-01-05T20-10Z";
            }
            string username = u;
            string password = p;
       
            //I have testuser setup to only see customerID 254
            //done with FUNCTION [Chicago].[fn_customer_security_predicate]
            //and security policy customer_security_policy 04/28/23
            //string username = "testuser";
            //string password = "tsaProcessing1625";

            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
            
        }

        


        public void updateSqlDatabase()
        {
            if (SQLConn.conn.State == ConnectionState.Open)
            {
                SQLConn.conn.Close();
               
            }
            SQLConn.conn = FormICMSMain.SQLConn.conn;

        }
        
        public void OpenSQLConn()
        {
            if (SQLConn.conn.State != System.Data.ConnectionState.Open)
            {
                SQLConn.conn.Open();
                

            }
            
            
        }

        public void OpenSQLConn1()
        {
            if (SQLConn1.conn.State != System.Data.ConnectionState.Open)
            {
                SQLConn1.conn.Open();


            }


        }

        public void CloseSQLConn()
        {
            SQLConn.conn.Close();
        }
        public void CloseSQLConn1()
        {
            SQLConn1.conn.Close();
        }
        public SqlTransaction StartTrans()
        {
            SqlTransaction tran = SQLConn.conn.BeginTransaction();

            return tran;

        }

        public int ConvertToSkid(int coilTagID,string coilTagSuffix, SqlTransaction tran)
        {
            try
            {


                StringBuilder sb = new StringBuilder();

                sb.Append("insert into " + PlantLocation.city + ".skidData ");
                sb.Append("select distinct c.coiltagid,c.coiltagsuffix, ");
                sb.Append("iif(ascii(" + PlantLocation.city + ".GetMaxskid(c.coilTagID,c.coilTagSuffix))=32, 'A',char(ascii(" + PlantLocation.city + ".GetMaxskid(c.coilTagID,c.coilTagSuffix))+1)),");
                sb.Append("c.location,	c.alloyid, 	c.finishID,	c.customerID, ");
                sb.Append("	0,0,1,0,c.length,c.width,0,0,0,0,0,	c.coilCount, ");
                sb.Append("c.coilCount,-1,0,-1,'',1,1,40,-1 ");
                sb.Append("from " + PlantLocation.city + ".coil c where coiltagid = @tagID and coiltagSuffix = @suffix ");



                String sql = sb.ToString();

                SqlCommand cmd = new SqlCommand
                {

                    // Set connection for Command.
                    Connection = SQLConn.conn,
                    CommandText = sql,
                    Transaction = tran


                };
                cmd.Parameters.AddWithValue("@tagID", coilTagID);
                cmd.Parameters.AddWithValue("@suffix", coilTagSuffix);

                if (SQLConn.conn.State == ConnectionState.Closed)
                {
                    SQLConn.conn.Open();
                }

                cmd.ExecuteScalar();


                sb.Clear();

                sb.Append("update " + PlantLocation.city + ".coil set coilstatus = -2 where coiltagid = @tagid and coiltagsuffix = @suffix");

                sql = sb.ToString();

                cmd = new SqlCommand
                {

                    // Set connection for Command.
                    Connection = SQLConn.conn,
                    CommandText = sql,
                    Transaction = tran


                };
                cmd.Parameters.AddWithValue("@tagID", coilTagID);
                cmd.Parameters.AddWithValue("@suffix", coilTagSuffix);

                cmd.ExecuteScalar();
                return 1;
            }catch (Exception ex)
            {
                string test = ex.Message;
                return -1;
               
            }

        }


        public int InsertOrderTime(OrderTime ot, SqlTransaction tran)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("INSERT INTO " + PlantLocation.city + ".OrderTimes ");
            sb.Append("(orderID, sequenceNum, startDate, endDate) ");
            sb.Append("output INSERTED.orderID ");
            sb.Append("VALUES(@orderID, @sequenceNum, @startDate, @endDate) ");



            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran

            };




            cmd.Parameters.AddWithValue("@orderID", ot.orderID);
            cmd.Parameters.AddWithValue("@sequenceNum", ot.sequence);
            cmd.Parameters.AddWithValue("@startDate", ot.start);
            cmd.Parameters.AddWithValue("@endDate", ot.end);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }
            int orderID = (int)cmd.ExecuteScalar();

            return orderID;

        }

        public DbDataReader GetOrderTimes(int orderID,bool useSecondConnection = false)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT * from " + PlantLocation.city + ".OrderTimes ");
            sb.Append("WHERE OrderID = @orderID ");
            sb.Append("ORDER BY sequenceNum ");

            String sql = sb.ToString();
            SqlCommand cmd = new SqlCommand();
            
           
            if (useSecondConnection)
            {
                if (SQLConn1.conn.State != System.Data.ConnectionState.Open)
                {
                    SQLConn1.conn.Open();
                }
                cmd = new SqlCommand
                {

                    // Set connection for Command.
                    Connection = SQLConn1.conn,
                    CommandText = sql
                };
            }
            else
            {
                cmd = new SqlCommand
                {

                    // Set connection for Command.
                    Connection = SQLConn.conn,
                    CommandText = sql
                };
                if (SQLConn.conn.State == ConnectionState.Closed)
                {
                    SQLConn.conn.Open();
                }
            }

            
            

            cmd.Parameters.AddWithValue("@orderID", orderID);
            

            DbDataReader reader = cmd.ExecuteReader();

            return reader;

        }

        public DbDataReader getCoilPolishHistory(int coilTagID, string coilTagSuffix)
        {


            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT oh.status,oh.CustomerPO ,cp.orderid, pd.polishWeight,pd.coilTagNewSuffix, ");
            sb.Append("af1.FinishDesc as prevFinish, af2.FinishDesc  as newFinish,cp.polishWeight as pWeight,pd.polishWeight as nWEight ");
            sb.Append(",oh.orderDate, oh.promiseDate, oh.comments ");
            sb.Append("from " + PlantLocation.city + ".CoilPolishHdr cp, " + PlantLocation.city + ".CoilPolishDtl pd," + PlantLocation.city + ".Coil cl, ");
            sb.Append(PlantLocation.city + ".Alloy al, " + PlantLocation.city + ".AlloyFinish af1," + PlantLocation.city + ".AlloyFinish af2, ");
            sb.Append(PlantLocation.city + ".orderHdr oh ");
            sb.Append(" where cp.OrderID = pd.OrderID");
            sb.Append(" and cp.coilTagID = pd.coilTagID");
            sb.Append(" and cp.coilTagSuffix = pd.coilTagSuffix ");
            sb.Append(" and cp.CoilTagID = cl.coilTagID ");
            sb.Append(" and cp.coilTagSuffix = cl.coilTagSuffix");
            sb.Append(" and cl.AlloyID = al.AlloyID ");
            sb.Append(" and cp.previousFinish = af1.FinishID");
            sb.Append(" and pd.DTLfinishID = af2.FinishID");
            sb.Append(" and cp.coilTagID = @coilTagID");
            sb.Append(" and cp.coilTagSuffix = @coilTagSuffix");
            sb.Append(" and oh.orderID = cp.orderID");

            sb.Append(" order by cp.coilTagID, cp.coilTagSuffix");



            String sql = sb.ToString();
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql


            };
            cmd.Parameters.AddWithValue("@coilTagID", coilTagID);
            cmd.Parameters.AddWithValue("@coilTagSuffix", coilTagSuffix);
            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public DbDataReader GetClClDiffDetails(int orderID)
        {


            StringBuilder sb = new StringBuilder();
           

            sb.Append("SELECT *, csb.weight as nWeight, c.width as OGWidth,csw.Comments as SlitComments  ");

            sb.Append("from " + PlantLocation.city + ".CoilSlitOrderHdr csh, ");
            sb.Append(PlantLocation.city + ".CoilSlitOrderWidths csw, ");
            sb.Append(PlantLocation.city + ".CoilSlitOrderBreaks csb, ");
            sb.Append(PlantLocation.city + ".coil c, ");
            sb.Append(PlantLocation.city + ".Alloy a, ");
            sb.Append(PlantLocation.city + ".AlloyFinish af ");

            sb.Append("where csh.OrderID = csw.OrderID ");
            sb.Append("and csh.orderid = csb.orderid ");
            sb.Append("and csw.cutbreak = csb.cutbreak ");
            sb.Append("and csh.coilTagID = csb.coilTagID ");
            sb.Append("and csh.coilTagSuffix = csb.coilTagSuffix ");
            sb.Append("and csh.coilTagID = csw.coilTagID ");
            sb.Append("and csh.coilTagSuffix = csw.coilTagSuffix ");
            sb.Append("and c.coiltagid = csh.coiltagid ");
            sb.Append("and c.coilTagSuffix = csh.coilTagSuffix ");
            sb.Append("and c.alloyID = a.AlloyID ");
            sb.Append("and c.finishID = af.FinishID ");
            sb.Append("and csh.OrderID = @OrderID ");
            sb.Append("order by c.coilTagID, c.coilTagSuffix, csw.cutbreak, csw.newTagSuffix ");


            String sql = sb.ToString();
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql


            };
            cmd.Parameters.AddWithValue("@OrderID", orderID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public DbDataReader GetClClSameDetails(int orderID)
        {


            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT *,cp.polishWeight as pWeight,pd.polishWeight as nWEight, af2.FinishDesc as newFinishDesc ");

            sb.Append("from " + PlantLocation.city + ".CoilPolishHdr cp, " + PlantLocation.city + ".CoilPolishDtl pd," + PlantLocation.city + ".Coil cl, ");
            sb.Append(PlantLocation.city + ".Alloy al, " + PlantLocation.city + ".AlloyFinish af1," + PlantLocation.city + ".AlloyFinish af2 ");

            sb.Append(" where cp.OrderID = " + orderID.ToString());
            sb.Append(" and cp.OrderID = pd.OrderID");
            sb.Append(" and cp.coilTagID = pd.coilTagID");
            sb.Append(" and cp.coilTagSuffix = pd.coilTagSuffix ");
            sb.Append(" and cp.CoilTagID = cl.coilTagID ");
            sb.Append(" and cp.coilTagSuffix = cl.coilTagSuffix");
            sb.Append(" and cl.AlloyID = al.AlloyID ");
            sb.Append(" and cp.previousFinish = af1.FinishID");
            sb.Append(" and pd.DTLfinishID = af2.FinishID");

            sb.Append(" order by cp.coilTagID, cp.coilTagSuffix");


            String sql = sb.ToString();
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql


            };

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }
        public DbDataReader GetOrdersCustomer(int customerID)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("select distinct oh.orderID , ctl.coilTagID , ctl.coiltagsuffix ");
            sb.Append("from " + PlantLocation.city + ".orderhdr oh, " + PlantLocation.city + ".CTLDetail ctl ");
            sb.Append("where customerID = " + customerID.ToString() + " and oh.orderid = ctl.orderid and oh.status > 0");

            String sql = sb.ToString();
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql


            };

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public DbDataReader GetCoilCTLInfo(int coilID,string coilTagSuffix, int orderID, int status)
        {
            StringBuilder sb = new StringBuilder();
            if (status < 0)
            {
                sb.Append("SELECT * FROM " + PlantLocation.city + ".Coil c ");
                sb.Append("left join " + PlantLocation.city + ".CoilWorkOrderDtls cwd on (");
                sb.Append("cwd.orderID = " + orderID.ToString() + " and cwd.coiltagid = c.coilTagID and cwd.coilTagSuffix = c.coilTagSuffix ), ");
                sb.Append( PlantLocation.city + ".CoilWeightChange cw ");
                sb.Append(", " + PlantLocation.city + ".Alloy a, " +PlantLocation.city + ".AlloyFinish af ");
                sb.Append("where c.coilTagID = cw.coilTagID ");
                sb.Append("and c.coilTagSuffix = cw.coilTagSuffix ");
                sb.Append("and cw.referenceNumber = " + orderID.ToString());
                sb.Append(" and c.coilTagID = @coilID ");
            }
            else
            {
                sb.Append("SELECT * fROM " + PlantLocation.city + ".Coil c, " + PlantLocation.city + ".Alloy a, " +PlantLocation.city + ".AlloyFinish af ");
                sb.Append(" where c.coilTagID = @coilID ");
            }
            
            
            sb.Append("and c.coilTagSuffix = @coilTagSuffix ");
            sb.Append("and c.alloyID = a.alloyID ");
            sb.Append("and c.finishID = af.finishID");

            String sql = sb.ToString();
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql


            };
            cmd.Parameters.AddWithValue("@coilID", coilID);
            cmd.Parameters.AddWithValue("@coilTagSuffix", coilTagSuffix);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public DbDataReader GetShShSmProcPrice(int orderID)
        {

            StringBuilder sb = new StringBuilder();


            sb.Append("select oh.orderid, oh.procprice , " + PlantLocation.city + ".GetSkidWeight(sk.skidid, sk.coilTagSuffix, sk.letter) as skidWeight ");
            sb.Append(", round(((sk.length * sk.width)/144) * sk.pieceCount,0) as sqft, op.pvc, op.pvcprice , op.paper, op.paperprice,pg.groupname ");
            sb.Append("from " + PlantLocation.city + ".orderhdr oh, ");
            sb.Append(PlantLocation.city + ".OrderPolishDtl op left join " + PlantLocation.city + ".pvcgroup pg on op.pvc = pg.GroupID, ");
            sb.Append(PlantLocation.city + ".skiddata sk ");
            sb.Append("where oh.orderid = op.orderID ");
            sb.Append("and oh.orderid = @orderID ");
            sb.Append("and op.skidid = sk.skidid ");
            sb.Append("and op.coilTagSuffix = sk.coilTagSuffix ");
            sb.Append("and trim(op.skidLetter) + '.' + trim(op.orderLetter) = sk.letter ");



            String sql = sb.ToString();
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql


            };
            
            cmd.Parameters.AddWithValue("@orderID", orderID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public DbDataReader GetShShSameOperTagInfo(int orderID)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT c.thickness,");
            sb.Append("sd.width,sd.length,a.AlloyDesc,af.FinishDesc,");
            sb.Append("oh.orderid,c.heat,c.millCoilNum,cu.ShortCustomerName,");
            sb.Append("opd.orderPieceCount,opd.skidID,opd.coilTagSuffix,opd.skidLetter,");
            sb.Append("opd.orderLetter ");
            sb.Append("from " + PlantLocation.city + ".OrderPolishDtl opd,");
            sb.Append(PlantLocation.city + ".orderhdr oh,");
            sb.Append(PlantLocation.city + ".skiddata sd,");
            sb.Append(PlantLocation.city + ".coil c,");
            sb.Append(PlantLocation.city + ".alloy a,");
            sb.Append(PlantLocation.city + ".AlloyFinish af,");
            sb.Append(PlantLocation.city + ".Customer cu ");
            sb.Append("where oh.orderid = opd.orderid ");
            sb.Append("and oh.orderid = @orderID ");
            sb.Append("and sd.skidid = opd.skidid ");
            sb.Append("and sd.coilTagSuffix = opd.coilTagSuffix ");
            sb.Append("and sd.letter = opd.skidletter ");
            sb.Append("and c.coilTagID = sd.skidid ");
            sb.Append("and c.coiltagsuffix = sd.coilTagSuffix ");
            sb.Append("and a.alloyid = sd.alloyID ");
            sb.Append("and af.FinishID = opd.newFinishID ");
            sb.Append("and oh.CustomerID = cu.CustomerID ");

            String sql = sb.ToString();
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql


            };

            cmd.Parameters.AddWithValue("@orderID", orderID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;



        }

        public DbDataReader GetOperatorTagInfo(int orderID)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT *, " + PlantLocation.city + ".GetMaxSkid(cl.coilTagID, cl.coilTagSuffix) as MaxLetter ");
            sb.Append("from " + PlantLocation.city + ".CTLDetail cd, " + PlantLocation.city + ".Coil cl, " + PlantLocation.city + ".Alloy al, ");
            sb.Append(PlantLocation.city + ".AlloyFinish af, " + PlantLocation.city + ".orderHdr oh, " + PlantLocation.city + ".SteelType st, ");
            sb.Append(PlantLocation.city + ".customer cu ");
            sb.Append("where oh.orderID = cd.orderID ");
            sb.Append("and oh.OrderID = @orderID ");
            sb.Append("and cd.CoilTagID = cl.coilTagID ");
            sb.Append("and cd.coilTagSuffix = cl.coilTagSuffix ");
            sb.Append("and cd.AlloyID = al.AlloyID ");
            sb.Append("and cd.FinishID = af.FinishID ");
            sb.Append("and st.SteelTypeID = af.SteelTypeID ");
            sb.Append("and cu.customerID = oh.customerID ");
            sb.Append("order by cd.orderID ,cd.coilTagID, cd.coilTagSuffix, cd.sequenceNumber ");


            String sql = sb.ToString();
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql


            };
           
            cmd.Parameters.AddWithValue("@orderID", orderID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }


            DbDataReader reader = cmd.ExecuteReader();

            return reader;




        }
        public DbDataReader GetCTLDetails(int orderID, int coilTagID = -1, string coilTagSuffix = "", bool weightChange = false)
        {
            

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT *," + PlantLocation.city + ".GetMaxSkid(cl.coilTagID, cl.coilTagSuffix) as MaxLetter ");

            sb.Append("from " + PlantLocation.city + ".CTLDetail cd, " + PlantLocation.city + ".Coil cl ");
            if (weightChange)
            {
                sb.Append(" left outer join " + PlantLocation.city + ".CoilWeightChange cw on (cw.referenceNumber = " + orderID.ToString() + " and cw.coilTagID = cl.coilTagID and cw.coilTagSuffix = cl.coilTagSuffix) ");
            }
            sb.Append("," + PlantLocation.city + ".Alloy al, " + PlantLocation.city + ".AlloyFinish af ");
            if (coilTagID == -1)
            {
               
                sb.Append(" where OrderID = " + orderID.ToString());
                
            }
            else
            {
                sb.Append("," + PlantLocation.city + ".orderHdr oh where oh.orderID = cd.orderID");
                sb.Append(" and cl.coilTagID = @coilTagID");
                sb.Append(" and cl.coilTagSuffix = @coilTagSuffix");
            }
            
            sb.Append(" and cd.CoilTagID = cl.coilTagID ");
            sb.Append(" and cd.coilTagSuffix = cl.coilTagSuffix ");
            sb.Append(" and cd.AlloyID = al.AlloyID ");
            sb.Append(" and cd.FinishID = af.FinishID");

            sb.Append(" order by cd.orderID ,cd.coilTagID, cd.coilTagSuffix, cd.sequenceNumber");

            

            String sql = sb.ToString();
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
               
                
            };
            if (coilTagID != -1)
            {
                cmd.Parameters.AddWithValue("@coilTagID", coilTagID);
                cmd.Parameters.AddWithValue("@coilTagSuffix", coilTagSuffix);
            }

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }
        public int InsertBranchInfo(int custID, string ShortName, string LongName, bool firstRecord = false,SqlTransaction tran = null)
        {

            StringBuilder sb = new StringBuilder();

            if (firstRecord)
            {
                sb.Append("INSERT INTO " + PlantLocation.city + ".CustomerBranch ");
                sb.Append("(BranchID,customerID,BranchDescShort,BranchDescLong) ");
                sb.Append("output INSERTED.BranchID VALUES(0,@customerID,@BranchDescShort, @BranchDescLong)");
            }
            else
            {
                sb.Append("INSERT INTO " + PlantLocation.city + ".CustomerBranch ");
                sb.Append("(customerID,BranchDescShort,BranchDescLong) ");
                sb.Append("output INSERTED.BranchID VALUES(@customerID,@BranchDescShort, @BranchDescLong)");
            }
            



            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql


            };
            if (tran != null)
            {
                cmd.Transaction = tran; 
            }
            cmd.Parameters.AddWithValue("@customerID", custID);
            cmd.Parameters.AddWithValue("@BranchDescShort", ShortName);
            cmd.Parameters.AddWithValue("@BranchDescLong", LongName);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            int branchID = (int)cmd.ExecuteScalar();



            return branchID;
        }


        public DbDataReader GetBranchInfo(int custID, bool secondConn = false)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * from " + PlantLocation.city + ".CustomerBranch ");
            sb.Append("where customerID = " + custID);

            String sql = sb.ToString();
            

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                
                CommandText = sql
            };

            if (!secondConn)
            {
                cmd.Connection = SQLConn.conn;
                if (SQLConn.conn.State == ConnectionState.Closed)
                {
                    SQLConn.conn.Open();
                }
            }
            else
            {
                cmd.Connection = SQLConn1.conn;
                if (SQLConn1.conn.State == ConnectionState.Closed)
                {
                    SQLConn1.conn.Open();
                }
            }
            

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public int UpdateCustomerStatus(int custID, int status)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("update " + PlantLocation.city + ".Customer ");
            sb.Append("set isActive = @status ");
            sb.Append("where customerID = @custID");

            SqlCommand cmd = new SqlCommand();
            String sql = sb.ToString();


            cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@custID", custID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            custID = cmd.ExecuteNonQuery();

            return custID;
        }

        public int UpdatePVCGroupPrice(int groupID, decimal price)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("update " + PlantLocation.city + ".PVCGroup ");
            sb.Append("set price = @price ");
            sb.Append("where groupID = @groupID");

            SqlCommand cmd = new SqlCommand();
            String sql = sb.ToString();


            cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@groupID", groupID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            groupID = cmd.ExecuteNonQuery(); 

            return groupID;
        }
        public DbDataReader GetPVCGroup(int groupID = -1)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * ");

            sb.Append("from " + PlantLocation.city + ".PVCGroup ");
            sb.Append(" where active > 0");
            if (groupID != -1)
            {
                sb.Append(" and groupid = @groupID");
            }
            SqlCommand cmd = new SqlCommand();
            String sql = sb.ToString();
            
            
            cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            if (groupID != -1)
            {
                cmd.Parameters.AddWithValue("@groupID", groupID);
            }

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }
        public DbDataReader GetPVCRollInfo(int GroupID)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * ");

            sb.Append("from " + PlantLocation.city + ".PVCGroup pg, ");
            sb.Append(PlantLocation.city + ".PVCDescription pd, ");
            sb.Append(PlantLocation.city + ".PVCRollDtls pr ");
            sb.Append("where pg.GroupID = " + GroupID.ToString());
            sb.Append(" and pd.GroupID = pg.GroupID ");
            sb.Append("and pr.PVCTypeID = pd.PVCTypeID ");
            sb.Append("and pr.custID = 0 ");//0 is TSA Owned
            sb.Append("and pr.status > 0 ");

            SqlCommand cmd = new SqlCommand();
            String sql = sb.ToString();


            cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };


            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }


        public DbDataReader GetPVCInventory(int custID = 0)
        {
            StringBuilder sb = new StringBuilder();

            if (custID == 0)
            {
                sb.Append("SELECT pg.groupID,pg.GroupName,pr.PVCTAgid,pd.ItemDesc,pr.currentLength,pr.PVCWidth,pg.price ");
                sb.Append("From " + PlantLocation.city + ".PVCGroup PG, " + PlantLocation.city + ".PVCDescription pd, " + PlantLocation.city + ".PVCRollDtls pr ");
                sb.Append("where pd.GroupID = pg.GroupID ");
                sb.Append("and pr.PVCTypeID = pd.PVCTypeID ");
                sb.Append("and pr.custID = " + custID.ToString() + " ");
                sb.Append("and pr.status > 0 ");
                sb.Append("order by groupID, pr.PVCWidth, pr.PVCTagID");
            }
            else
            {

                //goign to have to think about this.
                sb.Append("select * from " + PlantLocation.city + ".PVCCustRollDtl, " + PlantLocation.city + ".PVCRollDtls ");

                sb.Append("where PVCCustRollDtl.PVCTagID = PVCRollDtls.PVCTagID ");
                sb.Append("and PVCRollDtls.Status > 0 ");
                sb.Append("and PVCRollDtls.CustID = " + custID.ToString());
            }


            SqlCommand cmd = new SqlCommand();
            String sql = sb.ToString();


            cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }


            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public int InsertPVCOrderInfo(int PVCRollID, int orderID, int seqNum, int linFootage, SqlTransaction tran)
        {

            StringBuilder sb = new StringBuilder();


            sb.Append("INSERT INTO " + PlantLocation.city + ".PVCOrderInfo ");
            sb.Append("(PVCTagID,OrderID,skidSeqNum,LinearFootage) ");
            sb.Append("output INSERTED.PVCTagID VALUES(@PVCTagID,@OrderID,@skidSeqNum,@LinearFootage)");



            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                
                Transaction = tran

            };
            cmd.Parameters.AddWithValue("@PVCTagID", PVCRollID);
            cmd.Parameters.AddWithValue("@OrderID", orderID);
            cmd.Parameters.AddWithValue("@skidSeqNum", seqNum);
            cmd.Parameters.AddWithValue("@LinearFootage", linFootage);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            int PVCtagID = (int)cmd.ExecuteScalar();



            return PVCtagID;
        }
        public int UpdatePVCRollStatus(int RollTagID, decimal statusID, string referenceNumber, SqlTransaction tran)
        {
            int orderCnt = -1;



            StringBuilder sb = new StringBuilder();

            sb.Append("update " + PlantLocation.city + ".PVCRollDtls ");
            sb.Append(" set ");
            sb.Append("status = @statusID,ReferenceNumber = @refNum ");
            sb.Append("where PVCTagID = @RollTagID");

            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran

            };

            cmd.Parameters.AddWithValue("@statusID", statusID);
            cmd.Parameters.AddWithValue("@refNum", referenceNumber);

            cmd.Parameters.AddWithValue("@RollTagID", RollTagID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            //returns record count affected
            orderCnt = (int)cmd.ExecuteNonQuery();



            return orderCnt;
        }

        public int UpdateOrderHdr(int OrderID, decimal statusID, SqlTransaction tran)
        {
            int orderCnt = -1;



            StringBuilder sb = new StringBuilder();

            sb.Append("update " + PlantLocation.city + ".OrderHdr ");
            sb.Append(" set ");
            sb.Append("Status = @statusID ");
            sb.Append("where OrderID = @OrderID");

            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran

            };

            cmd.Parameters.AddWithValue("@statusID", statusID);
          
            cmd.Parameters.AddWithValue("@OrderID", OrderID);

            //returns record count affected
            orderCnt = (int)cmd.ExecuteNonQuery();

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            return orderCnt;
        }

        public int UpdatePVCRollInfo(int RollTagID, decimal decWidth, int intLength, string strLoc,
                                    SqlTransaction tran, bool lengthOnly = false)
        {
            int orderCnt = -1;



            StringBuilder sb = new StringBuilder();

            if (lengthOnly)
            {
                sb.Append("update " + PlantLocation.city + ".PVCRollDtls ");
                sb.Append(" set ");
                sb.Append("currentLength = (currentLength - @intLength) ");
                sb.Append("where PVCTagID = @RollTagID");
            }
            else
            {
                sb.Append("update " + PlantLocation.city + ".PVCRollDtls ");
                sb.Append(" set ");
                sb.Append("PVCWidth = @decWidth, currentLength = (currentLength - @intLength), Location = @Location ");
                sb.Append("where PVCTagID = @RollTagID");
            }
            

            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran

            };

            if (!lengthOnly)
            {
                cmd.Parameters.AddWithValue("@Location", strLoc);
                cmd.Parameters.AddWithValue("@decWidth", decWidth);

            }

            cmd.Parameters.AddWithValue("@intLength", intLength);
            cmd.Parameters.AddWithValue("@RollTagID", RollTagID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            //returns record count affected
            orderCnt = (int)cmd.ExecuteNonQuery();



            return orderCnt;
        }

        public int InsertCoilDamage(int coilTagID, int damageID, SqlTransaction tran)
        {
            int damID = -1;



            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + PlantLocation.city + ".CoilDamage ");
            sb.Append("(coilTagID,damageDescID) ");
            sb.Append("output INSERTED.coilTagID VALUES(@coilTagID, @damageDescID)");
            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Parameters.AddWithValue("@coilTagID", coilTagID);
            cmd.Parameters.AddWithValue("@damageDescID", damageID);
            cmd.Transaction = tran;

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            damID = (int)cmd.ExecuteScalar();



            return damID;
        }
        public void DeleteCoilDamage(int coilTagID, SqlTransaction tran)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from " + PlantLocation.city + ".CoilDamage ");

            sb.Append("where CoilTagID = @coilTagID");



            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Parameters.AddWithValue("@coilTagID", coilTagID);

            cmd.Transaction = tran;


            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            cmd.ExecuteNonQuery();


        }

        public DbDataReader GetCoilDamage(int CoilTagID, bool useConn1 = false, SqlTransaction tran = null)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * ");

            sb.Append("from " + PlantLocation.city + ".Coil c, ");
            sb.Append(PlantLocation.city + ".coilDamage cd, ");
            sb.Append(PlantLocation.city + ".DamageDescription dd ");
            sb.Append("where c.CoilTagID = " + CoilTagID.ToString());
            sb.Append(" and c.CoilTagID = cd.CoilTagID ");
            sb.Append("and cd.damageDescID = dd.damageDescID ");
            sb.Append("order by cd.damageDescID");

            SqlCommand cmd = new SqlCommand();
            String sql = sb.ToString();

            if (useConn1)
            {
                cmd = new SqlCommand
                {

                    // Set connection for Command.

                    Connection = SQLConn1.conn,
                    CommandText = sql
                };
            }
            else
            {
                cmd = new SqlCommand
                {

                    // Set connection for Command.

                    Connection = SQLConn.conn,
                    CommandText = sql
                };
            }
            if (tran != null)
            {
                cmd.Transaction = tran;
            }


            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public int InsertCoilWorkOrderDtls(int coilTagID, string coilTagSuffix, int orderID, int scrapAmount, 
                                            string scrapUnit, string rejectReason, decimal lbsPerInch, SqlTransaction tran)
        {
            int orderCnt = -1;


            StringBuilder sb = new StringBuilder();


            sb.Append("INSERT INTO " + PlantLocation.city + ".CoilWorkOrderDtls ");
            sb.Append("(OrderID,coilTagID,coilTagSuffix,scrapAmount,scrapUnit, rejectReason, lbsPerInch) ");
            sb.Append("output INSERTED.OrderID VALUES(@OrderID,@coilTagID,@coilTagSuffix,@scrapAmount,@scrapUnit, @rejectReason, @lbsPerInch)");


            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran

            };
           

            cmd.Parameters.AddWithValue("@OrderID", orderID );
            cmd.Parameters.AddWithValue("@coilTagID", coilTagID );
            cmd.Parameters.AddWithValue("@coilTagSuffix", coilTagSuffix );
            cmd.Parameters.AddWithValue("@scrapAmount", scrapAmount);
            cmd.Parameters.AddWithValue("@scrapUnit", scrapUnit );
            cmd.Parameters.AddWithValue("@rejectReason", rejectReason);
            cmd.Parameters.AddWithValue("@lbsPerInch", lbsPerInch);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            //returns record count affected
            orderCnt = (int)cmd.ExecuteNonQuery();



            return orderCnt;
        }

        public DbDataReader GetCoilWeightChange(int coilTagID, string coilTagSuffix, int orderID = -1)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * ");

            sb.Append("from " + PlantLocation.city + ".coilWeightChange c ");
            if (orderID == -1)
            {
                sb.Append("where coiltagiD = @coilTagID ");
                sb.Append("and coilTagSuffix = @coilTagSuffix ");
            }
            else
            {
                sb.Append("where referenceNumber = @orderID ");
            }

            sb.Append("order by coilTagID, coilTagSuffix ");

            SqlCommand cmd = new SqlCommand();
            String sql = sb.ToString();


            cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };
            if (orderID == -1)
            {
                cmd.Parameters.AddWithValue("@coilTagID", coilTagID);
                cmd.Parameters.AddWithValue("@coilTagSuffix", coilTagSuffix);

            }else
            {
                cmd.Parameters.AddWithValue("@orderID", orderID);
            }

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;


        }

        public int InsertCoilWeightChange(int coilTagID, string coilTagSuffix, int orderID, int prevWeight, int currWeight, SqlTransaction tran)
        {
            int orderCnt = -1;


            StringBuilder sb = new StringBuilder();


            sb.Append("INSERT INTO " + PlantLocation.city + ".CoilWeightChange ");
            sb.Append("(coilTagID,coilTagSuffix,referenceNumber,changeDate, previousWeight, currentWeight, Comments) ");
            sb.Append("output INSERTED.coilTagID VALUES(@coilTagID,@coilTagSuffix,@referenceNumber,@changeDate, @previousWeight, @currentWeight, @Comments)");


            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran


            };

            
            
            cmd.Parameters.AddWithValue("@coilTagID", coilTagID);
            cmd.Parameters.AddWithValue("@coilTagSuffix", coilTagSuffix);

            cmd.Parameters.AddWithValue("@referenceNumber", orderID);
            cmd.Parameters.AddWithValue("@changeDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@previousWeight", prevWeight);
            cmd.Parameters.AddWithValue("@currentWeight", currWeight);
            cmd.Parameters.AddWithValue("@Comments", "Work Order " + orderID);
            //returns record count affected
            orderCnt = (int)cmd.ExecuteNonQuery();
            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }


            return orderCnt;
        }

        public int UpdateCoilCust(int coilTagID, string coilTagSuffix,int newCustID, SqlTransaction tran)
        {
            
            StringBuilder sb = new StringBuilder();

            sb.Append("update " + PlantLocation.city + ".Coil ");
            sb.Append(" set ");
            sb.Append("customerID = @custID ");

            
            sb.Append("where coilTagID = @coilTagID and coilTagSuffix = @coilTagSuffix");

            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran

            };


            cmd.Parameters.AddWithValue("@custID", newCustID );
            cmd.Parameters.AddWithValue("@coilTagID", coilTagID);
            cmd.Parameters.AddWithValue("@coilTagSuffix", coilTagSuffix);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            //returns record count affected
            int updateCnt = (int)cmd.ExecuteNonQuery();



            return updateCnt;
        }

        public int UpdateCoilWeight(int coilTagID, string coilTagSuffix, int newWeight, string location, SqlTransaction tran)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("update " + PlantLocation.city + ".Coil ");
            sb.Append(" set ");
            sb.Append("weight = @newWeight, coilStatus = @status ");
            
            if (location.Length > 0)
            {
                sb.Append(", location = @location ");
            }
            


            sb.Append("where coilTagID = @coilTagID and coilTagSuffix = @coilTagSuffix");

            String sql = sb.ToString();

            int status = -1;
            if (newWeight > 0)
            {
                status = 1;
            }

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran

            };


            cmd.Parameters.AddWithValue("@newWeight", newWeight);
            cmd.Parameters.AddWithValue("@status", status);
            
            cmd.Parameters.AddWithValue("@coilTagID", coilTagID);
            cmd.Parameters.AddWithValue("@coilTagSuffix", coilTagSuffix);

            if (location.Length > 0)
            {
                cmd.Parameters.AddWithValue("@location", location);
            }

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            //returns record count affected
            int updateCnt = (int)cmd.ExecuteNonQuery();



            return updateCnt;
        }


        public void updateCoilWeightChange(int coilTagID, string coilTagSuffix,int orderID, int newWeight, SqlTransaction tran)
        {


            StringBuilder sb = new StringBuilder();

            sb.Append("update " + PlantLocation.city + ".CoilWeightChange ");
            sb.Append(" set ");
            sb.Append("currentWeight = @newWeight ");
            sb.Append("where coilTagID = @coilTagID and coilTagSuffix = @coilTagSuffix ");
            sb.Append("and referenceNumber = @orderID ");

            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran

            };


            cmd.Parameters.AddWithValue("@newWeight", newWeight);
            cmd.Parameters.AddWithValue("@coilTagID", coilTagID);
            cmd.Parameters.AddWithValue("@coilTagSuffix", coilTagSuffix);
            cmd.Parameters.AddWithValue("@orderID", orderID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            //returns record count affected
            cmd.ExecuteNonQuery();




        }

        public void updateCoilThickness(int coilTagID, string coilTagSuffix, decimal thickness,string millCoilNum, string heat)
        {
            

            StringBuilder sb = new StringBuilder();

            sb.Append("update " + PlantLocation.city + ".Coil ");
            sb.Append(" set ");
            sb.Append("thickness = @thickness, heat = @heat, millCoilNum = @millCoilNum ");
            sb.Append("where coilTagID = @coilTagID and coilTagSuffix = @coilTagSuffix");

            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                

            };


            cmd.Parameters.AddWithValue("@thickness", thickness);
            cmd.Parameters.AddWithValue("@millCoilNum", millCoilNum);
            cmd.Parameters.AddWithValue("@heat", heat);
            cmd.Parameters.AddWithValue("@coilTagID", coilTagID);
            cmd.Parameters.AddWithValue("@coilTagSuffix", coilTagSuffix);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            //returns record count affected
            cmd.ExecuteNonQuery();



            
        }

        public int UpdateCoil(int coilTagID, string coilTagSuffix, int weight, string coilLoc, int status, bool reject, SqlTransaction tran,int finishid = -99, string newCoilSuffix = "NOPE")
        {
            int updateCnt = -1;
            int coilReject = 0;
            if (reject)
            {
                coilReject = 1;
            }

            StringBuilder sb = new StringBuilder();

            sb.Append("update " + PlantLocation.city + ".Coil ");
            sb.Append(" set ");
            if (finishid != -99)
            {
                sb.Append("reject = @reject,weight = @weight, finishID = @finishid ");
                if (!newCoilSuffix.Equals("NOPE"))
                {
                    sb.Append(",coilTagSuffix = @newCoilTagSuffix ");
                }
            }
            else
            {
                sb.Append("reject = @reject, weight = @weight, coilStatus = @status, location = @location ");

            }
            sb.Append("where coilTagID = @coilTagID and coilTagSuffix = @coilTagSuffix");

            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran

            };


            if (finishid != -99)
            {
                cmd.Parameters.AddWithValue("@reject", coilReject);
                cmd.Parameters.AddWithValue("@weight", weight);
                cmd.Parameters.AddWithValue("@finishid", finishid);
            }
            else
            {
                cmd.Parameters.AddWithValue("@reject", coilReject);
                cmd.Parameters.AddWithValue("@weight", weight);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@location", coilLoc);
            }
            if (!newCoilSuffix.Equals("NOPE"))
            {
                
                cmd.Parameters.AddWithValue("@newCoilTagSuffix", newCoilSuffix);
            }
            cmd.Parameters.AddWithValue("@coilTagID", coilTagID);
            cmd.Parameters.AddWithValue("@coilTagSuffix", coilTagSuffix);


            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            //returns record count affected
            updateCnt = (int)cmd.ExecuteNonQuery();



            return updateCnt;
        }

        public int UpdateShipHdr(ShipHdrInfo sh, SqlTransaction tran)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("update " + PlantLocation.city + ".shipHdr ");
            sb.Append(" set [releaseNUM] = @releaseNUM,[releaseDate] =@releaseDate,[carrierName] = @carrierName");
            sb.Append(",[destination] = @destination,[city] = @city,[state] = @state,[route] = @route,[deliveryCarrier] = @deliveryCarrier ");
            sb.Append(",[shipAgent] = @shipAgent,[shipAddress] = @shipAddress,[consignedTo] = @consignedTo,[street] = @street");
            sb.Append(",[county] = @county,[zip] =  @zip,[deliveryAddress] = @deliveryAddress,[tractorNum] = @tractorNum,[trailerNum] = @trailerNum");
            sb.Append(",[shipPerson] = @shipPerson,[prepaidCollect] = @prepaidCollect ");
            sb.Append(" where shipid = @shipid ");
            
           
            String sql = sb.ToString();


            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran

            };

            cmd.Parameters.AddWithValue("@shipid", sh.ShipID);
            
            cmd.Parameters.AddWithValue("@releaseNUM", sh.ReleaseNum);
            cmd.Parameters.AddWithValue("@releaseDate", sh.ReleaseDate);
            cmd.Parameters.AddWithValue("@carrierName", sh.Carrier);
            cmd.Parameters.AddWithValue("@destination", sh.Destination);
            cmd.Parameters.AddWithValue("@city", sh.City);

            cmd.Parameters.AddWithValue("@state", sh.State);
            cmd.Parameters.AddWithValue("@route", sh.Route);
            cmd.Parameters.AddWithValue("@deliveryCarrier", sh.DeliveryCarrier);
            cmd.Parameters.AddWithValue("@shipAgent", sh.ShipAgent);
            cmd.Parameters.AddWithValue("@shipAddress", sh.ShipAddress);
            cmd.Parameters.AddWithValue("@consignedTo", sh.ConsignedTo);

            cmd.Parameters.AddWithValue("@street", sh.Street);
            cmd.Parameters.AddWithValue("@county", sh.County);
            cmd.Parameters.AddWithValue("@zip", sh.Zip);
            cmd.Parameters.AddWithValue("@deliveryAddress", sh.DeliveryAddress);
            cmd.Parameters.AddWithValue("@tractorNum", sh.TractorNum);
            cmd.Parameters.AddWithValue("@trailerNum", sh.TrailerNum);

            cmd.Parameters.AddWithValue("@shipPerson", sh.ShipPerson);
            cmd.Parameters.AddWithValue("@prepaidCollect", sh.PrepaidCollect);


            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            int ShipID = (int)cmd.ExecuteNonQuery();

            return ShipID;

        }

        public int InsertShipHdr(ShipHdrInfo sh, SqlTransaction tran)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("INSERT INTO " + PlantLocation.city + ".shipHdr ");
            sb.Append("([customerID],[releaseNUM],[releaseDate],[carrierName]");
            sb.Append(",[destination],[city],[state],[route],[deliveryCarrier]");
            sb.Append(",[shipAgent],[shipAddress],[consignedTo],[street]");
            sb.Append(",[county],[zip],[deliveryAddress],[tractorNum],[trailerNum]");
            sb.Append(",[shipPerson],[prepaidCollect],[status],[branch])");
            sb.Append(" output INSERTED.shipID VALUES ");
            sb.Append("(@customerID, @releaseNUM, @releaseDate, @carrierName, @destination, ");
            sb.Append("@city, @state, @route, @deliveryCarrier, @shipAgent, @shipAddress, ");
            sb.Append("@consignedTo, @street, @county, @zip, @deliveryAddress, @tractorNum, ");
            sb.Append("@trailerNum, @shipPerson, @prepaidCollect,@status,@branch)");

            String sql = sb.ToString();


            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran

            };

           
            cmd.Parameters.AddWithValue("@customerID", sh.CustomerID);
            cmd.Parameters.AddWithValue("@releaseNUM", sh.ReleaseNum);
            cmd.Parameters.AddWithValue("@releaseDate", sh.ReleaseDate );
            cmd.Parameters.AddWithValue("@carrierName", sh.Carrier);
            cmd.Parameters.AddWithValue("@destination", sh.Destination);
            cmd.Parameters.AddWithValue("@city", sh.City);

            cmd.Parameters.AddWithValue("@state", sh.State);
            cmd.Parameters.AddWithValue("@route", sh.Route);
            cmd.Parameters.AddWithValue("@deliveryCarrier", sh.DeliveryCarrier);
            cmd.Parameters.AddWithValue("@shipAgent", sh.ShipAgent);
            cmd.Parameters.AddWithValue("@shipAddress", sh.ShipAddress);
            cmd.Parameters.AddWithValue("@consignedTo", sh.ConsignedTo);

            cmd.Parameters.AddWithValue("@street", sh.Street);
            cmd.Parameters.AddWithValue("@county", sh.County);
            cmd.Parameters.AddWithValue("@zip", sh.Zip);
            cmd.Parameters.AddWithValue("@deliveryAddress", sh.DeliveryAddress);
            cmd.Parameters.AddWithValue("@tractorNum", sh.TractorNum);
            cmd.Parameters.AddWithValue("@trailerNum", sh.TrailerNum);

            cmd.Parameters.AddWithValue("@shipPerson", sh.ShipPerson);
            cmd.Parameters.AddWithValue("@prepaidCollect", sh.PrepaidCollect);
            cmd.Parameters.AddWithValue("@status", sh.Status);
            cmd.Parameters.AddWithValue("@branch", sh.Branch);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            int ShipID = (int)cmd.ExecuteScalar();

            return ShipID;

        }

        public void DeleteCTLAdders(int OrderID, SqlTransaction tran)
        {



            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from " + PlantLocation.city + ".CTLAdderPricing ");

            sb.Append("where orderID = " + OrderID.ToString());



            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Transaction = tran;

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            cmd.ExecuteNonQuery();




        }

        public int DeleteCTLDetail(int orderID, SqlTransaction tran)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("Delete from " + PlantLocation.city + ".CTLDetail ");
            sb.Append("where orderID = @orderID");

            String sql = sb.ToString();


            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran

            };


            cmd.Parameters.AddWithValue("@orderID", orderID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }


            int OrdID = (int)cmd.ExecuteNonQuery();

            return OrdID;

        }

        public int DeleteShipDtl(int shipID, SqlTransaction tran, int id = -1, string coilTagSuffix ="", string letter = "")
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("Delete from " + PlantLocation.city + ".shipDtl ");
            sb.Append("where shipID = @shipID ");

            if (id > 0)
            {
                sb.Append("and id = @id ");
                sb.Append("and coilTagSuffix = @coilTagSuffix ");
                sb.Append("and letter = @letter ");
            }


            String sql = sb.ToString();


            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran

            };


            cmd.Parameters.AddWithValue("@shipID", shipID);
            if (id > 0)
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@coilTagSuffix", coilTagSuffix);
                cmd.Parameters.AddWithValue("@letter", letter);
            }
            
            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }


            int ShipID = (int)cmd.ExecuteNonQuery();

            return ShipID;

        }

        public int InsertShipDtl(ShipDtlInfo sh, SqlTransaction tran)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("INSERT INTO " + PlantLocation.city + ".shipDtl ");
            sb.Append("([shipID],[id],[coilTagSuffix],[letter],[type],[status],[weight],[dateModified],[custPO])");
            sb.Append(" output INSERTED.shipID VALUES ");
            sb.Append("(@shipID, @id, @coilTagSuffix, @letter, @type, ");
            sb.Append("@status, @weight, @dateModified, @customerPO)");

            String sql = sb.ToString();


            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran

            };


            cmd.Parameters.AddWithValue("@shipID", sh.ShipID);
            cmd.Parameters.AddWithValue("@id", sh.Id);
            cmd.Parameters.AddWithValue("@coilTagSuffix", sh.CoilTagSuffix);
            cmd.Parameters.AddWithValue("@letter", sh.Letter );
            cmd.Parameters.AddWithValue("@type", sh.Type );
            cmd.Parameters.AddWithValue("@status", sh.Status);
            cmd.Parameters.AddWithValue("@weight", sh.Weight);
            cmd.Parameters.AddWithValue("@dateModified", sh.DateModified);
            cmd.Parameters.AddWithValue("@customerPO", sh.CustomerPO);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            int ShipID = (int)cmd.ExecuteScalar();

            return ShipID;

        }

        public int UpdateCoilStatus(int coilTagID, string coilTagSuffix,  int status, SqlTransaction tran)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("update " + PlantLocation.city + ".coil ");
            sb.Append("set coilStatus = @status ");
            sb.Append("where coilTagID = @id ");
            sb.Append("and coilTagSuffix = @coilTagSuffix ");
            

            String sql = sb.ToString();


            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran

            };


            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@id", coilTagID);
            cmd.Parameters.AddWithValue("@coilTagSuffix", coilTagSuffix);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            int cnt = (int)cmd.ExecuteNonQuery();

            return cnt;

        }
        public int UpdateSkidStatus(int skidID, string coilTagSuffix, string skidLetter, int status, SqlTransaction tran)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("update " + PlantLocation.city + ".SkidData ");
            sb.Append("set skidStatus = @status ");
            sb.Append("where skidID = @id ");
            sb.Append("and coilTagSuffix = @coilTagSuffix ");
            sb.Append("and letter = @letter ");
            //if (status > 0)
            //{
            //    sb.Append("and skidStatus > 0 ");
            //}
            
            String sql = sb.ToString();


            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran

            };


            cmd.Parameters.AddWithValue("@status", status);
            
            cmd.Parameters.AddWithValue("@id", skidID);
            cmd.Parameters.AddWithValue("@coilTagSuffix", coilTagSuffix);
            cmd.Parameters.AddWithValue("@letter", skidLetter);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }
            

            int cnt = (int)cmd.ExecuteNonQuery();

            return cnt;

        }

        public int UpdateShipHdrStatus(int shipID,  int status, SqlTransaction tran)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("update " + PlantLocation.city + ".ShipHdr ");
            sb.Append("set status = @status ");
            sb.Append("where shipID = @shipId ");
            
            String sql = sb.ToString();


            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran

            };


            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@shipid", shipID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            int cnt = (int)cmd.ExecuteNonQuery();

            return cnt;

        }

        public int UpdateShipDtlStatus(int shipID, int status, SqlTransaction tran)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("update " + PlantLocation.city + ".ShipDtl ");
            sb.Append("set status = @status ");
            sb.Append("where shipID = @shipId ");

            String sql = sb.ToString();


            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran

            };


            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@shipid", shipID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            int cnt = (int)cmd.ExecuteNonQuery();

            return cnt;

        }

        public int UpdateShipSkidStatus(int shipID, int status, SqlTransaction tran)
        {

            StringBuilder sb = new StringBuilder();
            

                                                  
            sb.Append("update " + PlantLocation.city + ".skiddata ");
            sb.Append("set skidstatus = @status from " + PlantLocation.city + ".skiddata sd " );
            sb.Append("inner join " + PlantLocation.city + ".shipdtl shd on  shd.shipID = @shipId ");
            sb.Append("and shd.type = 1 and shd.id = sd.skidid ");
            sb.Append("and shd.coilTagSuffix = sd.coilTagSuffix and shd.letter = sd.letter");
            String sql = sb.ToString();


            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran

            };


            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@shipid", shipID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            int cnt = (int)cmd.ExecuteNonQuery();

            return cnt;

        }
        public int UpdateShipCoilStatus(int shipID, int status, SqlTransaction tran)
        {

            StringBuilder sb = new StringBuilder();



            sb.Append("update " + PlantLocation.city + ".coil ");
            sb.Append("set coilstatus = @status from " + PlantLocation.city + ".coil cl ");
            sb.Append("inner join " + PlantLocation.city + ".shipdtl shd on  shd.shipID = @shipId ");
            sb.Append("and shd.type = 0 and shd.id = cl.coilTagID ");
            sb.Append("and shd.coilTagSuffix = cl.coilTagSuffix");
            String sql = sb.ToString();


            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran

            };


            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@shipid", shipID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            int cnt = (int)cmd.ExecuteNonQuery();

            return cnt;

        }

        public DbDataReader GetShipHdrByCustomer(int customerID, bool ignoreTruck = true)
        {

            StringBuilder sb = new StringBuilder();
            if (ignoreTruck)
            {
                sb.Append("Select * from " + PlantLocation.city + ".shiphdr where customerID = " + customerID.ToString());
                sb.Append(" and status > 0");
            }
            else
            {
                sb.Append("Select * from " + PlantLocation.city + ".shiphdr where customerID = " + customerID.ToString());
                sb.Append(" and status > 0");
                sb.Append(" and shipID not in (select shipID from " + PlantLocation.city + ".truckload)");
            }


            string sql = sb.ToString();
            SqlCommand cmd = new SqlCommand
            {
                Connection = SQLConn.conn,
                CommandText = sql
            };

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;



        }

        public DbDataReader GetShipCoilDtls(int shipID, bool withCust = false, int checkstatus = -99)
        {


            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * ");
            if (withCust)
            {
                sb.Append(", cu.City as CUCITY,cu.zip as CUZIP,sh.City as SHCITY, sh.zip as SHZIP ");
            }
            sb.Append("from " + PlantLocation.city + ".shiphdr sh, ");
            sb.Append( PlantLocation.city + ".shipdtl sd," + PlantLocation.city + ".Coil cl, ");
            sb.Append(PlantLocation.city + ".alloy al," + PlantLocation.city + ".AlloyFinish af ");
            if (withCust)
            {
                sb.Append(", " + PlantLocation.city + ".Customer cu ");

            }
            sb.Append(" where sh.shipid = " + shipID.ToString());
            if (checkstatus > 0)
            {
                sb.Append(" and sh.status > 0 ");
            }
            else
            {
                if (checkstatus != -99)
                {
                    sb.Append(" and sh.status < 0 ");
                }
            }
           
            sb.Append(" and sh.shipid = sd.shipid ");
            sb.Append(" and cl.coilTagID = sd.id ");
            sb.Append(" and cl.coilTagSuffix = sd.coilTagSuffix ");
            sb.Append(" and sd.type = 0 ");
            sb.Append(" and al.alloyID = cl.alloyID ");
            sb.Append(" and af.finishID = cl.finishID ");
            if (withCust)
            {
                sb.Append(" and sh.customerID = cu.customerID ");
               


            }
            sb.Append(" order by cl.coilTagID, cl.coilTagSuffix");
            

            String sql = sb.ToString();
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql


            };
            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }


            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public DbDataReader getShipHistory(int coilTagID)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("select *,sh.status as hdrStatus from " + PlantLocation.city + ".shipdtl sd, ");
            sb.Append(PlantLocation.city + ".shiphdr sh, " + PlantLocation.city + ".customer c ") ;

            sb.Append("where sh.shipid = sd.shipid ");
            sb.Append("and sd.shipid in (select shipid from " + PlantLocation.city + ".shipdtl where id = @coilTagID) ");
            sb.Append("and c.customerID = sh.customerID ");
            sb.Append("order by sd.shipid, sd.type, sd.id,sd.coilTagSuffix,sd.letter ");

            String sql = sb.ToString();
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql


            };

            cmd.Parameters.AddWithValue("@coilTagID", coilTagID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public DbDataReader GetShipSkidlDtls(int shipID,bool withCust = false, int checkstatus = -99)
        {


            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT * "); 
            if (withCust)
            {
                sb.Append(", cu.City as CUCITY,cu.zip as CUZIP,sh.City as SHCITY, sh.zip as SHZIP ");
            }
            sb.Append("from " + PlantLocation.city + ".shiphdr sh, ");
            sb.Append(PlantLocation.city + ".shipdtl sd," + PlantLocation.city + ".skidData skd, ");
            sb.Append(PlantLocation.city + ".alloy al," + PlantLocation.city + ".AlloyFinish af ");
            if (withCust)
            {
                sb.Append(", " + PlantLocation.city + ".Customer cu, " + PlantLocation.city + ".coil ");
                
            }

            sb.Append(" where sh.shipid = " + shipID.ToString());
            if (checkstatus > 0)
            {
                sb.Append(" and sh.status > 0 ");
            }
            else
            {
                if (checkstatus != -99)
                {
                    sb.Append(" and sh.status < 0 ");
                }
            }

            sb.Append(" and sh.shipid = sd.shipid ");
            sb.Append(" and skd.skidID = sd.id ");
            sb.Append(" and skd.coilTagSuffix = sd.coilTagSuffix ");
            sb.Append(" and sd.type = 1 ");
            sb.Append(" and al.alloyID = skd.alloyID ");
            sb.Append(" and af.finishID = skd.finishID ");
            sb.Append(" and skd.letter = sd.letter ");
            if (withCust)
            {
                sb.Append(" and sh.customerID = cu.customerID ");
                sb.Append(" and coil.coilTagID = skd.skidID ");
                sb.Append(" and coil.coilTagSuffix = skd.coilTagSuffix ");
                

            }
            sb.Append(" order by skd.skidID, skd.coilTagSuffix, skd.letter");


            String sql = sb.ToString();
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql


            };

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public void UndoCoilSkidStatus(int bolNumber, SqlTransaction tran)
        {
            UpdateShipSkidStatus(bolNumber, 1, tran);

            UpdateShipCoilStatus(bolNumber, 1, tran);

            
        }

        public DbDataReader getShipInfo(int shipID)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("select * from " + PlantLocation.city + ".shiphdr sh, ");
            sb.Append(PlantLocation.city + ".shipdtl sd, " + PlantLocation.city + ".customer c ");
            sb.Append(" where sh.shipID = @shipID ");
            sb.Append("and sh.shipID = sd.shipID ");
            sb.Append("and c.CustomerID = sh.customerID ");
            sb.Append("order by sh.shipID,sd.type,sd.id,sd.letter ");

            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            cmd.Parameters.AddWithValue("@shipID", shipID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;

        }
        public int GetShipCust(int shipID)
        {


            string sql = "select customerID from " + PlantLocation.city + ".shiphdr where shipID = " + shipID.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int custID = reader.GetInt32(reader.GetOrdinal("customerID"));
                        return custID;
                    }
                    
                }
            }

            return -1;
        }
        public int InsertTruckLoad(int loadid, int shipID, DateTime dt, int status, SqlTransaction tran)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("INSERT INTO " + PlantLocation.city + ".TruckLoad ");
            if (loadid == 0)
            {
                sb.Append("([shipID],[modDate],[status])");
                sb.Append(" output INSERTED.LoadID VALUES ");
                sb.Append("(@shipID, @modDate, @status)");
            }
            else
            {
                sb.Append("([loadID],[shipID],[modDate],[status])");
                sb.Append(" output INSERTED.LoadID VALUES ");
                sb.Append("(@loadid,@shipID, @modDate, @status)");
            }
            
            

            String sql = sb.ToString();


            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran

            };

            if (loadid != 0)
            {
                cmd.Parameters.AddWithValue("@loadid", loadid);
            
            }
            cmd.Parameters.AddWithValue("@shipID", shipID);
            cmd.Parameters.AddWithValue("@modDate", dt);
            cmd.Parameters.AddWithValue("@status", status);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            int LoadID = (int)cmd.ExecuteScalar();
            return LoadID;

        }

        public DbDataReader GetFixAddRecDamage(int receiveID)
        {


            StringBuilder sb = new StringBuilder();

            sb.Append("select * from " + PlantLocation.city + ".receiveDtl where receiveID = @receiveID");


            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            cmd.Parameters.AddWithValue("@receiveID", receiveID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }


        public DbDataReader GetSkidReceiveData(int receiveID)
        {


            StringBuilder sb = new StringBuilder();

            sb.Append("select *, rd.purchaseOrder as dtlPO from " + PlantLocation.city + ".receiveHdr rh, " + PlantLocation.city);
            sb.Append(".receiveDtl rd, " + PlantLocation.city + ".coil c,");
            sb.Append(PlantLocation.city + ".Alloy a, " + PlantLocation.city + ".AlloyFinish af, ");
            sb.Append(PlantLocation.city + ".Customer cu, " + PlantLocation.city + ".skidData sd, ");
            sb.Append(PlantLocation.city + ".SteelType st ");
            sb.Append("where rh.receiveID = rd.receiveID ");
            sb.Append("and rh.receiveID = " + receiveID.ToString());
            sb.Append(" and rd.type = 0 ");
            sb.Append("and rd.coilTagID = c.coilTagID ");
            sb.Append("and c.alloyid = a.AlloyID ");
            sb.Append("and c.finishID = af.FinishID ");
            sb.Append("and rh.custID = cu.CustomerID ");
            sb.Append("and rd.coilTagID = sd.skidID ");
            sb.Append("and rd.skidLetter = sd.letter ");
            sb.Append("and a.SteelTypeID = st.SteelTypeID ");
            sb.Append("order by sd.skidID ");


            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }
        


        public DbDataReader GetCoilReceiveData(int receiveID,int coilTagID = -1)
        {


            StringBuilder sb = new StringBuilder();
            sb.Append("select *, rd.weight as origWeight, c.weight as currWeight, rd.purchaseOrder as dtlPO,cu2.shortCustomerName as coilCust ");
            sb.Append("from " + PlantLocation.city + ".receiveHdr rh, " + PlantLocation.city + ".receiveDtl rd,");
            sb.Append(PlantLocation.city + ".Coil c, " + PlantLocation.city + ".Alloy a, " + PlantLocation.city + ".AlloyFinish af, ");
            sb.Append(PlantLocation.city + ".SteelType st," + PlantLocation.city + ".Customer cu1, " + PlantLocation.city + ".customer cu2 ");
            sb.Append("where rh.receiveID = rd.receiveID ");
            if (coilTagID == -1)
            {
                sb.Append("and rh.receiveID = " + receiveID.ToString());
            }
            else
            {
                sb.Append("and c.coilTagID = " + coilTagID.ToString());
            }
            
            sb.Append("and c.coilTagID = rd.coilTagID ");
            if (coilTagID == -1)
            {
                sb.Append("and c.coilTagSuffix = rd.skidLetter ");
            }
            
            sb.Append("and rd.alloyid = a.AlloyID ");
            sb.Append("and rd.finishID = af.FinishID ");
            sb.Append("and a.SteelTypeID = st.SteelTypeID ");
            sb.Append("and rh.custID = cu1.CustomerID ");
            sb.Append("and c.customerID = cu2.CustomerID ");
            sb.Append("order by c.coilTagID ");



            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        
        public List<string> getPOtags(string customerPO)
        {

            List<string> poTags = new List<string>();

            StringBuilder sb = new StringBuilder();
            //receiving
            sb.Append("select distinct coiltagid from " + PlantLocation.city + ".receiveHdr rh, " + PlantLocation.city + ".receiveDtl rd ");
            sb.Append("where rh.receiveID = rd.receiveID ");
            sb.Append("and rd.purchaseOrder = @customerPO ");
            //CTL
            sb.Append("union ");
            sb.Append("select distinct coilTagID from " + PlantLocation.city + ".orderhdr oh, " + PlantLocation.city + ".CTLDetail op ");
            sb.Append("where oh.OrderID = op.orderID ");
            sb.Append("and customerPO = @customerPO ");
            sb.Append("union ");
            //sheet polish/Buff
            sb.Append("select distinct skidid from " + PlantLocation.city + ".orderhdr oh, " + PlantLocation.city + ".OrderPolishDtl op ");
            sb.Append("where oh.OrderID = op.orderID ");
            sb.Append("and customerPO = @customerPO ");
            sb.Append("union ");
            //coil polish
            sb.Append("select distinct coilTagID from " + PlantLocation.city + ".orderhdr oh, " + PlantLocation.city + ".CoilPolishHdr op ");
            sb.Append("where oh.OrderID = op.orderID ");
            sb.Append("and customerPO = @customerPO ");
            sb.Append("union ");
            //slitting
            sb.Append("select distinct coilTagID from " + PlantLocation.city + ".orderhdr oh, " + PlantLocation.city + ".CoilSlitOrderHdr op ");
            sb.Append("where oh.OrderID = op.orderID ");
            sb.Append("and customerPO = @customerPO ");
            sb.Append("union ");
            //shearing
            sb.Append("select distinct skidid from " + PlantLocation.city + ".orderhdr oh, " + PlantLocation.city + ".OrderShearMaterial op ");
            sb.Append("where oh.OrderID = op.orderID ");
            sb.Append("and customerPO = @customerPO ");
            sb.Append("union ");
            //shipping
            sb.Append("select distinct ID from " + PlantLocation.city + ".shipHdr sh, " + PlantLocation.city + ".shipdtl sd ");
            sb.Append("where sh.shipID = sd.shipid ");
            sb.Append("and (sh.releaseNUM = @customerPO or custPO = @customerPO) ");
            sb.Append("order by 1");

            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };
            cmd.Parameters.AddWithValue("@customerPO", customerPO);


            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int tagID = reader.GetInt32(0);
                        poTags.Add(tagID.ToString()) ;
                    }
                }
            }


            return poTags;



        }

        public List<string> getMilltags(string millNum)
        {

            List<string> millTags = new List<string>();

            StringBuilder sb = new StringBuilder();
            
            sb.Append("select distinct coiltagid from " + PlantLocation.city + ".coil c ");
            sb.Append("where c.millCoilNum =  @millNum ");
            

            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };
            cmd.Parameters.AddWithValue("@millNum", millNum);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int tagID = reader.GetInt32(0);
                        millTags.Add(tagID.ToString());
                    }
                }
            }


            return millTags;



        }

        public int InsertSteelType(String SteelDesc)
        {

            StringBuilder sb = new StringBuilder();


            sb.Append("INSERT INTO " + PlantLocation.city + ".SteelType ");
            sb.Append("(SteelDesc) ");
            sb.Append("output INSERTED.SteelTypeID VALUES(@SteelDesc)");



            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Parameters.AddWithValue("@SteelDesc", SteelDesc);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            int SteelID = (int)cmd.ExecuteScalar();



            return SteelID;
        }

        public int UpdateSteelDesc(int SteelTypeID, string SteelDesc)
        {
            int SteelCnt = -1;

            StringBuilder sb = new StringBuilder();

            sb.Append("update " + PlantLocation.city + ".SteelType ");
            sb.Append("SET SteelDesc = @SteelDesc ");

            sb.Append("WHERE SteelTypeID = @SteelTypeID");





            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };

            cmd.Parameters.AddWithValue("@SteelDesc", SteelDesc);
            cmd.Parameters.AddWithValue("@SteelTypeID", SteelTypeID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            //returns record count affected
            SteelCnt = (int)cmd.ExecuteNonQuery();



            return SteelCnt;
        }

        public DbDataReader GetSteelTypes()
        {


            StringBuilder sb = new StringBuilder();

            sb.Append("select * From " + PlantLocation.city + ".SteelType ");
            sb.Append("order by SteelTypeID ");

            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();


            return reader;
        }
        public DbDataReader GetFinish(string alloyID, int finishID = -1, int steelTypeID = -1, bool allfinishes = false)
        {

            StringBuilder sb = new StringBuilder();
            if (steelTypeID == -1)
            {
                sb.Append("SELECT * from " + PlantLocation.city + ".Alloy al, " + PlantLocation.city + ".AlloyFinish af ");

                sb.Append("where al.AlloyID = " + alloyID + " ");
                sb.Append("and af.SteelTypeID = al.SteelTypeID ");
                if (finishID != -1)
                {
                    sb.Append("and af.finishID = " + finishID + " ");

                }
                sb.Append("order by af.SteelTypeID, af.FinishDesc");
            }
            else
            {
                sb.Append("SELECT * from " + PlantLocation.city + ".AlloyFinish af ");

                if (!allfinishes)
                {
                    sb.Append("where af.steeltypeid = " + steelTypeID);
                }


                sb.Append(" order by FinishDesc");

            }
            

            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;

        }


        public DbDataReader GetLocationInfo()
        {


            StringBuilder sb = new StringBuilder();

            //Should just be one record
            sb.Append("SELECT * from " + PlantLocation.city + ".Location ");

           
            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public int AddReceivingHdr(RecHdrInfo rhInfo, SqlTransaction tran)
        {
            int hdrRecID = -1;



            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + PlantLocation.city + ".receiveHdr ");
            sb.Append("(custID,purchaseOrder,container,receiveDate,status, workerID) ");
            sb.Append("output INSERTED.receiveID VALUES(@custID, @purchaseOrder,@container, @receiveDate, @status, @workerID)");
            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran,

            };
            cmd.Parameters.AddWithValue("@custID", rhInfo.custID);
            cmd.Parameters.AddWithValue("@purchaseOrder", rhInfo.purchaseOrder);
            cmd.Parameters.AddWithValue("@container", rhInfo.container);
            cmd.Parameters.AddWithValue("@receiveDate", rhInfo.receiveDate);
            cmd.Parameters.AddWithValue("@status", rhInfo.status);
            cmd.Parameters.AddWithValue("@workerID", rhInfo.workerID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            hdrRecID = (int)cmd.ExecuteScalar();



            return hdrRecID;
        }

        public DbDataReader GetCoilInfo(int coilID = 0, string coiltagSuffix = "", int customerID = 0, SqlTransaction tran = null, bool useConn1 = true)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT *, rd.purchaseOrder as dtlPO ");

            //sb.Append("from " + PlantLocation.city + ".coil cl, " + PlantLocation.city + ".Alloy al, " +
            //        PlantLocation.city + ".AlloyFinish af, " + PlantLocation.city + ".receiveDtl rd, " +
            //        PlantLocation.city + ".receivehdr rh, " + PlantLocation.city + ".Customer cu,  " + PlantLocation.city + ".SteelType st ");

            sb.Append("from " + PlantLocation.city + ".coil cl, " + PlantLocation.city + ".Alloy al, " +
                    PlantLocation.city + ".AlloyFinish af,  " +
                    PlantLocation.city + ".receivehdr rh, " + PlantLocation.city + ".Customer cu,  " + PlantLocation.city + ".SteelType st, ");

            sb.Append(PlantLocation.city + ".receivedtl rd ");


            if (coilID == 0)
            {
                if (customerID != 0)
                {
                    sb.Append("where cl.customerID = " + customerID.ToString().Trim() + " and ((cl.coilstatus > 0 and cl.weight >0) or cl.coilstatus = -3) ") ;

                }
                else
                {
                    sb.Append("where ((cl.coilstatus > 0 and cl.weight >0) or cl.coilstatus = -3) ");

                }

            }
            else
            {
                sb.Append("Where cl.coilTagID = @coilID and coilTagSuffix = @coilSuffix ");
            }

            sb.Append("and cl.AlloyID = al.AlloyID and cl.finishID = af.FinishID ");
            //sb.Append("and cl.coilTagID = rd.coilTagID ");
            sb.Append("and rh.receiveID = cl.receiveID ");
            sb.Append("and cl.customerID = cu.customerID ");
            sb.Append("and al.SteelTypeID = st.SteelTypeID ");
            sb.Append("and rh.receiveID = rd.receiveID ");
            sb.Append("and rd.coilTagID = cl.coilTagID ");
            if (customerID == 0 && coilID == 0) 
            {
                sb.Append("order by cu.longCustomerName,cl.coilTagID,cl.coilTagSuffix;");
            }
            else
            {
                sb.Append("order by cl.coilTagID,cl.coilTagSuffix;");
            }
            
            String sql = sb.ToString();

            SqlConnection thisConn = SQLConn.conn;
            if (useConn1)
            {
                thisConn = SQLConn1.conn;
            }

           SqlCommand cmd = new SqlCommand
            {
                

                // Set connection for Command.
                Connection = thisConn,
                CommandText = sql
            };

            if (tran != null)
            {
                cmd.Transaction = tran;
            }
            if (coilID != 0)
            {
                cmd.Parameters.AddWithValue("@coilID", coilID);
                cmd.Parameters.AddWithValue("@coilSuffix", coiltagSuffix);

            }

            if (thisConn.State == ConnectionState.Closed)
            {
                thisConn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public DbDataReader GetAlloyData(int FindAlloyID = -1, int SteelTypeID = -1)
        {


            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * from " + PlantLocation.city + ".Alloy a, " + PlantLocation.city + ".SteelType s " );

            if (FindAlloyID != -1)
            {
                sb.Append("where a.alloyID = " + FindAlloyID.ToString());
                
            }
            if (SteelTypeID != -1)
            {
                if (FindAlloyID == -1)
                {
                    sb.Append(" where a.SteelTypeID = " + SteelTypeID.ToString());
                }
                else
                {
                    sb.Append(" and a.SteelTypeID = " + SteelTypeID.ToString());
                }
            }
            if (FindAlloyID == -1 && SteelTypeID == -1)
            {
                sb.Append(" where a.SteelTypeID = s.SteelTypeID");
            }
            else
            {
                sb.Append(" and a.SteelTypeID = s.SteelTypeID");
            }
            
            if (SteelTypeID != -1)
            {
                sb.Append(" order by a.OrderList");
            }
            else
            {
                sb.Append(" order by a.SteelTypeID, a.AlloyDesc");
            }


            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public int DuplicateCoil(int coilTagID,string origCoilSuffix, string newCoilSuffix, int newFinishID, int newWeight, SqlTransaction tran)
        {




            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + PlantLocation.city + ".Coil ");
            sb.Append("SELECT [coilTagID],@newCoilSuffix,[SuffixID],[coilCount],[customerID],[receiveID] ");
            sb.Append(",[millCoilNum],[vendor],[location],[alloyID],@newFinishID,[thickness],[width] ");
            sb.Append(",[length],@newWeight,[paper],[pvc],[heat],[countryOfOrigin],[carbon],1 ");//default status = 1
            sb.Append(",[type],[typeNum] ,[reject],[comments] ");
            sb.Append("FROM " + PlantLocation.city + ".[Coil] ");
            sb.Append("where coiltagid = @coilTagID and coiltagsuffix = @origCoilSuffix ");



            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran,

            };
            cmd.Parameters.AddWithValue("@coilTagID", coilTagID);
            cmd.Parameters.AddWithValue("@origCoilSuffix", origCoilSuffix); 
            cmd.Parameters.AddWithValue("@newCoilSuffix", newCoilSuffix);
            cmd.Parameters.AddWithValue("@newFinishID", newFinishID);
            cmd.Parameters.AddWithValue("@newWeight", newWeight);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }


            cmd.ExecuteScalar();


            return 1;

        }
        public int InsertCoil(CoilInfo cinfo, SqlTransaction tran)
        {


           

            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + PlantLocation.city + ".Coil ");
            sb.Append("(coilTagSuffix,coilCount,customerID,receiveID,millCoilNum, ");
            sb.Append("vendor,location,alloyID,finishID,thickness,width,length, ");
            sb.Append("weight,heat,countryOfOrigin,carbon,coilStatus,type,typeNum) ");
            sb.Append("output INSERTED.coilTagID VALUES(@coilTagSuffix, @coilCount,@customerID, @receiveID, @millCoilNum, @vendor, ");
            sb.Append("@location, @alloyID,@finishID,@thickness, @width, @length,@weight, @heat, ");
            sb.Append("@countryOfOrigin,@carbon, @coilStatus, @type, @typeNum)");


            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran,

            };
            cmd.Parameters.AddWithValue("@coilTagSuffix", cinfo.coilTagSuffix);
            cmd.Parameters.AddWithValue("@coilCount", cinfo.coilCount);
            cmd.Parameters.AddWithValue("@customerID", cinfo.customerID);
            cmd.Parameters.AddWithValue("@receiveID", cinfo.receiveID);
            cmd.Parameters.AddWithValue("@millCoilNum", cinfo.millCoilNum);
            cmd.Parameters.AddWithValue("@vendor", cinfo.vendor);
            cmd.Parameters.AddWithValue("@location", cinfo.location);
            cmd.Parameters.AddWithValue("@alloyID", cinfo.alloyID);
            cmd.Parameters.AddWithValue("@finishID", cinfo.finishID);
            cmd.Parameters.AddWithValue("@thickness", cinfo.thickness);
            cmd.Parameters.AddWithValue("@width", cinfo.width);
            cmd.Parameters.AddWithValue("@length", cinfo.length);
            cmd.Parameters.AddWithValue("@weight", cinfo.weight);
            cmd.Parameters.AddWithValue("@heat", cinfo.heat);
            cmd.Parameters.AddWithValue("@countryOfOrigin", cinfo.countryOfOrigin);
            cmd.Parameters.AddWithValue("@carbon", cinfo.carbon);
            cmd.Parameters.AddWithValue("@coilStatus", cinfo.coilStatus);
            cmd.Parameters.AddWithValue("@type", cinfo.type);
            cmd.Parameters.AddWithValue("@typeNum", cinfo.typeNum);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }


            int tagID = (int)cmd.ExecuteScalar();


            return tagID;

        }

        public DbDataReader GetMachineNames()
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * ");
            sb.Append("from " + PlantLocation.city + ".Machines ma ");




            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public DbDataReader GetSlitterTrimInfo(int machineID)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * from " + PlantLocation.city + ".SlitterTrimTable st ");
            sb.Append("where st.machineID = " + machineID.ToString());



            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }
        public DbDataReader GetCLCLProcID()
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("select processID from tsamaster.processFunction pf,tsamaster.Processes pc ");
            sb.Append("where pf.procTypeID = pc.ProcTypeID ");
            sb.Append("and processFunction = 'CoilCoilDiff'");


            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public DbDataReader GetMachineInfo(int ProcID)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT machineID, machineName, processFunction, LeadTime ");
            sb.Append("from TSAMaster.ProcessFunction pf, TSAMaster.Processes pr, " + PlantLocation.city + ".Machines ma ");
            sb.Append("where pr.ProcessID = ma.ProcessID ");
            sb.Append("and pf.ProcTypeID = pr.procTypeID ");
            sb.Append("and pr.processID = " + ProcID.ToString());



            String sql = sb.ToString();
            //Bobby 2024 - Jan 8
            //if (SQLConn.conn.State == ConnectionState.Open)
            //{
            //    SQLConn.conn.Close();
            //    SQLConn.conn.Open();
            //}
            //else
            //{
            //    if (SQLConn.conn.State == ConnectionState.Closed)
            //    {
            //        SQLConn.conn.Open();
            //    }
            //}

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public int UpdateSkidCust(int tagID, string coilTagSuffix, string skidLetter, int newCustID, SqlTransaction trans = null)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("update " + PlantLocation.city + ".skidData ");
            sb.Append("set customerID = @custID ");

            sb.Append("where skidID = @id ");
            sb.Append("and coilTagSuffix = @coilTagSuffix ");
            sb.Append("and letter = @letter ");

            String sql = sb.ToString();


            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            if (trans != null)
            {
                cmd.Transaction = trans;
            }

            cmd.Parameters.AddWithValue("@custID", newCustID);
            cmd.Parameters.AddWithValue("@id", tagID);
            cmd.Parameters.AddWithValue("@coilTagSuffix",coilTagSuffix);
            cmd.Parameters.AddWithValue("@letter", skidLetter);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            int cnt = (int)cmd.ExecuteNonQuery();

            return cnt;
        }

        public int UpdateSkidInfo(SkidData sd, string orderLetter = "Nope",SqlTransaction trans = null)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("update " + PlantLocation.city + ".skidData ");
            sb.Append("set location = @location, sheetWeight = @sheetWeight, length = @length, width = @width, pieceCount = @pieceCount, ");
            sb.Append("comments = @comments, diagnol1 = @diag1, diagnol2 = @diag2, mic1 = @mic1, mic2 = @mic2, mic3 = @mic3,alloyID = @alloyID, ");
            sb.Append("finishID = @finishID, skidtypeID = @skidTypeID, skidPrice = @skidPrice, notprime = @notprime, branchID = @branchID ");
            if (orderLetter != "Nope")
            {
                sb.Append(",letter=@orderLetter, orderID = @orderID ");
            }
            sb.Append("where skidID = @id ");
            sb.Append("and coilTagSuffix = @coilTagSuffix ");
            sb.Append("and letter = @letter ");

            String sql = sb.ToString();


            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
                

            cmd.Parameters.AddWithValue("@location", sd.location);
            cmd.Parameters.AddWithValue("@sheetWeight", sd.sheetWeight);
            cmd.Parameters.AddWithValue("@length", sd.length);
            cmd.Parameters.AddWithValue("@width", sd.width);
            cmd.Parameters.AddWithValue("@pieceCount", sd.pieceCount);
            cmd.Parameters.AddWithValue("@comments", sd.comments);
            cmd.Parameters.AddWithValue("@diag1", sd.diagnol1);
            cmd.Parameters.AddWithValue("@diag2", sd.diagnol2);
            cmd.Parameters.AddWithValue("@mic1", sd.mic1);
            cmd.Parameters.AddWithValue("@mic2", sd.mic2);
            cmd.Parameters.AddWithValue("@mic3", sd.mic3);
            cmd.Parameters.AddWithValue("@alloyID", sd.alloyID);
            cmd.Parameters.AddWithValue("@finishID", sd.finishID);
            cmd.Parameters.AddWithValue("@skidTypeID", sd.skidTypeID);
            cmd.Parameters.AddWithValue("@skidPrice", sd.skidPrice);
            cmd.Parameters.AddWithValue("@notprime", sd.notPrime);
            cmd.Parameters.AddWithValue("@branchID", sd.branchID);
            cmd.Parameters.AddWithValue("@id", sd.skidID);
            cmd.Parameters.AddWithValue("@coilTagSuffix", sd.coilTagSuffix);
            cmd.Parameters.AddWithValue("@letter", sd.letter);
            if (orderLetter != "Nope")
            {
                cmd.Parameters.AddWithValue("@orderLetter", orderLetter);
                cmd.Parameters.AddWithValue("@orderID", sd.orderID);
            }

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            int cnt = (int)cmd.ExecuteNonQuery();

            return cnt;
        }




        public int UpdateCoilInfo(CoilInfo ci)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("update " + PlantLocation.city + ".coil ");
            sb.Append("set weight = @weight, width = @width, length = @length, thickness = @thickness, ");
            sb.Append("location = @location, millCoilNum = @millCoilNum, heat = @heat, vendor = @vendor, ");
            sb.Append("countryOfOrigin = @COO, coilCount = @coilCount, carbon = @carbon, ");
            sb.Append("alloyID = @alloyID, finishID = @finishID ");
            sb.Append("where coilTagID = @id ");
            sb.Append("and coilTagSuffix = @coilTagSuffix ");


            String sql = sb.ToString();




            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                

            };


            cmd.Parameters.AddWithValue("@weight", ci.weight);
            cmd.Parameters.AddWithValue("@width", ci.width);
            cmd.Parameters.AddWithValue("@length", ci.length);
            cmd.Parameters.AddWithValue("@thickness", ci.thickness);
            cmd.Parameters.AddWithValue("@location", ci.location);
            cmd.Parameters.AddWithValue("@millCoilNum", ci.millCoilNum);
            cmd.Parameters.AddWithValue("@heat", ci.heat);
            cmd.Parameters.AddWithValue("@vendor", ci.vendor);
            cmd.Parameters.AddWithValue("@COO", ci.countryOfOrigin);
            cmd.Parameters.AddWithValue("@coilCount", ci.coilCount);
            cmd.Parameters.AddWithValue("@carbon", ci.carbon);
            cmd.Parameters.AddWithValue("@alloyID", ci.alloyID);
            cmd.Parameters.AddWithValue("@finishID", ci.finishID);
            cmd.Parameters.AddWithValue("@id", ci.coilTagID);
            cmd.Parameters.AddWithValue("@coilTagSuffix", ci.coilTagSuffix);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            int cnt = (int)cmd.ExecuteNonQuery();

            return cnt;

        }
        public DbDataReader GetSkidHistory(int skidID,  SqlTransaction trans = null, int orderID = -1)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT *, " + PlantLocation.city + ".GetSkidWeight(sd.skidid,sd.coilTagSuffix,sd.letter) as SkidWeight ");
            sb.Append("from " + PlantLocation.city + ".skidData sd, " + PlantLocation.city + ".Alloy a, ");
            sb.Append( PlantLocation.city + ".AlloyFinish af, " + PlantLocation.city + ".customerBranch cb, ");
            sb.Append(PlantLocation.city + ".Coil c ");
            if (orderID == -1)
            {
                sb.Append("where sd.skidID = @skidID ");
            }
            else
            {
                sb.Append("where sd.orderID = @orderID ");
            }
            
            sb.Append("and a.alloyiD = sd.AlloyID ");
            sb.Append("and af.finishID = sd.finishID ");
            sb.Append("and cb.customerID = sd.customerID ");
            sb.Append("and cb.branchID = sd.branchID ");
            sb.Append("and c.coilTagID = sd.skidID ");
            sb.Append("and c.coilTagSuffix = sd.coilTagSuffix ");

            sb.Append("order by sd.skidID, sd.coilTagSuffix,sd.Letter ");

            

            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            if (orderID == -1)
            {
                cmd.Parameters.AddWithValue("@skidID", skidID);
            }
            else
            {
                cmd.Parameters.AddWithValue("@orderID", orderID);
            }

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }
        public DbDataReader GetSkidData(int skidID, string coilTagSuffix, string skidLetter, SqlTransaction trans = null)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT  sd.*, c.longCustomerName, coil.thickness, coil.millCoilNum, coil.heat, "+ PlantLocation.city +".GetSkidWeight(sd.skidID,sd.coilTagSuffix,sd.letter) as skidWeight ");
            sb.Append("from " + PlantLocation.city + ".skidData sd, " + PlantLocation.city + ".customer c, ");
            sb.Append(PlantLocation.city + ".coil ");
            sb.Append("where sd.skidID = @skidID ");
            sb.Append("and sd.coilTagSuffix = @coilTagSuffix ");
            sb.Append("and sd.letter = @skidLetter ");
            sb.Append("and sd.customerID = c.customerID ");
            sb.Append("and coil.coilTagID = sd.skidID ");
            sb.Append("and coil.coilTagSuffix = sd.coilTagSuffix ");

           

            String sql = sb.ToString();
            
            

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.Parameters.AddWithValue("@skidID", skidID);
            cmd.Parameters.AddWithValue("@coilTagSuffix", coilTagSuffix);
            cmd.Parameters.AddWithValue("@skidLetter", skidLetter);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public DbDataReader GetOrderHdr(int OrderID)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("select machineName, processFunction, oh.*, c.* From " + PlantLocation.city + ".orderHdr oh, " + PlantLocation.city + ".customer c, ");
            sb.Append(PlantLocation.city + ".machines, TSAMaster.Processes, TSAMaster.processFunction ");
            sb.Append("where oh.orderID = @orderID ");
            sb.Append("and oh.customerID = c.customerID ");

            sb.Append("and machines.processID = processes.ProcessID ");
            sb.Append("and processes.ProcTypeID = processFunction.procTypeID ");
            sb.Append("and oh.MachineID = machines.machineID ");
    

                String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };

            cmd.Parameters.AddWithValue("@orderID", OrderID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }


            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }
        public DbDataReader GetOrderAdders(int orderID, int TagID, string TagSuffix, int sequence)
        {


            StringBuilder sb = new StringBuilder();
            sb.Append("select ap.*,ad.adderDesc ");
            sb.Append("From " + PlantLocation.city + ".CTLAdderPricing ap, " + PlantLocation.city + ".AdderDesc ad ");
            sb.Append("where ap.adderID = ad.adderID ");
            sb.Append("and orderID = @orderID ");
            sb.Append("and coiltagid = @CoilTagID ");
            sb.Append("and coiltagsuffix = @coilTagSuffix ");
            sb.Append("and sequenceNumber = @numSeq ");



            String sql = sb.ToString();
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            cmd.Parameters.AddWithValue("@orderID", orderID);
            cmd.Parameters.AddWithValue("@CoilTagID", TagID);
            cmd.Parameters.AddWithValue("@coilTagSuffix", TagSuffix);
            cmd.Parameters.AddWithValue("@numSeq", sequence);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;


        }

        public void UpdateAdderDesc(int adderID, int status)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("update " + PlantLocation.city + ".adderDesc ");
            sb.Append("set active = @status ");
            sb.Append("where adderID = @adderID");

            SqlCommand cmd = new SqlCommand();
            String sql = sb.ToString();


            cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@adderID", adderID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            cmd.ExecuteNonQuery();


        }


        public int InsertAdderDesc(string adderDesc, decimal price, decimal minPrice,int calcType)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("INSERT INTO " + PlantLocation.city + ".[AdderDesc] ");
            sb.Append("([adderDesc],[adderPrice],[adderMin],[calcType],[active]) ");
            sb.Append("output INSERTED.adderID ");
            sb.Append("VALUES ");
            sb.Append("(@adderDesc,@adderPrice,@adderMin,@calcType,1) ");


            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };



            cmd.Parameters.AddWithValue("@adderDesc", adderDesc);
            cmd.Parameters.AddWithValue("@adderPrice", price);
            cmd.Parameters.AddWithValue("@adderMin", minPrice);
            cmd.Parameters.AddWithValue("@calcType", calcType);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            int adderID = (int)cmd.ExecuteScalar();

            return adderID;

        }
        public DbDataReader GetAdderDesc()
        {
           
            StringBuilder sb = new StringBuilder();

            sb.Append("select* From " + PlantLocation.city + ".AdderDesc ");
            sb.Append("where active > 0");


            String sql = sb.ToString();
            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public DbDataReader GetOpenBols()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("select c.LongCustomerName, sh.shipid, ");
            sb.Append("format(sh.releaseDate,'MM/dd/yy') as relDate,sd.id,sd.coilTagSuffix,sd.letter ");
            sb.Append("from " + PlantLocation.city + ".shiphdr sh, ");
            sb.Append(PlantLocation.city + ".shipdtl sd, ");
            sb.Append(PlantLocation.city + ".Customer c ");
            sb.Append("where sh.shipid = sd.shipID and sh.status > 0 and sd.status > 0 ");
            sb.Append("and c.CustomerID = sh.customerID order by sh.shipid, sd.id, sd.coilTagSuffix,sd.letter");


            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };
            
            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }
        public DbDataReader GetSkidInfo(string customerID = "-1",int skidID = -1, string coilTagSuffix = "NOPE", string letter = "NOPE", bool useConn1 = false) 
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT sd.*,cl.*,al.*,af.*,cu.*,br.*,st.*,stype.*,oh.*,rd.*, " + PlantLocation.city + ".GetSkidWeight(sd.skidID, sd.coilTagSuffix,sd.letter) as SkidWeight, ");
            sb.Append(PlantLocation.city + ".getSkidDate(sd.skidID,sd.coilTagSuffix,sd.letter) as skidDate ");
            sb.Append("from " + PlantLocation.city + ".skidData sd left join " + PlantLocation.city + ".orderHdr oh on sd.orderid = oh.orderid ");
            sb.Append("left join " + PlantLocation.city + ".receiveDtl rd on sd.skidid = rd.coilTagID and sd.letter = rd.skidLetter, ");
            sb.Append( PlantLocation.city + ".coil cl, ");
            sb.Append(PlantLocation.city + ".Alloy al, " + PlantLocation.city + ".AlloyFinish af, ");
            sb.Append(PlantLocation.city + ".Customer cu, " + PlantLocation.city + ".CustomerBranch br, ");
            sb.Append(PlantLocation.city + ".skidType st, " + PlantLocation.city + ".SteelType stype ");
            if (!customerID.Equals("-1"))
            {
                sb.Append("where sd.customerID = " + customerID + " and  sd.skidStatus > 0  ");
            }
            else
            {
                sb.Append("where sd.skidID = @skidID ");
                sb.Append("and sd.coilTagSuffix = @coilTagSuffix ");
                sb.Append("and sd.letter = @letter ");
            }
            
            sb.Append(" and sd.skidID = cl.coilTagID ");
            sb.Append(" and sd.coilTagSuffix = cl.coilTagSuffix ");
            sb.Append("and sd.AlloyID = al.AlloyID and sd.finishID = af.FinishID ");

            sb.Append("and sd.customerID = cu.customerID ");
            sb.Append("and br.branchID = sd.branchID ");
            sb.Append("and br.customerID = sd.customerID ");
            sb.Append("and st.skidTypeID = sd.skidTypeID ");
            sb.Append("and stype.steelTypeID = al.steelTypeID ");

            sb.Append("order by sd.skidID,sd.coilTagSuffix, sd.letter;");
            String sql = sb.ToString();

            SqlConnection thisConn = SQLConn.conn;
            if (useConn1)
            {
                thisConn = SQLConn1.conn;
            }

           SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = thisConn,
                CommandText = sql
            };
            if (customerID.Equals("-1"))
            {
                cmd.Parameters.AddWithValue("@skidID", skidID);
                cmd.Parameters.AddWithValue("@coilTagSuffix", coilTagSuffix);
                cmd.Parameters.AddWithValue("@letter", letter);
            }

            if (thisConn.State == ConnectionState.Closed)
            {
                thisConn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public int AddReceivingDtl(RecDtlInfo rdInfo, SqlTransaction tran)
        {

            int dtlRecID = -1;



            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + PlantLocation.city + ".receiveDtl ");
            sb.Append("(receiveID,coilTagID,skidLetter,type,purchaseOrder, millNum,heat,pieceCount,alloyID,finishID,thickness,width,length,weight) ");
            sb.Append(" output INSERTED.receiveID VALUES(@receiveID,@coilTagID,@skidLetter,@type,@purchaseOrder, @millNum,@heat,@pieceCount,@alloyID,@finishID,@thickness,@width,@length,@weight)");
            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran,

            };



            cmd.Parameters.AddWithValue("@receiveID", rdInfo.receiveID);
            cmd.Parameters.AddWithValue("@coilTagID", rdInfo.coilTagID);
            cmd.Parameters.AddWithValue("@skidLetter", rdInfo.skidLetter);
            cmd.Parameters.AddWithValue("@type", rdInfo.type);
            cmd.Parameters.AddWithValue("@purchaseOrder", rdInfo.purchaseOrder);
            cmd.Parameters.AddWithValue("@millNum", rdInfo.millNum);
            cmd.Parameters.AddWithValue("@heat", rdInfo.heat);
            cmd.Parameters.AddWithValue("@pieceCount", rdInfo.pieceCount);
            cmd.Parameters.AddWithValue("@alloyID", rdInfo.alloyID);
            cmd.Parameters.AddWithValue("@finishID", rdInfo.finishID);
            cmd.Parameters.AddWithValue("@thickness", rdInfo.thickness);
            cmd.Parameters.AddWithValue("@width", rdInfo.width);
            cmd.Parameters.AddWithValue("@length", rdInfo.length);
            cmd.Parameters.AddWithValue("@weight", rdInfo.weight);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            dtlRecID = (int)cmd.ExecuteScalar();



            return dtlRecID;
        }
        public int GetPVCRollCustCount(int custID)
        {
            int count = 0;
            StringBuilder sb = new StringBuilder();

            sb.Append("select count(*) as gCount from " + PlantLocation.city + ".PVCCustRollDtl, " + PlantLocation.city + ".PVCRollDtls ");

            sb.Append("where PVCCustRollDtl.PVCTagID = PVCRollDtls.PVCTagID ");
            sb.Append("and PVCRollDtls.Status > 0 ");
            sb.Append("and PVCRollDtls.CustID = " + custID.ToString());


            String sql = sb.ToString();
            try
            {
                
                SqlCommand cmd = new SqlCommand
                {

                    // Set connection for Command.
                    Connection = SQLConn.conn,
                    CommandText = sql

                };

                if (SQLConn.conn.State == ConnectionState.Closed)
                {
                    SQLConn.conn.Open();
                }

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            count = reader.GetInt32(reader.GetOrdinal("gCount"));
                        }


                    }
                    reader.Close();
                }


         
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }

            return count;
        }
        public DbDataReader GetSkidTypeData(bool secondConn = false)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("select* From " + PlantLocation.city + ".skidType ");
            sb.Append("order by orderby");

            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                
                CommandText = sql,


            };

            if (!secondConn)
            {
                cmd.Connection = SQLConn.conn;

                if (SQLConn.conn.State == ConnectionState.Closed)
                {
                    SQLConn.conn.Open();
                }
            }
            else
            {
                cmd.Connection = SQLConn1.conn;
                if (SQLConn1.conn.State == ConnectionState.Closed)
                {
                    SQLConn1.conn.Open();
                }
            }
            

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }
        
        public DbDataReader getShShHistory(int coilTagID)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("select *, afNew.finishDesc as newFinish, afOld.finishDesc as OldFinish ");

            sb.Append(" from " + PlantLocation.city + ".OrderPolishDtl opd, " + PlantLocation.city + ".orderhdr oh, ");
            sb.Append(PlantLocation.city + ".alloyfinish afNew, " + PlantLocation.city + ".alloyfinish afOld, ");
            sb.Append(PlantLocation.city + ".customerBranch cb ");
            sb.Append("where oh.orderid = opd.orderID ");
            sb.Append("and opd.orderid in (select orderid from " + PlantLocation.city + ".OrderPolishDtl op1 where skidid = @skidID) ");
            sb.Append("and afnew.finishID = newFinishID ");
            sb.Append("and afOld.FinishID = previousFinishID ");
            sb.Append("and cb.customerID = oh.customerID ");
            sb.Append("and cb.branchID = opd.branchID ");
            sb.Append("order by opd.orderiD, opd.skidID, opd.coilTagSuffix, opd.skidLetter, opd.orderLetter ");


            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };


            cmd.Parameters.AddWithValue("@skidID", coilTagID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }


        public DbDataReader GetShShSameOrderInfo(int orderID, int status = 1, int coilTagID = -1, string coilTagSuffix = "")
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("select opd.*,oh.*,c.*,al.*,sd.*,co.thickness, oh.comments as orderComments, ");
            sb.Append("opd.comments as skidComments,afNew.FinishDesc as newFin, afOld.FinishDesc as oldFin,co.millCoilNum, co.Heat, ");
            sb.Append(PlantLocation.city + ".GetSkidWeight(sd.skidID,sd.coilTagSuffix,sd.letter) as SkidWeight ");
            sb.Append("From " + PlantLocation.city + ".orderPolishDtl opd, " + PlantLocation.city + ".orderhdr oh, ");
            sb.Append(PlantLocation.city + ".customer c, " + PlantLocation.city + ".Alloy al, ");
            sb.Append(PlantLocation.city + ".skidData sd, " + PlantLocation.city + ".coil co, " + PlantLocation.city + ".AlloyFinish as afNew, ");
            sb.Append( PlantLocation.city + ".AlloyFinish as afOld ");
            sb.Append("where oh.orderID = opd.orderID ");
            if (coilTagID == -1)
            {
                sb.Append("and oh.orderid = @orderID ");
            }
            else
            {
                sb.Append("and co.coilTagID = @coilTagID ");
                sb.Append("and co.coilTagSuffix = @coilTagSuffix ");
            }
            sb.Append("and oh.customerID = c.customerID ");
            sb.Append("and opd.alloyID = al.alloyID ");
            sb.Append("and sd.skidID = opd.skidID ");
            sb.Append("and sd.coilTagSuffix = opd.coilTagSuffix ");
            sb.Append("and afold.FinishID = opd.previousFinishID ");
            sb.Append("and afnew.FinishID = opd.newFinishID ");
            
            if (status < 0)
            {
                sb.Append("and sd.letter = trim(opd.skidLetter) + '.' + trim(opd.orderletter) ");
                sb.Append("and co.coilTagID = sd.skidID ");
                sb.Append("and co.coilTagSuffix = sd.coilTagSuffix ");
            }
            else
            {
                sb.Append("and sd.letter = opd.skidLetter ");
                sb.Append("and co.coilTagID = sd.skidID ");
                sb.Append("and co.coilTagSuffix = sd.coilTagSuffix ");
            }
            
            sb.Append("order by opd.skidID, opd.coilTagSuffix, skidLetter, orderLetter ");

            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };

            cmd.Parameters.AddWithValue("@orderID", orderID);
            if (coilTagID != -1)
            {
                cmd.Parameters.AddWithValue("@coilTagID", coilTagID);
                cmd.Parameters.AddWithValue("@coilTagSuffix", coilTagSuffix);
            }

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }
        public int InsertSkidDataRecord(SkidData sd, SqlTransaction tran)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("INSERT INTO " + PlantLocation.city + ".SkidData ");
            sb.Append("(skidID,coilTagSuffix, letter,location,alloyID,finishID,customerID,branchID,");
            sb.Append("orderID,sequenceNum,sheetWeight,length,width,diagnol1,diagnol2,mic1,mic2,mic3,");
            sb.Append("orderedPieceCount,pieceCount,pvcID,pvcPrice, paper,comments,skidStatus,skidTypeID,");
            sb.Append("skidPrice,notPrime) ");
            sb.Append("output INSERTED.skidID ");
            sb.Append("VALUES(@skidID,@coilTagSuffix,@letter,@location,@alloyID,@finishID,@customerID,@branchID,");
            sb.Append("@orderID,@sequenceNum,@sheetWeight,@length,@width,@diagnol1,@diagnol2,@mic1,@mic2,@mic3,");
            sb.Append("@orderedPieceCount,@pieceCount,@pvcID,@pvcPrice, @paper,@comments,@status,@skidTypeID,");
            sb.Append("@skidPrice,@notPrime) ");



            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran

            };




            cmd.Parameters.AddWithValue("@skidID", sd.skidID);
            cmd.Parameters.AddWithValue("@coilTagSuffix", sd.coilTagSuffix);
            cmd.Parameters.AddWithValue("@letter", sd.letter);
            cmd.Parameters.AddWithValue("@location", sd.location);
            cmd.Parameters.AddWithValue("@alloyID", sd.alloyID);
            cmd.Parameters.AddWithValue("@finishID", sd.finishID);
            cmd.Parameters.AddWithValue("@customerID", sd.customerID);
            cmd.Parameters.AddWithValue("@branchID", sd.branchID);

            cmd.Parameters.AddWithValue("@orderID", sd.orderID);
            cmd.Parameters.AddWithValue("@sequenceNum", sd.sequenceNumber);
            cmd.Parameters.AddWithValue("@sheetWeight", sd.sheetWeight);
            cmd.Parameters.AddWithValue("@length", sd.length);
            cmd.Parameters.AddWithValue("@width", sd.width);
            cmd.Parameters.AddWithValue("@diagnol1", sd.diagnol1);



            cmd.Parameters.AddWithValue("@diagnol2", sd.diagnol2);
            cmd.Parameters.AddWithValue("@mic1", sd.mic1);
            cmd.Parameters.AddWithValue("@mic2", sd.mic2);
            cmd.Parameters.AddWithValue("@mic3", sd.mic3);
            cmd.Parameters.AddWithValue("@orderedPieceCount", sd.orderedPieceCount);
            cmd.Parameters.AddWithValue("@pieceCount", sd.pieceCount);

            cmd.Parameters.AddWithValue("@pvcID", sd.pvcID);
            cmd.Parameters.AddWithValue("@pvcPrice", sd.pvcPrice);
            cmd.Parameters.AddWithValue("@paper", sd.paper);
            cmd.Parameters.AddWithValue("@comments", sd.comments);
            cmd.Parameters.AddWithValue("@status", sd.status);
            cmd.Parameters.AddWithValue("@skidTypeID", sd.skidTypeID);
            cmd.Parameters.AddWithValue("@skidPrice", sd.skidPrice);
            cmd.Parameters.AddWithValue("@notPrime", sd.notPrime);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            int skidID = (int)cmd.ExecuteScalar();

            return skidID;

        }

        public int InsertCustomer(CustomerInfo ci, SqlTransaction tran)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("INSERT INTO " + PlantLocation.city + ".[Customer] ");
            sb.Append("([ShortCustomerName] ,[LongCustomerName]  ,[Address1] ");
            sb.Append(",[Address2] ,[City] ,[StateCode] ,[Zip] ,[Country] ,[Phone] ");
            sb.Append(",[Fax] ,[ContactName] ,[Email] ,[Packaging] ,[MaxSkidWeight] ");
            sb.Append(",[PriceTier] ,[WeightFormula] ,[isActive] ,[QuickBookName] ,[leadtime]) ");
            sb.Append("output INSERTED.CustomerID ");
            sb.Append("VALUES ");
            sb.Append("(@ShortCustomerName,@LongCustomerName,@Address1,@Address2,@City,@StateCode,@Zip, ");
            sb.Append("@Country,@Phone, @Fax,@ContactName,@Email,@Packaging,@MaxSkidWeight, ");
            sb.Append("@PriceTier,@WeightFormula,@isActive,@QuickBookName,@leadtime) ");

            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran

            };
            
            
            sb.Append("@PriceTier,@WeightFormula,@isActive,@QuickBookName,@leadtime) ");

            cmd.Parameters.AddWithValue("@ShortCustomerName", ci.ShortName);
            cmd.Parameters.AddWithValue("@LongCustomerName", ci.LongName);
            cmd.Parameters.AddWithValue("@Address1", ci.Address1);
            cmd.Parameters.AddWithValue("@Address2", ci.Address2);
            cmd.Parameters.AddWithValue("@City", ci.City);
            cmd.Parameters.AddWithValue("@StateCode", ci.StateCode);
            cmd.Parameters.AddWithValue("@Zip", ci.Zip);
            cmd.Parameters.AddWithValue("@Country", ci.Country);
            cmd.Parameters.AddWithValue("@Phone", ci.Phone);
            cmd.Parameters.AddWithValue("@Fax", ci.Fax);
            cmd.Parameters.AddWithValue("@ContactName", ci.ContactName);
            cmd.Parameters.AddWithValue("@Email", ci.Email);
            cmd.Parameters.AddWithValue("@Packaging", ci.Packaging);
            cmd.Parameters.AddWithValue("@MaxSkidWeight", ci.MaxSkidWeight);
            cmd.Parameters.AddWithValue("@PriceTier", ci.PriceTier);
            cmd.Parameters.AddWithValue("@WeightFormula", ci.WeightFormula);
            cmd.Parameters.AddWithValue("@isActive", ci.isActive);
            cmd.Parameters.AddWithValue("@QuickBookName", ci.QuickBookName);
            cmd.Parameters.AddWithValue("@leadtime", ci.leadTime);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            int custID = (int)cmd.ExecuteScalar();

            return custID;

        }

        public DbDataReader GetAllProcesses()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Select processID, processDesc from TSAMaster.Processes");


            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }



        public int InsertMachine(MachineInfo mc)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("INSERT INTO " + PlantLocation.city + ".[Machines] ");
            sb.Append("([processID],[machineName],[minThickness],[maxThickness],[minWidth]");
            sb.Append(",[maxWidth],[minLength],[maxLength],[MinWeight],[maxWeight],[machineDesc]");
            sb.Append(",[LeadTime],[DefaultFinishID],[HoldDown]) ");
            sb.Append("output INSERTED.MachineID ");
            sb.Append("VALUES ");
            sb.Append("(@processID,@machineName,@minThickness,@maxThickness,@minWidth,@maxWidth,@minLength, ");
            sb.Append("@maxLength,@minWeight, @maxWeight,@machineDesc,@LeadTime,@DefaultFinishID,@HoldDown) ");


            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                

            };



            cmd.Parameters.AddWithValue("@processID", mc.processID);
            cmd.Parameters.AddWithValue("@machineName", mc.machineName);
            cmd.Parameters.AddWithValue("@minThickness", mc.minThickness);
            cmd.Parameters.AddWithValue("@maxThickness", mc.maxThickness);
            cmd.Parameters.AddWithValue("@minWidth", mc.minWidth);
            cmd.Parameters.AddWithValue("@maxWidth", mc.maxWidth);
            cmd.Parameters.AddWithValue("@minLength", mc.minLength);
            cmd.Parameters.AddWithValue("@maxLength", mc.maxLength);
            cmd.Parameters.AddWithValue("@minWeight", mc.minWeight);
            cmd.Parameters.AddWithValue("@maxWeight", mc.maxWeight);
            cmd.Parameters.AddWithValue("@machineDesc", mc.machineDesc);
            cmd.Parameters.AddWithValue("@LeadTime", mc.leadTime);
            cmd.Parameters.AddWithValue("@DefaultFinishID", mc.finishID);
            cmd.Parameters.AddWithValue("@HoldDown", mc.HoldDown);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            int machineID = (int)cmd.ExecuteScalar();

            return machineID;

        }

        public DbDataReader GetTransferInfo(int tagID, string coilTagSuffix, string letter,int transferID = -1)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("select c1.longCustomerName as origCust,c2.longCustomerName as newCust,transferDate, purchaseOrder , transferCoilTagID, transferCoilTagSuffix, transferLetter, transferID, * ");
            sb.Append("from " + PlantLocation.city + ".Transfer t, " + PlantLocation.city);
            sb.Append(".customer c1, " + PlantLocation.city + ".customer c2 ");
            sb.Append("where t.originalCustID = c1.customerID ");
            sb.Append("and t.newCustID = c2.customerID ");
            


            if (transferID == -1)
            {
                sb.Append("and transferCoilTagID = @tagID ");
                sb.Append("and transferCoilTagSuffix = @coilTagSuffix ");
                sb.Append("and transferLetter = @letter ");
            }
            else
            {
                sb.Append("and t.transferID = @transferID ");
            }
            sb.Append("order by t.materialType,t.transferCoilTagID,t.transferCoilTagSuffix,t.transferLetter ");

            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            if (transferID == -1)
            {
                cmd.Parameters.AddWithValue("@tagID", tagID);
                cmd.Parameters.AddWithValue("@coilTagSuffix", coilTagSuffix);
                cmd.Parameters.AddWithValue("@letter", letter);
            }
            else
            {
                cmd.Parameters.AddWithValue("@transferID", transferID);
            }

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;

        }

        public int InsertTransferHdr(DateTime transDate, SqlTransaction tran)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + PlantLocation.city + ".TransferHdr ([transferDate]) ");
            sb.Append("output INSERTED.transferID Values (@trDate) ");

            string sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran,

            };

            cmd.Parameters.AddWithValue("@trDate", transDate);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            int transferID = (int)cmd.ExecuteScalar();


            return transferID;

        }

        public int InsertTransfer(int transID,int materialType, int tagID, string coilTagSuffix,
                                    string letter,int origCustID, int newCustID,string PO, DateTime transDate,SqlTransaction tran)
        {
            //materialType 0=coil 1=skid



            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + PlantLocation.city + ".Transfer ");
            sb.Append("([transferID],[materialType],[transferCoilTagID],[transferCoilTagSuffix],[transferLetter]");
            sb.Append(",[originalCustID],[newCustID],[purchaseOrder] ,[transferDate]) ");
           
            sb.Append("output INSERTED.transferID VALUES(@transID, @materialType, @transferCoilTagID,@transferCoilTagSuffix, @transferLetter,");
            sb.Append("@originalCustID, @newCustID,@purchaseOrder ,@transferDate )");


            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran,

            };
            cmd.Parameters.AddWithValue("@transID", transID);
            cmd.Parameters.AddWithValue("@materialType", materialType);
            cmd.Parameters.AddWithValue("@transferCoilTagID", tagID);
            cmd.Parameters.AddWithValue("@transferCoilTagSuffix", coilTagSuffix);
            cmd.Parameters.AddWithValue("@transferLetter", letter);
            cmd.Parameters.AddWithValue("@originalCustID", origCustID);
            cmd.Parameters.AddWithValue("@newCustID", newCustID);
            cmd.Parameters.AddWithValue("@transferDate", transDate);
            cmd.Parameters.AddWithValue("@purchaseOrder", PO);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            int transferID = (int)cmd.ExecuteScalar();


            return transferID;

        }

        public DbDataReader GetMachineOrders(int orderID = -1)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT machineID, machineName, processFunction, LeadTime, pr.processID ");
            sb.Append("from TSAMaster.ProcessFunction pf, TSAMaster.Processes pr, " + PlantLocation.city + ".Machines ma ");
            sb.Append("where pr.ProcessID = ma.ProcessID ");
            sb.Append("and pf.ProcTypeID = pr.procTypeID ");
            if (orderID == -1)
            {
                sb.Append("and ma.machineID in ( select machineID from " + PlantLocation.city + ".OrderHdr oh where oh.status > 0 )");

            }
            else
            {
                sb.Append("and ma.machineID in ( select machineID from " + PlantLocation.city + ".OrderHdr oh where oh.orderID = @orderID )");

            }




            String sql = sb.ToString();
            
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            if (orderID > 0)
            {
                cmd.Parameters.AddWithValue("@orderID", orderID);
            }

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }


            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }
        public DbDataReader GetCustOpenOrders(int custid)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("select distinct cu.LongCustomerName, m.machinename, c.thickness,");
            sb.Append("c.width, oh.orderid,oh.PromiseDate, oh.RunSheetComments , oh.CustomerPO ");
            sb.Append("from " + PlantLocation.city + ".orderhdr oh, ");
            sb.Append(PlantLocation.city + ".orderPolishDtl cd, ");
            sb.Append(PlantLocation.city + ".coil c, " + PlantLocation.city + ".customer cu, ");
            sb.Append(PlantLocation.city + ".skidData sk, " + PlantLocation.city + ".alloy a, ");
            sb.Append(PlantLocation.city + ".machines m ");
            sb.Append("where oh.orderID = cd.orderid ");
            sb.Append("and oh.status > 0 ");
            sb.Append("and c.customerID = cu.customerID ");
            sb.Append("and cd.skidID = c.coilTagID ");
            sb.Append("and cd.coilTagSuffix = c.coilTagSuffix ");
            sb.Append("and oh.MachineID = m.machineID ");
            sb.Append("and sk.skidid = cd.skidID ");
            sb.Append("and sk.coilTagSuffix = cd.coilTagSuffix ");
            sb.Append("and sk.letter = cd.skidLetter ");
            sb.Append("and a.alloyID = sk.alloyID ");
            sb.Append("and cu.customerID = @custID ");
            sb.Append("union ");
            sb.Append("select distinct cu.LongCustomerName, m.machinename,c.thickness, ");
            sb.Append("c.width, oh.orderid,oh.PromiseDate,oh.RunSheetComments, oh.CustomerPO ");
            sb.Append("from " + PlantLocation.city + ".orderhdr oh, ");
            sb.Append(PlantLocation.city + ".ctldetail cd, " + PlantLocation.city + ".coil c, ");
            sb.Append(PlantLocation.city + ".customer cu, " + PlantLocation.city + ".Machines m ");
            sb.Append("where oh.orderID = cd.orderid ");
            sb.Append("and oh.status > 0 ");
            sb.Append("and c.customerID = cu.customerID ");
            sb.Append("and cd.coilTagID = c.coilTagID ");
            sb.Append("and cd.coilTagSuffix = c.coilTagSuffix ");
            sb.Append("and m.machineID = oh.MachineID ");
            sb.Append("and cu.customerID = @custID ");
            sb.Append("union ");
            sb.Append("select distinct cu.LongCustomerName, m.machinename,c.thickness, c.width, ");
            sb.Append("oh.orderid,oh.PromiseDate,oh.RunSheetComments, oh.CustomerPO ");
            sb.Append("from " + PlantLocation.city + ".orderhdr oh, ");
            sb.Append(PlantLocation.city + ".coilPolishHdr cd, ");
            sb.Append(PlantLocation.city + ".coil c, " + PlantLocation.city + ".customer cu, ");
            sb.Append(PlantLocation.city + ".Machines m ");
            sb.Append("where oh.orderID = cd.orderid ");
            sb.Append("and oh.status > 0 ");
            sb.Append("and c.customerID = cu.customerID ");
            sb.Append("and cd.coilTagID = c.coilTagID ");
            sb.Append("and cd.coilTagSuffix = c.coilTagSuffix ");
            sb.Append("and m.machineid = oh.MachineID ");
            sb.Append("and cu.customerID = @custID ");
            sb.Append("order by oh.OrderID ");
            

            string sql = sb.ToString();

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }


            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            cmd.Parameters.AddWithValue("@custID", custid);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }


            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public DbDataReader getClClDiffCloseOrderInfo(int orderID)
        {
            StringBuilder sb = new StringBuilder();

            string city = PlantLocation.city;

            sb.Append("select *, ow.width as slitWidth, ob.paper as slitPaper ");
            sb.Append("from " + city + ".CoilSlitOrderBreaks ob, " + city + ".CoilSlitOrderWidths ow, ");
            sb.Append(city + ".coil c, " + city + ".alloy a, " + city + ".AlloyFinish af ");
            sb.Append("where ob.orderid = @orderID ");
            sb.Append("and ob.orderid = ow.orderid ");
            sb.Append("and ob.coiltagid = ow.coilTagID ");
            sb.Append("and ob.coilTagSuffix = ow.coilTagSuffix ");
            sb.Append("and ob.cutbreak = ow.cutbreak ");
            sb.Append("and c.coilTagID = ob.coiltagid ");
            sb.Append("and c.coilTagSuffix = ob.coilTagSuffix ");
            sb.Append("and c.alloyID = a.alloyid ");
            sb.Append("and c.finishID = af.FinishID ");

            sb.Append("order by ob.coilTagID, ob.coilTagSuffix,ow.newTagSuffix ");

            string sql = sb.ToString();


            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            cmd.Parameters.AddWithValue("@orderID", orderID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }


        public DbDataReader GetShShRunSheet(int MachineID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select distinct  oh.machineid, c.thickness, c.width, cu.ShortCustomerName, oh.orderid,a.DensityFactor, ");
            sb.Append(" sk.skidid , sk.coiltagsuffix, sk.letter, sk.location,oh.PromiseDate,sk.sheetWeight, cd.pvc,");
            sb.Append("cd.paper, oh.RunSheetComments , c.width, sk.length,sk.pieceCount, oh.RunSheetOrder,cd.breakSkid, oh.CustomerPO, oh.onHold ");
            sb.Append(", " + PlantLocation.city + ".GetSkidWeight(sk.skidID,sk.coilTagSuffix,sk.letter) as SkidWeight ");
            sb.Append("from " + PlantLocation.city + ".orderhdr oh, " + PlantLocation.city + ".orderPolishDtl cd, ");
            sb.Append(PlantLocation.city + ".coil c, " + PlantLocation.city + ".customer cu, ");
            sb.Append(PlantLocation.city + ".skidData sk, " + PlantLocation.city + ".alloy a ");
            sb.Append("where oh.orderID = cd.orderid ");
            sb.Append("and oh.status > 0 ");
            sb.Append("and c.customerID = cu.customerID ");
            sb.Append("and cd.skidID = c.coilTagID ");
            sb.Append("and cd.coilTagSuffix = c.coilTagSuffix ");
            sb.Append("and oh.machineid = @machineID ");
            sb.Append("and sk.skidid = cd.skidID ");
            sb.Append("and sk.coilTagSuffix = cd.coilTagSuffix ");
            sb.Append("and sk.letter = cd.skidLetter ");
            sb.Append("and a.alloyID = sk.alloyID ");
            sb.Append("order by oh.RunSheetOrder, oh.orderid");

            string sql = sb.ToString();

            
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            cmd.Parameters.AddWithValue("@machineID", MachineID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }


        public DbDataReader GetClClSmRunSheet(int MachineID)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("select distinct  oh.machineid,c.thickness, c.width, cu.ShortCustomerName, oh.orderid, ");
            sb.Append(" c.coiltagid, c.coiltagsuffix, c.location,oh.PromiseDate,c.weight,");
            sb.Append("cd.paper, oh.RunSheetComments , c.width, oh.RunSheetOrder, oh.onHold, oh.CustomerPO ");
            sb.Append("from " + PlantLocation.city + ".orderhdr oh, " + PlantLocation.city + ".coilPolishHdr cd, " + PlantLocation.city + ".coil c, " + PlantLocation.city + ".customer cu ");
            sb.Append("where oh.orderID = cd.orderid ");
            sb.Append("and oh.status > 0 ");
            sb.Append("and c.customerID = cu.customerID ");
            sb.Append("and cd.coilTagID = c.coilTagID ");
            sb.Append("and cd.coilTagSuffix = c.coilTagSuffix ");
            sb.Append("and c.coilstatus > 0 ");
            sb.Append("and oh.machineid = @machineID ");
            sb.Append("order by oh.RunSheetOrder, oh.orderid,  c.coilTagID, c.coilTagSuffix");

            string sql = sb.ToString();

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }


            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            cmd.Parameters.AddWithValue("@machineID", MachineID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public DbDataReader GetCTLRunSheet(int MachineID)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("select distinct  oh.machineid,cd.sequenceNumber, c.thickness, c.width, cu.ShortCustomerName, oh.orderid, ");
            sb.Append(" c.coiltagid, c.coiltagsuffix, c.location,oh.PromiseDate,c.weight, cd.PVCGroupID,");
            sb.Append("cd.paper, oh.RunSheetComments , c.width, cd.length, cd.skidCount, oh.RunSheetOrder, oh.onHold, oh.CustomerPO ");
            sb.Append("from " + PlantLocation.city + ".orderhdr oh, " + PlantLocation.city + ".ctldetail cd, " + PlantLocation.city + ".coil c, " + PlantLocation.city + ".customer cu ");
            sb.Append("where oh.orderID = cd.orderid ");
            sb.Append("and oh.status > 0 ");
            sb.Append("and c.customerID = cu.customerID ");
            sb.Append("and cd.coilTagID = c.coilTagID ");
            sb.Append("and cd.coilTagSuffix = c.coilTagSuffix ");
            sb.Append("and oh.machineid = @machineID ");
            sb.Append("order by oh.RunSheetOrder, oh.orderid, cd.sequenceNumber");

            string sql = sb.ToString();

            
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            cmd.Parameters.AddWithValue("@machineID", MachineID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }


            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public void UpdateOrderMachineID(int orderID, int machineID)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("update " + PlantLocation.city + ".orderHdr ");
           
            sb.Append("set machineID = @machineID ");
            

            sb.Append("where orderID = @orderID");

            SqlCommand cmd = new SqlCommand();
            String sql = sb.ToString();


            cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            
            cmd.Parameters.AddWithValue("@machineID", machineID);
            cmd.Parameters.AddWithValue("@orderID", orderID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }


            cmd.ExecuteNonQuery();


        }

        public void UpdateRunSheetOrder(int orderID, int runSheetOrder, string runSheetComments = "ABCDEFG")
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("update " + PlantLocation.city + ".orderHdr ");
            if (runSheetComments.Equals("ABCDEFG"))
            {
                sb.Append("set runSheetOrder = @runSheetOrder ");
            }
            else
            {
                sb.Append("set runSheetComments = @runSheetComments ");
            }
            
            sb.Append("where orderID = @orderID");

            SqlCommand cmd = new SqlCommand();
            String sql = sb.ToString();


            cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            if (runSheetComments.Equals("ABCDEFG"))
            {
                cmd.Parameters.AddWithValue("@runSheetOrder", runSheetOrder);
            }
            else
            {
                cmd.Parameters.AddWithValue("@runSheetComments", runSheetComments);
            }


            
            cmd.Parameters.AddWithValue("@orderID", orderID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }


            cmd.ExecuteNonQuery();

            
        }

        public void SetOrderHoldStatus(int orderID, int onHold)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update " + PlantLocation.city + ".orderHdr ");
            sb.Append("set onHold = @onHold ");
            sb.Append("where orderID = @orderID");

            SqlCommand cmd = new SqlCommand();
            String sql = sb.ToString();


            cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            cmd.Parameters.AddWithValue("@onHold", onHold);
            cmd.Parameters.AddWithValue("@orderID", orderID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            cmd.ExecuteNonQuery();


        }

        public DbDataReader GetScrapLBS (int orderID, int coilTagID, string coilTagSuffix)
        {
            


            StringBuilder sb = new StringBuilder();
            sb.Append("select  * from " + PlantLocation.city + ".GetScrapOrderLBSInfo(@orderID,@coilTagID,@coilTagSuffix)");

            string sql = sb.ToString();

            SqlCommand cmd = new SqlCommand()
            {
                Connection = SQLConn1.conn,
                CommandText = sql
            };
            cmd.Parameters.AddWithValue("@orderID", orderID);
            cmd.Parameters.AddWithValue("@coilTagID", coilTagID);
            cmd.Parameters.AddWithValue("@coilTagSuffix", coilTagSuffix);

            if (SQLConn1.conn.State == ConnectionState.Closed)
            {
                SQLConn1.conn.Open();
            }

            DbDataReader reader =  cmd.ExecuteReader();
            

            return reader;
        }


        public DbDataReader GetCTLPricing(int orderID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select oh.orderID,sd.skidid, ");
            sb.Append("sd.coiltagsuffix,");
            sb.Append("procprice,cwc.previousWeight,cwc.currentWeight,cwc.previousWeight * procprice as ProcTotal,'Paper' as TotType,");
            sb.Append("sum((sd.length * sd.width * sd.pieceCount)/144) as sqft,paperPrice as adderPrice, ");
            sb.Append("sum(((sd.length * sd.width * sd.pieceCount) / 144) * PaperPrice) as TypeTotal, ma.PriceMinOrder ");
            sb.Append("from " + PlantLocation.city + ".orderhdr oh," + PlantLocation.city + ".skiddata sd,");
            sb.Append( PlantLocation.city + ".CoilWeightChange cwc, " + PlantLocation.city + ".Machines ma ");
            sb.Append("where sd.orderid = oh.orderid ");
            sb.Append("and cwc.coilTagID = sd.skidid ");
            sb.Append("and cwc.coiltagsuffix = sd.coiltagsuffix ");
            sb.Append("and cwc.referenceNumber = oh.orderID ");
            sb.Append("and sd.orderid = @orderID ");
            sb.Append("and oh.machineID = ma.machineID ");
            sb.Append("group by oh.orderID, sd.skidid,sd.coiltagsuffix,cwc.previousWeight, procprice, ma.PriceMinOrder ,oh.paperprice,cwc.currentWeight ");
            sb.Append("union ");
            sb.Append("select oh.orderID, sd.skidid,sd.coiltagsuffix,procprice,cwc.previousWeight,cwc.currentWeight, ");
            sb.Append("cwc.previousWeight * procprice as ProcTotal,pg.GroupName as TotType, ");
            sb.Append("sum((sd.length * sd.width * sd.pieceCount)/144) as sqft,sd.pvcPrice as adderPrice, ");
            sb.Append("sum(((sd.length * sd.width * sd.pieceCount) / 144) * sd.pvcPrice) as TypeTotal, ma.PriceMinOrder ");
            sb.Append("from " + PlantLocation.city + ".orderhdr oh," + PlantLocation.city + ".skiddata sd, ");
            sb.Append(PlantLocation.city + ".CoilWeightChange cwc, " + PlantLocation.city + ".PVCGroup pg, ");
            sb.Append(PlantLocation.city + ".Machines ma ");
            sb.Append("where sd.orderid = oh.orderid ");
            sb.Append("and cwc.coilTagID = sd.skidid ");
            sb.Append("and cwc.coiltagsuffix = sd.coiltagsuffix ");
            sb.Append("and cwc.referenceNumber = oh.orderID ");
            sb.Append("and sd.orderid = @orderID ");
            sb.Append("and pg.GroupID = sd.pvcID ");
            sb.Append("and oh.machineID = ma.machineID ");
            sb.Append("group by oh.orderID, sd.skidid, sd.coiltagsuffix,cwc.previousWeight, procprice,");
            sb.Append("sd.pvcid, pg.GroupName, ma.PriceMinOrder, sd.pvcprice,cwc.currentWeight  ");
            sb.Append("order by sd.skidid, sd.coiltagsuffix, TotType");
            string sql = sb.ToString();

            
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            cmd.Parameters.AddWithValue("@orderID", orderID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public DbDataReader GetPricingAdders(int orderID, bool sheetInfo = false)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select ad.calcType, ");
            sb.Append("ad.adderDesc, ");
            sb.Append("ap.adderPrice,");
            sb.Append("ad.adderMin,");
            sb.Append("cwc.previousWeight,");
            sb.Append("sd.sheetWeight,");
            sb.Append("sd.length,");
            sb.Append("sd.width,");
            sb.Append("a.DensityFactor,");
            sb.Append(" c.thickness, sd.pieceCount,  ");
            sb.Append(" sd.skidID, sd.coilTagSuffix, ");
            sb.Append(PlantLocation.city + ".GetSkidWeight(sd.skidid,sd.coiltagsuffix,sd.letter) as skidWeight ");
            sb.Append("from " + PlantLocation.city + ".AdderDesc ad, ");
            if (sheetInfo)
            {
                sb.Append(PlantLocation.city + ".SheetAdderPricing ap, ");
            }
            else
            {
                sb.Append(PlantLocation.city + ".CTLAdderPricing ap, ");
            }
            
            sb.Append(PlantLocation.city + ".skiddata sd, ");
            sb.Append(PlantLocation.city + ".Alloy a, ");
            sb.Append(PlantLocation.city + ".CoilWeightChange cwc,");
            sb.Append(PlantLocation.city + ".coil c ");
            sb.Append("where ap.orderID = @orderID ");
            sb.Append("and sd.coilTagSuffix = ap.coilTagSuffix ");
            if (sheetInfo)
            {
                sb.Append("and sd.skidid = ap.skidID ");
                sb.Append("and sd.letter = ap.letter ");
            }
            else
            {
                sb.Append("and sd.skidid = ap.coilTagId ");
                sb.Append("and sd.sequenceNum = ap.sequenceNumber ");
            }
            
            sb.Append("and ad.adderid = ap.adderID ");
            sb.Append("and sd.alloyID = a.AlloyID ");
            sb.Append("and sd.skidID = cwc.coilTagID ");
            sb.Append("and sd.coilTagSuffix = cwc.coilTagSuffix ");
            sb.Append("and sd.orderID = cwc.referenceNumber ");
            sb.Append("and c.coilTagID = sd.skidid ");
            sb.Append("and c.coilTagSuffix = sd.coilTagSuffix ");
            sb.Append("order by ap.adderid, sd.skidid, sd.coilTagSuffix ");
    



            string sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            cmd.Parameters.AddWithValue("@orderID", orderID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }



        public void DeleteSheetAdderPricing(int orderID, int skidID, string coilTagSuffix, string letter, string orderLetter, int adderID, decimal price)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("delete from " + PlantLocation.city + ".SheetAdderPricing ");
            sb.Append("where orderID = @orderID and skidID = @skidID and coilTagSuffix = @coilTagSuffix ");
            sb.Append("and letter = @letter and orderLetter = @orderLetter and adderID = @adderID");

            SqlCommand cmd = new SqlCommand();
            String sql = sb.ToString();


            cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            cmd.Parameters.AddWithValue("@orderID", orderID);
            cmd.Parameters.AddWithValue("@skidID", skidID);
            cmd.Parameters.AddWithValue("@coilTagSuffix", coilTagSuffix);
            cmd.Parameters.AddWithValue("@letter", letter);
            cmd.Parameters.AddWithValue("@orderLetter", orderLetter);
            cmd.Parameters.AddWithValue("@adderID", adderID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            cmd.ExecuteNonQuery();


        }
        

        

        public DbDataReader getSkidCharges (int orderID)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("select sd.orderID,st.skidDescription,count(*) as skidCnt,sd.skidPrice, sum(sd.skidPrice) as total ");
            sb.Append("from " + PlantLocation.city + ".skiddata sd, ");
            sb.Append(PlantLocation.city + ".skidType st ");
            sb.Append("where sd.skidTypeID = st.skidTypeID ");
            sb.Append("and sd.orderID = @orderID ");
            sb.Append("and sd.skidprice > 0 ");
            sb.Append("group  by sd.orderID, st.skidDescription,sd.skidprice");

            string sql = sb.ToString();

            
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            cmd.Parameters.AddWithValue("@orderID", orderID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;

        }

        public DbDataReader getFixSkidInfo(int orderID)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("select *, " + PlantLocation.city + ".GetMaxSkid(sd.skidid,sd.coilTagSuffix) as MaxLetter ");
            sb.Append("from " + PlantLocation.city + ".skiddata sd, "+PlantLocation.city + ".alloy al, " + PlantLocation.city + ".alloyFinish af ");
            sb.Append("," + PlantLocation.city + ".orderHdr oh, " + PlantLocation.city + ".machines m ");
            sb.Append("where sd.orderid = @orderID ");
            sb.Append("and al.alloyID = sd.alloyID ");
            sb.Append("and af.finishID = sd.finishID ");
            sb.Append("and oh.orderID = sd.orderID ");
            sb.Append("and oh.machineID = m.machineID ");
            sb.Append("order by skidID, coilTagSuffix,letter");

            string sql = sb.ToString();

            
            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            cmd.Parameters.AddWithValue("@orderID", orderID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            DbDataReader reader = cmd.ExecuteReader();

            return reader;

        }

        public string getMaxCoilSuffix(int coilTagID, string coilTagSuffix)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT " + PlantLocation.city + ".[GetMaxCoilSuffix] (@tagID, @Suffix)");

            string sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn1.conn,
                CommandText = sql
            };

            if (SQLConn1.conn.State == ConnectionState.Closed)
            {
                SQLConn1.conn.Open();
            }

            cmd.Parameters.AddWithValue("@tagID", coilTagID);
            cmd.Parameters.AddWithValue("@Suffix", coilTagSuffix);

            DbDataReader reader = cmd.ExecuteReader();

            string retVal = "";

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    retVal = reader.GetString(0).Trim();
                }
            }

            return retVal;

        }

 
        public DbDataReader getRunSheetMachineMove(int machineID)
        {

            StringBuilder sb = new StringBuilder();

            //sb.Append("select m2.machineID, m2.machineName ");
            //sb.Append("from TSAMaster.processes p, " + PlantLocation.city + ".machines m1, " + PlantLocation.city + ".machines m2 ");
            //sb.Append("where p.ProcessID = m1.processID ");
            //sb.Append("and m1.machineID = @machineID ");
            //sb.Append("and m2.processID = p.ProcessID ");
            //sb.Append("and m2.machineID != m1.machineID ");


            sb.Append("select m1.machineID,m1.machineName ");
            sb.Append("from TSAMaster.Processes proc1, " + PlantLocation.city + ".machines m1 ");
            sb.Append("where proc1.ProcTypeID in ( ");
            sb.Append("select ProcTypeID from " + PlantLocation.city + ".machines ma, TSAMaster.Processes p1 ");
            sb.Append("where p1.ProcessID = ma.processID ");
            sb.Append("and ma.machineID = @machineID) ");
            sb.Append("and m1.processID = proc1.ProcessID ");
            sb.Append("and m1.machineid != @machineID ");

            string sql = sb.ToString();

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }


            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            cmd.Parameters.AddWithValue("@machineID", machineID);


            DbDataReader reader = cmd.ExecuteReader();

            return reader;

        }

        public DbDataReader CheckSkidOrderExists(int coiltagid, string coilTagSuffix, string letter)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select distinct skidid ");
            sb.Append("from " + PlantLocation.city + ".OrderPolishDtl opd, ");
            sb.Append(PlantLocation.city + ".orderhdr oh ");
            sb.Append("where opd.orderid = oh.orderid ");
            sb.Append("and oh.Status > 0 ");
            sb.Append("and opd.skidID = @tagid ");
            sb.Append("and opd.coiltagsuffix = @suffix ");
            sb.Append("and opd.skidLetter = @letter ");

            string sql = sb.ToString();

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }


            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            cmd.Parameters.AddWithValue("@tagid", coiltagid);
            cmd.Parameters.AddWithValue("@suffix", coilTagSuffix);
            cmd.Parameters.AddWithValue("@letter", letter);

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public DbDataReader CheckCoilOrderExists(int coiltagid, string coilTagSuffix)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select distinct coiltagid ");
            sb.Append("from " + PlantLocation.city + ".CTLDetail ctl, ");
            sb.Append(PlantLocation.city + ".orderhdr oh ");
            sb.Append("where ctl.orderid = oh.orderid ");
            sb.Append("and oh.Status > 0 ");
            sb.Append("and ctl.coiltagid = @tagid ");
            sb.Append("and ctl.coiltagsuffix = @suffix ");
            sb.Append("union ");
            sb.Append("select distinct coiltagid ");
            sb.Append("from " + PlantLocation.city + ".coilpolishdtl cpd, ");
            sb.Append(PlantLocation.city + ".orderhdr oh ");
            sb.Append("where cpd.orderid = oh.orderid ");
            sb.Append("and oh.Status > 0 ");
            sb.Append("and cpd.coiltagid = @tagid ");
            sb.Append("and cpd.coiltagsuffix = @suffix");

            string sql = sb.ToString();

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }


            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql
            };

            cmd.Parameters.AddWithValue("@tagid", coiltagid);
            cmd.Parameters.AddWithValue("@suffix", coilTagSuffix);

            DbDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public int DeleteCoilPolishHdr(int OrderID, SqlTransaction tran)
        {
            int orderCnt = -1;



            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from " + PlantLocation.city + ".CoilPolishHdr ");
            sb.Append("where orderID = @OrderID");
            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran,

            };
            cmd.Parameters.AddWithValue("@OrderID", OrderID);


            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }


            orderCnt = (int)cmd.ExecuteNonQuery();



            return orderCnt;
        }

        public int AddCoilPolishDtl(ClClSameDtlInfo cpInfo, SqlTransaction tran)
        {
            int hdrRecID = -1;


            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + PlantLocation.city + ".CoilPolishDtl ");
            sb.Append("(OrderID,coilTagID,coilTagSuffix,coilTagNewSuffix,polishWeight, DTLfinishID) ");
            sb.Append("output INSERTED.OrderID VALUES(@OrderID,@coilTagID,@coilTagSuffix,@coilTagNewSuffix,@polishWeight, @finishID)");
            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran,

            };
            cmd.Parameters.AddWithValue("@OrderID", cpInfo.orderID);
            cmd.Parameters.AddWithValue("@coilTagID", cpInfo.coilTagID);
            cmd.Parameters.AddWithValue("@coilTagSuffix", cpInfo.coilTagSuffix);
            cmd.Parameters.AddWithValue("@coilTagNewSuffix", cpInfo.newCoilTagSuffix);

            cmd.Parameters.AddWithValue("@polishWeight", cpInfo.Weight);
            cmd.Parameters.AddWithValue("@finishID", cpInfo.FinishID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            hdrRecID = (int)cmd.ExecuteScalar();



            return hdrRecID;
        }

        public int UpdateOrderHdr(OrderHdrInfo ordHdrInfo, SqlTransaction tran, bool onlyStatusUpdate = false)
        {
            int orderCnt = -1;



            StringBuilder sb = new StringBuilder();
            if (!onlyStatusUpdate)
            {
                sb.Append("update " + PlantLocation.city + ".OrderHdr ");
                sb.Append(" set ");
                sb.Append("CustomerPO = @CustomerPO, OrderDate = @OrderDate,PromiseDate = @PromiseDate,");
                sb.Append("Comments = @Comments, ScrapCredit = @ScrapCredit,ProcPrice = @ProcPrice, ");
                sb.Append("runSheetComments = @runsheet, paperPrice = @paperPrice ");
                sb.Append("where orderID = @ORderID");
            }
            else
            {
                sb.Append("update " + PlantLocation.city + ".OrderHdr ");
                sb.Append(" set ");
                sb.Append("status = @status ");
                sb.Append("where orderID = @ORderID");
            }
            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            if (!onlyStatusUpdate)
            {
                cmd.Parameters.AddWithValue("@CustomerPO", ordHdrInfo.CustomerPO);
                cmd.Parameters.AddWithValue("@OrderDate", ordHdrInfo.OrderDate);
                cmd.Parameters.AddWithValue("@PromiseDate", ordHdrInfo.PromiseDate);
                cmd.Parameters.AddWithValue("@Comments", ordHdrInfo.Comments);
                cmd.Parameters.AddWithValue("@ScrapCredit", ordHdrInfo.ScrapCredit);
                cmd.Parameters.AddWithValue("@ProcPrice", ordHdrInfo.ProcPrice);
                cmd.Parameters.AddWithValue("@runsheet", ordHdrInfo.runSheetComments);
                cmd.Parameters.AddWithValue("@paperPrice", ordHdrInfo.paperPrice);
            }
            else
            {
                cmd.Parameters.AddWithValue("@status", ordHdrInfo.Status);
            }
            cmd.Parameters.AddWithValue("@OrderID", ordHdrInfo.OrderID);
            cmd.Transaction = tran;

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }


            //returns record count affected
            orderCnt = (int)cmd.ExecuteNonQuery();



            return orderCnt;
        }

        public int AddCoilPolishHdr(ClClSameHdrInfo cpInfo, SqlTransaction tran)
        {
            int hdrRecID = -1;



            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + PlantLocation.city + ".CoilPolishHdr ");
            sb.Append("(OrderID,coilTagID,coilTagSuffix,previousFinish,newFinish, origWeight,polishWeight,paper) ");
            sb.Append("output INSERTED.OrderID VALUES(@OrderID,@coilTagID,@coilTagSuffix,@previousFinish,@newFinish, @origWeight,@polishWeight,@paper)");
            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran,

            };
            cmd.Parameters.AddWithValue("@OrderID", cpInfo.orderID);
            cmd.Parameters.AddWithValue("@coilTagID", cpInfo.coilTagID);
            cmd.Parameters.AddWithValue("@coilTagSuffix", cpInfo.coilTagSuffix);
            cmd.Parameters.AddWithValue("@previousFinish", cpInfo.previousFinishID);
            cmd.Parameters.AddWithValue("@newFinish", cpInfo.newFinishID);
            cmd.Parameters.AddWithValue("@origWeight", cpInfo.origWeight);
            cmd.Parameters.AddWithValue("@polishWeight", cpInfo.PolishWeight);
            cmd.Parameters.AddWithValue("@paper", cpInfo.paper);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            hdrRecID = (int)cmd.ExecuteScalar();



            return hdrRecID;
        }

        public int AddMasterOrder(int orderHdrID, int sequence, SqlTransaction tran, int masterID = -1)
        {

            StringBuilder sb = new StringBuilder();

            if (masterID == -1)
            {
                sb.Append("INSERT INTO " + PlantLocation.city + ".MasterOrder ");
                sb.Append("(orderID,sequence) ");
                sb.Append("output INSERTED.masterOrderID VALUES(@orderHdrID, @sequence)");

            }
            else
            {
                sb.Append("INSERT INTO " + PlantLocation.city + ".MasterOrder ");
                sb.Append("(masterOrderID,orderID,sequence) ");
                sb.Append("output INSERTED.masterOrderID VALUES(@masterID,@orderHdrID, @sequence)");
            }

            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            cmd.Parameters.AddWithValue("@masterID", masterID);
            cmd.Parameters.AddWithValue("@orderHdrID", orderHdrID);
            cmd.Parameters.AddWithValue("@sequence", sequence);
            cmd.Transaction = tran;

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            masterID = (int)cmd.ExecuteScalar();



            return masterID;
        }
        public int AddOrderHdr(OrderHdrInfo ordHdrInfo, SqlTransaction tran)
        {
            int OrdHdrID = -1;



            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO " + PlantLocation.city + ".OrderHdr ");
            sb.Append("(CustomerID,CustomerPO,OrderDate,PromiseDate,Status,Comments, ");
            sb.Append("ScrapCredit,CalculationType,ShipComments,MachineID,ProcPrice,Posted, ");
            sb.Append("BreakIn,RunSheetOrder,MixHeats,runSheetComments, paperPrice, onHold) ");
            sb.Append("output INSERTED.orderID ");
            sb.Append("VALUES(@CustomerID,@CustomerPO,@OrderDate,@PromiseDate,@Status,@Comments, ");
            sb.Append("@ScrapCredit,@CalculationType,@ShipComments,@MachineID,@ProcPrice,@Posted, ");
            sb.Append("@BreakIn,@RunSheetOrder,@MixHeats,@runSheet, @paperPrice, @onHold)");
            String sql = sb.ToString();



            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,


            };
            if (ordHdrInfo.runSheetComments == null)
            {
                ordHdrInfo.runSheetComments = "";
            }
            cmd.Parameters.AddWithValue("@CustomerID", ordHdrInfo.CustomerID);
            cmd.Parameters.AddWithValue("@CustomerPO", ordHdrInfo.CustomerPO);
            cmd.Parameters.AddWithValue("@OrderDate", ordHdrInfo.OrderDate);
            cmd.Parameters.AddWithValue("@PromiseDate", ordHdrInfo.PromiseDate);
            cmd.Parameters.AddWithValue("@Status", ordHdrInfo.Status);
            cmd.Parameters.AddWithValue("@Comments", ordHdrInfo.Comments);
            cmd.Parameters.AddWithValue("@ScrapCredit", ordHdrInfo.ScrapCredit);
            cmd.Parameters.AddWithValue("@CalculationType", ordHdrInfo.CalculationType);
            cmd.Parameters.AddWithValue("@ShipComments", ordHdrInfo.ShipComments);
            cmd.Parameters.AddWithValue("@MachineID", ordHdrInfo.MachineID);
            cmd.Parameters.AddWithValue("@ProcPrice", ordHdrInfo.ProcPrice);
            cmd.Parameters.AddWithValue("@Posted", ordHdrInfo.Posted);
            cmd.Parameters.AddWithValue("@BreakIn", ordHdrInfo.BreakIn);
            cmd.Parameters.AddWithValue("@RunSheetOrder", ordHdrInfo.RunSheetOrder);
            cmd.Parameters.AddWithValue("@MixHeats", ordHdrInfo.MixHeats);
            cmd.Parameters.AddWithValue("@runSheet", ordHdrInfo.runSheetComments);
            cmd.Parameters.AddWithValue("@paperPrice", ordHdrInfo.paperPrice);
            cmd.Parameters.AddWithValue("@onHold", 0);
            cmd.Transaction = tran;

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }

            OrdHdrID = (int)cmd.ExecuteScalar();



            return OrdHdrID;
        }


        public int DeleteCoilPolishDtl(int orderID, SqlTransaction tran)
        {
            int orderCnt = -1;


            StringBuilder sb = new StringBuilder();
            sb.Append("delete from " + PlantLocation.city + ".CoilPolishDtl ");
            sb.Append("where orderID = @OrderID");
            String sql = sb.ToString();

            SqlCommand cmd = new SqlCommand
            {

                // Set connection for Command.
                Connection = SQLConn.conn,
                CommandText = sql,
                Transaction = tran,

            };
            cmd.Parameters.AddWithValue("@OrderID", orderID);

            if (SQLConn.conn.State == ConnectionState.Closed)
            {
                SQLConn.conn.Open();
            }


            orderCnt = (int)cmd.ExecuteNonQuery();



            return orderCnt;
        }

    }
}
