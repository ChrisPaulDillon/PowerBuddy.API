using System;
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
            var squat = exercises.Where(x => x.ExerciseName.Contains("(B) Back Squat"))
                .Select<Exercise, int>(x => x.ExerciseId).FirstOrDefault();
            var bench = exercises.Where(x => x.ExerciseName.Contains("(B) Bench Press"))
                .Select<Exercise, int>(x => x.ExerciseId).FirstOrDefault();
            var declineBench = exercises.Where(x => x.ExerciseName.Contains("(B) Decline Bench Press"))
                .Select<Exercise, int>(x => x.ExerciseId).FirstOrDefault();
            var deadlift = exercises.Where(x => x.ExerciseName.Contains("(B) DeadLift"))
                .Select<Exercise, int>(x => x.ExerciseId).FirstOrDefault();
            var deadliftToKnee = exercises.Where(x => x.ExerciseName.Contains("(B) Deadlift (to knee"))
                .Select<Exercise, int>(x => x.ExerciseId).FirstOrDefault();
            var deadliftFromBoxes = exercises.Where(x => x.ExerciseName.Contains("(B) Deadlift (from boxes)"))
                .Select<Exercise, int>(x => x.ExerciseId).FirstOrDefault();
            var deficitDeadlift = exercises.Where(x => x.ExerciseName.Contains("(B) Deadlift (deficit)"))
                .Select<Exercise, int>(x => x.ExerciseId).FirstOrDefault();
            var benchCloseGrip = exercises.Where(x => x.ExerciseName.Contains("(B) Bench Press (Close Grip)"))
                .Select<Exercise, int>(x => x.ExerciseId).FirstOrDefault();
            var deadliftPaused = exercises.Where(x => x.ExerciseName.Contains("(B) Deadlift (Paused)"))
                .Select<Exercise, int>(x => x.ExerciseId).FirstOrDefault();

            return new TemplateProgram
            {
                Name = "Sheiko (Beginner)",
                Difficulty = Enum.GetName(typeof(TemplateDifficultyEnum), TemplateDifficultyEnum.Beginner),
                NoOfWeeks = 4,
                NoOfDaysPerWeek = 3,
                TemplateType = "Block",
                WeightProgressionType =
                    Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.PERCENTAGE),
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
                                RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                NoOfSets = 6, RepSchemeFormat = "1x5, 1x5, 4x4", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
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
                                RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                NoOfSets = 7, RepSchemeFormat = "1x5, 1x4, 1x3, 4x3", TemplateRepSchemes =
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
                        }
                    },
                    new TemplateDay
                    {
                        DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadliftToKnee,
                                RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                NoOfSets = 7, RepSchemeFormat = "1x3, 1x3, 1x3, 4x2",
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
                                RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                NoOfSets = 6, RepSchemeFormat = "1x3, 1x3, 1x3, 3x2",
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
                        DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                NoOfSets = 7, RepSchemeFormat = "1x5, 1x4, 1x3, 4x3", TemplateRepSchemes =
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
                                RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                NoOfSets = 7, RepSchemeFormat = "1x5, 1x4, 1x3, 4x2",
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
                                RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                NoOfSets = 7, RepSchemeFormat = "1x5, 1x4, 1x3, 4x2",
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
                                RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                NoOfSets = 8, RepSchemeFormat = "1x5, 1x4, 1x3, 5x3",
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
                        DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadliftToKnee,
                                RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                NoOfSets = 7, RepSchemeFormat = "1x3, 1x3, 1x3, 4x2",
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
                                RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                NoOfSets = 6, RepSchemeFormat = "1x6, 1x6, 4x6",
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
                                RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                NoOfSets = 6, RepSchemeFormat = "1x4, 1x4, 4x4",
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
                        DayNo = 3,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                NoOfSets = 6, RepSchemeFormat = "1x5, 1x5, 4x4",
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
                                RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                NoOfSets = 6, RepSchemeFormat = "1x3, 1x3, 4x3",
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
                                RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                NoOfSets = 7, RepSchemeFormat = "1x5, 1x4, 1x3, 4x3",
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
                                RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                NoOfSets = 8, RepSchemeFormat = "1x5, 1x4, 1x3, 5x2",
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
                        DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deficitDeadlift,
                                RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                NoOfSets = 6, RepSchemeFormat = "1x3, 1x3, 4x2",
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
                                RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                NoOfSets = 8, RepSchemeFormat = "1x5, 1x4, 1x3, 2x3, 3x2", TemplateRepSchemes =
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
                                RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                NoOfSets = 7, RepSchemeFormat = "1x3, 1x3, 2x3 3x2",
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
                        DayNo = 3,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                NoOfSets = 7, RepSchemeFormat = "1x5, 1x4, 1x3, 4x2",
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
                                RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                NoOfSets = 6, RepSchemeFormat = "1x4, 1x4, 4x4",
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
                                RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                NoOfSets = 8, RepSchemeFormat = "1x5, 1x4, 1x3, 2x2, 3x2",
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
                                RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                NoOfSets = 8, RepSchemeFormat = "1x5, 1x4, 1x3, 5x3",
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
                        DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                NoOfSets = 8, RepSchemeFormat = "1x5, 1x4, 1x3, 1x3, 4x2",
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
                                RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                NoOfSets = 7, RepSchemeFormat = "1x2, 1x2, 2x2, 3x1",
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
                        DayNo = 3,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                NoOfSets = 6, RepSchemeFormat = "1x5, 1x4, 4x3",
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
                                RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                NoOfSets = 6, RepSchemeFormat = "1x4, 1x4, 4x4",
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
