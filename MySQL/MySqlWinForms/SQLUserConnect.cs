using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySqlWinForms
{
    class SQLUserConnect
    {

        public List<User> ReadUsers()
        {
            List<User> result = new List<User>();
            MySqlConnection conn;
            string MyConnectionString = "server=127.0.0.1;uid=root;pwd=vertrigo;database=users";
            try
            {
                conn = new MySqlConnection(MyConnectionString);
                conn.Open();

                const string quary = "SELECT login, name, surname, birhday, password, email from users";
                MySqlCommand command = new MySqlCommand(quary, conn);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string Login = reader.GetString("login");

                        User us = new User(Login);
                        us.Name = reader.GetString("name");
                        us.Surname = reader.GetString("surname");
                        us.Password = reader.GetString("password");
                        us.Email = reader.GetString("email");
                        us.Birhday = reader.GetDateTime("birhday");
                        result.Add(us);
                    }
                }
            }

            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return result;
            }
            return result;
        }

        public bool DeleteUser(string login)
        {
            MySqlConnection conn = null; 
            string MyConnectionString = "server=127.0.0.1;uid=root;pwd=vertrigo;database=users";

            
            DialogResult dialogResult = MessageBox.Show($"Вы уверены, что хотите удалить пользователя с логином '{login}'?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes)
            {
                return false; 
            }


            try
            {
                conn = new MySqlConnection(MyConnectionString);
                conn.Open();

                string query = "DELETE FROM users WHERE login = @login";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@login", login); 

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                   
                    return true;
                }
                else
                {
                    MessageBox.Show($"Не удалось удалить пользователя с логином '{login}'. Пользователь не найден.");  
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Ошибка при удалении пользователя: {ex.Message}");
                return false;
            }
            

        }
        
    }

}