using MySql.Data.MySqlClient;
using System;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;


namespace Proyecto.Services
{
    public class DatabaseService
    {
        private string connectionString = "";
       

        public async Task<bool> AuthenticateUser(string username, string password)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    var query = "SELECT * FROM usuario WHERE Username = @Username AND Password = @Password";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        var result = await cmd.ExecuteScalarAsync();
                        return Convert.ToInt32(result) > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                await Application.Current.MainPage.DisplayAlert("Excepción interna", ex.InnerException?.Message,"Ok");
                //Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }
}

