
![image](https://user-images.githubusercontent.com/69054726/169936352-c0496657-d3a1-4fb6-b022-c5ea7bd740c4.png)

# Forestscape 

Projet fait par : Yaroslava Kost, Myriam Ouellette, Martina Piedimonte et Alina Alenikova

## Motivation
Notre jeu permet à toute personne intéressée d’apprendre sur plusieurs animaux divers. C’est un jeu éducatif et amusant, qui motive le monde à se familiariser avec le monde qui nous entoure.

## Style de code
C# avec Unity

## État de construction 
première version du jeu

##Technologies utilisées
Unity, Visual Studio

##Captures d’écran du jeu/démo 

![image](https://user-images.githubusercontent.com/69054726/169936431-71d1bd48-751e-4b73-ac21-4a7641527bad.png)

![image](https://user-images.githubusercontent.com/69054726/169936451-e84fe37b-54f6-4356-bab2-64d9af954755.png)
![image](https://user-images.githubusercontent.com/69054726/169936486-937159fd-1a1b-45f6-8ecb-bb8cd85631fa.png)

  


## Fonctionnalités 
-	Jeu first person view
-	Un grand terrain à explorer
-	Plusieurs animaux à trouver
-	Une caméra fonctionnelle 
-	Un carnet d’information à remplir 
-	Des ponts et des escaliers à réparer pour découvrir d’autres lieux
-	Un système de points 

## Exemple de code :



    //prend une capture d'ecran du point de vue de la main camera (ce que le joueur voit)
            IEnumerator CapturePhoto()
            {
                //Camera UI set false
                viewingPhoto = true;

                yield return new WaitForEndOfFrame();

                Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);

                screenCapture.ReadPixels(regionToRead, 0, 0, false);
                screenCapture.Apply();

                sortPhoto(ShowPhoto());

            }

            //montre la photo et y met un frame autour
            Sprite ShowPhoto()
            {
                Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
                photoDisplayArea.sprite = photoSprite;

                photoFrame.SetActive(true);
                return Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
            }

            //enleve la photo
            void RemovePhoto()
            {
                crosshair.SetActive(true);
                viewingPhoto = false;
                photoFrame.SetActive(false);
                cameraFrame.SetActive(false);
                photoMode = false;

            }


















## Comment utiliser le projet?

Simplement télécharger l’exécutable et le cliquer deux fois pour jouer au jeu. Utiliser la souris pour naviguer les menus. Les boutons W, A, S, D pour se déplacer ainsi que le bouton espace pour sauter. Pour interagir avec l’environnement utiliser le bouton de clavier E. Pour ouvrir la caméra cliquer sur C et pour le carnet cliquer X. Une fois que la caméra est ouverte, vous pouvez faire un clic droit pour prendre la photo et ensuite faire un clic gauche pour mettre la photo dans le carnet. Pour pouvoir plus s’approcher d’un animal, tenez le bouton Shift pour s’accroupir. Le but du jeu est de trouver et de photographier le plus d’animaux possibles pour compléter le carnet.

