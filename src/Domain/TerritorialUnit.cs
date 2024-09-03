namespace Domain
{
    public class TerritorialUnit : BaseEntity
    {
        public string? Nomber { get; set; }
        public virtual IEnumerable<Doctor>? Doctors { get; set; }
        public virtual IEnumerable<Patient>? Patients { get; set; }
    }
}
