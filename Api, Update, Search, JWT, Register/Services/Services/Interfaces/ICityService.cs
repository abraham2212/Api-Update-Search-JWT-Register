using Services.DTOs.City;


namespace Services.Services.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<CityDto>> GetAllAsync();
        Task<CityDto> GetByIdAsync(int? id);
        Task CreateAsync(CityCreateDto entity); 
        Task UpdateAsync(int? id,CityUpdateDto entity);
        Task DeleteAsync(int? id);
        Task SoftDeleteAsync(int? id);
        Task<IEnumerable<CityDto>> SearchAsync(string searchText);
    }
}
