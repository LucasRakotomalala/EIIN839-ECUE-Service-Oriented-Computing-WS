# HTTPListener


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

<ins>Note 1 :</ins> Il faut changer le chemin de l'exécutable externe qui est spécifié dans `MyMethods.cs` à la ligne `18`, pour y spécifier le votre.
<br>
<ins>Note 2:</ins> En ne spécifiant pas assez de paramètres pour l'appel à un exécutable, un autre message apparait. Il est possible de l'afficher avec l'URL suivante (entre autres) : `http://localhost:8081/Test1/MyExternalMethod`

### Question 7
* Pour utiliser le `WebClient`, il faut que `MyWebServerUrlParser` soit également lancé.
*  `WebClient` doit être lancé avec un argument : le site sur lequel il doit se connecter, par défaut : `http://localhost:8081/`. Cette URI doit être écoutée par `MyWebServerUrlParser` (`http://localhost:8081/` est écoutée par défaut).