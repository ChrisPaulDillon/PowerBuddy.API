using System.Collections.Generic;
using PowerLifting.Data.Entities.Exercises;
using PowerLifting.Data.SeedData.MuscleGroups;

namespace PowerLifting.Data.SeedData.Exercises
{
    public static class ExerciseSeed
    {
        public static Exercise[] CreateExercises()
        {
            return new Exercise[]
            {
                new Exercise
                {
                    ExerciseId = 1, ExerciseName = "Back Squat", ExerciseTypeId = 2,
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
                    ExerciseId = 2, ExerciseName = "DeadLift", ExerciseTypeId = 2,
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
                    ExerciseId = 3, ExerciseName = "Bench Press", ExerciseTypeId = 2,
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
                    ExerciseId = 4, ExerciseName = "Overhead Press", ExerciseTypeId = 2,
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
                    ExerciseId = 5, ExerciseName = "Front Squat", ExerciseTypeId = 2,
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
                    ExerciseId = 6, ExerciseName = "Overhead Squat", ExerciseTypeId = 2,
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
                    ExerciseId = 7, ExerciseName = "Floor Press", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = "Shoulder"},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = "Chest"},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = "Tricep"},
                    },
                },
                new Exercise {ExerciseId = 8, ExerciseName = "Barbell Lunge", ExerciseTypeId = 2},
                new Exercise {ExerciseId = 9, ExerciseName = "Incline Bench Press", ExerciseTypeId = 2},
                new Exercise {ExerciseId = 10, ExerciseName = "Decline Bench Press", ExerciseTypeId = 2},
                new Exercise {ExerciseId = 11, ExerciseName = "Good Morning", ExerciseTypeId = 2},
                new Exercise {ExerciseId = 12, ExerciseName = "Stiff Leg Deadlift", ExerciseTypeId = 2},
                new Exercise {ExerciseId = 13, ExerciseName = "Sumo Deadlift", ExerciseTypeId = 2},
                new Exercise {ExerciseId = 14, ExerciseName = "Snatch", ExerciseTypeId = 2},
                new Exercise {ExerciseId = 15, ExerciseName = "Hang Snatch", ExerciseTypeId = 2},
                new Exercise {ExerciseId = 16, ExerciseName = "Power Snatch", ExerciseTypeId = 2},
                new Exercise {ExerciseId = 17, ExerciseName = "Clean & Press", ExerciseTypeId = 2},
                new Exercise {ExerciseId = 18, ExerciseName = "Clean & Jerk", ExerciseTypeId = 2},
                new Exercise {ExerciseId = 19, ExerciseName = "Clean", ExerciseTypeId = 2},
                new Exercise {ExerciseId = 20, ExerciseName = "Hang Clean", ExerciseTypeId = 2},
                new Exercise {ExerciseId = 21, ExerciseName = "Power Clean", ExerciseTypeId = 2},
                new Exercise {ExerciseId = 22, ExerciseName = "Jerk", ExerciseTypeId = 2},
                new Exercise {ExerciseId = 23, ExerciseName = "Power Jerk", ExerciseTypeId = 2},
                new Exercise {ExerciseId = 24, ExerciseName = "Barbell Row", ExerciseTypeId = 2},
                new Exercise {ExerciseId = 25, ExerciseName = "Pendlay Row", ExerciseTypeId = 2},
                new Exercise {ExerciseId = 26, ExerciseName = "T-Bar Row", ExerciseTypeId = 2},

                //shoulder region
                new Exercise
                {
                    ExerciseId = 27, ExerciseName = "Barbell Press (Behind The Neck)", ExerciseTypeId = 2,
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
                    ExerciseId = 28, ExerciseName = "Barbell Front Raise", ExerciseTypeId = 2,
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
                    ExerciseId = 29, ExerciseName = "Military Press", ExerciseTypeId = 2,
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
                    ExerciseId = 30, ExerciseName = "Dumbbell Arnold Press", ExerciseTypeId = 1,
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
                    ExerciseId = 31, ExerciseName = "Dumbbell Front Raise", ExerciseTypeId = 1,
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
                    ExerciseId = 32, ExerciseName = "Dumbbell Shoulder Press", ExerciseTypeId = 1,
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
                    ExerciseId = 33, ExerciseName = "Barbell Shoulder Press", ExerciseTypeId = 2,
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
                    ExerciseId = 34, ExerciseName = "Barbell Upright Row", ExerciseTypeId = 2,
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
                    ExerciseId = 35, ExerciseName = "Dumbbell Lateral Raise", ExerciseTypeId = 1,
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
                    ExerciseId = 36, ExerciseName = "Dumbbell Upright Row", ExerciseTypeId = 2,
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
                    ExerciseId = 37, ExerciseName = "Barbell Rear Delt Raise", ExerciseTypeId = 2,
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
                    ExerciseId = 38, ExerciseName = "Dumbbell Rear Delt Row", ExerciseTypeId = 1,
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
                    ExerciseId = 39, ExerciseName = "Dumbbell Rear Delt Fly", ExerciseTypeId = 1,
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
                    ExerciseId = 40, ExerciseName = "Barbell Bench Press (Close Grip)", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.TRICEPS_BRACHII, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.ANTERIOR_DELTOID },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.CHEST },
                    },
                },
                new Exercise
                {
                    ExerciseId = 41, ExerciseName = "Barbell Incline Press (Close Grip)", ExerciseTypeId = 2,
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
                    ExerciseId = 42, ExerciseName = "JM Barbell Press", ExerciseTypeId = 2,
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
                    ExerciseId = 43, ExerciseName = "Barbell Skull Crusher", ExerciseTypeId = 2,
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
                    ExerciseId = 44, ExerciseName = "Dumbbell Skull Crusher", ExerciseTypeId = 1,
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
                    ExerciseId = 45, ExerciseName = "Barbell Tricep Extension", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.TRICEPS_BRACHII, IsPrimary = true},
                    },
                },
                new Exercise
                {
                    ExerciseId = 46, ExerciseName = "Dumbbell Tricep Extension", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.TRICEPS_BRACHII, IsPrimary = true},
                    },
                },
                new Exercise
                {
                    ExerciseId = 47, ExerciseName = "Dumbbell Tricep Kickback", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.TRICEPS_BRACHII, IsPrimary = true},
                    },
                },

                //BICEPS
                new Exercise
                {
                    ExerciseId = 48, ExerciseName = "Barbell Curl", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BICEPS_BRACHII, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIALIS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIORADIALIS }
                    },
                },
                new Exercise
                {
                    ExerciseId = 49, ExerciseName = "Dumbbell Curl", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BICEPS_BRACHII, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIALIS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIORADIALIS }
                    },
                },
                new Exercise
                {
                    ExerciseId = 50, ExerciseName = "Dumbbell Incline Curl", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BICEPS_BRACHII, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIALIS },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIORADIALIS }
                    },
                },
                new Exercise
                {
                    ExerciseId = 51, ExerciseName = "Barbell Preacher Curl", ExerciseTypeId = 2,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIALIS, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BICEPS_BRACHII },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIORADIALIS }
                    },
                },
                new Exercise
                {
                    ExerciseId = 52, ExerciseName = "Dumbbell Concentration Curl", ExerciseTypeId = 1,
                    ExerciseMuscleGroups = new List<ExerciseMuscleGroupAssoc>
                    {
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIALIS, IsPrimary = true},
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BICEPS_BRACHII },
                        new ExerciseMuscleGroupAssoc {ExerciseMuscleGroupName = EMG.BRACHIORADIALIS }
                    },
                },
                new Exercise
                {
                    ExerciseId = 53, ExerciseName = "Dumbbell Preacher Curl", ExerciseTypeId = 1,
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
