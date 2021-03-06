using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces {

    public interface IScheduleRepository {

        IEnumerable<Schedule> GetSchedule();

        void GenerateScheduleByDate(DateTime date, SportType type);

        void CountAttendance(Schedule schedule);
    }
}