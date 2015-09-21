using System;
using System.Web.Http;
using System.Web.Http.Description;
using RestApiConfiguration.Data;

namespace RestApiConfiguration.Controllers
{
    /// <summary>
    /// Main controller of API
    /// </summary>
    public class ConfigurationController : ApiController
    {
        private readonly ServiceCfg _service;
        /// <summary>
        /// initialize field
        /// </summary>
        public ConfigurationController()
        {
            _service = new ServiceCfg();
        }
        /// <summary>
        /// Get all configurations on server
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll()
        {
            try
            {
                var services = _service.Repository.Get();
                return Ok(services);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }
        /// <summary>
        /// Get concrete configuration by name
        /// </summary>
        /// <param name="id">Config Name</param>
        /// <returns>json or xml with concrete parametr</returns>
        public IHttpActionResult Get(string id)
        {
            try
            {
                var config = _service.Repository.Get(id);
                if (config != null)
                    return Ok(config);
                return NotFound();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        /// <summary>
        /// Get concrete config by key parametr
        /// </summary>
        /// <param name="id">name of configuration</param>
        /// <param name="key">parametr key</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/configuration/{id}/{key}")]
        public IHttpActionResult Get(string id, string key)
        {
            try
            {
                var getname = _service.Repository.GetByKey(id, key);
                if (getname != null)
                    return Ok(getname);
                return NotFound();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        // POST
        // api/configuration
        /// <summary>
        /// Post request frombody
        /// </summary>
        /// <param name="cfgModel">Entry of request</param>
        /// <returns>new url with new value</returns>
        [ResponseType(typeof(ConfigurationEntity))]
        public IHttpActionResult Post([FromBody] ConfigurationEntity cfgModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var service = _service.Repository.Insert(cfgModel);
                return CreatedAtRoute("DefaultApi", new { id = cfgModel.ConfigName }, service);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        /// <summary>
        /// Update concrete config
        /// </summary>
        /// <param name="cfgModel">value that need to update</param>
        /// <returns>Updated value</returns>
        [HttpPut]
        public IHttpActionResult Put([FromBody] ConfigurationEntity cfgModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var cfgupdate = _service.Repository.Update(cfgModel);
                return Ok(cfgupdate);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        /// <summary>
        /// Can change some values from given key,
        /// for example http://localhost:6348/api/Configuration/FirstConfig/registration/enabled
        /// set key registration to true and return that value 
        /// </summary>
        /// <param name="id">name of config</param>
        /// <param name="key">param that need to change</param>
        /// <param name="value">set value</param>
        /// <returns>changed value</returns>
        [Route("api/configuration/{id}/{key}/{value}")]
        [HttpPut]
        public IHttpActionResult Put(string id, string key, string value)
        {
            try
            {
                var updateCongigByValue = _service.Repository.UpdateConcreteValue(id, key, value);
                if (updateCongigByValue != null)
                    return Ok(updateCongigByValue);
                return NotFound();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        /// <summary>
        /// Delete by concrete name of config
        /// </summary>
        /// <param name="id">ConfigName</param>
        /// <returns></returns>
        [Route("api/configuration/deleteconfig/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            try
            {
                var configEntity = _service.Repository.Get(id);

                if (configEntity != null)
                    _service.Repository.Delete(configEntity);
                else
                    return NotFound();
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
