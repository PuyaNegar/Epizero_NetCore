using Common.Functions;
using Microsoft.Data.SqlClient;
using System; 

namespace DataAccessLayer.StoredProcedures
{
    public static class TeacherPaymentMethodBatchUpdater
    {
        public static void Execute(int teacherUserId)
        {
            try
            {
                var sqlConnection = new SqlConnection(AppConfigProvider.GetConnectionString());
                sqlConnection.Open();
                var sqlCommand = new SqlCommand("EXEC [dbo].[sp_teacherPaymentMethodBatchUpdater] " + teacherUserId  , sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex) { }
        } 
    }
}
