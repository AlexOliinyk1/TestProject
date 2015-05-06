using System;
using System.ComponentModel.DataAnnotations;
using Test.WebSite.Domain.Common;

namespace Test.WebSite.Domain.EntityModel
{
    public class Album : Entity
    {
        public string Genre { get; set; }

        public string Artist { get; set; }

        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Year { get; set; }
    }
}
