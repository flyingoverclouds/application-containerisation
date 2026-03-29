## Génération des images
### se mettre dans le dosser de la solution ( .slnx)
docker build -f MaSuperCalculette-Api\Dockerfile -t masupercalculette-api:latest  .
docker build -f MaSuperCalculette\Dockerfile -t masupercalculette-front:latest  .

## Execution de l'application 

### creation d'un volume pour les logs
docker volume create log_de_calcul 
docker inspect log_de_calcul


### demarrer l'api avec le volume nommé
docker run -p 8877:8080 --mount type=volume,src=log_de_calcul,target=/calclog  masupercalculette-api:latest

### démo avec les .http

### suppression du volume
docker volume rm log_de_calcul


### démarrer l'api en partageant un dossier local de l'OS 
mkdir c:\calclog
docker run -p 8877:8080 --mount type=bind,src=c:\calclog,target=/calclog  masupercalculette-api:latest



