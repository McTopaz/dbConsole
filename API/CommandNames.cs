using System;
using System.Collections.Generic;
using System.Text;

namespace dbConsole.API
{
    enum CommandNames
    {
        // Application specific command names.
        name,
        version,
        author,
        unknown,
        information,

        // Database specific command names.
        tables,
        table,
        rows
    }
}
