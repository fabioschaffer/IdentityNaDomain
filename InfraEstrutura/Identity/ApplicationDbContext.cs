using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfraEstrutura.Identity;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options) {
    }

    protected override void OnModelCreating(ModelBuilder builder) {
        base.OnModelCreating(builder);

        // Exemplo de customização
        builder.Entity<ApplicationUser>(entity => {
            entity.Property(x => x.NomeCompleto)
                  .HasMaxLength(200)
                  .IsRequired();
        });
    }
}
