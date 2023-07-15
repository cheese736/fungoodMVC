using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fungoodMVC.Dtos;
using fungoodMVC.Models;

namespace fungoodMVC
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<PostOrderDto, Order>();
		}
	}
}