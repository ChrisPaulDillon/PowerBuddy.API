using System;
using System.Collections.Generic;
using System.Linq;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.SeedData.TemplatePrograms
{
    public static class TemplateProgramSeed
    {
        public static TemplateProgram[] CreateTemplatePrograms(List<Exercise> exercises)
        {
            var squat = exercises.Where(x => x.ExerciseName.ToLower() == "(B) Back Squat".ToLower()).Select(x => x.ExerciseId).FirstOrDefault();
            var bench = exercises.Where(x => x.ExerciseName.ToLower() == "(B) Bench Press".ToLower()).Select(x => x.ExerciseId).FirstOrDefault();
            var deadlift = exercises.Where(x => x.ExerciseName.ToLower() == "(B) DeadLift".ToLower()).Select(x => x.ExerciseId).FirstOrDefault();
            var row = exercises.Where(x => x.ExerciseName.ToLower() == "(B) Row".ToLower()).Select(x => x.ExerciseId).FirstOrDefault();
            var overheadPress = exercises.Where(x => x.ExerciseName == "(B) Overhead Press").Select(x => x.ExerciseId).FirstOrDefault();

            var templates = new TemplateProgram[]
            {
                CreateJuggernaughtProgram(squat, bench, deadlift, overheadPress, row),
                Create531(squat, bench, deadlift, overheadPress, row),
                Create531BBB(squat, bench, deadlift, overheadPress, row),
                new TemplateProgram
                {
                    Name = "StrongLifts 5x5",
                    Difficulty = Enum.GetName(typeof(TemplateDifficultyEnum), TemplateDifficultyEnum.Beginner),
                    NoOfDaysPerWeek = 3, TemplateType = "Block",
                    WeightProgressionType = Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.INCREMENTAL),
                    TemplateDays = new List<TemplateDay>
                    {
                        new TemplateDay
                        {
                            WeekNo = 1,
                            DayNo = 1, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = squat,
                                            
                                                
                                            RepSchemeFormat = "5x5", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 5}
                                                }
                                        },
                                        new TemplateExercise
                                        {
                                            ExerciseId = bench,
                                            
                                                
                                            RepSchemeFormat = "5x5", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 5}
                                                }
                                        },
                                        new TemplateExercise
                                        {
                                            ExerciseId = row,
                                            
                                            RepSchemeFormat = "5x5", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 5}
                                                }
                                        },
                                    }
                                },
                                new TemplateDay
                                {
                                    WeekNo = 1, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = squat,
                                            RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 5}
                                                }
                                        },
                                        new TemplateExercise
                                        {
                                            ExerciseId = overheadPress,
                                            RepSchemeFormat = "5x5", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 5}
                                                }
                                        },
                                        new TemplateExercise
                                        {
                                            ExerciseId = deadlift,
                                            RepSchemeFormat = "5x5", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 5}
                                                }
                                        },
                                    }
                                },
                                new TemplateDay
                                {
                                    WeekNo = 1, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = squat,
                                            
                                                
                                            RepSchemeFormat = "5x5", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 5}
                                                }
                                        },
                                        new TemplateExercise
                                        {
                                            ExerciseId = bench,
                                            RepSchemeFormat = "5x5", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 5}
                                                }
                                        },
                                        new TemplateExercise
                                        {
                                            ExerciseId = row,
                                            RepSchemeFormat = "5x5", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 0, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 5}
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
                                            RepSchemeFormat = "5x5", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 5}
                                                }
                                        },
                                        new TemplateExercise
                                        {
                                            ExerciseId = overheadPress,
                                            RepSchemeFormat = "5x5", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 5}
                                                }
                                        },
                                        new TemplateExercise
                                        {
                                            ExerciseId = deadlift,
                                            RepSchemeFormat = "1x5", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 5}
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
                                            ExerciseId = squat,
                                            RepSchemeFormat = "5x5", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 5}
                                                }
                                        },
                                        new TemplateExercise
                                        {
                                            ExerciseId = bench,
                                            
                                                
                                            RepSchemeFormat = "5x5", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 5}
                                                }
                                        },
                                        new TemplateExercise
                                        {
                                            ExerciseId = row,
                                            RepSchemeFormat = "5x5", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 5}
                                                }
                                        },
                                    }
                                },
                                new TemplateDay
                                {
                                    WeekNo = 2,
                                    DayNo = 3, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = squat,
                                            RepSchemeFormat = "1x5", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 5}
                                                }
                                        },
                                        new TemplateExercise
                                        {
                                            ExerciseId = overheadPress,
                                            
                                                
                                            RepSchemeFormat = "5x5", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 5}
                                                }
                                        },
                                        new TemplateExercise
                                        {
                                            ExerciseId = deadlift,
                                            RepSchemeFormat = "1x5", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 2, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 3, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 4, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 5, NoOfReps = 5}
                                                }
                                        }
                                    }
                        }
                    }
                },

                new TemplateProgram
                {
                    Name = "Russian Squat Routine",
                    Difficulty = Enum.GetName(typeof(TemplateDifficultyEnum), TemplateDifficultyEnum.Intermediate),
                    NoOfDaysPerWeek = 3,
                    TemplateType = "Block",
                    WeightProgressionType = Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.PERCENTAGE),
                    TemplateDays = new List<TemplateDay>
                    {
                        new TemplateDay
                        {
                            WeekNo = 1,
                                    DayNo = 1, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = squat,
                                            RepSchemeFormat = "6x2", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 3, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 4, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 5, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 6, Percentage = 80, NoOfReps = 2},
                                                }
                                        }
                                    }
                                },
                                new TemplateDay
                                {
                                    WeekNo = 1,
                                    DayNo = 2, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = squat,
                                            
                                                
                                            RepSchemeFormat = "6x3", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 80, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 3, Percentage = 80, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 4, Percentage = 80, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 5, Percentage = 80, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 6, Percentage = 80, NoOfReps = 3},
                                                }
                                        }
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
                                            
                                                
                                            RepSchemeFormat = "6x2", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 3, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 4, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 5, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 6, Percentage = 80, NoOfReps = 2},
                                                }
                                        }
                                    }
                                },
                                //Week 2
                        new TemplateDay()
                        {
                            WeekNo = 2, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = squat,
                                            
                                                
                                            RepSchemeFormat = "6x4", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 80, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 3, Percentage = 80, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 4, Percentage = 80, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 5, Percentage = 80, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 6, Percentage = 80, NoOfReps = 4},
                                                }
                                        }
                                    }
                                },
                                new TemplateDay
                                {
                                    WeekNo = 2,
                                    DayNo = 2, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = squat,
                                            
                                                
                                            RepSchemeFormat = "6x2", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 3, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 4, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 5, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 6, Percentage = 80, NoOfReps = 2},
                                                }
                                        }
                                    }
                                },
                                new TemplateDay
                                {
                                    WeekNo = 2,
                                    DayNo = 3, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = squat,
                                            
                                                
                                            RepSchemeFormat = "6x5", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 80, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 3, Percentage = 80, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 4, Percentage = 80, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 5, Percentage = 80, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 6, Percentage = 80, NoOfReps = 5},
                                                }
                                        },
                            }
                                },
                        //Week 3
                        new TemplateDay()
                        {
                            WeekNo = 3,
                                    DayNo = 1, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = squat,
                                            
                                                
                                            RepSchemeFormat = "6x2", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 3, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 4, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 5, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 6, Percentage = 80, NoOfReps = 2},
                                                }
                                        }
                                    }
                                },
                                new TemplateDay
                                {
                                    WeekNo = 3,
                                    DayNo = 2, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = squat,
                                            
                                                
                                            RepSchemeFormat = "6x6", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 80, NoOfReps = 6},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 6},
                                                    new TemplateRepScheme {SetNo = 3, Percentage = 80, NoOfReps = 6},
                                                    new TemplateRepScheme {SetNo = 4, Percentage = 80, NoOfReps = 6},
                                                    new TemplateRepScheme {SetNo = 5, Percentage = 80, NoOfReps = 6},
                                                    new TemplateRepScheme {SetNo = 6, Percentage = 80, NoOfReps = 6},
                                                }
                                        }
                                    }
                                },
                                new TemplateDay
                                {
                                    WeekNo = 3,
                                    DayNo = 3, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = squat,
                                            
                                                
                                            RepSchemeFormat = "6x2", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 3, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 4, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 5, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 6, Percentage = 80, NoOfReps = 2},
                                                }
                                        }
                                    }
                                },
                                //Week 4
                        new TemplateDay()
                        {
                            WeekNo = 4,
                                    DayNo = 1, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = squat,
                                            
                                                
                                            RepSchemeFormat = "5x5", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 85, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 85, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 4, Percentage = 85, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 5, Percentage = 85, NoOfReps = 5},
                                                }
                                        }
                                    }
                                },
                                new TemplateDay
                                {
                                    WeekNo = 4,
                                    DayNo = 2, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = squat,
                                            
                                                
                                            RepSchemeFormat = "6x2", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 3, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 4, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 5, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 6, Percentage = 80, NoOfReps = 2},
                                                }
                                        }
                                    }
                                },
                                new TemplateDay
                                {
                                    WeekNo = 4,
                                    DayNo = 3, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = squat,
                                            
                                                
                                            RepSchemeFormat = "4x4", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 90, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 90, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 4},
                                                }
                                        },
                            }
                        },
                        new TemplateDay()
                        {
                            WeekNo = 5,
                                    DayNo = 1, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = squat,
                                            
                                                
                                            RepSchemeFormat = "6x2", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 3, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 4, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 5, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 6, Percentage = 80, NoOfReps = 2},
                                                }
                                        }
                                    }
                                },
                                new TemplateDay
                                {
                                    WeekNo = 5,
                                    DayNo = 2, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = squat,
                                            
                                                
                                            RepSchemeFormat = "3x3", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 95, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 95, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 3},
                                                }
                                        }
                                    }
                                },
                                new TemplateDay
                                {
                                    WeekNo = 5,
                                    DayNo = 3, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = squat,
                                            
                                                
                                            RepSchemeFormat = "6x2", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 3, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 4, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 5, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 6, Percentage = 80, NoOfReps = 2},
                                                }
                                        },
                            }
                        },
                        new TemplateDay()
                        {
                            WeekNo = 6,
                                    DayNo = 1, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = squat,
                                            
                                                
                                            RepSchemeFormat = "2x2", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 100, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 100, NoOfReps = 2},
                                                }
                                        }
                                    }
                                },
                                new TemplateDay
                                {
                                    WeekNo = 6,
                                    DayNo = 2, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = squat,
                                            
                                                
                                            RepSchemeFormat = "6x2", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 3, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 4, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 5, Percentage = 80, NoOfReps = 2},
                                                    new TemplateRepScheme {SetNo = 6, Percentage = 80, NoOfReps = 2},
                                                }
                                        }
                                    }
                                },
                                new TemplateDay
                                {
                                    WeekNo = 6,
                                    DayNo = 3, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = squat,
                                            
                                                
                                            RepSchemeFormat = "1x1", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme
                                                        {SetNo = 1, Percentage = 105, NoOfReps = 1, AMRAP = true},
                                                }
                                        }
                                    }
                                },
                    }
                },
                new TemplateProgram
                {
                    Name = "Smolov Jr Bench Routine",
                    Difficulty = Enum.GetName(typeof(TemplateDifficultyEnum), TemplateDifficultyEnum.Advanced),
                    NoOfDaysPerWeek = 4,
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
                                            ExerciseId = bench,
                                            
                                                
                                            RepSchemeFormat = "6x6", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 70, NoOfReps = 6},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 6},
                                                    new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 6},
                                                    new TemplateRepScheme {SetNo = 4, Percentage = 70, NoOfReps = 6},
                                                    new TemplateRepScheme {SetNo = 5, Percentage = 70, NoOfReps = 6},
                                                    new TemplateRepScheme {SetNo = 6, Percentage = 70, NoOfReps = 6},
                                                }
                                        }
                                    }
                                },
                                new TemplateDay
                                {
                                    WeekNo = 1,
                                    DayNo = 2, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = bench,
                                            
                                                
                                            RepSchemeFormat = "7x5", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 75, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 3, Percentage = 75, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 4, Percentage = 75, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 5, Percentage = 75, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 6, Percentage = 75, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 7, Percentage = 75, NoOfReps = 5},
                                                }
                                        }
                                    }
                                },
                                new TemplateDay
                                {
                                    WeekNo = 1,
                                    DayNo = 3, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = bench,
                                            
                                                
                                            RepSchemeFormat = "8x4", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 80, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 3, Percentage = 80, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 4, Percentage = 80, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 5, Percentage = 80, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 6, Percentage = 80, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 7, Percentage = 80, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 8, Percentage = 80, NoOfReps = 4},
                                                }
                                        }
                                    }
                                },
                                new TemplateDay
                                {
                                    WeekNo = 1,
                                    DayNo = 4, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = bench,
                                            
                                                
                                            RepSchemeFormat = "10x3", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 85, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 85, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 4, Percentage = 85, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 5, Percentage = 85, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 6, Percentage = 85, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 7, Percentage = 85, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 8, Percentage = 85, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 9, Percentage = 85, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 10, Percentage = 85, NoOfReps = 3},
                                                }
                                        }
                                    }
                                },
                        //Week 2
                        new TemplateDay()
                        {
                            WeekNo = 2,
                            DayNo = 1, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = bench,
                                            
                                                
                                            RepSchemeFormat = "6x6", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 72, NoOfReps = 6},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 72, NoOfReps = 6},
                                                    new TemplateRepScheme {SetNo = 3, Percentage = 72, NoOfReps = 6},
                                                    new TemplateRepScheme {SetNo = 4, Percentage = 72, NoOfReps = 6},
                                                    new TemplateRepScheme {SetNo = 5, Percentage = 72, NoOfReps = 6},
                                                    new TemplateRepScheme {SetNo = 6, Percentage = 72, NoOfReps = 6},
                                                }
                                        }
                                    }
                                },
                                new TemplateDay
                                {
                                    WeekNo = 2,
                                    DayNo = 2, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = bench,
                                            
                                                
                                            RepSchemeFormat = "7x5", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 77, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 77, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 3, Percentage = 77, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 4, Percentage = 77, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 5, Percentage = 77, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 6, Percentage = 77, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 7, Percentage = 77, NoOfReps = 5},
                                                }
                                        }
                                    }
                                },
                                new TemplateDay
                                {
                                    WeekNo = 2,
                                    DayNo = 3, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = bench,
                                            
                                                
                                            RepSchemeFormat = "8x4", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 82, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 82, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 3, Percentage = 82, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 4, Percentage = 82, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 5, Percentage = 82, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 6, Percentage = 82, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 7, Percentage = 82, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 8, Percentage = 82, NoOfReps = 4},
                                                }
                                        }
                                    }
                                },
                                new TemplateDay
                                {
                                    WeekNo = 2,
                                    DayNo = 4, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = bench,
                                            
                                                
                                            RepSchemeFormat = "10x3", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 87, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 87, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 3, Percentage = 87, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 4, Percentage = 87, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 5, Percentage = 87, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 6, Percentage = 87, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 7, Percentage = 87, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 8, Percentage = 87, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 9, Percentage = 87, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 10, Percentage = 87, NoOfReps = 3},
                                                }
                                        }
                                    }
                                },
                        //Week 3
                        new TemplateDay()
                        {
                            WeekNo = 3,
                            DayNo = 1, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = bench,
                                            
                                                
                                            RepSchemeFormat = "6x6", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 74, NoOfReps = 6},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 74, NoOfReps = 6},
                                                    new TemplateRepScheme {SetNo = 3, Percentage = 74, NoOfReps = 6},
                                                    new TemplateRepScheme {SetNo = 4, Percentage = 74, NoOfReps = 6},
                                                    new TemplateRepScheme {SetNo = 5, Percentage = 74, NoOfReps = 6},
                                                    new TemplateRepScheme {SetNo = 6, Percentage = 74, NoOfReps = 6},
                                                }
                                        }
                                    }
                                },
                                new TemplateDay
                                {
                                    WeekNo = 3,
                                    DayNo = 2, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = bench,
                                            
                                                
                                            RepSchemeFormat = "7x5", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 77, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 77, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 3, Percentage = 77, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 4, Percentage = 77, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 5, Percentage = 77, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 6, Percentage = 77, NoOfReps = 5},
                                                    new TemplateRepScheme {SetNo = 7, Percentage = 77, NoOfReps = 5},
                                                }
                                        }
                                    }
                                },
                                new TemplateDay
                                {
                                    WeekNo = 3,
                                    DayNo = 3, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = bench,
                                            
                                                
                                            RepSchemeFormat = "8x4", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 84, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 84, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 3, Percentage = 84, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 4, Percentage = 84, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 5, Percentage = 84, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 6, Percentage = 84, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 7, Percentage = 84, NoOfReps = 4},
                                                    new TemplateRepScheme {SetNo = 8, Percentage = 84, NoOfReps = 4},
                                                }
                                        }
                                    }
                                },
                                new TemplateDay
                                {
                                    WeekNo = 3,
                                    DayNo = 4, TemplateExercises = new List<TemplateExercise>
                                    {
                                        new TemplateExercise
                                        {
                                            ExerciseId = bench,
                                            
                                                
                                            RepSchemeFormat = "10x3", TemplateRepSchemes =
                                                new List<TemplateRepScheme>
                                                {
                                                    new TemplateRepScheme {SetNo = 1, Percentage = 89, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 2, Percentage = 89, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 3, Percentage = 89, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 4, Percentage = 89, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 5, Percentage = 89, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 6, Percentage = 89, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 7, Percentage = 89, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 8, Percentage = 89, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 9, Percentage = 89, NoOfReps = 3},
                                                    new TemplateRepScheme {SetNo = 10, Percentage = 89, NoOfReps = 3},
                                                }
                                        },
                            }
                        },
                    }
                },
                CreateMadcows(squat, bench, deadlift, overheadPress, row),
                Create531BBB4Day(squat, bench, deadlift, overheadPress, row),
                Create5314Day(squat, bench, deadlift, overheadPress, row)
            };

            return templates;
        }

        public static TemplateProgram CreateMadcows(int squat, int bench, int deadlift, int press, int row)
        {
            return new TemplateProgram
            {
                Name = "Madcow 5x5",
                Difficulty = Enum.GetName(typeof(TemplateDifficultyEnum), TemplateDifficultyEnum.Intermediate),
                NoOfDaysPerWeek = 3,
                TemplateType = "Block",
                WeightProgressionType = Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.INCREMENTAL),
                TemplateDays = new List<TemplateDay>
                {
                    new TemplateDay
                    {
                        WeekNo = 1,
                        DayNo = 1,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 95, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 95, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = row,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 95, NoOfReps = 5}
                                }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 1,
                        DayNo = 2,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 95, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 95, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "4x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 95, NoOfReps = 5},
                                }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 1,
                        DayNo = 3,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 95, NoOfReps = 3}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 95, NoOfReps = 3}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = row,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 95, NoOfReps = 3}
                                }
                            },
                        }
                    },

                    new TemplateDay()
                    {
                        WeekNo = 2,
                        DayNo = 1,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 95, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 95, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = row,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 95, NoOfReps = 5}
                                }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 2,
                        DayNo = 2,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 95, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 95, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "4x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 95, NoOfReps = 5},
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
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 100, NoOfReps = 3}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 100, NoOfReps = 3}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = row,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 100, NoOfReps = 3}
                                }
                            },
                        }
                    },
                    //Week 3
                    new TemplateDay()
                    {
                        WeekNo = 3,
                        DayNo = 1,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 100, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 100, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = row,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 100, NoOfReps = 5}
                                }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 3,
                        DayNo = 2,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 100, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 100, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "4x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 100, NoOfReps = 5},
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
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 100, NoOfReps = 3}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 100, NoOfReps = 3}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = row,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 100, NoOfReps = 3}
                                }
                            },
                        }
                    },
                    //Week 4
                    new TemplateDay()
                    {
                        WeekNo = 4,
                        DayNo = 1,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 100, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 100, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = row,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 100, NoOfReps = 5}
                                }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 4,
                        DayNo = 2,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 100, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 100, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "4x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 100, NoOfReps = 5},
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
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 105, NoOfReps = 3}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 105, NoOfReps = 3}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = row,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 105, NoOfReps = 3}
                                }
                            },
                        }
                    },
                    new TemplateDay()
                    {
                        WeekNo = 5,
                        DayNo = 1,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 55, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 80, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 105, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 55, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 80, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 105, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = row,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 55, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 80, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 105, NoOfReps = 5}
                                }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 5,
                        DayNo = 2,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 55, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 80, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 105, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 55, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 80, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 105, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "4x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 105, NoOfReps = 5},
                                }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 5,
                        DayNo = 3,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 55, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 80, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 105, NoOfReps = 3}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 55, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 80, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 110, NoOfReps = 3}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = row,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 55, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 80, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 110, NoOfReps = 3}
                                }
                            },
                        }
                    },
                    new TemplateDay()
                    {
                        WeekNo = 6,
                        DayNo = 1,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 55, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 95, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 110, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 55, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 95, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 110, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = row,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 55, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 95, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 110, NoOfReps = 5}
                                }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 6,
                        DayNo = 2,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 55, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 95, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 110, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 55, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 95, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 110, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "4x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 100, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 115, NoOfReps = 5},
                                }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 6,
                        DayNo = 3,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 55, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 95, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 115, NoOfReps = 3}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 55, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 95, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 115, NoOfReps = 3}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = row,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 55, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 95, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 115, NoOfReps = 3}
                                }
                            },
                        }
                    },
                    //week 7
                    new TemplateDay()
                    {
                        WeekNo = 7,
                        DayNo = 1,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 100, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 115, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 100, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 115, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = row,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 100, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 115, NoOfReps = 5}
                                }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 7,
                        DayNo = 2,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 100, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 115, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 100, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 115, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "4x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 100, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 115, NoOfReps = 5},
                                }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 7,
                        DayNo = 3,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 100, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 115, NoOfReps = 3}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 100, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 115, NoOfReps = 3}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = row,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 100, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 115, NoOfReps = 3}
                                }
                            },
                        }
                    },
                    new TemplateDay()
                    {
                        WeekNo = 8,
                        DayNo = 1,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 100, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 115, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 100, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 115, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = row,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 100, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 115, NoOfReps = 5}
                                }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 8,
                        DayNo = 2,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 100, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 115, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 100, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 115, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "4x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 100, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 115, NoOfReps = 5},
                                }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 8,
                        DayNo = 3,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 100, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 120, NoOfReps = 3}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 100, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 120, NoOfReps = 3}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = row,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 100, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 120, NoOfReps = 3}
                                }
                            },
                        }
                    },
                    new TemplateDay()
                    {
                        WeekNo = 9,
                        DayNo = 1,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 100, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 115, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 100, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 115, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = row,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 100, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 115, NoOfReps = 5}
                                }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 9,
                        DayNo = 2,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 100, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 115, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 100, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 115, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "4x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 105, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 120, NoOfReps = 5},
                                }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 9,
                        DayNo = 3,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 100, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 120, NoOfReps = 3}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 100, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 120, NoOfReps = 3}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = row,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 100, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 120, NoOfReps = 3}
                                }
                            },
                        }
                    },
                    new TemplateDay()
                    {
                        WeekNo = 10,
                        DayNo = 1,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 105, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 120, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 105, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 120, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = row,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 105, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 120, NoOfReps = 5}
                                }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 10,
                        DayNo = 2,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 105, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 120, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 105, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 120, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "4x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 105, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 120, NoOfReps = 5},
                                }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 10,
                        DayNo = 3,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 105, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 120, NoOfReps = 3}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 105, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 120, NoOfReps = 3}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = row,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 105, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 120, NoOfReps = 3}
                                }
                            },
                        }
                    },
                    new TemplateDay()
                    {
                        WeekNo = 11,
                        DayNo = 1,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 105, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 120, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 105, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 120, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = row,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 105, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 120, NoOfReps = 5}
                                }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 11,
                        DayNo = 2,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 105, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 120, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 105, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 120, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "4x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 105, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 120, NoOfReps = 5},
                                }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 11,
                        DayNo = 3,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 105, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 125, NoOfReps = 3}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 105, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 125, NoOfReps = 3}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = row,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 105, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 125, NoOfReps = 3}
                                }
                            },
                        }
                    },
                    new TemplateDay()
                    {
                        WeekNo = 12,
                        DayNo = 1,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 110, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 125, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 110, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 125, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = row,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 110, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 125, NoOfReps = 5}
                                }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 12,
                        DayNo = 2,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 110, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 125, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "5x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 110, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 125, NoOfReps = 5}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "4x5",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 80, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 95, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 110, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 125, NoOfReps = 5},
                                }
                            },
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 12,
                        DayNo = 3,
                        TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 110, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 130, NoOfReps = 3}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 110, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 130, NoOfReps = 3}
                                }
                            },
                            new TemplateExercise
                            {
                                ExerciseId = row,
                                 
                                RepSchemeFormat = "4x5, 1x3",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 110, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 130, NoOfReps = 3}
                                }
                            },
                        }
                    }
                }
            };
        }

        public static TemplateProgram Create531BBB(int squat, int bench, int deadlift, int press, int row)
        {
            return new TemplateProgram
            {
                Name = "5/3/1 Boring But Big (3 Day)",
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
                                 
                                RepSchemeFormat = "3x5", HasBackOffSets = true, BackOffSetFormat = "5x10",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                    new TemplateRepScheme
                                        {SetNo = 4, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 5, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 6, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 7, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 8, Percentage = 50, NoOfReps = 10, IsBackOffSet = true}
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 1,
                        DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "3x5", HasBackOffSets = true, BackOffSetFormat = "5x10",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                    new TemplateRepScheme
                                        {SetNo = 4, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 5, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 6, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 7, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 8, Percentage = 50, NoOfReps = 10, IsBackOffSet = true}
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 1,
                        DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "3x5", HasBackOffSets = true, BackOffSetFormat = "5x10",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                    new TemplateRepScheme
                                        {SetNo = 4, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 5, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 6, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 7, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 8, Percentage = 50, NoOfReps = 8, IsBackOffSet = true}
                                }
                            }
                        }
                    },
                    //Week 2
                    new TemplateDay
                    {
                        WeekNo = 2,
                        DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "3x3", HasBackOffSets = true, BackOffSetFormat = "5x10",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 70, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                    new TemplateRepScheme
                                        {SetNo = 4, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 5, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 6, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 7, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 8, Percentage = 50, NoOfReps = 10, IsBackOffSet = true}
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 2,
                        DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "3x3", HasBackOffSets = true, BackOffSetFormat = "5x10",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 70, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                    new TemplateRepScheme
                                        {SetNo = 4, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 5, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 6, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 7, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 8, Percentage = 50, NoOfReps = 10, IsBackOffSet = true}
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 2,
                        DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "3x3", HasBackOffSets = true, BackOffSetFormat = "5x10",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 70, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                    new TemplateRepScheme
                                        {SetNo = 4, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 5, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 6, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 7, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 8, Percentage = 50, NoOfReps = 8, IsBackOffSet = true}
                                }
                            }
                        }
                    },
                    //Week 3
                    new TemplateDay()
                    {
                        WeekNo = 3,
                        DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x1+", HasBackOffSets = true,
                                BackOffSetFormat = "5x10", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 85, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                    new TemplateRepScheme
                                        {SetNo = 4, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 5, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 6, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 7, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 8, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 3,
                        DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x1+", HasBackOffSets = true,
                                BackOffSetFormat = "5x10", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 85, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                    new TemplateRepScheme
                                        {SetNo = 4, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 5, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 6, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 7, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 8, Percentage = 50, NoOfReps = 10, IsBackOffSet = true}
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 3,
                        DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x1+", HasBackOffSets = true,
                                BackOffSetFormat = "5x10", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 85, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                    new TemplateRepScheme
                                        {SetNo = 4, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 5, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 6, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 7, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 8, Percentage = 50, NoOfReps = 8, IsBackOffSet = true}
                                }
                            }
                        }
                    },

                    //Week 4
                    new TemplateDay
                    {
                        WeekNo = 4,
                        DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 40, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 60, NoOfReps = 5}
                                }
                            }
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
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 40, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 60, NoOfReps = 5}
                                }
                            }
                        }
                    },

                    new TemplateDay
                    {
                        WeekNo = 4,
                        DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 40, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 60, NoOfReps = 5}
                                }
                            }
                        }
                    }
                }
            };
        }



        public static TemplateProgram Create531BBB4Day(int squat, int bench, int deadlift, int press, int row)
        {
            return new TemplateProgram
            {
                Name = "5/3/1 Boring But Big (4 Day)",
                Difficulty = Enum.GetName(typeof(TemplateDifficultyEnum), TemplateDifficultyEnum.Beginner),
                NoOfDaysPerWeek = 4,
                TemplateType = "Block",
                WeightProgressionType = Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.PERCENTAGE),
                TemplateDays = new List<TemplateDay>
                {
                    new TemplateDay()
                    {
                        WeekNo = 1, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "3x5", HasBackOffSets = true, BackOffSetFormat = "5x10",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                    new TemplateRepScheme
                                        {SetNo = 4, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 5, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 6, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 7, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 8, Percentage = 50, NoOfReps = 10, IsBackOffSet = true}
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 1, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "3x5", HasBackOffSets = true, BackOffSetFormat = "5x10",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                    new TemplateRepScheme
                                        {SetNo = 4, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 5, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 6, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 7, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 8, Percentage = 50, NoOfReps = 10, IsBackOffSet = true}
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 1, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "3x5", HasBackOffSets = true, BackOffSetFormat = "5x10",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                    new TemplateRepScheme
                                        {SetNo = 4, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 5, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 6, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 7, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 8, Percentage = 50, NoOfReps = 8, IsBackOffSet = true}
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 1, DayNo = 4, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "3x5", HasBackOffSets = true, BackOffSetFormat = "5x10",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                    new TemplateRepScheme
                                        {SetNo = 4, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 5, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 6, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 7, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 8, Percentage = 50, NoOfReps = 8, IsBackOffSet = true}
                                }
                            }
                        }
                    },

                    //Week 2
                    new TemplateDay()
                    {
                        WeekNo = 2, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "3x3", HasBackOffSets = true, BackOffSetFormat = "5x10",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 70, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                    new TemplateRepScheme
                                        {SetNo = 4, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 5, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 6, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 7, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 8, Percentage = 50, NoOfReps = 10, IsBackOffSet = true}
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 2, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "3x3", HasBackOffSets = true, BackOffSetFormat = "5x10",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 70, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                    new TemplateRepScheme
                                        {SetNo = 4, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 5, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 6, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 7, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 8, Percentage = 50, NoOfReps = 10, IsBackOffSet = true}
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 2, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "3x3", HasBackOffSets = true, BackOffSetFormat = "5x10",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 70, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                    new TemplateRepScheme
                                        {SetNo = 4, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 5, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 6, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 7, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 8, Percentage = 50, NoOfReps = 8, IsBackOffSet = true}
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 2, DayNo = 4, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "3x3", HasBackOffSets = true, BackOffSetFormat = "5x10",
                                TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 70, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                    new TemplateRepScheme
                                        {SetNo = 4, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 5, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 6, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 7, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 8, Percentage = 50, NoOfReps = 8, IsBackOffSet = true}
                                }
                            }
                        }
                    },
                    //Week 3
                    new TemplateDay()
                    {
                        WeekNo = 3, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x1+", HasBackOffSets = true,
                                BackOffSetFormat = "5x10", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 85, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                    new TemplateRepScheme
                                        {SetNo = 4, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 5, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 6, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 7, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 8, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 3, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x1+", HasBackOffSets = true,
                                BackOffSetFormat = "5x10", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 85, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                    new TemplateRepScheme
                                        {SetNo = 4, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 5, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 6, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 7, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 8, Percentage = 50, NoOfReps = 10, IsBackOffSet = true}
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 3, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x1+", HasBackOffSets = true,
                                BackOffSetFormat = "5x10", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 85, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                    new TemplateRepScheme
                                        {SetNo = 4, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 5, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 6, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 7, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 8, Percentage = 50, NoOfReps = 8, IsBackOffSet = true}
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 3, DayNo = 4, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x1+", HasBackOffSets = true,
                                BackOffSetFormat = "5x10", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 85, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                    new TemplateRepScheme
                                        {SetNo = 4, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 5, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 6, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 7, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                    new TemplateRepScheme
                                        {SetNo = 8, Percentage = 50, NoOfReps = 8, IsBackOffSet = true}
                                }
                            }
                        }
                    },
                    //Week 4
                    new TemplateDay()
                    {
                        WeekNo = 4, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 40, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 60, NoOfReps = 5}
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 4, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 40, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 60, NoOfReps = 5}
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 4, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = row,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 40, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 60, NoOfReps = 5}
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 4, DayNo = 4, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 40, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 60, NoOfReps = 5}
                                }
                            }
                        }
                    }
                }
            };
        }

        public static TemplateProgram Create531(int squat, int bench, int deadlift, int press, int row)
        {
            return new TemplateProgram
            {
                Name = "5/3/1 (3 Day)",
                Difficulty = Enum.GetName(typeof(TemplateDifficultyEnum), TemplateDifficultyEnum.Beginner),
                NoOfDaysPerWeek = 3,
                TemplateType = "Block",
                WeightProgressionType = Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.PERCENTAGE),
                TemplateDays = new List<TemplateDay>
                {
                    new TemplateDay()
                    {
                        WeekNo = 1, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 1, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 1, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                }
                            }
                        }
                    },
                    //Week 2
                    new TemplateDay()
                    {
                        WeekNo = 2, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "3x3", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 70, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 2, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "3x3", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 70, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 2, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "3x3", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 70, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                }
                            }
                        }
                    },
                    //Week 3
                    new TemplateDay()
                    {
                        WeekNo = 3, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x1", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 75, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 85, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 3, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x1", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 75, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 85, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 3, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x1", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 75, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 85, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true}
                                    }
                            }
                        }
                    },
                    //Week 4
                    new TemplateDay()
                    {
                        WeekNo = 4, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 40, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 60, NoOfReps = 5}
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 4, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 40, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 60, NoOfReps = 5}
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 4, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 40, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 60, NoOfReps = 5}
                                }
                            }
                        }
                    }
                }
            };
        }

        public static TemplateProgram Create5314Day(int squat, int bench, int deadlift, int press, int row)
        {
            return new TemplateProgram
            {
                Name = "5/3/1 (4 Day)",
                Difficulty = Enum.GetName(typeof(TemplateDifficultyEnum), TemplateDifficultyEnum.Beginner),
                NoOfDaysPerWeek = 4,
                TemplateType = "Block",
                WeightProgressionType = Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.PERCENTAGE),
                TemplateDays = new List<TemplateDay>
                {
                    new TemplateDay()
                    {
                        WeekNo = 1, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 1, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 1, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 1, DayNo = 4, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                }
                            }
                        }
                    },
                    //Week 2
                    new TemplateDay()
                    {
                        WeekNo = 2, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "3x3", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 70, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 2, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "3x3", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 70, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 2, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "3x3", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 70, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 2, DayNo = 4, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "3x3", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 70, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                }
                            }
                        }

                    },
                    //Week 3
                    new TemplateDay()
                    {
                        WeekNo = 3, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x1", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 75, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 85, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 3, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x1", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 75, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 85, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 3, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x1", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 75, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 85, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true}
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 3, DayNo = 4, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x1", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 75, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 85, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true}
                                    }
                            },
                        }
                    },
                    //Week 4
                    new TemplateDay()
                    {
                        WeekNo = 4, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 40, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 60, NoOfReps = 5}
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                       WeekNo = 4, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 40, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 60, NoOfReps = 5}
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 4, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 40, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 60, NoOfReps = 5}
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 4, DayNo = 4, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 40, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 60, NoOfReps = 5}
                                }
                            }
                        }
                    }
                }
            };
        }

        public static TemplateProgram CreateJuggernaughtProgram(int squat, int bench, int deadlift, int press, int row)
        {
            return new TemplateProgram
            {
                Name = "Juggernaught Method",
                Difficulty = Enum.GetName(typeof(TemplateDifficultyEnum), TemplateDifficultyEnum.Beginner),
                NoOfDaysPerWeek = 4,
                TemplateType = "Block",
                WeightProgressionType = Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.PERCENTAGE),
                TemplateDays = new List<TemplateDay>
                {
                    new TemplateDay()
                    {
                        WeekNo = 1, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                
                                RepSchemeFormat = "5x10", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 10},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 60, NoOfReps = 10},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 60, NoOfReps = 10},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 60, NoOfReps = 10},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 60, NoOfReps = 10, AMRAP = true},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 1, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                
                                RepSchemeFormat = "5x10", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 10},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 60, NoOfReps = 10},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 60, NoOfReps = 10},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 60, NoOfReps = 10},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 60, NoOfReps = 10, AMRAP = true},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 1, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                
                                RepSchemeFormat = "5x10", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 10},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 60, NoOfReps = 10},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 60, NoOfReps = 10},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 60, NoOfReps = 10},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 60, NoOfReps = 10, AMRAP = true},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 1, DayNo = 4, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 10},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 60, NoOfReps = 10},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 60, NoOfReps = 10},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 60, NoOfReps = 10},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 60, NoOfReps = 10, AMRAP = true},
                                }
                            }
                        }
                    },
                    //Week 2
                    new TemplateDay()
                    {
                        WeekNo = 2, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "2x5, 3x10", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 55, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 10},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 70, NoOfReps = 10},
                                        new TemplateRepScheme {SetNo = 5, Percentage = 70, NoOfReps = 10, AMRAP = true},
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 2, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "2x5, 3x10", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 55, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 10},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 70, NoOfReps = 10},
                                        new TemplateRepScheme {SetNo = 5, Percentage = 70, NoOfReps = 10, AMRAP = true},
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 2, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "2x5, 3x10", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 55, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 10},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 70, NoOfReps = 10},
                                        new TemplateRepScheme {SetNo = 5, Percentage = 70, NoOfReps = 10, AMRAP = true},
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 2, DayNo = 4, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "2x5, 3x10", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 55, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 10},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 70, NoOfReps = 10},
                                        new TemplateRepScheme {SetNo = 5, Percentage = 70, NoOfReps = 10, AMRAP = true},
                                    }
                            },
                        }
                    },
                    //Week 3
                    new TemplateDay()
                    {
                        WeekNo = 3, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x1, 1x1+", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 60, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 10},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 75, NoOfReps = 10, AMRAP = true},
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 3, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x1, 1x1+", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 60, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 10},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 75, NoOfReps = 10, AMRAP = true},
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 3, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x1, 1x1+", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 60, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 10},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 75, NoOfReps = 10, AMRAP = true},
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 3, DayNo = 4, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x1, 1x1+", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 60, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 10},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 75, NoOfReps = 10, AMRAP = true},
                                    }
                            },
                        }
                    },
                    //Week 4
                    new TemplateDay()
                    {
                        WeekNo = 4, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 40, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 60, NoOfReps = 5},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 4, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 40, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 60, NoOfReps = 5},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 4, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 40, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 60, NoOfReps = 5},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 4, DayNo = 4, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 40, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 60, NoOfReps = 5},
                                }
                            },
                        }
                    },
                    //Week 5
                    new TemplateDay()
                    {
                        WeekNo = 5, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                
                                RepSchemeFormat = "5x8", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 75, NoOfReps = 8},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 8},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 75, NoOfReps = 8},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 75, NoOfReps = 8},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 75, NoOfReps = 8, AMRAP = true},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 5, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                
                                RepSchemeFormat = "5x8", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 85, NoOfReps = 8},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 85, NoOfReps = 8},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 8},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 85, NoOfReps = 8},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 85, NoOfReps = 8, AMRAP = true},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 5, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                
                                RepSchemeFormat = "5x8", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 70, NoOfReps = 8},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 8},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 8},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 70, NoOfReps = 8},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 70, NoOfReps = 8, AMRAP = true},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 5, DayNo = 4, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                
                                RepSchemeFormat = "5x8", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 75, NoOfReps = 8},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 8},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 75, NoOfReps = 8},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 75, NoOfReps = 8},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 75, NoOfReps = 8, AMRAP = true},
                                }
                            },
                        }
                    },
                    //Week 6
                    new TemplateDay()
                    {
                        WeekNo = 6, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "2x3, 3x8", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 70, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 8},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 85, NoOfReps = 8},
                                        new TemplateRepScheme {SetNo = 5, Percentage = 85, NoOfReps = 8, AMRAP = true},
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 6, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "2x3, 3x8", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 75, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 85, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 8},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 95, NoOfReps = 8},
                                        new TemplateRepScheme {SetNo = 5, Percentage = 95, NoOfReps = 8, AMRAP = true},
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 6, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "2x3, 3x8", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 80, NoOfReps = 8},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 80, NoOfReps = 8},
                                        new TemplateRepScheme {SetNo = 5, Percentage = 80, NoOfReps = 8, AMRAP = true},
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 6, DayNo = 4, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "2x3, 3x8", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 70, NoOfReps = 8},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 8},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 80, NoOfReps = 8},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 80, NoOfReps = 8},
                                        new TemplateRepScheme {SetNo = 5, Percentage = 80, NoOfReps = 8, AMRAP = true},
                                    }
                            },
                        }
                    },

                    //Week 7
                    new TemplateDay()
                    {
                        WeekNo = 7, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x2, 1x1, 1x1+", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 2},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 5, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 7, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x2, 1x1, 1x1+", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 2},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 95, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 5, Percentage = 100, NoOfReps = 1, AMRAP = true},
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 7, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x2, 1x1, 1x1+", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 55, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 75, NoOfReps = 2},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 80, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 5, Percentage = 85, NoOfReps = 1, AMRAP = true},
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 7, DayNo = 4, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x2, 1x1, 1x1+", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 55, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 80, NoOfReps = 2},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 85, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 5, Percentage = 90, NoOfReps = 1, AMRAP = true},
                                    }
                            },
                        }
                    },

                    //Week 8
                    new TemplateDay()
                    {
                        WeekNo = 8, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 5},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 8, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 75, NoOfReps = 5},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 8, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 45, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 55, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 65, NoOfReps = 5},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 8, DayNo = 4, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 45, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 55, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 5},
                                }
                            },
                        }
                    },

                    //Week 9
                    new TemplateDay()
                    {
                        WeekNo = 9, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "6x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 6, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 9, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                
                                RepSchemeFormat = "6x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 95, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 95, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 95, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 95, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 6, Percentage = 95, NoOfReps = 5, AMRAP = true},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 9, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                
                                RepSchemeFormat = "6x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 80, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 80, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 80, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 80, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 6, Percentage = 80, NoOfReps = 5, AMRAP = true},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 9, DayNo = 4, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                
                                RepSchemeFormat = "6x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 85, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 6, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                }
                            },
                        }
                    },
                    //Week 10
                    new TemplateDay()
                    {
                        WeekNo = 10, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "2x2, 4x5", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 80, NoOfReps = 2},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 90, NoOfReps = 2},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 95, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 5, Percentage = 95, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 6, Percentage = 95, NoOfReps = 5, AMRAP = true},
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 10, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "2x2, 4x5", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 90, NoOfReps = 2},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 100, NoOfReps = 2},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 105, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 105, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 5, Percentage = 105, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 6, Percentage = 105, NoOfReps = 5, AMRAP = true},
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 10, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "2x2, 4x5", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 75, NoOfReps = 2},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 2},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 5, Percentage = 90, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 6, Percentage = 90, NoOfReps = 5, AMRAP = true},
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 10, DayNo = 4, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                  
                                RepSchemeFormat = "2x2, 4x5", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 80, NoOfReps = 2},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 90, NoOfReps = 2},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 95, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 5, Percentage = 95, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 6, Percentage = 95, NoOfReps = 5, AMRAP = true},
                                    }
                            },
                        }
                    },
                    //Week 11
                    new TemplateDay()
                    {
                        WeekNo = 11, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x2, 1x1, 1x1, 1x1+", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 2},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 5, Percentage = 100, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 6, Percentage = 105, NoOfReps = 1, AMRAP = true},
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 11, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x2, 1x1, 1x1, 1x1+", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 70, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 85, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 2},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 105, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 5, Percentage = 110, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 6, Percentage = 115, NoOfReps = 1, AMRAP = true},
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 11, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x2, 1x1, 1x1, 1x1+", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 55, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 80, NoOfReps = 2},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 85, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 5, Percentage = 90, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 6, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 11, DayNo = 4, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x2, 1x1, 1x1, 1x1+", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 2},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 5, Percentage = 100, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 6, Percentage = 105, NoOfReps = 1, AMRAP = true},
                                    }
                            },
                        }
                    },
                    //Week 12
                    new TemplateDay()
                    {
                        WeekNo = 12, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 75, NoOfReps = 5},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 12, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 55, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 5},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 12, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 45, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 55, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 5},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 12, DayNo = 4, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 75, NoOfReps = 5},
                                }
                            },
                        }
                    },
                    //Week 13
                    new TemplateDay()
                    {
                        WeekNo = 13, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                
                                RepSchemeFormat = "7x3", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 95, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 95, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 95, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 95, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 6, Percentage = 95, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 7, Percentage = 95, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 8, Percentage = 95, NoOfReps = 3, AMRAP = true},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 13, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                
                                RepSchemeFormat = "7x3", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 110, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 110, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 110, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 110, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 110, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 6, Percentage = 110, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 7, Percentage = 110, NoOfReps = 3, AMRAP = true},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 13, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                
                                RepSchemeFormat = "7x3", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 90, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 90, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 90, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 6, Percentage = 90, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 7, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 13, DayNo = 4, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                
                                RepSchemeFormat = "7x3", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 100, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 100, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 100, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 4, Percentage = 100, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 5, Percentage = 100, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 6, Percentage = 100, NoOfReps = 3},
                                    new TemplateRepScheme {SetNo = 7, Percentage = 100, NoOfReps = 3, AMRAP = true},
                                }
                            },
                        }
                    },
                    //Week 14
                    new TemplateDay()
                    {
                        WeekNo = 14, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "2x1, 5x3", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 90, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 100, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 105, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 105, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 5, Percentage = 105, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 6, Percentage = 105, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 7, Percentage = 105, NoOfReps = 3, AMRAP = true},
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 14, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "2x1, 5x3", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 105, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 115, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 120, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 120, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 5, Percentage = 120, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 6, Percentage = 120, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 7, Percentage = 120, NoOfReps = 3, AMRAP = true},
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 14, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "2x1, 5x3", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 85, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 90, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 95, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 5, Percentage = 95, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 6, Percentage = 95, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 7, Percentage = 95, NoOfReps = 3, AMRAP = true},
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 14, DayNo = 4, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "2x1, 5x3", TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 95, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 105, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 110, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 110, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 5, Percentage = 110, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 6, Percentage = 110, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 7, Percentage = 110, NoOfReps = 3, AMRAP = true},
                                    }
                            },
                        }
                    },
                    //Week 15
                    new TemplateDay()
                    {
                        WeekNo = 15, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x2, 1x1, 1x1, 1x1, 1x1+",
                                TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 2},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 95, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 5, Percentage = 100, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 6, Percentage = 110, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 7, Percentage = 115, NoOfReps = 1, AMRAP = true},
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 15, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x2, 1x1, 1x1, 1x1, 1x1+",
                                TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 75, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 90, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 105, NoOfReps = 2},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 110, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 5, Percentage = 120, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 6, Percentage = 125, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 7, Percentage = 135, NoOfReps = 1, AMRAP = true},
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 15, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                  
                                RepSchemeFormat = "1x5, 1x3, 1x2, 1x1, 1x1, 1x1, 1x1+",
                                TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 70, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 85, NoOfReps = 2},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 90, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 5, Percentage = 95, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 6, Percentage = 100, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 7, Percentage = 105, NoOfReps = 1, AMRAP = true},
                                    }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 15, DayNo = 4, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "1x5, 1x3, 1x2, 1x1, 1x1, 1x1, 1x1+",
                                TemplateRepSchemes =
                                    new List<TemplateRepScheme>
                                    {
                                        new TemplateRepScheme {SetNo = 1, Percentage = 65, NoOfReps = 5},
                                        new TemplateRepScheme {SetNo = 2, Percentage = 80, NoOfReps = 3},
                                        new TemplateRepScheme {SetNo = 3, Percentage = 95, NoOfReps = 2},
                                        new TemplateRepScheme {SetNo = 4, Percentage = 100, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 5, Percentage = 105, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 6, Percentage = 115, NoOfReps = 1},
                                        new TemplateRepScheme {SetNo = 7, Percentage = 120, NoOfReps = 1, AMRAP = true},
                                    }
                            },
                        }
                    },
                    //Week 16
                    new TemplateDay()
                    {
                        WeekNo = 16, DayNo = 1, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = bench,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 75, NoOfReps = 5},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 16, DayNo = 2, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = squat,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 75, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 90, NoOfReps = 5},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 16, DayNo = 3, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = press,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 50, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 60, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 70, NoOfReps = 5},
                                }
                            }
                        }
                    },
                    new TemplateDay
                    {
                        WeekNo = 16, DayNo = 4, TemplateExercises = new List<TemplateExercise>
                        {
                            new TemplateExercise
                            {
                                ExerciseId = deadlift,
                                 
                                RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme>
                                {
                                    new TemplateRepScheme {SetNo = 1, Percentage = 55, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 2, Percentage = 65, NoOfReps = 5},
                                    new TemplateRepScheme {SetNo = 3, Percentage = 80, NoOfReps = 5},
                                }
                            }
                        }
                    },
                }
            };
        }
    }
}
