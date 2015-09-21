using System.Collections.Generic;

namespace RestApiConfiguration.Data.Repository
{
    public interface IRepository
    {
        List<ConfigurationEntity> Get();
        ConfigurationEntity Get(string name);
        ConfigurationEntity Update(ConfigurationEntity obj);
        ConfigurationEntity Insert(ConfigurationEntity obj);
        object UpdateConcreteValue(string name, string key, dynamic value);
        object GetByKey(string name, string key);
        int Delete(ConfigurationEntity obj);
    }
}
