using ApiService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.Repositories
{
    public interface ITacheAsyncRepository
    {
        Task<IEnumerable<Tache>> GetAsync();
        Task<Tache> GetAsync(int id);
        Task<Tache> InsertAsync(Tache tache);
        Task UpdateAsync(int id, Tache tache);
        Task DeleteAsync(int id);
    }
}
