# HttpListener

* Création d'une classe [`Header`](HttpListener/BasicServerHttpListener/Header.cs) pour utiliser ceux de la consigne.
* Affichage des headers non nuls dans la console dans le `Main`, à la ligne [`60`](HttpListener/BasicServerHttpListener/Program.cs#L60).

On peut imaginer récupérer les attributs de la classe que nous avons créé (à savoir [`Header`](HttpListener/BasicServerHttpListener/Header.cs)) pour faire des sauts conditionnels dans le `Main`.

# WebDynamic

## Exemples d'URL :

* En utilisant la méthode `MyMethod` de la classe `MyMethods` du programme :
```
http://localhost:8080/Test1/Test2/MyMethod?param1=Loic&param2=Martin
http://localhost:8081/Test1/Test2/Test10/MyMethod?param1=Loic&param2=Martin
```

* En utilisant l'exécutable d'un programme externe :
```
http://localhost:8080/Test1/Test2/Test3/Test4/Test5/MyExternalMethod?param1=Loic&param2=Martin
http://localhost:8081/Test1/Test2/Test10/MyExternalMethod?param1=Loic&param2="tous les autres"
```

<ins>Note 1 :</ins> Il faut changer le chemin de l'exécutable externe qui est spécifié dans la classe [`MyMethods`](WebDynamic/MyWebServerUrlParser/MyMethods.cs) à la ligne [`19`](WebDynamic/MyWebServerUrlParser/MyMethods.cs#L19), pour y spécifier le votre.
<br>
<ins>Note 2:</ins> En ne spécifiant pas assez de paramètres pour l'appel à un exécutable, un autre message apparait. Il est possible de l'afficher avec l'URL suivante (entre autres) : `http://localhost:8081/Test1/MyExternalMethod`

### Question 7
* Pour utiliser le [`WebClient`](WebDynamic/WebClient), il faut que [`MyWebServer`](WebDynamic/MyWebServerUrlParser) soit également lancé.
*  [`WebClient`](WebDynamic/WebClient) doit être lancé avec un argument : le site sur lequel il doit se connecter, par défaut : `http://localhost:8081/`. Cette URI doit être écoutée par [`MyWebServer`](WebDynamic/MyWebServerUrlParser) (`http://localhost:8081/` est écoutée par défaut).