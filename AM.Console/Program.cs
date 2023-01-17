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
