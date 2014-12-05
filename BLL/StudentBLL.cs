using DAL;
using StudentModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class StudentBLL
    {
        private string dataTable = "Student";
        /// <summary>
        /// 从DAL中得到所需数据，供UI调用
        /// </summary>
        /// <returns></returns>
        public List<studentModal> GetStudentListBLL()
        {
            DAL.GetStudentInfo studentInfo = new GetStudentInfo();
            return studentInfo.GetAllStudentInfoDAL(dataTable);
        }
        
    }
}
