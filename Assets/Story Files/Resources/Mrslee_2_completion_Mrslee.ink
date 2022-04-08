VAR player_name = ""
VAR notification = ""
VAR new_contact = ""
VAR new_quest = ""

-> intro

===intro===
Mrslee?Smiling "{player_name}. Hi. Listen. I was looking for you. My headache went away! I am OK. No problem!"

* {not TempGoodbye} That's great news, Mrs. Lee. But we should talk about what I found out!
  -> Chat1
* {not TempGoodbye} Oh, good! Let's try to make you an appointment before it comes back.
  -> ReadyToSolve
* {TempGoodbye} I got it this time!
  -> ReadyToSolve

==Chat1==
Mrslee?Smiling "Yes, so you don't think I need the doctor anymore, you think?"

* I think it's important to get a routine check up, Mrs Lee.
  -> Chat2
* I think we should still talk about your headaches. Is that okay?
  -> ReadyToSolve

==Chat2==
Mrslee?Neutral "I'm feeling good now because no headache, but when I think about doctors... I feel like headache."

* We can talk about it together; I'll help.
  -> ReadyToSolve

==ReadyToSolve==
Mrslee?Neutral "What should I do?"

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
Mrslee?Smiling "Thank you, {player_name}. I feel good about going to the library program. They help me with my email one time. I know Rashad will take good care of me."
Mrslee?Smiling "He say I am very good with technology; maybe scheduling over the internet will be easier than trying to understand on the phone. I feel less stress.."

* He's right, Mrs. Lee. You're great with tech!
    -> END

==Option2==
Mrslee?Neutral "Rashad is very helpful, but I still feel stress."
Mrslee?Neutral "I need appointments in the future, and maybe Rashad is busy?. What if he can’t help me next time? No thank you."

* Let me see what else I can suggest, Mrs. Lee.
  ->PuzzleInterface
  
==Option3==
Mrslee?Neutral "That feel so stress. Not just headache, but talk about everything? I feel scared that maybe the doctor will talk more than he listen."

* If you don’t like the first doctor you see, we can help you try someone else. 
->Followup22

==Followup22==
Mrslee?Smiling "You help so much already. I try this, but might need more help later."

* Of course, Mrs. Lee! I’m here to help! 
->END

==Option4==
Mrslee?Neutral "That feel like more stress! Eddie say Urgent Care is different doctor every time. Too much trouble."

* I understand, Mrs. Lee. Let’s find you a less stressful solution.
  ->PuzzleInterface
  

==SolvedGoodbye==
Mrslee?Smiling "{player_name}. Thank you for encouraging. I will do."

* I know you can do this, Mrs Lee!
  -> END

==TempGoodbye==
Mrslee?Neutral "{player_name}, OK!"

* I'll come back.
  -> END

==BadSolution==

  -> END