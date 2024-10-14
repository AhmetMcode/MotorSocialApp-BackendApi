//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using MotorSocialApp.Application.DTOs;
//using MotorSocialApp.Application.Interfaces.AutoMapper;
//using MotorSocialApp.Application.Interfaces.UnitOfWorks;
//using MotorSocialApp.Domain.Entities;

//namespace MotorSocialApp.Application.Features.CariIslems.Queries.GetAllCariIslems
//{
//    public class GetAllCariIslemsQueryHandler : IRequestHandler<GetAllCariIslemsQueryRequest, IList<GetAllCariIslemsQueryResponse>>
//    {
//        private readonly IUnitOfWork unitOfWork;
//        private readonly IMapper mapper;

//        public GetAllCariIslemsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
//        {
//            this.unitOfWork = unitOfWork;
//            this.mapper = mapper;
//        }
//        public async Task<IList<GetAllCariIslemsQueryResponse>> Handle(GetAllCariIslemsQueryRequest request, CancellationToken cancellationToken)
//        {
//            var cariIslems = await unitOfWork.GetReadRepository<CariIslem>().GetAllAsync(include: x => x.Include(b => b.Kira));

//            var kira = mapper.Map<KiraDto, Kira>(new Kira());

//            var map = mapper.Map<GetAllCariIslemsQueryResponse, CariIslem>(cariIslems);

//            return map;
//        }
//    }
//}
