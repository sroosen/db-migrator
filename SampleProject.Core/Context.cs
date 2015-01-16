using System.Data.Entity;

namespace SampleProject.Core
{
    public class Context : DbContext
    {
        public virtual DbSet<Train> Trains { get; set; }
    }
}
