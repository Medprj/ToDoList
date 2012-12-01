using System.Web.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    // Тестовое задание "ToDoList"
    // Автор: Медведев А.А.
    // 01.12.2012
    public class ListController : Controller
    {
        private readonly RavenDb _ravenDb;

        public ListController()
        {
            _ravenDb = new RavenDb();
        }

        public ActionResult Index()
        {
            var allTasks = _ravenDb.GetAll<Models.ToDoList>();
            
            return View(allTasks);
        }

        public ActionResult AddTask(string newTask)
        {
            if (newTask != "")
            {
                _ravenDb.Save(new Models.ToDoList{Task = newTask});
            }
            return RedirectToAction("Index", "List");
        }

        [HttpPost]
        public ActionResult RemoveTask(int taskId)
        {                     
            _ravenDb.Delete(new Models.ToDoList {Id = taskId});
            return RedirectToAction("Index", "List");
        }
    }
}
