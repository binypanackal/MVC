using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DoExpenceses.DoExpensesDto;
using DoExpenceses.DoExpensesEntity;

namespace DoExpenceses.DoExpencesesDAL
{
    public class TaskExpence
    {
        public List<Category> GetCategory()
        {
            DoExpencesesAngualarEntitiesConnection _dbEntities = new DoExpencesesAngualarEntitiesConnection();
            return _dbEntities.Categories.ToList();
        }
        public List<Task> GetTasks()
        {
            DoExpencesesAngualarEntitiesConnection _dbEntities = new DoExpencesesAngualarEntitiesConnection();
            return _dbEntities.Tasks.ToList();
        }


        public Task GetTask(long taskID)
        {
            DoExpencesesAngualarEntitiesConnection _dbEntities = new DoExpencesesAngualarEntitiesConnection();
            return _dbEntities.Tasks.Find(taskID);
        }

        public List<CompletedTask> GetCompletedTasks()
        {
            DoExpencesesAngualarEntitiesConnection _dbEntities = new DoExpencesesAngualarEntitiesConnection();
            return _dbEntities.CompletedTasks.ToList();
        }

        public void GetTasksAsPerDate(DateTime sheduledDate)
        {
        }

        public void CreateCategory()
        {
        }

        public void CreateTask(Task task)
        {
            DoExpencesesAngualarEntitiesConnection _dbEntities = new DoExpencesesAngualarEntitiesConnection();
            _dbEntities.Tasks.Add(task);
            _dbEntities.SaveChanges();
        }

        public void CompleteTaks(CompletedTask compltedTask)
        {
            DoExpencesesAngualarEntitiesConnection _dbEntities = new DoExpencesesAngualarEntitiesConnection();
            _dbEntities.CompletedTasks.Add(compltedTask);
            _dbEntities.SaveChanges();

        }

        public void CreateUser(UserDetail userDetails)
        {
            DoExpencesesAngualarEntitiesConnection _dbEntities = new DoExpencesesAngualarEntitiesConnection();
            _dbEntities.UserDetails.Add(userDetails);
            _dbEntities.SaveChanges();
        }

        public UserDetail verifyLogin(UserDetail userDetails)
        {
            DoExpencesesAngualarEntitiesConnection _dbEntities = new DoExpencesesAngualarEntitiesConnection();
            UserDetail userdetail = _dbEntities.UserDetails.SingleOrDefault(x => x.UserName == userDetails.UserName && x.Password == userDetails.Password);
            return userdetail;
        }
    }
}
