VAR player_name = ""
VAR notification = ""
VAR new_contact = ""
VAR new_quest = ""

-> intro

==intro==
Elisa?Smiling "Hey {player_name}."

* Elisa! Whatcha up to? 
  -> Chat1
* Hey! Studying hard?  
  -> Chat1

==Chat1==
Elisa?Smiling "I am taking a moment to collect myself. My mom just sent a meme in the family group chat. I'm shocked. It was good!"
Elisa?Smiling "She's starting to get this whole internet humor thing! I wasn't prepared."

* I'm always shocked when parents are good at the internet!
  -> Chat2
* Can I ask a parent question? I could use your experience.
  -> Explain1

==Chat2==
Elisa?Smiling "Now all my siblings are hopping on it... ugh this is so distracting actually. I should be studying..."

* Speaking of elders... Can I ask a question?
  -> Explain1

==Explain1==
Elisa?Neutral "Yeah, sure! I'm happy to help if I can. If it crosses a boundary, I can always say so."

* I'm helping Mrs. Lee prepare for a doctor's appointment. 
  -> Explain2

==Explain2==
Elisa?Smiling "Oh! I was worried for a moment. 'Parent question' sounds so serious!"
Elisa?Smiling "I used to help with all my folks' appointments, until their English got better. How can I help?"

* I was hoping you might have some suggestions to help her feel more comfortable.
  -> Suggestion1
* I knew you'd have helpful perspective! 
  -> Suggestion1
  
==Suggestion1==
~ notification = "Elisa_Day 3_Mrs. Lee could ask someone to be on the phone with her during the appointment_Mrslee3-4"
# notification Elisa_Day 3_Mrs. Lee could ask someone to be on the phone with her during the appointment_Mrslee3-4

Elisa?Smiling "When my mom is worried about an appointment these days, and I can't be there in person, she'll get one of us on speakerphone."
Elisa?Smiling "Honestly, she doesn't need it much anymore, but having one of us available to ask questions makes it less stressful for her."

* Oh... Ok, but what about the appointments where she goes by herself?
  -> Suggestion2
* That's a good idea. Anything else?
  -> Suggestion2

==Suggestion2==
~ notification = "Elisa_Day 3_Mrs. Lee can create a list of questions and symptoms to take to her appointment with her_Mrslee3-3"
# notification Elisa_Day 3_Mrs. Lee can create a list of questions and symptoms to take to her appointment with her_Mrslee3-3

Elisa?Smiling "Well, one of the things we've all learned to do is to write down allllll our questions ahead of time."
Elisa?Smiling "We help "the patient" make a big list of symptoms they want to mention, and sometimes we'll remember something Mom forgot. 
Elisa?Smiling "When it's your appointment, it's easy to forget all the little details."
Elisa?Smiling "Having it in writing makes it feel more real, too, when the doctor asks. You don't need to remember how many times you've been itchy; you just have to look at your notebook."

* That's excellent! 
  -> Goodbye
* I like that you make preparing a family activity! 
  -> Goodbye

==Goodbye==
Elisa?Smiling "Good luck to Mrs. Lee! I need to head to class soon. Anything else?"

* No. You've been super helpful! 
  ->END

