using Microsoft.Data.SqlClient;
using Dapper;

namespace TPsinNumero.Models;

public class Integrantes
{
    private static string _connectionString = @"Server=localhost; DataBase=TPnoNum; Integrated Security=True; TrustServerCertificate=True;";
    public int IdIntegrante {get; set;}
    public string nombre {get; set;}
    public string password {get; set;}
    public string apellido {get; set;}
    public int telefono {get; set;}
    public string barrio {get; set;}
    public bool mascota {get; set;}
    public string hobbie {get; set;}
}

public Integrantes (int IdIntegrante, string nombre, string password, string apellido, int telefono, string barrio, bool mascota, string hobbie)
{
    this.IdIntegrante = IdIntegrante;
    this.nombre = nombre;
    this.password = password;
    this.apellido = apellido;
    this.telefono = telefono;
    this.barrio = barrio;
    this.mascota = mascota;
    this.hobbie = hobbie;
}

public List<Integrantes> AgregarIntegrantes(Integrantes inte)
{
    string query = "INSERT INTO Integrantes () VALUES ()";
}