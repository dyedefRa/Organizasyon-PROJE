using Organizasyon.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace Organizasyon.Entities.Files
{
    [Table(OrganizasyonConsts.DbTablePrefix + "Files")]
    public class File : Entity<int>
    {
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public long? FileSize { get; set; }
        public string FilePath { get; set; }
        public string FullPath { get; set; }
        public string Title { get; set; }
        public string ContentType { get; set; }
        public Status Status { get; set; }
    }
}
