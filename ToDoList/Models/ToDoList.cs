using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ToDoList.Models
{
    public class ToDoList : IModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Введи задачу")]
        public string Task { get; set; }
    }
}