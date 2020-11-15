using System;
using System.Collections.Generic;
using System.Text;

namespace dbConsole.API
{
    public interface IDatabaseInterface
    {
        IEnumerable<string> Tables();
        IEnumerable<string> Table(string name);
        IEnumerable<string> Rows(string table, string column, string value);
    }
}
