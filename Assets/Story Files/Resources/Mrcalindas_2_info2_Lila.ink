VAR player_name = ""
VAR notification = ""
VAR new_contact = ""
VAR new_quest = ""

-> intro

===intro===

Lila?Smiling "Hey {player_name}! It's great to run into you." 

* Lila! Great timing! I stopped in on my way to find you; I was needed to return these books before Rashad gets after me!
  -> Chat1
* Hey Lila! It's good to see you. Looks like you've got quite a stack of books there.
  -> Chat1

==Chat1==
Lila?Smiling "Ooo. Are you bringing back? I just checked out some new picture books for my class. I'm really excited to share them with the kids." 

* That sounds sweet. I'm just returning some cookbooks I took out. I managed to make some great chili yesterday.
  -> Chat2
* I bet the kids really appreciate that! I just got cookbooks. Hey, can I ask you a quick question?
  -> Explain1

==Chat2==
Lila?Smiling "Chili, eh? I have a great recipe for vegan chili if you ever want to try it. It's so easy, the kids in my class make it with me."

* Ooo. I may have to take you up on that. Oh, hey, can I ask you a question?
  -> Explain1


==Explain1==
Lila?Neutral "Sure, {player_name}. What's going on?" 

* You helped Mrs. Lee get her volunteer position, right?
  -> Explain2
* I'm curious about volunteer opportunities at the Community Center.
  -> Explain2

==Explain2==
Lila?Neutral "I did help get Mrs. Lee a volunteer position. She's really wonderful with the children, and they love her." 

Lila?Smiling "I don't know if which one of us is getting the most benefit; I love having her help!"

* That's so good to hear. I was wondering if you could tell me more about the benefits of seniors volunteering?
  -> Suggestion1


==Suggestion1==

~ notification = "Lila_Day 2_Some seniors benefit from caring for a pet_Mrcalindas2-3"
# notification Lila_Day 2_Some seniors benefit from caring for a pet_Mrcalindas2-3

Lila?Smiling "Oh there's lots of benefits. You know, seniors can suffer from depression like all of us. Volunteering decreases depression."

Lila?Smiling "Some people do really well with a pet to care for. Other people prefer activities that get them out of the house."

Lila?Smiling "Not just that, but volunteering can also increase mental cognition. Seniors can keep their minds active and sharp, just like Mrs. Lee!"

* Wow. I think we all wish we were as sharp as Mrs. Lee!
  -> Suggestion2
* This is so good to know. I knew I should have come to you.
   -> Suggestion2

==Suggestion2==

~ notification = "Lila_Day 2_Volunteering can combat isolation and loneliness_Mrcalindas2-4"
# notification Lila_Day 2_Volunteering can combat isolation and loneliness_Mrcalindas2-4 


Lila?Smiling "Well, I mentioned depression; isolation and loneliness are real issues for seniors, especially after losing a spouse. That's one thing volunteering can help with."
Lila?Smiling "There's so many different volunteering activities available. It just depends on what they like, and what makes them feel good." 


*  This is so good to know. I knew I should have come to you.
  -> Goodbye

==Goodbye==
Lila?Smiling "Well, you know I'm happy to help. If you know any seniors looking for an opportunity the library and the community center are great places to start."
Lila?Smiling "Don't be afraid to spread the word. I'm going to check these out. Catch you soon, {player_name}!"

* Thanks Lila, have an awesome day!
  ->END

