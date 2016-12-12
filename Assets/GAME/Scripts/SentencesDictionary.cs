using System.Collections.Generic;

public class SentencesDictionary
{
    Dictionary<SentenceKey, string> data;

    public SentencesDictionary()
    {
        data = new Dictionary<SentenceKey, string>();
        data.Add(SentenceKey.DOOR_BUTTON, "It looks like this can open the door...");
        data.Add(SentenceKey.ARMORY, "Maybe I can open this?");
        data.Add(SentenceKey.CRATE, "This doesn’t look like so heavy...");
        data.Add(SentenceKey.SCREWDRIVER_BEFORE, "A screwdriver...");
        data.Add(SentenceKey.FLASHLIGHT_BEFORE, "A flashlight...");
        data.Add(SentenceKey.TRAPDOOR, "A trapdoor with screws attached...");
        data.Add(SentenceKey.SCREW, "A screw, I need something to unscrew this...");
        data.Add(SentenceKey.OTHER_MAN, "Who is this guy ?");
        data.Add(SentenceKey.COMPUTER, "A computer screen with a card slot...");
        data.Add(SentenceKey.WINDOW, "The stars... I feel alone.");
        data.Add(SentenceKey.CARD_BEFORE, "A magnetic cart...");
        data.Add(SentenceKey.SCREWDRIVER_AFTER, "This could be usefull.");
        data.Add(SentenceKey.FLASHLIGHT_AFTER, "Now I can see better.");
        data.Add(SentenceKey.CARD_AFTER, "This card should be usable somewhere.");
    }

    public string GetSentence(SentenceKey key)
    {
        return data[key];
    }
}