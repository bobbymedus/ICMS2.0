using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;


namespace ICMS
{
    class OrderPVC
    {

        private readonly DataTable t = new DataTable();
        private DBUtils db = new DBUtils();

        private void PVCOrderSetup()
        {
            t.Columns.Add("PVCID", typeof(Int32));
            t.Columns.Add("GroupID", typeof(Int32));
            t.Columns.Add("GroupName", typeof(string));
            t.Columns.Add("ItemDesc", typeof(string));
            t.Columns.Add("Length", typeof(Int32));
            t.Columns.Add("Width", typeof(decimal));
            t.Columns.Add("Price", typeof(decimal));
        }

        public void OpenSQLConn()
        {

            
            db.OpenSQLConn();
        }
        public void CloseSQlConn()
        {
            db.CloseSQLConn();
        }
        public void LoadPVC()
        {

            if (t.Columns.Count == 0)
            {
                PVCOrderSetup();
            }




            using (DbDataReader reader = db.GetPVCInventory())
            {
                if (reader.HasRows)
                {
                    DataRow newRow = t.NewRow();
                    while (reader.Read())
                    {
                        newRow = t.NewRow();

                        newRow["PVCID"] = reader.GetInt32(reader.GetOrdinal("PVCTagID"));
                        newRow["GroupID"] = reader.GetInt32(reader.GetOrdinal("GroupID"));

                        newRow["GroupName"] = reader.GetString(reader.GetOrdinal("GroupName"));
                        newRow["ItemDesc"] = reader.GetString(reader.GetOrdinal("ItemDesc"));
                        newRow["Length"] = reader.GetInt32(reader.GetOrdinal("CurrentLength"));
                        newRow["Width"] = reader.GetDecimal(reader.GetOrdinal("PVCWidth"));
                        newRow["Width"] = reader.GetDecimal(reader.GetOrdinal("Price"));

                        t.Rows.Add(newRow);
                    }
                }
                reader.Close();
            }

        }

        public int updateLength(int PVCID, int newLength)
        {
            DataRow foundrows;

            foundrows = t.Select("PVCID = " + PVCID.ToString()).FirstOrDefault() ;

            foundrows["Length"] = newLength;

            return newLength;
        }

        public DataRow[] PVCID(int PVCID)
        {
            DataRow[] foundrows;

            foundrows = t.Select("PVCID = " + PVCID.ToString());

            return foundrows;
        }

        public DataRow[] GroupID(decimal GroupID)
        {
            DataRow[] foundrows;

            foundrows = t.Select("GroupID = " + GroupID.ToString());

            return foundrows;
        }
        public DataRow[] ExactWidth(decimal width)
        {
            DataRow[] foundrows;

            foundrows = t.Select("Width = " + width.ToString());

            return foundrows;
        }

        public DataRow[] GreaterThanWidth(decimal width)
        {
            DataRow[] foundrows;

            foundrows = t.Select("Width >= " + width.ToString());

            return foundrows;
        }
        public DataRow[] LessThanWidth(decimal width)
        {
            DataRow[] foundrows;

            foundrows = t.Select("Width <= " + width.ToString());

            return foundrows;
        }
    }
}
