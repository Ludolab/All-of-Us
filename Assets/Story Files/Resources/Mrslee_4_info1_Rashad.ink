VAR player_name = ""
VAR notification = ""
VAR new_contact = ""
VAR new_quest = ""

-> intro

==intro==
Rashad?Smiling "Hey {player_name}. What's good?"

* Just running around town, y'know, Rashad.
  -> Chat1
* Came in to see your face!
  -> Chat1

==Chat1==
Rashad?Smiling "I'm so tired today. Do you want to grab a coffee with me? "

* Coffee? Always. But that's not you. You okay?
  -> Chat2
* Are you sleeping okay? 
  -> Explain1

==Chat2==
Rashad?Smiling "Yeah. The kids were up and down all night, and Cheryl has a big meeting at work this week so I was up with them. No one warned us that kids run on 15 minutes of sleep and three cheese sticks a day!"
Rashad?Smiling "If they're asleep, I'm worrying about getting them to try new vegetables. If I'm asleep, they wake up."
Rashad?Smiling "At their last pediatrician appointment, the doctor gave me the new FDA food pyramid. If I don't want them living on coffee and fumes like me, I feel like I need to start good habits now."

* That's rough! On that topic, can I ask you a question?
  -> Explain1
* Lemme ask you something, SuperDad! 
  -> Explain1


==Explain1==
Rashad?Smiling "Only if it's related to my kids or comics. I'm in low-power mode, so I can't think about much of anything else, haha."

* It's kinda about your kids
  -> Explain2
* Regular question, I promise
  -> Explain2

==Explain2==
Rashad?Smiling "Sure, I'm game. What's up?"

* How do you track your family's health?
  -> Suggestion1

==Suggestion1==
~ notification = "Rashad_Day 4_Mrs. Lee can keep a folder with all her health information_Mrslee4-2"
# notification Rashad_Day 4_Mrs. Lee can keep a folder with all her health information_Mrslee4-2

Rashad?Smiling "This is one of the things we talk about in the health workshop! So many people don't know what to keep, or how to keep it. I suggest keeping everything in one place."
Rashad?Smiling "Lab results, appointment records, all the various notes."
Rashad?Smiling "I keep track of my whole families' health information in one folder. Actually it's bigger than a folder, but you get what I mean. All the records. All the symptoms and details. One place. Boom."

* Hmm. What if you want to share that information with family in other cities?
  -> Suggestion2
* Oh, absolutely, that's a great idea. Any other tools.
  -> Suggestion2

==Suggestion2==
~ notification = "Rashad_Day 4_Mrs. Lee can work with Eddie to setup a system for sharing health information online_Mrslee4-1"
# notification Rashad_Day 4_Mrs. Lee can work with Eddie to setup a system for sharing health information online_Mrslee4-1

Rashad?Smiling "Oh! I like having this stuff on paper, where I can touch it. Some people set up a shared online folder. I can show you some examples."
Rashad?Smiling "It's much easier to collaborate in a shared document. You just have to get everyone on board, and figure out how to scan things in."
Rashad?Smiling "That's something we can help with at either the health workshop or one of the technology workshops!"

* Oh! This might work for Mrs. Lee and Eddie!
  -> Goodbye
* Rashad, you're the best. These are great suggestions! 
  -> Goodbye

==Goodbye==
Rashad?Smiling "Okay, next time I get to ask the questions, {player_name}. Thanks for stopping by, but I gotta get back to organizing."

* You got it. Thanks! 
  ->END
  

