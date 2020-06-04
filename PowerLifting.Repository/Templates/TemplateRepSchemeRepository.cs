using Powerlifting.Common;
using PowerLifting.Contracts.Contracts;
using PowerLifting.Persistence;
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
