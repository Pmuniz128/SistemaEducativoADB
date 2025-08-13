namespace SistemaEducativoADB.API.Models.Entities
{
    public class Estudiante
    {
        public int Id { get; set; }

        public required string LastName { get; set; }
        public required string FirstName { get; set; }
        public int Age { get; set; }
    }
}
