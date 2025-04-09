<link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet">

<img src="Ressources/Audit_Of_Legends.png" alt="Chargement de l'image" style="display: block; margin: 0 auto;">

</br>
</br>

# ☛ Notre équipe

L’équipe 🔥**Vos Gros Darons**🔥, composée de :

🔸 **Antoine CHAUMET** 

🔸 **Alexandre COUTON** 

🔸 **Amine BELHAJ** 

🔸 **Auguste DELAYE**

Vous présente leur projet **T4**.

---

**Vos liens pour vos évaluations :** 

 - Prenom nom : Lien 1
 - Prenom nom : Lien 2
 - Prenom nom : Lien 3



# ☛ Présentation du projet

Ce projet a pour but de réaliser un **jeu serieux** sur le métier **d'audit dans une université** afin d'aider des débutants dans ce domaine pour leurs donner **un avant goût de la réalisation de leur premier audit**.
 
⚠️ **Attention** ⚠️ Il peut être intéressant pour vous de **bien comprendre le thême**. C'est pourquoi nous vous invitons à vous renseigner en lisant [**notre wiki**](wiki.md).

</br>

# ☛ Audit of Legends

Un **jeu serieux sur le metier d'audit en université** qui se focalise sur **la difficulté et les méthodes de récuperation des informations auprès des audités**.

> Inclure des screenshots du jeu / une vidéo de gameplay un peu en mode gif

</br>

# ☛ Procédures d'installation et d'exécution

Tutoriel d'installation du projet :
 - Ouvrez votre terminal bash et tapez la commande suivante :

```bash
git clone git@git.unistra.fr:MET25-T4-C/t4.git
```

> Si vous n'avez pas encore votre clé ssh, il se peut que vous ayez à renseigner votre identifiant et mot de passe unistra.

 ## ✤ Pour Windows


 ## ✤ Pour Linux


</br>

# ☛ Objectifs pédagogiques

Nous vous proposons 3 objectifs pédagogiques différents, à vous de choisir lequel / lesquels vous intéresse(ent) le plus.

 🔸 Compréhension du processus de réalisation de l'audit.

 🔸 Compréhension de la difficulté de la collecte d'informations.

 🔸  
 
</br>

## ✤ Objectifs pédagogiques avancés 

</br>

### Compréhension du processus de réalisation de l'audit

Il est important pour le joueur de comprendre quelles sont **les différentes étapes d'un audit**. Pour rappel, ces différentes informations sont dans [le wiki](wiki.md). Il est donc aussi important de bien faire comprendre au joueur **combien de temps est passé par section du processus** de réalisation d'un audit. Cet objectif ne se focus donc **pas sur une partie** du processus mais bien **sur son ensemble**.

</br>

### Compréhension de la difficulté de la collecte d'informations

Contrairement à l'objectif présenté juste avant, celui-ci se concentre principalement sur **la collecte d'informations** qui se fait majoritairement par **l'échange avec des employés** et plus rarement aussi par la réalisation de test. Il faut donc bien que le joueur comprenne **la difficulté du dialogue** avec certains employés qui peuvent être **méfiant ou cherche à cacher des informations sensibles** à l'auditeur. Le joueur doit aussi comprendre que toutes informations qu'il entend ne sont **pas forcément vraies,** ou encore que certaines informations ne soient **pas forcément très utiles**.
Afin de réaliser cet objectif, il n'est donc pas nécessaire d'inclure toutes les parties du processus de réalisation d'un audit, en revanche, leurs présence peut aider à contextualiser cette phase de dialogue avec les employés.

</br>

## ✤ Références

????????

</br>

# ☛ Description des fonctionnalités

🔴 IMPORTANT❗🔴 : Toutes les fonctionnalités qui sont décrites dans les parties suivantes n'ont pas forcément été implémentées dans le prototype. Le prototype à été conçue pour vous donner une idée d'une potentielle base de développement, à vous de l'améliorer ou de construire une nouvelle base au cours du T3. 

</br>

## ✤ Actions du joueur

  Nous souhaiterions que le joueur puisse au moins : 

   🔸 Avoir le choix entre différents sujets d'audits

   🔸 Intéragir avec les personnes audités

   🔸 Intéragir avec plusieurs personnes, qui possèdent des comportements différents à l'égart de l'auditeur

   🔸 Choisir avec qui il intéragit lorsqu'il le souhaite

   🔸 Produire un rapport uniquement à partir des informations qu'il aura découvert


</br>

## ✤ Logique de jeu

  Dans la logique du jeu, il faudrait que :

   🔸 Les différentes intéractions produisent des comportements différents

   🔸 Les informations reçues ne soient pas toutes vraies

   🔸 Une méchanique de vérification d'information soit présente

   🔸 Le joueur ait un moyen d'être limité en terme d'actions / de temps pour représenter le temps qui passe pour bien faire comprendre au joueur qu'il n'a pas toute la vie pour faire un seul audit 

   🔸 Un système de confiance entre l'auditeur et les audités soit mis en place et que cette confiance influe les réponses ces derniers 

</br>

## ✤ Interface

  L'interface doit au moins pouvoir présenter :
    
   🔸 Un système d'intéraction avec les audités

   🔸 Un affichage final qui indique si le joueur à fait du bon travail ou non

   🔸 Un moyen de connaitre la confiance que lui accorde les audités (qu'il soit facilement visible ou non)



</br>

# ☛ Contraintes de développement


Au niveau de la contrainte de développement, le client vous laisse libre par rapport à la technologie utilisée, et sur quels point vous voulez appuyer votre jeu. 

En revanche, il est intéressant de garder en tête que le client souhaite ce jeu dans le but de donner une première approche à des débutants dans le domaine.
Il faut donc penser à ne pas faire un jeu trop simplifié. C'est la raison pour laquelle nous avons détaillé au mieux le métier de auditeur dans [le wiki](wiki.md).

Une seule contrainte qui peut être intéressante à en déduire, est qu'il peut être plus favorable de créer des scénarios générés aléatoirement, afin de permettre aux joueurs de pouvoir réaliser plusieurs audits sur un même thême dans le but de les aider a mieux comprendre, plutôt que de les faire retenir quels choix sont les meilleurs dans un scénario donné. 


</br>

# ☛ Fonctionnalités supplémentaires optionnelles

Nous avons également pensé à d'autres ajouts qui pourraient vous intéresser : 

  🔸 Ajouter un système d'actions de tests sur certains scénarios (par exemple engager une équipe de cyber sécurité pour qu'il fasse un test de faille dans le cas d'un audit )

  🔸 Si le système de tests est mis en place, ajouter un système de budget maximum pour limiter le nombre d'actions de tests que le joueur peut faire

  🔸 Ajouter un système de création de rapport plus poussé, où le joueur doit lui même indiquer quelles informations il veut mettre dans quels blocs du rapports (par exmple choix d'une groupe d'informations parmis plusieurs)

  🔸 