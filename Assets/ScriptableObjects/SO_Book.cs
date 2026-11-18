using System;
using System.Collections.Generic;
using UnityEngine;


// SCRIPTABLE OBJECTS BOOKS ********************************+
[CreateAssetMenu(fileName = "Book", menuName = "Scriptable Objects/Book")]

public class SO_Book : ScriptableObject
{
    static Dictionary<GENRES, string> coverColors = new Dictionary<GENRES, string>
    {
        { GENRES.Fantasy, "Purple" },
        { GENRES.Mystery, "Dark Grey" },
        { GENRES.Horror, "Black" },
        { GENRES.History, "Light Yellow" },
        { GENRES.Romance, "Pink" },
        { GENRES.Comics, "Red" },
        { GENRES.Children, "Orange" },
        { GENRES.Manuals, "Grey" },
        { GENRES.Biographies, "Dark Red" },
        { GENRES.Poetry, "Light Blue" },
        { GENRES.Cookbooks, "Light Green" },
        { GENRES.ArtPhotography, "Light Pink" },
        { GENRES.Philosophy, "Yellow" },
        { GENRES.SelfHelp, "White" },
        { GENRES.PhysicsChemestry, "LightPurple/Green" }
    };

    public string title, author;
    public int ID;
    public List<D_Page> pages = new List<D_Page>();
    public string date; // datetime doesn't show up in the inspector, i'll convert it later on
    public bool isBanned;
    public GENRES genre;
    public bool hasPropaganda, hasHiddenMessage;
    public float suspitionPercent;
    public string CoverColor => coverColors[genre];
}
