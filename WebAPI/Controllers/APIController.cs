using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class APIController : ControllerBase
    {

        private readonly WebAPIContext _context;

        public APIController(WebAPIContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Отдает договоры заключенные в определенный день
        /// </summary>
        /// <param name="day"></param>
        /// <param name="mounth"></param>
        /// <returns></returns>
        [HttpGet("get_status_agr/{day}&{mounth}")]
        public async Task<ActionResult> GetStatusAgrPerDay(int day, int mounth)
        {

            var agreement = (from agreements in _context.Agreement
                             join status in _context.Status on agreements.StatusId equals status.Id
                             where agreements.DataOpen.Equals(new DateTime(2020, mounth, day))
                             select new
                             {
                                 agreementnumber = agreements.Number,
                                 status = status.StatusAggrement
                             });


            if (agreement == null)
            {
                return NotFound();
            }

            return Ok(agreement);
        }
        /// <summary>
        /// все данные бд
        /// этот метод? / брокерский / управления
        /// не принятые договора физ лиц
        /// не прянятые договора юр лиц
        /// кол-во договоров у персоны юр/физ
        /// персона заключившая договор по номеру
        /// </summary>
        /// <param name="day"></param>
        /// <param name="mounth"></param>
        /// <returns></returns>

        [HttpGet("get_all_agreements")]
        public async Task<ActionResult> GetAllData()
        {

            var agreement = (from agreements in _context.Agreement
                             join status in _context.Status on agreements.StatusId equals status.Id
                             join type in _context.Type on agreements.TypeId equals type.Id
                             join person in _context.Person on agreements.PersonId equals person.Id
                             select new
                             {
                                 agreement_number = agreements.Number,
                                 person,
                                 status = status.StatusAggrement,
                                 type = type.TypeAggrement,
                                 date_open = agreements.DataOpen,
                                 date_close = agreements.DataClose
                             });


            if (agreement == null)
            {
                return NotFound();
            }

            return Ok(agreement);
        }

        /// <summary>
        /// Отдает договоры которые были зарегистрированны в тот же день что и персона
        /// </summary>
        /// <returns></returns>
        [HttpGet("get_first_agreement_person")]
        public async Task<ActionResult> GetFirstAgreementPerson()
        {

            var agreement = (from agreements in _context.Agreement
                             join person in _context.Person on agreements.PersonId equals person.Id
                             where person.Data.Equals(agreements.DataOpen)
                             select new
                             {
                                 agreement_number = agreements.Number,
                                 data_open = agreements.DataOpen,
                                 data_close = agreements.DataClose,
                                 person_create = person.Data
                             });


            if (agreement == null)
            {
                return NotFound();
            }

            return Ok(agreement);
        }

        /// <summary>
        /// не принятые договоры
        /// </summary>
        /// <param name="typePerson"></param>
        /// <returns></returns>
        [HttpGet("get_not_accept_agreement/{typePerson}")]
        public async Task<ActionResult> GetNotAcceptAgr(bool typePerson = false)
        {

            var agreement = (from agreements in _context.Agreement
                             join person in _context.Person on agreements.PersonId equals person.Id
                             where person.Type == typePerson && agreements.StatusId == 2  
                             select new
                             {
                                 person = person.Inn,
                                 person_type = person.Type, 
                                 agreement_number = agreements.Number,
                                 agreement_status = _context.Status.Find(2).StatusAggrement
                             });


            if (agreement == null)
            {
                return NotFound();
            }

            return Ok(agreement);
        }

        [HttpGet("get_person_agr/{id}")]
        public async Task<ActionResult> GetPersonAgr(int id)
        {
            if (_context.Agreement.Max(p => p.PersonId) < id)
            {
                return NotFound();
            }

            var agreement = (from agreements in _context.Agreement
                             where agreements.PersonId == _context.Person.Find(id).Id
                             select new
                             {
                                 agreements
                             });


            if (agreement == null)
            {
                return NotFound();
            }

            return Ok(agreement);
        }


        [HttpGet("get_person_count_agr/{id}")]
        public async Task<ActionResult> GetPersonCountAgr(int id)
        {

            if (_context.Agreement.Max(p => p.PersonId) < id)
            {
                return NotFound();
            }

            var agreement = (from person in _context.Person
                             where person.Id == id
                             select  new
                             {
                                 person,
                                 count_agreements = _context.Agreement.Where(agr => agr.PersonId == id).Count()
                             });

            if (agreement == null)
            {
                return NotFound();
            }

            return Ok(agreement);
        }


        [HttpGet("get_broker_agr")]
        public async Task<ActionResult> GetBrokerAgr()
        {


            var agreement = (from type in _context.Type
                             join agreements in _context.Agreement on type.Id equals agreements.TypeId
                             where type.Id == 2 
                             select new
                             {
                                 status = type.TypeAggrement,
                                 agreements
                             });

            if (agreement == null)
            {
                return NotFound();
            }

            return Ok(agreement);
        }

        [HttpGet("get_diler_agr")]
        public async Task<ActionResult> GetDilerAgr()
        {


            var agreement = (from type in _context.Type
                             join agreements in _context.Agreement on type.Id equals agreements.TypeId
                             where type.Id == 1
                             select new
                             {
                                 status = type.TypeAggrement,
                                 agreements
                             });

            if (agreement == null)
            {
                return NotFound();
            }

            return Ok(agreement);
        }

        [HttpGet("get_manage_agr")]
        public async Task<ActionResult> GetManageAgr()
        {


            var agreement = (from type in _context.Type
                             join agreements in _context.Agreement on type.Id equals agreements.TypeId
                             where type.Id == 3
                             select new
                             {
                                 status = type.TypeAggrement,
                                 agreements
                             });

            if (agreement == null)
            {
                return NotFound();
            }

            return Ok(agreement);
        }

        [HttpGet("get_block_diler_agr")]
        public async Task<ActionResult> GetBlockDilerAgr()
        {


            var agreement = (from type in _context.Type
                             join agreements in _context.Agreement on type.Id equals agreements.StatusId
                             where type.Id == 2 && agreements.TypeId == 1
                             select new
                             {
                                 type = type.TypeAggrement,
                                 agreements,
                                 status = agreements.StatusId == 2 ? "блокирован" : "действует"
                             });

            if (agreement == null)
            {
                return NotFound();
            }

            return Ok(agreement);
        }

        [HttpGet("get_agr_by_number/{number}")]
        public async Task<ActionResult> GetAgrByNumber(int number)
        {

            var agreement = (from agreements in _context.Agreement
                             join status in _context.Status on agreements.StatusId equals status.Id
                             join type in _context.Type on agreements.TypeId equals type.Id
                             join person in _context.Person on agreements.PersonId equals person.Id
                             where agreements.Number == number
                             select new
                             {
                                 agreement_number = agreements.Number,
                                 person,
                                 status = status.StatusAggrement,
                                 type = type.TypeAggrement,
                                 date_open = agreements.DataOpen,
                                 date_close = agreements.DataClose
                             });


            if (agreement == null)
            {
                return NotFound();
            }

            return Ok(agreement);
        }

        [HttpGet("get_person_agr_by_inn/{inn}")]
        public async Task<ActionResult> GetPersonAgrByInn(long inn)
        {

            var agreement = (from agreements in _context.Agreement
                             join person in _context.Person on agreements.PersonId equals person.Id
                             where person.Inn == inn
                             select new
                             {
                                 person = person.Inn,
                                 agreements
                             });


            if (agreement == null)
            {
                return NotFound();
            }

            return Ok(agreement);
        }
    }
}
