using MediatR;
using Microsoft.Extensions.Logging;
using MotorSocialApp.Application.Interfaces.FirebaseNotificationServices;
using MotorSocialApp.Application.Interfaces.Repositories;
using MotorSocialApp.Application.Interfaces.Tokens;
using MotorSocialApp.Application.Interfaces.UnitOfWorks;
using MotorSocialApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Application.Features.UserLastLocationFolder.Queries.GetNearbyUsers
{
    public class GetNearbyUsersQueryHandler : IRequestHandler<GetNearbyUsersQueryRequest, GetNearbyUsersQueryResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFirebaseNotificationService firebaseNotificationService;
        private readonly ILogger<GetNearbyUsersQueryRequest> logger;

        public GetNearbyUsersQueryHandler(IUnitOfWork unitOfWork,IFirebaseNotificationService firebaseNotificationService,ILogger<GetNearbyUsersQueryRequest> logger)
        {
            this.unitOfWork = unitOfWork;
            this.firebaseNotificationService = firebaseNotificationService;
            this.logger = logger;
        }

        public async Task<GetNearbyUsersQueryResponse> Handle(GetNearbyUsersQueryRequest request, CancellationToken cancellationToken)
        {
           

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
            foreach (var nearbyUser in nearbyUsers) {
                var user = await unitOfWork.GetReadRepository<User>().GetAsync(usr=>usr.Id==nearbyUser.UserId);
                users.Add(user);
            }

            foreach(var user in users)
            {

                try {
                    if (user.DeviceToken != null && user.DeviceToken!="")
                    {
                        await firebaseNotificationService.SendNotificationAsync(
                        user.DeviceToken,
                        "Kaza Yardımı",
                        "Kaza Yardımı"
                        );
                    }

                }
                catch (Exception ex) {
                    logger.LogError(ex,ex.ToString());
                }

               
                
               
            }

            return new GetNearbyUsersQueryResponse
            {
                NearbyCountUser= nearbyUsers.Count
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

