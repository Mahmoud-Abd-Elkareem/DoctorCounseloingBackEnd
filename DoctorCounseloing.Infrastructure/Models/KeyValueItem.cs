namespace DoctorCounseloing.Infrastructure.Models
{
    public record KeyValueItem<TKey>
    {
        public KeyValueItem(TKey key, string value)
        {
            Key = key;
            Value = value;
        }

        public TKey Key { get; init; }
        public string Value { get; init; }
    }
}
