using ArchivosInfo;

string ruta;

List<ArchivoInfo> archivosInfo = new List<ArchivoInfo>();




Console.WriteLine("Ingrese la ruta de la carpeta:");
ruta = Console.ReadLine();
string rutaCSV = Path.Combine(ruta, "reporte_archivos.csv");


    //Verifico que la ruta exista
    if(Directory.Exists(ruta))
    {  
        //---------------Verifico que el archivo reporte este creado---------------//
        if(!File.Exists(rutaCSV))
        {
            File.Create(rutaCSV).Close();//el close para no tener error en futuro
        }
        //=============Muestro Las Carpetas =============//
        foreach(var file in Directory.GetDirectories(ruta))
        {
            string nombreCarpeta = Path.GetFileName(file);
            Console.WriteLine($"Carpetas: {nombreCarpeta}");
        }

        //=============Muestro Los Archivos=============//

        foreach(var file in Directory.GetFiles(ruta))
        {
            FileInfo  info = new FileInfo(file);

            double tamanioKB = Math.Round(info.Length / 1024.0, 2);

            Console.WriteLine($"{info.Name} - {tamanioKB} KB");

            var archivosInformacion = new ArchivoInfo
                (
                info.Name,
                info.Length,
                info.LastWriteTime
                );
            archivosInfo.Add(archivosInformacion);
        }
        //=============Redacto el informe .csv=============//

        List<string> lineasCSV = new List<string>();
        lineasCSV.Add("Nombre del Archivo,Tamaño (KB),Fecha de Última Modificación");

        foreach(var archivo in archivosInfo)
        {
            lineasCSV.Add(archivo.CadenaDeArchivo());
        }
        File.WriteAllLines(rutaCSV, lineasCSV);
    }
    else
    {
        Console.WriteLine("La ruta que ingreso no exite o no se encontro");
        Console.WriteLine("Creando ruta a continuacion");
        Directory.CreateDirectory(ruta);
    }   

