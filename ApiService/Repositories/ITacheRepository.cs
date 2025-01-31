using ApiService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.Repositories
{
    public interface ITacheRepository
    {
        IEnumerable<Tache> Get();
        Tache Get(int id);
        Tache Insert(Tache tache);
        void Update(int id, Tache tache);
        void Delete(int id);
    }
}
