using AutoMapper;
using Domain.Models;
using Repository.Repositories.Interfaces;
using Services.DTOs.Country;
using Services.Services.Interfaces;

namespace Services.Services
{
    public class CountryService : ICountryService
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _repo;
        public CountryService(IMapper mapper, ICountryRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task CreateAsync(CountryCreateDto country)=>await _repo.CreateAsync(_mapper.Map<Country>(country));
        public async Task DeleteAsync(int? id)=> await _repo.DeleteAsync(await _repo.GetByIdAsync(id));
        public async Task<IEnumerable<CountryDto>> GetAllAsync() => _mapper.Map<IEnumerable<CountryDto>>(await _repo.GetAllAsync());
        public async Task<CountryDto> GetById(int id) => _mapper.Map<CountryDto>(await _repo.GetByIdAsync(id));
        public async Task<IEnumerable<CountryDto>> SearchAsync(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return _mapper.Map<IEnumerable<CountryDto>>(await _repo.GetAllAsync());
            }
            return _mapper.Map<IEnumerable<CountryDto>>(await _repo.GetAllAsync(c => c.Name.Contains(searchText)));
        }
        public async Task SoftDeleteAsync(int? id) => await _repo.SoftDeleteAsync(id);
        public async Task UpdateAsync(int? id, CountryUpdateDto country)
        {
            if(id is null) throw new ArgumentNullException("Data is not found");
            var data = await _repo.GetByIdAsync(id) ?? throw new NullReferenceException("Data is not found");
            _mapper.Map(country, data);
            await _repo.UpdateAsync(data);
        }
    }
}
