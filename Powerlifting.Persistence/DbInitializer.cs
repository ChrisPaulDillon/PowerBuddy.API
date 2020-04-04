using System;
using System.Collections.Generic;
using System.Linq;
using Powerlifting.Service.Exercises.Model;
using Powerlifting.Service.LiftingStats.Model;
using Powerlifting.Services.ProgramLogs;
using Powerlifting.Services.ProgramLogRepSchemes.Model;
using Powerlifting.Services.TemplatePrograms.Model;
using PowerLifting.ProgramLogExercises.Model;
using PowerLifting.Service.Users.Model;
using PowerLifting.Services.TemplateRepSchemes.Model;
using Powerlifting.Services.TemplateExercises.Model;
using PowerLifting.Service.Exercises.Model;

namespace PowerLifting.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(PowerliftingContext context)
         {
            context.Database.EnsureCreated();


            if (!context.ExerciseType.Any())
            {
                var exerciseCategories = new ExerciseType[]
                {
                    new ExerciseType{ExerciseTypeName="Dumbbells"},
                    new ExerciseType{ExerciseTypeName="Barbells"},
                    new ExerciseType{ExerciseTypeName="Bodyweight"},
                    new ExerciseType{ExerciseTypeName="Machine"},
                };

                foreach (ExerciseType e in exerciseCategories)
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
                            ExerciseMuscleGroups = new List<ExerciseMuscleGroup> {
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Quads" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Hamstrings" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Lower Back" },
                        }, },
                    new Exercise{ExerciseName="Conventional Deadlift", ExerciseTypeId = 2,
                            ExerciseMuscleGroups = new List<ExerciseMuscleGroup> {
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Lower Back" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Upper Back" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Hamstrings" },
                        }, },
                    new Exercise{ExerciseName="Bench Press", ExerciseTypeId = 2},
                    new Exercise{ExerciseName="Overhead Press", ExerciseTypeId = 2},
                    new Exercise{ExerciseName="Front Squat", ExerciseTypeId = 2},
                    new Exercise{ExerciseName="Overhead Squat", ExerciseTypeId = 2},
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
                    new Exercise{ExerciseName="Penlay Row", ExerciseTypeId = 2},
                    new Exercise{ExerciseName="T-Bar Row", ExerciseTypeId = 2}
                };

                foreach (Exercise e in exercises)
                {
                    context.Exercise.Add(e);
                }
                context.SaveChanges();
            }

            if (!context.TemplateProgram.Any())
            {
                var templates = new TemplateProgram[]
                {
                    new TemplateProgram {Name="5/3/1", Difficulty="Beginner", NoOfWeeks = 4,
                        TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseName = "Squat", WeekNumber = 1, DayNumber = 1, NoOfSets = 3,
                                                                TemplateRepSchemes = new List<TemplateRepScheme> {
                                                                    new TemplateRepScheme { SetNo = 1, Percentage = 65, NumOfReps = 5},
                                                                    new TemplateRepScheme { SetNo = 2, Percentage = 75, NumOfReps = 5},
                                                                    new TemplateRepScheme { SetNo = 3, Percentage = 85, NumOfReps = 5}
                                                                                                          } },
                                          new TemplateExercise { ExerciseName = "Bench Press", WeekNumber = 1, DayNumber = 2, NoOfSets = 3,
                                                                TemplateRepSchemes = new List<TemplateRepScheme> {
                                                                    new TemplateRepScheme { SetNo = 1, Percentage = 65, NumOfReps = 5},
                                                                    new TemplateRepScheme { SetNo = 2, Percentage = 75, NumOfReps = 5},
                                                                    new TemplateRepScheme { SetNo = 3, Percentage = 85, NumOfReps = 5}
                                                                                                          } },
                                          new TemplateExercise { ExerciseName = "Deadlift", WeekNumber = 1, DayNumber = 3, NoOfSets = 3,
                                                                TemplateRepSchemes = new List<TemplateRepScheme> {
                                                                    new TemplateRepScheme { SetNo = 1, Percentage = 65, NumOfReps = 5},
                                                                    new TemplateRepScheme { SetNo = 2, Percentage = 75, NumOfReps = 5},
                                                                    new TemplateRepScheme { SetNo = 3, Percentage = 85, NumOfReps = 5}
                                                                                                          } },
                                          //Week 2
                                          new TemplateExercise { ExerciseName = "Squat", WeekNumber = 2, DayNumber = 1, NoOfSets = 3,
                                                                TemplateRepSchemes = new List<TemplateRepScheme> {
                                                                    new TemplateRepScheme { SetNo = 1, Percentage = 70, NumOfReps = 3},
                                                                    new TemplateRepScheme { SetNo = 2, Percentage = 80, NumOfReps = 3},
                                                                    new TemplateRepScheme { SetNo = 3, Percentage = 90, NumOfReps = 3}
                                                                                                          } },
                                          new TemplateExercise { ExerciseName = "Bench Press", WeekNumber = 2, DayNumber = 2, NoOfSets = 3,
                                                                TemplateRepSchemes = new List<TemplateRepScheme> {
                                                                    new TemplateRepScheme { SetNo = 1, Percentage = 70, NumOfReps = 3},
                                                                    new TemplateRepScheme { SetNo = 2, Percentage = 80, NumOfReps = 3},
                                                                    new TemplateRepScheme { SetNo = 3, Percentage = 90, NumOfReps = 3}
                                                                                                          } },
                                          new TemplateExercise { ExerciseName = "Deadlift", WeekNumber = 2, DayNumber = 3, NoOfSets = 3,
                                                                TemplateRepSchemes = new List<TemplateRepScheme> {
                                                                    new TemplateRepScheme { SetNo = 1, Percentage = 70, NumOfReps = 3},
                                                                    new TemplateRepScheme { SetNo = 2, Percentage = 80, NumOfReps = 3},
                                                                    new TemplateRepScheme { SetNo = 3, Percentage = 90, NumOfReps = 3}
                                                                                                          } },

                                           //Week 3
                                          new TemplateExercise { ExerciseName = "Squat", WeekNumber = 3, DayNumber = 1, NoOfSets = 3,
                                                                TemplateRepSchemes = new List<TemplateRepScheme> {
                                                                    new TemplateRepScheme { SetNo = 1, Percentage = 75, NumOfReps = 5},
                                                                    new TemplateRepScheme { SetNo = 2, Percentage = 85, NumOfReps = 3},
                                                                    new TemplateRepScheme { SetNo = 3, Percentage = 95, NumOfReps = 1}
                                                                                                          } },
                                          new TemplateExercise { ExerciseName = "Bench Press", WeekNumber = 3, DayNumber = 2, NoOfSets = 3,
                                                                TemplateRepSchemes = new List<TemplateRepScheme> {
                                                                    new TemplateRepScheme { SetNo = 1, Percentage = 75, NumOfReps = 5},
                                                                    new TemplateRepScheme { SetNo = 2, Percentage = 85, NumOfReps = 5},
                                                                    new TemplateRepScheme { SetNo = 3, Percentage = 95, NumOfReps = 5}
                                                                                                          } },
                                          new TemplateExercise { ExerciseName = "Deadlift", WeekNumber = 3, DayNumber = 3, NoOfSets = 3,
                                                                TemplateRepSchemes = new List<TemplateRepScheme> {
                                                                    new TemplateRepScheme { SetNo = 1, Percentage = 75, NumOfReps = 5},
                                                                    new TemplateRepScheme { SetNo = 2, Percentage = 85, NumOfReps = 5},
                                                                    new TemplateRepScheme { SetNo = 3, Percentage = 95, NumOfReps = 5}
                                                                                                          } },
                                          //Week 4
                                          new TemplateExercise { ExerciseName = "Squat", WeekNumber = 4, DayNumber = 1, NoOfSets = 3,
                                                                TemplateRepSchemes = new List<TemplateRepScheme> {
                                                                    new TemplateRepScheme { SetNo = 1, Percentage = 40, NumOfReps = 5},
                                                                    new TemplateRepScheme { SetNo = 2, Percentage = 50, NumOfReps = 5},
                                                                    new TemplateRepScheme { SetNo = 3, Percentage = 60, NumOfReps = 5}
                                                                                                          } },
                                          new TemplateExercise { ExerciseName = "Bench Press", WeekNumber = 4, DayNumber = 2, NoOfSets = 3,
                                                                TemplateRepSchemes = new List<TemplateRepScheme> {
                                                                    new TemplateRepScheme { SetNo = 1, Percentage = 40, NumOfReps = 5},
                                                                    new TemplateRepScheme { SetNo = 2, Percentage = 50, NumOfReps = 5},
                                                                    new TemplateRepScheme { SetNo = 3, Percentage = 60, NumOfReps = 5}
                                                                                                          } },
                                          new TemplateExercise { ExerciseName = "Deadlift", WeekNumber = 4, DayNumber = 1, NoOfSets = 3,
                                                                TemplateRepSchemes = new List<TemplateRepScheme> {
                                                                    new TemplateRepScheme { SetNo = 1, Percentage = 40, NumOfReps = 5},
                                                                    new TemplateRepScheme { SetNo = 2, Percentage = 50, NumOfReps = 5},
                                                                    new TemplateRepScheme { SetNo = 3, Percentage = 60, NumOfReps = 5}
                                                                                                          } },
                    } }
                };

                foreach (TemplateProgram e in templates)
                {
                    context.TemplateProgram.Add(e);
                }
                context.SaveChanges();
            }

            if (!context.User.Any())
            {
                var users = new User[]
                {
                    new User{ Email="chrispauldillon@live.com", PasswordHash = "test123",
                        LiftingStats= new LiftingStat { BenchWeight=100, DeadliftWeight=170, SquatWeight=200 },
                        ProgramLogs= new List<ProgramLog> {
                            new ProgramLog { StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(30), TemplateProgramId = 1, NoOfDaysLifting = 4, Monday = true, Tuesday = true,
                                ProgramLogExercises = new List<ProgramLogExercise> {
                                                    new ProgramLogExercise { LiftingDate = DateTime.Now, NumOfSets = 5, ExerciseName = "Squat",
                                                                         ProgramLogRepSchemes = new List<ProgramLogRepScheme> {
                                                                                new ProgramLogRepScheme { SetNo = 1, WeightLifted = 100, NumOfReps =5 },
                                                                                new ProgramLogRepScheme { SetNo = 2, WeightLifted = 120, NumOfReps =5 },
                                                                                new ProgramLogRepScheme { SetNo = 3, WeightLifted = 130, NumOfReps =5 },
                                                                         }},
                                                    new ProgramLogExercise { LiftingDate = DateTime.Now.AddDays(5), NumOfSets = 5, ExerciseName = "Deadlift",
                                                                         ProgramLogRepSchemes = new List<ProgramLogRepScheme> {
                                                                                new ProgramLogRepScheme { SetNo = 1, WeightLifted = 100, NumOfReps =5 },
                                                                                new ProgramLogRepScheme { SetNo = 2, WeightLifted = 120, NumOfReps =5 },
                                                                                new ProgramLogRepScheme { SetNo = 3, WeightLifted = 130, NumOfReps =5 },
                                                                         }},
                                                    new ProgramLogExercise { LiftingDate = DateTime.Now.AddDays(15), NumOfSets = 5, ExerciseName = "Squat",
                                                                         ProgramLogRepSchemes = new List<ProgramLogRepScheme> {
                                                                                new ProgramLogRepScheme { SetNo = 1, WeightLifted = 100, NumOfReps =5 },
                                                                                new ProgramLogRepScheme { SetNo = 2, WeightLifted = 120, NumOfReps =5 },
                                                                                new ProgramLogRepScheme { SetNo = 3, WeightLifted = 130, NumOfReps =5 },
                                                                         }},
                                                     new ProgramLogExercise { LiftingDate = DateTime.Now.AddDays(25), NumOfSets = 5, ExerciseName = "Overhead Press",
                                                                         ProgramLogRepSchemes = new List<ProgramLogRepScheme> {
                                                                                new ProgramLogRepScheme { SetNo = 1, WeightLifted = 100, NumOfReps =5 },
                                                                                new ProgramLogRepScheme { SetNo = 2, WeightLifted = 120, NumOfReps =5 },
                                                                                new ProgramLogRepScheme { SetNo = 3, WeightLifted = 130, NumOfReps =5 },
                                                                         }}

                                },
                            }
                        }
                    },

                    new User{ Email="dealdalzell@live.com", PasswordHash = "verystronkpw",
                        LiftingStats= new LiftingStat { BenchWeight=100, DeadliftWeight=170, SquatWeight=200 },
                        ProgramLogs= new List<ProgramLog> {
                            new ProgramLog { StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(30), TemplateProgramId = 1, NoOfDaysLifting = 4, Monday = true, Tuesday = true,
                                ProgramLogExercises = new List<ProgramLogExercise> {
                                                    new ProgramLogExercise { LiftingDate = DateTime.Now, NumOfSets = 5, ExerciseName = "Squat",
                                                                         ProgramLogRepSchemes = new List<ProgramLogRepScheme> {
                                                                                new ProgramLogRepScheme { SetNo = 1, WeightLifted = 100, NumOfReps =5 },
                                                                                new ProgramLogRepScheme { SetNo = 2, WeightLifted = 120, NumOfReps =5 },
                                                                                new ProgramLogRepScheme { SetNo = 3, WeightLifted = 130, NumOfReps =5 },
                                                                         }},
                                                    new ProgramLogExercise { LiftingDate = DateTime.Now.AddDays(5), NumOfSets = 5, ExerciseName = "Deadlift",
                                                                         ProgramLogRepSchemes = new List<ProgramLogRepScheme> {
                                                                                new ProgramLogRepScheme { SetNo = 1, WeightLifted = 100, NumOfReps =5 },
                                                                                new ProgramLogRepScheme { SetNo = 2, WeightLifted = 120, NumOfReps =5 },
                                                                                new ProgramLogRepScheme { SetNo = 3, WeightLifted = 130, NumOfReps =5 },
                                                                         }},
                                                    new ProgramLogExercise { LiftingDate = DateTime.Now.AddDays(15), NumOfSets = 5, ExerciseName = "Squat",
                                                                         ProgramLogRepSchemes = new List<ProgramLogRepScheme> {
                                                                                new ProgramLogRepScheme { SetNo = 1, WeightLifted = 100, NumOfReps =5 },
                                                                                new ProgramLogRepScheme { SetNo = 2, WeightLifted = 120, NumOfReps =5 },
                                                                                new ProgramLogRepScheme { SetNo = 3, WeightLifted = 130, NumOfReps =5 },
                                                                         }},
                                                     new ProgramLogExercise { LiftingDate = DateTime.Now.AddDays(25), NumOfSets = 5, ExerciseName = "Overhead Press",
                                                                         ProgramLogRepSchemes = new List<ProgramLogRepScheme> {
                                                                                new ProgramLogRepScheme { SetNo = 1, WeightLifted = 100, NumOfReps =5 },
                                                                                new ProgramLogRepScheme { SetNo = 2, WeightLifted = 120, NumOfReps =5 },
                                                                                new ProgramLogRepScheme { SetNo = 3, WeightLifted = 130, NumOfReps =5 },
                                                                         }}

                                },

                            }
                        }
                        }
                };

                foreach (User e in users)
                {
                    context.User.Add(e);
                }
                context.SaveChanges();
            }

            
        }
    }
}
 
