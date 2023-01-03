using System.ComponentModel;
namespace ApiCrud.Enum
{
    public enum StatusTask
    {
        [Description("Tarefa a fazer")]
        Backlog = 1,
        [Description("Tarefa sendo realizada")]
        Doing = 2,
        [Description("Tarefa finalizada")]
        Done = 3
    }
}
