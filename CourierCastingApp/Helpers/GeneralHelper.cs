using System.ComponentModel.DataAnnotations;

namespace CourierCastingApp.Helpers
{
    public enum DeliveryStatus
    {
        [Display(Name = "Nie odebrano")]
        NotPickedUp = 0,
        [Display(Name = "Odebrano")]
        PickedUp = 1,
        [Display(Name = "Dostarczono")]
        Delivered = 2,
        [Display(Name = "Anulowano")]
        Cancelled = 3
    }

    public enum ClientStatus
    {
        [Display(Name = "Klient")]
        Client = 0,
        [Display(Name = "Kurier")]
        Courier = 1,
        [Display(Name = "Pracownik firmy")]
        OfficeWorker = 2
    }

    public class Result
    {
        public bool Success { get; set; }
        public string Error { get; private set; }
        public bool isFailure => !Success;

        protected Result(bool success, string error)
        {
            if (success && error != string.Empty)
                throw new InvalidOperationException();
            if (!success && error == string.Empty)
                throw new InvalidOperationException();
            Success = success;
            Error = error;
        }   

        public static Result Fail(string message)
        {
            return new Result(false, message);
        }
        public static Result<T> Fail<T>(string message)
        {
            return new Result<T>(default(T)!, false, message);
        }
        public static Result Ok()
        {
            return new Result(true, string.Empty);
        }
        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value, true, string.Empty);
        }
    }

    public class Result<T> : Result
    {
        public T Value { get; set; }

        protected internal Result(T value, bool success, string error)
            :base(success, error)
        {
            Value = value;
        }
    }
}
