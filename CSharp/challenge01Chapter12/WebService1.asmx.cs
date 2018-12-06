using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
namespace challenge01Chapter12
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

       
        [WebMethod]
        public string Add(int IdStudent, string NameStudent)
        {


           
                SchoolEntity school = new SchoolEntity();
                
                Students student = new Students();
                student.StudentId = IdStudent;
                student.StudentName = NameStudent;
                //version 3.5 is school.AddToStudents and 4.6 version is school.Students.Add
                school.AddToStudents(student);
                school.SaveChanges();


            return "Ok";
            
        }

        [WebMethod]
        public string ReadAll()
        {

            SchoolEntity school = new SchoolEntity();

            List<StudentS> studentS = new List<StudentS>();
            StudentS stu = null;
            foreach(var s in school.Students)
            {
                stu = new StudentS
                {
                    IdStudent = s.StudentId,
                    NameStudent = s.StudentName
                };

                studentS.Add(stu);
            }

            string jsonStudents = JsonConvert.SerializeObject(studentS);

            return jsonStudents;
        }

        class StudentS
        {
            public int IdStudent { get; set; }
            public string NameStudent { get; set; }
        }
    }
}
