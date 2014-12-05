using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using Mono.Security;

namespace StudentModal
{
    
    public class studentHelper
    {
        //private static readonly string conStr = ConfigurationManager.ConnectionStrings["conSQL"].ToString();
        private static readonly string conStr = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=123456;Database=STUDENT;";
        private List<studentModal> studentList = new List<studentModal>();
        //private string sql = "select * from Student";
        /// <summary>
        /// 得到所有数据----modal
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>模型</returns>
        public List<studentModal> getAllStudentInfo(string sql,params NpgsqlParameter[] parameters)
        {
            using(NpgsqlConnection con=new NpgsqlConnection(conStr))
            {
                con.Open();
                using (NpgsqlCommand cmd =new NpgsqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parameters);
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    //从dataTable中读取数据形成modal
                    DataTable dataTable=dataSet.Tables[0];
                    int tableRow = dataTable.Rows.Count;
                    for (int i = 0; i < tableRow; i++)
                    {
                        studentModal student = new studentModal();
                        student.Name = dataTable.Rows[i]["Name"].ToString();
                        student.Number =Convert.ToInt32( dataTable.Rows[i]["Number"]);//需要处理为int
                        student.TelePhone = dataTable.Rows[i]["TelePhone"].ToString();
                        studentList.Add(student);
                    }
                    return studentList;
                }
            }
        }

        ////转换为object或者为空
        //private object FromDBValue(this object obj)
        //{
        //    return obj == DBNull.Value ? null : obj;
        //}
        ///// <summary>
        ///// 转换为数据库中的null值
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <returns></returns>
        //private object ToDBValue(this object obj)
        //{
        //    return obj == null ? DBNull.Value : obj;
        //}

    }
}
