var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// 1. Método GET a la raiz. ("/")
app.MapGet("/", () => 
{  
    // HTML 
    string formularioHTML = @"
        <!DOCTYPE html>
        <html lang='es'>
        <head>
            <meta charset='UTF-8'>
            <title>Formulario GET</title>
        </head>
        <body>
            <h2>Formulario de prueba</h2>
            
            <form action='/procesar' method='POST'> 
                <label for='nombre'>Nombre:</label>
                <input type='text' id='nombre' name='nombre'>
                
                <label for='correo'>Correo:</label>
                <input type='text' id='correo' name='correo'>
                <br>    
            
                <button type='submit'>Enviar Datos</button>
            </form>
        </body>
        </html>";

    return Results.Content(formularioHTML, "text/html");
 
 });

// 2. Método POST para procesar los datos.
app.MapPost("/procesar", async (HttpRequest request) =>
{ 
});

app.Run();
