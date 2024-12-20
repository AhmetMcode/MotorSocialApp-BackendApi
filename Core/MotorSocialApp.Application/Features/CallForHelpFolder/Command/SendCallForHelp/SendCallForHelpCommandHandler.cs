using MediatR;
using Microsoft.Extensions.Logging;
using MotorSocialApp.Application.Features.UserLastLocationFolder.Queries.GetNearbyUsers;
using MotorSocialApp.Application.Interfaces.AutoMapper;
using MotorSocialApp.Application.Interfaces.FirebaseNotificationServices;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using MotorSocialApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.CallForHelpFolder.Command.SendCallForHelp
{
    public class SendCallForHelpCommandHandler : IRequestHandler<SendCallForHelpCommandRequest, SendCallForHelpCommandResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<SendCallForHelpCommandHandler> logger;
        private readonly IFirebaseNotificationService firebaseNotificationService;

        public SendCallForHelpCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<SendCallForHelpCommandHandler> logger, IFirebaseNotificationService firebaseNotificationService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
            this.firebaseNotificationService = firebaseNotificationService;
        }

        public async Task<SendCallForHelpCommandResponse> Handle(SendCallForHelpCommandRequest request, CancellationToken cancellationToken)
        {


            var senderUser = await unitOfWork.GetReadRepository<User>().GetAsync(usr=>usr.Id==request.UserId);
            // 1. Tüm kullanıcıların LastLocation'larını getir (UserId != excludedUserId)
            var allLocations = await unitOfWork.GetReadRepository<UserLastLocation2>().GetAllAsync(
                predicate: x => x.UserId != request.UserId,
                orderBy: query => query.OrderByDescending(x => x.CreatedDate) // Tarihe göre sıralama
            );

            // 2. Aynı UserId'lerin son eklenen kaydını filtrele
            var lastLocations = allLocations
                .GroupBy(x => x.UserId) // UserId'ye göre gruplama
                .Select(g => g.First()) // Her gruptan en son ekleneni seç
                .ToList();
            double radiusKm = 10;
            // 3. Haversine Formülü ile mesafeleri hesaplayarak filtrele
            var nearbyUsers = lastLocations
                .Where(location =>
                    DistanceCalculator.CalculateDistance(request.Lat, request.Lng, location.Lat, location.Lng) <= radiusKm
                )
                .ToList();
            List<User> users = new List<User>();
            foreach (var nearbyUser in nearbyUsers)
            {
                var user = await unitOfWork.GetReadRepository<User>().GetAsync(usr => usr.Id == nearbyUser.UserId);
                users.Add(user);
            }
            foreach (var user in users)
            {

                try
                {
                    if (user.DeviceToken != null && user.DeviceToken != "")
                    {

                        var data = new Dictionary<string, string>();
                        data.Add("latitude", NumberFormatter.ConvertCommaToDot(request.Lat.ToString()));
                        data.Add("longitude", NumberFormatter.ConvertCommaToDot(request.Lng.ToString()));
                        await firebaseNotificationService.SendNotificationAsync(
                        deviceToken: user.DeviceToken,
                        title: CallForHelpEnumExtensions.ToFriendlyString(request.CallForHelpEnum),
                        body: $"{senderUser.FullName} adlı kullanıcıdan {CallForHelpEnumExtensions.ToFriendlyString(request.CallForHelpEnum)} çağrısı.",
                        data: data


                        );
                    }

                }
                catch (Exception ex)
                {
                    logger.LogError(ex, ex.ToString());
                }




            }

            return new SendCallForHelpCommandResponse
            {
                NearbyCountUser = nearbyUsers.Count
            };
        }




    }

    public static class CallForHelpEnumExtensions
    {
        public static string ToFriendlyString(this CallForHelpEnum value)
        {
            return value switch
            {
                CallForHelpEnum.kazaYardim => "Kaza Yardımı",
                CallForHelpEnum.sorunYardim => "Sorun Yardımı",
                CallForHelpEnum.beniBul => "Beni Bul",
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Geçersiz bir CallForHelpEnum değeri!")
            };
        }
    }

    public static class DistanceCalculator
    {
        private const double EarthRadiusKm = 6371; // Dünya'nın yarıçapı km cinsinden

        public static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            // Dereceyi radyana çevirme
            double dLat = (lat2 - lat1) * Math.PI / 180.0;
            double dLon = (lon2 - lon1) * Math.PI / 180.0;

            // Enlem değerlerini radyan cinsine çevirme
            lat1 = lat1 * Math.PI / 180.0;
            lat2 = lat2 * Math.PI / 180.0;

            // Haversine formülü
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            // Mesafeyi döndür (kilometre cinsinden)
            return EarthRadiusKm * c;
        }
    }
}

public class NumberFormatter
{
    public static string ConvertCommaToDot(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return input;

        // Kültüre bağlı dönüşüm yapar
        if (double.TryParse(input, NumberStyles.Any, new CultureInfo("tr-TR"), out double result))
        {
            return result.ToString(CultureInfo.InvariantCulture);
        }

        throw new FormatException("Geçersiz sayı formatı!");
    }

   
}