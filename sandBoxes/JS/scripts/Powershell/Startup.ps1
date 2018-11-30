#param([Bool]$shutdown)

#if($shutdown == false)
#{
#RabbitMQ
$pi = New-Object System.Diagnostics.ProcessStartInfo
$pi.FileName = "powershell.exe"
$pi.Arguments = "-noexit C:\Users\jspar\source\repos\andy85m1\micro-test-system\sandBoxes\JS\scripts\Powershell\RabbitMQ.ps1"
[System.Diagnostics.Process]::Start($pi)

Start-Sleep -s 10

#MongoDB
$pi = New-Object System.Diagnostics.ProcessStartInfo
$pi.FileName = "powershell.exe"
$pi.Arguments = "-noexit C:\Users\jspar\source\repos\andy85m1\micro-test-system\sandBoxes\JS\scripts\Powershell\MongoDB.ps1"
[System.Diagnostics.Process]::Start($pi)

Start-Sleep -s 10

#Actio.Api
$pi = New-Object System.Diagnostics.ProcessStartInfo
$pi.FileName = "powershell.exe"
$pi.Arguments = "-noexit C:\Users\jspar\source\repos\andy85m1\micro-test-system\sandBoxes\JS\scripts\Powershell\Actio.Api.ps1"
[System.Diagnostics.Process]::Start($pi)


#Actio.Services.Activities
$pi = New-Object System.Diagnostics.ProcessStartInfo
$pi.FileName = "powershell.exe"
$pi.Arguments = "-noexit C:\Users\jspar\source\repos\andy85m1\micro-test-system\sandBoxes\JS\scripts\Powershell\Actio.Services.Activities.ps1"
[System.Diagnostics.Process]::Start($pi)
#}