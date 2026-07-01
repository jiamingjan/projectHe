using IRepository;
using WebAppCore.ViewModels;

namespace IService
{
    public interface IBaseService<T, TKey> : IBaseRepository<T, TKey> where T : class
    {
		TokenParse GetTokenUser(string token);
		string GetTokenUserName(string token);
	}
}
