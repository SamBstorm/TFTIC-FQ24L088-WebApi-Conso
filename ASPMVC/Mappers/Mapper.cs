using ASPMVC.Models.ViewModels;
using ApiService.Entities;

namespace ASPMVC.Mappers
{
    public static class Mapper
    {
        public static TacheListItem ToListItem(this Tache tache) {
            if(tache is null) throw new ArgumentNullException(nameof(tache));
            return new TacheListItem()
            {
                Id = tache.Id,
                Titre = tache.Titre
            };
        }
        public static TacheDetails ToDetails(this Tache tache)
        {
            if (tache is null) throw new ArgumentNullException(nameof(tache));
            return new TacheDetails()
            {
                Id = tache.Id,
                Titre = tache.Titre,
                DateCreation = tache.DateCreation,
                Status = tache.Status
            };
        }

        public static TacheDelete ToDelete(this Tache tache)
        {
            if (tache is null) throw new ArgumentNullException(nameof(tache));
            return new TacheDelete()
            {
                Titre = tache.Titre
            };
        }

        public static Tache ToApiEntity(this TacheCreateForm tache)
        {
            if (tache is null) throw new ArgumentNullException(nameof(tache));
            return new Tache()
            {
                Id = default!,
                Titre = tache.Titre,
                DateCreation = DateTime.Now,
                Status = "En Cours"
            };
        }

        public static TacheEditForm ToEditForm(this Tache tache)
        {
            if (tache is null) throw new ArgumentNullException(nameof(tache));
            return new TacheEditForm()
            {
                Titre = tache.Titre,
                Status = tache.Status
            };
        }

        public static Tache ToApiEntity(this TacheEditForm tache)
        {
            if (tache is null) throw new ArgumentNullException(nameof(tache));
            return new Tache()
            {
                Id = default!,
                Titre = tache.Titre,
                DateCreation = DateTime.Now,
                Status = tache.Status
            };
        }
    }
}
