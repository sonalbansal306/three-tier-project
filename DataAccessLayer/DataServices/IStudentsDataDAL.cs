using ModelObjectLayer.DataBaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataServices
{
    public interface IStudentsDataDAL
    {
        List<Students> GetStudentsListDAL();       //-- Added the Signature for GetStudentsListDAL and it comes from IStudentDataDAL.cs
        string SaveStudentRecordDAL(Students FormData);
    }
}
