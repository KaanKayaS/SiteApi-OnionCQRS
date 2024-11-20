using SiteApi.Application.Bases;

namespace SiteApi.Application.Features.Auth.Exceptions
{
    public class RefreshTokenShouldNotBeExpiredException : BaseExceptions
    {
        public RefreshTokenShouldNotBeExpiredException() : base("Oturum açma süresi sona ermiştir lütfen tekrar giriş yapınız") { }
    }

}
