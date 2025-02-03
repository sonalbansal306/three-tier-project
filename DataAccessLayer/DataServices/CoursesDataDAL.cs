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
    public class CoursesDataDAL : ICoursesDataDAL
    {
        private readonly IDapperOrmHelper _dapperOrmHelper;

        
        public CoursesDataDAL(IDapperOrmHelper dapperOrmHelper)
        {
            _dapperOrmHelper = dapperOrmHelper;
        }

        //-- Add Function for Database Communication and show Listing

        public List<Courses> GetCoursesListDAL()   //-- Students is  basically a Entity in ModelObjectLayer -> DatabaseEntities -> Students.cs Class.
                                                     //-- List<Students> GetStudentsListDAL() add this function in IStudentDataDAL.cs
        {
            List<Courses> courses = new List<Courses>();   //Write some database expression
            try
            {
                using (IDbConnection dbConnection = _dapperOrmHelper.GetDapperContextHelper())
                {
                    string SqlQuery = "select * from Courses";
                    courses = dbConnection.Query<Courses>(SqlQuery, commandType: CommandType.Text).ToList();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            
            return courses;

        }

        //-- Add New Course Student 

        public string SaveCourseRecordDAL(Courses formData)
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

                    dbConnection.Execute(@"dbo.AddCourse",
                        new
                        {
                            FirstName = formData.FirstName,
                            LastName = formData.LastName,
                            EmailId = formData.EmailId, 
                            Address= formData.Address,
                            CourseType= formData.SelectedValue,
                            UploadDocument= formData.UploadDocument
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
        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null)
        {
            return await _connection.QueryAsync<T>(sql, parameters);
        }
        public async Task<IEnumerable<CourseTypeDropdown>> GetAllCourseTypesAsync()
        {
                    
                    string query = "SELECT * FROM CourseTypes";            
                    return await _dapperOrmHelper.QueryAsync<CourseTypeDropdown>(query);
        }

    }

}

