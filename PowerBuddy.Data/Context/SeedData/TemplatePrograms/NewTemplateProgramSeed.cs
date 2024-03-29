﻿using System;
using System.Collections.Generic;
using System.Linq;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.Context.SeedData.TemplatePrograms
{
    public static class NewTemplateProgramSeed
    {
        public static TemplateProgram[] CreateTemplatePrograms(List<Exercise> exercises)
        {
            return new TemplateProgram[]
            {
                CreateBeginnerSheiko(exercises)
            };
        }

        public static TemplateProgram CreateBeginnerSheiko(List<Exercise> exercises)
        {
            var squat = exercises.Where(x => x.ExerciseName.Contains("(B) Back Squat")).Select(x => x.ExerciseId).FirstOrDefault();
            var bench = exercises.Where(x => x.ExerciseName.Contains("(B) Bench Press")).Select(x => x.ExerciseId).FirstOrDefault();
            var declineBench = exercises.Where(x => x.ExerciseName.Contains("(B) Decline Bench Press")).Select(x => x.ExerciseId).FirstOrDefault();
            var deadlift = exercises.Where(x => x.ExerciseName.Contains("(B) Deadlift")).Select(x => x.ExerciseId).FirstOrDefault();
            var deadliftToKnee = exercises.Where(x => x.ExerciseName.Contains("(B) Deadlift (to knee")).Select(x => x.ExerciseId).FirstOrDefault();
            var deadliftFromBoxes = exercises.Where(x => x.ExerciseName.Contains("(B) Deadlift (from boxes)")).Select(x => x.ExerciseId).FirstOrDefault();
            var deficitDeadlift = exercises.Where(x => x.ExerciseName.Contains("(B) Deadlift (deficit)")).Select(x => x.ExerciseId).FirstOrDefault();
            var benchCloseGrip = exercises.Where(x => x.ExerciseName.Contains("(B) Bench Press (Close Grip)")).Select(x => x.ExerciseId).FirstOrDefault();
            var deadliftPaused = exercises.Where(x => x.ExerciseName.Contains("(B) Deadlift (paused)")).Select(x => x.ExerciseId).FirstOrDefault();

            return new TemplateProgram
            {
                Name = "Sheiko (Beginner)",
                Difficulty = Enum.GetName(typeof(TemplateDifficultyEnum), TemplateDifficultyEnum.Beginner),
                NoOfDaysPerWeek = 3,
                TemplateType = "Block",
                WeightProgressionType = Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.PERCENTAGE),
                TemplateDays = new List<TemplateDay>
                {
                    new TemplateDay()
                    {
                        WeekNo = 1,
                        DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                        new TemplateRepScheme {SetNo = 1, NoOfReps = 5, Percentage = 50},
                                        new TemplateRepScheme {SetNo = 2, NoOfReps = 5, Percentage = 60},
                                        new TemplateRepScheme {SetNo = 3, NoOfReps = 4, Percentage = 70},
                                        new TemplateRepScheme {SetNo = 4, NoOfReps = 4, Percentage = 70},
                                        new TemplateRepScheme {SetNo = 5, NoOfReps = 4, Percentage = 70},
                                        new TemplateRepScheme {SetNo = 6, NoOfReps = 4, Percentage = 70},
                                        }
                                },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, NoOfReps = 5, Percentage = 50},
                                        new TemplateRepScheme {SetNo = 2, NoOfReps = 4, Percentage = 60},
                                        new TemplateRepScheme {SetNo = 3, NoOfReps = 3, Percentage = 70},
                                        new TemplateRepScheme {SetNo = 4, NoOfReps = 3, Percentage = 75},
                                        new TemplateRepScheme {SetNo = 5, NoOfReps = 3, Percentage = 75},
                                        new TemplateRepScheme {SetNo = 6, NoOfReps = 3, Percentage = 75},
                                        new TemplateRepScheme {SetNo = 7, NoOfReps = 3, Percentage = 75},
                                    }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 1,
                        DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadliftToKnee,
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 3, Percentage = 50},
                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 3, Percentage = 60},
                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 3, Percentage = 70},
                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 2, Percentage = 75},
                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 2, Percentage = 75},
                                    new TemplateRepScheme {SetNo = 6, NoOfReps = 2, Percentage = 75},
                                    new TemplateRepScheme {SetNo = 7, NoOfReps = 2, Percentage = 75},
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = deadliftFromBoxes,
                                
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 3, Percentage = 55},
                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 3, Percentage = 65},
                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 3, Percentage = 75},
                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 2, Percentage = 85},
                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 2, Percentage = 85},
                                    new TemplateRepScheme {SetNo = 6, NoOfReps = 2, Percentage = 85},
                                }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 1,
                        DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                
                                 TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, NoOfReps = 5, Percentage = 50},
                                        new TemplateRepScheme {SetNo = 2, NoOfReps = 4, Percentage = 60},
                                        new TemplateRepScheme {SetNo = 3, NoOfReps = 3, Percentage = 70},
                                        new TemplateRepScheme {SetNo = 4, NoOfReps = 3, Percentage = 75},
                                        new TemplateRepScheme {SetNo = 5, NoOfReps = 3, Percentage = 75},
                                        new TemplateRepScheme {SetNo = 6, NoOfReps = 3, Percentage = 75},
                                        new TemplateRepScheme {SetNo = 7, NoOfReps = 3, Percentage = 75},
                                    }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                
                                
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 5, Percentage = 50},
                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 4, Percentage = 60},
                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 3, Percentage = 70},
                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 2, Percentage = 80},
                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 2, Percentage = 80},
                                    new TemplateRepScheme {SetNo = 6, NoOfReps = 2, Percentage = 80},
                                    new TemplateRepScheme {SetNo = 7, NoOfReps = 2, Percentage = 80},
                                }
                            },
                        }

                    },
                    new TemplateDay()
                    {
                        WeekNo = 2,
                        DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                
                                
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 5, Percentage = 50},
                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 4, Percentage = 60},
                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 3, Percentage = 70},
                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 2, Percentage = 80},
                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 2, Percentage = 80},
                                    new TemplateRepScheme {SetNo = 6, NoOfReps = 2, Percentage = 80},
                                    new TemplateRepScheme {SetNo = 7, NoOfReps = 2, Percentage = 80},
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                
                                
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 5, Percentage = 50},
                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 4, Percentage = 60},
                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 3, Percentage = 70},
                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 3, Percentage = 80},
                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 3, Percentage = 80},
                                    new TemplateRepScheme {SetNo = 6, NoOfReps = 3, Percentage = 80},
                                    new TemplateRepScheme {SetNo = 7, NoOfReps = 3, Percentage = 80},
                                    new TemplateRepScheme {SetNo = 8, NoOfReps = 3, Percentage = 80},
                                }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 2,
                        DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadliftToKnee,
                                
                                
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 3, Percentage = 50},
                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 3, Percentage = 60},
                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 3, Percentage = 70},
                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 2, Percentage = 75},
                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 2, Percentage = 75},
                                    new TemplateRepScheme {SetNo = 6, NoOfReps = 2, Percentage = 75},
                                    new TemplateRepScheme {SetNo = 7, NoOfReps = 2, Percentage = 75},
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                
                                
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 6, Percentage = 50},
                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 6, Percentage = 60},
                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 6, Percentage = 65},
                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 6, Percentage = 65},
                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 6, Percentage = 65},
                                    new TemplateRepScheme {SetNo = 6, NoOfReps = 6, Percentage = 65},
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = deadliftFromBoxes,
                                
                                
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 4, Percentage = 55},
                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 4, Percentage = 65},
                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 4, Percentage = 75},
                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 4, Percentage = 75},
                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 4, Percentage = 75},
                                    new TemplateRepScheme {SetNo = 6, NoOfReps = 4, Percentage = 75},
                                }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 2,
                        DayNo = 3,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 5, Percentage = 50},
                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 5, Percentage = 60},
                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 4, Percentage = 70},
                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 4, Percentage = 70},
                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 4, Percentage = 70},
                                    new TemplateRepScheme {SetNo = 6, NoOfReps = 4, Percentage = 70},
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = benchCloseGrip,
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 3, Percentage = 50},
                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 3, Percentage = 60},
                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 3, Percentage = 70},
                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 3, Percentage = 70},
                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 3, Percentage = 70},
                                    new TemplateRepScheme {SetNo = 6, NoOfReps = 3, Percentage = 70},
                                }
                            },
                        }
                    },
                    new TemplateDay()
                    {
                        WeekNo = 3,
                        DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 5, Percentage = 50},
                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 4, Percentage = 60},
                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 3, Percentage = 70},
                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 3, Percentage = 75},
                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 3, Percentage = 75},
                                    new TemplateRepScheme {SetNo = 6, NoOfReps = 3, Percentage = 75},
                                    new TemplateRepScheme {SetNo = 7, NoOfReps = 3, Percentage = 75},
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 5, Percentage = 50},
                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 4, Percentage = 60},
                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 3, Percentage = 70},
                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 2, Percentage = 80},
                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 2, Percentage = 80},
                                    new TemplateRepScheme {SetNo = 6, NoOfReps = 2, Percentage = 80},
                                    new TemplateRepScheme {SetNo = 7, NoOfReps = 2, Percentage = 80},
                                    new TemplateRepScheme {SetNo = 8, NoOfReps = 2, Percentage = 80},
                                }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 3,
                        DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deficitDeadlift,
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 3, Percentage = 50},
                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 3, Percentage = 60},
                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 2, Percentage = 65},
                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 2, Percentage = 65},
                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 2, Percentage = 65},
                                    new TemplateRepScheme {SetNo = 6, NoOfReps = 2, Percentage = 65},
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, NoOfReps = 5, Percentage = 50},
                                        new TemplateRepScheme {SetNo = 2, NoOfReps = 4, Percentage = 60},
                                        new TemplateRepScheme {SetNo = 3, NoOfReps = 3, Percentage = 70},
                                        new TemplateRepScheme {SetNo = 4, NoOfReps = 3, Percentage = 80},
                                        new TemplateRepScheme {SetNo = 5, NoOfReps = 3, Percentage = 80},
                                        new TemplateRepScheme {SetNo = 6, NoOfReps = 2, Percentage = 85},
                                        new TemplateRepScheme {SetNo = 7, NoOfReps = 2, Percentage = 85},
                                        new TemplateRepScheme {SetNo = 8, NoOfReps = 2, Percentage = 85},
                                    }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = deadliftFromBoxes,
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 3, Percentage = 60},
                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 3, Percentage = 70},
                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 3, Percentage = 80},
                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 3, Percentage = 80},
                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 2, Percentage = 90},
                                    new TemplateRepScheme {SetNo = 6, NoOfReps = 2, Percentage = 90},
                                    new TemplateRepScheme {SetNo = 7, NoOfReps = 2, Percentage = 90},
                                }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 3,
                        DayNo = 3,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                
                                
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 5, Percentage = 50},
                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 4, Percentage = 60},
                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 3, Percentage = 70},
                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 2, Percentage = 80},
                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 2, Percentage = 80},
                                    new TemplateRepScheme {SetNo = 6, NoOfReps = 2, Percentage = 80},
                                    new TemplateRepScheme {SetNo = 7, NoOfReps = 2, Percentage = 80},
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = declineBench,
                                
                                
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 4, Percentage = 50},
                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 4, Percentage = 60},
                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 4, Percentage = 70},
                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 4, Percentage = 70},
                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 4, Percentage = 70},
                                    new TemplateRepScheme {SetNo = 6, NoOfReps = 4, Percentage = 70},
                                }
                            },
                        }
                    },
                    new TemplateDay()
                    {
                        WeekNo = 4,
                        DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                
                                
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 5, Percentage = 50},
                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 4, Percentage = 60},
                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 3, Percentage = 70},
                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 2, Percentage = 80},
                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 2, Percentage = 80},
                                    new TemplateRepScheme {SetNo = 6, NoOfReps = 2, Percentage = 85},
                                    new TemplateRepScheme {SetNo = 7, NoOfReps = 2, Percentage = 85},
                                    new TemplateRepScheme {SetNo = 8, NoOfReps = 2, Percentage = 85},
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                
                                
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 5, Percentage = 50},
                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 4, Percentage = 60},
                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 3, Percentage = 70},
                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 3, Percentage = 80},
                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 3, Percentage = 80},
                                    new TemplateRepScheme {SetNo = 6, NoOfReps = 3, Percentage = 80},
                                    new TemplateRepScheme {SetNo = 7, NoOfReps = 3, Percentage = 80},
                                    new TemplateRepScheme {SetNo = 8, NoOfReps = 3, Percentage = 80},
                                }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 4,
                        DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                
                                
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 5, Percentage = 50},
                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 4, Percentage = 60},
                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 3, Percentage = 70},
                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 3, Percentage = 80},
                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 2, Percentage = 85},
                                    new TemplateRepScheme {SetNo = 6, NoOfReps = 2, Percentage = 85},
                                    new TemplateRepScheme {SetNo = 7, NoOfReps = 2, Percentage = 85},
                                    new TemplateRepScheme {SetNo = 8, NoOfReps = 2, Percentage = 85},
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = deadliftPaused,
                                
                                
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 2, Percentage = 50},
                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 2, Percentage = 60},
                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 2, Percentage = 70},
                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 2, Percentage = 70},
                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 1, Percentage = 75},
                                    new TemplateRepScheme {SetNo = 6, NoOfReps = 1, Percentage = 75},
                                    new TemplateRepScheme {SetNo = 7, NoOfReps = 1, Percentage = 75},
                                }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 4,
                        DayNo = 3,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 5, Percentage = 55},
                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 4, Percentage = 65},
                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 3, Percentage = 75},
                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 3, Percentage = 75},
                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 3, Percentage = 75},
                                    new TemplateRepScheme {SetNo = 6, NoOfReps = 3, Percentage = 75},
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                
                                
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 4, Percentage = 50},
                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 4, Percentage = 60},
                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 4, Percentage = 70},
                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 4, Percentage = 70},
                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 4, Percentage = 70},
                                    new TemplateRepScheme {SetNo = 6, NoOfReps = 4, Percentage = 70},
                                }
                            },
                        }
                    }
                }
            };
        }
    }
}
