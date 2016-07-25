﻿namespace Dsp.Web.Areas.Nme.Models
{
    using Data.Entities;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class BroQuestIndexModel
    {
        public IEnumerable<SelectListItem> SemesterList { get; set; }
        public Semester Semester { get; set; }
        public Member Member { get; set; }
        public IEnumerable<Member> Members { get; set; }

        public BroQuestIndexModel(Semester semester)
        {
            Semester = semester;
        }
        public BroQuestIndexModel(Member member)
        {
            Member = member;
        }
        public BroQuestIndexModel(Semester semester, Member member)
        {
            Semester = semester;
            Member = member;
        }
    }
}
