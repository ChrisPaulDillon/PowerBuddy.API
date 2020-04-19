using System;
namespace PowerLifting.Service.TemplatePrograms.Exceptions
{
    public class TemplateProgramDoesNotExistException : Exception
    {
        public TemplateProgramDoesNotExistException() : base("The template program associated with the given ID does not exist")
        {
        }
    }
}
