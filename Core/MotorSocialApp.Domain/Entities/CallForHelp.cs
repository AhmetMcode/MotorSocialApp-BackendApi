using MotorSocialApp.Domain.Common;
using MotorSocialApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorSocialApp.Domain.Entities
{
    public class CallForHelp : EntityBase,IEntityBase
    {
        public Guid UserId { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public CallForHelpEnum  CallForHelpEnum { get;set; }
    }
}
