using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementProject.Models;

public partial class AssetManagementDB : DbContext
{
    public AssetManagementDB()
    {
    }

    public AssetManagementDB(DbContextOptions<AssetManagementDB> options)
        : base(options)
    {
    }

    public virtual DbSet<Asset> Assets { get; set; }

    public virtual DbSet<AssetSpec> AssetSpecs { get; set; }

    public virtual DbSet<AssetType> AssetTypes { get; set; }

    public virtual DbSet<AssetUpdate> AssetUpdates { get; set; }

    public virtual DbSet<AssetVulnerability> AssetVulnerabilities { get; set; }

    public virtual DbSet<Audit> Audits { get; set; }

    public virtual DbSet<AuditReport> AuditReports { get; set; }

    public virtual DbSet<AuditTeam> AuditTeams { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Issuance> Issuances { get; set; }

    public virtual DbSet<Maintenance> Maintenances { get; set; }

    public virtual DbSet<MaintenanceReport> MaintenanceReports { get; set; }

    public virtual DbSet<MaintenanceTeam> MaintenanceTeams { get; set; }

    public virtual DbSet<Reporting> Reportings { get; set; }

    public virtual DbSet<TechnicalSpec> TechnicalSpecs { get; set; }

    public virtual DbSet<Tracking> Trackings { get; set; }

    public virtual DbSet<Transfer> Transfers { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    public virtual DbSet<Vulnerability> Vulnerabilities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-50P7ET3\\SQLEXPRESS;Database=AssetManagement;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asset>(entity =>
        {
            entity.HasKey(e => e.AssetId).HasName("PK__Asset__D28B561D0931D235");

            entity.ToTable("Asset");

            entity.Property(e => e.AssetId).HasColumnName("asset_id");
            entity.Property(e => e.AssetName)
                .HasMaxLength(255)
                .HasColumnName("asset_name");
            entity.Property(e => e.AssetType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("asset_type");
            entity.Property(e => e.AssetTypeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("asset_type_id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.IssuanceId).HasColumnName("issuance_id");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.StoreItemCode)
                .HasMaxLength(255)
                .HasColumnName("Store_Item_Code");
            entity.Property(e => e.StoreItemId)
                .HasMaxLength(255)
                .HasColumnName("Store_Item_ID");
            entity.Property(e => e.VendorId).HasColumnName("vendor_id");
            entity.Property(e => e.WarrantyEnd).HasColumnName("warranty_end");

            entity.HasOne(d => d.AssetTypeNavigation).WithMany(p => p.Assets)
                .HasPrincipalKey(p => p.AssetType1)
                .HasForeignKey(d => d.AssetType)
                .HasConstraintName("FK_Asset_AssetTypeName");

            entity.HasOne(d => d.Issuance).WithMany(p => p.Assets)
                .HasForeignKey(d => d.IssuanceId)
                .HasConstraintName("FK__Asset__issuance___6E01572D");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Assets)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("FK__Asset__vendor_id__6D0D32F4");
        });

        modelBuilder.Entity<AssetSpec>(entity =>
        {
            entity.HasKey(e => e.AssetSpecId).HasName("PK__AssetSpe__9727D3DE6E805DE7");

            entity.Property(e => e.AssetSpecId).HasColumnName("AssetSpec_ID");
            entity.Property(e => e.AssetId).HasColumnName("asset_Id");
            entity.Property(e => e.SpecsId).HasColumnName("specs_id");

            entity.HasOne(d => d.Asset).WithMany(p => p.AssetSpecs)
                .HasForeignKey(d => d.AssetId)
                .HasConstraintName("FK__AssetSpec__asset__797309D9");

            entity.HasOne(d => d.Specs).WithMany(p => p.AssetSpecs)
                .HasForeignKey(d => d.SpecsId)
                .HasConstraintName("FK__AssetSpec__specs__7A672E12");
        });

        modelBuilder.Entity<AssetType>(entity =>
        {
            entity.HasKey(e => e.AssetTypeId).HasName("PK__AssetTyp__95A1E2BCA80182D9");

            entity.HasIndex(e => e.AssetType1, "UQ_AssetTypes_Asset_Type").IsUnique();

            entity.Property(e => e.AssetTypeId)
                .HasMaxLength(255)
                .HasColumnName("asset_type_id");
            entity.Property(e => e.AssetType1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Asset_Type");
            entity.Property(e => e.AssetTypeDp)
                .HasMaxLength(255)
                .HasColumnName("asset_type_dp");
            entity.Property(e => e.Model)
                .HasMaxLength(255)
                .HasColumnName("model");
        });

        modelBuilder.Entity<AssetUpdate>(entity =>
        {
            entity.HasKey(e => e.UpdateId).HasName("PK__AssetUpd__68D2E07924A6A7BE");

            entity.ToTable("AssetUpdate");

            entity.Property(e => e.UpdateId).HasColumnName("update_id");
            entity.Property(e => e.AssetId).HasColumnName("asset_id");
            entity.Property(e => e.ComponentUpdated)
                .HasMaxLength(255)
                .HasColumnName("component_updated");
            entity.Property(e => e.MaintenanceCheck).HasColumnName("maintenance_check");
            entity.Property(e => e.NewValue)
                .HasMaxLength(255)
                .HasColumnName("new_value");
            entity.Property(e => e.PreviousValue)
                .HasMaxLength(255)
                .HasColumnName("previous_value");
            entity.Property(e => e.UpdateDate).HasColumnName("update_date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .HasColumnName("updated_by");

            entity.HasOne(d => d.Asset).WithMany(p => p.AssetUpdates)
                .HasForeignKey(d => d.AssetId)
                .HasConstraintName("FK__AssetUpda__asset__02084FDA");

            entity.HasOne(d => d.MaintenanceCheckNavigation).WithMany(p => p.AssetUpdates)
                .HasForeignKey(d => d.MaintenanceCheck)
                .HasConstraintName("FK__AssetUpda__maint__02FC7413");
        });

        modelBuilder.Entity<AssetVulnerability>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AssetVul__3213E83F00F243E2");

            entity.ToTable("AssetVulnerability");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssetId).HasColumnName("asset_id");
            entity.Property(e => e.DetectedOn).HasColumnName("detected_on");
            entity.Property(e => e.MitigationStatus)
                .HasMaxLength(255)
                .HasColumnName("mitigation_status");
            entity.Property(e => e.VulnerabilityId).HasColumnName("vulnerability_id");

            entity.HasOne(d => d.Asset).WithMany(p => p.AssetVulnerabilities)
                .HasForeignKey(d => d.AssetId)
                .HasConstraintName("FK__AssetVuln__asset__00200768");

            entity.HasOne(d => d.Vulnerability).WithMany(p => p.AssetVulnerabilities)
                .HasForeignKey(d => d.VulnerabilityId)
                .HasConstraintName("FK__AssetVuln__vulne__01142BA1");
        });

        modelBuilder.Entity<Audit>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PK__Audit__5AF23A1B76D7C67B");

            entity.ToTable("Audit");

            entity.Property(e => e.AuditId).HasColumnName("audit_Id");
            entity.Property(e => e.AssetId).HasColumnName("asset_id");
            entity.Property(e => e.AuditReportId).HasColumnName("audit_report_id");
            entity.Property(e => e.AuditTeamId).HasColumnName("audit_team_id");

            entity.HasOne(d => d.Asset).WithMany(p => p.Audits)
                .HasForeignKey(d => d.AssetId)
                .HasConstraintName("FK__Audit__asset_id__75A278F5");

            entity.HasOne(d => d.AuditReport).WithMany(p => p.Audits)
                .HasForeignKey(d => d.AuditReportId)
                .HasConstraintName("FK__Audit__audit_rep__778AC167");

            entity.HasOne(d => d.AuditTeam).WithMany(p => p.Audits)
                .HasForeignKey(d => d.AuditTeamId)
                .HasConstraintName("FK__Audit__audit_tea__76969D2E");
        });

        modelBuilder.Entity<AuditReport>(entity =>
        {
            entity.HasKey(e => e.AuditReportid).HasName("PK__AuditRep__51B73E7B29C17E27");

            entity.ToTable("AuditReport");

            entity.Property(e => e.AuditReportid).HasColumnName("audit_reportid");
            entity.Property(e => e.AuditDetails)
                .HasColumnType("text")
                .HasColumnName("audit_details");
            entity.Property(e => e.Reportdate)
                .HasColumnType("datetime")
                .HasColumnName("reportdate");
        });

        modelBuilder.Entity<AuditTeam>(entity =>
        {
            entity.HasKey(e => e.AuditTeamid).HasName("PK__AuditTea__D3D449B1A5A5EC9C");

            entity.ToTable("AuditTeam");

            entity.Property(e => e.AuditTeamid).HasColumnName("audit_teamid");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");
            entity.Property(e => e.TeamMemberName)
                .HasMaxLength(255)
                .HasColumnName("team_member_name");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.ContractId).HasName("PK__Contract__F8D66423895805FD");

            entity.ToTable("Contract");

            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.ContractType)
                .HasMaxLength(255)
                .HasColumnName("contract_type");
            entity.Property(e => e.Cost)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("cost");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.RenewalTerms)
                .HasColumnType("text")
                .HasColumnName("renewal_terms");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.VendorId).HasColumnName("vendor_id");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("FK__Contract__vendor__7E37BEF6");
        });

        modelBuilder.Entity<Issuance>(entity =>
        {
            entity.HasKey(e => e.IssuanceId).HasName("PK__Issuance__03B4522311B1DADF");

            entity.ToTable("Issuance");

            entity.Property(e => e.IssuanceId).HasColumnName("issuance_id");
            entity.Property(e => e.AssetId).HasColumnName("asset_id");
            entity.Property(e => e.Building)
                .HasMaxLength(255)
                .HasColumnName("building");
            entity.Property(e => e.DateAssigned).HasColumnName("date_assigned");
            entity.Property(e => e.DepartmentId)
                .HasMaxLength(255)
                .HasColumnName("department_id");
            entity.Property(e => e.Designation)
                .HasMaxLength(255)
                .HasColumnName("designation");
            entity.Property(e => e.EmploymentId).HasColumnName("employment_id");
            entity.Property(e => e.IssuedTo)
                .HasMaxLength(255)
                .HasColumnName("issued_to");
            entity.Property(e => e.Room)
                .HasMaxLength(255)
                .HasColumnName("room");

            entity.HasOne(d => d.Asset).WithMany(p => p.Issuances)
                .HasForeignKey(d => d.AssetId)
                .HasConstraintName("FK__Issuance__asset___6EF57B66");
        });

        modelBuilder.Entity<Maintenance>(entity =>
        {
            entity.HasKey(e => e.MaintenanceId).HasName("PK__Maintena__9D754BEAFE173E73");

            entity.ToTable("Maintenance");

            entity.Property(e => e.MaintenanceId).HasColumnName("maintenance_id");
            entity.Property(e => e.AssetId).HasColumnName("asset_id");
            entity.Property(e => e.MaintenanceReportId).HasColumnName("maintenance_report_id");
            entity.Property(e => e.MaintenanceTeamId).HasColumnName("maintenance_team_id");

            entity.HasOne(d => d.Asset).WithMany(p => p.Maintenances)
                .HasForeignKey(d => d.AssetId)
                .HasConstraintName("FK__Maintenan__asset__71D1E811");

            entity.HasOne(d => d.MaintenanceReport).WithMany(p => p.Maintenances)
                .HasForeignKey(d => d.MaintenanceReportId)
                .HasConstraintName("FK__Maintenan__maint__73BA3083");

            entity.HasOne(d => d.MaintenanceTeam).WithMany(p => p.Maintenances)
                .HasForeignKey(d => d.MaintenanceTeamId)
                .HasConstraintName("FK__Maintenan__maint__72C60C4A");
        });

        modelBuilder.Entity<MaintenanceReport>(entity =>
        {
            entity.HasKey(e => e.MaintenanceReportid).HasName("PK__Maintena__8A6809E043710B56");

            entity.ToTable("MaintenanceReport");

            entity.Property(e => e.MaintenanceReportid).HasColumnName("Maintenance_reportid");
            entity.Property(e => e.MaintenanceDetails)
                .HasColumnType("text")
                .HasColumnName("Maintenance_details");
            entity.Property(e => e.Reportdate)
                .HasColumnType("datetime")
                .HasColumnName("reportdate");
            entity.Property(e => e.UpdateId).HasColumnName("update_id");

            entity.HasOne(d => d.Update).WithMany(p => p.MaintenanceReports)
                .HasForeignKey(d => d.UpdateId)
                .HasConstraintName("FK__Maintenan__updat__74AE54BC");
        });

        modelBuilder.Entity<MaintenanceTeam>(entity =>
        {
            entity.HasKey(e => e.MaintenanceTeamid).HasName("PK__Maintena__7600997C7DE0991C");

            entity.ToTable("MaintenanceTeam");

            entity.Property(e => e.MaintenanceTeamid).HasColumnName("maintenance_teamid");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");
            entity.Property(e => e.TeamMemberName)
                .HasMaxLength(255)
                .HasColumnName("team_member_name");
        });

        modelBuilder.Entity<Reporting>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Reportin__779B7C584042350C");

            entity.ToTable("Reporting");

            entity.Property(e => e.ReportId).HasColumnName("report_id");
            entity.Property(e => e.AssetId).HasColumnName("asset_id");
            entity.Property(e => e.Summary)
                .HasColumnType("text")
                .HasColumnName("summary");

            entity.HasOne(d => d.Asset).WithMany(p => p.Reportings)
                .HasForeignKey(d => d.AssetId)
                .HasConstraintName("FK__Reporting__asset__787EE5A0");
        });

        modelBuilder.Entity<TechnicalSpec>(entity =>
        {
            entity.HasKey(e => e.SpecId).HasName("PK__Technica__883D519B08789C1E");

            entity.Property(e => e.SpecId).HasColumnName("SpecID");
            entity.Property(e => e.SpecField).HasColumnType("text");
            entity.Property(e => e.SpecName).HasMaxLength(255);
        });

        modelBuilder.Entity<Tracking>(entity =>
        {
            entity.HasKey(e => e.TrackingId).HasName("PK__Tracking__7AC3E9AE8AA48F98");

            entity.ToTable("Tracking");

            entity.Property(e => e.TrackingId).HasColumnName("tracking_id");
            entity.Property(e => e.AssetId).HasColumnName("asset_id");
            entity.Property(e => e.LastLocationId).HasColumnName("last_location_id");
            entity.Property(e => e.RfidTag)
                .HasMaxLength(255)
                .HasColumnName("rfid_tag");
            entity.Property(e => e.TrackingNumber)
                .HasMaxLength(255)
                .HasColumnName("tracking_number");

            entity.HasOne(d => d.Asset).WithMany(p => p.Trackings)
                .HasForeignKey(d => d.AssetId)
                .HasConstraintName("FK__Tracking__asset___6FE99F9F");

            entity.HasOne(d => d.LastLocation).WithMany(p => p.Trackings)
                .HasForeignKey(d => d.LastLocationId)
                .HasConstraintName("FK__Tracking__last_l__70DDC3D8");
        });

        modelBuilder.Entity<Transfer>(entity =>
        {
            entity.HasKey(e => e.TransferId).HasName("PK__Transfer__78E6FD33C2D1B492");

            entity.ToTable("Transfer");

            entity.Property(e => e.TransferId).HasColumnName("transfer_id");
            entity.Property(e => e.ApprovedBy)
                .HasMaxLength(255)
                .HasColumnName("approved_by");
            entity.Property(e => e.AssetId).HasColumnName("asset_id");
            entity.Property(e => e.FromLocationId).HasColumnName("from_location_id");
            entity.Property(e => e.ToLocationId).HasColumnName("to_location_id");
            entity.Property(e => e.TransferDate).HasColumnName("transfer_date");

            entity.HasOne(d => d.Asset).WithMany(p => p.Transfers)
                .HasForeignKey(d => d.AssetId)
                .HasConstraintName("FK__Transfer__asset___7D439ABD");

            entity.HasOne(d => d.FromLocation).WithMany(p => p.TransferFromLocations)
                .HasForeignKey(d => d.FromLocationId)
                .HasConstraintName("FK__Transfer__from_l__7B5B524B");

            entity.HasOne(d => d.ToLocation).WithMany(p => p.TransferToLocations)
                .HasForeignKey(d => d.ToLocationId)
                .HasConstraintName("FK__Transfer__to_loc__7C4F7684");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.VendorId).HasName("PK__Vendor__0F7D2B78EAC2BD95");

            entity.ToTable("Vendor");

            entity.Property(e => e.VendorId).HasColumnName("vendor_id");
            entity.Property(e => e.Address)
                .HasColumnType("text")
                .HasColumnName("address");
            entity.Property(e => e.ContactPerson)
                .HasMaxLength(255)
                .HasColumnName("contact_person");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Vulnerability>(entity =>
        {
            entity.HasKey(e => e.VulnerabilityId).HasName("PK__Vulnerab__6ED2BCA3B69C6800");

            entity.ToTable("Vulnerability");

            entity.Property(e => e.VulnerabilityId).HasColumnName("vulnerability_id");
            entity.Property(e => e.DateDiscovered).HasColumnName("date_discovered");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.MitigatedOn).HasColumnName("mitigated_on");
            entity.Property(e => e.Severity)
                .HasMaxLength(255)
                .HasColumnName("severity");
            entity.Property(e => e.Specsid).HasColumnName("specsid");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");

            entity.HasOne(d => d.Specs).WithMany(p => p.Vulnerabilities)
                .HasForeignKey(d => d.Specsid)
                .HasConstraintName("FK__Vulnerabi__specs__7F2BE32F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
