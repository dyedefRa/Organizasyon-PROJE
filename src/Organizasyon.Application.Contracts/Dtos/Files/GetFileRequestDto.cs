﻿using System;

namespace Organizasyon.Dtos.Files
{
    public class GetFileRequestDto
    {
        public string ContentType { get; set; }
        public Byte[] FileBytes { get; set; }
    }
}
