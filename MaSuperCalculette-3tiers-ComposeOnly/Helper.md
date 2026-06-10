# prereq
docker ps
    -> plus de container demo en run

docker network ls
    -> plus de network demo

docker volume ls
    -> plus de volume de démo

## Build des images si image pas dispo
docker build -f MaSuperCalculette-Api\Dockerfile -t masupercalculette-api:latest  .
docker build -f MaSuperCalculette\Dockerfile -t masupercalculette-front:latest  .

# compose.yaml 
## ecriture du compose
ouvrez le compose .yaml et expliquez le . Il s'agit de la transposition de nos lifgne de commandes en un description d'etat attendu

## démarrage
docker compose up



## test 
docker ps ls
docker network ls
docker network inspect NOMDUNET 

test la navigation sur localhost:9999


## demarre en arriere plan
docker compose up -d 
docker compose ls
docker compose logs
