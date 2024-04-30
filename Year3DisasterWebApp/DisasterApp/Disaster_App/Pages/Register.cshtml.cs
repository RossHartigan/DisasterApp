using Disaster_App.Data;
using Disaster_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Disaster_App.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly DisasterContext _context;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IConfiguration _configuration;

        public RegisterModel(DisasterContext context, ILogger<RegisterModel> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public void OnPost()
        {
            _logger.LogInformation("Test");

            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            var username = Request.Form["username"];
            var password = Request.Form["password"];
            var name = Request.Form["name"];
            var surname = Request.Form["surname"];
            var email = Request.Form["email"];

            _logger.LogInformation(username);

            List<User> users = _context.Users.ToList();

            foreach (var x in users)
            {
                _logger.LogInformation($"Username: {x.Username}, Name: {x.Name}");
            }

            var user = new User
            {
                Username = username,
                Password = password,
                Name = name,
                Surname = surname,
                Email = email
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}

