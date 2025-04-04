﻿using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class UserMembershipPlan
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid MembershipPlanId { get; set; }

    public DateTime? ActivatedAt { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public decimal? Price { get; set; }

    public virtual MembershipPlan MembershipPlan { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
