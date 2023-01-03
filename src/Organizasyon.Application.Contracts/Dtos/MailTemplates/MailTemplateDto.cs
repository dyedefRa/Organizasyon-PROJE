using Organizasyon.Enums;
using System;
using Volo.Abp.Application.Dtos;

namespace Organizasyon.Dtos.MailTemplates
{
    public class MailTemplateDto : EntityDto<int>
    {
        public string Subject { get; set; }
        public string MailKey { get; set; }
        public string MailTemplateValue { get; set; }
        public DateTime InsertedDate { get; set; }
        public Status Status { get; set; }
    }
}
