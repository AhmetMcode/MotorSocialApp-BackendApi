using MotorSocialApp.Application.DTOs;


namespace MotorSocialApp.Application.Features.CariIslems.Queries.GetAllCariIslems
{
    public class GetAllCariIslemsQueryResponse
    {
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
        public KiraDto Kira { get; set; }
    }
}
