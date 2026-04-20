var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string FormularioHTML(string mensaje = "")
{
    // Determinar el tipo de mensaje y editar css.
    if (!string.IsNullOrEmpty(mensaje))
    {
        bool esError = mensaje.Contains("Error"); //Si el mensaje contiene la palabra "Error", es un error, sino es un mensaje de éxito.
        string color = esError ? "#f44336" : "#4CAF50";
        mensaje = $@"
            <div style='padding: 10px; margin-bottom: 20px; background-color: {color}; color: white; border-radius: 3px; text-align: center;'>
                <strong>{mensaje}</strong>
            </div>";
    }
    
    return $@"
        <!DOCTYPE html>
        <html lang='es'>
        
        <head>
            <meta charset='UTF-8'>
            <title>Formulario GET</title>
        
            <style>
                element{{
                margin: 0;
                }}
                body {{
                    font-family: Arial, sans-serif;
                    height: 100vh;
                    display: flex;
                    justify-content: center;
                    align-items: center;
                    flex-direction: column;
                }}
                form {{
                    display: flex;
                    flex-direction: column;
                    max-width: 300px;
                }}
                label {{
                    margin-top: 10px;
                }}
                input {{
                    padding: 5px;
                    margin-top: 5px;
                    border-radius:3px;
                    border: 1px solid black;
                }}
                button {{
                    margin-top: 15px;
                    padding: 10px;
                    background-color: #4CAF50;
                    color: white;
                    border: none;
                    cursor: pointer;
                    border-radius:3px
                }}   
            </style>
        </head>

        <body>
            <h2>Formulario de prueba</h2>
            {mensaje} <!-- Mensaje de error o éxito -->
             
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
}

// 1. Método GET a la raiz. ("/")
app.MapGet("/", () => 
{  
    return Results.Content(FormularioHTML(), "text/html");
 
 });

// 2. Método POST para procesar los datos.
app.MapPost("/procesar", async (HttpRequest request) =>
{
    // Traer los datos del formulario
    var form = await request.ReadFormAsync();
    
    string nombre = form["nombre"].ToString(); // [id del input], convertido a string.
    string correo = form["correo"].ToString();
    string mensaje = "";
    
    // Validar que los campos no estén vacíos
    if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(correo))
    {
        mensaje = "Error: Todos los campos son obligatorios. Por favor, completa el nombre y correo.";
    }
    // Validar que el correo contenga un @
    else if (!correo.Contains("@"))
    {
        mensaje = "Error: El correo debe contener el símbolo '@' para ser válido.";
    }
    
    // Si no entró a los ifs anteriores, quiere decir que los datos están bien.
    else
    {
        mensaje = $"Datos recibidos correctamente, Nombre: {nombre}, Correo: {correo}";
    }

    return Results.Content(FormularioHTML(mensaje), "text/html");
});

app.Run();
