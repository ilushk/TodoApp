using TodoApp.Models;

namespace TodoApp
{
    internal class TodoModel : TodoMode
    {
        public string Text { get; set; }
        public bool IsDone { get; internal set; }
    }
}