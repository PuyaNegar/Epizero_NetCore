using System;
using Common.Functions;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer.StoredProcedures
{
    public class TeacherPaymentMethodUpdaterProcedure
    {
        public static void Execute(int teacherUserId , int courseId )
        {
            try
            {
                var sqlConnection = new SqlConnection(AppConfigProvider.GetConnectionString());
                sqlConnection.Open();
                var sqlCommand = new SqlCommand("EXEC [dbo].[sp_teacherPaymentMethodUpdater] " + teacherUserId + ", " +  courseId, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex) { }
        }
    }
}
