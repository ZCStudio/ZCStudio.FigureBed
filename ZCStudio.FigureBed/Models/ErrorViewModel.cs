﻿namespace ZCStudio.FigureBed.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string StatusCode { get; set; }
    }
}