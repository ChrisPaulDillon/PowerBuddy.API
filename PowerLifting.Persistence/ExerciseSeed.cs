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
                    ExerciseName = "Back Squat", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = "Quads"},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = "Hamstrings"},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = "Lower Back"},
                    },
                    ExerciseSports = new List<ExerciseSport>
                    {
                        new ExerciseSport {ExerciseSportStr = "PowerLifting"},
                        new ExerciseSport {ExerciseSportStr = "Olympic WeightLifting"},
                    },
                },
                new Exercise
                {
                    ExerciseName = "DeadLift", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = "Lower Back"},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = "Upper Back"},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = "Hamstring"},
                    },
                    ExerciseSports = new List<ExerciseSport>
                    {
                        new ExerciseSport {ExerciseSportStr = "PowerLifting"},
                        new ExerciseSport {ExerciseSportStr = "Olympic WeightLifting"},
                    },
                },
                new Exercise
                {
                    ExerciseName = "Bench Press", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = "Chest"},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = "Tricep"},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = "Anterior Deltoid"},
                    },
                    ExerciseSports = new List<ExerciseSport>
                    {
                        new ExerciseSport {ExerciseSportStr = "PowerLifting"},
                    },
                },
                new Exercise
                {
                    ExerciseName = "Overhead Press", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = "Anterior Deltoid"},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = "Tricep"},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = "Trapezius"},
                    },
                    ExerciseSports = new List<ExerciseSport>
                    {
                        new ExerciseSport {ExerciseSportStr = "PowerLifting"},
                        new ExerciseSport {ExerciseSportStr = "Olympic WeightLifting"},
                    },
                },
                new Exercise
                {
                    ExerciseName = "Front Squat", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = "Quadricep"},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = "Glute"},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = "Abdominal"},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = "Upper Back"},
                    },
                    ExerciseSports = new List<ExerciseSport>
                    {
                        new ExerciseSport {ExerciseSportStr = "PowerLifting"},
                        new ExerciseSport {ExerciseSportStr = "Olympic WeightLifting"},
                    },
                },
                new Exercise
                {
                    ExerciseName = "Overhead Squat", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = "Shoulder"},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = "Quadricep"},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = "Glute"},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = "Upper Back"},
                    },
                    ExerciseSports = new List<ExerciseSport>
                    {
                        new ExerciseSport {ExerciseSportStr = "Olympic WeightLifting"},
                    },
                },
                new Exercise
                {
                    ExerciseName = "Floor Press", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = "Shoulder"},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = "Chest"},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = "Tricep"},
                    },
                },
                new Exercise {ExerciseName = "Barbell Lunge", ExerciseTypeId = 2},
                new Exercise {ExerciseName = "Incline Bench Press", ExerciseTypeId = 2},
                new Exercise {ExerciseName = "Decline Bench Press", ExerciseTypeId = 2},
                new Exercise {ExerciseName = "Good Morning", ExerciseTypeId = 2},
                new Exercise {ExerciseName = "Stiff Leg Deadlift", ExerciseTypeId = 2},
                new Exercise {ExerciseName = "Sumo Deadlift", ExerciseTypeId = 2},
                new Exercise {ExerciseName = "Snatch", ExerciseTypeId = 2},
                new Exercise {ExerciseName = "Hang Snatch", ExerciseTypeId = 2},
                new Exercise {ExerciseName = "Power Snatch", ExerciseTypeId = 2},
                new Exercise {ExerciseName = "Clean & Press", ExerciseTypeId = 2},
                new Exercise {ExerciseName = "Clean & Jerk", ExerciseTypeId = 2},
                new Exercise {ExerciseName = "Clean", ExerciseTypeId = 2},
                new Exercise {ExerciseName = "Hang Clean", ExerciseTypeId = 2},
                new Exercise {ExerciseName = "Power Clean", ExerciseTypeId = 2},
                new Exercise {ExerciseName = "Jerk", ExerciseTypeId = 2},
                new Exercise {ExerciseName = "Power Jerk", ExerciseTypeId = 2},
                new Exercise {ExerciseName = "Barbell Row", ExerciseTypeId = 2},
                new Exercise {ExerciseName = "Pendlay Row", ExerciseTypeId = 2},
                new Exercise {ExerciseName = "T-Bar Row", ExerciseTypeId = 2},

                //shoulder region
                new Exercise
                {
                    ExerciseName = "Barbell Press (Behind The Neck)", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID, IsPrimary = true},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.MEDIAL_DELTOID },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.TRICEPS_BRACHII },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.MIDDLE_TRAPEZIUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.LOWER_TRAPEZIUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.SERRATUS_ANTERIOR },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Barbell Front Raise", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID, IsPrimary = true},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.CHEST },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.MEDIAL_DELTOID },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.MIDDLE_TRAPEZIUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.LOWER_TRAPEZIUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.SERRATUS_ANTERIOR },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Military Press", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID, IsPrimary = true},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.CHEST },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.MEDIAL_DELTOID },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.MIDDLE_TRAPEZIUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.LOWER_TRAPEZIUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.SERRATUS_ANTERIOR },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Arnold Press", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID, IsPrimary = true},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.SUPRASPINATUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.TRICEPS_BRACHII },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.MEDIAL_DELTOID },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.MIDDLE_TRAPEZIUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.LOWER_TRAPEZIUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.SERRATUS_ANTERIOR },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Front Raise", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID, IsPrimary = true},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.CHEST },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.MEDIAL_DELTOID },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.MIDDLE_TRAPEZIUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.LOWER_TRAPEZIUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.SERRATUS_ANTERIOR },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Shoulder Press", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID, IsPrimary = true},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.SUPRASPINATUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.MEDIAL_DELTOID },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.MIDDLE_TRAPEZIUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.LOWER_TRAPEZIUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.SERRATUS_ANTERIOR },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Shoulder Press", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID, IsPrimary = true},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.SUPRASPINATUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.MEDIAL_DELTOID },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.MIDDLE_TRAPEZIUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.LOWER_TRAPEZIUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.SERRATUS_ANTERIOR },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Barbell Upright Row", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.MEDIAL_DELTOID, IsPrimary = true},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.SUPRASPINATUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.BRACHIALIS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.BICEPS_BRACHII },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.MIDDLE_TRAPEZIUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.LOWER_TRAPEZIUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.SERRATUS_ANTERIOR },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.INFRASPINATUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.TERES_MINOR },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Lateral Raise", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.MEDIAL_DELTOID, IsPrimary = true},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.SUPRASPINATUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.MIDDLE_TRAPEZIUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.LOWER_TRAPEZIUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.SERRATUS_ANTERIOR },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Upright Row", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.MEDIAL_DELTOID, IsPrimary = true},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.SUPRASPINATUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.BRACHIALIS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.BICEPS_BRACHII },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.MIDDLE_TRAPEZIUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.LOWER_TRAPEZIUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.SERRATUS_ANTERIOR },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.INFRASPINATUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.TERES_MINOR },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Barbell Rear Delt Raise", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.POSTERIOR_DELTOID, IsPrimary = true},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.LEVATOR_SCAPULAE },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.MEDIAL_DELTOID },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.BRACHIALIS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.BICEPS_BRACHII },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.UPPER_TRAPEZIUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.BRACHIORADIALIS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.WRIST_FLEXORS },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Rear Delt Row", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.POSTERIOR_DELTOID, IsPrimary = true},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.TERES_MINOR },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.MEDIAL_DELTOID },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.BRACHIALIS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.MIDDLE_TRAPEZIUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.UPPER_TRAPEZIUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.RHOMBOIDS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.BRACHIORADIALIS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.BRACHIALIS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.INFRASPINATUS },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Rear Delt Fly", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.POSTERIOR_DELTOID, IsPrimary = true},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.TERES_MINOR },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.MEDIAL_DELTOID },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.MIDDLE_TRAPEZIUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.UPPER_TRAPEZIUS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.RHOMBOIDS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.INFRASPINATUS },
                    },
                },


                //UPPER ARMS REGION

                new Exercise
                {
                    ExerciseName = "Barbell Bench Press (Close Grip)", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.TRICEPS_BRACHII, IsPrimary = true},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.CHEST },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Barbell Incline Press (Close Grip)", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.TRICEPS_BRACHII, IsPrimary = true},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.CHEST },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.UPPER_CHEST },
                    },
                },
                new Exercise
                {
                    ExerciseName = "JM Barbell Press", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.TRICEPS_BRACHII, IsPrimary = true},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.CHEST },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.UPPER_CHEST },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Barbell Skull Crusher", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.TRICEPS_BRACHII, IsPrimary = true},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.CHEST },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.UPPER_CHEST },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.LATISSIMUS_DORSI },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.POSTERIOR_DELTOID },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.TERES_MAJOR },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.WRIST_FLEXORS },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Skull Crusher", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.TRICEPS_BRACHII, IsPrimary = true},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.CHEST },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.UPPER_CHEST },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.LATISSIMUS_DORSI },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.POSTERIOR_DELTOID },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.TERES_MAJOR },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.WRIST_FLEXORS },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Barbell Tricep Extension", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.TRICEPS_BRACHII, IsPrimary = true},
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Tricep Extension", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.TRICEPS_BRACHII, IsPrimary = true},
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Tricep Kickback", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.TRICEPS_BRACHII, IsPrimary = true},
                    },
                },

                //BICEPS
                new Exercise
                {
                    ExerciseName = "Barbell Curl", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.BICEPS_BRACHII, IsPrimary = true},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.BRACHIALIS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.BRACHIORADIALIS }
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Curl", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.BICEPS_BRACHII, IsPrimary = true},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.BRACHIALIS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.BRACHIORADIALIS }
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Incline Curl", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.BICEPS_BRACHII, IsPrimary = true},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.BRACHIALIS },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.BRACHIORADIALIS }
                    },
                },
                new Exercise
                {
                    ExerciseName = "Barbell Preacher Curl", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.BRACHIALIS, IsPrimary = true},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.BICEPS_BRACHII },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.BRACHIORADIALIS }
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Concentration Curl", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.BRACHIALIS, IsPrimary = true},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.BICEPS_BRACHII },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.BRACHIORADIALIS }
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Preacher Curl", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroup>
                    {
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.BRACHIALIS, IsPrimary = true},
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.BICEPS_BRACHII },
                        new ExerciseMuscleGroup {ExerciseMuscleGroupName = EMG.BRACHIORADIALIS }
                    },
                },
            };

        }
    }
}
