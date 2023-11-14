using Common.Functions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.StoredProcedures
{
    public static class CourseStudentQuestionsUnVerifyAnswerCountProcedure
    {
        public static void Execute()
        {
            try
            {
                var sqlConnection = new SqlConnection(AppConfigProvider.GetConnectionString());
                sqlConnection.Open();
                var sqlCommand = new SqlCommand("EXEC [dbo].[sp_CourseStudentQuestionsUnVerifyAnswerCount]", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex) { }
        } 
    }
}
