using Microsoft.Data.SqlClient;
using Dapper;
using Newtonsoft.Json;

namespace TPsinNumero.Models;

public class Integrantes
{
     [JsonProperty]
     private static string _connectionString = @"Server=localhost; DataBase=TPnoNum; Integrated Security=True; TrustServerCertificate=True;";
     [JsonProperty]
     public int IdIntegrante {get; set;}
    [JsonProperty] 
    public string nombre {get; set;}
     [JsonProperty]
     public string password {get; set;}
     [JsonProperty]
     public string apellido {get; set;}
     [JsonProperty]
     public int telefono {get; set;}
     [JsonProperty]
     public string barrio {get; set;}
     [JsonProperty]
     public bool mascota {get; set;}
     [JsonProperty]
     public string hobbie {get; set;}

public Integrantes() { }
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

public Integrantes VerificarIntegrantes(string nombreUsuario, string contraseña)
{
    Integrantes integrante = null;
    using(SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "SELECT * FROM Integrantes WHERE password = @pPassword AND nombre = @pNombre";
        integrante = connection.QueryFirstOrDefault<Integrantes>(query, new {pNombre = nombreUsuario, pPassword = contraseña});
    }
    return integrante;
}

public List<Integrantes> AgregarIntegrantesALista()
{
    List<Integrantes> integrantes = new List<Integrantes>();
    using(SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "SELECT * FROM Integrantes";
        integrantes = connection.Query<Integrantes>(query).ToList();
    }
    return integrantes;
}
}