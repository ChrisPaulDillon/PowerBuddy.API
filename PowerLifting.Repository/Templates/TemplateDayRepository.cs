using PowerLifting.Persistence;
using Powerlifting.Repository;
using PowerLifting.Service.TemplatePrograms.Contracts.Repositories;
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
