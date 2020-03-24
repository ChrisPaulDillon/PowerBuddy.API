using System;
using System.Collections.Generic;
using System.Linq;
using PowerLifting.Entities.Model;
using PowerLifting.Entities.Model.Lookups;
using PowerLifting.Entities.Model.Programs;

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
                    new ExerciseCategory{CategoryName="Bodyweight"},
                    new ExerciseCategory{CategoryName="Barbells"},
                    new ExerciseCategory{CategoryName="Core"},
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
                    //new Exercise{ExerciseName="Squat"},
                    //new Exercise{ExerciseName="Deadlift"},
                    //new Exercise{ExerciseName="Bench Press"},
                    new Exercise{ExerciseName="Overhead Press"},
                    new Exercise{ExerciseName="Dumbbell Press"},
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
                        ProgramType = new ProgramType{Name="5/3/1", ProgramExercises = new List<ProgramExercise> {
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
 
