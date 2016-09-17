using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace DevCon
{
    [ConsoleCommand("help", "Lists available commands")]
    public class Help : IConsoleCommand
    {
        public ConsoleResult Run(string[] args)
        {
            var sb = new StringBuilder("<table class='webcli-tbl'>");

            //Loop thru server commands
            foreach (var cmdType in WebCLIController.CommandTypes)
            {
                var attr = cmdType.GetTypeInfo().GetCustomAttributes(WebCLIController.AttributeType)
                                                .FirstOrDefault() as ConsoleCommandAttribute;
                if (attr == null) { continue; }

                sb.Append("<tr><td class='webcli-lbl'>" + HttpUtility.HtmlEncode(attr.Name) 
                           + "</td> <td>:</td> <td class='webcli-val'>" 
                           + HttpUtility.HtmlEncode(attr.Description) + "</td></tr>");
            }
            sb.Append("</table>");
            return new ConsoleResult(sb.ToString()) { isHTML = true };
        }
    }
}