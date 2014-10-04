using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace TsqlChronos.Util
{
    public static class SqlParser
    {
        public static TSqlFragment Parse(string sql)
        {
            var parser = new TSql110Parser(false);
            var reader = new StringReader(sql);
            IList<ParseError> errors;
            return parser.Parse(reader, out errors);
        }

        public static string GetSql(TSqlFragment fragment)
        {
            var scriptGenerator = new Sql110ScriptGenerator();
            string result;
            scriptGenerator.GenerateScript(fragment, out result);
            return result;
        }
    }
}
