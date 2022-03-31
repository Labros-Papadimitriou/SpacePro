using AutoMapper;
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
            CreateMap<EditUserDto, ApplicationUser > ();
        }
    
    }
}