namespace Remittance_Provider
{
    public enum ResponseStatus
    {
        SUCCESS = 200,
        CREATED = 201,
        INVALID_REQUEST = 400,
        UNAUTORIZED = 401,
        FORBIDDEN = 403,
        FAILED = 440,
        SERVICE_UNAVAILABLE = 503
    }
}
