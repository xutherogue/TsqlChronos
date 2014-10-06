using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using TsqlChronos.Util;

namespace TsqlChronos
{
    public sealed class ResultSet
    {
        public object[][] Values;
    }

    internal interface IResultProvider
    {
        Task<ResultSet> GetResults(SelectStatement statement);
    }

    public sealed class CacheEngine : IResultProvider
    {
        private readonly string connectionString;
        private readonly Cache cache;

        public CacheEngine(string connectionString)
        {
            cache = new Cache(this);
            this.connectionString = connectionString;
        }

        public void Notify()
        {
        }

        public ResultSet Fetch(string query)
        {
            return null;
        }

        public Task<ResultSet> GetResults(SelectStatement statement)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = SqlParser.GetSql(statement);
                return command.ExecuteReaderAsync().ContinueWith(t => AsResultSet(t.Result));
            }
        }

        private static ResultSet AsResultSet(SqlDataReader reader)
        {
            var results = new List<object[]>();

            while (reader.Read())
            {
                var row = new object[reader.FieldCount];
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                reader.GetValues(row);
                results.Add(row);
            }

            return new ResultSet { Values = results.ToArray() };
        }
    }
}
