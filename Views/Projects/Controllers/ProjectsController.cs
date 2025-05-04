using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ProjectManager.Models;
using ProjectManager.Services;

namespace ProjectManager.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET: /Projects
        public async Task<IActionResult> Index(string status)
        {
            var projects = await _projectService.GetAllAsync();

            if (!string.IsNullOrEmpty(status))
            {
                projects = projects.Where(p => p.Status.ToString() == status).ToList();
            }

            return View(projects);
        }

        // GET: /Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Project project)
        {
            if (ModelState.IsValid)
            {
                await _projectService.CreateAsync(project);
                TempData["ToastMessage"] = "✅ Projektet har sparats!";
                return RedirectToAction(nameof(Index));
            }

            return View(project);
        }

        // GET: /Projects/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var project = await _projectService.GetByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: /Projects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _projectService.UpdateAsync(project);
                TempData["ToastMessage"] = "✏️ Projektet har uppdaterats!";
                return RedirectToAction(nameof(Index));
            }

            return View(project);
        }

        // POST: /Projects/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _projectService.DeleteAsync(id);
            TempData["ToastMessage"] = "🗑️ Projektet har tagits bort!";
            return RedirectToAction(nameof(Index));
        }
    }
}
