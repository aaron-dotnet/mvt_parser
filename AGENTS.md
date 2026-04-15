# AGENTS.md

## Ejecutar

```bash
dotnet run
```

## Notas

- Proyecto parsea archivos de salida MVT (Mobile Verification Toolkit)
- READMEs en español
- .NET 10 requerido
- Samples en directorio `samples/`

## Parsers implementados

| Archivo | Parser |
|---------|--------|
| timeline.csv | TimelineParser |
| files.json | FilesParser |
| packages.json | PackagesParser |
| settings.json | SettingsParser |
| getprop.json | GetpropParser |
| processes.json | ProcessesParser |
| sms.json | SmsParser |
| info.json | InfoParser |
| selinux_status.json | SelinuxParser |
| logcat.txt | LogcatParser |
| command.log | CommandLogParser |
| dumpsys.txt | DumpsysParser |

## Desarrollo

- Archivos MVT reales pueden tener millones de líneas
- Parsers usan async streaming para archivos grandes
- Serialization con System.Text.Json
- Logcat: formato "MM-DD HH:MM:SS.mmm PID TID L TAG: message"
- Command log: formato "yyyy-MM-dd HH:MM:SS,mmm - module - level - message"
- Dumpsys solo extrae lista de servicios activos (no parsea contenido completo)