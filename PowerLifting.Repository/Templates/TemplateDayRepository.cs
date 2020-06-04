using Powerlifting.Common;
using PowerLifting.Contracts.Contracts;
using PowerLifting.Persistence;
using PowerLifting.Service.TemplatePrograms.Model;

namespace PowerLifting.Repository.Templates
{
    public class TemplateDayRepository : RepositoryBase<TemplateDay>, ITemplateDayRepository
    {
        public TemplateDayRepository(PowerliftingContext context) : base(context)
        {

        }
    }
}
