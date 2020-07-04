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
                var exercises = new Exercise[]
                {
                    new Exercise{ExerciseName="Back Squat", ExerciseTypeId = 2,
                        IsProgrammable = true, ExerciseMuscleGroups = new List<ExerciseMuscleGroup> {
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Quads" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Hamstrings" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Lower Back" },
                        },
                        ExerciseSports = new List<ExerciseSport> {
                                new ExerciseSport { ExerciseSportStr = "PowerLifting" },
                                new ExerciseSport { ExerciseSportStr = "Olympic WeightLifting" },
                        },
                    },
                    new Exercise{ExerciseName="DeadLift", ExerciseTypeId = 2,
                        IsProgrammable = true, ExerciseMuscleGroups = new List<ExerciseMuscleGroup> {
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Lower Back" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Upper Back" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Hamstring" },
                        },
                        ExerciseSports = new List<ExerciseSport> {
                                new ExerciseSport { ExerciseSportStr = "PowerLifting" },
                                new ExerciseSport { ExerciseSportStr = "Olympic WeightLifting" },
                        },
                    },
                    new Exercise{ExerciseName="Bench Press", ExerciseTypeId = 2,
                        IsProgrammable = true, ExerciseMuscleGroups = new List<ExerciseMuscleGroup> {
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Chest" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Tricep" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Anterior Deltoid" },
                        },
                        ExerciseSports = new List<ExerciseSport> {
                                new ExerciseSport { ExerciseSportStr = "PowerLifting" },
                        },
                    },
                    new Exercise{ExerciseName="Overhead Press", ExerciseTypeId = 2,
                            IsProgrammable = true, ExerciseMuscleGroups = new List<ExerciseMuscleGroup> {
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Anterior Deltoid" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Tricep" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Trapezius" },
                        },
                        ExerciseSports = new List<ExerciseSport> {
                                new ExerciseSport { ExerciseSportStr = "PowerLifting" },
                                new ExerciseSport { ExerciseSportStr = "Olympic WeightLifting" },
                        },
                    },
                    new Exercise{ExerciseName="Front Squat", ExerciseTypeId = 2,
                            IsProgrammable = true, ExerciseMuscleGroups = new List<ExerciseMuscleGroup> {
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Quadricep" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Glute" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Abdominal" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Upper Back" },
                        },
                        ExerciseSports = new List<ExerciseSport> {
                                new ExerciseSport { ExerciseSportStr = "PowerLifting" },
                                new ExerciseSport { ExerciseSportStr = "Olympic WeightLifting" },
                        },
                    },
                    new Exercise{ExerciseName="Overhead Squat", ExerciseTypeId = 2,
                         IsProgrammable = true, ExerciseMuscleGroups = new List<ExerciseMuscleGroup> {
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Shoulder" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Quadricep" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Glute" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Upper Back" },
                        },
                        ExerciseSports = new List<ExerciseSport> {
                                new ExerciseSport { ExerciseSportStr = "Olympic WeightLifting" },
                        },
                    },
                    new Exercise{ExerciseName="Floor Press", ExerciseTypeId = 2,
                         IsProgrammable = true, ExerciseMuscleGroups = new List<ExerciseMuscleGroup> {
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Shoulder" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Chest" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Tricep" },
                         },
                    },
                    new Exercise{ExerciseName="Wide Grip Bench Press", ExerciseTypeId = 2,
                        IsProgrammable = true, ExerciseMuscleGroups = new List<ExerciseMuscleGroup> {
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Shoulder" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Chest" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Tricep" },
                         },
                    },
                    new Exercise{ExerciseName="Narrow Grip Bench Press", ExerciseTypeId = 2,
                        IsProgrammable = true, ExerciseMuscleGroups = new List<ExerciseMuscleGroup> {
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Shoulder" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Chest" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Tricep" },
                         },
                    },

                    new Exercise{ExerciseName="Barbell Lunge", ExerciseTypeId = 2},
                    new Exercise{ExerciseName="Incline Bench Press", ExerciseTypeId = 2},
                    new Exercise{ExerciseName="Decline Bench Press", ExerciseTypeId = 2},
                    new Exercise{ExerciseName="Barbell Bicep Curl", ExerciseTypeId = 2},
                    new Exercise{ExerciseName="Good Morning", ExerciseTypeId = 2},
                    new Exercise{ExerciseName="Stiff Leg Deadlift", ExerciseTypeId = 2},
                    new Exercise{ExerciseName="Sumo Deadlift", ExerciseTypeId = 2},
                    new Exercise{ExerciseName="Snatch", ExerciseTypeId = 2},
                    new Exercise{ExerciseName="Hang Snatch", ExerciseTypeId = 2},
                    new Exercise{ExerciseName="Power Snatch", ExerciseTypeId = 2},
                    new Exercise{ExerciseName="Clean & Press", ExerciseTypeId = 2},
                    new Exercise{ExerciseName="Clean & Jerk", ExerciseTypeId = 2},
                    new Exercise{ExerciseName="Clean", ExerciseTypeId = 2},
                    new Exercise{ExerciseName="Hang Clean", ExerciseTypeId = 2},
                    new Exercise{ExerciseName="Power Clean", ExerciseTypeId = 2},
                    new Exercise{ExerciseName="Jerk", ExerciseTypeId = 2},
                    new Exercise{ExerciseName="Power Jerk", ExerciseTypeId = 2},
                    new Exercise{ExerciseName="Barbell Row", ExerciseTypeId = 2},
                    new Exercise{ExerciseName="Pendlay Row", ExerciseTypeId = 2},
                    new Exercise{ExerciseName="T-Bar Row", ExerciseTypeId = 2}
                };

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

