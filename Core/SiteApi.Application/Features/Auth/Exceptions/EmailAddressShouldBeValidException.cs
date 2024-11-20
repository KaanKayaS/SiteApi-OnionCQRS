using SiteApi.Application.Bases;

namespace SiteApi.Application.Features.Auth.Exceptions
{
    public class EmailAddressShouldBeValidException : BaseExceptions
    {
        public EmailAddressShouldBeValidException() : base("Böyle bir mail adresi bulunmamaktadır.") { }
    }

}
