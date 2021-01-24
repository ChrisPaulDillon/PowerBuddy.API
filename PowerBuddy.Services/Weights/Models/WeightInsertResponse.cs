namespace PowerBuddy.Services.Weights.Models
{
    public class WeightInsertResponse<T>
    {
        public bool IsMetric { get;  }
        public T Data { get; }

        private WeightInsertResponse(bool isMetric, T data)
        {
            IsMetric = isMetric;
            Data = data;
        }

        public static WeightInsertResponse<T> UsingMetric(T data)
        {
            return new WeightInsertResponse<T>(true, data);
        }

        public static WeightInsertResponse<T> NotMetric(T data)
        {
            return new WeightInsertResponse<T>(false, data);
        }
    }
}
