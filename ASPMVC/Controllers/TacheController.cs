using ApiService.Entities;
using ApiService.Repositories;
using ASPMVC.Mappers;
using ASPMVC.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPMVC.Controllers
{
    public class TacheController : Controller
    {
        private ITacheAsyncRepository _service;
        public TacheController(ITacheAsyncRepository repo)
        {
            _service = repo;
        }
        // GET: TacheController
        public async Task<IActionResult> Index()
        {
            IEnumerable<Tache> datas  = await _service.GetAsync();
            IEnumerable<TacheListItem> model = datas.Select(data => data.ToListItem());
            return View(model);
        }

        // GET: TacheController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Tache data = await _service.GetAsync(id);
            TacheDetails model = data.ToDetails();
            return View(model);
        }

        // GET: TacheController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TacheController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TacheCreateForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException(nameof(form));
                Tache tache = await _service.InsertAsync(form.ToApiEntity());
                return RedirectToAction(nameof(Details), new { id = tache.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: TacheController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Tache data = await _service.GetAsync(id);
            TacheEditForm model = data.ToEditForm();
            return View(model);
        }

        // POST: TacheController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TacheEditForm form)
        {
            try
            {
                if(!ModelState.IsValid) throw new ArgumentException(nameof (form));
                Tache data = form.ToApiEntity();
                data.Id = id;
                await _service.UpdateAsync(id, data);
                return RedirectToAction(nameof(Details), new { id });
            }
            catch
            {
                return RedirectToAction(nameof(Edit),id);
            }
        }

        // GET: TacheController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Tache tache = await _service.GetAsync(id);
            TacheDelete model = tache.ToDelete();
            return View(model);
        }

        // POST: TacheController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, TacheDelete collection)
        {
            try
            {
                await _service.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Delete),id);
            }
        }
    }
}
