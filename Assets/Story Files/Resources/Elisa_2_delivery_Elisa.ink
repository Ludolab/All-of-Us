VAR player_name = ""
VAR notification = ""
VAR new_contact = ""
VAR new_quest = ""


-> intro

==intro==
~ new_quest = "Elisa2.txt"
# new_quest

Elisa?Smiling "Hey, friend! How are you doing?"

* Today is a great day. How are you?
-> Chat1
* Hi, Elisa! Tell me about you! 
-> QuestIntro

==Chat1==
Elisa?Smiling "You know ... I'm discovering that the paperwork and administration that goes along with my transfer to the state school to finish my degree is almost more stress than finals." 

Elisa?Neutral "But I have a list and I'm working my way through it. One ridiculous document at a time."

* What's on the list?  
-> Chat2
* You're so methodical! Is there any way I can pitch in? 
-> Chat2

==Chat2==
Elisa?Neutral "Where do I start? I'll skip the really boring things, like the housing survey - did you know you have to answer a million questions about study habits and noise preferences to match you with a roommate?"

Elisa?Smiling "I am hoping to be approved for off-campus housing, but I'm filling out the roommate paperwork just in case." 

Elisa?Smiling "A lot of this is just grinding through, but there is one thing I don't understand, and I could use some help!"

* I'm in. Just tell me what you need! 
-> QuestIntro

==QuestIntro==
Elisa?Smiling "One of the things I need is my vaccination records. I thought we had them when mama enrolled us in school here in Bloomwood, but we can't find them anywhere."

Elisa?Neutral "I don't know how to go about finding them."

* Is that the last time you think you had them?
-> QuestDetails1
* I can do some legwork and figure out where to start, if you'd like.
-> QuestAcceptance

==QuestDetails1==
Elisa?Neutral "Yeah - I keep thinking we had them electronically, but I can't guess where they went. Trying to figure this out feels so overwhelming on top of everything else."

* This must be something other families have had to solve. I'll be back!
-> QuestAcceptance


==QuestAcceptance==
Elisa?Smiling "Oh, {player_name}. I'd be so grateful. You're right - this must be a problem with a solution."

* Of course, Elisa! You can always count on me.
-> Goodbye


==Goodbye==
Elisa?Smiling "I'm going to owe you big for this!"

* Haha! It's my pleasure to help. Bye Elisa! ->END


==== END ====
END
   -> END















