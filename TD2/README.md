# Exemples d'URL :

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
<br>
<ins>Note 3 :</ins> Ne pas spécifier assez d'arguments pour le 1er cas ne n'affiche rien de particulier : les `string` prendront les valeurs par défaut.