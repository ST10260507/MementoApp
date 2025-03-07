using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Memento.Models;

namespace Memento.Controllers
{
    public class EditorController : Controller
    {
        private static readonly Editor editor = new Editor();
        private static readonly History history = new History();

        public IActionResult Index()
        {
            ViewBag.Content = editor.Content;
            ViewBag.CanUndo = history.CanUndo();
            ViewBag.History = history.GetHistory();
            return View();
        }

        [HttpPost]
        public IActionResult Save(string content)
        {
            editor.Content = content;
            history.Save(editor.Save());
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Undo()
        {
            var memento = history.Undo();  // Removes last saved state

            if (history.CanUndo()) // If there are still items in history
            {
                editor.Restore(history.GetPeek()); // Restore previous state
            }
            else
            {
                editor.Content = ""; // If no history remains, clear the editor
            }

            return RedirectToAction("Index");
        }
    }
}