namespace Domain
{
    public class Doctor : BaseEntity
    {
        public string? FIO { get; set; }

        public uint CabinetId { get; set; }
        public virtual Cabinet? Cabinet { get; set; }
        public uint SpecializationId { get; set; }
        public virtual Specialization? Specialization { get; set; }

        public uint TerritorialUnitId { get; set; }
        public virtual TerritorialUnit?  TerritorialUnit { get; set; }
    }
}
