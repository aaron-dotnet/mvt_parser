# MVT Parser - Mobile Verification Toolkit

## Descripción

Proyecto para parsear y analizar los archivos de salida generados por MVT (Mobile Verification Toolkit) de Amnesty International. MVT es una herramienta forense de código abierto utilizada para detectar spyware como Pegasus en dispositivos Android.

## Archivos MVT

| Archivo | Tipo | Descripción |
|---------|------|-------------|
| `timeline.csv` | CSV | Línea de tiempo de eventos del sistema (archivos modificados, paquetes instalados, SMS enviados/recibidos) |
| `files.json` | JSON | Lista de archivos del dispositivo con metadatos (path, permisos, propietario, tamaño) |
| `getprop.json` | JSON | Propiedades del sistema Android (configuraciones del sistema) |
| `info.json` | JSON | Metadata de la extracción (versión MVT, fecha, indicadores IOC usados) |
| `packages.json` | JSON | Paquetes instalados (APKs, permisos, versiones, timestamps) |
| `processes.json` | JSON | Procesos en ejecución al momento de la extracción |
| `selinux_status.json` | JSON | Estado de SELinux (enforcing/permissive) |
| `settings.json` | JSON | Configuraciones del sistema (system, secure, global settings) |
| `sms.json` | JSON | Mensajes SMS (contenido, remitente, destinatario, timestamps) |
| `dumpsys.txt` | TXT | Output de servicios del sistema Android |
| `logcat.txt` | TXT | Log del sistema (crashes, errores, eventos) |
| `command.log` | LOG | Log de ejecución de comandos MVT |

## Estructura del Proyecto

```
MvtParser/
├── Models/
│   ├── Record.cs          (timeline.csv)
│   ├── FileEntry.cs       (files.json)
│   ├── AndroidProperty.cs  (getprop.json)
│   ├── ExtractionInfo.cs   (info.json)
│   ├── Package.cs         (packages.json)
│   ├── Process.cs         (processes.json)
│   ├── SelinuxStatus.cs   (selinux_status.json)
│   ├── SystemSettings.cs  (settings.json)
│   ├── SmsMessage.cs      (sms.json)
│   └── LogEntry.cs        (logcat.txt, command.log)
├── Parsers/
│   ├── TimelineParser.cs
│   ├── FilesParser.cs
│   ├── PackagesParser.cs
│   └── ...
└── Program.cs
```

## Estado Actual

- [x] Parser básico de `timeline.csv` funcionando
- [ ] Parsers para archivos JSON
- [ ] Parsers para archivos de texto
- [ ] Filtros por plugin y evento
- [ ] Generación de estadísticas

## Uso

```bash
dotnet run
```

## Requisitos

- .NET 10
- Archivos de salida MVT en formato JSON/CSV/TXT

## Notas

- Los archivos originales pueden contener millones de líneas
- El parsing debe ser optimizado para archivos grandes
- Encoding: UTF8 para archivos JSON, configurable para CSV