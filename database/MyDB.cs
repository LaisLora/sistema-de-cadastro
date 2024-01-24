using MySql.Data.MySqlClient;
using SistemaCadastroBalanço.database.Cadastros;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI.WebControls;

namespace SistemaCadastroBalanço.database
{
    public class MyDB
    {
        private string connectionString = "Server=localhost;Database=sistemacadastrobalanco;Uid=root;Pwd=root;";

        public void AdicionarCliente(string idCliente, string cliente, string pet, string idadepet, string cel, string observacoes)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO clientes (cliente, pet, idadepet, cel, observacoes) VALUES (@Cliente, @Pet, @IdadePet, @Cel, @Observacoes)";
                MySqlCommand command = new MySqlCommand(query, connection);

                //command.Parameters.AddWithValue("@IdCliente", idCliente);
                command.Parameters.AddWithValue("@Cliente", cliente);
                command.Parameters.AddWithValue("@Pet", pet);
                command.Parameters.AddWithValue("@IdadePet", idadepet);
                command.Parameters.AddWithValue("@Cel", cel);
                command.Parameters.AddWithValue("@Observacoes", observacoes);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void AtualizarCliente(Clientes cliente)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE clientes SET cliente = @Cliente, pet = @Pet, idadepet = @IdadePet, cel = @Cel, observacoes = @Observacoes WHERE idCliente = @IdCliente";
                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@IdCliente", cliente.idCliente);
                command.Parameters.AddWithValue("@Cliente", cliente.cliente);
                command.Parameters.AddWithValue("@Pet", cliente.pet);
                command.Parameters.AddWithValue("@IdadePet", cliente.idadepet);
                command.Parameters.AddWithValue("@Cel", cliente.cel);
                command.Parameters.AddWithValue("@Observacoes", cliente.observacoes);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void ExcluirCliente(string idCliente)
        {
            List<Clientes> lista = new List<Clientes>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM clientes WHERE idCliente = @IdCliente";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdCliente", idCliente);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public Clientes BuscaClientePeloId(string idCliente)
        {
            List<Clientes> lista = new List<Clientes>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                
                string query = "SELECT * FROM clientes WHERE idCliente = "+ idCliente + "";
                MySqlCommand command = new MySqlCommand(query, connection);
                
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Clientes cliente = new Clientes
                        {
                            idCliente = reader["idCliente"].ToString(),
                            cliente = reader["cliente"].ToString(),
                            pet = reader["pet"].ToString(),
                            idadepet = reader["idadepet"].ToString(),
                            cel = reader["cel"].ToString(),
                            observacoes = reader["observacoes"].ToString()
                        };
                        lista.Add(cliente);
                    }
                }
            }
            return lista.FirstOrDefault();
        }
        public List<Clientes> ListarClientes()
        {
            List<Clientes> lista = new List<Clientes>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM clientes";
                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Clientes cliente = new Clientes
                        {
                            idCliente = reader["idCliente"].ToString(),
                            cliente = reader["cliente"].ToString(),
                            pet = reader["pet"].ToString(),
                            idadepet = reader["idadepet"].ToString(),
                            cel = reader["cel"].ToString(),
                            observacoes = reader["observacoes"].ToString()
                        };
                        lista.Add(cliente);
                    }
                }
            }
            return lista;
        }

        
    }
}
