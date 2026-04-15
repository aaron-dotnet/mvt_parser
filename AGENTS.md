# AGENTS.md

## Ejecutar proyecto

```bash
dotnet run
```

## Leer primero

`README.md` está en español. Contiene la descripción del proyecto, estructura de archivos MVT soportados y estado actual de desarrollo.

## Requisitos

- .NET 10
- dotnet add package Newtonsoft.Json

## Estado del proyecto

Parsers implementados:

- timeline.csv: Parseo básico (CSV con fechas, Plugins, Events)
- files.json: ✅ FilesParser.ParseAsync()
- packages.json: ✅ PackagesParser.ParseAsync()
- settings.json: ✅ SettingsParser.ParseAsync()
- getprop.json: ✅ GetpropParser.ParseAsync()
- processes.json: ✅ ProcessesParser.ParseAsync()
- sms.json: ✅ SmsParser.ParseAsync()
- info.json: ✅ InfoParser.ParseAsync()
- selinux_status.json: ✅ SelinuxParser.ParseAsync()
- logcat.txt: ✅ LogcatParser.ParseAsync()
- command.log: ✅ CommandLogParser.ParseAsync()
- dumpsys.txt: ✅ DumpsysParser.ParseServicesAsync()

Modelos en Models/: FileEntry, Package, SystemSettings, AndroidProperty, Process, SmsMessage, ExtractionInfo, SelinuxStatus, LogEntry, CommandLogEntry, DumpsysService

Samples en samples/: archivos genéricos para pruebas

## Notas de desarrollo

- Archivos MVT pueden tener millones de líneas; parsers usan async streaming
- Encoding: UTF8 para JSON y TXT
- Para archivos grandes, usar JSON deserialization con System.Text.Json
- LogcatParser parsea formato: "MM-DD HH:MM:SS.mmm PID TID L TAG: message"
- CommandLogParser parsea formato: "yyyy-MM-dd HH:MM:SS,mmm - module - level - message"
- dumpsys solo extrae lista de servicios activos