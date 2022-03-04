using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases {

    public class GetScheduleUseCase : IGetScheduleUseCase {
        private readonly IScheduleRepository scheduleRepository;

        public GetScheduleUseCase(IScheduleRepository scheduleRepository) {
            this.scheduleRepository = scheduleRepository;
        }

        public IEnumerable<Schedule> Execute() {
            return scheduleRepository.GetSchedule();
        }
    }
}