## Génération des images
### se mettre dans le dosser de la solution ( .slnx)
docker build -f MaSuperCalculette-Api\Dockerfile -t masupercalculette-api:latest  .
docker build -f MaSuperCalculette\Dockerfile -t masupercalculette-front:latest  .

## Execution de l'application 

### demarrer l'api avec le volume nommé
mkdir c:\calclog
docker run -d -p 8877:8080 --mount type=bind,src=c:\calclog,target=/calclog  masupercalculette-api:latest
docker run -p 9999:8080  masupercalculette-front:latest

### tester l'app
browse vers http://localhost:9999
--> ERREUR (Expliquer) 

### démarrer le front en changeant le settings 
docker run -p 9999:8080 --env CalculatorUrl=192.168.14.214:8877  masupercalculette-front:latest

### tester l'app
browse vers http://localhost:9999
Ca marche !!!
Montrer les IP 172. ....

### démarrer le front en changeant en pointant sur l'ip privé docker
docker run -p 9999:8080 --env CalculatorUrl=172.17.0.4:8080  masupercalculette-front:latest


### arreter l'api 
docker ls 
docker stop  APIID

### redémarrer l'api sans port expose à l'extieur
docker run -d --mount type=bind,src=c:\calclog,target=/calclog  masupercalculette-api:latest

### expliquer pour 

## NETWORK 

### expliquer les types de reseau
docker network ls 

### contenu du reseau bridge
docker network inspect bridge
	expliquer le contenu


## Isolation de notre application
docker network create calculator_app
docker network ls
docker network inspect calculator_app

docker run --network calculator_app --mount type=bind,src=c:\calclog,target=/calclog  masupercalculette-api:latest
docker network inspect calculator_app
	montrer l'ip du container

docker run --network calculator_app -p 9999:8080 --env CalculatorUrl=172.18.0.2:8080  masupercalculette-front:latest
	lancer en mettant a jour l'ip du calculator

tester avec un browser sur :9999 -> ca marche. 

## Utilisation du dns interne
montrer les id et les hostname qui sont affié par l'app

docker run --network calculator_app -p 9999:8080 --env CalculatorUrl=IDDUCONTAINER:8080  masupercalculette-front:latest
	relancer le front en mettant l'id au lieu de l'ip

docker ps 
	montrer le nom sympa du container

docker run --network calculator_app -p 9999:8080 --env CalculatorUrl=NOM_SYMPA_CONTAINER:8080  masupercalculette-front:latest
	monter le nom sympa du container


## redemarrage propre et nom dns custom 
docker run --network calculator_app --network-alias api --mount type=bind,src=c:\calclog,target=/calclog  masupercalculette-api:latest

docker network inspect calculator_app

docker run --network calculator_app -p 9999:8080 --env CalculatorUrl=api:8080  masupercalculette-front:latest


# clean
stop les 2 container app

docker network rm calculator_app
docker volume rm calclog





