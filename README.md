# AdventureText
Modular and expandable framework for creating Text Adventures in Unity.

There is a sample game on the Google Play Store built for Android here:
https://play.google.com/store/apps/details?id=com.ZuluOneZero.AdventureText

See our blog posts about the development of this game and more information on how to configure the project here:
http://www.zuluonezero.net/2019/01/15/text-adventure/
http://www.zuluonezero.net/2019/01/22/a-week-of-text-adventures/
http://www.zuluonezero.net/2019/01/27/text-adventure-design-and-programming/
More updates to come...

BASIC INSRUCTIONS for a 2D Unity project....
1. Make an Empty Game Object called InputControl (make a tag for it with the same name) and add the InputControl and the PrintMainText scripts.
2. Make an Empty Game Object called FightClub (make a tag for it with the same name) and add the FightClub script.
3. Make an Empty Game Object called <Some Unique Descriptive Title) and add the WayPoint script (make as many of these as you need - each location or even get's a Game Object and WayPoint script.)
4. Make an Empty Game Object called Monster(make a tag for it with the same name) and add the MonsterStuff script - leave the public variables they get assigned at run time (passed from the WayPoint object).
5. You can assign the movement buttons and Action and Map buttons in your inspector to the InputControl script. Also assign the FightCLub and starting WayPoint.
6. The show map function works by having two layers for your map. The underlayer is the actual map drawing. Over that is as many masking layers as you have WayPoints that would reveal a location.  The script works by checking each WayPoint and if it's visited (bool) it does not display the mask thus revealing the map underneath.
7. Make a new canvas and canvas group (Alpha to 0 to start off) for the map and add sprites for the map image and any masking images ( *make a tag the same name as the related WayPoint for you mask).
8. There are default values set for most variables and you can check the blog posts above if you need more detailed info.
9. Make a separate canvas for the UI buttons and Text areas - you need Text areas for the Player HP, the outcome of Combat actions (from the FightClub) and the Monster HP.  Finally a big text area for the PrintMainText function (assign it to the public variable in the inspector).

That's pretty much it - make a WayPoint for every text entry you want to display and use the left/right/forward/backwards fields on the WayPoint script to allow navigation to the next WayPoint in that direction.  If you are using the Map feature you need a basic map and a mask for each WayPoint to reveal what's underneath (this is by far the most time consuming bit but also kind of fun).

When a location has a Monster you can define an array size of combat attack descriptions and defense descriptions and also a final killing blow description for either Monster or Player. Get gnarly with it.

Support requests can be emailed to zuluonezero.z10@gmail.com.

(Note: this is a small framework for making this type of game in Unity with only basic functionality - but you can expand it easily :) - If you are looking to make a classic text adventure game with a full featured complex suite of options then I would recommend Quest)

Zulu.
