// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Dapper;
using DapperCore6;
using System.Data.SqlClient;

string connection = "Data Source=DESKTOP-GEK0V2E; Initial Catalog=DotNetBookmarks; Integrated Security=True;"; //Connection using windows authentication
//string connection2 = "Data Source=DESKTOP-GEK0V2E; Initial Catalog=DotNetBookmarks; User ID=UserName; Password=myPass"; //Connection

using (var db = new SqlConnection(connection))
{
    // INSERT
    var sqlInsert = "insert into test(entero, cadena, fechahora) Values(@entero, @cadena, @fechahora)";
    var result = db.Execute(sqlInsert, new { entero = 123, cadena = "Felipe", fechahora = DateTime.Now });


    // UPDATE first
    var sqlEdit= "update test set cadena=@cadena where id=@id";
    var resultEdit = db.Execute(sqlEdit, new { cadena = "Miguel Ángel", id = 1 });
    
    // SELECT
    var sqlSelect = "select id, entero, cadena, fechahora from Test";

    var lst = db.Query<Test>(sqlSelect);

    foreach (var item in lst)
    {
        Console.WriteLine(item.id);
        Console.WriteLine(item.entero);
        Console.WriteLine(item.cadena);
        Console.WriteLine(item.fechahora);
        Console.WriteLine();
    }

    // SELECT ONE
    var sqlSelectOne = "select id, entero, cadena, fechahora from test where id=@id";
    var element = db.QueryFirst<Test>(sqlSelectOne, new { id = 4 });
    Console.WriteLine($"{element.id} - {element.entero} - {element.cadena} - {element.fechahora}");
}