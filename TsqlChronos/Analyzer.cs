using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace TsqlChronos
{
    internal sealed class Analyzer
    {
        public static bool IsInvalidated(CacheEntry entry, UpdateStatement statement)
        {
            return true;
        }
    }
}