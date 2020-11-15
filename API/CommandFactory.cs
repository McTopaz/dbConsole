using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace dbConsole.API
{
    static class CommandFactory
    {
        static DatabaseInterfaceParser Parser = SetupDatabaseInterfaceParser();
        static Dictionary<CommandNames, Command> Commands = AvailableCommand();

        static DatabaseInterfaceParser SetupDatabaseInterfaceParser()
        {
            var sip = new DatabaseInterfaceParser(new SandBoxInterface.SandBoxDatabase());
            return sip;
        }

        static Dictionary<CommandNames, Command> AvailableCommand()
        {
            // Application specific commands.
            var name = new SingleResultCommand() { Function = ApplicationInformation.Name };
            var version = new SingleResultCommand() { Function = ApplicationInformation.Version };
            var author = new SingleResultCommand() { Function = ApplicationInformation.Version };
            var unknown = new SingleResultCommand() { Function = ApplicationInformation.Unknown };
            var information = new MultipleResultCommand() { Function = ApplicationInformation.Information };

            // Database specific commands.
            var tables = new MultipleResultCommand() { Function = Parser.Tables };
            var table = new TableCommand() { Function = Parser.Table };
            var rows = new RowCommand() { Function = Parser.Rows };

            var list = new Dictionary<CommandNames, Command>();
            list.Add(CommandNames.name, name);
            list.Add(CommandNames.version, version);
            list.Add(CommandNames.author, author);
            list.Add(CommandNames.unknown, unknown);
            list.Add(CommandNames.information, information);
            list.Add(CommandNames.tables, tables);
            list.Add(CommandNames.table, table);
            list.Add(CommandNames.rows, rows);
            return list;
        }

        public static Command Create(IEnumerable<string> arguments)
        {
            // No command argument passed into API.
            // Return the Information command if not.
            if (arguments is null || arguments.Count() == 0)
            {
                return Commands[CommandNames.information];
            }

            // Get name of the command from the first argument of the application.
            // Make sure the name is a valid string.
            var name = arguments.ElementAt(0);
            if (string.IsNullOrWhiteSpace(name))
            {
                return Commands[CommandNames.information];
            }

            var command = SetupCommand(name);
            command.Name = name;
            command.Arguments = arguments.Skip(1);  // Get all arguments for the command after the command name.
            return command;
        }

        static Command SetupCommand(string name)
        {
            // Make sure the command name is supported.
            // Return the unknown command if not.
            var exist = Enum.IsDefined(typeof(CommandNames), name);
            if (!exist)
            {
                return Commands[CommandNames.unknown];
            }

            // Make sure the command has a supported implementation.
            // Return the unknown command if not.
            var key = (CommandNames)Enum.Parse(typeof(CommandNames), name);
            if (!Commands.ContainsKey(key))
            {
                return Commands[CommandNames.unknown];
            }

            return Commands[key];
        }
    }
}
