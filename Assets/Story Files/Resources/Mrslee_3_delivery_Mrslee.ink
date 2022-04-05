VAR player_name = ""
VAR notification = ""
VAR new_contact = ""
VAR new_quest = ""

-> intro

==intro==
~ new_quest = "Mrslee3.txt"
# new_quest

Mrslee?Neutral " "

* Hi, Mrs. Lee! How are you today?
  -> Chat1
* How are you, Mrs. Lee?
  -> QuestIntro

==Chat1==
Mrslee?Smiling "Hey. {player_name}. Today I feel happy. Today, I volunteer with the kids."

* I'm so glad; this seems like it's good for you, the kids, and Lila!
  -> Chat2
* Have you thought about making that doctor appointment?
  -> QuestIntro

==Chat2==
Mrslee?Smiling "Yah. It hard to feel stress when kids ask you to color or sing little songs."

* Well, less stress is good. Especially if less stress means less headaches.
  -> QuestIntro
* No headaches?
  -> QuestIntro

==QuestIntro==
Mrslee?Smiling "Oh. That. I made appointment at doctor office. Eddie said he was relief."

* That's awesome, Mrs. Lee! But how are you feeling about it?
  -> QuestDetails1
* I'm here if you need help preparing. Mentally, emotionally, logistically..
  -> QuestAcceptance

==QuestDetails1==
Mrslee?Neutral "Me? I am concern. Nervous!"
Mrslee?Neutral "Doctor always speak so fast. Not so much want to listen."

* I understand! That sounds super stressful, Mrs. Lee.
  -> QuestDetails2
* Maybe I can support you in some way.
  -> QuestAcceptance

==QuestDetails2==
Mrslee?Neutral "I forget everything! My feeling.. my words. "
Mrslee?Neutral "Why I'm gonna go if nobody listen to me?"

* We can work on ways to make sure the doctor listens to you.
  -> QuestAcceptance
* Let's think about this together
  -> QuestAcceptance

==QuestAcceptance==
Mrslee?Neutral "Thank you. What you think I should do? I feel nervous to go to doctor's appointment. How to prepare?"

* I'm gonna think about it!
  -> Goodbye
* I'll be back soon, sit tight!
  -> Goodbye

==Goodbye==
Mrslee?Neutral "Yes, thank you, {player_name}.

* See you soon!
  ->END
* Sure thing, Mrs. Lee.
  ->END


