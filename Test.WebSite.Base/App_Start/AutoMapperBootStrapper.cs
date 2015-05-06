using AutoMapper;
using Test.WebSite.Base.ViewModels;
using Test.WebSite.Domain.EntityModel;

namespace Test.WebSite.Base
{
    public class AutoMapperBootStrapper
    {
        public static void BootStrap()
        {
            Mapper.CreateMap<Album, AlbumViewModel>();
            Mapper.CreateMap<AlbumViewModel, Album>();
        }
    }
}