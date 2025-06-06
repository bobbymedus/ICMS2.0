using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static System.Windows.Forms.Design.AxImporter;
using System.Globalization;
using System.Security.Cryptography;
using System.Runtime.InteropServices.WindowsRuntime;

namespace ICMS
{
    class DBSQLServerUtils
    {

        public static string dbpwd;
        public static string user;
        public const string KEY = "ads;fljasdftoaeTASD;lasdkjasl;dkfjasdf;lkjasdfewqt3l;aknvsviopiasteu";


        public static string EncodePWD(string uncodedPWD, string keyVal = "NOPE")
        {
            string retVal = "";
            if (keyVal.Equals("NOPE"))
            {
                keyVal = KEY;
            }
            for (int i = 0; i < uncodedPWD.Length; i++)
            {
                char c = uncodedPWD[i];
                char k = keyVal[i];

                int e = (int)c + ((int)k - 64);
                retVal += (char)e;

            }

            return retVal;

        }

        public static string DecodePWD(string uncodedPWD, string keyVal = "NOPE")
        {
            string retVal = "";
            if (keyVal.Equals("NOPE"))
            {
                keyVal = KEY;
            }
            for (int i = 0; i < uncodedPWD.Length; i++)
            {
                char c = uncodedPWD[i];
                char k = keyVal[i];

                int e = (int)c - ((int)k - 64);
                retVal += (char)e;

            }

            return retVal;

        }

        










        //Private Function decodePWD(codedPWD As String) As String


        //    Dim intLooper As Integer
        //    Dim strPWD As String
        //    Dim strKey As String
        //    Dim strTmp As String


        //    strPWD = ""
        //    intLooper = 1
        //    dbpwd = ""
        //    Do While intLooper > 0

        //        strPWD = Mid(codedPWD, intLooper, 1)
        //        strKey = Chr((Asc(strPWD) - (Asc(Mid(KEY, intLooper, 1)) - 64)))
        //        dbpwd = dbpwd + strKey
        //        intLooper = intLooper + 1
        //        If intLooper > Len(codedPWD) Then
        //            intLooper = 0
        //        End If


        //    Loop

        //End Function


        public static SqlConnection
                GetDBConnection(string datasource, string database, string username, string password)
                {
            
                    string connString = @"Data Source=" + datasource + ";Initial Catalog="
                                + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

                    


                    SqlConnection conn = new SqlConnection(connString);

            
            
                    return conn;
                }
    }
}
