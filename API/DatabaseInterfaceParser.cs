using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace dbConsole.API
{
    internal class DatabaseInterfaceParser
    {
        internal IDatabaseInterface DatabaseInterface { get; set; }

        public DatabaseInterfaceParser(IDatabaseInterface databaseInterface)
        {
            DatabaseInterface = databaseInterface;
        }

        internal IEnumerable<string> Tables()
        {
            var result = DatabaseInterface.Tables();
            return result;
        }

        internal IEnumerable<string> Table(string name)
        {
            var result = DatabaseInterface.Table(name);
            return result;
        }

        internal IEnumerable<string> Rows(string table, string column, string value)
        {
            var result = DatabaseInterface.Rows(table, column, value);
            return result;
        }
    }
}
