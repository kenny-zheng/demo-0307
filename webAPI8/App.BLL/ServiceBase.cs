using App.EF.EF.dbDemoContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using NLog;
using System.Runtime.InteropServices;
//#Addusing
namespace App.BLL
{
    public interface IServiceBase
    {

    }
    public abstract class ServiceBase
    {
        internal ILogger _logger = NLog.LogManager.GetCurrentClassLogger();
        internal IConfigurationSection appSetting = AppSettingHelper.GetSection("ConnectionStrings");


        protected async virtual Task<dbDemoContext> dbTemplate([Optional] ConnectionMode connectionMode)
        {
            string connectionString = connectionMode.Equals(ConnectionMode.Slave) ? appSetting.GetSection("dbConnectionString-Slave").Value : appSetting.GetSection("dbConnectionString-Master").Value;
            var options = new DbContextOptionsBuilder<dbDemoContext>()
                          .UseSqlServer(connectionString)
                          .Options;

            var factory = new PooledDbContextFactory<dbDemoContext>(options, poolSize: 100);//TODO 依照連線字串的pool數設定
            return await factory.CreateDbContextAsync();

        }

        //#AddService
    }
}
