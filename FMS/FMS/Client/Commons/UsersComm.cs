using FMS.Shared.Models;
using System.Text.RegularExpressions;

namespace FMS.Client.Commons
{
    public class UsersComm
    {
        public UsersComm()
        {
            
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
