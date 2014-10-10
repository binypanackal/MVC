using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DoExpenceses.DoExpensesDto
{

    public partial class Category
    {
        public Category()
        {
            this.Tasks = new HashSet<Task>();
        }
    
        public int CategoryID { get; set; }
        public string CategoryTitle { get; set; }
        public int CategoryStatus { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> UserID { get; set; }
    
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual UserDetail UserDetail { get; set; }
    }


    public partial class CompletedTask
    {
        public int CompletedTaskID { get; set; }
        public int TaskID { get; set; }
        public Nullable<System.DateTime> CompletedDate { get; set; }
        public Nullable<System.DateTime> SheduledDate { get; set; }
        public Nullable<int> DifferenceMargin { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<decimal> Expence { get; set; }
        public Nullable<int> UserID { get; set; }

        public virtual Task Task { get; set; }
        public virtual UserDetail UserDetail { get; set; }
    }




    public partial class Task
    {
        public Task()
        {
            this.CompletedTasks = new HashSet<CompletedTask>();
        }

        public int TaskID { get; set; }
        public int CategoryID { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> SheduledDate { get; set; }
        public string RecuringType { get; set; }
        public Nullable<decimal> Expence { get; set; }
        public int TaskStatus { get; set; }
        public Nullable<int> UserID { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<CompletedTask> CompletedTasks { get; set; }
        public virtual UserDetail UserDetail { get; set; }
    }

    public partial class UserDetail
    {
        public UserDetail()
        {
            this.Categories = new HashSet<Category>();
            this.CompletedTasks = new HashSet<CompletedTask>();
            this.Tasks = new HashSet<Task>();
        }

        public int UserID { get; set; }
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name is required.")]
        public string UserName { get; set; }
     
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Email ID is required.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string EmaillID { get; set; }
        
        public int Status { get; set; }
        public System.DateTime CreateDate { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<CompletedTask> CompletedTasks { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }

}
