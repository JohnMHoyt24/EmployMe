using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web_API.Controllers
{
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            //Find out how I can create stored procedures for these SQL queries.
            string query = @"
                    select EmployeeId,EmployeeName,Department,DateOfJoining,PhotoFileName from
                    dbo.Employee
                    ";

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
            ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }
    }
}
