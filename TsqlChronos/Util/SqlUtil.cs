using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace TsqlChronos.Util
{
    public static class SqlUtil
    {
        public static IEnumerable<TSqlFragment> EnumerateAll(TSqlFragment fragment)
        {
            var fragments = new List<TSqlFragment>();
            var visitor = new AnonymousVisitor(fragments.Add);
            fragment.Accept(visitor);
            return fragments;
        }
    }
}
