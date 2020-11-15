using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace dbConsole.API
{
    public static class Engine
    {
        public static IEnumerable<string> Execute(params string[] arguments)
        {
            var command = CommandFactory.Create(arguments);

            try
            {
                command.ValidateArguments();
                command.Run();
            }
            catch (Exception e)
            {
                var list = new List<string>();
                list.Add($"Unable to run command {command.Name}");
                list.Add(e.Message);
                return list;
            }

            return command.Result;
        }
    }
}
  