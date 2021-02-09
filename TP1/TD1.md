# Description de « l’architecture » d’un serveur Web 

## Question 1
Nous devons utilisé le port 8080 ici car il s'agit d'un rappel pour le port standard d'un serveur Web. Le port 80 étant déjà utilisé.

# Tests avant de commencer

## Question 2
* J'exécute la commande `telnet www.tigli.fr 80` dans mon terminal.
* J'écris alors `GET /` dans la nouvelle fenêtre (bien que rien ne s'affiche lors de l'écriture)
* Lorsque la requête est correctement écrite, j'ai la réponse suivante :
```bash

<html><body><h1>Welcome to Nyx</h1></body></html>


Perte de la connexion à l’hôte.

```
* Lorsq'une requête n'est pas implémentée (comme `get /`), on obtient la réponse suivante :
```bash
<!DOCTYPE HTML PUBLIC "-//IETF//DTD HTML 2.0//EN">
                                                  <html><head>
                                                              <title>501 Method Not Implemented</title>
                                                                                                       </head><body>
                                                                                                                    <h1>Method Not Implemented</h1>
                           <p>get to /index.html not supported.<br />
                                                                     </p>
                                                                         <hr>
                                                                             <address>Apache/2.2.14 (Ubuntu) Server at nyx.unice.fr Port 80</address>
                             </body></html>


Perte de la connexion à l’hôte.

```

## Question 3
Comme le montre le screen ci-dessous, environ 40 requêtes sont nécessaires pour récupérer l'intégralité de la page.
<img alt="TD1-Q3" src="resources/TD1-Q3.png"/>

## Question 4
* Avec cache : <img alt="TD1-Q4-Cache" src="resources/TD1-Q4-Cache.png"/>
* Sans cache : <img alt="TD1-Q4-Cacheless" src="resources/TD1-Q4-Cacheless.png"/>
