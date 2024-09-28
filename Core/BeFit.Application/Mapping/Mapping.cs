using AutoMapper;
using BeFit.Application.DataTransferObjects.Create;
using BeFit.Application.DataTransferObjects.Friendship;
using BeFit.Application.DataTransferObjects.Update;
using BeFit.Domain.Entities;
using BeFit.Domain.Entities.Abstract;
using BeFit.Domain.Entities.Base;
using BeFit.Domain.Entities.Exercise;
using BeFit.Domain.Entities.Identity;
using BeFit.Domain.Entities.Macros;

namespace BeFit.Application.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        { 
            CreateMap<Nutrient, NutrientDto>();
            VVCC
            CreateMap<BaseEntity, BaseDto>();
            CreateMap<Food, FoodDto>().IncludeBase<Nutrient, NutrientDto>().ReverseMap();
            CreateMap<Drink, DrinkDto>().IncludeBase<Nutrient, NutrientDto>().ReverseMap();
            CreateMap<Cardio, CardioDto>().IncludeBase<Exercise, ExerciseDto>().ReverseMap();
            CreateMap<Training, TrainingDto>().IncludeBase<Exercise, ExerciseDto>().ReverseMap();
            CreateMap<Exercise, ExerciseDto>().ReverseMap();
            CreateMap<NutrientDto, Nutrient>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<CategoryImage, CategoryImageDto>().ReverseMap();
            CreateMap<NutrientImage, NutrientImageDto>().ReverseMap();
            CreateMap<PostImage, PostImageDto>().ReverseMap();
            CreateMap<CarbohydrateDto, Carbohydrate>().ReverseMap();
            CreateMap<FatDto, Fat>().ReverseMap();
            CreateMap<ProteinDto, Protein>().ReverseMap();
            CreateMap<SaltDto, Salt>().ReverseMap();
            CreateMap<MineralsDto, Minerals>().ReverseMap();
            CreateMap<Vitamins, VitaminsDto>().ReverseMap();
            CreateMap<Drink, DrinkDto>().ReverseMap();
            CreateMap<CommentDislike, CommentDislikeDto>().ReverseMap();
            CreateMap<CommentLike, CommentLikeDto>().ReverseMap();
            CreateMap<LikeDto, Like>().ReverseMap();
            CreateMap<DislikeDto, Dislike>().ReverseMap();
            CreateMap<PostLike, PostLikeDto>().ReverseMap();
            CreateMap<PostDislike, PostDislikeDto>().ReverseMap();
            CreateMap<PostDto, Post>().ReverseMap();
            CreateMap<CommentDto, Comment>().ReverseMap();
            CreateMap<NutrientProperties, NutrientPropertiesDto>().ReverseMap();
            CreateMap<UserProperties, UserPropertiesDto>().ReverseMap();
            CreateMap<CreateNutrientDto, FoodDto>().ReverseMap();
            CreateMap<CreateNutrientDto, DrinkDto>().ReverseMap();
            CreateMap<CreateNutrientDto, NutrientDto>().ReverseMap();
            CreateMap<CreateUserPropertiesDto, UserProperties>().ReverseMap();
            CreateMap<UpdateUserPropertiesDto, UserProperties>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
            CreateMap<Friendship, FriendshipDto>().ReverseMap();
            CreateMap<Friendship, SendFriendshipDto>().ReverseMap();
        }
    }
}
