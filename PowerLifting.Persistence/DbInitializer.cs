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
                    new Exercise{ExerciseName="Conventional DeadLift", ExerciseTypeId = 2,
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
                    new Exercise{ExerciseName="Barbell Lunge", ExerciseTypeId = 2},
                    new Exercise{ExerciseName="Wide Grip Bench Press", ExerciseTypeId = 2},
                    new Exercise{ExerciseName="Narrow Grip Bench Press", ExerciseTypeId = 2},
                    new Exercise{ExerciseName="Floor Press", ExerciseTypeId = 2},
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
                var templates = new TemplateProgram[]
                {
                    new TemplateProgram {Name="5/3/1", Difficulty=Enum.GetName(typeof(TemplateDifficultyEnum), TemplateDifficultyEnum.Beginner), NoOfWeeks = 4, MaxLiftDaysPerWeek = 3,
                        TemplateType="Block", WeightProgressionType=Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.PERCENTAGE),
                         TemplateExerciseCollection = new List<TemplateExerciseCollection> {
                            new TemplateExerciseCollection { TemplateProgramId = 1, ExerciseId = 1 },
                            new TemplateExerciseCollection { TemplateProgramId = 1, ExerciseId = 26 },
                            new TemplateExerciseCollection { TemplateProgramId = 1, ExerciseId = 27 } },
                            TemplateWeeks = new List<TemplateWeek> {
                            new TemplateWeek { WeekNo = 1,TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise>{
                                          new TemplateExercise { ExerciseId = 26, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 27, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                                                                                          } } } } } },
                            //Week 2
                            new TemplateWeek { WeekNo = 2, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1,TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "3x3", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 70, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 26, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "3x3", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 70, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 27, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "3x3", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 70, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                                                                                          } } } } } },
                             //Week 3
                            new TemplateWeek { WeekNo = 3, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo=1, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "1x5, 1x3, 1x1", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo=2, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 26, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "1x5, 1x3, 1x1", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo=3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 27, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "1x5, 1x3, 1x1", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true}
                                                                                                          } } } } } },
                                          //Week 4
                            new TemplateWeek { WeekNo = 4, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo=1, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5}
                                                                                                          } } } },
                                    new TemplateDay { DayNo=2, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 26, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5}
                                                                                                          } } } },
                                    new TemplateDay { DayNo=3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 27, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5}
                                                                                                          } } } } } },
                    } },
                    new TemplateProgram {Name="5/3/1 Boring But Big", Difficulty=Enum.GetName(typeof(TemplateDifficultyEnum), TemplateDifficultyEnum.Beginner),
                        NoOfWeeks = 4, MaxLiftDaysPerWeek = 3, TemplateType="Block", WeightProgressionType=Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.PERCENTAGE),
                         TemplateExerciseCollection = new List<TemplateExerciseCollection> {
                            new TemplateExerciseCollection { TemplateProgramId = 2, ExerciseId = 1 },
                            new TemplateExerciseCollection { TemplateProgramId = 2, ExerciseId = 26 },
                            new TemplateExerciseCollection { TemplateProgramId = 2, ExerciseId = 27 },
                            new TemplateExerciseCollection { TemplateProgramId = 2, ExerciseId = 25 } },
                            TemplateWeeks = new List<TemplateWeek> {
                            new TemplateWeek { WeekNo = 1,TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo=1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 25, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 8, RepSchemeFormat = "3x5", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NoOfReps = 10, IsBackOffSet = true}
                                                                                                          } } } },
                                    new TemplateDay { DayNo=2, TemplateExercises = new List<TemplateExercise>{
                                          new TemplateExercise { ExerciseId = 26, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 8, RepSchemeFormat = "3x3", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NoOfReps = 10, IsBackOffSet = true}
                                                                                                          } } } },
                                    new TemplateDay { DayNo=3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 27, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 8, RepSchemeFormat = "1x5, 1x3, 1x1", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NoOfReps = 10, IsBackOffSet = true}
                                                                                                          } } } } } },
                            //Week 2
                            new TemplateWeek { WeekNo = 2, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 8, RepSchemeFormat = "3x5", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 70, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NoOfReps = 10, IsBackOffSet = true}
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 26, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 8, RepSchemeFormat = "3x5", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 70, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NoOfReps = 10, IsBackOffSet = true}
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 27, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 8, RepSchemeFormat = "3x5", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 70, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NoOfReps = 10, IsBackOffSet = true}
                                                                                                          } } } } } },
                             //Week 3
                            new TemplateWeek { WeekNo = 3, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 8, RepSchemeFormat = "3x5", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 26, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 8, RepSchemeFormat = "3x3", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NoOfReps = 10, IsBackOffSet = true}
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 27, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 8, RepSchemeFormat = "1x5, 1x3, 1x1", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NoOfReps = 10, IsBackOffSet = true}
                                                                                                          } } } } } },
                                          //Week 4
                            new TemplateWeek { WeekNo = 4, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5}
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 26, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5}
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 27, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5}
                                                                                                          } } } } } },
                    } },
                    new TemplateProgram { Name="StrongLifts 5x5", Difficulty=Enum.GetName(typeof(TemplateDifficultyEnum), TemplateDifficultyEnum.Beginner), NoOfWeeks = 12,
                        MaxLiftDaysPerWeek = 3, TemplateType="Block", WeightProgressionType=Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.INCREMENTAL),
                         TemplateExerciseCollection = new List<TemplateExerciseCollection> {
                            new TemplateExerciseCollection { TemplateProgramId = 3, ExerciseId = 1 },
                            new TemplateExerciseCollection { TemplateProgramId = 3, ExerciseId = 25},
                            new TemplateExerciseCollection { TemplateProgramId = 3, ExerciseId = 26 },
                            new TemplateExerciseCollection { TemplateProgramId = 3, ExerciseId = 27 },
                            new TemplateExerciseCollection { TemplateProgramId = 3, ExerciseId = 2 } },
                            TemplateWeeks = new List<TemplateWeek> {
                            new TemplateWeek { WeekNo = 1,TemplateDays = new List<TemplateDay> {
                                   new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                       new TemplateExercise { ExerciseId = 26, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                        new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                    } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                       new TemplateExercise { ExerciseId = 25, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                        new TemplateExercise { ExerciseId = 27, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                    } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1,RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                       new TemplateExercise { ExerciseId = 26, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                        new TemplateExercise { ExerciseId = 2,RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 0, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                    } } } },
                            new TemplateWeek { WeekNo = 2,TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                       new TemplateExercise { ExerciseId = 25, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                        new TemplateExercise { ExerciseId = 27, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                    } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                       new TemplateExercise { ExerciseId = 26, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                        new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                    } },
                                     new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                       new TemplateExercise { ExerciseId = 25, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                        new TemplateExercise { ExerciseId = 27, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } }
                                    } } } } } }
                };

                foreach (var e in templates)
                {
                    context.TemplateProgram.Add(e);
                }
                context.SaveChanges();
            }
        }
    }
}

