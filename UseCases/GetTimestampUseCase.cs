using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases {

    public class GetTimestampUseCase : IGetTimestampUseCase {
        private readonly IBookingRepository bookingRepository;

        public GetTimestampUseCase(IBookingRepository bookingRepository) {
            this.bookingRepository = bookingRepository;
        }

        public string GetTimestampByKey(int key) {
            return bookingRepository.GetTimestampByKey(key);
        }

        public IEnumerable<KeyValuePair<int, string>> GetTimestamps() {
            return bookingRepository.GetTimestamps();
        }
    }
}