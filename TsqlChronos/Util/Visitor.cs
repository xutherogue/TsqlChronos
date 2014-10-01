using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace TsqlChronos.Util
{
    class AnonymousVisitor : TSqlFragmentVisitor
    {
        private readonly Action<TSqlFragment> _action;

        public AnonymousVisitor(Action<TSqlFragment> action)
        {
            _action = action;
        }

        public override void Visit(TSqlFragment fragment)
        {
            _action(fragment);
        }
    }
}
