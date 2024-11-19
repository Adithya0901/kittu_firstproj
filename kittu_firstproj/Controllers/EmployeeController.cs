using Dapper;
using kittu_firstproj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Web.Mvc;

namespace kittu_firstproj.Controllers
{
    
    public class EmployeeController : Controller
    {
        private static string connstr = "Data Source=IN-H9BNVP3\\SQLEXPRESS;Initial Catalog=kittu_emp;Persist Security Info=True;Integrated Security=true;TrustServerCertificate=True\r\n";
        public IActionResult Employee()
        {
            return View();
        }

        [AjaxOnly]
        public JsonResult insertemployee( EmployeeModel emp) {
            SqlConnection con = new SqlConnection(connstr);
            con.Open();
            string query = "insert into emp (employeename,employeeaddress,designation,empmail) values(@empname,@empaddress,@des,@empmail)";
            con.ExecuteScalar(query, new
            {
                empname = emp.EmployeeName,
                empaddress=emp.EmployeeAddress,
                des=emp.Designation,
                empmail=emp.EmpMail
            });

            return Json("Success");
          
        
        }
    }
}
