using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.CariIslems.Queries.GetAllCariIslems
{
    public class GetAllCariIslemsQueryRequest : IRequest<IList<GetAllCariIslemsQueryResponse>>
    {
    }
}
