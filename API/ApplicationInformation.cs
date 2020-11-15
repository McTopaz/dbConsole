using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace dbConsole.API
{
    static internal class ApplicationInformation
    {
        internal static IEnumerable<string> Information()
        {
            var name = Name();
            var version = Version();
            var author = Author();
            var title = $"=== {name} --- {version} --- by {author} ===";
            var bar = new string('=', title.Length);
            var api = nameof(dbConsole);

            var list = new List<string>();
            list.Add($"");
            list.Add($" {bar}");
            list.Add($" {title}");
            list.Add($" {bar}");
            list.Add($"");
            list.Add($"{api} <command> <argument1> <argumentN>");
            list.Add($"");
            list.Add($"{api} tables");
            list.Add($"{api} table <name>");
            list.Add($"{api} rows <table> where <column> <value>");
            list.Add($"{api} rows <table> where <column> <value> <column1> <columnN");
            return list;
        }

        internal static string Name()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var info = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            var name = info.ProductName;
            return name;
        }

        internal static string Version()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var info = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            var version = info.FileVersion;
            return $"V{version}";
        }

        internal static string Author()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var info = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            return info.CompanyName;
        }

        internal static string Unknown()
        {
            var msg = $"Unknown command";
            return msg;
        }
    }
}
