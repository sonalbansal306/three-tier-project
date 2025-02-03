using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ModelObjectLayer.DataBaseEntities
{
    public class Courses
    {
       
        public int CoursesId { get; set; }        
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailId { get; set; }
        public string? Address { get; set; }
        public string SelectedValue { get; set; }
        public List<SelectListItem> CourseType { get; set; }      
        // public int CID { get; set; }
        //public string CourseDropdown { get; set; }
        public IFormFile UploadDocument { get; set; }

    }
}
