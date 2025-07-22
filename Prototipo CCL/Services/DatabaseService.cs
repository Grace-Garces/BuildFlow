using Microsoft.Data.SqlClient;
using Security;
using System.Threading.Tasks;

namespace Prototipo_CCL.Services
{
    public class DatabaseService
    {
        // Sua string de conexão. Em um app de produção, isso viria de um arquivo de configuração seguro.
        private readonly string _connectionString = "Server=DESKTOP-2A99RIJ\\PR_DBC;Database=DB-BuildFlow;User Id=SSBD/Project;Password=Database2;TrustServerCertificate=True;Encrypt=False;";

        /// <summary>
        /// Valida as credenciais do usuário no banco de dados.
        /// </summary>
        /// <param name="username">Nome de usuário digitado.</param>
        /// <param name="password">Senha digitada.</param>
        /// <returns>Retorna true se o login for válido, caso contrário, false.</returns>
        public async Task<bool> ValidateLoginAsync(string username, string password)
        {
            // IMPORTANTE: Em um aplicativo real, NUNCA compare senhas em texto plano.
            // A senha digitada pelo usuário deveria ser transformada em um hash e comparada
            // com o SenhaHash armazenado no banco de dados.
            // Para este protótipo, faremos uma comparação simples para validar a lógica.
            var passwordForQuery = "admin_hashed"; // Simula a senha que estaria no banco

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    var query = "SELECT COUNT(1) FROM Usuarios WHERE NomeUsuario = @Username AND SenhaHash = @Password";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", passwordForQuery); // Em um app real, você compararia o hash da senha digitada

                        // ExecuteScalarAsync é eficiente para queries que retornam um único valor (como uma contagem).
                        var result = await command.ExecuteScalarAsync();

                        // Se a contagem for 1, significa que o usuário foi encontrado.
                        return (result != null && (int)result == 1);
                    }
                }
                catch (SqlException ex)
                {
                    // Em um app real, você logaria o erro aqui.
                    // Por enquanto, podemos exibir um alerta para o desenvolvedor.
                    await Application.Current.MainPage.DisplayAlert("Erro de Conexão", $"Não foi possível conectar ao banco de dados: {ex.Message}", "OK");
                    return false;
                }
            }
        }

        // Futuramente, outros métodos para interagir com o banco de dados virão aqui:
        // public async Task<List<Apontamento>> GetApontamentosAsync() { ... }
        // public async Task SaveApontamentoAsync(Apontamento apontamento) { ... }
    }
}