using AutoMapper;
using Domain.Models;
using Repository.Repositories.Interfaces;
using Services.DTOs.City;
using Services.Services.Interfaces;

namespace Services.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _repo;
        private readonly IMapper _mapper;
        public CityService(ICityRepository repo,
                           IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task CreateAsync(CityCreateDto entity) => await _repo.CreateAsync(_mapper.Map<City>(entity));

        public async Task DeleteAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException("Data is not found");
            await _repo.DeleteAsync(await _repo.GetByIdAsync(id));
        }

        public async Task<IEnumerable<CityDto>> GetAllAsync() => _mapper.Map<IEnumerable<CityDto>>(await _repo.GetAllAsync());

        public async Task<CityDto> GetByIdAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException("Data is not found");
            return _mapper.Map<CityDto>(await _repo.GetByIdAsync(id));
        }

        public async Task<IEnumerable<CityDto>> SearchAsync(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return _mapper.Map<IEnumerable<CityDto>>(await _repo.GetAllAsync());
            }
            return _mapper.Map<IEnumerable<CityDto>>(await _repo.GetAllAsync(c => c.Name.Trim().Contains(searchText)));
        }

        public async Task SoftDeleteAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException("Data is not found");
            await _repo.SoftDeleteAsync(id);
        }

        public async Task UpdateAsync(int? id, CityUpdateDto entity)
        {
            if (id is null) throw new ArgumentNullException("Data is not found");
            var data = await _repo.GetByIdAsync(id) ?? throw new NullReferenceException("Data is not found");
            _mapper.Map(entity, data);
            await _repo.UpdateAsync(data);
        }
    }
}
