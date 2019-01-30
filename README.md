# AdventureText
Modular and expandable framework for creating Text Adventures in Unity.

There is a sample game on the Google Play Store built for Android here:
https://play.google.com/store/apps/details?id=com.ZuluOneZero.AdventureText

See our blog posts about the development of this game and more information on how to configure the project here:
http://www.zuluonezero.net/2019/01/15/text-adventure/
http://www.zuluonezero.net/2019/01/22/a-week-of-text-adventures/
http://www.zuluonezero.net/2019/01/27/text-adventure-design-and-programming/

BASIC INSRUCTIONS
1. Make an Empty Game Object called InputControl (make a tag for it with the same name) and add the InputControl and the PrintMainText scripts.
2. Make an Empty Game Object called FightClub (make a tag for it with the same name) and add the FightClub script.
3. Make an Empty Game Object called <Some Unique Descriptive Title) and add the WayPoint script (make as many of these as you need - each location or even get's a Game Object and Waypoint script.)
4. You can assign the movement buttons and Action and Map buttons in your inspector to the InputControl script. Also assign the FightCLub and starting WayPoint.
5. The show map function works by having two layers for your map. Underlayer is the actual map drawing. Over that is some masking layers that match up one for each WayPoint.
The script works by checking each WayPoint and if it's visited (bool) it does not display the mask thus revealing the map underneath.
6. Make a new canvas for the map and add sprites for the map image and any masking images ( *make a tag the same name as the related WayPoint for you mask).
7. There are default values set for most variables and you can check the blog posts above if you need more detailed info.

Support requests can be emailed to zuluonezero.z10@gmail.com.

(Note: this is a small framework for making this type of game in Unity with only basic functionality - but you can expand it easily :) - If you are looking to make a classic text adventure game I can recommend Quest)

