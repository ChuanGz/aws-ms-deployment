using Microsoft.EntityFrameworkCore;

namespace User.Api.Data;

public class MT_DB_UserContext : DbContext
{
    public MT_DB_UserContext() { }

    public MT_DB_UserContext(DbContextOptions<MT_DB_UserContext> options)
        : base(options) { }

    public virtual DbSet<Entities.User> Users { get; set; }
    public virtual DbSet<Entities.UserGroup> UserGroups { get; set; }
}
