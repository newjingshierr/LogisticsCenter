
using System.ComponentModel;

namespace Logistics_Model
{
    public enum SystemStatusEnum
    {
        /// <summary>
        /// 请求成功
        /// </summary>
        [Description("成功")]
        Sucess = 0,

        /// <summary>
        /// 系统错误
        /// </summary>
        [Description("系统错误")]
        ServerError = 1,

        /// <summary>
        /// 不存在
        /// </summary>
        [Description("不存在")]
        NotFound = 2,

        /// <summary>
        /// 请求参数不合法
        /// </summary>
        [Description("请求参数不合法")]
        InvalidRequest = 4,


        /// <summary>
        /// code参数不合法
        /// </summary>
        [Description("code参数不合法")]
        InvalidCodeRequest = 5,

        /// <summary>
        /// 电话或者邮箱不合法
        /// </summary>
        [Description("电话或者邮箱不合法")]
        InvalidTelOrMailRequest = 6,


        /// <summary>
        /// 两次密码输入不一致
        /// </summary>
        [Description("两次密码输入不一致")]
        PwdRepeatRequest = 7,

        /// <summary>
        /// 密码长度小6位
        /// </summary>
        [Description("密码长度小6位")]
        PwdLess6Request = 8,

        /// <summary>
        /// 用户名不合法
        /// </summary>
        [Description("用户名不合法")]
        InvalidUserNameRequest = 9,


        /// <summary>
        /// 密码不合法
        /// </summary>
        [Description("密码不合法")]
        InvalidPwdRequest = 10,

        /// <summary>
        /// 用户不合法
        /// </summary>
        [Description("用户不合法")]
        InvalidUserRequest = 11,

        /// <summary>
        /// 用户名已经存在
        /// </summary>
        [Description("用户名已经存在")]
        InvalidUserExistRequest = 12,

        /// <summary>
        /// code参数不合法
        /// </summary>
        [Description("操作太频繁")]
        OperateRateRequest = 13,

        /// <summary>
        /// 商户不存在
        /// </summary>
        [Description("商户不存在")]
        TenantNotExist = 100,

        /// <summary>
        /// 没有权限
        /// </summary>
        [Description("Access Denied")]
        AccessDenied = 401,
    }
}
