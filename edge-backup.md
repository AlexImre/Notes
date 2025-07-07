edge-backup

steps for reference
 
SQL
`sudo tar -vczf appdata_backup.tar.gz /var/lib/docker/volumes/appdata/_data`
take tar backup of the files in the app data docker volume
this does take a little while, hence the -v flag to track progress a little bit
1.3G worth of market report images and like 400M of logs
 
SQL
`smbclient //172.24.1.34/dbbackups`
transferring this backup to the share is simplest (imo) with the smbclient which I've installed on the server
 
you obviously need to have credentials that have perms to write files to it

to run the DB backup ad hoc
connect via SSMS to 10.10.100.6 (edge DB) using the SA acc in RDM
run the sql server agent backup job
ssh to server as amius2023532
run ~/backupmove.sh
copy backup from ~/ dir to backup10 (smbclient again most likely)