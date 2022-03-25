using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpacePro.Models.Dtos
{
    public class WinnersDto
    {
        public string Id;
        public string Name;
        public string Photo;
        public WinnersDto(string id,string name, string photo)
        {
            this.Id = id;
            this.Name = name;
            this.Photo = photo;
        }
    }
}