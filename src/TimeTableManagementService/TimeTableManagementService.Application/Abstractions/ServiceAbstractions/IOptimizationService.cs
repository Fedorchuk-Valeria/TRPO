using TimetableManagement.Application.DTOs.OptimizationDTOs;

namespace TimetableManagement.Application.Abstractions.ServiceAbstractions;

public interface IOptimizationService
{
    Task<List<OptimizationResultDTO>> FindTimeforATask(OptimizationDTO dto, int userId);
}
