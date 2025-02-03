using ModelObjectLayer.DataBaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelObjectLayer.CommonEntities
{
    public class StudentModule
    {
        //-- Import these two Entities(Student and Courses) from DataBaseEntities folder
        public List<Students> studentsList { get; set; } 
       
    }
}
