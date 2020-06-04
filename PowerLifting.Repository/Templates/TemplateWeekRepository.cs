using Powerlifting.Common;
using PowerLifting.Contracts.Contracts;
using PowerLifting.Persistence;
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
