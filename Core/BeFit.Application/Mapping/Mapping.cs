using AutoMapper;
using BeFit.Application.DataTransferObjects;
using BeFit.Domain.Entities;
using BeFit.Domain.Entities.Abstract;
using BeFit.Domain.Entities.Identity;
using BeFit.Domain.Entities.Macros;

namespace BeFit.Application.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<FoodDto, Food>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<CategoryImage, CategoryImageDto>().ReverseMap();
            CreateMap<FoodImage, FoodImageDto>().ReverseMap();
            CreateMap<PostImage, PostImageDto>().ReverseMap();
            CreateMap<CarbohydrateDto, Carbohydrate>().ReverseMap();
            CreateMap<FatDto, Fat>().ReverseMap();
            CreateMap<ProteinDto, Protein>().ReverseMap();
            CreateMap<SaltDto, Salt>().ReverseMap();
            CreateMap<MineralsDto, Minerals>().ReverseMap();
            CreateMap<Vitamins, VitaminsDto>().ReverseMap();
            CreateMap<Drink, DrinkDto>().ReverseMap();
            CreateMap<Food, FoodDto>().ReverseMap();
            CreateMap<CommentDislike, CommentDislikeDto>().ReverseMap();
            CreateMap<CommentLike, CommentLikeDto>().ReverseMap();
            CreateMap<LikeDto, Like>().ReverseMap();
            CreateMap<DislikeDto, Dislike>().ReverseMap();
            CreateMap<PostLike, PostLikeDto>().ReverseMap();
            CreateMap<PostDislike, PostDislikeDto>().ReverseMap();
            CreateMap<PostDto, Post>().ReverseMap();
            CreateMap<CommentDto, Comment>().ReverseMap();
            CreateMap<NutrientPropertiesDto, NutrientProperties>().ReverseMap();
            CreateMap<UserProperties, UserPropertiesDto>().ReverseMap();
        }
    }
}
