// See https://aka.ms/new-console-template for more information

using AM.ApplicationCore.Domain;

Console.WriteLine("Hello, World!");
//Plane p1= new Plane(100,new DateTime(12/12/2022),1);

//initialiseur d'objets, remplace les constructeurs paramétrés


Plane p2 = new Plane
{
    Capacity= 100,
    ManufactureDate = DateTime.Now,
    PlaneId=1000 
};

Passenger p1 = new Passenger
{
    FirstName = "Testp",
    LastName = "Testp",
    EmailAddress = "testp@gmail.com"
};

Staff s1 = new Staff
{
    FirstName = "Tests",
    LastName = "Tests",
    EmailAddress = "staff@gmail.com"
};
Traveller t1 = new Traveller
{
    FirstName = "TestT",
    LastName = "TestT",
    EmailAddress = "traveller@gmail.com"
};

Console.WriteLine(p1.CheckProfile("Testp", "Testp"));
Console.WriteLine(p1.CheckProfile("m", "m","pass@gmail.com"));

p1.PassengerType();
t1.PassengerType();
s1.PassengerType();

