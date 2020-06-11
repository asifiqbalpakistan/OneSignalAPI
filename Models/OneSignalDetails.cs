using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AG_OneSignalAPI.Models
{
    public class OneSignalDetails
    {
        [DisplayName("APP ID")]
        public string id { get; set; }
        [Required]
        [DisplayName("Name")]
        public string name { get; set; }
        [DisplayName("Site URL")]
        [Required]
        public string chrome_web_origin { get; set; }
        [DisplayName("Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy HH:mm}")]
        public DateTime created_at { get; set; }
        
        public DateTime updated_at { get; set; }
        [DisplayName("APP Key")]
        public string basic_auth_key { get; set; }

    }
}