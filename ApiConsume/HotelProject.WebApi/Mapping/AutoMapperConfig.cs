using AutoMapper;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebApi.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            //1.yöntem
            CreateMap<RoomAddDto, Room>();
            CreateMap<Room, RoomAddDto>();

            //2.yöntem
            CreateMap<UpdateRoomDto, Room>().ReverseMap();
        }
    }
}
