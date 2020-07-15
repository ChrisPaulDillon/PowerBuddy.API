using System;
using System.Collections.Generic;
using System.Linq;
using PowerLifting.Entity.ProgramLogs.Model;
using PowerLifting.Entity.System.ExerciseMuscleGroups.Models;
using PowerLifting.Entity.System.Exercises.Models;
using PowerLifting.Entity.System.ExerciseSports.Model;
using PowerLifting.Entity.System.ExerciseTypes.Models;
using PowerLifting.Entity.System.Quotes.Models;
using PowerLifting.Service.LiftingStats.Model;
using PowerLifting.Service.SystemServices.RepSchemeTypes.Model;
using PowerLifting.Service.TemplatePrograms.Model;
using PowerLifting.Service.Users.Model;

namespace PowerLifting.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(PowerliftingContext context)
        {
            var curDate = DateTime.Now.Date;
            context.Database.EnsureCreated();

            if (!context.Quote.Any())
            {
                var quotes = new Quote[]
                {
                    new Quote{QuoteStr="We All Gonna Make It Brahs", Author = "Zyzz", Year = 2011, Active = true},
                    new Quote{QuoteStr="Non Negotiable", Author = "Jason Blaha", Year = 2015, Active = true},
                    new Quote{QuoteStr="Everyone wants to be a bodybuilder, but nobody wants to lift no heavy ass weights", Author = "Ronnie Coleman", Year = 2005, Active = true},
                };

                foreach (var e in quotes)
                {
                    context.Quote.Add(e);
                }
                context.SaveChanges();
            }


            if (!context.RepSchemeType.Any())
            {
                var repSchemeTypes = new RepSchemeType[]
                {
                    new RepSchemeType{RepSchemeName="Fixed"},
                    new RepSchemeType{RepSchemeName="Ramped"},
                };

                foreach (var e in repSchemeTypes)
                {
                    context.RepSchemeType.Add(e);
                }
                context.SaveChanges();
            }

            if (!context.ExerciseType.Any())
            {
                var exerciseCategories = new ExerciseType[]
                {
                    new ExerciseType{ExerciseTypeName="Dumbbell"},
                    new ExerciseType{ExerciseTypeName="Barbell"},
                    new ExerciseType{ExerciseTypeName="BodyWeight"},
                    new ExerciseType{ExerciseTypeName="Machine"},
                };

                foreach (var e in exerciseCategories)
                {
                    context.ExerciseType.Add(e);
                }
                context.SaveChanges();
            }

            if (!context.Exercise.Any())
            {

                foreach (var e in exercises)
                {
                    context.Exercise.Add(e);
                }
                context.SaveChanges();
            }

            if (!context.TemplateProgram.Any())
            {
                var createdTemplates = TemplateProgramSeed.CreateTemplatePrograms();
                foreach (var e in createdTemplates)
                {
                    context.TemplateProgram.Add(e);
                }
                context.SaveChanges();
            }
        }
    }
}

