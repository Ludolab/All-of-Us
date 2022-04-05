VAR player_name = ""
VAR notification = ""
VAR new_contact = ""
VAR new_quest = ""

-> intro

==intro==
Elisa?Smiling "Hey, friend! How are you, {player_name}?"

* Hey Elisa! I'm feeling good today - how about you? 
  -> Chat1
* Got a minute? I wanna pick your brain.
  -> Chat1

==Chat1==
Elisa?Smiling "For you? always!"
Elisa?Smiling "I have a dental cleaning at 4 today, though. So I need to bounce in time to get over there."

* Ahhh! How do you keep track of your appointments?
  -> Chat2
* Oh drat. I forgot to call and schedule my checkup.
  -> Chat2

==Chat2==
~ notification = "Elisa_Day 4_Mrs. Lee can develop the habit of scheduling the next checkup while she's in the office_Mrslee4-4"
# notification Elisa_Day 4_Mrs. Lee can develop the habit of scheduling the next checkup while she's in the office_Mrslee4-4

Elisa?Smiling "Oh! I always schedule the next appointment when I'm in the office. And I put it right into the calendar on my phone."
Elisa?Smiling "Being able to look a head and see what appointments are coming up helps me manage my time better. "
Elisa?Smiling "You can't forget to schedule an appointment if you don't leave without the next one planned!"

* That's super smart. I'm so going to steal that.
  -> Chat3
* Do you rely on your phone calendar a lot? 
  -> Explain1

==Chat3==
Elisa?Smiling "Hah! Feel free. You were on a mission, though - don't let me distract you!"

* It seems like you use your calendar a lot.
  -> Explain1
* I wanted to ask another question about your family. Is that okay?
   -> Explain2

==Explain1==
Elisa?Smiling "I really do. I like being able to share my calendar with my family, so they have a sense of when I'm busy with class." 
Elisa?Smiling "Honestly, some days, it's the only thing that keeps me focused. I call it my external brain!" 

* Oh, I'm so glad you have a tool that works! 
  -> Explain2
* Does your family use calendars too?
  -> Explain2

==Explain2==
Elisa?Smiling "Always! Mama is always encouraging me to find new tools. She's a little afraid of change, but wants her kids to be at the front of the pack."
Elisa?Smiling "I worry a little about what will happen when I go away for school in the fall."
Elisa?Smiling "I mean, my siblings pitch in. Over time, they've gotten more confident, and need less help. My mom can be a little prideful and I know it hurt her to have to lean so hard on her kids."

* Are there resources you wish you had access to?
  -> Suggestion2
* Do you talk about family health habits together?
  -> Suggestion2

==Suggestion2==
~ notification = "Elisa_Day 4_Mrs. Lee should talk to Eddie about family health history_Mrslee4-3"
# notification Elisa_Day 4_Mrs. Lee should talk to Eddie about family health history_Mrslee4-3

Elisa?Smiling "OH! That's a great question. I just started with a new doctor, and they asked about family health history."
Elisa?Smiling "Neither set of grandparents talked much about their health. Or personal stuff at all. So we know a few details, but it was hard when the doctor asked all these questions, and I had no answers."
Elisa?Smiling "Mom and I started a project documenting as much as she knows about her folks. And my sister is working with Dad on his side of the family."

*  Oh, that's helpful! 
  -> Goodbye
* I love that you're splitting up the work.
  -> Goodbye

==Goodbye==
Elisa?Smiling "There are benefits to being part of a big family! Many hands make for lighter work. That's what they say, right?"
Elisa?Smiling "Say, I should head off for my cleaning. Nice chatting with you!"

* Good luck! Hopefully you're cavity free. Thanks!
  ->END

