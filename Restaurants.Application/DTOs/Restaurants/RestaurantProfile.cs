using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Restaurants.Application.Restaurants.Commands.CreateRestaurantCommand;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurantCommand;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.DTOs.Restaurants
{
    public class RestaurantProfile:Profile
    {
        public RestaurantProfile() 
        {
            CreateMap<UpdateRestaurantCommand, Restaurant>()
                .ForMember(r => r.Address, opt => opt.MapFrom(src => new Address()
                {
                    City = src.City,
                    Street = src.Street,
                    PostalCode = src.PostalCode
                }));

            CreateMap<CreateRestaurantCommand, Restaurant>()
                .ForMember(r => r.Address, opt => opt.MapFrom(src=>new Address()
                {
                    City = src.City,
                    Street = src.Street,
                    PostalCode = src.PostalCode
                }));
            CreateMap<CreateRestaurantDto, Restaurant>()
                .ForMember(Restaurant => Restaurant.Address, opt => opt.MapFrom(src => new Address
                {
                    City = src.City,
                    Street = src.Street,
                    PostalCode = src.PostalCode

                }))
                ;
            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(r => r.Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForMember(r => r.PostalCode, opt => opt.MapFrom(src => src.Address.PostalCode))
                .ForMember(r => r.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(r => r.Dishes, opt => opt.MapFrom(src => src.Dishes));
        }
    }
}
