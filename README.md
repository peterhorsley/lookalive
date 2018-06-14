### Pings a remote host to see if it's alive.

*Usage:*
	`LookAlive.exe [<hostname/IP> [arg1] [arg2] [...] [arg6]]`
	
<hostname/IP> - destination address to ping

*Optional arguments can be any of the following (in any order):*
<pingPeriod> - seconds between pings

<iconColour> - system tray icon colour

</d> - Disable notifications when host availability changes

</upIcon=<path>> - Path to an icon file to display when the host is online.

</dnIcon=<path>> - Path to an icon file to display when the host is offline.

<{[!]<fileName>[,args]}> - command to run when remote host state changes
Anywhere inside the braces, you can add the following strings for substitution:

{hostname_ip} - gets replaced with the remote hostname/IP

{time} - gets replaced with the current date and time

{state} - gets replaced with "online" or "offline" according to the state change

The optional ! character before the <fileName> hides windows created by the command.

Note: If there are any spaces between { and }, enclose the whole argument in quotes.
