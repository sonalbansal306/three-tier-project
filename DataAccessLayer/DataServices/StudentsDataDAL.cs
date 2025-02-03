using Dapper;
using DataAccessLayer.DataContext;
using ModelObjectLayer.DataBaseEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataServices
{
    public class StudentsDataDAL : IStudentsDataDAL
    {
        private readonly IDapperOrmHelper _dapperOrmHelper;
        public StudentsDataDAL(IDapperOrmHelper dapperOrmHelper)
        {
            _dapperOrmHelper = dapperOrmHelper;
        }

        //-- Add Function for Database Communication

        public List<Students> GetStudentsListDAL()   //-- Students is  basically a Entity in ModelObjectLayer -> DatabaseEntities -> Students.cs Class.
                                                     //-- List<Students> GetStudentsListDAL() add this function in IStudentDataDAL.cs
        {
            List<Students> students = new List<Students>();   //Write some database expression
            try
            {
                using (IDbConnection dbConnection = _dapperOrmHelper.GetDapperContextHelper())
                {
                    string SqlQuery = "select * from Students";
                    students = dbConnection.Query<Students>(SqlQuery, commandType: CommandType.Text).ToList();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            return students;

        }

        //-- Add New Student 
        public string SaveStudentRecordDAL(Students FormData)
        {
            string result = string.Empty;

            try
            {
                using (IDbConnection dbConnection = _dapperOrmHelper.GetDapperContextHelper())
                {
                    // Ensure the connection is open before executing
                    if (dbConnection.State == ConnectionState.Closed)
                    {
                        dbConnection.Open();
                    }

                    dbConnection.Execute(@"dbo.AddStudent",
                        new
                        {
                            FirstName = FormData.FirstName,
                            LastName = FormData.LastName,
                            Email = FormData.Email
                        },
                        commandType: CommandType.StoredProcedure);
                    result = "Saved Successfully";
                }
            }
            catch (Exception ex)
            {
                 string message = ex.Message;
               
            }

            return result;

        }
    }
}


