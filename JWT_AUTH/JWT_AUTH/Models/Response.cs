﻿namespace JWT_AUTH.Models
{
    public class Response
    {

        public string Message { get; set; } = string.Empty;

        public int Code { get; set; } = 0;

        public  dynamic data { get; set; } 


        public string Error { get; set; } = string.Empty;

    }
}
