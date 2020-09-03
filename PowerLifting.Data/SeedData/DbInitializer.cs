using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Entities.Exercises;
using PowerLifting.Data.Entities.System;
using PowerLifting.Data.SeedData.Exercises;
using PowerLifting.Data.SeedData.TemplatePrograms;

namespace PowerLifting.Data.SeedData
{
    public class DbInitializer
    {
        public static void InitializeAsync(PowerLiftingContext context)
        {
            var curDate = DateTime.Now.Date;
            context.Database.EnsureCreated();

            if (!context.Quote.Any())
            {
                var quotes = new Quote[]
                {
                    new Quote{QuoteStr="We All Gonna Make It Brahs", Author = "Zyzz", Year = 2011, Active = true},
                    new Quote{QuoteStr="Everyone wants to be a bodybuilder, but nobody wants to lift no heavy ass weights", Author = "Ronnie Coleman", Year = 2005, Active = true},
                    new Quote{QuoteStr="The worst thing I can be is the same as everybody else.", Author = "Arnold Schwarzenegger", Active = true},
                    new Quote{QuoteStr="If I Have To Die Tonight , If This Weight Is Going To Kill Me Tonight, SO BE IT! I’m Dying Where I Wanna Be...", Author = "Kai Greene", Active = true},
                    new Quote{QuoteStr="Vision creates faith and faith creates willpower. With faith there is no anxiety and no doubt – just absolute confidence in yourself", Author = "Arnold Schwarzenegger", Active = true},
                    new Quote{QuoteStr="I hated every minute of training, but I said, don’t quit. Suffer now and live the rest of your life as a champion", Author = "Muhammad Ali", Active = true},
                    new Quote{QuoteStr="Some are born strong and others are made strong", Author = "J.R. Rim", Active = true},
                    new Quote{QuoteStr="Don't ever pay people out or put people down. Instead just put yourself up and let the haters do their thing", Author = "Zyzz", Active = true},
                    new Quote{QuoteStr="I think the biggest mistake people make is not believing in themselves enough", Author = "Rich Piana", Active = true},
                    new Quote{QuoteStr="Hard work and training. There's no secret formula. I lift heavy, work hard and aim to be the best", Author = "Ronnie Coleman", Active = true},
                    new Quote{QuoteStr="Light weight ... Yeah buddy!", Author = "Ronnie Coleman", Active = true},
                    new Quote{QuoteStr="The last three or four reps is what makes the muscle grow. This area of pain divides a champion from someone who is not a champion", Author = "Arnold Schwarzenegger", Active = true},
                    new Quote{QuoteStr="The successful warrior is the average man, with laser-like focus", Author = "Bruce Lee", Active = true},
                    new Quote{QuoteStr="What hurts today makes you stronger tomorrow", Author = "Jay Cutler", Active = true},
                    new Quote{QuoteStr="You have to think it before you can do it. The mind is what makes it all possible", Author = "Kai Greene", Active = true},
                    new Quote{QuoteStr="We are what we repeatedly do. Excellence then is not an act but a habit", Author = "Aristotle", Active = true},
                    new Quote{QuoteStr="Don’t count the days, make the days count", Author = "Muhammad Ali", Active = true},
                    new Quote{QuoteStr="Don’t count the days, make the days count", Author = "Muhammad Ali", Active = true},
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

            if (!context.ExerciseMuscleGroup.Any())
            {
                var exerciseMuscleGroups = ExerciseMuscleGroupSeed.CreateExerciseMuscleGroups();

                foreach (var e in exerciseMuscleGroups)
                {
                    context.ExerciseMuscleGroup.Add(e);
                }
                context.SaveChanges();
            }

            var exercises = ExerciseSeed.CreateExercises();

            if (!context.Exercise.Any())
            {
                

                foreach (var e in exercises)
                {
                    context.Exercise.Add(e);
                }
                context.SaveChanges();
            }

            var templateExercises = context.Exercise.ToList();
            if (!context.TemplateProgram.Any())
            {
                var createdTemplates = TemplateProgramSeed.CreateTemplatePrograms(templateExercises);
                foreach (var e in createdTemplates)
                {
                    context.TemplateProgram.Add(e);
                }
                context.SaveChanges();
            }
        }
    }
}

