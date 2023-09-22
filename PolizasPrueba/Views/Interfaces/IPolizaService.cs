using PolizasPrueba.Models;
using System;
using System.Collections.Generic;

namespace NombreDeTuProyecto.Services
{
    public interface IPolizaService
    {
        List<PolizaSeguro> ObtenerPolizas();
        PolizaSeguro ObtenerPolizaPorId(int id);
        void CrearPoliza(PolizaSeguro poliza);
        void ActualizarPoliza(int id, PolizaSeguro poliza);
        void EliminarPoliza(int id);
    }
}
