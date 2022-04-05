VAR player_name = ""
VAR notification = ""
VAR new_contact = ""
VAR new_quest = ""

-> intro

===intro===
~ new_quest = "Rashad4.txt"
# new_quest

Rashad?Smiling "Hey, {player_name}! I'm glad you stopped by. I just wanted to thank you for helping me out this week. I was able to get a lot done because of you."

* Hey Rashad! Thanks, man. We're friends, so it's the least I can do. How did everything work out?
  -> Chat1
* Hey Rashad! It's no trouble, really. We all need to help each other. Bloomwood Spirit, right?
  -> QuestIntro

==Chat1==

Rashad?Smiling "Yeah, but still. I was really nervous about therapy, and I feel prepared for my intake interview."
Rashad?Smiling "The recommendation was just what I needed. I might talk to HR about how the board treats me."

* Really? Do you need any support?
  -> Chat2
*  That sounds great, Rashad. You do so much for the community. Bloomwood spirit, man. You've got it.
  -> QuestIntro

==Chat2==
Rashad?Smiling "Nah, I'm good. I'm going to ask one of my allies on the board to help me. If it continues, I'm prepared to go to HR. But wait, that's not what I was going to say."
Rashad?Smiling "The Board approved an initiative I wanted to talk to you about. You're always talking about making sure the neighborhood has connections. Bloomwood spirit, right?" 

* Yes! You know I am all about that Bloomwood spirit. Which sounds corny, but it's important!
  -> QuestIntro

==QuestIntro==
Rashad?Smiling "Hey now. Bloomwood spirit, was- is a thing."
Rashad?Smiling "I explained the changing demographics to the board when I pitched on this, but I want to get an intergenerational dialogue going at the library. "
Rashad?Smiling "A lot of our seniors and young people frequent the library, and I'd like to bring them together."

* Intergenerational dialogue? I'm all for that. Tell me more.
  -> QuestDetails1
* That sounds great! Is there anything I can help with?
  -> QuestAcceptance

==QuestDetails1==
Rashad?Smiling "Okay, so remember how we used to help out the Pribishes all the time? Making sure their lawn was mowed, and just checking in? I pitched a program that's just like that."
Rashad?Smiling "With all these apps for medical care and appointments, I was thinking we could pair teens and seniors."
Rashad?Smiling "Except instead of mowing lawns, they exchange knowledge. That way the teens could speak to mentors and help them with deciphering their health needs, since it seems to be a common problem. What do you think?"

* This is interesting. What do the teens learn?
  -> QuestDetails2
* Ooo, please tell me the teens get neat skills, like cooking. I could have used that...
  -> OptionalQuestDetails1
* That sounds great! Is there anything I can help with?.
  -> QuestAcceptance

==OptionalQuestDetails1==
Rashad?Neutral "You really could have. Mr. Calindas told me you couldn't boil water. Literally. Anyway, yes. They can match up their interests and choose each other."
Rashad?Neutral "So, each teen and senior matches themselves up. Remember how hard it was during the pandemic for some of our seniors whose families are out of the neighborhood?"

* I do remember. That was really tough, but we pulled through.
  -> QuestDetails2
* I do remember. That was really tough. So what can I do?
  -> QuestAcceptance

==QuestDetails2==
Rashad?Neutral "We did pull through, but think about all the young people who know about stuff that seniors just don't. And seniors who can pass down valuable knowledge."
Rashad?Neutral "There's a lot they can teach each other, and we can offer this as a volunteer opportunity, which looks good for college applications, and gives social time to the seniors."

* Well, you're right. Mrs. Pribish taught me how to bake bread. Which oddly, is the only thing I can't burn. How can I help?
  -> QuestAcceptance
* It would look great on a resume, but it would be stellar for the community. How can I help?
  -> QuestAcceptance

==QuestAcceptance==
Rashad?Smiling "You know I'm happy you asked about that, because I do have something you can do."
Rashad?Smiling "To get the ball rolling, I need to know a bit more about what teens and seniors could want from each other. I don't want to just put a program out there with no input."
Rashad?Smiling "Maybe find out more about senior mental health, and what teens feel like they need or want to learn?"

* Sure! I know exactly who to ask about this. I'll see if I can bring you some information.
  -> Goodbye
* This sounds like a great idea, Rashad. I'll ask around!
  -> Goodbye

==Goodbye==
Rashad?Smiling "Thank you so much, {player_name}. Thanks for helping with this. I knew you'd be the right person for this one."
Rashad?Smiling "I feel like my vision for the library is finally coming true. Take care, okay?"

* Take care, Rashad. I'll be back.
  ->END
* Bye Rashad! I'm so excited for you, this is going to go great.
  ->END
