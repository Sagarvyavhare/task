using System;
using System.Collections.Generic;

namespace nikhilTask.Models;

public partial class Addresstbl
{
    public int Id { get; set; }

    public string Line1 { get; set; } = null!;

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public int? Zip { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
