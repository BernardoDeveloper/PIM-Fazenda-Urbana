using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using PIM_Fazenda_Urbana_CRUD.handler;
using System.Reflection;

namespace PIM_Fazenda_Urbana_CRUD.database
{
    internal class Connection
    {
        public const string StringConexao = "data source=DESKTOP-DK5SUF1;initial catalog=pim_poc;trusted_connection=true;TrustServerCertificate=True";

        private SqlConnectionStringBuilder? builder; // Builder de string de conexão
        bool StringValida = false;

        public Connection()
        {
            var errorMessage = new ErrorHandler();

            try
            {
                builder = new SqlConnectionStringBuilder(StringConexao);
                StringValida = true;
            }
            catch (Exception ex)
            {
                StringValida = false;

                errorMessage.ErrorHandlerMessage($"Invalid connection string {StringConexao}");
                errorMessage.ErrorHandlerMessage($"System message error: {ex.Message}");
            }
        }

        public bool VerificarConexao()
        {
            try
            {
                if (!StringValida || builder is null)
                {
                    Console.WriteLine("[ERROR] Connextion string invalid");
                    return false;
                }

                using (var conexao = new SqlConnection(builder.ConnectionString))
                {
                    conexao.Open();
                }

                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("ERRO: " + ex.Message);

                return false;
            }
        }

        public void ExecutarComandoSql(string comando)
        {
            try
            {
                if (!StringValida || builder is null)
                {
                    throw new Exception("Invalid connection string");
                }

                using (var conexao = new SqlConnection(builder.ConnectionString))
                {
                    conexao.Open(); // Abre a conexão criada a partir da string de conexão
                    var sqlcmd = new SqlCommand(comando, conexao);
                    sqlcmd.ExecuteNonQuery(); // Solicita ao SQL Server a execução do comando SQL.
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("[ERROR]: Can't create a connection with server");
                Console.WriteLine($"[ERROR]: System message error - {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ListProduct(string? condition)
        {
            try
            {
                using (var connection = new SqlConnection(builder.ConnectionString))
                {
                    // Build query string - verify if has where condition
                    string queryString = "SELECT * FROM product";

                    if (condition != null)
                        queryString += $" WHERE {condition}";

                    SqlCommand command = new(queryString, connection);
                    connection.Open();

                    // List the data from column
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Console.WriteLine("| ID | nome do produto | descricao | preco |");

                        while (reader.Read())
                        {
                            Console.WriteLine("| {0} | {1} | {2} | R$ {3} |", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDouble(3));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("[ERROR]: Can't create a connection with server");
                Console.WriteLine($"[ERROR]: System message error - {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
