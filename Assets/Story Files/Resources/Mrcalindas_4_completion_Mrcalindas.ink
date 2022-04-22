VAR player_name = ""
VAR notification = ""
VAR new_contact = ""
VAR new_quest = ""

-> intro

== intro== 

Mrcalindas?Smiling "Hello {player_name}! I bet you didn't expect to see me here."

* Hi. Mr. Calindas, I actually love seeing you out and about. How are you?
  -> Chat1
* Hi. Mr. Calindas. I didn't think you existed outside of the clinic! Since you're here, I think I may have some ideas for you.
  -> Chat1


==Chat1==

Mrcalindas?Smiling "I'm actually waiting for my mother to finish her first aerobics class with Mrs. Lee. So, I'm feeling pretty good."

Mrcalindas?Smiling "It's really feeling like Bloomwood is a great place for my whole family. Did you have ideas for Brooklyn? 

* Well, I think you're going to be happy. Brooklyn too!
  -> Chat2
* I'm excited to share what I learned! 
  -> ReadyToSolve

==Chat2==

Mrcalindas?Neutral "Really? Jessica and I were on the phone last night, trying to make a plan for Brooklyn's time here. I'm looking forward to settling some of her anxiety."

* Both the library and the community center have activities, and they taught me a lot about what to look for when choosing an activity. 
  -> ReadyToSolve


==ReadyToSolve==

Mrcalindas?Neutral "Oh? Rashad and Lila are both very thoughtful. I would like to know what they think."

* Here’s what I have…
  -> PuzzleInterface
* Actually, before I commit, let me check my journal again.
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
  

==Option1==
# correct
Mrcalindas?Smiling "This makes a lot of sense. An over-tired child is never going to get as much out of an activity as a well-rested child. And a hungry person is often a cranky person."

Mrcalindas?Smiling "It seems like the things you take into account for autistic children are similar to the things you keep in mind with other children, if you’re savvy to their ways."

* Maybe, but a little more thoughtfully and with more attention to planning for an exit strategy if things go wrong.
	-> SolvedGoodbye


==Option2==

Mrcalindas?Neutral "Hmm. Did you come up with anything more specific?"
 
Let me see what else I can find, Mr. Calindas.
  ->TempGoodbye

==Option3==

Mrcalindas?Neutral "I feel like this is part of the picture, but did you learn anything else?"
 
Let me see what else I can find, Mr. Calindas.
  ->TempGoodbye


==Option4==
# correct

Mrcalindas?Smiling "I am comforted to know that there are places in Bloomwood that are prepared to support Brooklyn." 

Mrcalindas?Smiling "Maybe she and my mother will both come out with me to playtime at the Community Center, or possibly to story time at the Library. I think they would both enjoy either." 

  
* I think Brooklyn is going to have an excellent week, Mr. Calindas! 
	-> SolvedGoodbye


==SolvedGoodbye==
Mrcalindas?Smiling "Thank you, {player_name}. I appreciate all of your help. I know Jessica will too." 

I learned a lot today, Mr. Calindas. Thank you! 
  -> END

==TempGoodbye==
Mrcalindas?Neutral "I’ll be here when you come back."

* Hold tight! I’ll be right back.
  -> PuzzleInterface
