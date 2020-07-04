using System;
using System.Collections.Generic;
using PowerLifting.Service.TemplatePrograms.Model;

namespace PowerLifting.Persistence
{
    public static class TemplateProgramSeed
    {
        public static TemplateProgram[] CreateTemplatePrograms()
        {
            var templates = new TemplateProgram[]
                {
                    new TemplateProgram {Name="5/3/1", Difficulty=Enum.GetName(typeof(TemplateDifficultyEnum), TemplateDifficultyEnum.Beginner), NoOfWeeks = 4, MaxLiftDaysPerWeek = 3,
                        TemplateType="Block", WeightProgressionType=Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.PERCENTAGE),
                         TemplateExerciseCollection = new List<TemplateExerciseCollection> {
                            new TemplateExerciseCollection { TemplateProgramId = 1, ExerciseId = 1 },
                            new TemplateExerciseCollection { TemplateProgramId = 1, ExerciseId = 26 },
                            new TemplateExerciseCollection { TemplateProgramId = 1, ExerciseId = 27 } },
                            TemplateWeeks = new List<TemplateWeek> {
                            new TemplateWeek { WeekNo = 1,TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise>{
                                          new TemplateExercise { ExerciseId = 26, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 27, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                                                                                          } } } } } },
                            //Week 2
                            new TemplateWeek { WeekNo = 2, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1,TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "3x3", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 70, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 26, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "3x3", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 70, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 27, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "3x3", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 70, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                                                                                          } } } } } },
                             //Week 3
                            new TemplateWeek { WeekNo = 3, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo=1, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "1x5, 1x3, 1x1", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo=2, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 26, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "1x5, 1x3, 1x1", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                                                                                          } } } },
                                    new TemplateDay { DayNo=3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 27, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "1x5, 1x3, 1x1", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true}
                                                                                                          } } } } } },
                                          //Week 4
                            new TemplateWeek { WeekNo = 4, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo=1, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5}
                                                                                                          } } } },
                                    new TemplateDay { DayNo=2, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 26, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5}
                                                                                                          } } } },
                                    new TemplateDay { DayNo=3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 27, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5}
                                                                                                          } } } } } },
                    } },
                    new TemplateProgram {Name="5/3/1 Boring But Big", Difficulty=Enum.GetName(typeof(TemplateDifficultyEnum), TemplateDifficultyEnum.Beginner),
                        NoOfWeeks = 4, MaxLiftDaysPerWeek = 3, TemplateType="Block", WeightProgressionType=Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.PERCENTAGE),
                         TemplateExerciseCollection = new List<TemplateExerciseCollection> {
                            new TemplateExerciseCollection { TemplateProgramId = 2, ExerciseId = 1 },
                            new TemplateExerciseCollection { TemplateProgramId = 2, ExerciseId = 26 },
                            new TemplateExerciseCollection { TemplateProgramId = 2, ExerciseId = 27 },
                            new TemplateExerciseCollection { TemplateProgramId = 2, ExerciseId = 25 } },
                            TemplateWeeks = new List<TemplateWeek> {
                            new TemplateWeek { WeekNo = 1,TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo=1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 25, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
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
                                          new TemplateExercise { ExerciseId = 26, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 8, RepSchemeFormat = "3x3", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
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
                                          new TemplateExercise { ExerciseId = 27, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 8, RepSchemeFormat = "1x5, 1x3, 1x1", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 65, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 85, NoOfReps = 5, AMRAP = true},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NoOfReps = 10, IsBackOffSet = true}
                                                                                                          } } } } } },
                            //Week 2
                            new TemplateWeek { WeekNo = 2, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 8, RepSchemeFormat = "3x5", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
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
                                          new TemplateExercise { ExerciseId = 26, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 8, RepSchemeFormat = "3x5", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
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
                                          new TemplateExercise { ExerciseId = 27, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 8, RepSchemeFormat = "3x5", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 70, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 80, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 90, NoOfReps = 3, AMRAP = true},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NoOfReps = 10, IsBackOffSet = true}
                                                                                                          } } } } } },
                             //Week 3
                            new TemplateWeek { WeekNo = 3, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 8, RepSchemeFormat = "3x5", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
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
                                          new TemplateExercise { ExerciseId = 26, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 8, RepSchemeFormat = "3x3", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
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
                                          new TemplateExercise { ExerciseId = 27, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 8, RepSchemeFormat = "1x5, 1x3, 1x1", HasBackOffSets=true, BackOffSetFormat="5x10", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                new TemplateRepScheme { SetNo = 1, Percentage = 75, NoOfReps = 5},
                                                new TemplateRepScheme { SetNo = 2, Percentage = 85, NoOfReps = 3},
                                                new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 1, AMRAP = true},
                                                new TemplateRepScheme { SetNo = 4, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 5, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 6, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 7, Percentage = 50, NoOfReps = 10, IsBackOffSet = true},
                                                new TemplateRepScheme { SetNo = 8, Percentage = 50, NoOfReps = 10, IsBackOffSet = true}
                                                                                                          } } } } } },
                                          //Week 4
                            new TemplateWeek { WeekNo = 4, TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5}
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 26, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5}
                                                                                                          } } } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                          new TemplateExercise { ExerciseId = 27, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.RAMPED),
                                            NoOfSets = 3, RepSchemeFormat = "3x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                                 new TemplateRepScheme { SetNo = 1, Percentage = 40, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 2, Percentage = 50, NoOfReps = 5},
                                                 new TemplateRepScheme { SetNo = 3, Percentage = 60, NoOfReps = 5}
                                                                                                          } } } } } },
                    } },
                    new TemplateProgram { Name="StrongLifts 5x5", Difficulty=Enum.GetName(typeof(TemplateDifficultyEnum), TemplateDifficultyEnum.Beginner), NoOfWeeks = 12,
                        MaxLiftDaysPerWeek = 3, TemplateType="Block", WeightProgressionType=Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.INCREMENTAL),
                         TemplateExerciseCollection = new List<TemplateExerciseCollection> {
                            new TemplateExerciseCollection { TemplateProgramId = 3, ExerciseId = 1 },
                            new TemplateExerciseCollection { TemplateProgramId = 3, ExerciseId = 25},
                            new TemplateExerciseCollection { TemplateProgramId = 3, ExerciseId = 26 },
                            new TemplateExerciseCollection { TemplateProgramId = 3, ExerciseId = 27 },
                            new TemplateExerciseCollection { TemplateProgramId = 3, ExerciseId = 2 } },
                            TemplateWeeks = new List<TemplateWeek> {
                            new TemplateWeek { WeekNo = 1,TemplateDays = new List<TemplateDay> {
                                   new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                       new TemplateExercise { ExerciseId = 26, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                        new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                    } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                       new TemplateExercise { ExerciseId = 25, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                        new TemplateExercise { ExerciseId = 27, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                    } },
                                    new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1,RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                       new TemplateExercise { ExerciseId = 26, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                        new TemplateExercise { ExerciseId = 2,RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                       new TemplateExercise { ExerciseId = 25, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                        new TemplateExercise { ExerciseId = 27, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                    } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                       new TemplateExercise { ExerciseId = 26, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                        new TemplateExercise { ExerciseId = 2, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                    } },
                                     new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                       new TemplateExercise { ExerciseId = 25, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } },
                                        new TemplateExercise { ExerciseId = 27, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 5, RepSchemeFormat = "5x5", TemplateRepSchemes = new List<TemplateRepScheme> {
                                            new TemplateRepScheme { SetNo = 1, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 2, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 3, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 4, NoOfReps = 5},
                                            new TemplateRepScheme { SetNo = 5, NoOfReps = 5}
                                        } }
                                    } } } } } },


                        new TemplateProgram {Name="Russian Squat Routine", Difficulty=Enum.GetName(typeof(TemplateDifficultyEnum), TemplateDifficultyEnum.Intermediate), NoOfWeeks = 6, MaxLiftDaysPerWeek = 3,
                        TemplateType="Block", WeightProgressionType=Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.PERCENTAGE),
                        TemplateExerciseCollection = new List<TemplateExerciseCollection> {
                            new TemplateExerciseCollection { TemplateProgramId = 1, ExerciseId = 1 }
                        },
                        TemplateWeeks = new List<TemplateWeek> {
                            new TemplateWeek { WeekNo = 1,TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 6, RepSchemeFormat = "3x3", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 95, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 95, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 3},
                                          }
                                        }
                                    } },
                                     new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 2, RepSchemeFormat = "2x2", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 100, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 100, NoOfReps = 2},
                                          }
                                        }
                                    } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 1, RepSchemeFormat = "1x1", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          }
                                        }
                                    } },
                                }
                            }

                    } },
                        new TemplateProgram {Name="Smolov Jr Bench Routine", Difficulty=Enum.GetName(typeof(TemplateDifficultyEnum), TemplateDifficultyEnum.Advanced), NoOfWeeks = 3, MaxLiftDaysPerWeek = 4,
                        TemplateType="Block", WeightProgressionType=Enum.GetName(typeof(WeightProgressionTypeEnum), WeightProgressionTypeEnum.PERCENTAGE),
                        TemplateExerciseCollection = new List<TemplateExerciseCollection> {
                            new TemplateExerciseCollection { TemplateProgramId = 5, ExerciseId = 26 }
                        },
                        TemplateWeeks = new List<TemplateWeek> {
                            new TemplateWeek { WeekNo = 1,TemplateDays = new List<TemplateDay> {
                                    new TemplateDay { DayNo = 1, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 6, RepSchemeFormat = "7x5", TemplateRepSchemes = new List<TemplateRepScheme> {
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 6, RepSchemeFormat = "3x3", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 95, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 95, NoOfReps = 3},
                                          new TemplateRepScheme { SetNo = 3, Percentage = 95, NoOfReps = 3},
                                          }
                                        }
                                    } },
                                     new TemplateDay { DayNo = 3, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 2, RepSchemeFormat = "2x2", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          new TemplateRepScheme { SetNo = 1, Percentage = 100, NoOfReps = 2},
                                          new TemplateRepScheme { SetNo = 2, Percentage = 100, NoOfReps = 2},
                                          }
                                        }
                                    } },
                                    new TemplateDay { DayNo = 2, TemplateExercises = new List<TemplateExercise> {
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
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
                                        new TemplateExercise { ExerciseId = 1, RepSchemeType=Enum.GetName(typeof(RepSchemeTypeEnum), RepSchemeTypeEnum.FIXED),
                                            NoOfSets = 1, RepSchemeFormat = "1x1", TemplateRepSchemes = new List<TemplateRepScheme> {
                                          }
                                        }
                                    } },
                                }
                            }
                    } },
        };

            return templates;
        }
    }
}
