using PowerLifting.Services.TemplateRepSchemes.Model;
using Powerlifting.Repository;
using PowerLifting.Persistence;
using PowerLifting.Service.TemplateRepSchemes;

namespace PowerLifting.Repository.Repositories
{
    public class TemplateRepSchemeRepository : RepositoryBase<TemplateRepScheme>, ITemplateRepSchemeRepository
    {
        public TemplateRepSchemeRepository(PowerliftingContext context) : base(context)
        {
        }
    }
}
