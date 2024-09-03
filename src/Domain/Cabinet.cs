namespace Domain
{
    public class Cabinet : BaseEntity
    {
        public string? Name  { get; set; }
        public virtual IEnumerable<Doctor>? Doctors { get; set; }
    }
}
