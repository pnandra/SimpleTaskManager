using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleTaskManagerMVC.Models;


namespace SimpleTaskManagerMVC.BLC
{
    public interface IBusinessLogic : IDisposable
    {
        List<SimpleTask> GetTasks();
        SimpleTask FindTaskById(int id);
        void AddTask(SimpleTask form);
        void UpdateTask(int id, SimpleTask form);
        void DeleteTask(int id);
    }
}
