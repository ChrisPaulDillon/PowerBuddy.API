using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Service.TemplatePrograms.Exceptions
{
    public class TemplateProgramNameAlreadyExistsException : Exception
    {
        public TemplateProgramNameAlreadyExistsException() : base("Template Program name already exists!")
        {

        }
    }
}
