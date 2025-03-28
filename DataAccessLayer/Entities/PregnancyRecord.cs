﻿using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class PregnancyRecord
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public string? BabyName { get; set; }

    public DateOnly? PregnancyStartDate { get; set; }

    public DateOnly? ExpectedDueDate { get; set; }

    public string? BabyGender { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<FetalGrowthRecord> FetalGrowthRecords { get; set; } = new List<FetalGrowthRecord>();

    public virtual MotherInfo? MotherInfo { get; set; }

    public virtual User? User { get; set; }
}
