using AutoMapper;
using Belatrix.WebApi.Models;

namespace Belatrix.WebApi.Profiles
{
    public class CustomersProfile : Profile
    {
        public CustomersProfile()
        {
            CreateMap<Customer, ViewModels.Customer>();
        }
    }
}
