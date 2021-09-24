using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using DecolaTech.FonsecaFlix.Web.Models;
using DecolaTech.FonsecaFlix.Interfaces;
using DecolaTech.FonsecaFlix.Models;

namespace DecolaTech.FonsecaFlix.Web.Controllers
{
    [ Route("[controller]")]
    public class SeriesController : Controller
    {

        private readonly IRepository<SerieEntity> _seriesRepository;

        public SeriesController(IRepository<SerieEntity> repository){
            this._seriesRepository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult Consulta(int id)
        {   
            try{
                SerieModel model = new SerieModel(_seriesRepository.FindById(id));
                return Ok(model);
            }
            catch(Exception e){
                Console.WriteLine(e);
                return  NoContent();
            }
            
        }   

        [HttpGet("")]
        public IActionResult Lista(){
            return Ok(_seriesRepository.ListAll().Where( s => s.excluded == false).Select((s)=>{
                return new SerieModel(s);
            }));
        }

        [HttpPut("{id}")]
        public IActionResult Atualiza(int id, [FromBody] SerieModel model ){
            model.setId(id);
            this._seriesRepository.Update(id, model.ToSerieEntity());
            return NoContent();
        }

        [HttpPost("")]
        public IActionResult Insere([FromBody] SerieModel model){

            model.setId( _seriesRepository.getNextId()); // Should broke here
            SerieEntity serie = model.ToSerieEntity();

            this._seriesRepository.Add(serie);
            return Created("", new SerieModel(serie));
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id){
            this._seriesRepository.RemoveById(id);
            return NoContent();
        }

       
    }
}

