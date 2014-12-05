
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mono.Security;
using StudentModal;

namespace DAL
{
    public class GetStudentInfo
    {
        /// <summary>
        /// 构建sql语句，然后得到数据
        /// </summary>
        string sql = "select * from ";
        public List<studentModal> GetAllStudentInfoDAL(string dataTable)
        {
            StudentModal.studentHelper studentHelper = new studentHelper();
            return studentHelper.getAllStudentInfo(sql+dataTable);
        }
    }
}
