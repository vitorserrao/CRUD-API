using ApiCrud.Enum;
namespace ApiCrud.Models

{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public StatusTask Status { get; set; }

    }
}
