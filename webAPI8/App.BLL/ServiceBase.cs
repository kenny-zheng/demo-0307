using App.EF.EF.dbTemplate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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


        protected async virtual Task<DbTemplateContext> dbTemplate([Optional] ConnectionMode connectionMode)
        {
            string connectionString = connectionMode.Equals(ConnectionMode.Slave) ? appSetting.GetSection("dbConnectionString-Slave").Value : appSetting.GetSection("dbConnectionString-Master").Value;
            var options = new DbContextOptionsBuilder<DbTemplateContext>()
                          .UseSqlServer(connectionString)
                          .Options;

			var factory = new PooledDbContextFactory<DbTemplateContext>(options, poolSize: 100);//TODO 依照連線字串的pool數設定
			return await factory.CreateDbContextAsync();
        
		}

        //#AddService
    }
}
