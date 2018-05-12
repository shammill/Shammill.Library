using System;

// Standard Implementing an Interface
public interface IVehicle
{
    public double speed;
    public int numberOfWheels;
    public string model;
    public string typeOfVehicle;

    public void DriveVehicle();
}


public class Vehicle : IVehicle
{
    public void Vehicle()
    {
        
    }

    public double speed;
    public int numberOfWheels;
    public string model;
    public string typeOfVehicle;

    public void DriveVehicle()
    {

    }
}


// Standard Implementing an Abstract Interface that already has a DriveVehicle function implemented.
public abstract interface IAbstractVehicle
{
    public double speed;
    public int numberOfWheels;
    public string model;
    public string typeOfVehicle;

    public void DriveVehicle()
    {
        // Broom Broom!
    }
}


public class Vehicle : IAbstractVehicle
{
    public void Vehicle()
    {

    }

    public double speed;
    public int numberOfWheels;
    public string model;
    public string typeOfVehicle;

    public override void DriveVehicle()
    {
        // BrrrBroom!
    }
}