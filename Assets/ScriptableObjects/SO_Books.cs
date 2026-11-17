using System;
using System.Collections.Generic;
using UnityEngine;


// SCRIPTABLE OBJECTS BOOKS ********************************+
[CreateAssetMenu(fileName = "Book", menuName = "Scriptable Objects/Book")]

public class SCO_ : ScriptableObject
{
    public enum GENRES { Fantasy, Mystery, Horror, History, Romance, Comics, Children, Manuals, Biographies, Poetry, Cookbooks, ArtPhotography, Philosophy, SelfHelp, PhysicsChemestry };

    Dictionary<GENRES, string> genreColors = new Dictionary<GENRES, string>
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
    public int ID, numPages;
    public string date; // datetime doesn't show up in the inspector, i'll convert it later on
    public bool isBanned;
    public GENRES genre;
    public bool hasPropaganda, hasHiddenMessage;
    public float suspitionPercent;
}
