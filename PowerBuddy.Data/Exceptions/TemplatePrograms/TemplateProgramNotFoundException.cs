using System;

namespace PowerBuddy.Data.Exceptions.TemplatePrograms
{
    public class TemplateProgramNotFoundException : Exception
    {
        public TemplateProgramNotFoundException() : base("TemplateProgram Not Found")
        {
        }
    }
}
