// See https://aka.ms/new-console-template for more information

using AM.ApplicationCore.Domain;

Console.WriteLine("Hello, World!");
Plane p1= new Plane(100,new DateTime(12/12/2022),1);
//initialiseur d'objets


Plane p2 = new Plane
{
    Capacity= 100,
    ManufactureDate =new DateTime(12-12-2022)
};
