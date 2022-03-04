using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases {

    public class GenerateScheduleByDateUseCase : IGenerateScheduleByDateUseCase {
        private readonly IScheduleRepository scheduleRepository;

        public GenerateScheduleByDateUseCase(IScheduleRepository scheduleRepository) {
            this.scheduleRepository = scheduleRepository;
        }

        public void Execute(DateTime date, SportType type) {
            scheduleRepository.GenerateScheduleByDate(date, type);
        }
    }
}