using System;

namespace SamsLibrary
{

    // Standard Implementing an Interface
    public interface IVehicle
    {
        void DriveVehicle();
    }


    public class Vehicle : IVehicle
    {
        public Vehicle()
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


    // Standard Implementing an Abstract Class that already has a DriveVehicle function implemented.
    public abstract class AbstractVehicle
    {
        void DriveVehicle()
        {
            // Broom Broom!
        }
    }


    public class Car : AbstractVehicle
    {
        public Car()
        {

        }

        public double speed;
        public int numberOfWheels;
        public string model;
        public string typeOfVehicle;

        public void DriveVehicle()
        {
            // BrrrBroom!
        }
    }

}