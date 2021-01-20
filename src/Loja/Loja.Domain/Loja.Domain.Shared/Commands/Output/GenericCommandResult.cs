using System.Collections.Generic;

namespace Loja.Domain.Shared.Command
{
    public class GenericCommandResult : IGenericCommandResult
    {

        public GenericCommandResult()
        {

        }
        public GenericCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;

            if (success)
                Data = data;
            else
                Errors = data;
        }


        public GenericCommandResult(bool success, string message, string property = "")
        {
            Success = success;


            if (Errors is null)
                Errors = new List<object>() { new { property, message } };
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Errors { get; set; }
        public object Data { get; set; }


    }
}
