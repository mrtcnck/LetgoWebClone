﻿using AutoMapper;
using Letgo.Entities.Concrete;
using Letgo.WebUI.Models.DTO_s;

namespace Letgo.WebUI.AutoMapper
{
    public class LetgoAutoMapper : Profile
    {
        public LetgoAutoMapper()
        {
            CreateMap<AdvertCreateDTO, Advert>();
        }
    }
}
