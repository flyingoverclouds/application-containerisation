docker build . -t masupercalculette-1tiers-minidockerfile

docker image inspect masupercalculette-1tiers-minidockerfile:latest

docker  run -p 8080:8080 masupercalculette-1tiers-minidockerfile:latest 

Ctrl-C

docker ps 
docker ps -a

docker start XXXXXX

docker exec -i XXXXXX pwd
docker exec -i XXXXXX ls
docker exec -i XXXXXX sh

docker exec -i XXXXXX /bin/pwsh
	get-childitem env:
	exit

docker logs XXXXXX

docker stop XXXXXX

docker rm XXXXXX


