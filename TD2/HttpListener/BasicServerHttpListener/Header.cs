using System.Net;

namespace BasicServerHTTPListener
{
    class Header
    {
        private string accept;
        private string acceptCharset;
        private string acceptEncoding;
        private string acceptLanguage;
        private string allow;
        private string authorization;
        private string cookie;
        private string from;
        private string userAgent;

        public Header(WebHeaderCollection webHeaderCollection)
        {
            // Les types MIME admis pour la réponse
            accept = webHeaderCollection.Get("Accept");
            // Les jeux de caractères admis pour la réponse
            acceptCharset = webHeaderCollection.Get("Accept-Charset");
            // Les encodages de contenu admis pour la réponse
            acceptEncoding = webHeaderCollection.Get("Accept-Encoding");
            // Les langages naturels préférés pour la réponse
            acceptLanguage = webHeaderCollection.Get("Accept-Language");
            // Le jeu de méthodes HTTP pris en charge
            allow = webHeaderCollection.Get("Allow");
            // Les informations d’identification que le client doit présenter pour s’authentifier auprès du serveur
            authorization = webHeaderCollection.Get("Authorization");
            // Les données de cookie présentées au serveur
            cookie = webHeaderCollection.Get("Cookie");
            // Les données de cookie présentées au serveur
            from = webHeaderCollection.Get("From");
            // Les informations relatives à l’agent client
            userAgent = webHeaderCollection.Get("User-Agent");
        }

        public override string ToString()
        {
            string headers = "";

            if (this.accept != null)
                headers += "Accept: " + this.accept + "\n";
            if (this.acceptCharset != null)
                headers += "Accept-Charset: " + this.acceptCharset + "\n";
            if (this.acceptEncoding != null)
                headers += "Accept-Encoding : " + this.acceptEncoding + "\n";
            if (this.acceptLanguage != null)
                headers += "Accept-Language: " + this.acceptLanguage + "\n";
            if (this.allow != null)
                headers += "Allow: " + this.allow + "\n";
            if (this.authorization != null)
                headers += "Authorization: " + this.authorization + "\n";
            if (this.cookie != null)
                headers += "Cookie: " + this.cookie + "\n";
            if (this.from != null)
                headers += "From: " + this.from + "\n";
            if (this.userAgent != null)
                headers += "User-Agent: " + this.userAgent + "\n";

            return headers;
        }
    }
}
