using System;
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
        DEATH,
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
            GameInventoryController.AddInventory(GameInventoryController.Inventory.STICK);
            GameInventoryController.AddInventory(GameInventoryController.Inventory.ROPE);
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
        if ((GameInventoryController.HasElement(GameInventoryController.Inventory.ROPE) &&
                GameInventoryController.HasElement(GameInventoryController.Inventory.STICK)) || challengeCompleted)
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

                    GameInventoryController.RemoveInventory(GameInventoryController.Inventory.STICK);
                    GameInventoryController.RemoveInventory(GameInventoryController.Inventory.ROPE);
                }
                else if (Input.GetKeyDown(KeyCode.F))
                {
                    if (GameInventoryController.HasElement(GameInventoryController.Inventory.ROPE))
                    {
                        message = "You're moving forward deeper into the cave and sudenly you hear some noises " +
                        "coming from above, you look up and see a huge rock falling where you stand.\n\nYou" +
                        " were unable to move and died of a smashed skull.\n\nPress S to Play Again!";

                        GameInventoryController.RemoveInventory(GameInventoryController.Inventory.STICK);
                        GameInventoryController.RemoveInventory(GameInventoryController.Inventory.ROPE);

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
        if ((GameInventoryController.HasElement(GameInventoryController.Inventory.ROPE) &&
                GameInventoryController.HasElement(GameInventoryController.Inventory.STICK)) || challengeCompleted)
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

                    GameInventoryController.RemoveInventory(GameInventoryController.Inventory.STICK);
                    GameInventoryController.RemoveInventory(GameInventoryController.Inventory.ROPE);
                }
                else if (Input.GetKeyDown(KeyCode.F))
                {
                    if (GameInventoryController.HasElement(GameInventoryController.Inventory.ROPE))
                    {
                        message = "You went past the cat and when you were just about ten steps ahead, you hear " +
                            "a vicious growling sound coming from behind. The cat turned into an 8 foot tall demon " +
                            "panther.\n\nYour heart may have skipped a beat but before you could do anything you were" +
                            " turned into several pieces of human meat by a single hit from the panters claws.\n\n" +
                            "Press S to Play Again!";

                        GameInventoryController.RemoveInventory(GameInventoryController.Inventory.STICK);
                        GameInventoryController.RemoveInventory(GameInventoryController.Inventory.ROPE);

                        gameState = GameState.DEATH;
                    }
                }
            }
            else
            {
                message = "You broke the stick into 3-4 pieces and rest it against the broken part of the" +
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