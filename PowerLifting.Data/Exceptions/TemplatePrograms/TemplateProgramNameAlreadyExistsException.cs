using System;

namespace PowerLifting.Data.Exceptions.TemplatePrograms
{
    public class TemplateProgramNameAlreadyExistsException : Exception
    {
        public TemplateProgramNameAlreadyExistsException() : base("Template Program name already exists!")
        {

        }
    }
}
