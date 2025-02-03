using BusinessLogicLayer.LogicServices;
using DataAccessLayer.DataServices;
using Microsoft.AspNetCore.Mvc;
using ModelObjectLayer.CommonEntities;
using ModelObjectLayer.DataBaseEntities;

namespace Three_Tier_Architecture.Controllers
{
    public class StudentsController : Controller
    {
        //-- Add the Interface of Business Logic layer

        private readonly IStudentsLogic _studentsLogic;

        //-- Create the constructor for StudentController Class and pass Interface and parameter 
        public StudentsController(IStudentsLogic studentsLogic)
        {
            _studentsLogic = studentsLogic;
        }

        //-- Display the Student List

        [HttpGet]
        public IActionResult StudentsList()
        {

            //--Main Model
            StudentModule model = new StudentModule();     //-- Comes from Model Access layer -> Common Entities -> StudentModule

            //-- get students list

            model.studentsList = _studentsLogic.GetStudentsListLogic().ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult AddStudent()
        {


            return View();
        }

        [HttpPost]
         public IActionResult AddStudentPost(Students FormData)
        {
            //--Save Student Record

            string result = _studentsLogic.SaveStudentRecordLogic(FormData);

         
             if (result == "Saved Successfully")
             {

                 // Return a success response to the client
                 return Json(new { status = "success", message = "Student record saved successfully!" });
             }
             else
             {
                 // Return an error response to the client
                 return Json(new { status = "error", message = result });
             }
        }
    
    }
}
