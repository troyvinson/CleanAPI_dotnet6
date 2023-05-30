namespace Domain.RequestFeatures
{
    public abstract class BaseParameters
    {
        public string? SearchTerm { get; set; }
        public virtual string? OrderBy { get; set; } = "id";
    }
}
