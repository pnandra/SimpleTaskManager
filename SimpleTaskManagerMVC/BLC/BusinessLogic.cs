using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleTaskManagerMVC.Models;
using SimpleTaskManagerMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace SimpleTaskManagerMVC.BLC
{
    public class BusinessLogic : IBusinessLogic
    {
        //note to self:  This class and interface has to be registered under Startup.cs to be able inject/activate in home controller.
        private readonly SimpleTaskManagerMVCContext _context;
        private bool _disposed;

        public BusinessLogic(SimpleTaskManagerMVCContext context) // inject context
        {
            _context = context;
        }

        public List<SimpleTask> GetTasks()
        {
            return _context.SimpleTask.OrderBy(x => x.Name).ToList(); // if sorting was required, I'd command that from View.
        }
        
        public SimpleTask FindTaskById(int id)
        {
            return _context.SimpleTask.FirstOrDefault(m => m.Id == id);
        }

        public void AddTask(SimpleTask form)
        {
            if(form.DueDate < System.DateTime.Now)
            {
                throw new Exception("Due Date can not be in the past for new tasks");
            }
             _context.Add(form);
            _context.SaveChanges(); //if this was real application, I'd push this down to a separate Db Repository class.
        }

        public void UpdateTask(int id, SimpleTask form)
        {
            _context.Update(form);
            _context.SaveChanges();//if this was real application, I'd push this down to a separate Db Repository class.
        }

        public void DeleteTask(int id)
        {
            var simpleTask = _context.SimpleTask.Find(id);
            _context.SimpleTask.Remove(simpleTask);
            _context.SaveChanges(); _context.SaveChanges();//if this was real application, I'd push this down to a separate Db Repository class.
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
