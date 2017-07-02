using UnityEngine;
using UnityEngine.UI;
using System.ComponentModel;

public class GameSceneImageController : MonoBehaviour {

    private static Image image;

    public enum ImageRes
    {
        [Description("cave_entry")]
        CAVE_ENTRY,
        [Description("coward_pussy")]
        COWARD_PUSSY,
        [Description("cave_mouth")]
        CAVE_MOUTH,
        [Description("cave_entrance")]
        CAVE_ENTRANCE,
        [Description("cave_swamp")]
        CAVE_SWAMP,
        [Description("cave_animal")]
        CAVE_ANIMAL,
        [Description("cave_crystal")]
        CAVE_CRYSTAL,
        [Description("cave_swamp")]
        CAVE_FOUNTAIN_GATE,
        [Description("cave_fountain_gate")]
        CAVE_FOUNTAIN,
        [Description("cave_night_sky")]
        CAVE_NIGHT_SKY
    };

    // Use this for initialization
    void Start () {
        image = GetComponent<Image>();    		
	}
	
    public static void SetImage(ImageRes sceneImage)
    {
        switch(sceneImage)
        {
            case ImageRes.CAVE_ENTRY:
            case ImageRes.COWARD_PUSSY:
            case ImageRes.CAVE_MOUTH:
            case ImageRes.CAVE_ENTRANCE:
            case ImageRes.CAVE_SWAMP:
            case ImageRes.CAVE_ANIMAL:
            case ImageRes.CAVE_CRYSTAL:
            case ImageRes.CAVE_FOUNTAIN_GATE:
            case ImageRes.CAVE_FOUNTAIN:
            case ImageRes.CAVE_NIGHT_SKY:
                image.sprite = Resources.Load<Sprite>(sceneImage.ToString()); break;
        }
    }
}
