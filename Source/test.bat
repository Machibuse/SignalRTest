dotnet publish Client\Client.csproj -o C
dotnet publish Host\Host.csproj -o H

start C\Client.exe user01
start C\Client.exe user02
start C\Client.exe user03
start C\Client.exe user04
start C\Client.exe user05
start C\Client.exe user06
start C\Client.exe user07
start C\Client.exe user08
start C\Client.exe user09
start C\Client.exe user10
start C\Client.exe user11
start C\Client.exe user12
start C\Client.exe user13
start C\Client.exe user14
start C\Client.exe user15
start C\Client.exe user16
start C\Client.exe user17
start C\Client.exe user18
start C\Client.exe user19
start C\Client.exe user20


:loop

H\Host.exe 


goto loop