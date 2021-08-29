namespace ICBF.MICAV.Domain.Base
{
    public interface IEntidad<T>
    {
        T Id { get; set; }
    }
}