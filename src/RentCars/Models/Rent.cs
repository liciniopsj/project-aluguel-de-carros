using RentCars.Types;

namespace RentCars.Models;

public class Rent
{
    public Vehicle Vehicle { get; set; }
    public Person Person { get; set; }
    public int DaysRented { get; set; }
    public Type PersonType { get; }
    public double Price { get; set; }
    public RentStatus Status { get; set; }

    //10 - Crie o construtor de `Rent` seguindo as regras de negócio
    public Rent(Vehicle vehicle, Person person, int daysRented)
    {
        Vehicle = vehicle;
        Person = person;
        DaysRented = daysRented;
        PersonType = Person.GetType();

        if (PersonType == typeof(PhysicalPerson))
        {
            Price = Vehicle.PricePerDay * daysRented;
        }
        else
        {
            Price = Vehicle.PricePerDay * daysRented;
            Price *= 0.9;
        }
        

        Status = RentStatus.Confirmed;
        vehicle.IsRented = true;
        person.Debit = Price;
    }

    //11 - Implemente os métodos de `cancelar` e `finalizar` um aluguel
    public void Cancel()
    {
        Status = RentStatus.Canceled;
    }

    //11 - Implemente os métodos de `cancelar` e `finalizar` um aluguel
    public void Finish()
    {
        Status = RentStatus.Finished;
    }
}