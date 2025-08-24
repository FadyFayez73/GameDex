using Domain.Entities;
using Services.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IControlServices : IBaseServices<Control>
    {
        Task<IEnumerable<Control>> GetAllControlsAsync();
        Task<Control?> GetControlByIdAsync(Guid id);
        Task<IEnumerable<Control>> GetControlsByGameIdAsync(Guid gameId);
        Task<IEnumerable<Control>> GetControlsByTypeAsync(string controlType);
        Task<IEnumerable<Control>> GetControlsByActionAsync(string action);
    }
}
