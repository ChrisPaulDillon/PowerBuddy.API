using System;
using System.Collections.Generic;
using PowerLifting.Data.Entities.Templates;

namespace PowerLifting.Data.SeedData.TemplatePrograms
{
    public static class JuggernaughtMethod
    {
        public static TemplateProgram Create()
        {
            return new TemplateProgram
            {
                TemplateProgramId = 9,
                Name = "Juggernaught Method",
                Difficulty = Enum.GetName(typeof(TemplateDifficultyEnum), TemplateDifficultyEnum.Beginner),
                NoOfWeeks = 16,
                NoOfDaysPerWeek = 4,
                TemplateType = "Block",
                WeightProgressionType = Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.PERCENTAGE),
                TemplateWeeks = new List<TemplateWeek> {
                            new TemplateWeek { WeekNo = 1,TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 5, RepSchemeFormat = "5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 10},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 60, NoOfReps = 10},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 10},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 60, NoOfReps = 10},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 60, NoOfReps = 10, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise>{
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 5, RepSchemeFormat = "5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 10},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 60, NoOfReps = 10},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 10},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 60, NoOfReps = 10},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 60, NoOfReps = 10, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 4, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 5, RepSchemeFormat = "5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 10},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 60, NoOfReps = 10},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 10},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 60, NoOfReps = 10},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 60, NoOfReps = 10, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 4, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 5, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 10},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 60, NoOfReps = 10},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 10},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 60, NoOfReps = 10},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 60, NoOfReps = 10, AMRAP = true},
                                                                                                          } } } }
                            } },
                            //Week 2
                             new TemplateWeek { WeekNo = 2,TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 5, RepSchemeFormat = "2x5, 3x10", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 55, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 10},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 70, NoOfReps = 10},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 70, NoOfReps = 10, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise>{
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 5, RepSchemeFormat = "2x5, 3x10", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 55, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 10},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 70, NoOfReps = 10},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 70, NoOfReps = 10, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 4, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 5, RepSchemeFormat = "2x5, 3x10", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 55, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 10},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 70, NoOfReps = 10},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 70, NoOfReps = 10, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 4, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 5, RepSchemeFormat = "2x5, 3x10", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 55, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 10},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 70, NoOfReps = 10},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 70, NoOfReps = 10, AMRAP = true},
                                                                                                          } } } },
                            } },
                             //Week 3
                              new TemplateWeek { WeekNo = 3,TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 4, RepSchemeFormat = "1x5, 1x3, 1x1, 1x1+", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 60, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 10},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 75, NoOfReps = 10, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise>{
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                             NoOfSets = 4, RepSchemeFormat = "1x5, 1x3, 1x1, 1x1+", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 60, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 10},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 75, NoOfReps = 10, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 4, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 4, RepSchemeFormat = "1x5, 1x3, 1x1, 1x1+", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 60, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 10},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 75, NoOfReps = 10, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 4, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                             NoOfSets = 4, RepSchemeFormat = "1x5, 1x3, 1x1, 1x1+", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 60, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 10},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 75, NoOfReps = 10, AMRAP = true},
                                                                                                          } } } },
                            } },
                                          //Week 4
                            new TemplateWeek { WeekNo = 4,TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise>{
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                              NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 4, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                             NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 4, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                             NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5},
                                                                                                          } } } },
                            } },
                            //Week 5
                             new TemplateWeek { WeekNo = 5,TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 5, RepSchemeFormat = "5x8", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 8},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 8},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 75, NoOfReps = 8},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 75, NoOfReps = 8},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 75, NoOfReps = 8, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise>{
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                           NoOfSets = 5, RepSchemeFormat = "5x8", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 85, NoOfReps = 8},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 8},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 8},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 85, NoOfReps = 8},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 85, NoOfReps = 8, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 4, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 5, RepSchemeFormat = "5x8", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 70, NoOfReps = 8},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 8},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 8},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 70, NoOfReps = 8},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 70, NoOfReps = 8, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 4, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 5, RepSchemeFormat = "5x8", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 8},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 8},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 75, NoOfReps = 8},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 75, NoOfReps = 8},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 75, NoOfReps = 8, AMRAP = true},
                                                                                                          } } } },
                            } },
                             //Week 6
                             new TemplateWeek { WeekNo = 6, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 5, RepSchemeFormat = "2x3, 3x8", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 70, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 8},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 85, NoOfReps = 8},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 85, NoOfReps = 8, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise>{
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 5, RepSchemeFormat = "2x3, 3x8", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 8},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 95, NoOfReps = 8},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 95, NoOfReps = 8, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 4, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 5, RepSchemeFormat = "2x3, 3x8", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 80, NoOfReps = 8},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 80, NoOfReps = 8},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 80, NoOfReps = 8, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 4, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                             NoOfSets = 5, RepSchemeFormat = "2x3, 3x8", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 70, NoOfReps = 8},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 8},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 80, NoOfReps = 8},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 80, NoOfReps = 8},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 80, NoOfReps = 8, AMRAP = true},
                                                                                                          } } } },
                            } },

                             //Week 7
                             new TemplateWeek { WeekNo = 7, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 5, RepSchemeFormat = "1x5, 1x3, 1x2, 1x1, 1x1+", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise>{
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 5, RepSchemeFormat = "1x5, 1x3, 1x2, 1x1, 1x1+", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 95, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 100, NoOfReps = 1, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 4, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 5, RepSchemeFormat = "1x5, 1x3, 1x2, 1x1, 1x1+", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 55, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 75, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 80, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 85, NoOfReps = 1, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 4, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                              NoOfSets = 5, RepSchemeFormat = "1x5, 1x3, 1x2, 1x1, 1x1+", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 55, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 85, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 90, NoOfReps = 1, AMRAP = true},
                                                                                                          } } } },
                            } },

                               //Week 8
                             new TemplateWeek { WeekNo = 8, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 60, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 5},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise>{
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                           NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 75, NoOfReps = 5},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 4, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 45, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 55, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 65, NoOfReps = 5},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 4, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 45, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 55, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 5},
                                                                                                          } } } },
                            } },

                               //Week 9
                             new TemplateWeek { WeekNo = 9,TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 6, RepSchemeFormat = "6x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 85, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 85, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 85, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise>{
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                           NoOfSets = 6, RepSchemeFormat = "6x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 95, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 95, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 95, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 95, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 95, NoOfReps = 5, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 4, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                           NoOfSets = 6, RepSchemeFormat = "6x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 80, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 80, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 80, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 80, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 80, NoOfReps = 5, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 4, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                           NoOfSets = 6, RepSchemeFormat = "6x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 85, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 85, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 85, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                                                                                          } } } },
                            } },
                             //Week 10
                              new TemplateWeek { WeekNo = 10, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 6, RepSchemeFormat = "2x2, 4x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 90, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 95, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 95, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 95, NoOfReps = 5, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise>{
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 6, RepSchemeFormat = "2x2, 4x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 90, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 100, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 105, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 105, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 105, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 105, NoOfReps = 5, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 4, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                              NoOfSets = 6, RepSchemeFormat = "2x2, 4x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 90, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 90, NoOfReps = 5, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 4, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                              NoOfSets = 6, RepSchemeFormat = "2x2, 4x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 90, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 95, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 95, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 95, NoOfReps = 5, AMRAP = true},
                                                                                                          } } } },
                            } },
                              //Week 11
                               new TemplateWeek { WeekNo = 11, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 6, RepSchemeFormat = "1x5, 1x3, 1x2, 1x1, 1x1, 1x1+", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 100, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 105, NoOfReps = 1, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise>{
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                           NoOfSets = 6, RepSchemeFormat = "1x5, 1x3, 1x2, 1x1, 1x1, 1x1+", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 70, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 105, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 110, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 115, NoOfReps = 1, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 4, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 6, RepSchemeFormat = "1x5, 1x3, 1x2, 1x1, 1x1, 1x1+", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 55, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 80, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 85, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 90, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 4, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                              NoOfSets = 6, RepSchemeFormat = "1x5, 1x3, 1x2, 1x1, 1x1, 1x1+", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 100, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 105, NoOfReps = 1, AMRAP = true},
                                                                                                          } } } },
                            } },
                               //Week 12
                                 new TemplateWeek { WeekNo = 12, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 60, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 75, NoOfReps = 5},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise>{
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                           NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 55, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 4, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 45, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 55, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 5},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 4, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 60, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 75, NoOfReps = 5},
                                                                                                          } } } },
                            } },
                                 //Week 13
                             new TemplateWeek { WeekNo = 13,TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                            NoOfSets = 7, RepSchemeFormat = "7x3", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 95, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 95, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 95, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 95, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 95, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 7, Percentage = 95, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 8, Percentage = 95, NoOfReps = 3, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise>{
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                             NoOfSets = 7, RepSchemeFormat = "7x3", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 110, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 110, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 110, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 110, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 110, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 110, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 7, Percentage = 110, NoOfReps = 3, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 4, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                             NoOfSets = 7, RepSchemeFormat = "7x3", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 90, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 90, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 90, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 90, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 7, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 4, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Fixed),
                                              NoOfSets = 7, RepSchemeFormat = "7x3", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 100, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 100, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 100, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 100, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 100, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 100, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 7, Percentage = 100, NoOfReps = 3, AMRAP = true},
                                                                                                          } } } },
                            } },
                             //Week 14
                             new TemplateWeek { WeekNo = 14, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 7, RepSchemeFormat = "2x1, 5x3", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 90, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 100, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 105, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 105, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 105, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 105, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 7, Percentage = 105, NoOfReps = 3, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise>{
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 7, RepSchemeFormat = "2x1, 5x3", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 105, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 115, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 120, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 120, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 120, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 120, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 7, Percentage = 120, NoOfReps = 3, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 4, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                               NoOfSets = 7, RepSchemeFormat = "2x1, 5x3", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 85, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 90, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 95, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 95, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 95, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 7, Percentage = 95, NoOfReps = 3, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 4, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                             NoOfSets = 7, RepSchemeFormat = "2x1, 5x3", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 95, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 105, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 110, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 110, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 110, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 110, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 7, Percentage = 110, NoOfReps = 3, AMRAP = true},
                                                                                                          } } } },
                            } },
                             //Week 15
                         new TemplateWeek { WeekNo = 15, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 7, RepSchemeFormat = "1x5, 1x3, 1x2, 1x1, 1x1, 1x1, 1x1+", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 95, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 100, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 110, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 7, Percentage = 115, NoOfReps = 1, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise>{
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                           NoOfSets = 7, RepSchemeFormat = "1x5, 1x3, 1x2, 1x1, 1x1, 1x1, 1x1+", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 90, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 105, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 110, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 120, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 125, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 7, Percentage = 135, NoOfReps = 1, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 4, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                             NoOfSets = 7, RepSchemeFormat = "1x5, 1x3, 1x2, 1x1, 1x1, 1x1, 1x1+", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 70, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 90, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 95, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 100, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 7, Percentage = 105, NoOfReps = 1, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 4, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                             NoOfSets = 7, RepSchemeFormat = "1x5, 1x3, 1x2, 1x1, 1x1, 1x1, 1x1+", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 4, Percentage = 100, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 5, Percentage = 105, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 6, Percentage = 115, NoOfReps = 1},
                                          new TemplateRepScheme { SetNo = 7, Percentage = 120, NoOfReps = 1, AMRAP = true},
                                                                                                          } } } },
                            } },
                         //Week 16
                              new TemplateWeek { WeekNo = 16, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 3, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 75, NoOfReps = 5},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise>{
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                           NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 60, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 5},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 4, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 50, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 60, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 70, NoOfReps = 5},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 4, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.Ramped),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 55, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 65, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 80, NoOfReps = 5},
                                                                                                          } } } },
                            } },
                    }
            };
        }

    }


}
