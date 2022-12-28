using Microsoft.EntityFrameworkCore;
using PartnerPortal.Domain.Entities;

namespace PartnerPortal.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; }

        DbSet<TodoItem> TodoItems { get; }
        DbSet<SalesPerson> SalesPersons { get; }
        DbSet<ProjectManager> ProjectManagers { get; }
        DbSet<Skil> Skills { get; }
        DbSet<Department> Departments { get; }
        DbSet<Currency> Currencies { get; }
        DbSet<Country> Countries { get; }
        DbSet<Partner> Partners { get; }
        DbSet<RequisitionSkill> RequisitionSkills { get; }
        DbSet<RequisitionPartner> RequisitionPartners { get; }
        DbSet<RequisitionJD> RequisitionJDs { get; }
        DbSet<RequisitionFile> RequisitionFiles { get; }
        DbSet<Requisition> Requisitions { get; }
        DbSet<Count> Counts { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
