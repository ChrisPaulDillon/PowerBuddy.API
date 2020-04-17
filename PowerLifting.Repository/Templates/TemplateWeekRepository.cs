using PowerLifting.Persistence;
using Powerlifting.Repository;
using PowerLifting.Service.TemplatePrograms.Contracts.Repositories;
using PowerLifting.Service.TemplatePrograms.Model;

namespace PowerLifting.Repository.Templates
{
    public class TemplateWeekRepository : RepositoryBase<TemplateWeek>, ITemplateWeekRepository
    {
        public TemplateWeekRepository(PowerliftingContext context) : base(context)
        {

        }
    }
}
