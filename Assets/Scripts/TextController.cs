using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{

    #region Variable Declaration

    public float DELAY = 0.2f;
    private string message;
    private bool challengeCompleted;
    private enum GameState
    {
        Start_S0,
        Coward_CW,
        CaveMouth_CM,
        HeapOfRocks_HOR,
        LeftCave_LT,
        RightCave_RT,
        SwampChallenge_SWC,
        AnimalChallenge_ANC,
        CrystalChallenge_CTC,
        FountainGate_FTG,
        FOUNTAIN,
        DEATH,
        DeveloperTakeAway,
    };

    private GameState gameState;

    public Text mainText;

    #endregion

    // Use this for initialization
    void Start()
    {
        challengeCompleted = false;
        gameState = GameState.Start_S0;
    }

    #region States Section

    private void State_S0()
    {
        message = "Welcome to 'Cave Of Hope' Text Adventure Game!\n\nBackground\n---------------\n" +
            "To cure your bedridden mother's chronic disease you seek knowledge from your village elder. " +
            "The Village Elder told,\n\n\"Thou shall visita 'Cave of Hope', to inveniet the knowledge you " +
            "seek and bring thy mater aqua from the sanctus fall. But heed to your iudicia. \"\n\n\nPress " +
            "C to Continue and R to Run Away.";

        mainText.text = message;

        //StartCoroutine(ShowTypeText(message));

        if (Input.GetKeyDown(KeyCode.C))
        {
            GameSceneImageController.SetImage(GameSceneImageController.ImageRes.CAVE_MOUTH);
            gameState = GameState.CaveMouth_CM;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GameSceneImageController.SetImage(GameSceneImageController.ImageRes.COWARD_PUSSY);
            gameState = GameState.Coward_CW;
        }
    }

    private void State_CW()
    {
        message = "I am Farm Chicken in Human Flesh with no Guts and I like being a Pussy!" +
            "\n\n\nPress S to Start Over.";

        mainText.text = message;

        if (Input.GetKeyDown(KeyCode.S))
        {
            GameSceneImageController.SetImage(GameSceneImageController.ImageRes.CAVE_ENTRY);
            gameState = GameState.Start_S0;
        }
    }

    private void State_CM()
    {
        message = "You went inside the 'Cave' and standing near the mouth of the cave. The " +
            "cave from inside looks more humongous than from the outside. The cave reeks of" +
            " bat faeces.\n\nYou discover two pathways, one on the left and the other on the " +
            "extreme right, and they lead the way deeper into the Cave, and see a large pile " +
            "of rocks stacked in between the two caves.\n\nSelect I to inspect the Rock Pile, " +
            "\n\t\tL to go to Left Cave Entrance, \n\t\tE to go to Right Cave ENtrance, and " +
            "\n\t\tR to run away.";

        mainText.text = message;

        if (Input.GetKeyDown(KeyCode.R))
        {
            GameSceneImageController.SetImage(GameSceneImageController.ImageRes.COWARD_PUSSY);
            gameState = GameState.Coward_CW;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            GameSceneImageController.SetImage(GameSceneImageController.ImageRes.CAVE_MOUTH);
            gameState = GameState.HeapOfRocks_HOR;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            GameSceneImageController.SetImage(GameSceneImageController.ImageRes.CAVE_ENTRANCE);
            gameState = GameState.LeftCave_LT;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            GameSceneImageController.SetImage(GameSceneImageController.ImageRes.CAVE_ENTRANCE);
            gameState = GameState.RightCave_RT;
        }
    }

    private void State_HOR()
    {
        message = "You see a heap of rocks lying on top of each other and all together it " +
            "looks like one giant rock but you notice a small junction rock at the bottom which " +
            "perhaps supports the entire rock pile, but you dare not touch it. You find a " +
            "wooden skick and some ragged rope near the junction point and wonder how it " +
            "got there? You hear some humming noise coming from the left tunnel (probably " +
            "air stream) and faint growling noise from the right cave.\n\nSelect P to Pickup " +
            "Stick and Rope,\n\t\tL to go just inside Left Cave Entrance,\n\t\tR to go just " +
            "inside Right Cave Entrance,\n\t\tB to go back.";

        mainText.text = message;

        if (Input.GetKeyDown(KeyCode.B))
        {
            gameState = GameState.CaveMouth_CM;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            GameInventoryController.AddItem(GameInventoryController.Inventory.STICK);
            GameInventoryController.AddItem(GameInventoryController.Inventory.ROPE);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            GameSceneImageController.SetImage(GameSceneImageController.ImageRes.CAVE_ENTRANCE);
            gameState = GameState.LeftCave_LT;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GameSceneImageController.SetImage(GameSceneImageController.ImageRes.CAVE_ENTRANCE);
            gameState = GameState.RightCave_RT;
        }
    }

    private void State_LT()
    {
        message = "You now stand just inside the left cave. The left cave looks a little or may be " +
            "more than a little gross. Plants and grass coming out of the rocky walls have started " +
            "to decay showing signs that no life can sustain within these rocky walls. \n\nYou suddenly" +
            " feel a gush of chilled wind coming from deep inside the cave. You suspect there might" +
            " be an opening inside.\n\nSelect F to move forward deeper into the cave, and,\n\t\tR to " +
            "Return to the Cave Mouth.";

        mainText.text = message;

        if (Input.GetKeyDown(KeyCode.R))
        {
            GameSceneImageController.SetImage(GameSceneImageController.ImageRes.CAVE_MOUTH);
            gameState = GameState.CaveMouth_CM;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            GameSceneImageController.SetImage(GameSceneImageController.ImageRes.CAVE_SWAMP);
            gameState = GameState.SwampChallenge_SWC;
        }
    }

    private void State_SWC()
    {
        if ((GameInventoryController.HasItem(GameInventoryController.Inventory.ROPE) &&
                GameInventoryController.HasItem(GameInventoryController.Inventory.STICK)) || challengeCompleted)
        {
            if (!challengeCompleted)
            {
                message = "You have now arrived deeper into the the left cave. Suddenly the ground starts " +
                    "shaking and the cave way behind you closes due to collapsed rocks. Now you cannot go back." +
                    " This section of the cave looks like a dead and decayed swamp graveyard. The place is " +
                    "windy and cold.\n\nYou notice that among the dead there's a single plant that is still " +
                    "alive but the main trunk is somewhat broken by the wind. If it stays like that, it will " +
                    "probably die sooner or later.\n\nSelect F to move forward.\n\t\tU to use Rope and Stick " +
                    "to give support to the plant";

                mainText.text = message;

                if (Input.GetKeyDown(KeyCode.U))
                {
                    challengeCompleted = true;

                    GameInventoryController.RemoveItem(GameInventoryController.Inventory.STICK);
                    GameInventoryController.RemoveItem(GameInventoryController.Inventory.ROPE);
                }
                else if (Input.GetKeyDown(KeyCode.F))
                {
                    if (GameInventoryController.HasItem(GameInventoryController.Inventory.ROPE))
                    {
                        message = "You're moving forward deeper into the cave and sudenly you hear some noises " +
                        "coming from above, you look up and see a huge rock falling where you stand.\n\nYou" +
                        " were unable to move and died of a smashed skull.\n\nPress S to Play Again!";

                        GameInventoryController.RemoveItem(GameInventoryController.Inventory.STICK);
                        GameInventoryController.RemoveItem(GameInventoryController.Inventory.ROPE);

                        gameState = GameState.DEATH;
                    }
                }
            }
            else
            {
                message = "You fixed the plant using the stick as support and rope to tie them together. " +
                        "You take a few steps back and feel a glow of satisfaction.\n\nIn moments the chilly wind" +
                        " stops blowing and you witness the environment suddenly change  itself from a dead " +
                        "state to a healthy vegetation. The path ahead of you now shines brighter.\n\nSelect" +
                        " F to move forward.";

                mainText.text = message;

                if (Input.GetKeyDown(KeyCode.F))
                {
                    GameSceneImageController.SetImage(GameSceneImageController.ImageRes.CAVE_CRYSTAL);
                    gameState = GameState.CrystalChallenge_CTC;
                    challengeCompleted = false;
                }
            }
        }
        else
        {
            message = "You have now arrived deeper into the the left cave. Suddenly the ground starts " +
            "shaking and the cave way behind you closes due to collapsed rocks. Now you cannot go back." +
            " This section of the cave looks like a dead and decayed swamp graveyard. The place is " +
            "windy and cold.\n\nYou notice that among the dead there's a single plant that is still " +
            "alive but the main trunk is somewhat broken by the wind. If it stays like that, it will " +
            "probably die sooner or later.\n\nSelect F to move forward.";

            mainText.text = message;

            if (Input.GetKeyDown(KeyCode.F))
            {
                message = "You're moving forward deeper into the cave and sudenly you hear some noises " +
                "coming from above, you look up and see a huge rock falling where you stand.\n\nYou" +
                " were unable to move and died of a smashed skull.\n\nPress S to Play Again!";

                gameState = GameState.DEATH;
            }
        }
    }

    private void State_RT()
    {
        message = "You now stand just inside the right cave. The cave is very uneven and looks like small " +
            "mountains have come out of the walls forming a terrain. It shows no direct way inside the cave. " +
            "However, if you do a little rock climbing then you wouldn't have much problem. \n\nAfter every " +
            "few seconds you feel like you heard a growling sound from inside the cave. You wonder if you " +
            "should go inside.\n\nSelect F to move forward deeper into the cave, and,\n\t\tR to Return to the " +
            "Cave Mouth.";

        mainText.text = message;

        if (Input.GetKeyDown(KeyCode.R))
        {
            GameSceneImageController.SetImage(GameSceneImageController.ImageRes.CAVE_MOUTH);
            gameState = GameState.CaveMouth_CM;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            GameSceneImageController.SetImage(GameSceneImageController.ImageRes.CAVE_ANIMAL);
            gameState = GameState.AnimalChallenge_ANC;
        }

    }

    private void State_ANC()
    {
        if ((GameInventoryController.HasItem(GameInventoryController.Inventory.ROPE) &&
                GameInventoryController.HasItem(GameInventoryController.Inventory.STICK)) || challengeCompleted)
        {
            if (!challengeCompleted)
            {
                message = "You have now arrived deeper into the the right cave. Suddenly the ground starts " +
                    "shaking and the cave way behind you closes due to collapsed rocks. Now you cannot go back." +
                    "\n\nWhile exploring this section of the cave you come across a wild cat but it's staying low and" +
                    " did not run after noticing your presense. You realised the cat has broken it's legs while" +
                    " jumping across the rocky terrain.\n\nSelect F to move forward.\n\t\tU to use the Rope and" +
                    " Stick to help the Cat.";

                mainText.text = message;

                if (Input.GetKeyDown(KeyCode.U))
                {
                    challengeCompleted = true;

                    GameInventoryController.RemoveItem(GameInventoryController.Inventory.STICK);
                    GameInventoryController.RemoveItem(GameInventoryController.Inventory.ROPE);
                }
                else if (Input.GetKeyDown(KeyCode.F))
                {
                    if (GameInventoryController.HasItem(GameInventoryController.Inventory.ROPE))
                    {
                        message = "You went past the cat and when you were just about ten steps ahead, you hear " +
                            "a vicious growling sound coming from behind. The cat turned into an 8 foot tall demon " +
                            "panther.\n\nYour heart may have skipped a beat but before you could do anything you were" +
                            " turned into several pieces of human meat by a single hit from the panters claws.\n\n" +
                            "Press S to Play Again!";

                        GameInventoryController.RemoveItem(GameInventoryController.Inventory.STICK);
                        GameInventoryController.RemoveItem(GameInventoryController.Inventory.ROPE);

                        gameState = GameState.DEATH;
                    }
                }
            }
            else
            {
                message = "You broke the stick into three to four pieces and rest it against the broken part of the" +
                    " cats legs and used the rope to tie them tightly around the leg to support the bone " +
                    "and let it heal itself.\n\nThe cat stopped growling and stood up, walking slowly around" +
                    " your legs. In the next few moments the cat changed into a white cat radiating white" +
                    " light like an Animal spirit and then it vanished into thin air. You stood there in " +
                    "utmost damned amazement thinking what just happened.\n\nSelect F to move forward.";

                mainText.text = message;

                if (Input.GetKeyDown(KeyCode.F))
                {
                    GameSceneImageController.SetImage(GameSceneImageController.ImageRes.CAVE_CRYSTAL);
                    gameState = GameState.CrystalChallenge_CTC;
                    challengeCompleted = false;
                }
            }
        }
        else
        {
            message = "You have now arrived deeper into the the right cave. Suddenly the ground starts " +
                "shaking and the cave way behind you closes due to collapsed rocks. Now you cannot go back." +
                "\n\nWhile exploring this section of the cave you come across a wild cat but it's staying low and" +
                " did not run after noticing your presense. You realised the cat has broken it's legs while" +
                " jumping across the rocky terrain. You don't have anything that can help the poor soul." +
                "\n\nSelect F to move forward.";

            mainText.text = message;

            if (Input.GetKeyDown(KeyCode.F))
            {
                message = "You went past the cat and when you were just about ten steps ahead, you hear " +
                    "a vicious growling sound coming from behind. The cat turned into an 8 foot tall demon " +
                    "panther.\n\nYour heart may have skipped a beat but before you could do anything you were" +
                    " turned into several pieces of human meat by a single hit from the panters claws.\n\n" +
                    "Press S to Play Again!";

                gameState = GameState.DEATH;
            }
        }
    }

    private void State_CTC()
    {
        if (!challengeCompleted)
        {
            message = "After your magical experience you have now reached at another section of the dungeoneous " +
            "cave. This part looks rough and rocky, in addition, it's darker here. \n\nWhat are those? You see" +
            " some shiny rocky crystals attached to the cave walls and many similar looking stones widespread " +
            "across the cave floor. Upon a closer look you realise that these shiny rocks are none other than " +
            " Unpolished Diamond.\n\nSelect T to take the diamonds.\n\t\tF to move forward.";

            mainText.text = message;

            if (Input.GetKeyDown(KeyCode.T))
            {
                GameInventoryController.AddItem(GameInventoryController.Inventory.DIAMOND);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (GameInventoryController.HasItem(GameInventoryController.Inventory.DIAMOND))
                {
                    message = "You filled your pockets with the diamonds and the thought of becoming the richest " +
                        "in the village had your mind occupied. You wouldn't stop looking at those diamonds. You " +
                        "didn't notice that ahead of you was a small cliff. You fall from the cliff and hit your " +
                        "head so hard that you die instantly.\n\nPress S to Play Again!";

                    GameInventoryController.RemoveItem(GameInventoryController.Inventory.DIAMOND);

                    gameState = GameState.DEATH;
                }
                else
                {
                    challengeCompleted = true;
                }
            }
        }
        else
        {
            message = "You ignored the diamonds and moved forward because you didn't come for the diamonds but " +
                "rather a cure for your sick mother. Diamonds wouldn't do you any good since you like earning " +
                "your living by working hard.\n\nYou were walking past the crystals ready to climb down a small" +
                " cliff just ahead when you turn around and notice that the crystals are glowing brighter than " +
                "ever, unable to comprehend the mystical nature of the cave you decide to climb down the cave " +
                "but to add to your surprise a bridge suddenly appears over the cliff for you to continue your " +
                "journey.\n\t\t\t\t\t\t\tPress C to Continue";

            mainText.text = message;

            if (Input.GetKeyDown(KeyCode.C))
            {
                GameSceneImageController.SetImage(GameSceneImageController.ImageRes.CAVE_FOUNTAIN_GATE);
                //GameInventoryController.AddItem(GameInventoryController.Inventory.DIAMOND);                
                gameState = GameState.FountainGate_FTG;
                challengeCompleted = false;
            }
        }
    }

    private void State_FTG()
    {
        if (!challengeCompleted)
        {
            message = "You are now standing in front of a huge stone gate and you could hear the sound of the water " +
            "fall from beyond the gate. You know that you have to cross the gate to get to the fall but their is" +
            " an iron door which is locked. You can break the lock but all the stones / rocks around you is too big" +
            " for you to pick up.\n\nYou see an average-size tortoise which you can pickup.\n\nSelect K to Kill the" +
            " tortoise and use the Hard Shell.\n\t\tS to Search for Alternatives.";

            mainText.text = message;

            if (Input.GetKeyDown(KeyCode.K))
            {
                message = "You decided to killed the Tortoise and use it's hard shell to break the lock on the iron " +
                    "gate. The moment you touched the tortoise from behind you could feel a burning sensation all " +
                    "over your body. Soon you got burning marks and felt the intense pain. \n\nIn just ten mins " +
                    "your body caught fire and you died a painfull death with your ashes in a cave where maybe no " +
                    "human being will ever stepin for the next 100 years.\n\nPress S to Play Again!";

                mainText.text = message;

                gameState = GameState.DEATH;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                challengeCompleted = true;
            }
        }
        else
        {
            message = "You could have kill the tortoise but taking a life to save another isn't justice and your " +
                "mother wouldn't be proud of you. You decided to look for alternatives.\n\nYou're looking around " +
                "to get something to break the lock, just when you hear a cranking sound of rusted iron clashing " +
                "or moving. You see that the iron gate has now opened itself for you. You go and take a look. You" +
                " also find a waterskin.\n\nSelect T to Take the WaterSkin.\n\t\tF to move forward.";

            mainText.text = message;

            if (Input.GetKeyDown(KeyCode.T))
            {
                GameInventoryController.AddItem(GameInventoryController.Inventory.WATERSKIN);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                GameSceneImageController.SetImage(GameSceneImageController.ImageRes.CAVE_FOUNTAIN);
                gameState = GameState.FOUNTAIN;
            }
        }
    }

    private void FOUNTAIN()
    {
        if (GameInventoryController.HasItem(GameInventoryController.Inventory.WATERSKIN))
        {
            message = "You finally arrived at your destination. It looks heavenly and you can't help but admire " +
            "the condescending beauty of nature and this magical cave, \"Cave of Hope\". You can see the " +
            "sparkling water fall which is getting collected in a large crystal vessel. You understand you need" +
            " to collect that water. You hear the sound of rock moving. A passage to the earthly world opens & " +
            "you see that the sun has fallen asleep with stars doing their shift. As you walked out of the Cave" +
            " you noticed that the passage closed and soon there was no trace of door or hidden passage.\n\nSelect" +
            " C to Collect water in your Waterskin and leave the Cave.";

            mainText.text = message;

            if (Input.GetKeyDown(KeyCode.C))
            {
                GameInventoryController.AddItem(GameInventoryController.Inventory.DIAMOND);
                GameSceneImageController.SetImage(GameSceneImageController.ImageRes.CAVE_NIGHT_SKY);

                gameState = GameState.DeveloperTakeAway;
            }
        }
        else
        {
            message = "You finally arrived at your destination. It looks heavenly and you can't help but admire" +
            " the condescending beauty of nature and this magical cave, \"The Cave of Hope\".\n\nYou can see the " +
            "sparkling water fall which is getting collected in a large crystal vessel. You understand you need" +
            " to collect that water. You don't have a waterskin to collect water.\n\nSelect R to Go back to the" +
            "fountain gate";

            mainText.text = message;

            if (Input.GetKeyDown(KeyCode.R))
            {
                GameSceneImageController.SetImage(GameSceneImageController.ImageRes.CAVE_FOUNTAIN_GATE);
                gameState = GameState.FountainGate_FTG;
            }
        }

    }

    private void DevTakeAway()
    {
        GameSceneImageController.SetImage(GameSceneImageController.ImageRes.CAVE_NIGHT_SKY);
        message = "Your exprience was magical and you learned a lot. You adrmired the beauty of the" +
            " night and walked towards home. You felt a bulge in your pocket and looked only to find" +
            " a single diamond. You understood it was a gift and it will be enough to pay for your" +
            " mother's treatment.\n\n\t\t\t\t\tDeveloper TakeAway\n\na.) Be compassionate towards all" +
            " forms of life.\nb.) Greed will make your life a living hell. \nc.) Never harm others for" +
            " personal gain.\n\nThank you for Playing! Press S to Play Again!";

        mainText.text = message;

        if (Input.GetKeyDown(KeyCode.S))
        {
            GameInventoryController.RemoveItem(GameInventoryController.Inventory.DIAMOND);
            GameInventoryController.RemoveItem(GameInventoryController.Inventory.WATERSKIN);
            GameSceneImageController.SetImage(GameSceneImageController.ImageRes.CAVE_ENTRY);
            gameState = GameState.Start_S0;
        }
    }

    private void DEATH(string message)
    {
        mainText.text = message;

        if (Input.GetKeyDown(KeyCode.S))
        {
            GameSceneImageController.SetImage(GameSceneImageController.ImageRes.CAVE_ENTRY);
            gameState = GameState.Start_S0;
        }
    }

    #endregion

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameState.Start_S0: State_S0(); break;
            case GameState.Coward_CW: State_CW(); break;
            case GameState.CaveMouth_CM: State_CM(); break;
            case GameState.HeapOfRocks_HOR: State_HOR(); break;
            case GameState.LeftCave_LT: State_LT(); break;
            case GameState.RightCave_RT: State_RT(); break;
            case GameState.SwampChallenge_SWC: State_SWC(); break;
            case GameState.AnimalChallenge_ANC: State_ANC(); break;
            case GameState.CrystalChallenge_CTC: State_CTC(); break;
            case GameState.FountainGate_FTG: State_FTG(); break;
            case GameState.FOUNTAIN: FOUNTAIN(); break;
            case GameState.DeveloperTakeAway: DevTakeAway(); break;
            case GameState.DEATH: DEATH(message); break;
        }
    }

    // Method to Create Auto Typing Effect
    IEnumerator ShowTypeText(string fullText)
    {
        string currentText;
        for (int i = 1; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            mainText.text = currentText;
            yield return new WaitForSeconds(DELAY);
        }
    }
}