using ModelObjectLayer.DataBaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataServices
{
    public interface ICoursesDataDAL
    {
        List<Courses> GetCoursesListDAL();       //-- Added the Signature for GetStudentsListDAL and it comes from IStudentDataDAL.cs
        string SaveCourseRecordDAL(Courses formData);
        Task<IEnumerable<CourseTypeDropdown>> GetAllCourseTypesAsync();
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null);
    }
}
