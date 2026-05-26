# Tetris M5 - Tetris en Windows Forms

Projet de développement d'un jeu de Tetris en C# avec le framework Windows Forms (WinForms) dans le cadre du module M5.

---

## 🚀 Fonctionnalités Principales

* **Moteur de Score et de Progression Réaliste (`ScoreManager`)** :
    * Barème exponentiel officiel : 1 ligne = 100 pts, 2 lignes = 300 pts, 3 lignes = 500 pts, 4 lignes (Tetris) = 800 pts.
    * Courbe de difficulté progressive (10 niveaux max) augmentant le niveau et la vitesse automatique toutes les 5 lignes complétées au total.
    * Multiplicateur de score lié au niveau en cours : `CurrentScore += basePoints * Level`.
* **Aperçu Intelligent de la Pièce Suivante (`nextPieceCanvas`)** :
    * Zone d'aperçu dédiée de 100x100 pixels.
    * Calcul dynamique automatique des dimensions (Bounding Box) et des offsets de centrage permettant d'afficher toutes les pièces (incluant la barre longue 'I' et le bloc compact 'O') parfaitement au milieu, à une échelle miniature adaptée (20px par cellule au lieu de 30px).
* **Gestion Avancée des Thèmes (Sombre / Clair)** :
    * Bascule dynamique complète des couleurs de l'application à la volée.
    * Adaptation intelligente et automatique des icônes de contrôle (`white` pour le thème sombre, `black` pour le thème clair).
* **Contrôles Fluides et Sécurisés** :
    * Prise en charge du *Hard Drop* (chute et verrouillage instantanés) via la touche **Espace** ou un **Clic gauche** direct sur la zone de jeu.
    * Filtrage strict des entrées : aucune action au clavier n'affecte le jeu s'il est en pause, non démarré ou terminé.
* **Écran de Fin Immersif (Game Over Overlay)** :
    * Plus de popups ou de `MessageBox` intrusives. L'écran de Game Over est dessiné directement via GDI+ sur le canvas principal sous forme de voile sombre semi-transparent, affichant le statut et le score final tout en laissant transparaître la partie figée.

---

## 🕹️ Commandes du Jeu

| Touche / Action | Action dans le Jeu |
| :--- | :--- |
| **Flèche Gauche** | Déplacer la pièce vers la gauche |
| **Flèche Droite** | Déplacer la pièce vers la droite |
| **Flèche Haut** | Pivoter la pièce (Rotation) |
| **Flèche Bas** | Soft Drop (Descendre d'une case plus rapidement) |
| **Barre Espace** | **Hard Drop** (Chute et verrouillage instantanés au fond) |
| **Clic Gauche (sur le jeu)** | **Hard Drop** (Chute et verrouillage instantanés au fond) |

---

## 📊 Tableau de Progression des Niveaux

| Niveau | Lignes Totales Cumulées | Multiplicateur de Score | Vitesse du jeu (Intervalle) |
| :---: | :---: | :---: | :---: |
| **Niveau 1** | De 0 à 4 lignes | x 1 | 600 ms |
| **Niveau 2** | De 5 à 9 lignes | x 2 | 550 ms |
| **Niveau 3** | De 10 à 14 lignes | x 3 | 500 ms |
| **Niveau 4** | De 15 à 19 lignes | x 4 | 450 ms |
| **Niveau 5** | De 20 à 24 lignes | x 5 | 400 ms |
| **Niveau 6** | De 25 à 29 lignes | x 6 | 350 ms |
| **Niveau 7** | De 30 à 34 lignes | x 7 | 300 ms |
| **Niveau 8** | De 35 à 39 lignes | x 8 | 250 ms |
| **Niveau 9** | De 40 à 44 lignes | x 9 | 200 ms |
| **Niveau 10**| 45 lignes et plus | x 10 | 100 ms (Vitesse maximale) |

---

## 🔧 Structure du Projet

* `TetrisDomain` : Contient le cœur logique du jeu (`Game`, `Board`, `Piece`). Totalement indépendant de l'affichage graphique.
* `Tetris_M5.ScoreManager` : Classe autonome gérant les algorithmes de score et de montée de niveau.
* `Tetris_M5.Presentation` : Fenêtre principale WinForms (IHM). Gère les entrées clavier/souris, les rafraîchissements optimisés (`Invalidate`), les bascules de thèmes et les dessins GDI+.
