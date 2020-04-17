using Powerlifting.Repository;
using PowerLifting.Persistence;
using PowerLifting.Service.TemplatePrograms.Contracts.Repositories;
using PowerLifting.Service.TemplatePrograms.Model;

namespace PowerLifting.Repository.Templates
{
    public class TemplateRepSchemeRepository : RepositoryBase<TemplateRepScheme>, ITemplateRepSchemeRepository
    {
        public TemplateRepSchemeRepository(PowerliftingContext context) : base(context)
        {
        }
    }
}
