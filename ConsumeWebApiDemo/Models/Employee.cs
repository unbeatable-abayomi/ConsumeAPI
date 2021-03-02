using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsumeWebApiDemo.Models
{
    
    public class Employee
    {
            
            [Required(ErrorMessage = "Employee ID is required")]
            [Display(Name = "Employee ID")]
            public int EmployeeId { get; set; }

            [Column("FirstName")]
            [Display(Name = "First Name")]
            [Required(ErrorMessage = "First name is required")]
            [StringLength(10, ErrorMessage = "FirstName Must Be less than 10 charactes")]
            public string FirstName { get; set; }

            [Column("LastName")]
            [Display(Name = "Last Name")]
            [Required(ErrorMessage = "Last name is required")]
            [StringLength(10, ErrorMessage = "Last Name Must Be less than 10 charactes")]
            public string LastName { get; set; }


            [Column("Title")]
            [Display(Name = "Title")]
            [Required(ErrorMessage = "Title is required")]
            [StringLength(10, ErrorMessage = "Title Must Be less than 10 charactes")]
            public string Title { get; set; }

            [Column("BirthDate")]
            [Display(Name = "Birth Date")]
            [Required(ErrorMessage = "Birth Date is required")]
            public DateTime BirthDate { get; set; }

            [Column("HireDate")]
            [Display(Name = "Hire Date")]
            [Required(ErrorMessage = "Hire Date is required")]
            public DateTime HireDate { get; set; }


            [Column("Country")]
            [Display(Name = "Country")]
            [Required(ErrorMessage = "Country is required")]
            [StringLength(15, ErrorMessage = "Country Name Must Be less than 15 charactes")]
            public string Country { get; set; }

            [Column("Note")]
            [Display(Name = "Notes")]
            [StringLength(500, ErrorMessage = "Note Must Be less than 500 charactes")]
            public string Note { get; set; }


            //public Employee()
            //{
            //}
        }
   
}
