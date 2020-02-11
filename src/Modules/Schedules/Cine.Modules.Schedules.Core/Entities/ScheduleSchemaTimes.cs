using System.Collections;
using System.Collections.Generic;
using Cine.Modules.Schedules.Core.ValueObjects;

namespace Cine.Modules.Schedules.Core.Entities
{
    public sealed class ScheduleSchemaTimes : IEnumerable<(int ageRestriction, IEnumerable<Time> times)>
    {
        private readonly IEnumerable<(int ageRestriction, IEnumerable<Time> scheduleTimes)> _times;

        public ScheduleSchemaTimes(IEnumerable<(int ageRestriction, IEnumerable<Time> scheduleTimes)> times)
            => _times = times;

        public IEnumerator<(int ageRestriction, IEnumerable<Time> times)> GetEnumerator()
            => _times.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => _times.GetEnumerator();
    }
}
