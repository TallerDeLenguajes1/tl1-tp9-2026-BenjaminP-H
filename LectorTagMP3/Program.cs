using MP3;
using System.Text;//lo uso para combertir bytes a texto

// Solicita la ruta del archivo MP3
Console.WriteLine("Ingrese el archivo formaro MP3: ");
string ruta = Console.ReadLine();

// Verifica que el archivo exista
if (!File.Exists(ruta))
{
    Console.WriteLine("El archivo no existe.");
    return;
}

// Abro el archivo en modo lectura
FileStream archivo = new FileStream(
    ruta,
    FileMode.Open,
    FileAccess.Read
);

// El tag ID3v1 se encuentra siempre en los últimos 128 bytes del archivo
archivo.Seek( -128, SeekOrigin.End);

// Permite leer datos binarios desde el archivo
BinaryReader lector = new BinaryReader(archivo);

// Lee los 128 bytes correspondientes al tag
byte[] datosTag = lector.ReadBytes(128);

//===================== Obtengo los datos necesarios del TAG =====================//
string header = Encoding.GetEncoding("latin1").GetString(datosTag, 0, 3).Trim();

string titulo = Encoding.GetEncoding("latin1").GetString(datosTag, 3, 30).Trim();

string artista = Encoding.GetEncoding("latin1").GetString(datosTag, 33, 30).Trim();

string album = Encoding.GetEncoding("latin1").GetString(datosTag, 63, 30).Trim();

string anio = Encoding.GetEncoding("latin1").GetString(datosTag, 93, 4).Trim();

// Verifica que el archivo tenga un tag ID3v1 válido
if (header != "TAG")
{
    Console.WriteLine("El archivo no contiene un Tag ID3v1 válido.");
    return;
}

// Carga los datos obtenidos en un objeto Id3v1Tag

Id3v1Tag tag = new Id3v1Tag
{   
    Titulo = titulo,
    Artista = artista,
    Album = album,
    Anio = anio,
};

// Muestra la información obtenida del archivo MP3
Console.WriteLine($"Título: {tag.Titulo}");
Console.WriteLine($"Artista: {tag.Artista}");
Console.WriteLine($"Álbum: {tag.Album}");
Console.WriteLine($"Año: {tag.Anio}");

// Cierra los recursos utilizados
lector.Close();
archivo.Close();
