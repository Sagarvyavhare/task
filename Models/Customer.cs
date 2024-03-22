using System;
using System.Collections.Generic;

namespace nikhilTask.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Thumbnailurl { get; set; } = null!;

    public DateOnly Dateofbirth { get; set; }

    public string Emailid { get; set; } = null!;

    public long? Mobilenumber { get; set; }

    public string Gender { get; set; } = null!;

    public DateTime Createdtimestamp { get; set; }

    public DateTime Lastupdatedtimestamp { get; set; }

    public bool? Active { get; set; }

    public int? Addressid { get; set; }

    public virtual Addresstbl? Address { get; set; }
}
