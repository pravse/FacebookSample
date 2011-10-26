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
    public class PuzzleModel
    {
        [Required]
        [DisplayName("Answer")]
        public string Answer { get; set; }

        public bool Correct { get; set; }

        [DisplayName("Response")]
        public string Response { get; set; }
    }

    #endregion

    #region Services

    public interface IPuzzleService
    {
        bool CheckAnswer(string answer);
    }

    public class PuzzleService : IPuzzleService
    {
        public bool CheckAnswer(string answer)
        {
            if (String.IsNullOrEmpty(answer)) throw new ArgumentException("Value cannot be null or empty.", "answer");

            if (answer.Equals("Missisippi")) { return true; } else { return false; }
        }
    }
    #endregion

}
