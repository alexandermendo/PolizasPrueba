using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using PolizasPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/polizas")]
public class PolizaController : ControllerBase
{
    private readonly IMongoCollection<PolizaSeguro> _polizasCollection;

    public PolizaController(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("seguros"); 
        _polizasCollection = database.GetCollection<PolizaSeguro>("polizas");
    }

    [HttpGet]
    public ActionResult<IEnumerable<PolizaSeguro>> Get()
    {
        var polizas = _polizasCollection.Find(poliza => true).ToList();
        return Ok(polizas);
    }


    [HttpGet("{numeroPolizaOrPlaca}")]
    public ActionResult<PolizaSeguro> GetByNumeroPolizaOrPlaca(string numeroPolizaOrPlaca)
    {
        var filter = Builders<PolizaSeguro>.Filter.Or(
            Builders<PolizaSeguro>.Filter.Eq(p => p.numeroPoliza, numeroPolizaOrPlaca),
            Builders<PolizaSeguro>.Filter.Eq(p => p.placaAutomotor, numeroPolizaOrPlaca)
        );

        var poliza = _polizasCollection.Find(filter).FirstOrDefault();
        if (poliza == null) return NotFound("No se encontró ninguna póliza con ese número de póliza o placa.");
        return Ok(poliza);
    }


    [HttpPost]
    public ActionResult Create(PolizaSeguro poliza)
    {
        if (poliza.fechaTomaPoliza > DateTime.UtcNow) return BadRequest("La fecha de vigencia no puede ser en el futuro.");
        _polizasCollection.InsertOne(poliza);
        return CreatedAtAction(nameof(GetByNumeroPolizaOrPlaca), new { numeroPoliza = poliza.numeroPoliza }, poliza);
    }


    [HttpPut("{numeroPoliza}")]
    public ActionResult Update(string numeroPoliza, PolizaSeguro updatedPoliza)
    {
        var existingPoliza = _polizasCollection.FindOneAndUpdate(
            Builders<PolizaSeguro>.Filter.Eq(p => p.numeroPoliza, numeroPoliza),
            Builders<PolizaSeguro>.Update
                .Set(p => p.nombreCliente, updatedPoliza.nombreCliente) 
        );
        if (existingPoliza == null) return NotFound();
        return NoContent(); 
    }

    [HttpDelete("{numeroPoliza}")]
    public ActionResult Delete(string numeroPoliza)
    {
        var result = _polizasCollection.DeleteOne(poliza => poliza.numeroPoliza == numeroPoliza);
        if (result.DeletedCount == 0) return NotFound(); 
        return NoContent(); 
    }
}
