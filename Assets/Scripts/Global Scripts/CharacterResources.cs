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
    LEE,
    NONE
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

    public static CHARACTERS GetCharacterFromString(string c)
    {
        switch (c)
        {
            case "Rashad":
                return CHARACTERS.RASHAD;
            case "Lila":
                return CHARACTERS.LILA;
            case "Mr. Calindas":
                return CHARACTERS.CALINDAS;
            case "Elisa":
                return CHARACTERS.ELISA;
            case "Mrs.Lee":
                return CHARACTERS.LEE;
            default:
                return CHARACTERS.RASHAD;
        }
    }

    public static string GetName(CHARACTERS c)
    {
        switch (c)
        {
            case CHARACTERS.RASHAD:
                return "Rashad";
            case CHARACTERS.LILA:
                return "Lila";
            case CHARACTERS.CALINDAS:
                return "Mr. Calindas";
            case CHARACTERS.ELISA:
                return "Elisa";
            case CHARACTERS.LEE:
                return "Mrs. Lee";
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
      GameStrings.getString("rashad_name"),
      GameStrings.getString("rashad_first_name"),
      GameStrings.getString("rashad_description"),
      GameStrings.getString("rashad_title"),
      "",
      GameStrings.getString("rashad_pronouns"),
      int.Parse(GameStrings.getString("rashad_age")),
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
      GameStrings.getString("lila_name"),
      GameStrings.getString("lila_first_name"),
      GameStrings.getString("lila_description"),
      GameStrings.getString("lila_title"),
      "",
      GameStrings.getString("lila_pronouns"),
      int.Parse(GameStrings.getString("lila_age")),
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
      GameStrings.getString("mrcalindas_name"),
      GameStrings.getString("mrcalindas_first_name"),
      GameStrings.getString("mrcalindas_description"),
      GameStrings.getString("mrcalindas_title"),
      "",
      GameStrings.getString("mrcalindas_pronouns"),
      int.Parse(GameStrings.getString("mrcalindas_age")),
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
      GameStrings.getString("elisa_name"),
      GameStrings.getString("elisa_first_name"),
      GameStrings.getString("elisa_description"),
      GameStrings.getString("elisa_title"),
      "",
      GameStrings.getString("elisa_pronouns"),
      int.Parse(GameStrings.getString("elisa_age")),
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
      GameStrings.getString("mrslee_name"),
      GameStrings.getString("mrslee_first_name"),
      GameStrings.getString("mrslee_description"),
      GameStrings.getString("mrslee_title"),
      "",
      GameStrings.getString("mrslee_pronouns"),
      int.Parse(GameStrings.getString("mrslee_age")),
      0f,
      0f,
      0f,
      0f
    );
    lee.SetCharacterEnum(CHARACTERS.LEE);
    return lee;
  }
  
   
}
