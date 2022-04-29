VAR player_name = ""
VAR notification = ""
VAR new_contact = ""
VAR new_quest = ""

-> intro

===intro===
~ new_quest = "Mrslee2.txt"
# new_quest

Mrslee?Smiling "Hello, {player_name}! I got Eddie's medicine. I ask the pharmacist, and it was a different name. Just ask. I should worry less. That's what Eddie says. Too much stress."

* Mrs. Lee! I'm so glad it worked out. How are you today? 
  -> Chat1
* That's great!  You took care of Eddie. Now, how are you?
  -> Chat1


==Chat1==
Mrslee?Neutral "I'm overwhelmed! Everything is harder alone and I just can't get rid of this <a>headache</a>."

* You've been having headaches?
  -> QuestIntro
* Oh, Mrs. Lee. Again? Tell me more?
  -> Chat2
  
  
==Chat2==
Mrslee?Neutral "Eddie say I worry too much. He say I give myself headache from stress, but I try not to stress. and that make me stress!"

* Well, now I'm a little concerned. Can I do anything for you? 
  -> QuestIntro

==QuestIntro==
Mrslee?Neutral "Headache, headache. I get like this all the time. No big deal. Everybody get headache, right?"

* How often do you get headaches like this?
  -> QuestDetails1
* I'd like to help you! Headaches can be symptoms of other health concerns.
  -> QuestDetails2

==QuestDetails1==
Mrslee?Neutral "I talk to my sister on a video call. She said it was fine. Only stress."
Mrslee?Neutral "She said sometimes her head aches when she worry too much. Or when her sleep is bad. Doctors don't fix worry. They make worry."

* Have you gotten it checked out at the <a>doctor</a>'s office?
  -> QuestDetails2
* I'd like to help if you'd let me.
  -> QuestAcceptance

==OptionalQuestDetails1==
Mrslee?Neutral "Thinking about doctors only make my headache worse."

* I'm so sorry. Headaches make everything harder.
  -> QuestDetails2
* I'd really like to help you out; would you let me research options?
  -> QuestAcceptance

==QuestDetails2==
Mrslee?Neutral "I am really fine. It's been like this for years and years. My mother had same problem. She didn't go to doctors."
Mrslee?Neutral "Eddie say I should worry less. Wait until he has grandkids!"

* How often do you get headaches like this?
  -> OptionalQuestDetails2

==OptionalQuestDetails2==
Mrslee?Neutral "I am not sure. They come. They go. I am fine."

* I'm worried about you. Have you talked to Eddie about the headaches?
  -> QuestAcceptance
* Tell me what stresses you out about doctors; maybe I can find solutions.
  -> QuestAcceptance

==QuestAcceptance==
Mrslee?Smiling "I suppose Eddie would like if I ask a doctor. I feel nervous about the appointment and <a>scheduling</a>... that makes me, well, it makes me headache thinking about it."

* I can definitely help you.
  -> Goodbye
* I'll be back soon with some advice.
  -> Goodbye

==Goodbye==
Mrslee?Neutral "Thanks, {player_name}. I'm just gonna be here.

* Please don't worry, Mrs. Lee. I'll be back.
  ->END


