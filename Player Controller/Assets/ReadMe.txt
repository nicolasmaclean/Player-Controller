controls
WASD - movement
mouse x/y axis - rotation
C - crouch
v - dash
r - reset current scene
escape key - unlocks mouse

Shopping List Manager
Shopping List Items are the required items to win
modify this accordingly or check auto populate shopping list to populate it with the items already in the scene

to add new grocery items 
1. right click on items in the hierarchy and create a 3d object of your choice ( we can change/replace these later)
2. add an "item" component in the inspector on the right side of the screen
3. change the item name to what it should be

to create the level add to or remove from under the environment gameobject
there are a couple objects made under prototyping/prefabs to use

please make all changes to the level one scene or a new scene that you can make here: assets/scenes/levels
DO NOT CHANGE THE TESTING SCENE

to add shelves
1. go to the assets/models and animations folder
2. drag any of the options into the scene
3. to knock out a panel of a shelf, look at the children and disable whichever one(s) you want

array of gameobjects
1. make an empty
2. attach the array component from the assets/scripts/helper scripts folder
3. pick a gameobject for arraytemplate
4. to refresh changes in offset use refresh button
5. delete removes all the array gameobjects
6. apply will delete the array component and put all the array items under the array gameobject's parent