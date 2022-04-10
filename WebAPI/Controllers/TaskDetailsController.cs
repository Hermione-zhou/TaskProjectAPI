using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskDetailsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public TaskDetailsController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select TaskDetailsId,Task,Priority,Description,By_who,Stage  from dbo.TaskDetails";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TaskDetailsAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }
        [HttpPost]
        public JsonResult Post(TaskDetails taskDetails)
        {
            //insert into dbo.TaskDetails values('S3_3',30,'test post data in api','hermione',3)
            string query = @"
                insert into dbo.TaskDetails
                (Task,Priority,Description,By_who,Stage)
                values
                ('" + taskDetails.Task + @"',
                '" + taskDetails.Priority + @"',
                '" + taskDetails.Description + @"',
                '" + taskDetails.By_who + @"',
                  '" + taskDetails.Stage + @"')";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TaskDetailsAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Add successfully!");
        }

        [Route("api/TaskDetails/SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;
                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("anonymous.png");
            }
        }

        [Route("GetAllTasks")]
        [HttpGet]
        public JsonResult GetAllTasks()
        {
            string query = @"
                select Task from dbo.TaskDetails";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TaskDetailsAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);

        }

        [Route("GetStage1Tasks")]
        [HttpGet]
        public JsonResult GetStage1Tasks()
        {
            string query = @"
               select TaskDetailsId,Task,Priority,Description,By_who,Stage from dbo.TaskDetails where Stage=1";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TaskDetailsAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);

        }
        [Route("GetStage2Tasks")]
        [HttpGet]
        public JsonResult GetStage2Tasks()
        {
            string query = @"
                select  TaskDetailsId,Task,Priority,Description,By_who,Stage from dbo.TaskDetails where Stage=2";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TaskDetailsAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);

        }

        [Route("GetStage3Tasks")]
        [HttpGet]
        public JsonResult GetStage3Tasks()
        {
            string query = @"
                select  TaskDetailsId,Task,Priority,Description,By_who,Stage from dbo.TaskDetails where Stage=3";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TaskDetailsAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);

        }
    }
}
