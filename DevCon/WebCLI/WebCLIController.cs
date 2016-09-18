using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace DevCon
{
    public class WebCLIController : ApiController
    {
        public static readonly Type AttributeType = typeof(ConsoleCommandAttribute);
        public static readonly List<Type> CommandTypes;

        static WebCLIController()
        {
            var type = typeof(IConsoleCommand);
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(asm => asm.GetTypes());

            CommandTypes = types.Where(t => t.GetInterfaces().Contains(type)).OrderBy(t => t.Name).ToList();
        }

        // POST: api/webcli
        public ConsoleResult Post([FromBody]CommandInput command)
        {
            string[] args = null;
            string cmd = null;
            var inMultiStepCmd = !string.IsNullOrEmpty(command.multiStepCmd);

            if (inMultiStepCmd)
            {
                args = new string[command.multiStepCmdArgs.Length + 1];
                args[0] = command.multiStepCmd;
                Array.Copy(command.multiStepCmdArgs, 0, args, 1, command.multiStepCmdArgs.Length);
                cmd = command.multiStepCmd.ToUpper();
            }
            else
            {
                args = command.GetArgs();
                cmd = args.First().ToUpper();
            }

            Type cmdTypeToRun = null;

            // Get command type
            foreach (var cmdType in CommandTypes)
            {
                var attr = (ConsoleCommandAttribute)cmdType.GetTypeInfo().GetCustomAttributes(AttributeType).FirstOrDefault();
                if (attr != null && attr.Name.ToUpper() == cmd)
                {
                    cmdTypeToRun = cmdType;
                    break;
                }
            }

            if (cmdTypeToRun == null) { return new ConsoleErrorResult(); }

            // Instantiate and run the command
            try
            {
                var cmdObj = Activator.CreateInstance(cmdTypeToRun) as IConsoleCommand;
                if (inMultiStepCmd && cmdObj is IMultiStepConsoleCommand)
                {
                    var multiStepCmdObj = cmdObj as IMultiStepConsoleCommand;
                    return multiStepCmdObj.RunStep(args);
                }
                else
                {
                    return cmdObj.Run(args);
                }
            }
            catch
            {
                return new ConsoleErrorResult();
            }
        }
    }
}
