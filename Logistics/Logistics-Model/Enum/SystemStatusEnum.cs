
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
        /// 操作太频繁
        /// </summary>
        [Description("操作太频繁")]
        OperateRateRequest = 13,

        /// <summary>
        /// 不能设定相同的密码
        /// </summary>
        [Description("不能设定相同的密码")]
        BadPwdRequest = 14,

        /// <summary>
        /// 注销失败
        /// </summary>
        [Description("注销失败")]
        SigoutErrorRequest = 15,
        /// <summary>
        ///
        /// </summary>
        [Description("非法角色")]
        InvalidRoleRequest = 16,

        [Description("非法导航")]
        InvalidNavigationRequest = 17,

        [Description("此验证码已过期，请重新获取")]
        ExpiredCodeRequest = 18,

        [Description("文件上传失败")]
        FileUploadFailedRequest = 19,

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

        ///系统 4000-4100
        #region
        ///角色没有找到
        [Description("Role Not Found")]
        RoleNotFound = 4000,

        /// <summary>
        /// 导航没有找到
        /// </summary>
        [Description("Navigation Not Found")]
        NavigationNotFound = 40001,
        /// <summary>
        /// 用户信息不存在
        /// </summary>
        [Description("Userinfo Not Found")]
        UserinfoNotFound = 40002,
        [Description("TokenExpired")]
        TokenExpired = 40003,

        [Description("Channel not found")]
        ChannelNotFound = 40005,
        #endregion
        //用户订单 42000-4300
        [Description("Order Exception")]
        OrderException = 42000,

        [Description("Order Status Not Found")]
        OrderStatusNotFound = 42001,

        [Description("Order Status Not Draft 0")]
        OrderStatusNotDraft = 42002,

        [Description("Order Status Not Draft 0")]
        CustomerOrderDeleteFailed = 42003,

        [Description("Order update failed")]
        CustomerOrdeUpdateFailed = 42004,

        [Description("CustomerOrdeAttachmentDeleteFailed")]
        CustomerOrdeAttachmentDeleteFailed = 42005,
        #region

        #endregion
    }
}
