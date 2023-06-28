using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace R4DBTool
{
    public class SQL
    {
        string DatabaseName { get; set; }
        Server SqlServer { get; set; }
        Database Database { get; set; }
        public SQL(string databaseName)
        {
            this.DatabaseName = databaseName;
            SqlServer = new Server(File.ReadAllText(Application.StartupPath + "SQLServerName.txt"));
            Database = SqlServer.Databases[databaseName];
        }

        public void RestoreDb(string backupFilePath, string fileName, string outputPath)
        {
            if (CheckDbExists())
            {
                MessageBox.Show("Database with this name already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
            Restore restore = new()
            {
                Database = DatabaseName
            };

            string formattedFilename = fileName.Replace(".bak", "");

            BackupDeviceItem backupDeviceItem = new(backupFilePath, DeviceType.File);
            restore.Devices.Add(backupDeviceItem);

            restore.RelocateFiles.Add(new RelocateFile(formattedFilename, $@"{outputPath}\{DatabaseName}.mdf"));
            restore.RelocateFiles.Add(new RelocateFile(formattedFilename + "_log", $@"{outputPath}\{DatabaseName}.ldf"));

            restore.ReplaceDatabase = true;

            restore.SqlRestore(SqlServer);

            SqlServer.ConnectionContext.Disconnect();
            MessageBox.Show($"Database {DatabaseName} Successfully Restored!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public void DropDb()
        {
            if (!CheckDbExists() || CheckDbInUse())
            {
                MessageBox.Show($"Database {DatabaseName} doesn't exist or is in use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Database.Drop();
            MessageBox.Show($"Database {DatabaseName} Successfully Dropped!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private bool CheckDbExists()
        {
            return SqlServer.Databases.Contains(DatabaseName);
        }

        private bool CheckDbInUse()
        {
            return SqlServer.GetActiveDBConnectionCount(DatabaseName) > 0;
        }
    }
}
