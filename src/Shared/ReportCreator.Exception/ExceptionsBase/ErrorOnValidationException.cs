namespace ReportCreator.Exception.ExceptionsBase
{
    public class ErrorOnValidationException : ReportCreatorException
    {
        private readonly List<string> _errorMessages;
        
        public ErrorOnValidationException(List<string> errorMessages)
        {
            _errorMessages = errorMessages;
        }

        public List<string> GetErrorMessages()
        {
            return _errorMessages;
        }
    }
}
