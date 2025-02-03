using ModelObjectLayer.DataBaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.LogicServices
{
    public interface IStudentsLogic
    {
        List<Students> GetStudentsListLogic();   //-- Added the Signature for GetStudentsListLogic and it comes from StudentLogic.cs
        string SaveStudentRecordLogic(Students FormData);

    }
}
