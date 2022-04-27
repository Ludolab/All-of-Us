VAR player_name = ""
VAR notification = ""
VAR new_contact = ""
VAR new_quest = ""

-> intro

==intro==

Mrslee?Smiling "Hello {player_name}, nice see you again! How are you doing?"

* I'm great, Mrs. Lee! How are you?
-> Chat1
* Hi, Mrs. Lee! I’m doing good, and yourself?
-> Chat1

==Chat1==
Mrslee?Smiling "I feel okay! I’m looking for some meditation classes, maybe that would help."

* Oh, no are you okay Mrs. Lee? 
-> Chat2

* Oh, cool! Meditation sounds fun. Are you up for a question?
-> Explain1

==Chat2==
Mrslee?Smiling "I will be okay, don’t worry. Sometimes, it is hard to sleep."

Mrslee?Smiling "Eddie suggested physical activity; I already take fitness class and help with Lila's class."

Mrslee?Smilng "Then he suggest I ask Lila. She show me this list of classes that teach meditation and mindfulness exercises."

Mrslee?Smiling "Eddie say maybe I need to make my brain tired too!"

* Eddie sounds like he knows what he's talking about.
-> Chat3
* It sounds like you have this under control! Can I ask you something? 
-> Explain1

==Chat3==
Mrslee?Smiling "I know sometime people take medicine to help sleep but I want to find another way."

Mrslee?Smiling "Sometime I just get up and watch television. Did you know I can watch Korean TV shows now on internet? Dr. Lee would have been so happy."

* That sounds like a good way to cope! Can I ask you something?
-> Explain1

==Explain1==
Mrslee?Neutral "Sure, what is it?"

* The library is super busy and Rashad is looking for extra help. 
-> Explain2
* Do you know anyone looking for a job? Rashad needs someone who loves books.
-> Explain2

==Explain2==
~ notification = "Mrslee_Day 1_Mrs. Lee can ask her friends if their grandchildren want to apply_Rashad1-3"
# notification Mrslee_Day 1_Mrs. Lee can ask her friends if their grandchildren want to apply_Rashad1-3

Mrslee?Neutral "Wow, I have no idea Rashad need help like this. I know lot of friends with grandchildren looking for work. What is the job?"

* They're hiring a part-time worker in the young adult section.
-> Suggestion1
* Rashad is looking for an assistant to help reshelve young adult books. 
-> Suggestion1

==Suggestion1==
~ notification = "Mrslee_Day 1_Asking friends of the library to share the job posting on social media might increase the number of candidates_Rashad1-4"
# notification Mrslee_Day 1_Asking friends of the library to share the job posting on social media might increase the number of candidates_Rashad1-4

Mrslee?Smiling "I met Rashad when he work as the young adult librarian! Now he hire a new person to help in that department."
Mrslee?Smiling "I can spread the word to my friends at my next fitness class. We could post flyer on bulletin board in the Community Center."

* That would be great! Thank you so much. Did you have any other questions?
-> Suggestion2

==Suggestion2==
Mrslee?Smiling "Anything to help out Rashad. When Eddie needed a summer job, Rashad helped him. Showed him how to use the internet to apply. Lots of jobs get posted online now."

Mrslee?Smiling " Maybe we also ask Lila to email people who attend fitness class. And her daycare parents! She know everyone!" 

Mrslee?Smiling "I can post in local groups online; I belong to garden forums and talk about flowers. Maybe someone there likes books."


* Perfect! You can include a link to library's website where people can apply. 
-> Goodbye

==Goodbye==
Mrslee?Smiling "Sounds great, {player_name}! I want to help Rashad because he do so much for the community."
Mrslee?Smiling "I will pass along the message to friends. See you soon."

* Thanks, Mrs. Lee! Take care. 
->END
* You’re the best! See you soon!  
->END















