# kiss kiss bang bang

😘 😘 💥 💥

Maxcamp 2K22

<strong>0.0.1-SNAPSHOT</strong>

----

<img src="https://pbs.twimg.com/profile_images/1442801403211272192/bC1x4-LA_400x400.jpg" style="width: 220px; border-radius: 50%"/>

[@Zeill45](https://twitter.com/Zeill45)

Humble développeur & co-directeur technique chez [@maxdsfrance](https://twitter.com/maxdsfrance)

---

<img src="/assets/images/artiste_incompris.png" style="width: 60%" />

🎨 artiste incompris 🎨

---

🍄 votre humble serviteur 🍄

----

Les origines

---

<img src="https://assets.mkdev.me/posts/covers/000/000/112/original/how-to-choose-a-programming-language.png?1491912211" style="width: 450px"/>

C'est quoi le langage:
* le plus adapté
* le plus rapide
* le plus cool
* ...

---

<img src="https://preview.redd.it/19fq7c002w021.png?auto=webp&s=3e0a27751f560581f575619ba337a0d6a124096a" style="height: 320px" />

quel framework ?!?

---

<img src="https://lachroniquefacile.fr/wp-content/uploads/2016/11/CtJvPgNXEAA6uJB-1.jpg"  style="height: 320px" />

----

PeachMe

Peach Kiss as a service

---

<img src="/assets/images/peach-kissing-mario.webp" style="width: 320px" />

NFT original

---

<img src="/assets/images/out2.png" style="width: 320px" />

Notre promesse 

---

<img src="/assets/images/archi.png" style="width: 450px" />

L'archi

---

Site web statique

[lien](http://peachme.io:8080)

---

API dotnet core

--- 

site de statut des services

[lien](http://status.peachme.io:3001/)

----

<video controls>
<source src="/assets/videos/bowser-video.mp4"
    type="video/mp4">
</video>

----

<img src="/assets/images/no-lib.jpeg" />

Rien d'autre que la librairie standard 😱

---

<img src="https://upload.wikimedia.org/wikipedia/commons/thumb/d/df/We_Can_Do_It%21_NARA_535413_-_Restoration_2.jpg/640px-We_Can_Do_It%21_NARA_535413_-_Restoration_2.jpg" style="height: 420px" />

---

MEP (Mise En Pratique)

La CLI en:
* bash
* dotnet
* java
* node
* python 

---

<img src="https://i.imgur.com/4SdB78W.gif" />

le code

---

<img src="https://pbs.twimg.com/media/CqsGZn1UEAE5y7X.jpg" />

---

<img src="https://thumbs.gfycat.com/ImmenseLiquidCuscus-max-1mb.gif" />

Du front sans librairies 🙀

---

* node
* simple css
* SSE (Server Sent Events)

---

<img src="https://i.imgur.com/4SdB78W.gif" />

le code

----

<iframe width="560" height="315" src="https://www.youtube.com/embed/RSY85SLXzwk" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>

⚡️ who's blazing fast ?

---

<img src="/assets/images/cli_chart.png" />

---

🔨 temps de build

Note: pas vraiment un pb dans le cas d'une cli, est-ce qu'on build souvent, temps dans la CI, les pipelines, compiler du Rust ça peut être méga long par exemple

---

⚡️ temps d'exécution

Note: pour une CLI c'est très important qu'on ai pas l'impression que ça freeze, c'est quoi la volumétrie d'appel, ....

---

<img src="https://i.imgur.com/4SdB78W.gif" style="height:420px" />

temps de dev

----

🤔 des avantages au no lib ?

---

🍸 pas de maj de dépendances

---

⚠️ dépendances transitives

[How one developer just broke Node, Babel and thousands of projects in 11 lines of JavaScript](https://www.theregister.com/2016/03/23/npm_left_pad_chaos/)

---

```js
module.exports = leftpad;
function leftpad (str, len, ch) {
  str = String(str);
  var i = -1;
  if (!ch && ch !== 0) ch = ' ';
  len = len - str.length;
  while (++i < len) {
    str = ch + str;
  }
  return str;
}
```

--- 

👑 "souveraineté numérique"

ai-je le temps pour:
- attendre un fix ?
- contribuer
  - qui ?
  - budget ? 

---

<iframe width="560" height="315" src="https://www.youtube.com/embed/vW9gxQByUME" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>

Devoxx 2021 - Comment nous faisons évoluer Clever Cloud - REX sur la vie d'un projet de 10 ans (Quentin Adam)

---

💸 garder la maitrise sur la valeur de l'entreprise

---

▶️ suivi des releases de son langage/runtime

Note: on peut plus se focus sur ces montées de version

---

⚡️ temps de démarrage amélioré (FAAS, ....)

----

<img src="https://thumbs.gfycat.com/ImportantShallowChinchilla-max-1mb.gif" />

Les épines rencontrées

---

🤯 manipuler du JSON en Java vanilla

Pour faire du JSON vanilla en Java ... utiliser le runtime javascript :D 

https://stackoverflow.com/a/26105474

😿 Jackson 

---

fetch encore en expérimental dans Node18

---

j'aurais voulu creuser + la partie API HTTP dans les différents langages + perf

---

le code des CLIs n'est pas forcemment portable sur tous les OS

---

fun fact System.CommandLine n'est pas dispo sans nugget sous linux/mac :(

---

Le front en vanilla JS ça pique xD

😿 React

heureusement il y a [react-light](https://blog.maxds.fr/react-light/)


---

<img src="https://acegif.com/wp-content/uploads/2021/06/acegif-com-sweating-44.gif" />

le temps pour produire tout le code de ce talk 

----

💡 Pour aller plus loin

---

C'est en se privant qu'on se rend compte de la chance qu'on a

--- 

Documentation offline: https://devdocs.io/

En cas de:
* bombe atomique
* attaque zombie
* dans le train

---

le lien du repo github sera ajouté dans la **0.0.1**

---

<img src="https://www.autobelle.it/altre-immagini/immagini_annunci/71/713055/sorgente_713055.d1579364304.jpg" style="height:420px" />

🕵️‍♀️ restez curieux, regardez sous le capot

----

<img src="/assets/images/out2.png" style="width: 320px" />

Merci 

----

Note: Site web vitrine avec le service

https://github.com/bibixx/reveal.js-gamepad-plugin

https://codepen.io/suez/pen/wMMgXp

Pour faire du JSON vanilla en Java ... utiliser le runtime javascript :D 

https://stackoverflow.com/a/26105474

truc clé en main pour le monitoring: https://github.com/louislam/uptime-kuma

Marvin dépendance transitive qui pète au runtime :( (si pas de lock si les dépendances)

Le mec vire sa lib de npm ou whatever (npm)

fun fact System.CommandLine n'est pas dispo sans nugget sous linux/mac :(