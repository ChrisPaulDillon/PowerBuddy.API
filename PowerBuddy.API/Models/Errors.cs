using System.Collections.Generic;
using System.Text.Json.Serialization;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace PowerBuddy.API.Models
{
    public class Errors
    {
        [JsonPropertyName("Code")]
        public string Code { get; }

        [JsonPropertyName("Message")]
        public string Message { get; }

        private Errors(string code, string message)
        {
            Code = code;
            Message = message;
        }

        private Errors(string code)
        {
            Code = code;
        }

        public static Errors Create(string code)
        {
            return new Errors(code);
        }

        public static Errors Create(string code, string message)
        {
            return new Errors(code, message);
        }

        public static Errors Create(string code, IEnumerable<ValidationFailure> errors)
        {
            return new Errors(code, JsonConvert.SerializeObject(errors));
        }
    }
}
