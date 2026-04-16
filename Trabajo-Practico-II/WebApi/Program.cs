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
            <style>
                element{
                margin: 0;
                }
                body {
                    font-family: Arial, sans-serif;
                    height: 100vh;
                    display: flex;
                    justify-content: center;
                    align-items: center;
                    flex-direction: column;
                }
                form {
                    display: flex;
                    flex-direction: column;
                    max-width: 300px;
                }
                label {
                    margin-top: 10px;
                }
                input {
                    padding: 5px;
                    margin-top: 5px;
                    border-radius:3px;
                    border: 1px solid black;
                }
                button {
                    margin-top: 15px;
                    padding: 10px;
                    background-color: #4CAF50;
                    color: white;
                    border: none;
                    cursor: pointer;
                    border-radius:3px
                }   
            </style>
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
