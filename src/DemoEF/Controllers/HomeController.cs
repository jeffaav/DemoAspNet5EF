using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Sql;
using DemoEF.Models.DataModel;

namespace DemoEF.Controllers
{
    public class HomeController : Controller
    {
        private TSMEDSContext dbContext { get; }

        public HomeController(TSMEDSContext context)
        {
            this.dbContext = context;
        }
        public IActionResult Index()
        {
            return View(GetProjects(dbContext));
            //return View(dbContext.Project.ToList());
        }

        private IEnumerable<Project> GetProjects(TSMEDSContext context)
        {
            var connection = context.Database.GetDbConnection();
            var command = connection.CreateCommand();

            command.CommandText = "ListProjects";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            connection.Open();

            var reader = command.ExecuteReader();
            var projects = new List<Project>();

            while (reader.Read())
            {
                projects.Add(new Project
                {
                    ProjectName = reader[nameof(Project.ProjectName)].ToString(),
                    ProjectID = Convert.ToInt32(reader[nameof(Project.ProjectID)]),
                });
            }

            connection.Close();

            return projects;
        }
    }
}