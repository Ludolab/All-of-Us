VAR player_name = ""
VAR notification = ""
VAR new_contact = ""
VAR new_quest = ""

-> intro

===intro===
~ new_quest = "Mrslee1.txt"
# new_quest
~ new_contact = "Mrslee"
# new_contact

Mrslee?Neutral "Good morning, {player_name}!"

+ Mrs. Lee! How was fitness class?  
  -> Chat1
+ Hey Mrs. Lee! How are you?
  -> Chat2

==Chat1==
Mrslee?Smiling "Good to see you. I love my fitness class."

+ I wish mornings weren't so early; maybe I'll join you sometime! How's your week going?
  -> Chat2

== Chat2 ==
Mrslee?Neutral "Good, but now I am feeling stress. Very, very stress."

+ Is there anything that I can help you with?
  -> QuestIntro
+ Oh no! Do you want to talk about it?
  -> QuestIntro


== QuestIntro ==
Mrslee?Neutral "You know my grandson. Eddie? He coming back this weekend. I am excited! He's been away at school. He need medication from pharmacy, and I always feel scare."

+ Aw, you sound upset; tell me why you're scared...
  -> QuestDetails1
+ Of course I remember Eddie. But, can I help you feel less worried, Mrs. Lee?
  -> QuestAcceptance

== QuestDetails1 ==
Mrslee?Neutral "Last time, the medicine I pick up doesn't have name that Eddie say! I was so embarrass to ask pharmacist." 
Mrslee?Neutral "Eddie said it was right, but I worry he isn't so careful."

+ I understand! I think we can figure this out together.
 -> QuestDetails2
+ Oh, I'm sorry, that DOES sound very stressful! How can I help?
  -> QuestAcceptance

==QuestDetails2==
Mrslee?Neutral "It is confusing! Eddie need his blood pressure medication. His blood pressure. Too high!"

+ I hear you, Mrs. Lee. I would be happy to help you
  -> QuestAcceptance

== QuestAcceptance ==
Mrslee?Smiling "Thank you {player_name}. Talking make me feel better, but could help me figure out how to know if I get the right medicine at the pharmacy?"

+ Of course I can do that for you, Mrs. Lee.  I want to go ask some questions and I'll be right back.
  -> END
