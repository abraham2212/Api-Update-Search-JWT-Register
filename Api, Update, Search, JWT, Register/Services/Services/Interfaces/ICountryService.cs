using Services.DTOs.Country;


namespace Services.Services.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDto>> GetAllAsync();
        Task<CountryDto> GetById(int id);
        Task CreateAsync(CountryCreateDto country);
        Task DeleteAsync(int? id);
        Task SoftDeleteAsync(int? id);
        Task UpdateAsync(int? id, CountryUpdateDto country);
        Task<IEnumerable<CountryDto>> SearchAsync(string searchText);
    }
}
