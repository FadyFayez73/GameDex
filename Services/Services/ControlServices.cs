using Domain.Entities;
using Domain.Repositories;
using Services.Contracts;

namespace Services.Services
{
    public class ControlServices : IControlServices
    {
        private readonly IControlRepository _controlRepository;

        public ControlServices(IControlRepository controlRepository)
        {
            _controlRepository = controlRepository;
        }

        public async Task<(bool, Guid)> AddAsync(Control entity)
        {
            entity.ControlID = Guid.NewGuid();

            var result = await _controlRepository.AddAsync(entity);

            return (result, entity.ControlID);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var control = await _controlRepository.GetControlByIdAsync(id);
            if (control == null) return false;

            return await _controlRepository.DeleteAsync(control);
        }

        public async Task<bool> UpdateAsync(Control entity)
        {
            var result = await _controlRepository.UpdateAsync(entity);
            return result;
        }

        public async Task<IEnumerable<Control>> GetAllControlsAsync()
        {
            var controls = await _controlRepository.GetAllControlsAsync();
            return controls;
        }

        public async Task<Control?> GetControlByIdAsync(Guid id)
        {
            var control = await _controlRepository.GetControlByIdAsync(id);
            return control;
        }

        public async Task<IEnumerable<Control>> GetControlsByGameIdAsync(Guid gameId)
        {
            var controls = await _controlRepository.GetControlsByGameIdAsync(gameId);
            return controls;
        }

        public async Task<IEnumerable<Control>> GetControlsByTypeAsync(string controlType)
        {
            var controls = await _controlRepository.GetControlsByTypeAsync(controlType);
            return controls;
        }

        public async Task<IEnumerable<Control>> GetControlsByActionAsync(string action)
        {
            var controls = await _controlRepository.GetControlsByActionAsync(action);
            return controls;
        }
    }
}
