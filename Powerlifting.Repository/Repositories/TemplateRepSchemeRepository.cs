using PowerLifting.Services.TemplateRepSchemes.Model;
using PowerLifting.Services.TemplateRepSchemes;
using Powerlifting.Repository;
using PowerLifting.Persistence;

namespace PowerLifting.Repository.Repositories
{
    public class TemplateRepSchemeRepository : RepositoryBase<TemplateRepScheme>, ITemplateRepSchemeRepository
    {
        public TemplateRepSchemeRepository(PowerliftingContext context) : base(context)
        {
        }
    }
}
