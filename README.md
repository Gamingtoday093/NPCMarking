# NPCMarking
Unturned Plugin that gives NPC's the ability to set the player's Marker.

## How do I use NPCMarking?
Using NPCMarking is Simple! First install the Plugin by placing it inside your Rocket/Plugins folder.
To integrate your NPC into NPCMarking all you have to do is set one of the Flags specified in the Configuration (Default for Marking anywhere is 42672)
```
Reward_#_Type Flag_Short
Reward_#_ID 42672 (Specified in the Configuration)
Reward_#_Value <RewardValue>
Reward_#_Modification Assign
```

`<RewardValue>` Represents either a value to describe a location or the index of a Spawnpoint/Location depending on what FlagID you are specifying. You can easily get this Value by using the appropriate Command found further down. For example `/cpos` will give you the closest possible Flag Value for your current Position. 

## Commands
**GetClosestPosition**  
`/GetClosestPosition` **-** *`/CPos`*  
Gives and Marks your Closest possible Marker Position as it's Flag Value.  

**MarkPosition**  
`/MarkPosition <FlagValue>` **-** *`/MPos`*  
Sets your Marker at specified NPC Flag Value.  

**ClosestLocationIndex**  
`/ClosestLocationIndex` **-** *`/CLI`*  
Gives your closest Locations Index.  

**LocationIndex**  
`/LocationIndex <LocationName>` **-** *`/LI`*  
Gives the Index of a Location by Name.  

**SpawnpointIndex**  
`/SpawnpointIndex <SpawnpointName>` **-** *`/SpI`*  
Gives the Index of a Spawnpoint by Name.  
