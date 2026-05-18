using System.ComponentModel.DataAnnotations;

namespace StudentCRUD.Models.Entities;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
    public String Mobile { get; set; }
}