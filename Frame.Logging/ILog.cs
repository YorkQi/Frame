using System;
using System.Threading.Tasks;

namespace Frame.Logging
{
    public interface ILog
    {
        /// <summary>
        /// 程序正常运行时使用
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="Code"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        Task Info(Exception exception, string Code, string Message);

        /// <summary>
        /// 程序调试bug时使用
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="Code"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        Task Debug(Exception exception, string Code, string Message);

        /// <summary>
        /// 程序未按预期运行时使用，但并不是错误，如:用户登录密码错误
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="Code"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        Task Warning(Exception exception, string Code, string Message);

        /// <summary>
        /// 程序出错误时使用，如:IO操作失败
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="Code"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        Task Error(Exception exception, string Code, string Message);

        /// <summary>
        /// 特别严重的问题，导致程序不能再继续运行时使用，如:磁盘空间为空
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="Code"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        Task Critical(Exception exception, string Code, string Message);
    }
}
