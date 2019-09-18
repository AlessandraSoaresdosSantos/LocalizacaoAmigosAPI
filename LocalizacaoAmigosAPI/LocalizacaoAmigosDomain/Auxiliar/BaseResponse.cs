namespace LocalizacaoAmigos.Domain.Auxiliar
{
    public abstract class BaseResponse
    {
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }

        public BaseResponse(bool success, string message)
        {
            Message = message;
            IsSuccess = success;
        }
    }
}
