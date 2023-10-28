using System.ComponentModel.DataAnnotations;

namespace CourierAPI.Helpers;

public class RequiredEnumAttribute : RequiredAttribute
{
    public override bool IsValid(object? value)
    {
        if (value == null)
        {
            return false;
        }

        var type = value.GetType();
        return type.IsEnum && Enum.IsDefined(type, value);
    }
}
public enum DeliveryStatus
{
    NotPickedUp,
    PickedUp,
    Delivered,
    Cancelled
}

