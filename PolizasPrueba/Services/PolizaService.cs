using MongoDB.Driver;
using PolizasPrueba.Models;

namespace NombreDeTuProyecto.Services
{
    public class PolizaService : IPolizaService
    {
        private readonly IMongoDatabase _mongoDatabase;
        public PolizaService(IMongoClient mongoClient)
        {
            _mongoDatabase = mongoClient.GetDatabase("seguros");
        }

        public void ActualizarPoliza(int id, PolizaSeguro poliza)
        {
            throw new NotImplementedException();
        }

        public void CrearPoliza(PolizaSeguro poliza)
        {
            throw new NotImplementedException();
        }

        public void EliminarPoliza(int id)
        {
            throw new NotImplementedException();
        }

        public PolizaSeguro ObtenerPolizaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<PolizaSeguro> ObtenerPolizas()
        {
            var polizasMongo = _mongoDatabase.GetCollection<PolizaSeguro>("polizas");
            var polizas = polizasMongo.Find(p => true).ToList();
            return polizas;
        }
    }
}
