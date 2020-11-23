using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleTaskManagerMVC.Models;
using SimpleTaskManagerMVC.BLC;

namespace SimpleTaskManagerMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBusinessLogic _businessLogic;

        public HomeController(ILogger<HomeController> logger, IBusinessLogic businessLogic)
        {
            _logger = logger;
            _businessLogic = businessLogic;  //inject IBusinessLogic
        }

        public IActionResult Index()
        {
            return View(_businessLogic.GetTasks());
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SimpleTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,DueDate,Completed")] SimpleTask simpleTask)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _businessLogic.AddTask(simpleTask);
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    HandleException(ex);
                }                
            }
            return View(simpleTask);
        }

        // GET: SimpleTasks/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var simpleTask = _businessLogic.FindTaskById(id.Value);
            if (simpleTask == null)
            {
                return NotFound();
            }
            return View(simpleTask);
        }

        // POST: SimpleTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,DueDate,Completed")] SimpleTask simpleTask)
        {
            if (id != simpleTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _businessLogic.UpdateTask(id, simpleTask);  
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
            return Edit(id);
        }

        // GET: SimpleTasks/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var simpleTask = _businessLogic.FindTaskById(id.Value);
            if (simpleTask == null)
            {
                return NotFound();
            }

            return View(simpleTask);
        }

        // POST: SimpleTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _businessLogic.DeleteTask(id);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            
            return RedirectToAction(nameof(Index));
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(Exception exception = null)
        {
            if(exception != null)
            {
                return View(new ErrorViewModel(exception));
            }
            return View(new ErrorViewModel(requestId: Activity.Current?.Id ?? HttpContext.TraceIdentifier));
        }

        private void HandleException(Exception exception)
        {
            //handling exceptions at this level.   These exception might have been thrown inside the Business Logic.
           Error(exception);  
        }
    }
}
