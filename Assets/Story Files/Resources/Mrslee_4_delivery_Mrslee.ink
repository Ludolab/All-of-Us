VAR player_name = ""
VAR notification = ""
VAR new_contact = ""
VAR new_quest = ""

-> intro

==intro==
~ new_quest = "Mrslee4.txt"
# new_quest

Mrslee?Smiling "You wanna see Eddie?"

* Hey, Mrs. Lee! 
  -> Chat1
* Eddie is back?
  -> Chat1

==Chat1==
Mrslee?Smiling "I was reading the newspaper. I was thinking a lot! Eddie called and says he's coming this weekend. Surprise!"

* That IS a surprise! 
   -> Chat2
* What were you thinking about?
  -> Chat2

==Chat2==
Mrslee?Smiling "OH. I forgot to tell you! I went to doctor's office. Doctor was a "SHE," and she was very, very smart. I feel like I understand more things now."

* Yay!! Do you want to talk about it?
-> QuestIntro

==QuestIntro==
Mrslee?Smiling "You know. Eddie's very important to me and I talk about him a lot."

* I know that, Mrs. Lee. I think you're both lucky to have such a deep connection.
  -> QuestDetails1
* You need to think about yourself, too!
  -> QuestAcceptance

==QuestDetails1==
Mrslee?Smiling "I ask question about his blood pressure. You know, it's very funny!"
Mrslee?Smiling "I ask so many question about his Eddie, and the doctor remind me to ask about ME!"

* What about the headaches?
  -> QuestDetails2
* That IS funny! Did you learn anything new?
  -> OptionalQuestDetails1


==OptionalQuestDetails1==
Mrslee?Smiling "Doctor said "Mrs. Lee. Your blood pressure is ... a VERY good number." She asked how I feel. Lots of questions about me."

* Yes, the appointment was for you!
  -> QuestDetails2
* Did you come away with more questions?
  -> QuestAcceptance

==QuestDetails2==
Mrslee?Smiling "We talk about my headache. You know! My eye exam was so bad!"
Mrslee?Smiling "That's why I am getting aching like this. My eyes work so hard. So my head is aching."

* It's great to have some answers!
  -> QuestAcceptance
* You should feel very accomplished, Mrs. Lee!
  -> QuestAcceptance

==QuestAcceptance==
Mrslee?Smiling "I am thinking about this. My health is very important, too! Doctor suggest I should think about how to continue a good health practice for the future."
Mrslee?Smiling "She understand. Say I take better care of Eddie by taking care of me."

* I love that she understood! I'll come back to you after I brainstorm some.
  -> Goodbye
* I'll be back soon with some suggestions; I want to ask some people for their ideas.
  -> Goodbye

==Goodbye==
Mrslee?Smiling "OK. I will sit here and think."

* Okay, Mrs. Lee
  ->END


