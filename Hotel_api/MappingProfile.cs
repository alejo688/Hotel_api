using AutoMapper;
using DB.Entity;
using Hotel_api.Model;

namespace Hotel_api
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Usuario, UsuarioModel>()
                .ReverseMap();
            CreateMap<Hotel, HotelModel>()
                .ReverseMap();
            CreateMap<Habitacion, HabitacionModel>()
                .ReverseMap();
            CreateMap<Reserva, ReservaModel>()
                .ReverseMap();
        }
    }
}