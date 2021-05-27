namespace QLHTDT.openserver
{
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;

    public class ConnecServer
    {
        private string pDatabase;
        private string pPassword;
        private string pServer;
        private string pUser;

        public ConnecServer(string server, string User, string Password, string Database)
        {
            this.pServer = server;
            this.pUser = User;
            this.pDatabase = Database;
            this.pPassword = Password;
        }

        public IWorkspace ConnectSDE()
        {
            IWorkspace workspace;
            try
            {
                IWorkspaceFactory factory = (IWorkspaceFactory) Activator.CreateInstance(Type.GetTypeFromProgID("esriDataSourcesGDB.SdeWorkspaceFactory"));
                IPropertySet connectionProperties = new PropertySetClass();
                connectionProperties.SetProperty("dbclient", "SQLServer");
                connectionProperties.SetProperty("instance", "sde:sqlserver:" + this.pServer);
                connectionProperties.SetProperty("authentication_mode", "DBMS");
                connectionProperties.SetProperty("user", this.pUser);
                connectionProperties.SetProperty("password", this.pPassword);
                connectionProperties.SetProperty("Database", this.pDatabase);
                workspace = factory.Open(connectionProperties, 0);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox("Kết nối không thành công, xin vui lòng kiểm tra lại cấu hình hệ thống", MsgBoxStyle.OkOnly, "Thông báo");
                workspace = null;
                ProjectData.ClearProjectError();
                return workspace;
            }
            return workspace;
        }
    }
}

