using System.Collections.Generic;

namespace lb4.Enums;

public class ScientificAchievementMap
{
    public static readonly Dictionary<EScientificAchievement, string> DescriptionMap = new()
    {
        { EScientificAchievement.InternationalSpeech, "International Speech" },
        { EScientificAchievement.ScientificArticle, "Scientific Article" },
        { EScientificAchievement.ScientificPost, "Scientific Post" },
        { EScientificAchievement.PostThesis, "Post Thesis" },
    };
}