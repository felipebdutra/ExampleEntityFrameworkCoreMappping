using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.EntityFrameworkCoreExample
{
    public class EntityExample : IAggregateRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}