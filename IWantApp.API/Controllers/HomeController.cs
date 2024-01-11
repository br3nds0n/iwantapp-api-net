using Npgsql;
using Microsoft.AspNetCore.Mvc;

namespace IWantApp.API.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public object Home()
        {
            string connectionString = _configuration.GetConnectionString("Default");
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    return Ok(new
                    {
                        App = "IWantApp.API",
                        Status = "Iniciada com sucesso",
                        Database = "OK"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    App = "IWantApp.API",
                    Status = $"Erro ao iniciar: {ex.Message}",
                    Database = "ERROR"
                });
            }
        }
    }
}