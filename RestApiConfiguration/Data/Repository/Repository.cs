using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RestApiConfiguration.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly ConfigDbContext _context;

        public Repository(ConfigDbContext context)
        {
            _context = context;
        }
        public List<ConfigurationEntity> Get()
        {
            return _context.Configurations.ToList();
        }

        public ConfigurationEntity Get(string name)
        {
            return _context.Configurations.FirstOrDefault(r => r.ConfigName == name);
        }

        public dynamic GetByKey(string name, string key)
        {
            var search = _context.Configurations.FirstOrDefault(r => r.ConfigName == name);
            var newlowercase = key.ToLowerInvariant();
            if (search != null)
            {
                switch (newlowercase)
                {
                    case "hostingname":
                        return search.HostingName;
                    case "typeofhosting":
                        return search.TypeOfHosting;
                    case "emailadress":
                        return search.EmailAdress;
                    case "ftpusername":
                        return search.FtpUserName;
                    case "registration":
                        return search.Registration;
                    default:
                        return null;
                }
            }
            return null;
        }
        public ConfigurationEntity Update(ConfigurationEntity obj)
        {
            var updateConfig = _context.Configurations.SingleOrDefault(x => x.ConfigName == obj.ConfigName);
            if (updateConfig != null)
            {
                updateConfig.ConfigName = obj.ConfigName;
                updateConfig.EmailAdress = obj.EmailAdress;
                updateConfig.FtpUserName = obj.FtpUserName;
                updateConfig.Registration = obj.Registration;
                updateConfig.HostingName = obj.HostingName;
                updateConfig.TypeOfHosting = obj.TypeOfHosting;

                _context.Entry(updateConfig).State = EntityState.Modified;
                _context.SaveChanges();
                return updateConfig;
            }
            return null;
        }
        /// <summary>
        /// Update a concrete value by value in URL
        /// Example: http://localhost:6348/api/Configuration/secondconfig/ftpusername/myusername
        /// value is "mysusername" in key is "ftpusername" name is "secondconfig"
        /// </summary>
        /// <param name="name">id</param>
        /// <param name="key">param in your config</param>
        /// <param name="value">value that you want</param>
        /// <returns></returns>
        public dynamic UpdateConcreteValue(string name, string key, dynamic value)
        {
            var updateConfig = _context.Configurations.SingleOrDefault(x => x.ConfigName == name);
            var newlowercase = key.ToLowerInvariant();
            if (updateConfig != null)
            {
                switch (newlowercase)
                {
                    case "hostingname":
                        updateConfig.HostingName = value;
                        _context.Entry(updateConfig).State = EntityState.Modified;
                        _context.SaveChanges();
                        return updateConfig;
                    case "typeofhosting":
                        updateConfig.TypeOfHosting = value;
                        _context.Entry(updateConfig).State = EntityState.Modified;
                        _context.SaveChanges();
                        return updateConfig;
                    case "ftpusername":
                        updateConfig.FtpUserName = value;
                        _context.Entry(updateConfig).State = EntityState.Modified;
                        _context.SaveChanges();
                        return updateConfig;
                    case "registration":
                        if (value == "enabled")
                            updateConfig.Registration = true;
                        if (value == "disabled")
                            updateConfig.Registration = false;
                        _context.Entry(updateConfig).State = EntityState.Modified;
                        _context.SaveChanges();
                        return updateConfig;
                    default:
                        return null;
                }
            }
            return false;
        }
        public ConfigurationEntity Insert(ConfigurationEntity obj)
        {
            _context.Configurations.Add(obj);
            _context.SaveChanges();
            return obj;
        }
        public int Delete(ConfigurationEntity obj)
        {
            _context.Configurations.Remove(obj);
            return _context.SaveChanges();
        }
    }
}