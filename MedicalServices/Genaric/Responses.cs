﻿using System.Net;

namespace MedicalServices.Genaric
{
    // Generic response class to encapsulate responses from service methods
    public class Responses<T>
    {
        public Responses()
        {

        }
        public Responses(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }
        public Responses(string message)
        {
            Succeeded = false;
            Message = message;
        }
        public Responses(string message, bool succeeded)
        {
            Succeeded = succeeded;
            Message = message;
        }

        public HttpStatusCode StatusCode { get; set; }
        public object Meta { get; set; }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }

}