using BusinessLogicLayer.LogicServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModelObjectLayer.CommonEntities;
using ModelObjectLayer.DataBaseEntities;

namespace Three_Tier_Architecture.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICoursesLogic _coursesLogic;

        public CoursesController(ICoursesLogic coursesLogic)
        {
            _coursesLogic = coursesLogic;
        }

        //-- Display the Course List

        [HttpGet]
        public IActionResult CoursesList()
        {

            //--Main Model
            CourseModule model = new CourseModule();     //-- Comes from Model Access layer -> Common Entities -> CourseModule

            //-- get courses list

            model.coursesList = _coursesLogic.GetCoursesListLogic().ToList();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddCourse()                       //to Add New Course Page
        {
            // Assume GetAllCourseTypesAsync returns a list of course types
            var courseTypes = await _coursesLogic.GetAllCourseTypesAsync();

            // Create SelectListItems
            var courseTypeList = courseTypes.Select(ct => new SelectListItem
            {
                Value = ct.CID.ToString(),   // Assuming CID is the ID of the course type
                Text = ct.CourseDropdown     // Assuming CourseDropdown is the name of the course type
            }).ToList();

            // Set up the Courses model to pass to the view
            var model = new Courses
            {
                CourseType = courseTypeList,
                SelectedValue = "1" // Default selected value (for example, "BCA")
            };

            return View(model);


            //var courseTypes = (await _coursesLogic.GetAllCourseTypesAsync()).Select(ct => new SelectListItem
            //{
            //    Value = ct.CID.ToString(),
            //    Text = ct.CourseDropdown
            //}).ToList();

            //var model = new Courses
            //{
            //    CourseType = courseTypes,
            //    SelectedValue = "1" // Default selected value
            //};
            //return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> AddCoursePost(CourseTypeDropdown model,Courses formData)
        {
            //--Save Course Record

            if (ModelState.IsValid)
            {
                string result = _coursesLogic.SaveCourseRecordLogic(formData);


                if (result == "Saved Successfully")
                {

                    return RedirectToAction("CoursesList", "Courses");
                }
                else
                {
                    TempData["ErrorTemp"] = result;
                    return RedirectToAction("AddCourse", "Courses");
                }
            }
            // Reload the course types in case of validation error

          //  model.CourseTypes = (await _coursesLogic.GetAllCourseTypesAsync()).Select(ct => new SelectListItem
            var courseTypes = (await _coursesLogic.GetAllCourseTypesAsync()).Select(ct => new SelectListItem
            {
                Value = ct.CID.ToString(),
                Text = ct.CourseDropdown
            }).ToList();

            return View("AddCourse", formData);

        }


    
        //[HttpGet]
        //public async Task<IActionResult> BindDropdown(string selectedValue)
        //{
        //    try
        //    {
        //        if (HttpContext.Session.GetString("UserName") != null)
        //        {
        //            var data = await _coursesLogic.GetBindCourse(selectedValue);
        //            ViewBag.SelectedValue = selectedValue;
        //          //  return PartialView("_ClaimListPartial", data);
        //        }
        //        return RedirectToAction("Login", "Account", new { area = "" });
        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(500, $"An error occurred while BindDropdown Method called For Claim Status: {ex.Message}");
        //    }
        //}


        //[HttpPost]

        //public async Task<IActionResult> ClaimUploadFile(IFormFile file, string claimNotes, int claimId)
        //{
        //    try
        //    {
        //        if (HttpContext.Session.GetString("UserName") != null)
        //        {
        //            bool fileUploadResult = false;
        //            bool messageUploadResult = false;

        //            // Upload file if provided
        //            if (file != null && file.Length > 0)
        //            {
        //                fileUploadResult = await _coursesLogic.ClaimUploadFiles(file, claimId);
        //            }

        //            // Upload claim notes if provided
        //            if (!string.IsNullOrEmpty(claimNotes))
        //            {
        //                messageUploadResult = await _coursesLogic.ClaimUploadMessages(claimNotes, claimId);
        //            }

        //            // Check if either upload was successful
        //            if (fileUploadResult || messageUploadResult)
        //            {
        //                return Json(new { successMessage = "File uploaded successfully!" });
        //                //return RedirectToAction("SearchClaim", "User", new { area = "UserArea" });
        //            }
        //            else
        //            {
        //                return Json(new { errorMessage = "Error uploading file:  File And Notes Are Missing ! " });
        //                //return View("SearchClaim"); // You might want to handle failure more gracefully
        //            }
        //        }
        //        else
        //        {
        //            return RedirectToAction("Login", "Account", new { area = "" });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { errorMessage = "Error uploading file: " + ex.Message });
        //    }
        //}

    }
}
