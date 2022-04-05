using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public static class GameStrings {

    private static Dictionary<string, Dictionary<string, string>> strings = new Dictionary<string, Dictionary<string, string>>
    {
        {"English", new Dictionary<string, string>
            {
                // Backstories
                {"backstories_1", "There’s so much to love about Bloomwood! The neighborhood is full of caring, vibrant people and plentiful resources. \n\n As the new Community Manager, your role is to learn what your neighbors need, and help them find answers. Every neighbor has problems you can solve, and information, resources, or skills to contribute."},
                {"backstories_2", "Explore Bloomwood and learn more about your neighbors. Spend a week with each neighbor, and their needs - and thereby your goals - will become clear."},
                {"backstories_3", ""},

                // Ending
                {"ending_1", "I’ve been talking so much about Bloomwood Spirit and getting this block party ready.  Today as we blocked off streets and inflated the giant bounce house, I wondered if all my efforts to help did the job. People have bigger issues. Health, money, family, school...did we make enough time? Share enough resources?"},
                {"ending_2", "Our Block Party is a connection between the old Bloomwood and the new Bloomwood. The smells of food and the whirring of the cotton candy machine all brought back memories. But could this bring the people?"},
                {"ending_3", "Just as I began to worry, Mr. Calindas arrived to set up the Healthcare tent. He patted me on the back before he went to instruct volunteer nurses on how to work with the community. “Paz and Jessica are showing up soon! Don’t worry!”"},
                {"ending_4", "I still worried, but it wasn’t long before Lila waved to me as she and Trisha carried art supplies, mobbed by several children who were as excited to see her outside of class as they were to see her in class. “Yes, I bought the facepaint and temporary tattoos! You just have to let me set up!”"},
                {"ending_5", "Rashad parked the library van, and Octavia and Charles sprinted towards the cotton candy machine. “Ya’ll don’t eat too much of that,” he called out, knowing full well they would eat too much of it."},
                {"ending_6", "The trickle of people became a warm inviting crowd of neighbors. Mrs. Lee, all smiles, brought her grandson Eddie, who I haven’t seen in forever. “Do you remember my grandson, Eddie? I’m very proud of him.” Eddie looked just as proud of her."},
                {"ending_7", "Elisa and her family carried succulents, and a few of her friends from school had boxes filled with extras. “We have the perlite, and the rocks. Mini Bloomwood terrariums, these are gonna be so cute!”"},
                {"ending_8", "We spent the whole day laughing, playing, and celebrating. Mr. Calindas was right. I didn’t need to worry. As music filled the neighborhood and the bounce house shook, I looked at my neighbors. We needed this. I needed this. We could be here, because we all helped each other. Bloomwood spirit has never been about the buildings, or the grants, or the businesses that rush in."},
                {"ending_9", "It’s always been the people."},
                
                // Phone scene
                {"journal_updated", "MyJournal Updated"},
                {"todo_updated", "MyTodo Updated"},
                {"phone_settings_app", "Settings"},
                {"phone_contacts_app", "Contacts"},
                {"phone_todo_app", "To-Do List"},
                {"phone_notes_app", "My Journal"},
                {"phone_dictionary_app", "Dictionary"},
                {"home_screen", "Home Screen"},
                {"no_journal_entries", "No journal entries yet!"},
            
                // Days and Weeks
                {"day", "DAY"},
                {"week", "Week"},
                {"monday", "Monday"},
                {"tuesday", "Tuesday"},
                {"wednesday", "Wednesday"},
                {"thursday", "Thursday"},
                {"friday", "Friday"},
                {"saturday", "Saturday"},
                {"sunday", "Sunday"},

                {"monday_short", "MON"},
                {"tuesday_short", "TUE"},
                {"wednesday_short", "WED"},
                {"thursday_short", "THU"},
                {"friday_short", "FRI"},
                {"saturday_short", "SAT"},
                {"sunday_short", "SUN"},

                // Menus, Buttons, and Map
                {"comm_manager", "Community Manager"},
                {"day_summary", "Day Summary"},
                {"continue", "CONTINUE"},
                {"new_game", "NEW GAME"},
                {"tutorial", "TUTORIAL"},
                {"skip", "SKIP STORY"},
                {"next", "NEXT"},
                {"back", "BACK"},
                {"exit_game", "EXIT GAME"},
                {"info", "INFO"},
                {"save", "SAVE"},
                {"go_to_sleep", "GO TO SLEEP"},
                {"current_task", "Current Task"},
                {"meet", "Meet"},
                {"good_morning_message", "Good morning! Another beautiful day in Bloomwood."},
                {"search_term", "Search a term..."},
                
                // Saved Games
                {"saved_games", "Saved Games"},
                {"next_npc", "Where Do I Want to Start?"},
                {"completed", "Completed"},

                // NPC info
                {"rashad_name", "Rashad Williams"},
                {"rashad_first_name", "Rashad"},
                {"rashad_age_pronouns", "42 years old | He/Him/His"},
                {"rashad_pronouns", "He/Him/His"},
                {"rashad_age", "42"},
                {"rashad_title", "Head Librarian, Bloomwood Library"},
                {"rashad_description", "Rashad was born in Bloomwood.  He moved back after getting his Master’s Degree in Library Science. He is married with 2 children (Wife Cheryl, children Octavia and Charles). He enjoys comic books, science fiction, and is an avid runner."},

                {"lila_name", "Lila Morgan"},
                {"lila_first_name", "Lila"},
                {"lila_age_pronouns", "26 years old | She/Her/Hers"},
                {"lila_pronouns", "She/Her/Hers"},
                {"lila_age", "26"},
                {"lila_title", "Head Start Teacher, Community Center"},
                {"lila_description", "Lila Morgan moved to town when she was 17; her mom worked with the Head Start program. After college, Lila returned to Bloomwood with her partner, Trisha. She is close with Mrs. Lee, and loves teaching her border collie, Charlie, tricks."},

                {"elisa_name", "Elisa Ramirez"},
                {"elisa_first_name", "Elisa"},
                {"elisa_age_pronouns", "19 years old | She/Her/Hers"},
                {"elisa_pronouns", "She/Her/Hers"},
                {"elisa_age", "19"},
                {"elisa_title", "College Student, Bloomwood Library"},
                {"elisa_description", "Elisa Ramirez grew up in Bloomwood, where her parents moved after leaving El Salvador. She will graduate this June with her Associate’s degree in Finance from Bloomwood College. Elisa loves reading, spending time with friends, physical activity, and the outdoors."},

                {"mrcalindas_name", "Mr. Calindas"},
                {"mrcalindas_first_name", "Mr. Calindas"},
                {"mrcalindas_age_pronouns", "58 years old | He/Him/His"},
                {"mrcalindas_pronouns", "He/Him/His"},
                {"mrcalindas_age", "58"},
                {"mrcalindas_title", "Head Nurse, Bloomwood Health Clinic"},
                {"mrcalindas_description", "Mr. Calindas moved to Bloomwood 20 years ago, when his wife, Paz took a job teaching Biology at Bloomwood Highschool. Mr. Calidas likes  to unwind by running or cooking with his daughter, Jessica."},
                
                {"mrslee_name", "Mrs. Lee"},
                {"mrslee_first_name", "Mrs. Lee"},
                {"mrslee_age_pronouns", "65 years old | She/Her/Hers"},
                {"mrslee_pronouns", "She/Her/Hers"},
                {"mrslee_age", "65"},
                {"mrslee_title", "Elder, Community Center"},
                {"mrslee_description", "Mrs. Lee and her husband, Dr. Lee, emigrated from South Korea with their grandson Eddie. Together, they raised Eddie in Bloomwood. Since the recent passing of her husband, Mrs. Lee has become a regular at the fitness classes at the Community Center."},

                // Saving game
                {"please_note", "Please Note!"},
                {"progress_wont_save", "Unfortunately, your progress made in the current task will not be saved."},
                {"saving_progress", "Saving Progress..."},

                // PC Setup
                {"pc_setup_title", "Who are you?"},
                {"name_field", "Name"},
                {"code_field", "Code"},
                {"pronouns_field", "Pronouns"},
                {"language_field", "Language"},
                {"she_her", "She/Her"},
                {"he_his", "He/His"},
                {"they_them", "They/Them"},
                {"other", "Other"},
                {"first_name", "First Name"},
                {"choose_one", "Choose One"},
                {"welcome_title", "Welcome to Bloomwood"},
                {"welcome_text", "Congratulations! Before you start your new role as our Community Manager, tell us a little bit about yourself"},
                {"name_taken", "Name is taken"},
                
                // Languages
                {"english", "English"},
                {"spanish", "Spanish"},

                // Buildings
                {"home", "Home"},
                {"community_center", "Bloomwood Community Center"},
                {"health_clinic", "Bloomwood Health Clinic"},
                {"library", "Bloomwood Library"},

                // Home scene
                {"new_journal_entries", "New Journal Entries"},
                {"block_party_preparations", "Block Party Preparations"},
                {"succulents_planted", "Succulents Planted"},
                {"community_engagement", "Community Engagement"},

                // Start week
                {"startweek_text1", "Are you ready to start the week and help"},
                {"startweek_text2", "solve some problems?"},
                {"startweek_text3", "If not, you can select a different neighbor!"},

                // End of quest
                {"days_left", "DAYS LEFT"},
                {"to_block_party", "to block party for"},

                {"end_of_quest_rashad_1_title", "A Little Help from Your Friends"},
                {"end_of_quest_rashad_1_desc", "You found a library assistant in the YA section! Check in with Rashad and see how he’s doing."},
                {"end_of_quest_rashad_2_title", "Under Pressure"},
                {"end_of_quest_rashad_2_desc", "You helped Rashad learn about race based stress! Check in later and see how he’s doing."},
                {"end_of_quest_rashad_3_title", "Running on Empty"},
                {"end_of_quest_rashad_3_desc", "You helped Rashad figure out the next steps for getting therapy. Check in later to see how he’s feeling."},
                {"end_of_quest_rashad_4_title", "A New Horizon"},
                {"end_of_quest_rashad_4_desc", "You helped Rashad figure out the benefits of intergenerational outreach. Great work this week!"},
            
                {"end_of_quest_lila_1_title", "LGBTQ+ Support"},
                {"end_of_quest_lila_1_desc", "You helped Lila with logistics for her first community event! Check in and see if she needs anything."},
                {"end_of_quest_lila_2_title", "Making time for what's important"},
                {"end_of_quest_lila_2_desc", "You helped Lila learn about her family health history options! See how she’s doing."},
                {"end_of_quest_lila_3_title", "Is this normal?"},
                {"end_of_quest_lila_3_desc", "You helped Lila get information and support for her feminine health care needs. Check in and see how she feels!"},
                {"end_of_quest_lila_4_title", "Where are my people?"},
                {"end_of_quest_lila_4_desc", "You helped Lila make new connections in the neighborhood! Great work this week!"},

                {"end_of_quest_calindas_1_title", "What the Community Really Needs"},
                {"end_of_quest_calindas_1_desc", "Mr. Calindas feels like he’s prepared for the Health Fair! Check in later to see if he needs anything else."},
                {"end_of_quest_calindas_2_title", "Mother Calindas' New Home"},
                {"end_of_quest_calindas_2_desc", "Mr. Calindas feels like his Mother will love the neighborhood! Check in and see how he’s doing!"},
                {"end_of_quest_calindas_3_title", "Tech Support for Mom"},
                {"end_of_quest_calindas_3_desc", "You helped Mr. Calindas find some program options for Mother Calindas. Check in to see if he needs anything else!"},
                {"end_of_quest_calindas_4_title", "A Fun Day for Brooklyn"},
                {"end_of_quest_calindas_4_desc", "Mr. Calindas’ family feels like the Block Party is going to be accessible for his granddaughter! Great work this week!"},

                {"end_of_quest_lee_1_title", "Help Mrs. Lee Feel Confident Picking up Eddie's Prescription"},
                {"end_of_quest_lee_1_desc", "You helped Mrs. Lee figure out the correct prescription for her grandson, Eddie. Check in with her, and see how she’s doing."},
                {"end_of_quest_lee_2_title", "Empower Mrs. Lee to Schedule a Doctor's Appointment"},
                {"end_of_quest_lee_2_desc", "You encouraged Mrs. Lee to seek treatment for her headaches! Check in on her and see if she needs anything else."},
                {"end_of_quest_lee_3_title", "Help Mrs. Lee Prepare for Her Doctor's Appointment"},
                {"end_of_quest_lee_3_desc", "Mrs. Lee is prepared for her doctor’s appointment! You should check in with her to see how she’s doing."},
                {"end_of_quest_lee_4_title", "Encourage Mrs. Lee to Continue Her Health Journey"},
                {"end_of_quest_lee_4_desc", "Mrs. Lee is feeling in charge of her health! Great work this week!"},

                {"end_of_quest_elisa_1_title", "Find out more info on career fairs"},
                {"end_of_quest_elisa_1_desc", "You helped Elisa get ready for her career fair and learn networking tips. Check in with her and see how she is."},
                {"end_of_quest_elisa_2_title", "Find out how to get vaccination records"},
                {"end_of_quest_elisa_2_desc", "You helped Elisa with her immunization questions! Stop by and ask if she needs anything."},
                {"end_of_quest_elisa_3_title", "Find a mentor for Elisa"},
                {"end_of_quest_elisa_3_desc", "You helped Elisa get support as a first generation college student. Check in and see how she’s feeling."},
                {"end_of_quest_elisa_4_title", "Find out more info on diabetes"},
                {"end_of_quest_elisa_4_desc", "You helped Elisa and her Mom with diabetes information. Great work this week!"},
                
                // Tutorial
                {"tutorial_startweek_yellowtitle", "What should I do?"},
                {"tutorial_startweek_whitetitle", "Who should I chat with first?"},
                {"tutorial_startweek_whitetext_1", "Welcome, "},
                {"tutorial_startweek_whitetext_2", ", New Community Manager! \n Click on one of our Bloomwood Residents to learn more about them. You will spend the next week really digging into what they need, and figuring out how best to help them solve their problems."},
                {"tutorial_startweek_buttontext", "GOT IT"},

                {"dictionary_vn_yellowtitle", "Tools and Resources"},
                {"dictionary_vn_whitetitle", "Search in Dictionary"},
                {"dictionary_vn_whitetext_1", "You are about to meet "},
                {"dictionary_vn_whitetext_2", "! \n If you see words or phrases that you are not familiar with, you can try to search it using the dictionary here. Blue text in the dialogue boxes are included in the dictionary."},
                {"dictionary_vn_buttontext", "NEXT"},

                {"speed_vn_yellowtitle", "What should I do?"},
                {"speed_vn_whitetitle", "Wanna speed up?"},
                {"speed_vn_whitetext", "You’re about to have your first conversation with Mrs. Lee. To start chatting, click inside the white box. Select a response to keep the dialogue going!"},
                {"speed_vn_buttontext", "GOT IT"},

                {"task_map_yellowtitle", "What Next?"},
                {"task_map_whitetitle", "Stay On Task!"},
                {"task_map_whitetext", "It was a great conversation! Now you will go gather more information and help them out."},
                {"task_map_buttontext", "NEXT"},

                {"neighbors_map_yellowtitle", "What should I do?"},
                {"neighbors_map_whitetitle", "Talk to your Neighbors"},
                {"neighbors_map_whitetext", "The map shows you all the important places around town. Hover over a location to see who is there right now. \n Click on a neighbor to start a conversation. Each neighbor has specific expertise, and will be able to help with specific questions. Talk to people around town for advice and ideas."},
                {"neighbors_map_buttontext", "NEXT"},

                {"phone_map_yellowtitle", "What should I do?"},
                {"phone_map_whitetitle", "Jot It All Down"},
                {"phone_map_whitetext", "Click on your phone to see what you have learned and check your To-Do List. This will help you figure out your next steps."},
                {"phone_map_buttontext", "GOT IT"},

                {"todolist_phone_yellowtitle", "Tools and Resources"},
                {"todolist_phone_whitetitle", "To-do List"},
                {"todolist_phone_whitetext", "You’ll be collecting solutions to problems your neighbors are facing. Collect all the available information to solve their dilemmas. Your To-Do List on your phone will help you keep track of what you’ve learned, and what your next steps might be.  "},
                {"todolist_phone_buttontext", "GOT IT"},

                {"myjournals_phone_yellowtitle", "Tools and Resources"},
                {"myjournals_phone_whitetitle", "My Journal"},
                {"myjournals_phone_whitetext", "Each conversation you have provides information that might help your neighbors. Useful facts are saved in your journal. \n You can also see what you’ve learned already for other neighbors."},
                {"myjournals_phone_buttontext", "GOT IT"},

                {"tutorial_help", "Help"},


            }
        },
        {"Spanish", new Dictionary<string, string>
            {
                {"new_game", "New Game"},
            }
        }
    };

    public static string getString(string str) {
        return strings[GlobalGameInfo.language][str];
    }

}