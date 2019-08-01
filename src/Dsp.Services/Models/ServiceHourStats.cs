﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Dsp.Services.Models
{
    public class ServiceHourStats
    {
        public int UnadjustedMemberCount { get; private set; }
        public int AdjustedMemberCount { get; private set; }
        public float TargetPercentage { get; private set; }
        public bool IncludesUnapprovedHours { get; private set; }
        public IEnumerable<string> Months { get; private set; }
        public IEnumerable<int> TargetMemberCount { get; private set; }
        public IEnumerable<int> MoreThanZeroHours { get; private set; }
        public IEnumerable<int> FiveOrMoreHours { get; private set; }
        public IEnumerable<int> TenOrMoreHours { get; private set; }
        public IEnumerable<int> FifteenOrMoreHours { get; private set; }

        public ServiceHourStats(
            int unadjustedMemberCount,
            int adjustedMemberCount,
            bool includesUnapprovedHours,
            IEnumerable<string> months,
            IEnumerable<int> moreThanZeroHours,
            IEnumerable<int> fiveOrMoreHours,
            IEnumerable<int> tenOrMoreHours,
            IEnumerable<int> fifteenOrMoreHours,
            float targetPercentage = 0.8f)
        {
            UnadjustedMemberCount = unadjustedMemberCount;
            AdjustedMemberCount = adjustedMemberCount;
            TargetPercentage = targetPercentage;
            var target = (int)Math.Ceiling(adjustedMemberCount * targetPercentage);
            TargetMemberCount = Enumerable.Repeat(target, moreThanZeroHours.Count());
            IncludesUnapprovedHours = includesUnapprovedHours;
            Months = months;
            MoreThanZeroHours = moreThanZeroHours;
            FiveOrMoreHours = fiveOrMoreHours;
            TenOrMoreHours = tenOrMoreHours;
            FifteenOrMoreHours = fifteenOrMoreHours;
        }
    }
}
