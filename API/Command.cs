using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dbConsole.API
{
    abstract class Command
    {
        internal string Name { get; set; }
        internal IEnumerable<string> Arguments { get; set; }
        internal IEnumerable<string> Result { get; set; } = Enumerable.Empty<string>();

        internal virtual void ValidateArguments()
        {
        }

        internal virtual void Run()
        {
        }
    }

    class SingleResultCommand : Command
    {
        internal Func<string> Function { get; set; }

        internal override void Run()
        {
            var result = Function();
            Result = new string[] { result };   // Must convert string to "strings".
        }
    }

    class MultipleResultCommand : Command
    {
        internal Func<IEnumerable<string>> Function {get; set; }

        internal override void Run()
        {
            var result = Function();
            Result = result;
        }
    }

    class TableCommand : Command
    {
        internal Func<string, IEnumerable<string>> Function { get; set; }

        internal override void ValidateArguments()
        {
            if (Arguments.Count() < 1)
            {
                var msg = $"There was no table name specified for the command";
                throw new ArgumentException(msg);
            }
        }

        internal override void Run()
        {
            var name = Arguments.First();
            var result = Function(name);
            Result = result;
        }
    }

    class RowCommand : Command
    {
        internal Func<string, string, string, IEnumerable<string>> Function { get; set; }

        internal override void ValidateArguments()
        {
            if (Arguments.Count() < 3)
            {
                var msg = $"Command required 'table', 'column' and 'value' arguments.";
                throw new ArgumentException(msg);
            }
        }

        internal override void Run()
        {
            var table = Arguments.ElementAt(0);
            var column = Arguments.ElementAt(1);
            var value = Arguments.ElementAt(2);

            var result = Function(table, column, value);
            Result = result;
        }
    }
}
