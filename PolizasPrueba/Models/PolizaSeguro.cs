using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace PolizasPrueba.Models
{
    public class PolizaSeguro
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string numeroPoliza { get; set; }
        public string nombreCliente { get; set; }
        public string identificacionCliente { get; set; }
        public DateTime fechaNacimientoCliente { get; set; }
        public DateTime fechaTomaPoliza { get; set; }
        public List<string> coberturas { get; set; }
        public decimal valorMaximoCubierto { get; set; }
        public string nombrePlan { get; set; }
        public string ciudadResidenciaCliente { get; set; }
        public string direccionResidenciaCliente { get; set; }
        public string placaAutomotor { get; set; }
        public string modeloAutomotor { get; set; }
        public bool vehiculoTieneInspeccion { get; set; }
    }
}
