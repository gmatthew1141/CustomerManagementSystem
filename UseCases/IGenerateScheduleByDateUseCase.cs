using CoreBusiness;
using System;

namespace UseCases {
    public interface IGenerateScheduleByDateUseCase {
        void Execute(DateTime date, SportType type);
    }
}