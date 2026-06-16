namespace ArchivosInfo;

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

    public string CadenaDeArchivo()
    {
        double tamanioKB = Math.Round(Tamanio / 1024.0, 2);
        return $"{Nombre},{tamanioKB},{UltimaFechaDeModificacion}";
    }
}