using System.ComponentModel;

// Copy from JumpKing
// namespace JumpKing.MiscSystems.Achievements;
namespace CommonCom;

public enum Achievement
{
    [Description("Just the Beginning|If only you knew... (100 Falls)")]
    FALL_100,

    [Description("Thick Skull|Be happy you have a helmet. (1000 Falls)")]
    FALL_1000,

    [Description("Jump Squire|You have much to learn... (1000 Jumps)")]
    JUMP_1000,

    [Description("Jump Knight|You are a seasoned jumper. (10 000 Jumps)")]
    JUMP_10000,

    [Description("Jump Lord|My lord is a true veteran in the art of jumping! (20 000 Jumps)")]
    JUMP_100000,

    [Description("Talkative|You have heard a taste of the old man's wisdom. (Listen to Old Man 10 times)")]
    TALK_OLDMAN_10,

    [Description("Apprentice of the Pond-Sage|You have heard all that the old man has to teach. (Listen to Old Man 40 times)")]
    TALK_OLDMAN_ALL,

    [Description("Meditations|Hear the advice of the hermit on the mountain. (Listen to Hermit 10 times)")]
    TALK_HERMIT_10,

    [Description("Barter|Each man has his price? (Talk to the merchant 4 times)")]
    TALK_MERCHANT_10,

    [Description("Jump King|Reach the top.")]
    WIN,

    [Description("Swift Jumper|Complete the game within 1 hour.")]
    WIN_TIME_60,

    [Description("Lightning-Speed Jumper|Complete the game within 15 minutes.")]
    WIN_TIME_15,

    [Description("Double King|Finish the game wearing the crown.")]
    WIN_WITH_CROWN,

    [Description("Fashion King|Finish game wearing the special boots.")]
    WIN_WITH_SHOES,

    [Description("Fool me Twice...|You seem to dislike birds?")]
    WIN_TOUCH_CROW_2,

    [Description("Godlike Jumper|Complete the game without falling.")]
    WIN_NO_FALLS,

    [Description("Fashionable|Own the special boots.")]
    PURCHASE_SHOES,

    [Description("Big Spender|Only the finest for a King.")]
    PURCHASE_FOR_10,

    [Description("Fowler|That bird...")]
    CHASE_BIRD_PAST_SNOWSTORM,

    [Description("Fool's Paradise|Reach Chapel Perilous.")]
    REACH_CATHEDRAL,

    [Description("Detective|Enter through an illusory wall.")]
    GO_THOUGH_ILLUSORY_WALL,

    [Description("Off the Beaten Path|Find the room of The Imp.")]
    FIND_IMP_ROOM,

    [Description("Giant Leaps|Complete game with giant boots.")]
    WIN_GIANTBOOTS_REGULAR,

    [Description("Giant Leaps+|Complete NB+ with giant boots.")]
    WIN_GIANTBOOTS_NBP,

    [Description("Absolute Will|Complete the game with Snake Ring.")]
    WIN_ICERING_REGULAR,

    [Description("Absolute Will+|Complete NB+ with Snake Ring.")]
    WIN_ICERING_NPB,

    [Description("New King+|Complete New Babe+.")]
    WIN_NBP,

    [Description("Mad King|Complete New Babe+ without falling.")]
    WIN_NBP_NO_FALLS,

    [Description("Large Feet|Purchase the Giant Boots.")]
    BUY_GIANTBOOTS,

    [Description("Favour of a Higher Being|Receive the Snake Ring.")]
    BUY_ICERING,

    [Description("Blue Ordeal|Reach Deep Ruin.")]
    REACH_SEA,

    [Description("Archeologist|Find the hidden nose.")]
    FIND_NOSE,

    [Description("Deadly Outfit|Wear the Snake Ring and the giant boots at the same time.")]
    WEAR_GIANTBOOTS_AND_ICERING,

    [Description("Giant Leaps Ghost|Complete Ghost of the Babe with giant boots.")]
    WIN_GIANTBOOTS_OWL,

    [Description("Absolute Will Ghost|Complete Ghost of the Babe with Snake Ring.")]
    WIN_ICERING_OWL,

    [Description("Regal Attire|Receive the King's Cape.")]
    GET_OWLCAPE,

    [Description("Exorcist King|Complete Ghost of the Babe.")]
    WIN_OWL,

    [Description("Gnomed Out|Wear the tunic, yellow shoes and the green hat at the same time.")]
    WEAR_TUNIC_YELLOWSHOES_AND_GNOMEHAT,

    [Description("Nobody's Perfect|Complete Ghost of the Babe with only 2 falls.")]
    WIN_OWL_2_FALL,

    [Description("Disciple of the Forest Scholar|How could anyone deny your intellect now?")]
    GET_GNOME_HAT,

    [Description("King & The Gang|Hang with the gang.")]
    TIMESTOP_GARGOYLE_TALK,

    [Description("True Scholar|Become initiated amongst the forest scholars.")]
    PURCHASE_SCHOLAR_TUNIC,

    [Description("Helping a Brother Out|Many thanks, brother!")]
    PURCHASE_YELLOW_SHOES,

    [Description("Bird Outfit|Wear all garments of the most dedicated at once.")]
    WEAR_SHOES_RING_AND_OWLCAPE,

    [Description("King of the Flies|You lose!")]
    CHASE_AWAY_BUG,

    [Description("Cute Cat|Find the 9th cat.")]
    FIND_9TH_CAT,

    [Description("Haunted Jumper|Complete Ghost of the Babe within 1 hour.")]
    WIN_TIME_60_OWL,

    [Description("Possessed Jumper|Complete Ghost of the Babe within 30 minutes.")]
    WIN_TIME_30_OWL
}
