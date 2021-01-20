namespace Loja.Domain.Shared.Command
{
    public interface IGenericCommandResult
    {
        bool Success { get; set; }
        string Message { get; set; }
        object Errors { get; set; }
        object Data { get; set; }
    }
}
