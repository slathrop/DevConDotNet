using System.IO;
using System.Linq;

namespace DevCon
{
    [ConsoleCommand("diskspace", "Reports the amount of free disk space in bytes")]
    public class DiskSpace : IConsoleCommand
    {
        public ConsoleResult Run(string[] args)
        {
            var drives = DriveInfo.GetDrives();
            var result = "";

            //If drive specified, show just that drive's space
            if (args.Length > 1)
            {
                var drive = drives.Single(d => d.Name.ToLower() == args[1].ToLower());
                result = GetDriveSpace(drive);
            }
            else //Show all drives
            {
                foreach (var drive in drives)
                {
                    result += GetDriveSpace(drive);
                }
            }

            return new ConsoleResult(result) { isHTML = true };
        }

        private string GetDriveSpace(DriveInfo drive)
        {
            string fmt = "<div style='color:#D6B054;white-space:pre'>Drive {0} {1,13} bytes free</div>";
            return string.Format(fmt, drive.Name, drive.AvailableFreeSpace);
        }
    }
}