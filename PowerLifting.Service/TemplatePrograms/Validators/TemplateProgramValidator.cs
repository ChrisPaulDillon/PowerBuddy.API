using System;
using PowerLifting.Service.TemplatePrograms.Exceptions;

namespace PowerLifting.Service.TemplatePrograms.Validators
{
    public class TemplateProgramValidator
    {
        public TemplateProgramValidator()
        {
        }

        #region TemplateProgramValidation

        public void ValidateTemplateProgramId(int templateProgramId)
        {
            if (templateProgramId < 1)
            {
                throw new TemplateProgramDoesNotExistException();
            }
        }

        #endregion
    }
}
