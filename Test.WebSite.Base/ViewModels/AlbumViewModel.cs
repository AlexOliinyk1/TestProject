using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Test.WebSite.Domain.EntityModel;

namespace Test.WebSite.Base.ViewModels
{
    public class AlbumViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Genre { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Artist { get; set; }

        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Year { get; set; }

        public IEnumerable<Album> Albums { get; set; }
    }
}