﻿using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class ReminderType
{
    public Guid Id { get; set; }

    public string TypeName { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Reminder> Reminders { get; set; } = new List<Reminder>();
}
