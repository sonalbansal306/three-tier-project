using Microsoft.AspNetCore.Http;
using ModelObjectLayer.DataBaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.LogicServices
{
    public interface ICoursesLogic
    {
        List<Courses> GetCoursesListLogic();   //-- Added the Signature for GetCoursesListLogic and it comes from CoursesLogic.cs
        string SaveCourseRecordLogic(Courses formData);
        Task<IEnumerable<CourseTypeDropdown>> GetAllCourseTypesAsync();

        // Task<List<Courses>> GetBindCourse(string selectedValue);

        //Task<bool> ClaimUploadFiles(IFormFile file, int claimId);
        //Task<bool> ClaimUploadMessages(string claimNotes, int claimId);
    }
}
