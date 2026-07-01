using Autofac.Extras.DynamicProxy;
using IService;
using MyTool;
using System.Security.Claims;
using WebAppCore.AutofacExtensions;
using WebAppCore.DbModel;
using WebAppCore.ViewModels;

namespace WebAppCore.Service
{
    /// <summary>
    ///
    /// </summary>   
    public interface ISysUsersService : IBaseService<SysUser, int>
    {
		/// <summary>
		///
		/// </summary>
		string GetCaptcha(ref string strCode);
        string Login(LoginReq req, string sessionCode, ref TokenInfo ti);
		LoginRes Login(LoginReq req, string sessionCode);
		string GetTableData(int? pageNum, int? pageSize, SysUsersModel req);
		
        string GetVxeTableData(int pageIndex, int pageSize, SysUsersModel data);

        string DeleteTableData(List<SysUsersModel> data);
        string AddTableData(List<SysUsersModel> data);

        string UpdateTableData(List<SysUsersModel> data);
        string GetTableDataBootStrap(int page, int rows, string userName);
        string SignUp(SysUsersModel user);
	}
}