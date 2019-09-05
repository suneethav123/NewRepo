using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

// This reads Giftcard gc_id from giftcard DB

namespace Cinemark.DataBase
{
    class ReadDBForGiftCard
    {
        public static GiftCardCode FetchInfo()
        {
            //var con = ConfigurationManager.ConnectionStrings["Yourconnection"].ToString();
            var con = @"Data Source=usvir04403\sql2k12_qa;Initial Catalog=giftcard;Integrated Security=True";

            GiftCardCode GCCode = new GiftCardCode();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "select top 1 * from giftcard where void = 0 and active = 1 and test_card = 0 and email = '' and total_amount <= 100";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);

                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        GCCode.gc_id = oReader["gc_id"].ToString();


                    }

                    myConnection.Close();
                }
            }
            return GCCode;
        }
    }
}