using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SampleWebRole.Models
{

    #region Models
    public class SocialModel
    {
        [Required]
        [DisplayName("Answer")]
        public string Answer { get; set; }

        [DisplayName("Response")]
        public string Response { get; set; }
    }

    #endregion

    #region Services

    public interface ISocialService
    {
        bool DummyMethod(string value);
    }

    public class SocialService : ISocialService
    {
        public bool DummyMethod(string value)
        {
            return true;
        }
    }
    #endregion

}
