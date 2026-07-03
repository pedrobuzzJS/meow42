using Microsoft.EntityFrameworkCore;
using meow42_api.Abstracts;
using meow42_api.Interfaces;
using meow42_api.Models;

namespace meow42_api.Data;

public class AppDbContext : DbContext
{
    private readonly ITenantService _tenantService;

    public AppDbContext(DbContextOptions<AppDbContext> options, ITenantService tenantService) : base(options)
    {
        _tenantService = tenantService;
    }
    public override int SaveChanges()
    {
        AddTimeStamps();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AddTimeStamps();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void AddTimeStamps()
    {
        var now = DateTime.UtcNow;

        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is not BaseModel baseEntity) continue;

            if (entry.State == EntityState.Added)
            {
                if (entry.HasMappedProperty(nameof(baseEntity.CreatedAt)))
                    baseEntity.CreatedAt = now;

                if (entry.HasMappedProperty(nameof(baseEntity.UpdatedAt)))
                    baseEntity.UpdatedAt = null;
            } else if (entry.State == EntityState.Modified)
            {
                if (entry.HasMappedProperty(nameof(baseEntity.UpdatedAt)))
                    baseEntity.UpdatedAt = now;

                if (entry.HasMappedProperty(nameof(baseEntity.CreatedAt)))
                    entry.Property(nameof(baseEntity.CreatedAt)).IsModified = false;
            }
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        modelBuilder.Entity<Role>()
            .HasMany(role => role.Permissions)
            .WithMany(permission => permission.Roles)
            .UsingEntity(join => join.ToTable("tbrolepermission"));
        
        var entityTypes = modelBuilder.Model.GetEntityTypes().ToList();

        foreach (var entityType in entityTypes)
        {
            if (entityType.ClrType == null)
            {
                continue;
            }
        
            if (entityType.ClrType == typeof(Company))
            {
                continue;
            }
        
            if (!typeof(BaseModel).IsAssignableFrom(entityType.ClrType))
            {
                continue;
            }
        
            if (entityType.FindProperty("CompanyId") == null)
            {
                continue;
            }
            
            modelBuilder.Entity(entityType.ClrType)
                .HasOne(typeof(Company))
                .WithMany()
                .HasForeignKey("CompanyId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
    
    public DbSet<Archives> Archive { get; set; }
    public DbSet<Audit> Audit { get; set; }
    public DbSet<Banner> Banner { get; set; }
    public DbSet<BannerGroup>  BannerGroup { get; set; }
    public DbSet<Brand> Brand { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Company> Company { get; set; }
    public DbSet<Derivation> Derivation { get; set; }
    public DbSet<DerivationItem> DerivationItem { get; set; }
    public DbSet<DocumentSignature> DocumentSignature { get; set; }
    public DbSet<DocumentTemplate> DocumentTemplate { get; set; }
    public DbSet<Event>EEvent { get; set; }
    public DbSet<EventLocal>EEventLocal { get; set; }
    public DbSet<EventDate> EventDate { get; set; }
    public DbSet<Form> Form { get; set; }
    public DbSet<Inventory>IInventory { get; set; }
    public DbSet<InventoryMovement> InventoryMovement { get; set; }
    public DbSet<Log>LLog { get; set; }
    public DbSet<Menu>MMenu { get; set; }
    public DbSet<Module>MModule { get; set; }
    public DbSet<Page>PPage { get; set; }
    public DbSet<Permission>PPermission { get; set; }
    public DbSet<Person> Person { get; set; }
    public DbSet<PersonContact> PersonContact { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<ProductDerivation> ProductDerivation { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<Routine>RRoutine { get; set; }
    public DbSet<Setting>SSetting { get; set; }
    public DbSet<Ticket> Ticket { get; set; }
    public DbSet<TicketBatch> TicketBatch { get; set; }
    public DbSet<User>UUser { get; set; }
    public DbSet<UserNotification> UserNotification { get; set; }
    public DbSet<Webhook> Webhook { get; set; }
}