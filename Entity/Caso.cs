namespace COVID.Entity
{
    class Caso
    {
        public string id { get; set; }
        public string Estado { get; set; } 
        public string Contagio { get; set; }
        public Persona Persona { get; set; }
        public string Pais { get; set; }
    }
}