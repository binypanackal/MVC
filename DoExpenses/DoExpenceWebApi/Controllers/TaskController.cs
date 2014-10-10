using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DoExpenceses.DoExpencesesDAL;
using DoExpenceses.DoExpensesDto;

namespace DoExpenceses.Controllers
{
    public class TaskController : ApiController
    {
        // GET api/task
      
        public IEnumerable<Task> Get()
        {
            TaskExpence taskExpence = new TaskExpence();
            List<Task> tasks = taskExpence.GetTasks();
            List<CompletedTask> completedTasks = taskExpence.GetCompletedTasks();
            var _nonCompletedTasks = from a in tasks
                                     where !(from b in completedTasks
                                             where b.TaskID == a.TaskID
                                             select b.TaskID)
                                               .Contains(a.TaskID)
                                     select a;

            return tasks.ToList();
        }

        // GET api/task/5
        public IEnumerable<Task> Get(int id)
        {
            TaskExpence taskExpence = new TaskExpence();
            List<Task> tasks = taskExpence.GetTasks();

            List<CompletedTask> completedTasks = taskExpence.GetCompletedTasks();
            var _nonCompletedTasks = from a in tasks
                                     where !(from b in completedTasks
                                             where b.TaskID == a.TaskID
                                             select b.TaskID)
                                             .Contains(a.TaskID)
                                     && (a.SheduledDate <= DateTime.Today.AddDays(7))
                                     select a;

            return _nonCompletedTasks;
        }

        // POST api/task
        public void Post([FromBody]string value)
        {
        }

        // PUT api/task/5
        public void Put(Task task)
        {
            TaskExpence taskExpence = new TaskExpence();
            taskExpence.CreateTask(task);
        }


        // PUT api/task/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/task/5
        public void Delete(int id)
        {
        }
    }
}
