using System;
using System.Collections.Generic;
using System.Linq;
using PowerLifting.Service.Users.Model;
using PowerLifting.Service.Exercises.Model;
using PowerLifting.Service.LiftingStats.Model;
using PowerLifting.Service.ProgramLogs.Model;
using PowerLifting.Service.TemplatePrograms.Model;

namespace PowerLifting.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(PowerliftingContext context)
         {
            var curDate = DateTime.Now.Date;
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
                        }, },
                    new Exercise{ExerciseName="Conventional Deadlift", ExerciseTypeId = 2,
                        IsProgrammable = true, ExerciseMuscleGroups = new List<ExerciseMuscleGroup> {
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Lower Back" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Upper Back" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Hamstring" },
                        }, },
                    new Exercise{ExerciseName="Bench Press", ExerciseTypeId = 2,
                        IsProgrammable = true, ExerciseMuscleGroups = new List<ExerciseMuscleGroup> {
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Chest" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Tricep" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Anterior Deltoid" },
                        }, },
                    new Exercise{ExerciseName="Overhead Press", ExerciseTypeId = 2,
                            IsProgrammable = true, ExerciseMuscleGroups = new List<ExerciseMuscleGroup> {
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Anterior Deltoid" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Tricep" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Trapezius" },
                        }, },
                    new Exercise{ExerciseName="Front Squat", ExerciseTypeId = 2,
                            IsProgrammable = true, ExerciseMuscleGroups = new List<ExerciseMuscleGroup> {
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Quadricep" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Glute" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Abdominal" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Upper Back" },
                        }, },
                    new Exercise{ExerciseName="Overhead Squat", ExerciseTypeId = 2,
                            IsProgrammable = true, ExerciseMuscleGroups = new List<ExerciseMuscleGroup> {
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Shoulder" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Quadricep" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Glute" },
                                new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Upper Back" },
                        }, },
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
                    new TemplateProgram {Name="5/3/1", Difficulty="Beginner", NoOfWeeks = 4, MaxLiftDaysPerWeek = 4, TemplateType="Block", WeightProgressionType=Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.PERCENTAGE),
                         TemplateExerciseCollection = new List<TemplateExerciseCollection> {
                            new TemplateExerciseCollection { TemplateProgramId = 1, ExerciseId = 1 },
                            new TemplateExerciseCollection { TemplateProgramId = 1, ExerciseId = 26 },
                            new TemplateExerciseCollection { TemplateProgramId = 1, ExerciseId = 27 } },
                            TemplateWeeks = new List<TemplateWeek> {
                            new TemplateWeek { WeekNumber = 1,TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, NoOfSets = 3, TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 65, NumOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 75, NumOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 85, NumOfReps = 5}
                                                                                                          } } } },
                                    new TemplateDay { TemplateExercises = new List<TemplateExercise>{
                                          new TemplateExercise { ExerciseId = 26, NoOfSets = 3, TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 65, NumOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 75, NumOfReps = 5},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 85, NumOfReps = 5}
                                                                                                          } } } },
                                    new TemplateDay { TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 27, NoOfSets = 3, TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 65, NumOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 75, NumOfReps = 5},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 85, NumOfReps = 5}
                                                                                                          } } } } } },
                            //Week 2
                            new TemplateWeek { WeekNumber = 2, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, NoOfSets = 3, TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 70, NumOfReps = 3},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 80, NumOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 90, NumOfReps = 3}
                                                                                                          } } } },
                                    new TemplateDay { TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 26, NoOfSets = 3, TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 70, NumOfReps = 3},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 80, NumOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 90, NumOfReps = 3}
                                                                                                          } } } },
                                    new TemplateDay { TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 27, NoOfSets = 3, TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 70, NumOfReps = 3},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 80, NumOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 90, NumOfReps = 3}
                                                                                                          } } } } } },
                             //Week 3
                            new TemplateWeek { WeekNumber = 3, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, NoOfSets = 3, TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 75, NumOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 85, NumOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 95, NumOfReps = 1}
                                                                                                          } } } },
                                    new TemplateDay { TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 26, NoOfSets = 3, TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 75, NumOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 85, NumOfReps = 5},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 95, NumOfReps = 5}
                                                                                                          } } } },
                                    new TemplateDay { TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 27, NoOfSets = 3,TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 75, NumOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 85, NumOfReps = 5},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 95, NumOfReps = 5}
                                                                                                          } } } } } },
                                          //Week 4
                            new TemplateWeek { WeekNumber = 4, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, NoOfSets = 3, TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NumOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NumOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NumOfReps = 5}
                                                                                                          } } } },
                                    new TemplateDay { TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 26, NoOfSets = 3, TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NumOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NumOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NumOfReps = 5}
                                                                                                          } } } },
                                    new TemplateDay { TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 27, NoOfSets = 3, TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NumOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NumOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NumOfReps = 5}
                                                                                                          } } } } } },
                    } },
                    new TemplateProgram {Name="5/3/1 Boring But Big", Difficulty="Beginner", NoOfWeeks = 4, MaxLiftDaysPerWeek = 4, TemplateType="Block", WeightProgressionType=Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.PERCENTAGE),
                         TemplateExerciseCollection = new List<TemplateExerciseCollection> {
                            new TemplateExerciseCollection { TemplateProgramId = 2, ExerciseId = 1 },
                            new TemplateExerciseCollection { TemplateProgramId = 2, ExerciseId = 26 },
                            new TemplateExerciseCollection { TemplateProgramId = 2, ExerciseId = 27 },
                            new TemplateExerciseCollection { TemplateProgramId = 2, ExerciseId = 25 } },
                            TemplateWeeks = new List<TemplateWeek> {
                            new TemplateWeek { WeekNumber = 1,TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 25, NoOfSets = 8, TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 65, NumOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 75, NumOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 85, NumOfReps = 5},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 50, NumOfReps = 10},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 50, NumOfReps = 10},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 50, NumOfReps = 10},
                                          new TemplateRepScheme { SetNo = 7, Percentage = 50, NumOfReps = 10},
                                          new TemplateRepScheme { SetNo = 8, Percentage = 50, NumOfReps = 10},
                                                                                                          } } } },
                                    new TemplateDay { TemplateExercises = new List<TemplateExercise>{
                                          new TemplateExercise { ExerciseId = 26, NoOfSets = 3, TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 65, NumOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 75, NumOfReps = 5},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 85, NumOfReps = 5},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NumOfReps = 10},
                                                                                                          } } } },
                                    new TemplateDay { TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 27, NoOfSets = 3, TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 65, NumOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 75, NumOfReps = 5},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 85, NumOfReps = 5},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NumOfReps = 10},
                                                                                                          } } } } } },
                            //Week 2
                            new TemplateWeek { WeekNumber = 2, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, NoOfSets = 3, TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 70, NumOfReps = 3},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 80, NumOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 90, NumOfReps = 3},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NumOfReps = 10},
                                                                                                          } } } },
                                    new TemplateDay { TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 26, NoOfSets = 3, TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 70, NumOfReps = 3},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 80, NumOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 90, NumOfReps = 3},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NumOfReps = 10},
                                                                                                          } } } },
                                    new TemplateDay { TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 27, NoOfSets = 3, TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 70, NumOfReps = 3},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 80, NumOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 90, NumOfReps = 3},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NumOfReps = 10},
                                                                                                          } } } } } },
                             //Week 3
                            new TemplateWeek { WeekNumber = 3, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, NoOfSets = 3, TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 75, NumOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 85, NumOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 95, NumOfReps = 1},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NumOfReps = 10},
                                                                                                          } } } },
                                    new TemplateDay { TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 26, NoOfSets = 3, TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 75, NumOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 85, NumOfReps = 5},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 95, NumOfReps = 5},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NumOfReps = 10},
                                                                                                          } } } },
                                    new TemplateDay { TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 27, NoOfSets = 3,TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 75, NumOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 85, NumOfReps = 5},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 95, NumOfReps = 5},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NumOfReps = 10},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NumOfReps = 10},
                                                                                                          } } } } } },
                                          //Week 4
                            new TemplateWeek { WeekNumber = 4, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, NoOfSets = 3, TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NumOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NumOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NumOfReps = 5}
                                                                                                          } } } },
                                    new TemplateDay { TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 26, NoOfSets = 3, TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NumOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NumOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NumOfReps = 5}
                                                                                                          } } } },
                                    new TemplateDay { TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 27, NoOfSets = 3, TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NumOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NumOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NumOfReps = 5}
                                                                                                          } } } } } },
                    } },
                    new TemplateProgram { Name="Stronglifts 5x5", Difficulty="Beginner", NoOfWeeks = 12, MaxLiftDaysPerWeek = 3, TemplateType="Block", WeightProgressionType=Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.INCREMENTAL), 
                         TemplateExerciseCollection = new List<TemplateExerciseCollection> {
                            new TemplateExerciseCollection { TemplateProgramId = 3, ExerciseId = 1 },
                            new TemplateExerciseCollection { TemplateProgramId = 3, ExerciseId = 25},
                            new TemplateExerciseCollection { TemplateProgramId = 3, ExerciseId = 26 },
                            new TemplateExerciseCollection { TemplateProgramId = 3, ExerciseId = 27 },
                            new TemplateExerciseCollection { TemplateProgramId = 3, ExerciseId = 2 } },
                            TemplateWeeks = new List<TemplateWeek> {
                            new TemplateWeek { WeekNumber = 1,TemplateDays = new List<TemplateDay> {
                                   new TemplateDay { TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, NoOfSets = 5, TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NumOfReps = 5}
                                        } },
                                       new TemplateExercise { ExerciseId = 26, NoOfSets = 5, TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NumOfReps = 5}
                                        } },
                                        new TemplateExercise { ExerciseId = 2, NoOfSets = 5, TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NumOfReps = 5}
                                        } },
                                    } },
                                    new TemplateDay { TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, NoOfSets = 5, TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NumOfReps = 5}
                                        } },
                                       new TemplateExercise { ExerciseId = 25, NoOfSets = 5, TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NumOfReps = 5}
                                        } },
                                        new TemplateExercise { ExerciseId = 27, NoOfSets = 5, TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NumOfReps = 5}
                                        } },
                                    } },
                                    new TemplateDay { TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, NoOfSets = 5, TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NumOfReps = 5}
                                        } },
                                       new TemplateExercise { ExerciseId = 26, NoOfSets = 5, TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NumOfReps = 5}
                                        } },
                                        new TemplateExercise { ExerciseId = 2, NoOfSets = 5, TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 0, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NumOfReps = 5}
                                        } },
                                    } } } },
                            new TemplateWeek { WeekNumber = 2,TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, NoOfSets = 5, TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NumOfReps = 5}
                                        } },
                                       new TemplateExercise { ExerciseId = 25, NoOfSets = 5, TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NumOfReps = 5}
                                        } },
                                        new TemplateExercise { ExerciseId = 27, NoOfSets = 5, TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NumOfReps = 5}
                                        } },
                                    } },
                                    new TemplateDay { TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, NoOfSets = 5, TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NumOfReps = 5}
                                        } },
                                       new TemplateExercise { ExerciseId = 26, NoOfSets = 5, TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NumOfReps = 5}
                                        } },
                                        new TemplateExercise { ExerciseId = 2, NoOfSets = 5, TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NumOfReps = 5}
                                        } },
                                    } },
                                     new TemplateDay { TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, NoOfSets = 5, TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NumOfReps = 5}
                                        } },
                                       new TemplateExercise { ExerciseId = 25, NoOfSets = 5, TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NumOfReps = 5}
                                        } },
                                        new TemplateExercise { ExerciseId = 27, NoOfSets = 5, TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NumOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NumOfReps = 5}
                                        } }
                                    } } } } } }
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
                        LiftingStats= new List<LiftingStat> {
                            new LiftingStat { RepRange=1, ExerciseId=1, Weight=100, LastUpdated=curDate},
                            new LiftingStat { RepRange=1, ExerciseId=26, Weight=120, LastUpdated=curDate},
                            new LiftingStat { RepRange=1, ExerciseId=27, Weight=130, LastUpdated=curDate}
                        },
                        ProgramLogs= new List<ProgramLog> {
                            new ProgramLog { StartDate = curDate, EndDate = curDate.AddDays(30), TemplateProgramId = 1, Monday = true, Tuesday = true, ProgramLogWeeks = new List<ProgramLogWeek> {
                                    new ProgramLogWeek { StartDate = curDate, EndDate = curDate.AddDays(7), ProgramLogDays = new List<ProgramLogDay> {
                                        new ProgramLogDay { DayOfWeek = "Monday", Date = curDate, ProgramLogExercises = new List<ProgramLogExercise> {
                                             new ProgramLogExercise { NoOfSets = 5, ExerciseId = 1, ProgramLogRepSchemes = new List<ProgramLogRepScheme> {
                                                new ProgramLogRepScheme { SetNo = 1, WeightLifted = 100, NumOfReps =5 },
                                                new ProgramLogRepScheme { SetNo = 2, WeightLifted = 120, NumOfReps =5 },
                                                new ProgramLogRepScheme { SetNo = 3, WeightLifted = 130, NumOfReps =5 },
                                               }}}},
                                         new ProgramLogDay { DayOfWeek = "Tuesday", Date = curDate.AddDays(1), ProgramLogExercises = new List<ProgramLogExercise> {
                                              new ProgramLogExercise {  NoOfSets = 5, ExerciseId = 27, ProgramLogRepSchemes = new List<ProgramLogRepScheme> {
                                                new ProgramLogRepScheme { SetNo = 1, WeightLifted = 100, NumOfReps =5 },
                                                new ProgramLogRepScheme { SetNo = 2, WeightLifted = 120, NumOfReps =5 },
                                                new ProgramLogRepScheme { SetNo = 3, WeightLifted = 130, NumOfReps =5 },
                                                }}}},
                                         new ProgramLogDay { DayOfWeek = "Wednesday", Date = curDate.AddDays(2), ProgramLogExercises = new List<ProgramLogExercise> {
                                                new ProgramLogExercise {  NoOfSets = 5, ExerciseId = 1, ProgramLogRepSchemes = new List<ProgramLogRepScheme> {
                                                new ProgramLogRepScheme { SetNo = 1, WeightLifted = 100, NumOfReps =5 },
                                                new ProgramLogRepScheme { SetNo = 2, WeightLifted = 120, NumOfReps =5 },
                                                new ProgramLogRepScheme { SetNo = 3, WeightLifted = 130, NumOfReps =5 },
                                                }}}},
                                         new ProgramLogDay { DayOfWeek = "Wednesday", Date = curDate.AddDays(3), ProgramLogExercises = new List<ProgramLogExercise> {
                                                new ProgramLogExercise {  NoOfSets = 5, ExerciseId = 26, ProgramLogRepSchemes = new List<ProgramLogRepScheme> {
                                                new ProgramLogRepScheme { SetNo = 1, WeightLifted = 100, NumOfReps =5 },
                                                new ProgramLogRepScheme { SetNo = 2, WeightLifted = 120, NumOfReps =5 },
                                                new ProgramLogRepScheme { SetNo = 3, WeightLifted = 130, NumOfReps =5 },
                                                }}}}
                                    }
                                    }
                                }
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
 
