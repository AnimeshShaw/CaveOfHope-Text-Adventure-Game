using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class GameInventoryController : MonoBehaviour
{

    public static Image[] invIcons;
    public static RectTransform panel;

    public enum Inventory
    {
        [Description("stick")]
        STICK,
        [Description("rope")]
        ROPE,
        [Description("diamond")]
        DIAMOND,
    }

    private static List<Inventory> collectedItems;

    void Start()
    {
        panel = GetComponent<RectTransform>();

        invIcons = new Image[3];
        invIcons = panel.GetComponentsInChildren<Image>();
        collectedItems = new List<Inventory>();

        foreach (Image image in invIcons)
        {
            image.enabled = false;
        }

        invIcons[0].enabled = true;
    }

    public static void AddInventory(Inventory item)
    {
        if (collectedItems.Contains(item) == false)
        {
            if (item == Inventory.STICK)
            {
                invIcons[1].enabled = true;
                invIcons[1].sprite = Resources.Load<Sprite>(item.ToString());
                collectedItems.Add(Inventory.STICK);
            }

            if (item == Inventory.ROPE)
            {
                invIcons[2].enabled = true;
                invIcons[2].sprite = Resources.Load<Sprite>(item.ToString());
                collectedItems.Add(Inventory.ROPE);
            }

            if (item == Inventory.DIAMOND)
            {
                invIcons[1].enabled = true;
                invIcons[1].sprite = Resources.Load<Sprite>(item.ToString());
                collectedItems.Add(Inventory.DIAMOND);
            }
        }
    }

    public static void RemoveInventory(Inventory item)
    {
        if (collectedItems.Contains(item))
        {
            if (item == Inventory.STICK)
            {
                invIcons[1].enabled = false;
                invIcons[1].sprite = null;
                collectedItems.Remove(Inventory.STICK);
            }
            else if (item == Inventory.ROPE)
            {
                invIcons[2].enabled = false;
                invIcons[2].sprite = null;
                collectedItems.Remove(Inventory.ROPE);
            }
            else if (item == Inventory.DIAMOND)
            {
                invIcons[1].enabled = false;
                invIcons[1].sprite = null;
                collectedItems.Remove(Inventory.DIAMOND);
            }
        }
    }

    public static bool HasElement(Inventory item)
    {
        return collectedItems.Contains(item);
    }
}