using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiConfiguration.Data
{
    public class ConfigurationEntity
    {
        /// <summary>
        /// Configuration Name 
        /// </summary>
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
       
        public string ConfigName { get; set; }
        /// <summary>
        /// Email adress of user
        /// </summary>
        public string EmailAdress { get; set; }
        /// <summary>
        /// host nmae
        /// </summary>
        public string HostingName { get; set; }
        /// <summary>
        /// ftp user name
        /// </summary>
        public string FtpUserName { get; set; }
        /// <summary>
        /// Enable of disable registration
        /// </summary>
        public bool Registration { get; set; }
        /// <summary>
        /// Type of hosting
        /// </summary>
        public string TypeOfHosting { get; set; }
    }
}