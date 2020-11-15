using System;
using System.Collections.Generic;
using System.Text;

namespace dbConsole.API.SandBoxInterface
{
    class SandBoxDatabase : IDatabaseInterface
    {   
        public IEnumerable<string> Tables()
        {
            var list = new List<string>() { "Table1", "Table2", "Table3" };
            return list;
        }

        public IEnumerable<string> Table(string name)
        {
            var list = new List<string>();
            list.Add("ID, INT, PK, NN");
            list.Add("Name, VARCHAR(255)");
            list.Add("Age, INT32");
            return list;
        }

        public IEnumerable<string> Rows(string table, string column, string value)
        {
            var list = new List<string>();
            list.Add("1337 Joe 25");
            list.Add("1338 Joe 42");
            return list;
        }
    }
}
