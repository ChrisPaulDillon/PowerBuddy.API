using System.Collections.Generic;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.SeedData.MuscleGroups;

namespace PowerBuddy.Data.Context.SeedData.Exercises
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
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = "Quads"},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = "Hamstrings"},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = "Lower Back"},
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
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = "Lower Back"},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = "Upper Back"},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = "Hamstring"},
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
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = "Chest"},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = "Tricep"},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = "Anterior Deltoid"},
                    },
                    ExerciseSports = new List<ExerciseSport>
                    {
                        new ExerciseSport {ExerciseSportStr = "PowerLifting"},
                    },
                },
                new Exercise
                {
                    ExerciseName = "Overhead Press", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = "Anterior Deltoid"},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = "Tricep"},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = "Trapezius"},
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
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = "Quadricep"},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = "Glute"},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = "Abdominal"},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = "Upper Back"},
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
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = "Shoulder"},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = "Quadricep"},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = "Glute"},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = "Upper Back"},
                    },
                    ExerciseSports = new List<ExerciseSport>
                    {
                        new ExerciseSport {ExerciseSportStr = "Olympic WeightLifting"},
                    },
                },
                new Exercise
                {
                    ExerciseName = "Floor Press", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = "Shoulder"},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = "Chest"},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = "Tricep"},
                    },
                },
                new Exercise { ExerciseName = "Barbell Lunge", ExerciseTypeId = 2},
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
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.MEDIAL_DELTOID },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.TRICEPS_BRACHII },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.MIDDLE_TRAPEZIUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.LOWER_TRAPEZIUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.SERRATUS_ANTERIOR },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Barbell Front Raise", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.CHEST },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.MEDIAL_DELTOID },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.MIDDLE_TRAPEZIUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.LOWER_TRAPEZIUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.SERRATUS_ANTERIOR },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Military Press", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.CHEST },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.MEDIAL_DELTOID },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.MIDDLE_TRAPEZIUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.LOWER_TRAPEZIUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.SERRATUS_ANTERIOR },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Arnold Press", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.SUPRASPINATUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.TRICEPS_BRACHII },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.MEDIAL_DELTOID },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.MIDDLE_TRAPEZIUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.LOWER_TRAPEZIUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.SERRATUS_ANTERIOR },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Front Raise", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.CHEST },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.MEDIAL_DELTOID },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.MIDDLE_TRAPEZIUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.LOWER_TRAPEZIUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.SERRATUS_ANTERIOR },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Shoulder Press", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.SUPRASPINATUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.MEDIAL_DELTOID },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.MIDDLE_TRAPEZIUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.LOWER_TRAPEZIUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.SERRATUS_ANTERIOR },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Barbell Shoulder Press", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.SUPRASPINATUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.MEDIAL_DELTOID },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.MIDDLE_TRAPEZIUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.LOWER_TRAPEZIUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.SERRATUS_ANTERIOR },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Barbell Upright Row", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.MEDIAL_DELTOID, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.SUPRASPINATUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIALIS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BICEPS_BRACHII },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.MIDDLE_TRAPEZIUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.LOWER_TRAPEZIUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.SERRATUS_ANTERIOR },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.INFRASPINATUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.TERES_MINOR },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Lateral Raise", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.MEDIAL_DELTOID, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.SUPRASPINATUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.MIDDLE_TRAPEZIUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.LOWER_TRAPEZIUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.SERRATUS_ANTERIOR },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Upright Row", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.MEDIAL_DELTOID, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.SUPRASPINATUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIALIS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BICEPS_BRACHII },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.MIDDLE_TRAPEZIUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.LOWER_TRAPEZIUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.SERRATUS_ANTERIOR },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.INFRASPINATUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.TERES_MINOR },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Barbell Rear Delt Raise", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.POSTERIOR_DELTOID, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.LEVATOR_SCAPULAE },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.MEDIAL_DELTOID },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIALIS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BICEPS_BRACHII },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.UPPER_TRAPEZIUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIORADIALIS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.WRIST_FLEXORS },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Rear Delt Row", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.POSTERIOR_DELTOID, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.TERES_MINOR },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.MEDIAL_DELTOID },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIALIS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.MIDDLE_TRAPEZIUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.UPPER_TRAPEZIUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.RHOMBOIDS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIORADIALIS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIALIS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.INFRASPINATUS },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Rear Delt Fly", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.POSTERIOR_DELTOID, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.TERES_MINOR },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.MEDIAL_DELTOID },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.MIDDLE_TRAPEZIUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.UPPER_TRAPEZIUS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.RHOMBOIDS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.INFRASPINATUS },
                    },
                },

                //UPPER ARMS REGION

                new Exercise
                {
                    ExerciseName = "Barbell Bench Press (Close Grip)", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.TRICEPS_BRACHII, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.CHEST },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Barbell Incline Press (Close Grip)", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.TRICEPS_BRACHII, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.CHEST },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.UPPER_CHEST },
                    },
                },
                new Exercise
                {
                    ExerciseName = "JM Barbell Press", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.TRICEPS_BRACHII, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.CHEST },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.UPPER_CHEST },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Barbell Skull Crusher", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.TRICEPS_BRACHII, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.CHEST },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.UPPER_CHEST },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.LATISSIMUS_DORSI },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.POSTERIOR_DELTOID },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.TERES_MAJOR },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.WRIST_FLEXORS },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Skull Crusher", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.TRICEPS_BRACHII, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.CHEST },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.UPPER_CHEST },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.LATISSIMUS_DORSI },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.POSTERIOR_DELTOID },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.TERES_MAJOR },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.WRIST_FLEXORS },
                    },
                },
                new Exercise
                {
                    ExerciseName = "Barbell Tricep Extension", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.TRICEPS_BRACHII, IsPrimary = true},
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Tricep Extension", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.TRICEPS_BRACHII, IsPrimary = true},
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Tricep Kickback", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.TRICEPS_BRACHII, IsPrimary = true},
                    },
                },

                //BICEPS
                new Exercise
                {
                    ExerciseName = "Barbell Curl", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BICEPS_BRACHII, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIALIS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIORADIALIS }
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Curl", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BICEPS_BRACHII, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIALIS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIORADIALIS }
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Incline Curl", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BICEPS_BRACHII, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIALIS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIORADIALIS }
                    },
                },
                new Exercise
                {
                    ExerciseName = "Barbell Preacher Curl", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIALIS, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BICEPS_BRACHII },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIORADIALIS }
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Concentration Curl", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIALIS, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BICEPS_BRACHII },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIORADIALIS }
                    },
                },
                new Exercise
                {
                    ExerciseName = "Dumbbell Preacher Curl", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIALIS, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BICEPS_BRACHII },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIORADIALIS }
                    },
                },
            };

        }
    }
}
