using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApiConfiguration.Data
{
    public class ConfigFactory
    {
        public ConfigurationEntity CfgCreate(ConfigurationEntity cfg)
        {
            return new ConfigurationEntity()
            {
                FtpUserName = cfg.FtpUserName,
                HostingName = cfg.HostingName,
                Registration = cfg.Registration,
                EmailAdress = cfg.EmailAdress,
                TypeOfHosting = cfg.TypeOfHosting,
                ConfigName = cfg.ConfigName
            };
        }
    }
}