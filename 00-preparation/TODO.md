# Configuration de votre machine virtuelle

Connectez vous à votre machine virtuelle

- soit avec le client remote desktop natif de windows
- soit via le bastion Azure (déjà créé)

Il va falloir installer :

- WSL 2
- Docker desktop
- GIT
- Virsual Studio Community Edition

## 1 - Installation de WSL 2

Lancez une invite de commande (cmd)

```cmd
wsl --status
wsl --install 
```

Rebootez votre VM.

Lancez une invite de commande (cmd)

```cmd
wsl --status
wsl --list 
wsl --list --online 
```

## 2 - Installation de Docker Desktop

- Téléchargez Docker Desktop : https://www.docker.com/products/docker-desktop/ 
- Lancez l’installation :
  - Per User Installation (Recommended)”
  - WSL 2
- Démarrez Docker Desktop (double clic sur l’icone)
  - Acceptez la licence
  - “Skip” l’enregistrement
- Lancez une invite de commande (cmd)

```cmd
    wsl --status
    wsl --list 
    docker run hello-world
```

## 3 - Installation de GIT

- Téléchargez GIT “standalone installer” sur https://git-scm.com/install/windows 
- Lancez l’installation, options par défaut.
- Lancez une invite de commande (cmd)

```cmd
    git --version 
```

## 4 - Installation de Visual Studio Community Edition

- Téléchargez “Visual Studio Community” sur https://visualstudio.microsoft.com/downloads/ 
- Sélectionnez les Workloads :
  - ASP.Net and web development
  - Azure and AI development
  - NodeJS development
- Cliquez sur “Install”
- Coffee pause (ou Tea pause, ou Limonad pause , …)

## 5 - Récupération du code source des exemples/lab/démo

Le code source se trouve dans le repo github : https://github.com/flyingoverclouds/application-containerisation 

- Lancer une invite de commande (cmd)

```cmd
cd \
md repos
cd repos
git clone https://github.com/flyingoverclouds/application-containerisation 
```



