VAR player_name = ""
VAR notification = ""
VAR new_contact = ""
VAR new_quest = ""

-> intro

==intro==
Rashad?Smiling "{player_name}, wassup!"

* Doin' good, Rashad. How 'bout you?
  -> Chat1
* I'm chillin', just preparing for the weekend. You?
  -> Chat1

==Chat1==
Rashad?Smiling "Ahhh yeah! I'm great. My lady and the kids just stopped by so I'm still riding those good vibes. How about you? 

* How is Cheryl doing?
  -> Chat2
* You heard Mrs. Lee's got a new gig over at the community center?
  -> Explain1

==Chat2==
Rashad?Smiling "Cheryl is doing great actually. She's been loving these workout classes they're holding at the community center. She said Mrs. Lee goes too, they have a blast."

* Oh my gosh. I love that for Mrs. Lee and Cheryl
  -> Chat3
* Do you wonder where Mrs. Lee gets all her energy? She impresses me so much! 
  -> Explain1

==Chat3==
Rashad?Smiling "Yeah it's really special for Cheryl. She never really knew Mrs. Lee until recently. Now they be exchanging recipes on email and stuff."

* I should get Mrs. Lee's email... she makes the best glass noodles!
  -> Explain1
* I would love to get on that email thread!
  -> Explain1

==Explain1==
Rashad?Smiling "She's pretty impressive with her tech, too! I once suggested she sit in the computer class we hold here. She knew the most out of all my seniors!

* Community classes at the library, like workshops, huh!
  -> Explain2
* I should come to a workshop sometime.
  -> Explain2

==Explain2==
Rashad?Smiling "Yeah we have tons of workshops at the library. We work hard to be an awesome resource, not just for older folks."
Rashad?Smiling "I started out as the youth librarian, and created all sorts of workshops for teens."
Rashad?Smiling "Librarians help people find great books, but we also answer questions and help with things, when we can."

* What's the next cool thing you're hosting?
  -> Suggestion1
* That's why you're the boss!
  -> Suggestion2

==Suggestion1==
~ notification = "Rashad_Day 2_Mrs. Lee can go to the health programming workshop at the library and ask for help_Mrslee2-1"
# notification Rashad_Day 2_Mrs. Lee can go to the health programming workshop at the library and ask for help_Mrslee2-1

Rashad?Smiling "Tonight is... the health programming workshop. Actually a lot of people show up for this one. We help them figure out various useful online systems."

* Do people ever ask for help using websites and other computer tasks?
  -> Suggestion2
* That's exactly what I needed to hear.
  -> Suggestion2

==Suggestion2==
~ notification = "Rashad_Day 2_Mrs. Lee can ask Rashad to schedule her appointment_Mrslee2-2"
# notification Rashad_Day 2_Mrs. Lee can ask Rashad to schedule her appointment_Mrslee2-2

Rashad?Smiling "If you're in the library, it is literally my job to help you. Need help with something? I got you."
Rashad?Smiling "Figuring out the copy machine? I got you. Setting up an email address? I can help! I'm one of the resources the library offers, man!"

* You are the best Rashad, you don't even know!
  -> Goodbye

==Goodbye==
Rashad?Smiling "Hahaha {player_name} always fun talkin' to ya. See you around."

* Peace!
  ->END

