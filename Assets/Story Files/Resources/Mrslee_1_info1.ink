VAR player_name = ""
VAR notification = ""
VAR new_contact = ""
VAR new_quest = ""

-> intro

==intro==
~ new_contact = "Lila"
# new_contact
Lila?Smiling "Hey, {player_name}!! How are you?"

* Hi! It's awesome running into you here.
  -> Chat1
* Aw, hey! My day just got better because I ran into you!
  -> Chat1

==Chat1==
Lila?Smiling "Well you always know where to find me. If you didn't, well, I work here most every day."
* Do you enjoy it?
  -> Chat2
* That's awesome. I ran into Mrs. Lee, you two are very close I remember.
  -> Explain1

==Chat2==
Lila?Smiling "I really do. I love this place and the people. Oh! I even got Mrs Lee a volunteering position here."

* That is very sweet. You were close with Eddie, right?
  -> Chat3
* Nice! Speaking of Mrs. Lee... I could use your help.
  -> Explain1

==Chat3==
Lila?Smiling "Yeah! We were neighbors growing up. We did the whole "walking to school together" thing as kids."

* Aw, then would you mind if I asked you to help Mrs. Lee?
  -> Explain1
* That sounds like a really nice memory. Can I ask you for something regarding Eddie and Mrs Lee?
  -> Explain1

==Explain1==
Lila?Smiling "Ohh yes! I haven't seen her today, I've been so busy running around here. I know she takes her aerobics class today."
Lila?Smiling "She loves those. She's really been coming out of her shell recently... being around other people definitely helps. I love to see it. She's okay, right?"

* She's actually a little discouraged from an encounter at the pharmacy.
  -> Explain2
* She needs some encouragement speaking up for herself at the pharmacy.
  -> Explain2

==Explain2==
Lila?Neutral "I see, yeah. Oh, Mrs Lee. She needs encouragement stepping into her power. She can do hard things. I understand that she doesn't really feel it though."

* It's so nice to hear you pump her up like this.
  -> Suggestion1
* Would you feel comfortable going with her to the pharmacy?
  -> Suggestion2

==Suggestion1==
Lila?Neutral "I kind of talk to her like this all the time. Maybe it's time I give her a big pep talk."
~ notification = "Lila_Day 1_Maybe it’s time i give her a big pep talk"
# notification

* Maybe you could go with her to the pharmacy
  -> Suggestion2
* She could use that
  -> Goodbye

==Suggestion2==
Lila?Smiling "I can go to the pharmacy with Mrs. Lee. I can support her! I love that lady."
~ notification = "Lila_Day 1_Lila can go to the pharmacy with Mrs. Lee._Mrslee1"
# notification

* I think that would make her feel really comfortable if you were with her.
  -> Goodbye

==Goodbye==
Lila?Smiling "Sounds good. I can take a break from here whenever!"

* Thanks, you rock!
  ->END
* You're a great friend, Lila. Thank you.
  ->END
