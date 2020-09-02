using System;
using System.Collections.Generic;
using PowerLifting.Data.Entities.Templates;

namespace PowerLifting.Data.SeedData.TemplatePrograms
{
    public static class TemplateProgramSeed
    {
        public static TemplateProgram[] CreateTemplatePrograms()
        {
            var templates = new TemplateProgram[]
            {
                JuggernaughtMethod.Create(),
                    Create531(),
                    Create531BBB(),
                    new TemplateProgram { TemplateProgramId = 3, Name="StrongLifts 5x5", Difficulty=Enum.GetName(typeof(TemplateDifficultyEnum), TemplateDifficultyEnum.Beginner), NoOfWeeks = 12,
                        NoOfDaysPerWeek = 3, TemplateType="Block", WeightProgressionType=Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.INCREMENTAL),
                        TemplateWeeks = new List<TemplateWeek> {
                            new TemplateWeek { WeekNo = 1,TemplateDays = new List<TemplateDay> {
                                   new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                       new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                        new TemplateExercise { ExerciseId = 24, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                    } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                       new TemplateExercise { ExerciseId = 4, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                        new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                    } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1,RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                       new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                        new TemplateExercise { ExerciseId = 24, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                       new TemplateExercise { ExerciseId = 4, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                        new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 5, RepSchemeFormat = "1x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                    } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                       new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                        new TemplateExercise { ExerciseId = 24, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                    } },
                                     new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 5, RepSchemeFormat = "1x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                       new TemplateExercise { ExerciseId = 4, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                        new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 5, RepSchemeFormat = "1x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } }
                                    } } } }
                            } },

                        new TemplateProgram {TemplateProgramId = 4, Name="Russian Squat Routine", Difficulty=Enum.GetName(typeof(TemplateDifficultyEnum), TemplateDifficultyEnum.Intermediate), NoOfWeeks = 6, NoOfDaysPerWeek = 3,
                        TemplateType="Block", WeightProgressionType=Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.PERCENTAGE),
                        TemplateWeeks = new List<TemplateWeek> {
                            new TemplateWeek { WeekNo = 1,TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 6, RepSchemeFormat = "6x2", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 80, NoOfReps = 2},
                                          }
                                        }
                                    } },
                                     new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 6, RepSchemeFormat = "6x3", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 80, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 80, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 80, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 80, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 80, NoOfReps = 3},
                                          }
                                        }
                                    } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 6, RepSchemeFormat = "6x2", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 80, NoOfReps = 2},
                                          }
                                        }
                                    } },
                                }
                            },
                            //Week 2
                            new TemplateWeek { WeekNo = 2, TemplateDays = new List<TemplateDay> {
                                     new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 6, RepSchemeFormat = "6x4", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 80, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 80, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 80, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 80, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 80, NoOfReps = 4},
                                          }
                                        }
                                    } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 6, RepSchemeFormat = "6x2", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 80, NoOfReps = 2},
                                          }
                                        }
                                    } },
                                     new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 6, RepSchemeFormat = "6x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 80, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 80, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 80, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 80, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 80, NoOfReps = 5},
                                          }
                                        }
                                    } },
                                }
                            },
                             //Week 3
                            new TemplateWeek { WeekNo = 3, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 6, RepSchemeFormat = "6x2", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 80, NoOfReps = 2},
                                          }
                                        }
                                    } },
                                     new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 6, RepSchemeFormat = "6x6", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 80, NoOfReps = 6},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 6},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 80, NoOfReps = 6},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 80, NoOfReps = 6},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 80, NoOfReps = 6},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 80, NoOfReps = 6},
                                          }
                                        }
                                    } },
                                      new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 6, RepSchemeFormat = "6x2", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 80, NoOfReps = 2},
                                          }
                                        }
                                    } },
                                }
                            },
                            //Week 4
                            new TemplateWeek { WeekNo = 4, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 85, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 85, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 85, NoOfReps = 5},
                                          }
                                        }
                                    } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 6, RepSchemeFormat = "6x2", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 80, NoOfReps = 2},
                                          }
                                        }
                                    } },
                                      new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 4, RepSchemeFormat = "4x4", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 90, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 90, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 4},
                                          }
                                        }
                                    } },
                                }
                            },
                            new TemplateWeek { WeekNo = 5, TemplateDays = new List<TemplateDay> {
                                   new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 6, RepSchemeFormat = "6x2", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 80, NoOfReps = 2},
                                          }
                                        }
                                    } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 6, RepSchemeFormat = "3x3", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 95, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 95, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 3},
                                          }
                                        }
                                    } },
                                     new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 6, RepSchemeFormat = "6x2", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 80, NoOfReps = 2},
                                          }
                                        }
                                    } },
                                }
                            },
                            new TemplateWeek { WeekNo = 6, TemplateDays = new List<TemplateDay> {
                                   new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 2, RepSchemeFormat = "2x2", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 100, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 100, NoOfReps = 2},
                                          }
                                        }
                                    } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 6, RepSchemeFormat = "6x2", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 80, NoOfReps = 2},
                                          }
                                        }
                                    } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 1, RepSchemeFormat = "1x1", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 105, NoOfReps = 1, AMRAP = true},
                                          }
                                        }
                                    } },
                                }
                            }

                    } },
                        new TemplateProgram { TemplateProgramId = 5, Name="Smolov Jr Bench Routine", Difficulty=Enum.GetName(typeof(TemplateDifficultyEnum), TemplateDifficultyEnum.Advanced), NoOfWeeks = 3, NoOfDaysPerWeek = 4,
                        TemplateType="Block", WeightProgressionType=Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.PERCENTAGE),
                        TemplateWeeks = new List<TemplateWeek> {
                            new TemplateWeek { WeekNo = 1,TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                          NoOfSets = 6, RepSchemeFormat = "6x6", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 70, NoOfReps = 6},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 6},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 6},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 70, NoOfReps = 6},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 70, NoOfReps = 6},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 70, NoOfReps = 6},
                                          }
                                        }
                                    } },
                                     new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                          NoOfSets = 7, RepSchemeFormat = "7x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 75, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 75, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 75, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 75, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 7, Percentage = 75, NoOfReps = 5},
                                          }
                                        }
                                    } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                          NoOfSets = 8, RepSchemeFormat = "8x4", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 80, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 80, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 80, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 80, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 80, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 7, Percentage = 80, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 8, Percentage = 80, NoOfReps = 4},
                                          }
                                        }
                                    } },
                                    new TemplateDay { DayNo = 4, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                          NoOfSets = 10, RepSchemeFormat = "10x3", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 85, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 85, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 85, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 85, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 7, Percentage = 85, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 8, Percentage = 85, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 9, Percentage = 85, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 10, Percentage = 85, NoOfReps = 3},
                                          }
                                        }
                                    } },
                                }
                            },
                            //Week 2
                             new TemplateWeek { WeekNo = 2,TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                          NoOfSets = 6, RepSchemeFormat = "6x6", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 72, NoOfReps = 6},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 72, NoOfReps = 6},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 72, NoOfReps = 6},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 72, NoOfReps = 6},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 72, NoOfReps = 6},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 72, NoOfReps = 6},
                                          }
                                        }
                                    } },
                                     new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                          NoOfSets = 7, RepSchemeFormat = "7x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 77, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 77, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 77, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 77, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 77, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 77, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 7, Percentage = 77, NoOfReps = 5},
                                          }
                                        }
                                    } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                          NoOfSets = 8, RepSchemeFormat = "8x4", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 82, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 82, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 82, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 82, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 82, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 82, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 7, Percentage = 82, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 8, Percentage = 82, NoOfReps = 4},
                                          }
                                        }
                                    } },
                                    new TemplateDay { DayNo = 4, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                          NoOfSets = 10, RepSchemeFormat = "10x3", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 87, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 87, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 87, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 87, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 87, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 87, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 7, Percentage = 87, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 8, Percentage = 87, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 9, Percentage = 87, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 10, Percentage = 87, NoOfReps = 3},
                                          }
                                        }
                                    } },
                                }
                            },
                             //Week 3
                              new TemplateWeek { WeekNo = 3,TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                          NoOfSets = 6, RepSchemeFormat = "6x6", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 74, NoOfReps = 6},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 74, NoOfReps = 6},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 74, NoOfReps = 6},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 74, NoOfReps = 6},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 74, NoOfReps = 6},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 74, NoOfReps = 6},
                                          }
                                        }
                                    } },
                                     new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                          NoOfSets = 7, RepSchemeFormat = "7x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 77, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 77, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 77, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 77, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 77, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 77, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 7, Percentage = 77, NoOfReps = 5},
                                          }
                                        }
                                    } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                          NoOfSets = 8, RepSchemeFormat = "8x4", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 84, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 84, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 84, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 84, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 84, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 84, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 7, Percentage = 84, NoOfReps = 4},
                                          new TemplateRepScheme { SetNo = 8, Percentage = 84, NoOfReps = 4},
                                          }
                                        }
                                    } },
                                    new TemplateDay { DayNo = 4, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                          NoOfSets = 10, RepSchemeFormat = "10x3", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 89, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 89, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 89, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 89, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 89, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 89, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 7, Percentage = 89, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 8, Percentage = 89, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 9, Percentage = 89, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 10, Percentage = 89, NoOfReps = 3},
                                          }
                                        }
                                    } },
                                }
                            },
                    } },
                        CreateMadcows(),
                        Create531BBB4Day(),
                        Create5314Day()
        };

            return templates;
        }

        public static TemplateProgram CreateMadcows()
        {
            return new TemplateProgram
            {
                TemplateProgramId = 6,
                Name = "Madcow 5x5",
                Difficulty = Enum.GetName(typeof(TemplateDifficultyEnum), TemplateDifficultyEnum.Intermediate),
                NoOfWeeks = 12,
                NoOfDaysPerWeek = 3,
                TemplateType = "Block",
                WeightProgressionType = Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.INCREMENTAL),
                TemplateWeeks = new List<TemplateWeek>
                {
                    new TemplateWeek
                    {
                        WeekNo = 1,
                        TemplateDays = new List<TemplateDay>
                        {
                            new TemplateDay
                            {
                                DayNo = 1,
                                TemplateExercises = new List<TemplateExercise>
                                {
                                    new TemplateExercise
                                    {
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 95, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 3,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 95, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 95, NoOfReps = 5 }
                                        }
                                    },
                                }
                            },
                            new TemplateDay
                            {
                                DayNo = 2,
                                TemplateExercises = new List<TemplateExercise>
                                {
                                    new TemplateExercise
                                    {
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 95, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 4,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 95, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 4,
                                        RepSchemeFormat = "4x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 95, NoOfReps = 5 },
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
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 95, NoOfReps = 3 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 3,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 95, NoOfReps = 3 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 95, NoOfReps = 3 }
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new TemplateWeek
                    {
                        WeekNo = 2,
                        TemplateDays = new List<TemplateDay>
                        {
                            new TemplateDay
                            {
                                DayNo = 1,
                                TemplateExercises = new List<TemplateExercise>
                                {
                                    new TemplateExercise
                                    {
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 95, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 3,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 95, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 95, NoOfReps = 5 }
                                        }
                                    },
                                }
                            },
                            new TemplateDay
                            {
                                DayNo = 2,
                                TemplateExercises = new List<TemplateExercise>
                                {
                                    new TemplateExercise
                                    {
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 95, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 4,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 95, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 4,
                                        RepSchemeFormat = "4x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 95, NoOfReps = 5 },
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
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 100, NoOfReps = 3 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 3,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 100, NoOfReps = 3 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 100, NoOfReps = 3 }
                                        }
                                    },
                                }
                            }
                        }
                    },
                    //Week 3
                    new TemplateWeek
                    {
                        WeekNo = 3,
                        TemplateDays = new List<TemplateDay>
                        {
                            new TemplateDay
                            {
                                DayNo = 1,
                                TemplateExercises = new List<TemplateExercise>
                                {
                                    new TemplateExercise
                                    {
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 100, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 3,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 100, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 100, NoOfReps = 5 }
                                        }
                                    },
                                }
                            },
                            new TemplateDay
                            {
                                DayNo = 2,
                                TemplateExercises = new List<TemplateExercise>
                                {
                                    new TemplateExercise
                                    {
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 100, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 4,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 100, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 4,
                                        RepSchemeFormat = "4x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 100, NoOfReps = 5 },
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
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 100, NoOfReps = 3 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 3,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 100, NoOfReps = 3 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 100, NoOfReps = 3 }
                                        }
                                    },
                                }
                            }
                        }
                    },
                    //Week 4
                    new TemplateWeek
                    {
                        WeekNo = 4,
                        TemplateDays = new List<TemplateDay>
                        {
                            new TemplateDay
                            {
                                DayNo = 1,
                                TemplateExercises = new List<TemplateExercise>
                                {
                                    new TemplateExercise
                                    {
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 100, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 3,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 100, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 100, NoOfReps = 5 }
                                        }
                                    },
                                }
                            },
                            new TemplateDay
                            {
                                DayNo = 2,
                                TemplateExercises = new List<TemplateExercise>
                                {
                                    new TemplateExercise
                                    {
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 100, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 4,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 100, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 4,
                                        RepSchemeFormat = "4x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 100, NoOfReps = 5 },
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
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 105, NoOfReps = 3 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 3,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 105, NoOfReps = 3 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 105, NoOfReps = 3 }
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new TemplateWeek
                    {
                        WeekNo = 6,
                        TemplateDays = new List<TemplateDay>
                        {
                            new TemplateDay
                            {
                                DayNo = 1,
                                TemplateExercises = new List<TemplateExercise>
                                {
                                    new TemplateExercise
                                    {
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 55, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 80, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 105, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 3,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 55, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 80, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 105, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 55, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 80, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 105, NoOfReps = 5 }
                                        }
                                    },
                                }
                            },
                            new TemplateDay
                            {
                                DayNo = 2,
                                TemplateExercises = new List<TemplateExercise>
                                {
                                    new TemplateExercise
                                    {
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 55, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 80, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 105, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 4,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 55, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 80, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 105, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 4,
                                        RepSchemeFormat = "4x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 105, NoOfReps = 5 },
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
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 55, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 80, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 105, NoOfReps = 3 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 3,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 55, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 80, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 110, NoOfReps = 3 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 55, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 80, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 110, NoOfReps = 3 }
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new TemplateWeek
                    {
                        WeekNo = 7,
                        TemplateDays = new List<TemplateDay>
                        {
                            new TemplateDay
                            {
                                DayNo = 1,
                                TemplateExercises = new List<TemplateExercise>
                                {
                                    new TemplateExercise
                                    {
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 55, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 95, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 110, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 3,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 55, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 95, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 110, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 55, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 95, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 110, NoOfReps = 5 }
                                        }
                                    },
                                }
                            },
                            new TemplateDay
                            {
                                DayNo = 2,
                                TemplateExercises = new List<TemplateExercise>
                                {
                                    new TemplateExercise
                                    {
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 55, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 95, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 110, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 4,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 55, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 95, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 110, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 4,
                                        RepSchemeFormat = "4x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 100, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 115, NoOfReps = 5 },
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
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 55, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 95, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 115, NoOfReps = 3 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 3,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 55, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 95, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 115, NoOfReps = 3 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 55, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 95, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 115, NoOfReps = 3 }
                                        }
                                    },
                                }
                            }
                        }
                    },
                    //week 8
                    new TemplateWeek
                    {
                        WeekNo = 8,
                        TemplateDays = new List<TemplateDay>
                        {
                            new TemplateDay
                            {
                                DayNo = 1,
                                TemplateExercises = new List<TemplateExercise>
                                {
                                    new TemplateExercise
                                    {
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 100, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 115, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 3,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 100, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 115, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 100, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 115, NoOfReps = 5 }
                                        }
                                    },
                                }
                            },
                            new TemplateDay
                            {
                                DayNo = 2,
                                TemplateExercises = new List<TemplateExercise>
                                {
                                    new TemplateExercise
                                    {
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 100, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 115, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 4,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 100, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 115, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 4,
                                        RepSchemeFormat = "4x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 100, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 115, NoOfReps = 5 },
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
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 100, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 115, NoOfReps = 3 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 3,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 100, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 115, NoOfReps = 3 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 100, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 115, NoOfReps = 3 }
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new TemplateWeek
                    {
                        WeekNo = 9,
                        TemplateDays = new List<TemplateDay>
                        {
                            new TemplateDay
                            {
                                DayNo = 1,
                                TemplateExercises = new List<TemplateExercise>
                                {
                                    new TemplateExercise
                                    {
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 100, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 115, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 3,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 100, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 115, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 100, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 115, NoOfReps = 5 }
                                        }
                                    },
                                }
                            },
                            new TemplateDay
                            {
                                DayNo = 2,
                                TemplateExercises = new List<TemplateExercise>
                                {
                                    new TemplateExercise
                                    {
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 100, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 115, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 4,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 100, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 115, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 4,
                                        RepSchemeFormat = "4x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 100, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 115, NoOfReps = 5 },
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
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 100, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 120, NoOfReps = 3 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 3,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 100, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 120, NoOfReps = 3 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 100, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 120, NoOfReps = 3 }
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new TemplateWeek
                    {
                        WeekNo = 9,
                        TemplateDays = new List<TemplateDay>
                        {
                            new TemplateDay
                            {
                                DayNo = 1,
                                TemplateExercises = new List<TemplateExercise>
                                {
                                    new TemplateExercise
                                    {
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 100, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 115, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 3,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 100, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 115, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 100, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 115, NoOfReps = 5 }
                                        }
                                    },
                                }
                            },
                            new TemplateDay
                            {
                                DayNo = 2,
                                TemplateExercises = new List<TemplateExercise>
                                {
                                    new TemplateExercise
                                    {
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 100, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 115, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 4,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 100, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 115, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 4,
                                        RepSchemeFormat = "4x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 105, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 120, NoOfReps = 5 },
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
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 100, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 120, NoOfReps = 3 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 3,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 100, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 120, NoOfReps = 3 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 100, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 120, NoOfReps = 3 }
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new TemplateWeek
                    {
                        WeekNo = 10,
                        TemplateDays = new List<TemplateDay>
                        {
                            new TemplateDay
                            {
                                DayNo = 1,
                                TemplateExercises = new List<TemplateExercise>
                                {
                                    new TemplateExercise
                                    {
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 105, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 120, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 3,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 105, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 120, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 105, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 120, NoOfReps = 5 }
                                        }
                                    },
                                }
                            },
                            new TemplateDay
                            {
                                DayNo = 2,
                                TemplateExercises = new List<TemplateExercise>
                                {
                                    new TemplateExercise
                                    {
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 105, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 120, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 4,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 105, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 120, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 4,
                                        RepSchemeFormat = "4x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 105, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 120, NoOfReps = 5 },
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
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 105, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 120, NoOfReps = 3 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 3,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 105, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 120, NoOfReps = 3 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 105, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 120, NoOfReps = 3 }
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new TemplateWeek
                    {
                        WeekNo = 11,
                        TemplateDays = new List<TemplateDay>
                        {
                            new TemplateDay
                            {
                                DayNo = 1,
                                TemplateExercises = new List<TemplateExercise>
                                {
                                    new TemplateExercise
                                    {
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 105, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 120, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 3,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 105, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 120, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 105, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 120, NoOfReps = 5 }
                                        }
                                    },
                                }
                            },
                            new TemplateDay
                            {
                                DayNo = 2,
                                TemplateExercises = new List<TemplateExercise>
                                {
                                    new TemplateExercise
                                    {
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 105, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 120, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 4,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 105, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 120, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 4,
                                        RepSchemeFormat = "4x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 105, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 120, NoOfReps = 5 },
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
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 105, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 125, NoOfReps = 3 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 3,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 105, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 125, NoOfReps = 3 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 105, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 125, NoOfReps = 3 }
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new TemplateWeek
                    {
                        WeekNo = 12,
                        TemplateDays = new List<TemplateDay>
                        {
                            new TemplateDay
                            {
                                DayNo = 1,
                                TemplateExercises = new List<TemplateExercise>
                                {
                                    new TemplateExercise
                                    {
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 110, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 125, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 3,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 110, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 125, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 110, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 125, NoOfReps = 5 }
                                        }
                                    },
                                }
                            },
                            new TemplateDay
                            {
                                DayNo = 2,
                                TemplateExercises = new List<TemplateExercise>
                                {
                                    new TemplateExercise
                                    {
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 110, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 125, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 4,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "5x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 110, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 125, NoOfReps = 5 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 4,
                                        RepSchemeFormat = "4x5",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 80, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 95, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 110, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 125, NoOfReps = 5 },
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
                                        ExerciseId = 1,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 110, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 130, NoOfReps = 3 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 3,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 110, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 130, NoOfReps = 3 }
                                        }
                                    },
                                    new TemplateExercise
                                    {
                                        ExerciseId = 2,
                                        RepSchemeType = Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                        NoOfSets = 5,
                                        RepSchemeFormat = "4x5, 1x3",
                                        TemplateRepSchemes = new List<TemplateRepScheme>
                                        {
                                            new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 4, Percentage = 110, NoOfReps = 5 },
                                            new TemplateRepScheme { SetNo = 5, Percentage = 130, NoOfReps = 3 }
                                        }
                                    },
                                }
                            }
                        }
                    },
                }
            };
        }

        public static TemplateProgram Create531BBB()
        {
            return new TemplateProgram
            {
                TemplateProgramId = 2,
                Name = "5/3/1 Boring But Big (3 Day)",
                Difficulty = Enum.GetName(typeof(TemplateDifficultyEnum), TemplateDifficultyEnum.Beginner),
                NoOfWeeks = 4,
                NoOfDaysPerWeek = 3,
                TemplateType = "Block",
                WeightProgressionType = Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.PERCENTAGE),
                TemplateWeeks = new List<TemplateWeek> {
                            new TemplateWeek { WeekNo = 1,TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
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
                                          new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
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
                                    new TemplateDay { DayNo=3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 8, RepSchemeFormat = "3x5", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NoOfReps = 8, IsBackOffSet = true}
                                                                                                          } } } } } },
                            //Week 2
                            new TemplateWeek { WeekNo = 2, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 8, RepSchemeFormat = "3x3", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
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
                                          new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 8, RepSchemeFormat = "3x3", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
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
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 8, RepSchemeFormat = "3x3", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 70, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NoOfReps = 8, IsBackOffSet = true}
                                                                                                          } } } } } },
                             //Week 3
                            new TemplateWeek { WeekNo = 3, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 8, RepSchemeFormat = "1x5, 1x3, 1x1+", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
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
                                          new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 8, RepSchemeFormat = "1x5, 1x3, 1x1+", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
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
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 8, RepSchemeFormat = "1x5, 1x3, 1x1+", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NoOfReps = 8, IsBackOffSet = true}
                                                                                                          } } } } } },
                                          //Week 4
                            new TemplateWeek { WeekNo = 4, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5}
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5}
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5}
                                                                                                          } } } }
                            } },
                    }
            };
        }

        public static TemplateProgram Create531BBB4Day()
        {
            return new TemplateProgram
            {
                TemplateProgramId = 7,
                Name = "5/3/1 Boring But Big (4 Day)",
                Difficulty = Enum.GetName(typeof(TemplateDifficultyEnum), TemplateDifficultyEnum.Beginner),
                NoOfWeeks = 4,
                NoOfDaysPerWeek = 4,
                TemplateType = "Block",
                WeightProgressionType = Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.PERCENTAGE),
                TemplateWeeks = new List<TemplateWeek> {
                            new TemplateWeek { WeekNo = 1,TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
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
                                          new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
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
                                    new TemplateDay { DayNo=3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 8, RepSchemeFormat = "3x5", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NoOfReps = 8, IsBackOffSet = true}
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 4, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 4, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 8, RepSchemeFormat = "3x5", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NoOfReps = 8, IsBackOffSet = true}
                                                                                                          } } } }
                            } },
                            //Week 2
                            new TemplateWeek { WeekNo = 2, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 8, RepSchemeFormat = "3x3", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
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
                                          new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 8, RepSchemeFormat = "3x3", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
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
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 8, RepSchemeFormat = "3x3", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 70, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NoOfReps = 8, IsBackOffSet = true}
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 4, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 4, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 8, RepSchemeFormat = "3x3", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 70, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NoOfReps = 8, IsBackOffSet = true}
                                                                                                          } } } }
                            } },
                             //Week 3
                            new TemplateWeek { WeekNo = 3, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 8, RepSchemeFormat = "1x5, 1x3, 1x1+", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
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
                                          new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 8, RepSchemeFormat = "1x5, 1x3, 1x1+", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
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
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 8, RepSchemeFormat = "1x5, 1x3, 1x1+", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NoOfReps = 8, IsBackOffSet = true}
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 4, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 4, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 8, RepSchemeFormat = "1x5, 1x3, 1x1+", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NoOfReps = 8, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NoOfReps = 8, IsBackOffSet = true}
                                                                                                          } } } }
                            } },
                                          //Week 4
                            new TemplateWeek { WeekNo = 4, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5}
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5}
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5}
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 4, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 4, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5}
                                                                                                          } } } }
                            } },
                    }
            };
        }

        public static TemplateProgram Create531()
        {
            return new TemplateProgram
            {
                TemplateProgramId = 1,
                Name = "5/3/1 (3 Day)",
                Difficulty = Enum.GetName(typeof(TemplateDifficultyEnum), TemplateDifficultyEnum.Beginner),
                NoOfWeeks = 4,
                NoOfDaysPerWeek = 3,
                TemplateType = "Block",
                WeightProgressionType = Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.PERCENTAGE),
                TemplateWeeks = new List<TemplateWeek> {
                            new TemplateWeek { WeekNo = 1,TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise>{
                                          new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                                                                                          } } } } } },
                            //Week 2
                            new TemplateWeek { WeekNo = 2, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1,TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x3", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 70, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x3", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 70, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x3", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 70, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                                                                                          } } } } } },
                             //Week 3
                            new TemplateWeek { WeekNo = 3, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo=1, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "1x5, 1x3, 1x1", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo=2, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "1x5, 1x3, 1x1", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo=3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "1x5, 1x3, 1x1", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true}
                                                                                                          } } } } } },
                                          //Week 4
                            new TemplateWeek { WeekNo = 4, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo=1, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5}
                                                                                                          } } } },
                                    new TemplateDay { DayNo=2, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5}
                                                                                                          } } } },
                                    new TemplateDay { DayNo=3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5}
                                                                                                          } } } } } },
                    }
            };

        }

        public static TemplateProgram Create5314Day()
        {
            return new TemplateProgram
            {
                TemplateProgramId = 8,
                Name = "5/3/1 (4 Day)",
                Difficulty = Enum.GetName(typeof(TemplateDifficultyEnum), TemplateDifficultyEnum.Beginner),
                NoOfWeeks = 4,
                NoOfDaysPerWeek = 4,
                TemplateType = "Block",
                WeightProgressionType = Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.PERCENTAGE),
                TemplateWeeks = new List<TemplateWeek> {
                            new TemplateWeek { WeekNo = 1,TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise>{
                                          new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 4, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 4, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                                                                                          } } } }
                            } },
                            //Week 2
                            new TemplateWeek { WeekNo = 2, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1,TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x3", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 70, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x3", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 70, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x3", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 70, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 4, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 4, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x3", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 70, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                                                                                          } } } }
                            } },
                             //Week 3
                            new TemplateWeek { WeekNo = 3, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo=1, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "1x5, 1x3, 1x1", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo=2, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "1x5, 1x3, 1x1", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo=3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "1x5, 1x3, 1x1", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true}
                                                                                                          } } } },
                                     new TemplateDay { DayNo = 4, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 4, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "1x5, 1x3, 1x1", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true}
                                                                                                          } } } },
                            } },
                                          //Week 4
                            new TemplateWeek { WeekNo = 4, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo=1, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5}
                                                                                                          } } } },
                                    new TemplateDay { DayNo=2, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5}
                                                                                                          } } } },
                                    new TemplateDay { DayNo=3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5}
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 4, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 4, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5}
                                                                                                          } } } }
                            } },
                    }
            };
        }
    }
}
