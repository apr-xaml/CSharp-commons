using System;
using System.Collections.Generic;
using System.Linq;

namespace nIt.nCommon
{
    public class FiniteNonZeroTimeInterval
    {
        public FiniteNonZeroTimeInterval(DateTime start, DateTime end)
        {
            Throw.IfNot(IsFiniteAndNonZero(start, end));

            Start = start;
            End = end;
        }

        public DateTime End { get; }
        public DateTime Start { get; }


        static public bool IsFiniteAndNonZero(DateTime start, DateTime end) => (end - start).Ticks > 0;


        public static bool AnyIntersecting(IEnumerable<FiniteNonZeroTimeInterval> intervals)
        {

            var timePoints = intervals
                .Select
                (
                    x => new[]
                    {
                        new { IsStart = true, Value = x.Start },
                        new { IsStart = false, Value = x.End  }
                    }
                )
                .SelectMany(x => x);


            var ordered = timePoints.OrderBy(x => x.Value);

            var accumulated = ordered.SelectWithHistory
                (
                    oxStart: (x) => new { StartingCount = 1, EndingCount = 0 },
                    oxNext: (x, xAccum) => (x.IsStart) ?
                        new { StartingCount = xAccum.StartingCount + 1, EndingCount = xAccum.EndingCount }
                        : new { StartingCount = xAccum.StartingCount, EndingCount = xAccum.EndingCount + 1 }
                );


            var firstIntersecting = accumulated.FirstOrDefault(x => x.StartingCount > x.EndingCount + 1);

            return (firstIntersecting != null);
        }
    }
}
