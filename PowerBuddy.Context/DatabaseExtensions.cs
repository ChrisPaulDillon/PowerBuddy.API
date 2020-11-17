using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PowerBuddy.Context
{
    public static class DatabaseExtensions
    {
        public interface IIdentifier
        {
            public string Id { get; set; }
        }

        public static void DetachLocal<T>(this PowerLiftingContext context, T t, string entryId)
            where T : class, IIdentifier
        {
            var local = context.Set<T>()
                .Local
                .FirstOrDefault(entry => entry.Id.Equals(entryId));
            if (local != null)
            {
                context.Entry(local).State = EntityState.Detached;
            }
            context.Entry(t).State = EntityState.Modified;
        }
    }
}
