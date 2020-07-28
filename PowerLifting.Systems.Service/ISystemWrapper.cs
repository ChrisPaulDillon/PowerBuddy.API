using PowerLifting.Systems.Repository;

namespace PowerLifting.Systems.Service
{
    public interface ISystemWrapper
    {
        IRepSchemeTypeRepository RepSchemeType { get; }
        ITemplateDifficultyRepository TemplateDifficulty { get; }
        IQuoteRepository Quote { get; }
    }
}