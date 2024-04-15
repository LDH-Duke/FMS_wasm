using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Shared.DTO
{
    /*
         메일의 제목
         메일의 내용
         첨부파일 경로
         보낼사람[]
    */

    public class MailInfo
    {
        /// <summary>
        /// 메일의 제목
        /// </summary>
        public string SubJect { get; set; }
        
        /// <summary>
        /// 메일의 내용
        /// </summary>
        public string Contents { get; set; }

        /// <summary>
        /// 첨부파일 경로
        /// </summary>
        public string Attach { get; set; }

        /// <summary>
        /// 보낼사람
        /// </summary>
        public List<string> Address { get; set; }
    }
}
