using System.Collections.Generic;

namespace UseCases {

    public interface IGetTimestampUseCase {

        string GetTimestampByKey(int key);

        IEnumerable<KeyValuePair<int, string>> GetTimestamps();
    }
}