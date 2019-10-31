using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This reads Supersavers serial_num and seqno from DB

namespace Cinemark.DataBase
{
    class ReadDB
    {
        public static CouponCode FetchInfo()
        {
            //var con = ConfigurationManager.ConnectionStrings["Yourconnection"].ToString();
            var con = @"Data Source=usvir04403\sql2k12_qa;Initial Catalog=super_saver;Integrated Security=True";

            CouponCode coupon  = new CouponCode();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "SELECT TOP 1 serial_num, seqno FROM super_saver WHERE 1 = 1 AND super_saver_type_id = 4 AND redeemable = 1 AND void = 0 AND is_ test = 0 AND is_deleted = 0 AND active = 1 AND seqno IS NOT NULL";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        coupon.SerialNum = oReader["serial_num"].ToString();
                        coupon.SeqNo = oReader["seqno"].ToString();
                        
                    }

                    myConnection.Close();
                }
            }
            return coupon;
        }
    }
}
