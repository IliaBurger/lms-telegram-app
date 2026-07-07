using System;
using System.Collections.Generic;

namespace bot1
{
    public enum CourseLevel
    {
        JuniorMinus,
        Junior,
        Middle
    }

    public class Lesson
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string MarkdownContent { get; set; } = string.Empty; 
        public string PracticeTask { get; set; } = string.Empty; 
        public string CorrectCode { get; set; } = string.Empty; 
        public int XpReward { get; set; }
        public string PrerequisiteLessonId { get; set; } = string.Empty;
    }

    public class Module
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public CourseLevel Level { get; set; }
        public List<Lesson> Lessons { get; set; } = new();
    }

    public class UserProfile
    {
        public long TelegramId { get; set; }
        public string Username { get; set; } = string.Empty;
        public int TotalXp { get; set; } = 0;
        public List<string> CompletedLessons { get; set; } = new();
        public DateTime LastActive { get; set; } = DateTime.UtcNow;
        
        public string GetRankTitle()
        {
            if (TotalXp >= 90) return "Middle Developer 🚀";
            if (TotalXp >= 40) return "Junior Developer 🐍";
            return "Trainee (Junior-) 🥚";
        }
    }

    public class LeaderboardEntry
    {
        public int Position { get; set; }
        public string Username { get; set; } = string.Empty;
        public int TotalXp { get; set; }
        public string Rank { get; set; } = string.Empty;
        public bool IsCurrentUser { get; set; }
    }

    public class LoginRequest
    {
        public long TelegramId { get; set; }
        public string Username { get; set; } = string.Empty;
    }

    public class PracticeSubmission
    {
        public long TelegramId { get; set; }
        public string LessonId { get; set; } = string.Empty;
        public string UserCode { get; set; } = string.Empty;
    }
}