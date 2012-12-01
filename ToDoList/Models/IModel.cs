namespace ToDoList.Models
{
    public interface IModel
    {
        int Id { get; set; }
        string Task { get; set; }
    }
}