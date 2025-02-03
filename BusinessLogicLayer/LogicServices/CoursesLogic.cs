using Microsoft.AspNetCore.Http;
using DataAccessLayer.DataServices;
using ModelObjectLayer.DataBaseEntities;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.LogicServices
{
    public class CoursesLogic : ICoursesLogic
    {
        public readonly ICoursesDataDAL _coursesDataDAL;
       // private readonly IHttpContextAccessor _contextAccessor;

        public CoursesLogic(ICoursesDataDAL coursesDataDAL)
        {
            this._coursesDataDAL = coursesDataDAL;
            //_contextAccessor = contextAccessor;
        }


        //-- Function for getting the Course List from database and
        //-- [ List<Courses> GetStudentsListLogic() ] defining Signature of Interface in IStudentsLogic.cs

        public List<Courses> GetCoursesListLogic()        //--Students is  basically a Entity in ModelObjectLayer -> DatabaseEntities -> Students.cs Class.
        {
            List<Courses> result = new List<Courses>();
            result = _coursesDataDAL.GetCoursesListDAL();      //-- get this GetStudentsListDAL() from DataAccessLayer
            return result;
        }


        //-- Add New Course
        public string SaveCourseRecordLogic(Courses formData)
        {

            //--Call Data Access Layer() for inserting the Course object

            string result = _coursesDataDAL.SaveCourseRecordDAL(formData);
            if (result == "Saved Successfully")
            {
                return result;
            }
            else
            {
                result = "An error occured.Please try again.";
                return result;
            }
            

        }

        public async Task<IEnumerable<CourseTypeDropdown>> GetAllCourseTypesAsync()
        {
            return await _coursesDataDAL.GetAllCourseTypesAsync();
        }
    }

    //public async Task<List<Courses>> GetBindCourse(string selectedValue)
    //{
    //    try
    //    {
    //        var courseId = _contextAccessor.HttpContext.Session.GetInt32("CoursesId");
    //        // string courseName = await GetCompanyName();
    //        string firstName = "";
    //        string lastName = ""; // Implement this method as needed              


    //    }
    //    catch (Exception)
    //    {

    //        throw;
    //    }
    //}


    //public async Task<bool> ClaimUploadFiles(IFormFile file, int claimId)
    //{
    //    try
    //    {
    //       // var courseId = _contextAccessor.HttpContext.Session.GetInt32("ClientId");
    //       // var companyName = await GetCompanyName();
    //       // var courseId = _contextAccessor.HttpContext.Session.GetInt32("CoursesId");
    //       // var clientName = await GetUserFullName(userId);
    //       // var claimentFullName = await ClaimentFullName(claimId);
    //        if (file == null || file.Length == 0)
    //        {
    //            return false;
    //        }
    //        string extension = Path.GetExtension(file.FileName).ToLower();
    //        if (extension != ".pdf" && extension != ".jpg" && extension != ".txt" && extension != ".docx" && extension != ".png" && extension != ".jpeg")
    //        {
    //            return false;
    //        }
    //        //string fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
    //        string fileName = Path.GetFileNameWithoutExtension(file.FileName) + "_" + DateTime.Now.Ticks + extension;
    //        string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", fileName);
    //        using (var stream = new FileStream(path, FileMode.Create))
    //        {
    //            file.CopyTo(stream);
    //        }
    //        string uri = "C:/Three_Tier_Architecture/Uploads/";
    //        var fileNameParam = new SqlParameter("@UploadFileName", fileName);
    //       // var claimIdParam = new SqlParameter("@ClaimId", claimId);
    //       // var clientNameParam = new SqlParameter("@ClientName", clientName);
    //        var siteUrlParam = new SqlParameter("@SiteUrl", uri);

    //      //  var result = await _coursesDataDAL.Database.ExecuteSqlRawAsync("EXEC sp_ClaimsDocument @UploadFileName, @ClaimId, @ClientName, @SiteUrl", fileNameParam, claimIdParam, clientNameParam, siteUrlParam);
    //        //if (result > 0)
    //        //{
    //        //    //var claimentFirstName = result.FirstName
    //        //    List<string> Files = new List<string>();

    //        //    Files.Add(fileName);
    //        //    var clientIdParam = new SqlParameter("@ClientId", clientId);
    //        //    var getEmail = await _context.Database.ExecuteSqlRawAsync($"Exec sp_GetExaminarEmail @ClientId", clientIdParam);
    //        //    if (getEmail > 0)
    //        //    {
    //        //        var getEmailId = await _context.EmailId.Select(x => x.AnalystEmailId).FirstOrDefaultAsync();

    //        //        // Create HTML email template
    //        //        string emailBody = CreateEmailBodyForClaims(claimentFullName, Files, companyName);
    //        //        // Send email
    //        //        SendEmailForClaims(getEmailId, "Claims File Upload for " + companyName, emailBody, Files);
    //        //        return true;
    //        //    }
    //        //    return false;
    //        //}
    //        return false;
    //    }
    //    catch (Exception)
    //    {
    //        throw;
    //    }
    //}
}

