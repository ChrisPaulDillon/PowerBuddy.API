using System;
namespace PowerLifting.Service.TemplatePrograms.Exceptions
{
    public class TemplateProgramNotFoundException : Exception
    {
        public TemplateProgramNotFoundException() : base("TemplateProgram Not Found")
        {
        }
    }
}
