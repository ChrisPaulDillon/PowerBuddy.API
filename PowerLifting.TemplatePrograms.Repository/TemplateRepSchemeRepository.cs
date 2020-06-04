using Powerlifting.Common;
using PowerLifting.Persistence;
using PowerLifting.Service.TemplatePrograms.Model;
using PowerLifting.TemplatePrograms.Contracts;
using PowerLifting.TemplatePrograms.Contracts.Repositories;

namespace PowerLifting.TemplatePrograms.Repository
{
    public class TemplateRepSchemeRepository : RepositoryBase<TemplateRepScheme>, ITemplateRepSchemeRepository
    {
        public TemplateRepSchemeRepository(PowerliftingContext context) : base(context)
        {
        }
    }
}
