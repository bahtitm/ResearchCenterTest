namespace Domain
{
    public class Patient : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Patronymic { get; set; }
        public string? Address { get; set; }
        public string? BirthDay { get; set; }
        public Gender Gender { get; set; }

        public uint TerritorialUnitId { get; set; }
        public virtual TerritorialUnit? TerritorialUnit { get; set; }

    }
    public enum Gender
    {
        None,
        Male,
        Female

    }
}
