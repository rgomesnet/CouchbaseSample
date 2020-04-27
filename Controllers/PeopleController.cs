namespace CouchbaseSample.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using CouchbaseSample.Models;

    public class PeopleController : Controller
    {
        private readonly IPeopleRepository repository;

        public PeopleController(IPeopleRepository repository)
        {
            this.repository = repository;
        }

        // GET: People
        public async Task<ActionResult> Index()
        {
            var people = await this.repository.List();
            return View(people);
        }

        // GET: People/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var person = await this.repository.Read(id);
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person newPerson)
        {
            try
            {
                this.repository.Create(newPerson);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: People/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var person = await this.repository.Read(id);
            return View(person);
        }

        // POST: People/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Person person)
        {
            try
            {
                await this.repository.Update(person);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: People/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            await this.repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}