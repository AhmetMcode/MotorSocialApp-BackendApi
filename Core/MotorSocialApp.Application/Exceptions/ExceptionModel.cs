using Newtonsoft.Json;

namespace MotorSocialApp.Application.Exceptions
{
    public class ExceptionModel : MotorSocialApp
    {
        public IEnumerable<string> Errors { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class MotorSocialApp
    {
        public int StatusCode { get; set; }
    }
}