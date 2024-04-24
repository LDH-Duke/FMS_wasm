using FMS.Shared.Model;
using Microsoft.Extensions.Logging.Abstractions;
using System.Text.RegularExpressions;

namespace FMS.Client.Commons
{
    public class UsersComm
    {
        public UsersComm()
        {
            
        }

        /// <summary>
        /// 아이디 소문자 변환
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string CheckID(string userid)
        {
            if (userid == null) return null;
            
            return userid.ToLower();
        }
        
        /// <summary>
        /// 비밀번호 체크
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckPassWord(string password)
        {
            if (password != null && password.Length <= 8)
            {
                return false;
            }

            //숫자1이상, 영문1이상, 특수문자1이상
            Regex regexPass = new Regex(@"^(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{9,}$", RegexOptions.IgnorePatternWhitespace);
            return regexPass.IsMatch(password);
        }
    }
}
