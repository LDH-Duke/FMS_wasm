using FMS.Shared.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace FMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        MailMessage mail;


        [HttpPost]
        public void Post([FromBody] MailsDTO dto)
        {
            mail = new MailMessage();
            mail.From = new MailAddress(dto.From); // 보낸사람
            mail.Subject = dto.Subject; // 메일의 제목
            mail.Body = dto.Content; // 메일의 내용

            // 첨부파일 추가
            /*
            Attachment Attach = new Attachment(dto.AttachPath);
            mail.Attachments.Add(Attach);
            */

            // 인증관련 - 이건 회사메일껄로 해야함. (현재는 테스트)
            var client = new SmtpClient()
            {
                Port = 587, // google
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Host = "smtp.gmail.com",
                EnableSsl = true,

                // 구글 정책 변경으로 인해 2단계 인증 내용
                // gmail ID / 2단계 비밀번호
                Credentials = new NetworkCredential("dyddnkim95@gmail.com", "jtrw hikp jifq dusl")
            };

            client.Send(mail);
            Console.WriteLine("전송완료");

        }

    }
}
