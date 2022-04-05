VAR player_name = ""
VAR notification = ""
VAR new_contact = ""
VAR new_quest = ""

-> intro

==intro==
Mrslee?Neutral "I am so frustrate--I feel so frustrate!"

* {not TempGoodbye}  Talk to me, Mrs. Lee. I'm listening!
  -> Chat1
* {not TempGoodbye} I think I might be able to help you.
  -> ReadyToSolve
* {TempGoodbye} I think I'm ready now! 
  -> ReadyToSolve


==Chat1==
Mrslee?Neutral "I'm so concerning about Eddie. He has high blood pressure and I worry bad things gonna happen if he don't take."

* When does he need the medication?
  -> Chat2
* I can help you.
  -> ReadyToSolve

==Chat2==
Mrslee?Neutral "He needs medicine when he arrive before the weekend maybe? I need to make sure it's correct."

* I think I know what to do!
  -> ReadyToSolve
* We'll make sure he gets it in time.
  -> ReadyToSolve

==ReadyToSolve==
Mrslee?Neutral "What do you think?"

* Here’s what I have…
  -> PuzzleInterface
* I'll come back to help!
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
  
==Option2==
Mrslee?Smiling "Thank you, {player_name}. I do trust Lila. I have a bad feeling the medicine might be wrong. Lila can help me ask the pharmacist to confirm."
Mrslee?Smiling "Eddie says some drugs have different names, and it is okay, but anyway I am scare for Eddie."
Mrslee?Neutral "Lila can help if I feel embarrass about my English."

* That’s a good idea, Mrs. Lee. Sometimes it’s hard to speak up and ask questions.
-> Followup1 
* I feel like you’re really onto something! Drug names are confusing.
-> Followup1

==Followup1==
Mrslee?Neutral "I want to be brave and ask good questions. Lila can help me practice, then next time, I know enough."
Mrslee?Smiling "Also, next time, the pharmacist won’t be a stranger!"

* I'm here to support you!
    -> END
  
==Option1==
Mrslee?Neutral "No thank you, {player_name}. I want to solve the problem myself."
Mrslee?Neutral "Lila very nice. She do me favor. But next time, what if Lila busy with work? Or Eddie need new medication? I need to know how to ask questions."

* Let me try again
  -> PuzzleInterface
  
==Option4==
  
Mrslee?Neutral "I feel stress, {player_name}. I learn in library workshop that sometimes websites lie. I don't know enough to trust a web search about Eddie's medicine."  

* Let me try again
  ->PuzzleInterface
  
==Option3==
Mrslee?Smiling "I know that the drug can be named lisinopril. If I look it up in the drug portal, they give other names too?"

* Exactly! You can print out the information sheet and take it with you.
-> Followup2 
* Yes, and you can look up high blood pressure and get more information.
-> Followup2

==Followup2==
Mrslee?Neutral "Rashad help me print things at the library sometimes. I will ask him for help at the next health workshop."
Mrslee?Smiling "I feel less stress knowing I can take a printout to show the pharmacist."

* It sounds like you're ready for this! 
 -> END

==SolvedGoodbye==

  -> END

==TempGoodbye==
Mrslee?Neutral "Okay, come back soon!"

* No worries, Mrs. Lee. I will.
  -> END

==BadSolution==

  -> END