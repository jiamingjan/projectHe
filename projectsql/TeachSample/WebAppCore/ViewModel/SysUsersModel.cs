
namespace WebAppCore.ViewModels
{
    public class SysUsersModel
    {
        public long? userId { get; set; }

        public string? nickName { get; set; }

        public string? phone { get; set; }

        public int? roleId { get; set; }

        public string? salt { get; set; }

        public string? avatar { get; set; }

        public string? sex { get; set; }

        public string? email { get; set; }

        public int? deptId { get; set; }

        public int? postId { get; set; }

        public string? createBy { get; set; }

        public string? updateBy { get; set; }

        public string? remark { get; set; }

        public string? status { get; set; }

        public DateTime? create_time { get; set; }

        public DateTime? update_time { get; set; }

        public DateTime? delete_time { get; set; }

        public string? username { get; set; }

        public string? password { get; set; }

        /// <summary>
        /// 多角色
        /// </summary>
        public string? roleIds { get; set; }

        /// <summary>
        /// 多岗位
        /// </summary>
        public string? postIds { get; set; }
    }

    public class SysUsersModel2
    {
        public string userId { get; set; }

        public string? nickName { get; set; }

        public string? phone { get; set; }

		public string? roleIds { get; set; }
		public string? email { get; set; }
		public string? username { get; set; }
	}

    public class ResetPasswordReq
    {
        public long UserId { get; set; }
        public string? UserName { get; set; }

        public string? Password { get; set; }
    }

    public class UserWithAffix
    {
        public SysUsersModel data { get; set; }
        public string postIds { get; set; }
        public string roleIds { get; set; }
        public List<SysPostsModel> posts { get; set; }
        public List<SysRolesModel> roles { get; set; }
    }

    /// <summary>
    /// 验证码返回数据
    /// </summary>
    public class CheckCodeRes
    {
        public string base64Captcha { get; set; }
        public string captchaId { get; set; }
    }

    public class LoginReq
    {
        public string username { get; set; }
        public string password { get; set; }
        public string captcha { get; set; }//用户输入
        public string captchaId { get; set; } //前台传回来的base64编码后的数据（本来就是后台传过去）
    }

    public class MenuMeta
    {
        public string title { get; set; }//中文
        public string isLink { get; set; } //全都空字符串？
        public bool isHide { get; set; }
        public bool isKeepAlive { get; set; }
        public bool isAffix { get; set; }
        public bool isFrame { get; set; }
        public List<string> auth { get; set; } //["system:user:list"]
        public string icon { get; set; }
    }

    //这个因为需要针对sort进行排序，所以实现这个接口
    public class Menu : IComparable<Menu>
    {
        public string name { get; set; }
        public string path { get; set; }
        public string redirect { get; set; }
        public string component { get; set; } //?
        public int? sort { get; set; } //排序
        public MenuMeta meta { get; set; }
        public List<Menu> children { get; set; }//叶子节点没有内容[]

        // list.Sort()时会根据该CompareTo()进行自定义比较
        public int CompareTo(Menu other)
        {
            if (this.sort != null && other.sort != null && this.sort != other.sort)
            {
                return ((int)this.sort).CompareTo((int)other.sort);
            }
            else return 0;
        }
    }

    //public class LoginUserData
    //{
    //    public long userId { get; set; }
    //    public string nickName { get; set; }
    //    public string phone { get; set; }
    //    public int? roleId { get; set; } //
    //    public string salt { get; set; }
    //    public string avatar { get; set; }
    //    public string sex { get; set; }
    //    public string email { get; set; }
    //    public int? deptId { get; set; }
    //    public int? postId { get; set; }
    //    public string createBy { get; set; }
    //    public string updateBy { get; set; }
    //    public string remark { get; set; }
    //    public string status { get; set; }
    //    public string create_time { get; set; }
    //    public string update_time { get; set; }
    //    public string username { get; set; }
    //    public string password { get; set; } //编码
    //    public string roleIds { get; set; }
    //    public string postIds { get; set; }
    //}

    public class LoginResData
    {
        public long expire { get; set; }
        public List<Menu> menus { get; set; }
        public List<string> permissions { get; set; }
        public string token { get; set; } //
        //public LoginUserData user { get; set; }
        public SysUsersModel user { get; set; }

    }

    public class LoginRes
    {
        public int code { get; set; }
        public string msg { get; set; }
        public LoginResData data { get; set; }
    }

    public class ChangePwdReq
    {
        public string newPassword { get; set; }
        public string oldPassword { get; set; }
    }
}