namespace ML
{
    public class Automovil
    {
        public int IdAutomovil {get; set;}
        public string Modelo { get; set; }
        public string Color { get; set; }
        public int NumeroPuertas { get; set; }
        public ML.Placas Placas { get; set; }
        public ML.Marca Marca { get; set; }
        public List<object> Automoviles { get; set; }
    }
}