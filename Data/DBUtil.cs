using ImageMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;

namespace ImageMVC.Data
{
    public class DBUtil
    {
        public List<Student> GetStudentList()
        {
            List<Student> studentList = new List<Student>();
            OdbcConnection conn = new OdbcConnection("DSN=MySQL_Local;Uid=root;Pwd=Welcome@123;Database=ProjectZero");
            conn.Open();
            OdbcCommand comm = conn.CreateCommand();
            comm.CommandText = "SELECT * FROM Student";
            OdbcDataAdapter adapter = new OdbcDataAdapter(comm);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            conn.Close();
            // comm.ExecuteNonQuery();
            //comm.executescalar();
            //comm.executereader();

            //Read data from DataSet
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Student std = new Student();
                    std.StudentId = Convert.ToInt16(dt.Rows[i]["StudentID"]);
                    std.StudentName = dt.Rows[i]["StudentName"].ToString();
                    std.Age = Convert.ToInt16(dt.Rows[i]["Age"]);
                    std.Degree = dt.Rows[i]["Degree"].ToString();
                    std.Marks = Convert.ToInt16(dt.Rows[i]["Marks"]);
                    studentList.Add(std);

                }
            }
            return studentList;

        }
        public void UpdateStudentDetails(Student st)
        {
            //List<Student> studentList = new List<Student>();
            OdbcConnection conn = new OdbcConnection("DSN=MySQL_Local;Uid=root;Pwd=Welcome@123;Database=ProjectZero");
            conn.Open();
            OdbcCommand comm = conn.CreateCommand();
            comm.CommandText = "UPDATE Student  SET STUDENTNAME=' " + st.StudentName + "',AGE= " + st.Age + ", DEGREE='" + st.Degree + "',MARKS=" + st.Marks + " WHERE StudentID= " + st.StudentId;
            comm.CommandText = "insert into Student  ( STUDENTNAME,AGE,DEGREE,MARKS) values (' " + st.StudentName + "', " + st.Age + ", '" + st.Degree + "'," + st.Marks + " )";
            comm.ExecuteNonQuery();
            conn.Close();
        }
        public Student SingleStudent(int id)
        {
            Student student = new Student();
            OdbcConnection conn = new OdbcConnection("DSN=MySQL_Local;Uid=root;Pwd=Welcome@123;Database=ProjectZero");
            conn.Open();
            OdbcCommand comm = conn.CreateCommand();
            comm.CommandText = "SELECT *FROM Student WHERE StudentId= " + id;
            OdbcDataAdapter adapter = new OdbcDataAdapter(comm);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            //comm.Executescalar();
            //comm.ExecuteNonQuery();
            conn.Close();

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                //for (int i = 0; i < dt.Rows.Count; i++)

                Student std = new Student();
                std.StudentId = Convert.ToInt16(dt.Rows[0]["StudentID"]);
                std.StudentName = dt.Rows[0]["StudentName"].ToString();
                std.Age = Convert.ToInt16(dt.Rows[0]["Age"]);
                std.Degree = dt.Rows[0]["Degree"].ToString();
                std.Marks = Convert.ToInt16(dt.Rows[0]["Marks"]);
                student = std;
            }

            return student;


        }
      
        
        
        public void DeleteStudent(int id)
        {
            Student student = new Student();
            OdbcConnection conn = new OdbcConnection("DSN=MySQL_Local;Uid=root;Pwd=Welcome@123;Database=ProjectZero");
            conn.Open();
            OdbcCommand comm = conn.CreateCommand();
            comm.CommandText = "DELETE FROM Student WHERE StudentId= " + id;
            comm.ExecuteNonQuery();
            //OdbcDataAdapter adapter = new OdbcDataAdapter(comm);
            //DataSet ds = new DataSet();
            //adapter.Fill(ds);
            conn.Close();
            
        }
        public void CreateStudentDetails(Student st)

        {
            //List<Student> studentList = new List<Student>();
            OdbcConnection conn = new OdbcConnection("DSN=MySQL_Local;Uid=root;Pwd=Welcome@123;Database=ProjectZero");
            conn.Open();
            OdbcCommand comm = conn.CreateCommand();
            //comm.CommandText = "UPDATE Student  SET STUDENTNAME=' " + st.StudentName + "',AGE= " + st.Age + ", DEGREE='" + st.Degree + "',MARKS=" + st.Marks + " WHERE StudentID= " + st.StudentId;
            comm.CommandText = "insert into Student  ( STUDENTNAME,AGE,DEGREE,MARKS) values (' " + st.StudentName + "', " + st.Age + ", '" + st.Degree + "'," + st.Marks + " )";
            comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}

