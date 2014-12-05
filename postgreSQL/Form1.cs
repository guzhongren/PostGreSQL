using StudentModal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace postgreSQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<studentModal> studentListBLL = new List<studentModal>();
            BLL.StudentBLL studentBLL = new BLL.StudentBLL();
            studentListBLL= studentBLL.GetStudentListBLL();
            dataGridView1.Rows.Add(studentListBLL.Count);
            for (int j = 0; j < studentListBLL.Count; j++)
            {
                studentModal studentModal = studentListBLL[j];
                dataGridView1.Rows[j].Cells[0].Value = studentModal.Name;
                dataGridView1.Rows[j].Cells[1].Value = studentModal.Number;
                dataGridView1.Rows[j].Cells[2].Value = studentModal.TelePhone;
                //dataGridView1.Rows.Add(1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //StudentModal.studentHelper helper = new studentHelper();
            //List<studentModal> list= helper.getAllStudentInfo("select * from Student");
            //Console.WriteLine("dfdfd");
        }
    }
}
