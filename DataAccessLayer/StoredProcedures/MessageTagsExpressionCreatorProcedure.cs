using Common.Functions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.StoredProcedures
{
    public class MessageTagsExpressionCreatorProcedure
    {
        public static void Execute(int MessageId   )
        {
            try
            {
                var sqlConnection = new SqlConnection(AppConfigProvider.GetConnectionString());
                sqlConnection.Open();
                var sqlCommand = new SqlCommand("EXEC [dbo].[sp_MessageTagsExpressionCreator] " + MessageId.ToString(), sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex) { }
        }
    }
}
