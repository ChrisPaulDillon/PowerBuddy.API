using System;
using System.Collections.Generic;
using PowerLifting.Entity.System.ExerciseMuscleGroups.Models;
using PowerLifting.Entity.System.Exercises.Models;
using PowerLifting.Entity.System.ExerciseSports.Model;

namespace PowerLifting.Persistence
{
    public static class ExerciseSeed
    {
        public static Exercise[] CreateExercises()
        {
            return new Exercise[]
            {
                new Exercise
                {
                    ExerciseName="Back Squat", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Quads" },
                        new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Hamstrings" },
                        new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Lower Back" },
                    },
                    ExerciseSports = new List<ExerciseSport>
                    {
                        new ExerciseSport { ExerciseSportStr = "PowerLifting" },
                        new ExerciseSport { ExerciseSportStr = "Olympic WeightLifting" },
                    },
                },
                new Exercise
                {
                    ExerciseName="DeadLift", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Lower Back" },
                        new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Upper Back" },
                        new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Hamstring" },
                    },
                    ExerciseSports = new List<ExerciseSport>
                    {
                        new ExerciseSport { ExerciseSportStr = "PowerLifting" },
                        new ExerciseSport { ExerciseSportStr = "Olympic WeightLifting" },
                    },
                },
                new Exercise
                {
                    ExerciseName="Bench Press", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Chest" },
                        new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Tricep" },
                        new ExerciseMuscleGroup { ExerciseMuscleGroupName = "Anterior Deltoid" },
                    },
                    ExerciseSports = new List<ExerciseSport>
                    {
                        new ExerciseSport { ExerciseSportStr = "PowerLifting" },
                    },
                },
                new Exercise
                {
                    ExerciseName="Overhead Press", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
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

            var exercises = new Exercise[]
            {

            };
        }
    }
}
