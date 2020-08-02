﻿using AutoMapper;
using PowerLifting.Data.DTOs.System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.Entities.Exercises;
using PowerLifting.Data.Exceptions.Exercises;
using PowerLifting.Persistence;

namespace PowerLifting.Exercises.Service
{
    public class ExerciseService : IExerciseService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public ExerciseService(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExerciseDTO>> GetAllExercises()
        {
            return await _context.Set<Exercise>()
                .Where(x => x.IsApproved)
                .ProjectTo<ExerciseDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<ExerciseDTO>> GetAllUnapprovedExercises()
        {
            return await _context.Exercise.Where(x => !x.IsApproved)
                .AsNoTracking()
                .ProjectTo<ExerciseDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<TopLevelExerciseDTO>> GetAllExercisesBySport(string exerciseSport)
        {
            return await _context.Set<Exercise>()
                .Where(x => x.ExerciseSports.Any(x => x.ExerciseSportStr == exerciseSport))
                .ProjectTo<TopLevelExerciseDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Exercise> GetExerciseById(int id)
        {
            var exercise = await _context.Set<Exercise>()
                .Where(x => x.ExerciseId == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if(exercise == null) throw new ExerciseNotFoundException();

            return exercise;
        }

        public async Task<Exercise> CreateExercise(CExerciseDTO exerciseDTO)
        {
            var doesExist = await _context.Set<Exercise>()
                .AsNoTracking()
                .AnyAsync(x => x.ExerciseName == exerciseDTO.ExerciseName);

            if (doesExist) throw new ExerciseAlreadyExistsException();

            var exercise = _mapper.Map<Exercise>(exerciseDTO);
            _context.Add(exercise);
            await _context.SaveChangesAsync();

            return exercise;
        }

        public async Task<bool> UpdateExercise(ExerciseDTO exerciseDTO)
        {
            var doesExerciseExist = await _context.Set<Exercise>()
                .AsNoTracking()
                .AnyAsync(x => x.ExerciseId == exerciseDTO.ExerciseId);

            if (!doesExerciseExist) throw new ExerciseNotFoundException();
             
            var exercise = _mapper.Map<Exercise>(exerciseDTO);
            _context.Update(exercise);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }

        public async Task<bool> DeleteExercise(ExerciseDTO exerciseDTO)
        {
            var doesExerciseExist =  await _context.Set<Exercise>()
                .AsNoTracking()
                .AnyAsync(x => x.ExerciseId == exerciseDTO.ExerciseId);
            
            if (!doesExerciseExist) throw new ExerciseNotFoundException();

            var exercise = _mapper.Map<Exercise>(exerciseDTO);
            _context.Remove(exercise);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }
    }
}