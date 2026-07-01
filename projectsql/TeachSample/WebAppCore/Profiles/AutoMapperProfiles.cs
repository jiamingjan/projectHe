
using AutoMapper;
using WebAppCore.DbModel;
using WebAppCore.ViewModels;

namespace WebAppCore.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
			//特别说明：如果RadarRawDatum和RadarRawDatumModel之间有不同的属性，不同的可能需要手工赋值

			//构造函数中创建映射关系
			CreateMap<SysDictType, SysDictTypeModel>();
			//构造函数中创建映射关系，这个是双向转换
			CreateMap<SysDictDatum, SysDictDatumModel>().ReverseMap();
			CreateMap<stockrecom, StockRecomModel>().ReverseMap();
			//CreateMap<SysUser, SysUsersModel>().ReverseMap();
			CreateMap<SysUser, SysUsersModel>()
				.ForMember(dest => dest.update_time, opt => opt.MapFrom(src => src.UpdateTime)) 
				.ForMember(dest => dest.create_time, opt => opt.MapFrom(src => src.CreateTime)).ReverseMap();  
	//.ForMember(dest => dest.create_time, opt => opt.MapFrom(src => src.Age > 18 ? "Adult" : "Child")); // 条件逻辑映射Age到AgeGroup
			CreateMap<queryinfo, QueryInfoModel>().ReverseMap();
			CreateMap<SysDept, SysDeptsModel>().ReverseMap();
			CreateMap<SysRole, SysRolesModel>().ReverseMap();
			CreateMap<SysRoleMenu, SysRoleMenusModel>().ReverseMap();
			CreateMap<SysMenu, SysMenusModel>().ReverseMap();
			CreateMap<SysPost, SysPostsModel>().ReverseMap();
			CreateMap<SysApi, SysApisModel>().ReverseMap();
			CreateMap<CasbinRule, CasbinRuleModel>().ReverseMap();
			CreateMap<SysConfig, SysConfigsModel>().ReverseMap();			
			CreateMap<FalldownDevice, FalldownDeviceModel>().ReverseMap();
			CreateMap<ProjectInfo, ProjectInfoModel>().ReverseMap();
            CreateMap<ColorDiff, ColorDiffModel>().ReverseMap();
			//CreateMap<SysRoleDept, SysRoleDeptModel>().ReverseMap();
		}
    }
}