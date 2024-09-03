namespace Application.Features.Patients.Dtos
{
    public class PatientDto
    {
        public uint Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Patronymic { get; set; }
        public string? Address { get; set; }
        public string? BirthDay { get; set; }
        public Gender Gender { get; set; }

        public string? TerritorialUnitNumber { get; set; }
    }
}
