using System;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TsqlChronos.Util;

namespace TsqlChronos.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var sql = SqlParser.Parse("SELECT * FROM Whatever");
            var fragments = SqlUtil.EnumerateAll(sql);
            foreach (var fragment in fragments)
            {
                if (fragment is NamedTableReference)
                {
                    var namedTable = (NamedTableReference) fragment;
                    Console.WriteLine(namedTable.SchemaObject.BaseIdentifier.Value);
                }
            }
        }
    }
}
