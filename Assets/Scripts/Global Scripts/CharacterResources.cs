using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class helps load the sprites associated with different characters
//it also has an enum for the characters
public class CharacterResources
{

  public enum CHARACTERS{
    RASHAD,
    LILA,
    CALINDAS,
    ELISA,
    LEE
  }

  public static Sprite rashadNeutral;
  public static Sprite rashadTalking;
  public static Sprite rashadSmall;
  
  public static Sprite lilaNeutral;
  public static Sprite lilaTalking;
  public static Sprite lilaSmall;

  public static Sprite calindasNeutral;
  public static Sprite calindasTalking;
  public static Sprite calindasSmall;

  public static Sprite elisaNeutral;
  public static Sprite elisaTalking;
  public static Sprite elisaSmall;

  public static Sprite leeNeutral;
  public static Sprite leeTalking;
  public static Sprite leeSmall;

  public CharacterResources(){
    rashadNeutral = Resources.Load<Sprite>("rashad_neutral");
    rashadTalking = Resources.Load<Sprite>("rashad_talking");
    rashadSmall = Resources.Load<Sprite>("rashad_small");
    
    lilaNeutral = Resources.Load<Sprite>("lila_neutral");
    lilaTalking = Resources.Load<Sprite>("lila_talking");
    lilaSmall = Resources.Load<Sprite>("lila_small");

    calindasNeutral = Resources.Load<Sprite>("calindas_neutral");
    calindasTalking = Resources.Load<Sprite>("calindas_talking");
    calindasSmall = Resources.Load<Sprite>("calindas_small");
    
    elisaNeutral = Resources.Load<Sprite>("elisa_neutral");
    elisaTalking = Resources.Load<Sprite>("elisa_talking");
    elisaSmall = Resources.Load<Sprite>("elisa_small");

    leeNeutral = Resources.Load<Sprite>("lee_neutral");
    leeTalking = Resources.Load<Sprite>("lee_talking");
    leeSmall = Resources.Load<Sprite>("lee_small");
  }

    public Color GetColor(CHARACTERS c)
    {
        switch (c)
        {
            case CHARACTERS.RASHAD:
                return new Color(0.9921569f, 0.6313726f, 0.5686275f, 1.0f);
            case CHARACTERS.LILA:
                return new Color(0.7333333f, 0.8313726f, 0.6784314f, 1.0f);
            case CHARACTERS.CALINDAS:
                return new Color(0.9686275f, 0.8745099f, 0.5803922f, 1.0f);
            case CHARACTERS.ELISA:
                return new Color(0.6156863f, 0.6666667f, 0.8431373f, 1.0f);
            case CHARACTERS.LEE:
                return new Color(0.3294118f, 0.6156863f, 0.5803922f, 1.0f);
            default:
                return new Color(0.9921569f, 0.6313726f, 0.5686275f, 1.0f);
        }
    }
   public string GetName(CHARACTERS c)
    {
        switch (c)
        {
            case CHARACTERS.RASHAD:
                return "Rashad";
            case CHARACTERS.LILA:
                return "Lila";
            case CHARACTERS.CALINDAS:
                return "Calindas";
            case CHARACTERS.ELISA:
                return "Elisa";
            case CHARACTERS.LEE:
                return "Lee";
            default:
                return "Rashad";
        }
    }

    public Sprite GetSmallIcon(CHARACTERS c){
    switch (c){
      case CHARACTERS.RASHAD:
        return rashadSmall;
      case CHARACTERS.LILA:
        return lilaSmall;
      case CHARACTERS.CALINDAS:
        return calindasSmall;
      case CHARACTERS.ELISA:
        return elisaSmall;
      case CHARACTERS.LEE:
        return leeSmall;
      default:
        return rashadSmall;
    }
  }

  public Sprite GetNeutralHeadshot(CHARACTERS c){
    switch (c){
      case CHARACTERS.RASHAD:
        return rashadNeutral;
      case CHARACTERS.LILA:
        return lilaNeutral;
      case CHARACTERS.CALINDAS:
        return calindasNeutral;
      case CHARACTERS.ELISA:
        return elisaNeutral;
      case CHARACTERS.LEE:
        return leeNeutral;
      default:
        return rashadNeutral;
    }
  }

  public static GlobalGameInfo.CharacterItem Rashad(){
    GlobalGameInfo.CharacterItem rashad = new GlobalGameInfo.CharacterItem(
      "Rashad Williams",
      "Rashad",
      "Rashad Williams was born and raised in Bloomwood, and moved back "
      +"after getting his Master’s Degree in Library Science. He is married "
      +"with 2 children (Wife Cheryl, children Octavia and Charles) and "
      +"started out as the popular Young Adult Librarian for Bloomwood Library. "
      +"Since being promoted to Head Librarian last year, he’s tried to make new programs "
      +"available for the Bloomwood Community. He enjoys comic books, science fiction, "
      +"and is an avid runner.",
      "Head Librarian",
      "Bloomwood Library",
      "He/Him/His",
      42,
      0f,
      0f,
      0f,
      0f
    );
    rashad.SetCharacterEnum(CHARACTERS.RASHAD);
    return rashad;
  }

  public static GlobalGameInfo.CharacterItem Lila(){
    GlobalGameInfo.CharacterItem lila = new GlobalGameInfo.CharacterItem(
      "Lila Morgan",
      "Lila",
      "Lila Morgan grew up near Bloomwood, and moved to town when "
      +"she was 17, where she worked with her mom at the Community Center, "
      +"assisting her in her job as a Head Start teacher. After attending "
      +"college at a state school nearby, Lila has recently returned to "
      +"Bloomwood to take her mom’s position as she leaves to travel, and "
      +"now lives in town with her partner Trisha. She is close with Mrs. Lee, "
      +"and loves designing tattoos, teaching her border collie Charlie partner "
      +"tricks, and long car rides with Trisha.",
      "Head Start Teacher",
      "Community Center",
      "She/Her/Hers",
      26,
      0f,
      0f,
      0f,
      0f
    );
    lila.SetCharacterEnum(CHARACTERS.LILA);
    return lila;
  }

  public static GlobalGameInfo.CharacterItem Calindas(){
    GlobalGameInfo.CharacterItem calindas = new GlobalGameInfo.CharacterItem(
      "Mr. Calindas",
      "Mr. Calindas",
      "Giancarlo Calindas, is respectfully known as Mr. Calindas in "
      +"the neighborhood. He moved into the neighborhood 20 years ago, "
      +"when his wife, Paz took a job teaching Biology at Bloomwood Highschool. "
      +"A second generation Filipino American, Mr. Calindas’ parents were "
      +"farmworkers in Southern California, who brought him up with a strong sense "
      +"of community. Mr. Calindas is the steward for his nurse’s union and likes "
      +"to unwind by running. He cares deeply about the health and well-being of the "
      +"neighborhood, and his daughter Jessica and his granddaughter, Brooklyn. ",
      "Head Nurse",
      "Bloomwood Health Clinic",
      "He/Him/His",
      58,
      0f,
      0f,
      0f,
      0f
    );
    calindas.SetCharacterEnum(CHARACTERS.CALINDAS);
    return calindas;
  }
  public static GlobalGameInfo.CharacterItem Elisa(){
    GlobalGameInfo.CharacterItem elisa = new GlobalGameInfo.CharacterItem(
      "Elisa Ramirez",
      "Elisa",
      "Elisa Ramirez grew up in Bloomwood, where her parents moved after "
      +"leaving El Salvador. She’s currently living with her family while "
      +"attending Bloomwood College. She loves reading, spending time with "
      +"friends, physical activity, and the outdoors. She is currently the "
      +"VP of her school’s nature club, and an aspiring freeclimber. She’s "
      +"almost done with her Associates degree at Bloomwood College, and is "
      +"currently getting ready to complete her Bachelor’s at a university "
      +"nearby. She’s studying business, and intends to become a financial "
      +"advisor once she graduates.",
      "College Student",
      "Bloomwood Library",
      "She/Her/Hers",
      19,
      0f,
      0f,
      0f,
      0f
    );
    elisa.SetCharacterEnum(CHARACTERS.ELISA);
    return elisa;
  }

  public static GlobalGameInfo.CharacterItem Lee(){
    GlobalGameInfo.CharacterItem lee = new GlobalGameInfo.CharacterItem(
      "Mrs. Lee",
      "Mrs. Lee",
      "Mrs. Lee is an elder in Bloomwood where "
      +"she has lived for the last 20 years. "
      +"Mrs. Lee and her husband Dr. Lee emigrated "
      +"from South Korea with their grandson Eddie. "
      +"Together, they raised Eddie in Bloomwood, "
      +"speaking a mix of English and Korean. "
      +"After the recent passing of her husband, Mrs. Lee "
      +"schedules regular video calls with her Korean friends "
      +"and occasionally with Eddie, when he’s not in his university "
      +"library. Mrs. Lee loves attending fitness classes at the "
      +"Community Center and her favorite color is pink!",
      "Elder",
      "Community Center",
      "She/Her/Hers",
      65,
      0f,
      0f,
      0f,
      0f
    );
    lee.SetCharacterEnum(CHARACTERS.LEE);
    return lee;
  }
  
   
}
