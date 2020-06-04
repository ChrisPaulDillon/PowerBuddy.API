using Powerlifting.Common;
using PowerLifting.Persistence;
using PowerLifting.Service.TemplatePrograms.Model;
using PowerLifting.TemplatePrograms.Contracts;

namespace PowerLifting.TemplatePrograms.Repository
{
    public class TemplateWeekRepository : RepositoryBase<TemplateWeek>, ITemplateWeekRepository
    {
        public TemplateWeekRepository(PowerliftingContext context) : base(context)
        {

        }
    }
}
