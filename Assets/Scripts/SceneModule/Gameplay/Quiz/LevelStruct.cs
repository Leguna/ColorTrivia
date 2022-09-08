using UnityEngine;

namespace SceneModule.Gameplay.Quiz
{
    public struct LevelStruct
    {
        public LevelStruct(Sprite hintImage, string[] answers, string quizText)
        {
            HintImage = hintImage;
            Answers = answers;
            QuizText = quizText;
        }

        public string QuizText { get; }
        public Sprite HintImage { get; }
        public string[] Answers { get; }
    }
}