using Powerlifting.Common;
using PowerLifting.Persistence;
using PowerLifting.Service.TemplatePrograms.Model;
using PowerLifting.TemplatePrograms.Contracts;
using PowerLifting.TemplatePrograms.Contracts.Repositories;

namespace PowerLifting.TemplatePrograms.Repository
{
    public class TemplateDayRepository : RepositoryBase<TemplateDay>, ITemplateDayRepository
    {
        public TemplateDayRepository(PowerliftingContext context) : base(context)
        {

        }
    }
}
