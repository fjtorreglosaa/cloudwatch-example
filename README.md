Install

- AWSSDK.CloudWatchLogs          --> Se usa para usar logs con aws
- AWS.Logger.AspNetCore          --> Se usa para integrar los logs de aws con los que vienen por defecto en .net
- AWS.Logger.Serilog             --> Se usa para serializar los logs, y darles formato para que las busquedas en el cloudwatch sean mas faciles
- Serilog                        --> Libreria que permite serializar los logs
- Serilog.AspNetCore             --> Da formato o serializa los logs de asp.netcore
- Serilog.Settings.Configuration --> Dado que necesitamos archivos de configuracion para usar serilog, se requere este paquete

Usando el CloudWatch con serilog se puede filtrar de la siguiente forma:

{$.city= Monteria} filtra los logs que tienen Monteria
{$.city= Monteria && $.count > 1} filtra los logs que tienen Monteria y son mayores que 1
