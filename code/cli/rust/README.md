# RUST

## Lancement 
cargo run --release -- francois.png

## Choix pour base64
Pour l'implémentation en Rust, il a été décidé d'utiliser au moins une librairie : base64.

Dans la mesure où l'implementation manuel de cette fonctionnalité semble hors sujet  pour le challenge, il a été juger acceptable de prendre cet librairie.

## Murs pris en pleine face :

Il n'y a pas de lib HTTP dans la std de Rust, la base est la partie TCP, qui bénéficie d'une très bonne implémentation et qui est bien documenté, mais une manque de connaissance des détails du RFC sur HTTP a amené les soucis suivants : 

- En HTTP/1.1, si le header "Host" est absent, un serveur peut renvoyer "400 bad request" sans détails. C'est le cas du serveur C# du projet. ( mais pas de express.js ni de actix ( server en Rust)), ce qui a compliqué la debugging pour trouver la source de l'erreur.

- Le header "Content-length" pour un POST doit être renseigné, sinon le body n'est pas lu. On a l'habitude que ce champs soit remplie automatiquement par nos lib ( un tcpdump a été utilisé pour checker ce qu'envoyait un curl classique)

- Lors de la lecture de la réponse, il n'y avait pas de "Content-Length", le retour était fait en chunk, compliquant un peu la lecture
  - C'est à dire, une ligne avec le nombre d'octet, suivi d'une partie du contenu, et ça n fois jusqu'à arriver à la fin du contenu.

    
Cela dit, pas de difficulté lié à Rust directemment, même si la gestion d'erreur mis en place est plus que minimal pour  gagenr du temps, on reste sur du code lisible.
