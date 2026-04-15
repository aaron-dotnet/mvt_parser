# MVT Parser

## Descripción

Parser para archivos de salida del Mobile Verification Toolkit (MVT) de Amnesty International. MVT es una herramienta forense de código abierto usada para analizar dispositivos Android en busca de indicadores de spyware.

## Archivos soportados

| Archivo | Tipo | Descripción |
|---------|------|-------------|
| `timeline.csv` | CSV | Línea de tiempo de eventos |
| `files.json` | JSON | Archivos del dispositivo |
| `getprop.json` | JSON | Propiedades del sistema Android |
| `info.json` | JSON | Metadata de la extracción |
| `packages.json` | JSON | Paquetes instalados |
| `processes.json` | JSON | Procesos en ejecución |
| `selinux_status.json` | JSON | Estado de SELinux |
| `settings.json` | JSON | Configuraciones del sistema |
| `sms.json` | JSON | Mensajes SMS/MMS |
| `dumpsys.txt` | TXT | Servicios del sistema |
| `logcat.txt` | TXT | Log del sistema |
| `command.log` | LOG | Log de MVT |

## Estructura

```
mvt_parser/
├── Models/          # Modelos de datos
│   ├── FileEntry.cs
│   ├── Package.cs
│   ├── SmsMessage.cs
│   └── ...
├── Parsers/        # Parsers por archivo
│   ├── TimelineParser.cs
│   ├── FilesParser.cs
│   └── ...
└── Program.cs       # Punto de entrada
```

## Estado

Todos los parsers implementados y funcionales. Los archivos originales pueden superar los millones de líneas, por lo que los parsers usan async streaming.

## Requisitos

- .NET 10

## Uso

```bash
dotnet run
```

Los archivos de prueba están en el directorio `samples/`.