using AutoMapper;
using Entities.BroadClasses;
using Entities.IdentityUsers;
using SpacePro.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SpacePro.AutoMapperConfig
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            //source --> destination
            CreateMap<EditUserDto, ApplicationUser> ();
            CreateMap<CreateArticleDto, Article> ();
            CreateMap<EditArticleDto, Article> ();
        }
    }
}