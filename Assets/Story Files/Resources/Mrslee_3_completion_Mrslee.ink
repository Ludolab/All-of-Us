VAR player_name = ""
VAR notification = ""
VAR new_contact = ""
VAR new_quest = ""

-> intro

==intro==
Mrslee?Smiling "Great day, {player_name}!"

* {not TempGoodbye} Great to see you too!
  -> Chat1
* {not TempGoodbye} I thought about how to prepare!
  -> ReadyToSolve
* {TempGoodbye} I really though about it this time.
  -> ReadyToSolve

==Chat1==
Mrslee?Smiling "Hey. Can you believe it, still no headache."

* What about th--
  -> Chat2
* I can help you.
  -> ReadyToSolve

==Chat2==
Mrslee?Neutral "Oh my goodness! I just remember what I worry about. The appointment!"

* I can help you.
  -> ReadyToSolve
* It's okay, Mrs. Lee
  -> ReadyToSolve

==ReadyToSolve==
Mrslee?Neutral "OK. What should I do?"

* Here’s what I have…
  -> PuzzleInterface
* Actually, I'm not ready.
  -> TempGoodbye

==PuzzleInterface==
# turnin

* They picked Option 1. 
  -> Option1
* They picked Option 2. 
  -> Option2
* They picked Option 3.
  -> Option3
* They picked Option 4. 
  -> Option4
* They picked a solution marked as bad.
  -> BadSolution

==Option1==
Mrslee?Smiling "Did you know Eddie like to Facetime? Last time he was home, he asked me to talk sometimes. I know he worry, so this is a good idea.."

* Sharing your health information might be helpful for him, too! 
->Followup31

==Followup31==
Mrslee?Smiling "He ask good questions, and if I write down answers, I feel less stress about forgetting when I talk to doctor. I feel proud of how smart and helpful Eddie is."

->END

==Option2==
Mrslee?Neutral "Lila is very helpful, but her life very busy. If she go to this appointment, what about next appointment. Dr. Lee always take care of everything, and now look! So stress!"

* I think you can do it, Mrs. Lee. I’ll be back with a better suggestion!
-> PuzzleInterface

==Option3==
Mrslee?Smiling "Write down when I feel headache. Write down how bad? I can do that. Thinking about headache make me feel headache, but you say doctor might help."
Mrslee?Smiling "Lila give me special notebook with pretty pink paper. She say if I feel good using my journal, maybe it feel less stress."

* Do you feel like you need more guidance on what to write down?
-> Followup32

==Followup32==
Mrslee?Smiling "I visit Heatlh Clinic and Mr. Calindas gave me pamphlet. It had questions doctor might ask. I will try to answer those questions in my journal, so I have good information to share."

* Oh! Mr. Calindas and his pamphlets are so helpful!
-> END

==Option4==
Mrslee?Neutral "Use my phone, and talk to doctor, and wear hospital gown? That sounds even MORE headache. I’m sorry, but I don’t think that help my headache."

* Oh, Mrs. Lee! You’re right. That sounds hard. I’ll be back.
-> PuzzleInterface

==SolvedGoodbye==
Mrslee?Smiling "{player_name}. Thank you. This way, no stress."

* Goodbye!
  -> END
* Goodbye a different way!
  -> END

==TempGoodbye==
Mrslee?Neutral "OK. I will wait."

* No worries, Mrs. Lee. I'll be back.
  -> END

==BadSolution==

  -> END