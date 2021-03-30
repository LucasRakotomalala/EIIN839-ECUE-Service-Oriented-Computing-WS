# Introduction to the ABC (Address, Binding, Contract) model in WCF (Windows Communication Foundation)

## SOAP Web Services

* [`App.config`](MathsLibrary/App.config) : on met en place plusieurs ports pour plusieurs clients potentiels ([`Client/Program.cs`](Client/Program.cs))

## REST Web Service

### Exemples d'URL

* Addition : `http://localhost:8733/Design_Time_Addresses/MathsLibrary/MathsOperations/RESTEndPoint/Add?x=1&y=2`
* Multiplication : `http://localhost:8733/Design_Time_Addresses/MathsLibrary/MathsOperations/RESTEndPoint/Multiply?x=10&y=2`
* Soustraction : `http://localhost:8733/Design_Time_Addresses/MathsLibrary/MathsOperations/RESTEndPoint/Substract?x=5&y=3`
* Division : `http://localhost:8733/Design_Time_Addresses/MathsLibrary/MathsOperations/RESTEndPoint/Divide?x=3&y=4`

Un exemple de requête au Web Service `REST` depuis un programme `C#` est disponible à la [ligne `39` du programme de `Client`](https://github.com/LucasRakotomalala/EIIN839-ECUE-Service-Oriented-Computing-WS/blob/develop/TD5/MathsLibrary/Client/Program.cs#L39). Les lignes qui suivent permettent de traiter à minima la réponse.
