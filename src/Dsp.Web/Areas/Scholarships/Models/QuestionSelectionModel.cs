﻿namespace Dsp.Web.Areas.Scholarships.Models
{
    using Dsp.Data.Entities;

    public class QuestionSelectionModel
    {
        public bool IsSelected { get; set; }
        public ScholarshipAppQuestion Question { get; set; }
    }
}