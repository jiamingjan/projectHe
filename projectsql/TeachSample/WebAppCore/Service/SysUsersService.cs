using System.Text.Json;
using WebAppCore.DbModel;
using WebAppCore.ViewModels;
using Service;
using IRepository;
using System.Linq.Expressions;
using WebAppCore.DbExtensions;
using AutoMapper;
using MyTool;
using SixLabors.ImageSharp.Formats.Gif;
using System.Security.Cryptography;
using System.Text;
using NPOI.HSSF.Record;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using NPOI.SS.UserModel;
//using Newtonsoft.Json;


namespace WebAppCore.Service
{
    /// <summary>
    ///
    /// </summary>   
    public class SysUsersService : BaseService<SysUser, int>, ISysUsersService
    {
        private readonly ISysUsersDAL _repository;
		private readonly ISysMenusDAL _menusRepository;
		private readonly IMapper _mapper;
        public SysUsersService(ISysUsersDAL repository, ISysMenusDAL menusRepository, IMapper mapper) : base(repository)
        {
            _repository = repository;
			_menusRepository = menusRepository;
			_mapper = mapper;
        }
		/// <summary>
		///
		/// </summary>
		/// 
		public string GetCaptcha(ref string strCode)
		{
			int codeLen = 4; //长度
			strCode = CheckCode.MakeCode(codeLen);  
			MemoryStream imgCode = CheckCode.CheckCodeImage(strCode, GifFormat.Instance);
			CheckCodeRes captCha = new CheckCodeRes();

			//image
			string info = "data:image/gif;base64,"; //可以是png，等等
			captCha.base64Captcha = info + Convert.ToBase64String(imgCode.ToArray());

			//code            
			captCha.captchaId = Base64.Encode(strCode);

			

			//return
			string json = JsonSerializer.Serialize(captCha);
			return json;
		}

		/// <summary>
		/// 这个是旧的，可以产生token
		/// </summary>
		/// <param name="req"></param>
		/// <param name="sessionCode"></param>
		/// <param name="ti"></param>
		/// <returns></returns>
		public string Login(LoginReq req, string sessionCode, ref TokenInfo ti)
		{
			//err
			//resStr = "{\"code\":200,\"msg\":\"验证码认证失败\",\"data\":null}";
			LoginRes res = new LoginRes();
			//Check input
			if (req == null)
			{
				res.code = 400;//?
				res.msg = "请求参数无效，请联系管理员！";
				return JsonSerializer.Serialize(res);
			}

			//这里也后台验证一下验证码、用户名、密码是否传递过来
			if (string.IsNullOrEmpty(req.captcha))
			{
				res.code = 400;//?
				res.msg = "请输入验证码！";
				return JsonSerializer.Serialize(res);
			}

			if (string.IsNullOrEmpty(req.username))
			{
				res.code = 400;//?
				res.msg = "请输入用户名！";
				return JsonSerializer.Serialize(res);
			}

			if (string.IsNullOrEmpty(req.password))
			{
				res.code = 400;//?
				res.msg = "请输入密码！";
				return JsonSerializer.Serialize(res);
			}

			if (checkReqCode(req, sessionCode,ref res) == false)
				return JsonSerializer.Serialize(res);

			bool ret = checkLoginUser(req, ref res);
			if (ret)
			{
				//gen token
				ti = new TokenInfo(req.username, req.password);
				res.data.token = TokenHelper.GenToken(ti);

				//save user info for validate token late request
				//HttpContext.Current.Session["TokenInfo"] = ti;
			}

			return JsonSerializer.Serialize(res);
		}

		public LoginRes Login(LoginReq req, string sessionCode)
		{
			//err
			//resStr = "{\"code\":200,\"msg\":\"验证码认证失败\",\"data\":null}";
			LoginRes res = new LoginRes();
			//Check input
			if (req == null)
			{
				res.code = 400;//?
				res.msg = "请求参数无效，请联系管理员！";
				return res;
			}

			//这里也后台验证一下验证码、用户名、密码是否传递过来
			if (string.IsNullOrEmpty(req.captcha))
			{
				res.code = 400;//?
				res.msg = "请输入验证码！";
				return res;
			}

			if (string.IsNullOrEmpty(req.username))
			{
				res.code = 400;//?
				res.msg = "请输入用户名！";
				return res;
			}

			if (string.IsNullOrEmpty(req.password))
			{
				res.code = 400;//?
				res.msg = "请输入密码！";
				return res;
			}

			if (checkReqCode(req, sessionCode, ref res) == false)
				return res;

			checkLoginUser(req, ref res);
			return res;
		}

		/// <summary>
		/// 验证码验证比对
		/// 其实有2种方法：
		/// 1.利用传过来的传输中用户输入req.captcha（未编码）和req.captchaId(base64编码返回的值直接验证比较（当然要转码）
		/// 2.利用传过来的传输中用户输入req.captcha（未编码）和后台session存的进行比较（不用要转码）
		/// 下面就用的是2
		/// </summary>
		/// <param name="req"></param>
		/// <returns></returns>
		private bool checkReqCode(LoginReq req,string sessionCode, ref LoginRes res)
		{
			//err
			//resStr = "{\"code\":200,\"msg\":\"验证码认证失败\",\"data\":null}";           
			//var sessionCode = HttpContext.Current.Session["CheckCode"];

			if (sessionCode == null || string.IsNullOrEmpty(req.captcha) || !req.captcha.ToUpper().Equals(sessionCode.ToString().ToUpper()))//这里不区分大小写
			{
				res.code = 400;
				res.msg = "验证码认证失败";
				return false;
			}
			else
			{
				res.code = 200;
				res.msg = "success";
				return true;
			}

		}

		private bool checkLoginUser(LoginReq req, ref LoginRes res)
		{
			if (res == null)
				res = new LoginRes();
			res.data = new LoginResData();

			DateTime startDate = new DateTime(1970, 1, 1, 8, 0, 0);
			DateTime endDate = DateTime.Now.AddDays(7); // 7 天后过期
			TimeSpan seconds = endDate - startDate;
			res.data.expire = Convert.ToInt64(seconds.TotalSeconds);
			var query = _repository.LoadEntities(r => r.Username != null && r.Username.Trim().Equals(req.username.Trim()), r => r.UserId, true);
			List <SysUser> usersList = query?.ToList() ?? new List<SysUser>();
			if (usersList == null || usersList.Count <= 0)
			{
				res.code = 400;
				res.msg = "用户不存在";
				return false;
			}
			
			if (string.IsNullOrEmpty(usersList[0].Password))
			{
				res.code = 400;
				res.msg = "用户密码为空";
				return false;
			}

			string strPwd = req.password.Trim();
			if (strPwd.Length < 25) //如果大于等于25表示前端已经加过密了，这里就直接比较
			{
				MD5 md5 = new MD5CryptoServiceProvider();
				byte[] pwd = Encoding.Default.GetBytes(req.password.Trim());
				byte[] md5Pwd = md5.ComputeHash(pwd);
				strPwd = BitConverter.ToString(md5Pwd).Replace("-", "");
			}			

			//这里要注意忽略大小写
			if (!string.Equals(usersList[0].Password,strPwd,StringComparison.OrdinalIgnoreCase))
			{
				res.code = 400;
				res.msg = "密码不正确";
				return false;
			}

			//List<SysUsersModel> userTabList = new List<SysUsersModel>();
			//TransforDataUp(userTabList, usersList);
			List<SysUsersModel> userTabList = _mapper.Map<List<SysUsersModel>>(usersList);
			res.data.user = userTabList[0];

			// 确保 role_ids 格式正确
			string roleIds = usersList[0].RoleIds;
			if (string.IsNullOrEmpty(roleIds))
			{
				res.code = 400;
				res.msg = "用户角色为空";
				return false;
			}
						
			try
			{
				List<SysMenu> sys_menuList = _menusRepository.GetSysMenusByRoleIds(roleIds);
				
				List<Menu> resMenu = null;

				List<SysMenu> no_F_menuList = new List<SysMenu>();
				List<string> perm = new List<string>();
				foreach (SysMenu one in sys_menuList)
				{
					if (!string.IsNullOrEmpty(one.Permission))
						perm.Add(one.Permission);

					if (!string.IsNullOrEmpty(one.MenuType) && !one.MenuType.ToUpper().Equals("F"))
						no_F_menuList.Add(one);
				}

				GetSubMenus(ref resMenu, no_F_menuList, 0);

				res.data.permissions = perm;
				res.data.menus = resMenu;
				res.code = 200;
				res.msg = "success";							
			}
			catch (Exception ex)
			{
				res.code = 500;
				res.msg = "SQL 语法错误: " + ex.Message;
				return false;
			}

			VisitorCounter.Init();
			VisitorCounter.UpdateVisitorCount();

			//List<(string month, int rowDataCount, int preDataCount, int featureDataCount, int rowDataIncrement, int preDataIncrement, int featureDataIncrement)> monthlyDataList = CacheManager.GetDataFromCache();
			//下面暂时注释，何
			//if (monthlyDataList == null)
			//{
			//	var home = new homeBLL();
			//	monthlyDataList = home.GetMonthlyDataCounts();
			//	Console.WriteLine(monthlyDataList);
			//}

			return true;
		}

		/// <param name="target"></param>
		/// <param name="src"></param>
		/// <param name="parentMenuId"></param>
		private void GetSubMenus(ref List<Menu> target, List<SysMenu> src, long parentMenuId)
		{
			foreach (SysMenu one in src)
			{
				if (one.ParentId == parentMenuId)
				{
					Menu menu = new Menu();
					menu.name = one.MenuName;
					menu.path = one.Path;
					menu.redirect = "";
					menu.component = one.Component;
					menu.sort = one.Sort;

					menu.meta = new MenuMeta();
					menu.meta.auth = new List<string>();//??数据哪里来？ helm
					menu.meta.icon = one.Icon;
					menu.meta.isAffix = false;//下面要查字典？
					if (!string.IsNullOrEmpty(one.IsAffix) && one.IsAffix.Equals("1"))
						menu.meta.isAffix = true;

					menu.meta.isFrame = false;
					if (!string.IsNullOrEmpty(one.IsFrame) && one.IsFrame.Equals("1"))
						menu.meta.isFrame = true;

					menu.meta.isHide = false;
					if (!string.IsNullOrEmpty(one.IsHide) && one.IsHide.Equals("1"))
						menu.meta.isHide = true;

					menu.meta.isKeepAlive = false;
					if (!string.IsNullOrEmpty(one.IsKeepAlive) && one.IsKeepAlive.Equals("1"))
						menu.meta.isKeepAlive = true;

					menu.meta.isLink = one.IsLink;
					menu.meta.title = string.IsNullOrEmpty(one.Title) ? one.MenuName : one.Title;//如果为空用name代替



					//特别注意：前台用到children.length要求children不能为null，所以这里必须创建一个，否则出错
					List<Menu> newtarget = new List<Menu>();

					//递归调用
					GetSubMenus(ref newtarget, src, one.MenuId);
					menu.children = newtarget;

					//把该节点row及所有子节点都加入到target数组中
					if (target == null)
						target = new List<Menu>();
					target.Add(menu);
				}
			}

			//这里根据sort字段进行排序
			if (target != null && target.Count > 0)
				target.Sort();
		}
				
		public string GetTableData(int? pageNum, int? pageSize, SysUsersModel req)
		{
			int total = 0;
			VueResMsg<VueTable<SysUsersModel>> res = new VueResMsg<VueTable<SysUsersModel>>();

			List<SysUser> resList = new List<SysUser>();

			Expression<Func<SysUser, bool>> pieceWhere = null!;
			pieceWhere = PredicateExtensions.True<SysUser>();
			if (!string.IsNullOrEmpty(req.username) && !req.username.Equals("null"))//null是没有传递参数
				pieceWhere = PredicateExtensions.And(pieceWhere, r => r.Username.Contains(req.username));//Contains 模糊匹配
			if (req.phone != null && !string.IsNullOrEmpty(req.phone) && !req.phone.Equals("null"))//null是没有传递参数
				pieceWhere = PredicateExtensions.And(pieceWhere, r => r.Phone.Contains(req.phone));//Contains 模糊匹配
			if (req.deptId != null && !req.deptId.Equals("null") && req.deptId > 0)//不存在这个条件会传0过来，所以这里过滤
				pieceWhere = PredicateExtensions.And(pieceWhere, r => r.DeptId == req.deptId);//Contains 模糊匹配
			if (req.status != null && !string.IsNullOrEmpty(req.status) && !req.status.Equals("null"))//null是没有传递参数
				pieceWhere = PredicateExtensions.And(pieceWhere, r => r.Status.Equals(req.status));//Contains 模糊匹配

			List<SysUser> records = _repository.LoadPageEntities<string?>( (int)pageNum, (int)pageSize,
				out total, pieceWhere, r => r.Username, true).ToList();

			List<SysUsersModel> results = _mapper.Map<List<SysUsersModel>>(records);
			res.SetOK();
			VueTable<SysUsersModel> table = new VueTable<SysUsersModel>();
			table.total = total;
			table.pageNum = (int)pageNum;
			table.pageSize = (int)pageSize;
			table.data = results;
			res.data = table;
			return JsonSerializer.Serialize(res);
		}


        public string GetVxeTableData(int pageIndex, int pageSize, SysUsersModel data)
        {
            int total = 0;

            Expression<Func<SysUser, bool>> pieceWhere = null!;
            pieceWhere = PredicateExtensions.True<SysUser>();
            if (!string.IsNullOrEmpty(data.username))
            {
                pieceWhere = PredicateExtensions.And(pieceWhere, r => r.Username.Equals(data.username));
            }
            if (!string.IsNullOrEmpty(data.nickName))
            {
                pieceWhere = PredicateExtensions.And(pieceWhere, r => r.NickName.Equals(data.nickName));
            }
            if (!string.IsNullOrEmpty(data.phone))
            {
                pieceWhere = PredicateExtensions.And(pieceWhere, r => r.Phone.Equals(data.phone));
            }
            if (!string.IsNullOrEmpty(data.email))
            {
                pieceWhere = PredicateExtensions.And(pieceWhere, r => r.Email.Equals(data.email));
            }


            List<SysUser> records = _repository.LoadPageEntities<long>((int)pageIndex!, (int)pageSize!, out total, pieceWhere, r => r.UserId, false).ToList();
            List<SysUsersModel> results = _mapper.Map<List<SysUsersModel>>(records);
            VxeGridTable<SysUsersModel> xGrid = new VxeGridTable<SysUsersModel>();
            xGrid.page = new page();
            xGrid.page.currentPage = pageIndex;
            xGrid.page.pageSize = pageSize;
            xGrid.page.total = total;
            xGrid.result = results;
            string json = JsonSerializer.Serialize(xGrid);
            return json;
        }

        public string AddTableData(List<SysUsersModel> data)
        {

            VueResMsg<string> resMsg = new VueResMsg<string>();
            if (data == null || data.Count <= 0)
            {
                resMsg.code = -1;
                resMsg.msg = "没有数据！";
                return JsonSerializer.Serialize(resMsg);
            }

            foreach (SysUsersModel one in data)
            {				
                if (string.IsNullOrEmpty(one.username) || one.username == "null")
                    continue;

				//if (string.IsNullOrEmpty(password) || password == "null")
				//{
				//    resMsg.code = -1;
				//    resMsg.msg = "密码为空！";
				//    return JsonSerializer.Serialize(resMsg);
				//}

				//是否已经注册
				SysUser? record = _repository.LoadEntities(r => r.Username == one.username, r => r.UserId, true).ToList().FirstOrDefault();//Tb_Login——DbModel中            
                if (record != null)
                    continue;

				SysUser user = _mapper.Map<SysUser>(one);
				user.UpdateTime = DateTime.Now;				
                user.CreateTime = DateTime.Now;
                _repository.Add(user, false);
            }


            int addNum = _repository.SaveChange();
            if (addNum >= 0)
            {
                resMsg.SetOK();
                resMsg.msg = addNum.ToString();
            }                
            else
            {
                resMsg.code = -1;
                resMsg.msg = "新增失败！";
            }

            string json = JsonSerializer.Serialize(resMsg);
            return json;
        }

		public string SignUp(SysUsersModel newuser)
		{
			VueResMsg<string> resMsg = new VueResMsg<string>();
			if (newuser == null || string.IsNullOrEmpty(newuser.username) || newuser.username == "null")
			{
				resMsg.code = -1;
				resMsg.msg = "用户名不为空！";
				return JsonSerializer.Serialize(resMsg);
			}

			//是否已经注册
			SysUser? record = _repository.LoadEntities(r => r.Username == newuser.username, r => r.UserId, true).ToList().FirstOrDefault();//Tb_Login——DbModel中            
			if (record != null)
			{
				resMsg.code = -1;
				resMsg.msg = "用户已经存在！";
				return JsonSerializer.Serialize(resMsg);
			}

			SysUser user = _mapper.Map<SysUser>(newuser);
				user.UpdateTime = DateTime.Now;
				user.CreateTime = DateTime.Now;
				_repository.Add(user, false);
			
			int addNum = _repository.SaveChange();
			if (addNum >= 0)
			{
				resMsg.SetOK();
				resMsg.msg = addNum.ToString();
			}
			else
			{
				resMsg.code = -1;
				resMsg.msg = "注册失败！";
			}

			string json = JsonSerializer.Serialize(resMsg);
			return json;
		}


		public string DeleteTableData(List<SysUsersModel> data)
        {
            VueResMsg<string> resMsg = new VueResMsg<string>();
            if (data == null || data.Count <= 0)
            {
                resMsg.code = -1;
                resMsg.msg = "没有数据！";
                return JsonSerializer.Serialize(resMsg);
            }

            foreach (SysUsersModel one in data)
            {
				SysUser user = new SysUser();
				if (one.userId != null)
				{
					user.UserId = (long)one.userId;
					_repository.Delete(user, false);
				}
            }


            int addNum = _repository.SaveChange();
            if (addNum >= 0)
            {
                resMsg.SetOK();
                resMsg.msg = addNum.ToString();
            }
            else
            {
                resMsg.code = -1;
                resMsg.msg = "删除失败！";
            }

            string json = JsonSerializer.Serialize(resMsg);
            return json;
        }

        public string UpdateTableData(List<SysUsersModel> data)
        {

            VueResMsg<string> resMsg = new VueResMsg<string>();
            if (data == null || data.Count <= 0)
            {
                resMsg.code = -1;
                resMsg.msg = "没有数据！";
                return JsonSerializer.Serialize(resMsg);
            }

            foreach (SysUsersModel one in data)
            {				
                if (string.IsNullOrEmpty(one.username) || one.username == "null")
                    continue;

				SysUser user = _mapper.Map<SysUser>(one);
				user.UpdateTime = DateTime.Now;
				_repository.Update(user, false);
            }


            int addNum = _repository.SaveChange();
            if (addNum >= 0)
            {
                resMsg.SetOK();
                resMsg.msg = addNum.ToString();
            }
            else
            {
                resMsg.code = -1;
                resMsg.msg = "更新失败！";
            }

            string json = JsonSerializer.Serialize(resMsg);
            return json;
        }

		public string GetTableDataBootStrap(int pageIndex, int pageSize, string userName)
		{
			int total = 0;		

			Expression<Func<SysUser, bool>> pieceWhere = PredicateExtensions.True<SysUser>();
			if (userName != null && !string.IsNullOrEmpty(userName))
				pieceWhere = PredicateExtensions.And(pieceWhere, r => r.Username.ToUpper().Contains(userName.ToUpper()));

			List<SysUser> records = _repository.LoadPageEntities<long>(pageIndex, pageSize, out total, pieceWhere, r => r.UserId, false).ToList();

			List<SysUsersModel> listdata = _mapper.Map<List<SysUsersModel>>(records);

			JqGridTable<SysUsersModel> jqGridTable = new JqGridTable<SysUsersModel>();
			jqGridTable.page = pageIndex;
			jqGridTable.records = total;
			jqGridTable.rows = listdata;
			jqGridTable.total = total / pageSize;
			if (total % pageSize != 0) jqGridTable.total++;
			string json = JsonSerializer.Serialize(jqGridTable);
			return json;
		}

	}
}