# Exemples d'URL :

* En utilisant une méthode de la classe `MyMethods` du programme :
```bash
http://localhost:8080/Test1/Test2/MyMethod?param1=Loic&param2=Martin
http://localhost:8081/Test1/Test2/Test10/MyMethod?param1=Loic&param2=Martin
```

* En utilisant l'exécutable d'un programme externe :
```bash
http://localhost:8080/Test1/Test2/Test3/Test4/Test5/MyExternalMethod?param1=Loic&param2=Martin
http://localhost:8081/Test1/Test2/Test10/MyExternalMethod?param1=Loic&param2="tous les autres"
```

<ins>Note:</ins> Il faut changer le chemin de l'exécutable externe qui est spécifié dans `Program.cs` à la ligne `128`, pour y spécifier le votre.