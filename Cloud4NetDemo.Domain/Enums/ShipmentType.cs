namespace Cloud4NetDemo.Domain.Enums
{
    public enum ShipmentType
    {
        STANDARD,
        PRIORITY
        
        
    }

    public static class ShipmentTypeExtensions
    {
        public static ShipmentType fromCustomerGrade(this ShipmentType shipmentType, int grade)
        {
            if (grade >= 10)
            {
                return ShipmentType.PRIORITY;
            }

            return ShipmentType.STANDARD;
        } 
    }
}