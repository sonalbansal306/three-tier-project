using ModelObjectLayer.DataBaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelObjectLayer.CommonEntities
{
    public class CourseModule
    {
        //-- Import these two Entities(Courses) from DataBaseEntities folder
        public List<Courses> coursesList { get; set; }
    }
}
