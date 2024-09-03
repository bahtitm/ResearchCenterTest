namespace Application.Features.Doctors.Dtos
{
    public class DoctorDto
    {
        public uint Id { get; set; }
        public string? FIO { get; set; }        
    
        public string? CabinetName { get; set; }

        public string? SpecializationName { get; set; }


        public string? TerritorialUnitNomber { get; set; }


    }
}
