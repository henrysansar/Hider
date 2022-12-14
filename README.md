# Hider
HiderV2 - Hide/Show objects in an experience via chat commands

# Link at Sansar Marketplace - Download for free and ready
https://store.sansar.com/listings/f4269a21-4309-4287-b222-12def01c62a3/hiderv2---hideshow-objects-in-an-experience-via-chat-commands

# About
This is indeed my most used script. This can hide and show (and swap if you do some trick) objects in a scenario via chat commands.

Properties:

Show: Command to trigger the object to be in visible mode. Example: /mario_npc_show
Hide: Command to trigger the object to be in invisible mode. Example: /mario_npc_hide
Channel: Keep it zero to allow the script to listen your chat commands. You can set a different channel so others scripts can make calls to the channel specified.
Start Mode: Use h or s (sensitive case). This will define the initial state of the object. h for hidden and s for showing. Ex: If you want the object to not be displayed as default, use h.
Hide Offset: If your object contains Volumes (Rigid Bodies), set all the Containers to Key Framed and put a value like -500 on this property. This will make the object position descend to -500 meters of the original position to avoid people colliding with invisible objects.
Debug: This will supply some infos on the debug window.

Hint: switching objects...

Let's say that you have Mario and Luigi NPCs on your experience and you, for some reason , you want to make Mario disappear and Luigi appear in a single command...

Mario Properties:
Show: /mario_npc_show
Hide: /mario_npc_hide
Start Mode: s

Luigi Properties:
Show: /mario_npc_hide
Hide: /mario_npc_show
Start Mode: h

Wanna see some examples in action ?

https://atlas.sansar.com/experiences/henrygrumiaux/cemetery : The zombies had this script inside whose start mode is h. When you steps the trigger, this is sending something like /zombies_show to channel 200 and then they appears and starts to dance.

https://atlas.sansar.com/experiences/henrygrumiaux/draft-blood-bath : This is using a switch/swap example. Humans had /humans-show and humans/hide. Vanpires had /humans_hide and /humans_show a timer script send such commands to channel 300

https://atlas.sansar.com/experiences/henrygrumiaux/circus-club : try /cl_show ! You will see the clowns dancing nearby the dj booth. to hide it: /cl_hide

Facing difficulty ? Common issues:

- My object contain lights. The object disappear, but the lights still remains: Set the scriptable property of the light to on
- Object disappear, but I can feel the object there when I collide with it : Set all the volumes to KeyFramed and don't forget to set the Offset Position.
- After set the volumes to KeyFramed, ppl now can handle the objects : Change all the properties Can Grab of all the containers to off
- Object is still visible: Check the default state of the script and if necessary: Set all the root containers Movable from Script property to on.

Doubts ? Don't be shy ! I've a reputation to always be available to help people always as it possible. Just ping me !