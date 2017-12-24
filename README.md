# Fructuseur

## Présentation
Fructuseur est un CMS permettant le développement de sites web de manière simplifiée. Avec l'apprentissage des commandes de référence, votre projet sera créé en quelques lignes.

## Comment l'installer
Pour installer Fructuseur, il suffit de télécharger la dernière mise à jour disponible ici nommé Fructuseur.exe. Il faut ensuite glisser Fructuseur dans le dossier web vide de votre nouveau projet, puis de lancer l'application. Nous appellerons cette application terminal.
> N'hésitez pas également à glisser vos polices d'écriture dans le dossier source contenant le terminal. Nous appellerons le dossier source contenant le terminal le dossier racine.


## Comment développer son projet sous Fructuseur
Une fois les commandes essentielles effectuées, vous pouvez ainsi créer tous les fichiers javascript et css dans les dossiers racines js et css. Ils seront automatiquement ajoutés à toutes les pages de votre projet. Ensuite, il ne vous reste plus qu'à développer le visuel de chaque page dans le dossier racine web.


## Liste des commandes

### Les commandes essentielles
Les commandes essentielles sont les commandes de base du terminal qui devront être utilisées pour créer l'architecture de votre projet à ses débuts. Les commandes essentielles ci-dessous sont listées dans l'ordre logique d'execution. Les mots contenus dans les crochets {} de la liste des commandes seront modifiés selon vos besoins. Les mots clés de la commande qui ne pourront pas être modifiés selon vos besoins seront illustrés avec les différentes possibilités séparées par ||.


#### v0.1.0

  1. **```update```**: Cette commande permet des créer et de télécharger les fichiers de base essentiels au bon fonctionnement du cms.

  2. **```create {Mon projet}```**: Cette commande permet d'initialiser votre projet avec le nom approprié.

  3. **```page {accueil}```**: Cette commande permet de créer une nouvelle page et de l'ajouter au projet. Cette page pourra être modifiée depuis le dossier racine web.

  4. **```default_f {accueil}```**: Permet de faire d'une page créée par la commande page la page par défaut qui sera affichée lors de l'arrivée sur le site.

### Les commandes d'ajout
Les commandes d'ajout sont secondaires. Elles ne sont pas indispensable au bon fonctionnement du cms. Elles permettent de simplifier simplement la partie intégration du développeur. Les préréquis des commandes sont cités dans [].

#### v0.1.0

  1. **```font {police.ttf} {MaSuperPolice}```**: [Un fichier {police.ttf} dans le dossier racine] Cette commande permet d'ajouter automatiquement la font dans le projet par un @font-face avec le font-family: {MaSuperPolice};.

  > 1: Des problèmes de permissions peuvent faire crasher le terminal et empecher le bon fonctionnement de la commande.


  2. **```responsive min||max {768}```**: Cette commande permet de créer un fichier css au dossier racine css qui contiendra un media querie généré automatiquement. Pour la commande responsive max 1280 le media querie sera @media screen and (max-width:1280).


  3. **```cdn js||css {http://iazlur.fr/lib/flixy.js}```**: Cette commande permet de d'ajouter automatiquement un script js ou css avec le lien cité en 2 ème argument au projet.
  
#### v0.1.1

 1. **```cdnvar {flixy} {http://iazlur.fr/lib/flixy.js}```**: Cette commande permet de sauvegarder le lien d'un cdn sur le support physique pour simplifier la commande cdn. Elle pourra désormais être utilisée ainsi: cdn js flixy.
 
 2. **```css {style}```**: Permet de créer un fichier css rapidement dans le dossier racine css.
 
 3. **```js {main}```**: Permet de créer un fichier js rapidement dans le dossier racine js.
 
#### v0.1.2

 1. **```build```**: Permet d'ouvrir le pagebuilder.
 
### Les commandes du pagebuilder
Le page builder permet de faciliter la tâche de l'intégrateur. Grâce à ces commandes, Fructubuild vous permettra d'optimiser votre temps de développement. Les préréquis des commandes sont cités dans [].

#### v0.1.2

 1. **```css {monfichier}```**: [un fichier monfichier.css dans le dossier racine css] Permet d'ouvrir le cssbuilder sur le fichier css indiqué.
 
 2. **```{body .navbar a}```**: [cssbuilder d'ouvert] Permet de générer proprement body .navbar a { } dans le fichier css ouvert du cssbuilder.


