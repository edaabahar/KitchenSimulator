class Appliance<T>(int capacity, bool hasThermostat) : Storage<T>(capacity) where T : KitchenObject
{
    public bool IsPowerOn { get; set; } = false;

    public float DesiredTemperature { get; set; }

    public bool HasThermostat { get; set; } = hasThermostat;
}