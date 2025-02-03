using DataAccessLayer.DataServices;
using ModelObjectLayer.DataBaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.LogicServices
{
    public class StudentsLogic : IStudentsLogic
    {
        //-- Dependency Injection

        public readonly IStudentsDataDAL _studentDataDAL;

        //-- Creates the constructor for the Class StudentsLogic and pass Interface and parameter 
        public StudentsLogic(IStudentsDataDAL studentDataDAL)
        {
            this._studentDataDAL = studentDataDAL;
        }

        //-- Function for getting the Student List from database and
        //-- [ List<Students> GetStudentsListLogic() ] defining Signature of Interface in IStudentsLogic.cs

        public List<Students> GetStudentsListLogic()        //--Students is  basically a Entity in ModelObjectLayer -> DatabaseEntities -> Students.cs Class.
        {
            List<Students> result = new List<Students>();
            result = _studentDataDAL.GetStudentsListDAL();      //-- get this GetStudentsListDAL() from DataAccessLayer
            return result;
        }

        //-- Add New Student
        public string SaveStudentRecordLogic(Students FormData)
        {           

            //--Call Data Access Layer() for inserting the student object
            
           string result = _studentDataDAL.SaveStudentRecordDAL(FormData);          
           return result;
            
        }
    }
}
