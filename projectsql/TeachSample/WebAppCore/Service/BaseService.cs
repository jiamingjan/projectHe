using IRepository;
using IService;
using JWT;
using MyTool;

using System.Linq.Expressions;
using System.Text.Json;
using WebAppCore.ViewModels;

///这里用这些的问题是在上层暴露了dbmodel，逻辑上不合适 helm
namespace Service
{
    public class BaseService<T, TKey> : IBaseService<T, TKey> where T : class
    {
        private readonly IBaseRepository<T, TKey> _repository;
        public BaseService(IBaseRepository<T, TKey> repository)
        {
            _repository = repository;
        }


        public T? Find(TKey id)
        {
            return _repository.Find(id);
        }

        public T? Find(Expression<Func<T, bool>> wherelamb)
        {
            return _repository.Find(wherelamb);
        }

        public IQueryable<T> LoadEntities<S>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderbyLambda, bool isAsc)
        {
            return _repository.LoadEntities(whereLambda, orderbyLambda, isAsc);
        }

        public IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderbyLambda, bool isAsc)
        {
            return _repository.LoadPageEntities(pageIndex, pageSize, out total, whereLambda, orderbyLambda, isAsc);
        }

        public int SaveChange()
        {
            return _repository.SaveChange();
        }

        public bool Update(T entity, bool isSaveChage = true)
        {
            return _repository.Update(entity, isSaveChage);
        }

        public void Add(T entity, bool isSaveChage = true)
        {
            _repository.Add(entity, isSaveChage = true);
        }
        public bool Delete(T entity, bool isSaveChage = true)
        {
            return _repository.Delete(entity, isSaveChage);
        }

        public int Delete(params int[] ids)
        {
            return _repository.Delete(ids);
        }
        public void Dispose()
        {
            _repository.Dispose();
        }

        public TokenParse GetTokenUser(string token)
        {
            if (token == null)
                return null;
			TokenParse user = new TokenParse();
			JwtSettings jwtSettings = GlobalStateService.jwtSettings; ;
			if (jwtSettings != null)
            {
                string res = "";
				bool ret = TokenHelper.DecodeToken(token, jwtSettings.SecretKey,ref res);
				if (!string.IsNullOrEmpty(res) && ret)
					user = JsonSerializer.Deserialize<TokenParse>(res);
			}

			return user;
		}

		public string GetTokenUserName(string token)
        {
            string userName = "";
            TokenParse user = GetTokenUser(token);
            if (user != null)
            {
				userName = user.unique_name;
            }
            return userName;
		}

	}
}

