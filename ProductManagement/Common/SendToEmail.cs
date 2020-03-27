using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks; 

namespace Common
{
    /// <summary>
    /// 发送邮箱
    /// </summary>
    public static class SendToEmail
    {
        /// <summary>
        /// 发送修改密码地址到用户邮箱
        /// </summary>
        /// <param name="email"></param>
        public static void UpdPwdAddrToEmail(string userName,string email)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            mail.From = new MailAddress("foxming0904@163.com");
            mail.To.Add(new MailAddress(email));
            mail.IsBodyHtml = true;
            mail.SubjectEncoding = Encoding.UTF8;
            mail.Subject = "后台产品管理系统";
            mail.BodyEncoding = Encoding.UTF8;
            mail.Priority = MailPriority.High;
            var encryptname = userName.Encrypt();
            string msg = $@"后台产品管理系统
                                          您于{  DateTime.Now.ToString("yyyy-MM-dd-ss") }
                                    找回用户：{userName}的密码   如非本人操作，请忽略本邮件或联系管理员----  修改密码地址：  http://localhost:21205/User/ResetUserPasswordPage?userName={encryptname}";

            mail.Body = msg;
            //发件邮箱的服务器地址
            smtp.Host = " smtp.163.com";
            //是否为SSL加密
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = true;
            //验证发件人的凭据
            smtp.Credentials = new System.Net.NetworkCredential("foxming0904@163.com", "foxjiumeng4857");
            smtp.Send(mail);

        }
    }
}
