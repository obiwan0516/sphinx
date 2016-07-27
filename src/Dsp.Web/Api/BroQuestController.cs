﻿using Dsp.Data;
using Dsp.Data.Entities;
using Dsp.Services.Admin;
using Dsp.Services.Interfaces;
using Dsp.Web.Extensions;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Dsp.Web.Api
{
    [RoutePrefix("api/broquest")]
    public class BroQuestController : ApiController
    {
        private SphinxDbContext _db;
        private ISemesterService _semesterService;
        public BroQuestController()
        {
            _db = new SphinxDbContext();
            _semesterService = new SemesterService(_db);
        }

        [Route("period")]
        public async Task<IHttpActionResult> GetPeriod()
        {
            var semester = await _semesterService.GetCurrentSemesterAsync();
            if (semester == null)
            {
                return NotFound();
            }
            var beginsOn = semester.QuestingBeginsOn.FromUtcToCst();
            var endsOn = semester.QuestingEndsOn.FromUtcToCst();
            return Ok(new { BeginsOn = beginsOn, EndsOn = endsOn });
        }

        [Route("period/{id:int}")]
        public async Task<IHttpActionResult> GetPeriod(int id)
        {
            var semester = await GetSemesterByIdAsync(id);
            if(semester == null)
            {
                return NotFound();
            }
            var beginsOn = semester.QuestingBeginsOn.FromUtcToCst();
            var endsOn = semester.QuestingEndsOn.FromUtcToCst();
            return Ok(new { BeginsOn = semester.QuestingBeginsOn, EndsOn = semester.QuestingEndsOn });
        }

        [Route("timeleft")]
        public async Task<IHttpActionResult> GetTimeLeftBegins()
        {
            var semester = await _semesterService.GetCurrentSemesterAsync();
            if (semester == null)
            {
                return NotFound();
            }
            var now = DateTime.UtcNow;
            var beginsOn = semester.QuestingBeginsOn;
            var endsOn = semester.QuestingEndsOn;
            var timeLeft = string.Empty;
            if(now < beginsOn) // Questing hasn't started
            {
                timeLeft = (beginsOn - now).ToPreciseTimeUntilString();
                timeLeft = string.Format("Questing begins in: {0}", timeLeft);
            }
            else if(now < endsOn) // Questing has started, but not finished
            {
                timeLeft = (endsOn - now).ToPreciseTimeUntilString();
                timeLeft = string.Format("Questing ends in: {0}", timeLeft);
            }
            else // Questing is over and we're waiting on the next semester
            {
                timeLeft = "Questing is over.  Check back next semester.";
            }

            return Ok(timeLeft);
        }

        private async Task<Semester> GetSemesterByIdAsync(int id)
        {
            return (await _db.Semesters
                    .Where(s => s.DateEnd >= DateTime.UtcNow)
                    .OrderBy(s => s.DateStart)
                    .ToListAsync())
                    .First();
        }
    }
}
;