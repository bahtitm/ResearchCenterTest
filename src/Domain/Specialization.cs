namespace Domain
{
    public class Specialization : BaseEntity
    {
        public string? Name { get; set; }
        public virtual IEnumerable<Doctor>? Doctors { get; set; }
    }
}
