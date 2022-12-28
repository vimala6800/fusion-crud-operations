using Duende.IdentityServer.EntityFramework.Options;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Domain.Entities;
using PartnerPortal.Infrastructure.Identity;
using PartnerPortal.Infrastructure.Persistence.Interceptors;
using System.Numerics;
using System.Reflection;

namespace PartnerPortal.Infrastructure.Persistence
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly IMediator _mediator;
        private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            IMediator mediator,
            AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
            : base(options, operationalStoreOptions)
        {
            _mediator = mediator;
            _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        }

        public DbSet<TodoList> TodoLists => Set<TodoList>();

        public DbSet<TodoItem> TodoItems => Set<TodoItem>();
        public DbSet<SalesPerson> SalesPersons => Set<SalesPerson>();
        public DbSet<ProjectManager> ProjectManagers => Set<ProjectManager>();
        public DbSet<Skil> Skills=> Set<Skil>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Currency> Currencies => Set<Currency>();
        public DbSet<Country> Countries => Set<Country>();
        public DbSet<Partner> Partners => Set<Partner>();
        public DbSet<RequisitionFile> RequisitionFiles => Set<RequisitionFile>();
        public DbSet<RequisitionJD> RequisitionJDs => Set<RequisitionJD>();
        public DbSet<RequisitionPartner> RequisitionPartners => Set<RequisitionPartner>();
        public DbSet<RequisitionSkill> RequisitionSkills => Set<RequisitionSkill>();
        public DbSet<Requisition> Requisitions => Set<Requisition>();
        public DbSet<Count> Counts => Set<Count>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEvents(this);

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
