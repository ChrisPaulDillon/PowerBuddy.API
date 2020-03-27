using System;
using System.Collections.Generic;
using System.Linq;
using Powerlifting.Service.Exercises.Model;
using Powerlifting.Service.LiftingStats.Model;
using Powerlifting.Service.ProgramExercises.Model;
using Powerlifting.Services.ExerciseCategories.Model;
using Powerlifting.Services.IndividualSets.Model;
using Powerlifting.Services.ProgramLogs;
using Powerlifting.Services.ProgramTemplates;
using Powerlifting.Services.Users.Model;
using PowerLifting.ExerciseMarkups.Model;

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
  
            if (!context.User.Any())
            {
                var users = new User[]
                {
                    new User{ Email="chrispauldillon@live.com", Password="test123",
                        LiftingStats= new LiftingStat { BenchWeight=100, DeadliftWeight=170, SquatWeight=200 },
                        ProgramLogs= new List<ProgramLog> {
                            new ProgramLog { StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(30), NoOfDaysLifting = 4, Monday = true, Tuesday = true,
                                            ExeciseMarkups = new List<ExerciseMarkup> { new ExerciseMarkup { LiftingDate = DateTime.Now, NumOfSets = 5,
                                                                        Exercise = new Exercise { ExerciseName = "Standing Press" },
                                                                                IndividualSets = new List<IndividualSet> { new IndividualSet { SetNo = 1, WeightLifted = 100, NumOfReps =5 }},
                                                                                }},
                        ProgramTemplate = new ProgramTemplate{Name="5/3/1", Difficulty="Beginner", ProgramExercises = new List<ProgramExercise> {
                                                                                            new ProgramExercise { ExerciseId = 0, DayOfWeek = "Monday", WeekNumber = 1,
                                                                                             IndividualSets = new List<IndividualSet> { new IndividualSet { SetNo = 3, NumOfReps = 5, WeightLifted = 100},
                                                                                                              new IndividualSet { SetNo = 3, NumOfReps = 5, WeightLifted = 100},
                                                                                                              new IndividualSet { SetNo = 3, NumOfReps = 5, WeightLifted = 100} } },
                                                                                            new ProgramExercise { ExerciseId = 0, DayOfWeek = "Monday", WeekNumber = 1},
                                                                                            new ProgramExercise { ExerciseId = 0, DayOfWeek = "Monday", WeekNumber = 1 } },
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
 
