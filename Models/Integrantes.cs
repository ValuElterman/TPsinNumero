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

public void CrearIntegrantes(Integrantes inte)
{
    string query = "INSERT INTO Integrantes (IdIntegrante, nombre, password, apellido, telefono, barrio, mascota, hobbie) VALUES (@pIdIntegrante, @pnombre, @ppassword, @papellido, @ptelefono, @pbarrio, @pmascota, @phobbie )";
    using(SqlConnection connection = new SqlConnection(_connectionString))
    {
        connection.Execute(query, new {pIdIntegrante = inte.IdIntegrante, pnombre = inte.nombre, ppassword = inte.password, papellido = inte.apellido, ptelefono = inte.telefono, pbarrio = inte.barrio, pmascota = inte.mascota, phobbie = inte.hobbie});
    }
}

public List<Integrantes> AgregarIntegrantes()
{
    List<Integrantes> integrantes = new List<Integrantes>();
    using(SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "SELECT * FROM Integrantes";
        integrantes = connection.Query<Integrantes>(query).ToList();
    }
}
}