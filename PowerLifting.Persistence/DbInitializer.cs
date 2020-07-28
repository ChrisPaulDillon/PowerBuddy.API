﻿using System;
using System.Collections.Generic;
using System.Linq;
using PowerLifting.Data.Entities.System;

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
                    new ExerciseType{ExerciseTypeId = 1, ExerciseTypeName="Dumbbell"},
                    new ExerciseType{ExerciseTypeId = 2, ExerciseTypeName="Barbell"},
                    new ExerciseType{ExerciseTypeId = 3, ExerciseTypeName="BodyWeight"},
                    new ExerciseType{ExerciseTypeId = 4, ExerciseTypeName = "Cable"},
                    new ExerciseType{ExerciseTypeId = 5, ExerciseTypeName="Machine"},
                };

                foreach (var e in exerciseCategories)
                {
                    context.ExerciseType.Add(e);
                }
                context.SaveChanges();
            }

            if (!context.Exercise.Any())
            {
                var exercises = ExerciseSeed.CreateExercises();

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

