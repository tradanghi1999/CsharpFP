using Fp;
using Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPExcercise
{
    public static class WorkFP
    {
        public static Option<WorkPermit> GetWorkPermit(
            Dictionary<string, Employee> people,
            string employeeId)
            => people[employeeId].WorkPermit.Match<Option<WorkPermit>>(
                    () => new None(),
                    (wp) => wp.Expiry > DateTime.Now ?
                            wp.ParseToOption() :
                            new None()
                );
        public static double AverageYearsWorkedAtTheCompany(List<Employee> employees)
            => employees
                .Where(e => 
                        e.LeftOn.IsSome == false)
                .Average(e => 
                            (DateTime.Now - e.JoinedOn).TotalDays);
    }
}
