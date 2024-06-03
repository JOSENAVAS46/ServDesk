using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using System.Text;
using Dapper;

namespace ServDesk.DataAccess
{
    public class SqlHelper
    {
        private readonly string _admConnectionString;
        private SqlConnection? Connection { get; set; }
        private SqlTransaction? Transaction { get; set; }
        private const int TimeOut = 2000;

        public SqlHelper(Configuracion sqlconfiguracion)
        {
            _admConnectionString = sqlconfiguracion.SqlConnection;
        }

        public void IniciarTransaccion()
        {
            Connection = new SqlConnection(_admConnectionString);
            Connection.Open();
            Transaction = Connection.BeginTransaction();
        }

        public void ConfirmarTransaccion()
        {
            Transaction?.Commit();
            Transaction = null;
            Connection?.Close();
        }

        public void AbortarTransaccion()
        {
            Transaction?.Rollback();
            Transaction = null;
            Connection?.Close();
        }

        
        
        public async Task<T> ConsultarAsync<T>(string spName, object? parametros = null)
        {
            using var connection = new SqlConnection(_admConnectionString);
            var consulta = await connection.QueryFirstOrDefaultAsync<T>(spName, parametros,
                commandType: CommandType.StoredProcedure);
            return consulta;

        }

        public async Task<T> ConsultarTransactionAsync<T>(string spName, object? parametros = null)
        {

            var consulta = await Connection.QueryFirstOrDefaultAsync<T>(spName, parametros, Transaction,
                commandType: CommandType.StoredProcedure);
            return consulta;

        }

        public async Task<List<T>> ListarAsync<T>(string spName, object? parametros = null)
        {
            using var connection = new SqlConnection(_admConnectionString);
            var results = await connection.QueryAsync<T>(spName, parametros, commandType: CommandType.StoredProcedure);
            return results.ToList();
        }


        public async Task EjecutarSpAsync(string spName, object? parametros = null)
        {
            await Connection.ExecuteAsync(spName, parametros, Transaction, TimeOut, commandType: CommandType.StoredProcedure);
        }

        public async Task<object> EjecutarSpEscalarAsync(string spName, object parametros)
        {
            return await Connection.ExecuteScalarAsync(spName, parametros, Transaction, TimeOut, commandType: CommandType.StoredProcedure);
        }

        public async Task<byte[]> ConsultarReporteAsync<T>(string spName, object parametros)
        {
            var consulta = await ListarAsync<T>(spName, parametros);
            var sb = new StringBuilder();
            const char csvSeparador = '\t';
            var propiedadesEntidad = typeof(T).GetProperties();
            sb.AppendLine(string.Join(csvSeparador, propiedadesEntidad.Select(column => column.Name)));
            foreach (var item in consulta)
            {
                sb.AppendLine();
                foreach (var i in propiedadesEntidad)
                {
                    sb.Append(item.ToString());
                    sb.Append(csvSeparador);
                }
            }
            var resultado = new UTF8Encoding().GetBytes(sb.ToString());
            return resultado;
        }

        // Query Simples Directos.
        public async Task<IEnumerable<dynamic>> SimpleQueryAsync<dynamic>(string query, object? parametros = null)
        {
            using var connection = new SqlConnection(_admConnectionString);
            var results = await connection.QueryAsync(query);
            return (List<dynamic>)results;
        }

        public async Task<T> ListarAsyncCodigo<T>(string spName, object? parametros = null)
        {
            using var connection = new SqlConnection(_admConnectionString);
            var results = await connection.QueryAsync<T>(spName, parametros, commandType: CommandType.StoredProcedure);
            return results.First();
        }

    }
}
