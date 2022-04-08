VAR player_name = ""
VAR notification = ""
VAR new_contact = ""
VAR new_quest = ""

-> intro

==intro==
~ new_contact = "Lila"
# new_contact

Lila?Smiling "Hey, {player_name}!! How are you?"

* Hi! It's awesome running into you.
  -> Chat1
* Aw, hey! My day just got better because I ran into you!
  -> Chat1

==Chat1==
Lila?Smiling "Well you always know where to find me; five days a week. Four seasons a year!"
Lila?Smiling "Oh! I even helped Mrs Lee get a volunteering position here."

* That's great for both of you! You must really enjoy it here if you're bringing other people in! 
  -> Chat2
* That's awesome. I ran into Mrs. Lee earlier too; I know the two of you are friends.
  -> Explain1

==Chat2==
Lila?Smiling "I really do. I enjoy the people and I believe in the work." 

* That is very sweet. You were close with Eddie, right?
  -> Chat3
* Nice! Speaking of Mrs. Lee... I could use your help.
  -> Explain1

==Chat3==
Lila?Smiling "Yeah! We were neighbors growing up. We did the whole "walking to school together" thing as kids."

* Awww. Do you think it would be okay, then,  if I asked you to help Mrs. Lee?
  -> Explain1
* That's so sweet! Can I ask you for something regarding Eddie and Mrs Lee?
  -> Explain1

==Explain1==
Lila?Smiling "Ohh yes! I haven't seen her yet this morning, I've been so busy running around. I usually see her before her aerobics class."
Lila?Smiling "She's really been coming out of her shell recently... being around other people definitely helps. She's okay, right?"

* She's trying really hard to help Eddie, but she's stressed out.
  -> Explain2
* She needs some encouragement speaking up for herself at the pharmacy. 
  -> Explain2

==Explain2==
Lila?Neutral "I see, yeah. Oh, Mrs Lee. She needs encouragement stepping into her power. She can do hard things, but I understand that she doesn't really feel it though."

* It's so nice to hear you pump her up like this.
  -> Suggestion1
  
==Suggestion1==
~ notification = "Lila_Day 1_Mrs. Lee could ask Lila to pick up the prescription for her_Mrslee1-1"
# notification Lila_Day 1_Mrs. Lee could ask Lila to pick up the prescription for her_Mrslee1-1

Lila?Neutral "I know this is her prescription anxiety acting up." 
Lila?Smiling "I need to pick up a prescription for Trisha tonight; can I pick up Eddie's prescription up for Mrs. Lee?"
Lila?Smiling "Have her stop by and give me the information, if that would help. "

* I'm not sure she would be comfortable with that... maybe a pep talk instead?
  -> Suggestion2
* That would help her feel better about today, but what about next time? 
  -> Suggestion2

==Suggestion2==
~ notification = "Lila_Day 1_Mrs. Lee could ask Lila to come to the pharmacy with her so she has support asking clarifying questions_Mrslee1-2"
# notification Lila_Day 1_Mrs. Lee could ask Lila to come to the pharmacy with her so she has support asking clarifying questions_Mrslee1-2

Lila?Smiling "Maybe she needs some in-person support; in that case, I'm happy to go with her. She can do this, but I can be her cheerleader!"

* I think having you with her would make Mrs. Lee feel more confident.
  -> Goodbye

==Goodbye==
Lila?Smiling "Sounds good. I can take a break from here whenever!"

* Thanks, you rock!
  ->END
* You're a great friend, Lila. Thank you.
  ->END