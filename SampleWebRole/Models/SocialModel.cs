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
    public class DialogModel
    {
        public string AddFriendResponse = null; 
        public bool IsValid = false;
    }

    #endregion

    #region Services

    public interface IDialogService
    {
        bool DummyMethod(string value);
    }

    public class DialogService : IDialogService
    {
        public bool DummyMethod(string value)
        {
            return true;
        }
    }
    #endregion

}
