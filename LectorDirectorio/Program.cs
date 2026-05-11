string ruta;


Console.WriteLine("Ingrese la ruta de la carpeta:");
ruta = Console.ReadLine();
if(Directory.Exists(ruta))//Verifico que la ruta exista
{  
    if(!File.Exists("reporte_archivos.csv"))//Verifico que el archivo reporte este creado
    {
        File.Create("reporte_archivos.csv");//Creo el archivo
    }
    //tring[] archivos = Directory.GetFiles(ruta);
    foreach(var file in Directory.GetDirectories(ruta).ToList())//aca muestro la carpetas
    {
        Console.WriteLine($"Carpetas: {ruta}");
    }

    List<ArchivoInfo> archivosInfos = new List<ArchivoInfo>();

    foreach(var file in Directory.GetFiles(ruta).ToList())
    {
        FileInfo  info = new FileInfo(file);
        Console.WriteLine($"Archivo: {info.Name}"+ "-" + $"Tamaño: {info.Length} bytes" + "-" + $"Fecha de modificacion: {info.LastWriteTime}");
        var _archivosInfo = new ArchivoInfo(info.Name, info.Length,info.LastWriteTime);
        archivosInfos.Add(_archivosInfo);
    }

    foreach (var archivo in archivosInfos)
    {
        Console.ReadLine(archivo.cadenaDeArchivo);
    }
}
else
{
    Console.WriteLine("La ruta que ingreso no exite o no se encontro");
    Directory.CreateDirectory(ruta);
}


public  class ArchivoInfo
{
    public string Nombre {get; set;}
    public long Tamanio {get; set;}
    public DateTime UltimaFechaDeModificacion {get; set;}

    public ArchivoInfo(string name, long length, DateTime lastWriteTime)
    {
        Nombre = name;
        Tamanio = length;
        UltimaFechaDeModificacion = lastWriteTime;
    }

    public string cadenaDeArchivo()
    {
        return $"{Nombre},{Tamanio},{UltimaFechaDeModificacion}";
    }
}