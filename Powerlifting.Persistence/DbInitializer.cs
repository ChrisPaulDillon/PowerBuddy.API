using System;
using System.Collections.Generic;
using System.Linq;
using Powerlifting.Service.Exercises.Model;
using Powerlifting.Service.LiftingStats.Model;
using Powerlifting.Service.ProgramExercises.Model;
using Powerlifting.Services.ExerciseCategories.Model;
using Powerlifting.Services.ProgramLogs;
using Powerlifting.Services.ProgramTemplates.Model;
using Powerlifting.Services.Users.Model;
using PowerLifting.ExerciseMarkups.Model;
using PowerLifting.Services.ProgramRepSchemes.Model;
using Powerlifting.Services.IndividualSets.Model;

namespace PowerLifting.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(PowerliftingContext context)
         {
            context.Database.EnsureCreated();


            if (!context.ExerciseCategory.Any())
            {
                var exerciseCategories = new ExerciseCategory[]
                {
                    new ExerciseCategory{CategoryName="Dumbbells"},
                    new ExerciseCategory{CategoryName="Barbells"},
                    new ExerciseCategory{CategoryName="Bodyweight"},
                };

                foreach (ExerciseCategory e in exerciseCategories)
                {
                    context.ExerciseCategory.Add(e);
                }
                context.SaveChanges();
            }

            if (!context.Exercise.Any())
            {
                var exercises = new Exercise[]
                {
                    new Exercise{ExerciseName="Back Squat", ExerciseCategoryId = 2},
                    new Exercise{ExerciseName="Conventional Deadlift", ExerciseCategoryId = 2},
                    new Exercise{ExerciseName="Bench Press", ExerciseCategoryId = 2},
                    new Exercise{ExerciseName="Overhead Press", ExerciseCategoryId = 2},
                    new Exercise{ExerciseName="Front Squat", ExerciseCategoryId = 2},
                    new Exercise{ExerciseName="Overhead Squat", ExerciseCategoryId = 2},
                    new Exercise{ExerciseName="Barbell Lunge", ExerciseCategoryId = 2},
                    new Exercise{ExerciseName="Wide Grip Bench Press", ExerciseCategoryId = 2},
                    new Exercise{ExerciseName="Narrow Grip Bench Press", ExerciseCategoryId = 2},
                    new Exercise{ExerciseName="Floor Press", ExerciseCategoryId = 2},
                    new Exercise{ExerciseName="Incline Bench Press", ExerciseCategoryId = 2},
                    new Exercise{ExerciseName="Decline Bench Press", ExerciseCategoryId = 2},
                    new Exercise{ExerciseName="Barbell Bicep Curl", ExerciseCategoryId = 2},
                    new Exercise{ExerciseName="Good Morning", ExerciseCategoryId = 2},
                    new Exercise{ExerciseName="Stiff Leg Deadlift", ExerciseCategoryId = 2},
                    new Exercise{ExerciseName="Sumo Deadlift", ExerciseCategoryId = 2},
                    new Exercise{ExerciseName="Snatch", ExerciseCategoryId = 2},
                    new Exercise{ExerciseName="Hang Snatch", ExerciseCategoryId = 2},
                    new Exercise{ExerciseName="Power Snatch", ExerciseCategoryId = 2},
                    new Exercise{ExerciseName="Clean & Press", ExerciseCategoryId = 2},
                    new Exercise{ExerciseName="Clean & Jerk", ExerciseCategoryId = 2},
                    new Exercise{ExerciseName="Clean", ExerciseCategoryId = 2},
                    new Exercise{ExerciseName="Hang Clean", ExerciseCategoryId = 2},
                    new Exercise{ExerciseName="Power Clean", ExerciseCategoryId = 2},
                    new Exercise{ExerciseName="Jerk", ExerciseCategoryId = 2}, 
                    new Exercise{ExerciseName="Power Jerk", ExerciseCategoryId = 2},
                    new Exercise{ExerciseName="Barbell Row", ExerciseCategoryId = 2},
                    new Exercise{ExerciseName="Penlay Row", ExerciseCategoryId = 2},
                    new Exercise{ExerciseName="T-Bar Row", ExerciseCategoryId = 2},
                };

                foreach (Exercise e in exercises)
                {
                    context.Exercise.Add(e);
                }
                context.SaveChanges();
            }

            if (!context.ProgramTemplate.Any())
            {
                var templates = new ProgramTemplate[]
                {
                    new ProgramTemplate {Name="5/3/1", Difficulty="Beginner", NoOfWeeks = 4,
                        ProgramExercises = new List<ProgramExercise> {
                                          new ProgramExercise { ExerciseName = "Squat", WeekNumber = 1, DayNumber = 1, NoOfSets = 3,
                                                                ProgramRepSchemes = new List<ProgramRepScheme> {
                                                                    new ProgramRepScheme { SetNo = 1, Percentage = 65, NumOfReps = 5},
                                                                    new ProgramRepScheme { SetNo = 2, Percentage = 75, NumOfReps = 5},
                                                                    new ProgramRepScheme { SetNo = 3, Percentage = 85, NumOfReps = 5}
                                                                                                          } },
                                          new ProgramExercise { ExerciseName = "Bench Press", WeekNumber = 1, DayNumber = 2, NoOfSets = 3,
                                                                ProgramRepSchemes = new List<ProgramRepScheme> {
                                                                    new ProgramRepScheme { SetNo = 1, Percentage = 65, NumOfReps = 5},
                                                                    new ProgramRepScheme { SetNo = 2, Percentage = 75, NumOfReps = 5},
                                                                    new ProgramRepScheme { SetNo = 3, Percentage = 85, NumOfReps = 5}
                                                                                                          } },
                                          new ProgramExercise { ExerciseName = "Deadlift", WeekNumber = 1, DayNumber = 3, NoOfSets = 3,
                                                                ProgramRepSchemes = new List<ProgramRepScheme> {
                                                                    new ProgramRepScheme { SetNo = 1, Percentage = 65, NumOfReps = 5},
                                                                    new ProgramRepScheme { SetNo = 2, Percentage = 75, NumOfReps = 5},
                                                                    new ProgramRepScheme { SetNo = 3, Percentage = 85, NumOfReps = 5}
                                                                                                          } },
                                          //Week 2
                                          new ProgramExercise { ExerciseName = "Squat", WeekNumber = 2, DayNumber = 1, NoOfSets = 3,
                                                                ProgramRepSchemes = new List<ProgramRepScheme> {
                                                                    new ProgramRepScheme { SetNo = 1, Percentage = 70, NumOfReps = 3},
                                                                    new ProgramRepScheme { SetNo = 2, Percentage = 80, NumOfReps = 3},
                                                                    new ProgramRepScheme { SetNo = 3, Percentage = 90, NumOfReps = 3}
                                                                                                          } },
                                          new ProgramExercise { ExerciseName = "Bench Press", WeekNumber = 2, DayNumber = 2, NoOfSets = 3,
                                                                ProgramRepSchemes = new List<ProgramRepScheme> {
                                                                    new ProgramRepScheme { SetNo = 1, Percentage = 70, NumOfReps = 3},
                                                                    new ProgramRepScheme { SetNo = 2, Percentage = 80, NumOfReps = 3},
                                                                    new ProgramRepScheme { SetNo = 3, Percentage = 90, NumOfReps = 3}
                                                                                                          } },
                                          new ProgramExercise { ExerciseName = "Deadlift", WeekNumber = 2, DayNumber = 3, NoOfSets = 3,
                                                                ProgramRepSchemes = new List<ProgramRepScheme> {
                                                                    new ProgramRepScheme { SetNo = 1, Percentage = 70, NumOfReps = 3},
                                                                    new ProgramRepScheme { SetNo = 2, Percentage = 80, NumOfReps = 3},
                                                                    new ProgramRepScheme { SetNo = 3, Percentage = 90, NumOfReps = 3}
                                                                                                          } },

                                           //Week 3
                                          new ProgramExercise { ExerciseName = "Squat", WeekNumber = 3, DayNumber = 1, NoOfSets = 3,
                                                                ProgramRepSchemes = new List<ProgramRepScheme> {
                                                                    new ProgramRepScheme { SetNo = 1, Percentage = 75, NumOfReps = 5},
                                                                    new ProgramRepScheme { SetNo = 2, Percentage = 85, NumOfReps = 3},
                                                                    new ProgramRepScheme { SetNo = 3, Percentage = 95, NumOfReps = 1}
                                                                                                          } },
                                          new ProgramExercise { ExerciseName = "Bench Press", WeekNumber = 3, DayNumber = 2, NoOfSets = 3,
                                                                ProgramRepSchemes = new List<ProgramRepScheme> {
                                                                    new ProgramRepScheme { SetNo = 1, Percentage = 75, NumOfReps = 5},
                                                                    new ProgramRepScheme { SetNo = 2, Percentage = 85, NumOfReps = 5},
                                                                    new ProgramRepScheme { SetNo = 3, Percentage = 95, NumOfReps = 5}
                                                                                                          } },
                                          new ProgramExercise { ExerciseName = "Deadlift", WeekNumber = 3, DayNumber = 3, NoOfSets = 3,
                                                                ProgramRepSchemes = new List<ProgramRepScheme> {
                                                                    new ProgramRepScheme { SetNo = 1, Percentage = 75, NumOfReps = 5},
                                                                    new ProgramRepScheme { SetNo = 2, Percentage = 85, NumOfReps = 5},
                                                                    new ProgramRepScheme { SetNo = 3, Percentage = 95, NumOfReps = 5}
                                                                                                          } },
                                          //Week 4
                                          new ProgramExercise { ExerciseName = "Squat", WeekNumber = 4, DayNumber = 1, NoOfSets = 3,
                                                                ProgramRepSchemes = new List<ProgramRepScheme> {
                                                                    new ProgramRepScheme { SetNo = 1, Percentage = 40, NumOfReps = 5},
                                                                    new ProgramRepScheme { SetNo = 2, Percentage = 50, NumOfReps = 5},
                                                                    new ProgramRepScheme { SetNo = 3, Percentage = 60, NumOfReps = 5}
                                                                                                          } },
                                          new ProgramExercise { ExerciseName = "Bench Press", WeekNumber = 4, DayNumber = 2, NoOfSets = 3,
                                                                ProgramRepSchemes = new List<ProgramRepScheme> {
                                                                    new ProgramRepScheme { SetNo = 1, Percentage = 40, NumOfReps = 5},
                                                                    new ProgramRepScheme { SetNo = 2, Percentage = 50, NumOfReps = 5},
                                                                    new ProgramRepScheme { SetNo = 3, Percentage = 60, NumOfReps = 5}
                                                                                                          } },
                                          new ProgramExercise { ExerciseName = "Deadlift", WeekNumber = 4, DayNumber = 1, NoOfSets = 3,
                                                                ProgramRepSchemes = new List<ProgramRepScheme> {
                                                                    new ProgramRepScheme { SetNo = 1, Percentage = 40, NumOfReps = 5},
                                                                    new ProgramRepScheme { SetNo = 2, Percentage = 50, NumOfReps = 5},
                                                                    new ProgramRepScheme { SetNo = 3, Percentage = 60, NumOfReps = 5}
                                                                                                          } },
                    } }
                };

                foreach (ProgramTemplate e in templates)
                {
                    context.ProgramTemplate.Add(e);
                }
                context.SaveChanges();
            }

            if (!context.User.Any())
            {
                var users = new User[]
                {
                    new User{ Email="chrispauldillon@live.com", Password="test123",
                        LiftingStats= new LiftingStat { BenchWeight=100, DeadliftWeight=170, SquatWeight=200 },
                        ProgramLogs= new List<ProgramLog> {
                            new ProgramLog { StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(30), ProgramTemplateId = 1, NoOfDaysLifting = 4,
                                Monday = true, Tuesday = true,
                                ExeciseMarkups = new List<ExerciseMarkup> {
                                                    new ExerciseMarkup { LiftingDate = DateTime.Now, NumOfSets = 5,
                                                                         Exercise = new Exercise { ExerciseName = "Standing Press" },
                                                                         IndividualSets = new List<IndividualSet> {
                                                                                new IndividualSet { SetNo = 1, WeightLifted = 100, NumOfReps =5 }}}},
                        
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
 
