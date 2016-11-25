using EmbeddedStock.DataAccess.Models;
using EmbeddedStock.Models;
using EmbeddedStock.Models.Loan;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EmbeddedStock
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.CreateMap<ComponentCategory, ComponentCategoryViewModel>();
            AutoMapper.Mapper.CreateMap<ComponentType, ComponentTypeViewModel>()
                .ForMember(dest => dest.ImageByte,
                           opts => opts.MapFrom(src => src.Image));

            AutoMapper.Mapper.CreateMap<Component, ComponentViewModel>();
            AutoMapper.Mapper.CreateMap<ComponentViewModel, Component>();
            AutoMapper.Mapper.CreateMap<HttpPostedFileBase, byte[]>().ConstructUsing(source =>
            {
                MemoryStream target = new MemoryStream();
                source.InputStream.CopyTo(target);
                return target.ToArray();
            });
            AutoMapper.Mapper.CreateMap<ComponentTypeViewModel, ComponentType>().ForMember(dest => dest.Image, opts => opts.MapFrom(src => src.ImageFile));
            AutoMapper.Mapper.CreateMap<ComponentCategoryViewModel, ComponentCategory>();
            AutoMapper.Mapper.CreateMap<Loaner, LoanViewModel>();
            AutoMapper.Mapper.CreateMap<LoanViewModel, Loaner>();
            AutoMapper.Mapper.CreateMap<LoanInformation, LoanViewModel>()
                .ForMember(dest => dest.TelephoneNumber, opts => opts.MapFrom(src => src.LoanOwner.TelephoneNumber))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.LoanOwner.Name))
                .ForMember(dest => dest.StudentNumber, opts => opts.MapFrom(src => src.LoanOwner.StudentNumber))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.LoanOwner.Email));
        }
    }
}