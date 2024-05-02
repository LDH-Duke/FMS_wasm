using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Shared.DTO
{
    public class MailsDTO
    {
        /// <summary>
        /// 보낸사람
        /// </summary>
        public string From { get; set; }
        
        /// <summary>
        /// 제목
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 내용
        /// </summary>
        public string? Content { get; set; }

        /// <summary>
        /// 첨부파일 경로
        /// </summary>
        public string? AttachPath { get; set; }

        /// <summary>
        /// 받을사람
        /// </summary>
        public List<string> To { get; set; }

    }
}
