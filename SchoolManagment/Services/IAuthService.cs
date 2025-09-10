using SchoolManagment.Models.ModelsDTO;

namespace SchoolManagment.Services
{
    public interface IAuthService
    {

        Task<TokenResponse> Authenticate(Auth auth);
    }
}
