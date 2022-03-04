using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory {

    public class ScheduleInMemoryRepository : IScheduleRepository {
        public List<Schedule> Schedules { get; set; }
        private Dictionary<int, string> timestamps;
        private readonly IGetTimestampUseCase getTimestampUseCase;
        private readonly IGetAttendanceByDateUseCase getAttendanceByDateUseCase;

        public ScheduleInMemoryRepository(IGetTimestampUseCase getTimestampUseCase, IGetAttendanceByDateUseCase getAttendanceByDateUseCase) {
            this.getTimestampUseCase = getTimestampUseCase;
            this.getAttendanceByDateUseCase = getAttendanceByDateUseCase;
            timestamps = this.getTimestampUseCase.GetTimestamps().ToDictionary(x => x.Key, x => x.Value);
        }

        public IEnumerable<Schedule> GetSchedule() {
            return Schedules;
        }

        public void GenerateScheduleByDate(DateTime date, SportType type) {
            Schedules = new List<Schedule>();
            IEnumerable<Attendance> attendances = getAttendanceByDateUseCase.Execute(date, type);

            for (int i = 0; i < 19; i++) {
                var schedule = new Schedule {
                    Timestamp = timestamps[i] + " - " + timestamps[i + 1],
                    Court1 = attendances.SingleOrDefault(x => x.PlayTime == i && x.CourtNum == 1),
                    Court2 = attendances.SingleOrDefault(x => x.PlayTime == i && x.CourtNum == 2),
                    Court3 = attendances.SingleOrDefault(x => x.PlayTime == i && x.CourtNum == 3),
                    Court4 = attendances.SingleOrDefault(x => x.PlayTime == i && x.CourtNum == 4),
                    TotalAttendance = attendances.Count(x => x.Present && x.PlayTime == i)
                };

                Schedules.Add(schedule);
            }
        }

        public void CountAttendance(Schedule schedule) {
            int total = 0;

            if (schedule.Court1 != null && schedule.Court1.Present) {
                total++;
            }
            if (schedule.Court2 != null && schedule.Court2.Present) {
                total++;
            }
            if (schedule.Court3 != null && schedule.Court3.Present) {
                total++;
            }
            if (schedule.Court4 != null && schedule.Court4.Present) {
                total++;
            }

            schedule.TotalAttendance = total;
        }
    }
}