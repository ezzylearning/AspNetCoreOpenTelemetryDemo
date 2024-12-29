using System;
using System.Collections.Generic;

namespace AspNetCoreOpenTelemetryDemo.Models;

public partial class Country
{
    public Guid Id { get; set; }

    public int SequenceId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? IsoCode3 { get; set; }

    public string? PhoneCode { get; set; }

    public string? Capital { get; set; }

    public string? Tld { get; set; }

    public string? Nationality { get; set; }

    public Guid? CurrencyId { get; set; }

    public Guid? RegionId { get; set; }

    public Guid? SubRegionId { get; set; }

    public bool IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public Guid? UpdatedBy { get; set; }
}
