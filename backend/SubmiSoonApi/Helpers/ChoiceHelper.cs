using SubmiSoonApi.Models;

namespace SubmiSoonApi.Helpers
{
    public static class ChoiceHelper
    {
        public static List<Choice> CreateChoices(params string[] texts)
        {
            return texts.Select(t => new Choice
            {
                Text = t
            }).ToList();
        }
    }
}
