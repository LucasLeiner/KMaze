# Kmaze
## Principe
Vous contrôlez  "Pepe" avec les touches "ZQSD", vous pouvez sauter avec "espace", faire pause avec "échap", et intéragir avec "f".
Récupérez les pièces qui apparaissent sur la map afin d'augmenter votre score, mais faites attention à l'ennemie qui vous poursuit, s'il vous touche trois fois, c'en sera fini de vous. 
Afin de vous en débarrasser, tout les 5 de score la cerise apparait, prenez là afin d'inverser l'ordre des forces.
Sur la carte se trouve des téléporteurs, prenez les pour échapper à l'ennemie ou pour accélérer votre collecte de pièce.
Une fois les 20 pièces atteintes, la clé et le coffre apparaissent à la place des téléporteurs. Ramassez la clé, puis ouvrez le coffre pour terminer la partie, mais rien ne vous empêche d'aller chercher un score plus haut.
### PS
Il est possible de baisser les sons dans le menu pause.
Il est possible de sauter par dessus l'ennemie.
## Ce qui à été fait
#### Personnage :
Le model 3d du personnage "Pepe", est l'œuvre libre d'utilisation de "demidrew" via "https://sketchfab.com/3d-models/pepe-342e3f7a54d14e44b08af6c882a61181".
J'ai quand à moi modélisé le chapeau puis j'ai fusionné les deux afin d'obtenir mon personnage.

#### Animations :
Les animations de mon personnage proviennent toutes de Mixamo, mais j'ai fait l'animation de l'ouverture du coffre.

#### Sons :
Les sons sont des sons libres de droits :
- Music : https://www.youtube.com/watch?v=eGigHoRQATs
- Coin : mixkit.co
- Fin : pixabay.com

#### Scripts : 
Avec l'aide de tutos youtubes :
- https://www.youtube.com/@kozmobotgames
- https://www.youtube.com/@Brackeys

Et de la doc officiel :
- https://docs.unity3d.com/Manual/index.html

Ennemi :
En ajoutant le package navigationAi, puis en instanciant un navmesh pour notre ennemi, un simple "SetDestination(player.position)" permet à l'ennemi de se diriger vers nous automatiquement.
Je change sa couleur avec "rend.material.SetColor()" lorsque mon booléen indiquant que j'ai mangé une cerise est à "true".

Teleporters :
En ajoutant un boxcollider à mon emplacement de téléportation et en cochant isTriger, je peux détecter une collision avec OnTriggerEnter.

    private  void  OnTriggerEnter(Collider  col){
	    if (col.gameObject.tag  ==  "Player"  &&  scoreManager.score  <  20){
		    hintMenuUI.SetActive(true);
		    onTeleporter  =  true;
	    }
    }
    public  void  Teleport(InputAction.CallbackContext  context){
	    if (context.performed){
		    if (onTeleporter  &&  scoreManager.score  <  20){
			    player.transform.position  =  teleportCoord;
			    onTeleporter  =  false;
		    }
	    }
    }
Il faut ensuite appeller la fonction dans notre PlayerInput.

Coffre :
Après avoir configuré le playerInput pour appeler la fonction Finish().
Celle ci désaffiche le menu qui expliquait comment ouvrir le coffre, enregistre le highscore si nécessaire, reset le score puis démarre ma routine de fin.
Celle si passe un booléen paramètre de l'animatorController de mon coffre pour lancer l'animation d'ouverture du coffre, attend 2 secondes le temp que l'animation se fasse, stop le jeu, change de music et affiche le menu de fin afin de redémarrer une partie.

    public  void  Finish(){
	    if(onChest  &&  KeyManager.keyTaken){
		    MenuChest.SetActive(false);
		    if (scoreManager.score  >  scoreManager.highScore){
			    scoreManager.highScore  =  scoreManager.score;
			    PlayerPrefs.SetInt("HighScore", scoreManager.highScore);
		    }
		    scoreManager.score  =  0;
		    StartCoroutine("Fin");
	    }
    }
    IEnumerator  Fin(){
	    animator.SetBool("Finished", true);
	    yield  return  new  WaitForSeconds(2f);
	    Time.timeScale  =  0f;
	    MenuFin.SetActive(true);
	    StopAllAudio();
	    audioFin.Play();
    }
